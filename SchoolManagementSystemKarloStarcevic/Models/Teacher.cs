using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace SchoolManagementSystemKarloStarcevic.Models
{
    public class Teacher
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Polje Ime je obavezno.")]
        [Display(Name = "Ime")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Polje Prezime je obavezno.")]
        [Display(Name = "Prezime")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Polje Datum rođenja je obavezno.")]
        [Display(Name = "Datum rođenja")]
        public DateTime BirthDate { get; set; }

        public ICollection<Subject> SubjectsTaught { get; set; } = new List<Subject>();
    }
}
