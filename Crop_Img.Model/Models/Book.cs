using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crop_Img.Model.Models
{
    public class Book
    {
        [Key]
        public Guid BookId { get; set; }
        [Required]
        [DisplayName("Book Name")]
        public string? BookName { get; set; }
        [NotMapped]
        public List<Lessons> LessonList { get; set; }
    }
}
