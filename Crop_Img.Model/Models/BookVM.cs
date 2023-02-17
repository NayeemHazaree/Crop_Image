using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crop_Img.Model.Models
{
    public class BookVM
    {
        public List<Book>? Books { get; set; }
        public List<Lessons> Lessons { get; set; }
    }
}
