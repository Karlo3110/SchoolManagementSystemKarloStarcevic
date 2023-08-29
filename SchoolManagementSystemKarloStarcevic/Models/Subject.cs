using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystemKarloStarcevic.Models
{
    public class Subject
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Field Name is required.")]
        [Display(Name = "Name")]
        public string SubjectName { get; set; }
        [Display(Name = "Teacher")]
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public ICollection<Student> Students { get; set; } = new List<Student>();
    }
}
