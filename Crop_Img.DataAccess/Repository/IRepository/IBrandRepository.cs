using Crop_Img.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crop_Img.DataAccess.Repository.IRepository
{
    public interface IBrandRepository : IRepository<Brand>
    {
        Task Update(Brand brand);
    }
}
