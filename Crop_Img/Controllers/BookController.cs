using Crop_Img.DataAccess.Repository.IRepository;
using Crop_Img.Model.Models;
using Microsoft.AspNetCore.Mvc;

namespace Crop_Img.Controllers
{
    public class BookController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public BookController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SaveBook(Book objBook)
        {
            if(objBook.LessonList.Count != 0)
            {
                if (ModelState.IsValid)
                {
                    await _unitOfWork.Book.AddAsync(objBook);
                    foreach (var item in objBook.LessonList)
                    {
                        item.BookId = objBook.BookId;
                        await _unitOfWork.Lesson.AddAsync(item);
                    }
                }
                await _unitOfWork.SaveAsync();
            }
            return View("Index");        }
    }
}
