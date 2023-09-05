using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace SchoolManagementSystemKarloStarcevic.Models
{
    public class Teacher
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Field Name is required.")]
        [Display(Name = "Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Field Surname is required.")]
        [Display(Name = "Surname")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Field Birth date is required.")]
        [Display(Name = "Birth date")]
        public DateTime BirthDate { get; set; }
        //profesor moze odrzavati predmet - prilikom kreiranja se nudi predmet
        public ICollection<Subject> SubjectsTaught { get; set; } = new List<Subject>();
    }
}
