using Crop_Img.DataAccess.Repository.IRepository;
using Crop_Img.Model.Models;
using Microsoft.AspNetCore.Mvc;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp;
using System.Drawing;
using static System.Net.Mime.MediaTypeNames;
using SixLabors.ImageSharp.Formats;

namespace Crop_Img.Controllers
{
    public class ImageController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ImageController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            //IEnumerable<Model.Models.Image> imageList = await _unitOfWork.Image.GetAllAsync();
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> UploadImage(Model.Models.Image image, IFormFile up_img)
        {
            string BytesInString = "";
            IImageFormat format;
            if (image.ImageWidth != 0 && image.ImageHeight != 0 && up_img != null)
            {
                using (var ms = new MemoryStream())
                {
                    //img.CopyTo(ms);
                    using (SixLabors.ImageSharp.Image imgToCrop = SixLabors.ImageSharp.Image.Load(up_img.OpenReadStream(), out format))
                    {
                        //if(image.Width > 100 && image.Height >100)
                        //{
                        //    image.Mutate(x => x.Resize(220, 260));
                        //}
                        //image.Mutate(x => x.Resize(220, 260));
                        imgToCrop.Mutate(x => x.Resize(image.ImageWidth,image.ImageHeight));
                        imgToCrop.Save(ms, format);
                    }
                    var fileBytes = ms.ToArray();
                    BytesInString = Convert.ToBase64String(fileBytes);
                }
                image.ImageByte = BytesInString;
                await _unitOfWork.Image.AddAsync(image);
                await _unitOfWork.SaveAsync();
                return Json(new { success = true });
            }

            return Json(new { success = false });
        }

        [HttpGet]
        public async Task<IActionResult>SummonedImages()
        {
            IEnumerable<Model.Models.Image> imageList = await _unitOfWork.Image.GetAllAsync();
            return PartialView("_ShowImages", imageList);
        }
    }
}
