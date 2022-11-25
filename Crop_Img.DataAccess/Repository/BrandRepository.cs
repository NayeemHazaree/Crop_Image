using Crop_Img.DataAccess.Data;
using Crop_Img.DataAccess.Repository.IRepository;
using Crop_Img.Model.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crop_Img.DataAccess.Repository
{
    public class BrandRepository : Repository<Brand>, IBrandRepository
    {
        private readonly ApplicationDbContext _db;
        public BrandRepository(ApplicationDbContext db) :base(db)
        {
            _db = db;
        }

        public async Task Update(Brand brand)
        {
            var brandItem = await _db.Brand.FirstOrDefaultAsync(x => x.Id == brand.Id);
            if (brandItem != null)
            {
                brandItem.BrandImg = brand.BrandImg;
            }
        }
    }
}
