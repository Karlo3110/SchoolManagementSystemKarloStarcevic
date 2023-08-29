using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystemKarloStarcevic.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Field First Name is required.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Field Last Name is required.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Field Birth Date is required.")]
        [Display(Name = "Birth Date")]
        public DateTime BirthDate { get; set; }

        public ICollection<Subject> SubjectsAttended { get; set; } = new List<Subject>();
    }
}
