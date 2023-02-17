using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crop_Img.Model.Models
{
    public class Lessons
    {
        [Key]
        public Guid LessonId { get; set; }
        [Required]
        public string? LessonName { get; set; }
        [Required]
        public int LessonNo { get; set; }
        [ForeignKey("Book")]
        public Guid BookId { get; set; }
        public virtual Book? Book { get; set; }
    }
}
