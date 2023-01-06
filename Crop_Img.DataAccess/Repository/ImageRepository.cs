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
    public class ImageRepository : Repository<Image>, IImageRepository
    {
        private readonly ApplicationDbContext _db;
        public ImageRepository(ApplicationDbContext db) :base(db)
        {
            _db = db;
        }

        public async Task Update(Image image)
        {
            var imgObj = await _db.Image.FirstOrDefaultAsync(x => x.Id == image.Id);
            if (imgObj != null)
            {
                imgObj.ImageByte = image.ImageByte;
            }
        }
    }
}
