using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crop_Img.Model.Models
{
    public class Image
    {
        [Key]
        public Guid Id { get; set; }
        public string? ImageByte { get; set; }
        public int ImageWidth { get; set; }
        public int ImageHeight { get; set; }
    }
}
