using Crop_Img.DataAccess.Data;
using Crop_Img.DataAccess.Repository.IRepository;
using Crop_Img.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crop_Img.DataAccess.Repository
{
    public class LessonRepository : Repository<Lessons>, ILessonRepository
    {
        private readonly ApplicationDbContext _db;
        public LessonRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
