using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crop_Img.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        public IImageRepository Image { get; }
        public IBookRepository Book { get; }
        public ILessonRepository Lesson { get; }
        Task SaveAsync();
    }
}
