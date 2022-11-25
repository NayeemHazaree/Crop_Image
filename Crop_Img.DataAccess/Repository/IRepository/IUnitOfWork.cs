using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crop_Img.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        public IBrandRepository Brand { get; }
        Task SaveAsync();
    }
}
