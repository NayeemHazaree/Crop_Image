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
    public class BrandController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public BrandController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<Brand> brandList = await _unitOfWork.Brand.GetAllAsync();
            return View(brandList);
        }



        [HttpPost]
        public async Task<IActionResult> UploadImage(IFormFile img)
        {
            string BytesInString = "";
            IImageFormat format;
            if (img != null)
            {
                using (var ms = new MemoryStream())
                {
                    //img.CopyTo(ms);
                    using (SixLabors.ImageSharp.Image image = SixLabors.ImageSharp.Image.Load(img.OpenReadStream(),out format))
                    {
                        if(image.Width > 100 && image.Height >100)
                        {
                            image.Mutate(x => x.Resize(100, 100));
                        }
                        image.Save(ms, format);
                    }
                    var fileBytes = ms.ToArray();
                    BytesInString = Convert.ToBase64String(fileBytes);
                }
            }
            Brand brand = new()
            {
                Id = new Guid(),
                BrandImg = BytesInString
            };
            await _unitOfWork.Brand.AddAsync(brand);
            await _unitOfWork.SaveAsync();
            return Json(new { success = true });
        }

        [HttpGet]
        public async Task<IActionResult>SummonedImages()
        {
            IEnumerable<Brand> brandList = await _unitOfWork.Brand.GetAllAsync();
            return PartialView("_ShowImages",brandList);
        }
    }
}
