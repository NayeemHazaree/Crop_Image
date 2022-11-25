using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crop_Img.Model.Models
{
    public class Brand
    {
        [Key]
        public Guid Id { get; set; }
        public string? BrandImg { get; set; }
    }
}
