using SchoolManagementSystemKarloStarcevic.Models;
using System.Collections.Generic;

namespace SchoolManagementSystemKarloStarcevic.Controllers
{
    internal class HomeIndexViewModel
    {
        public List<Teacher> Teachers { get; set; }
        public List<Student> Students { get; set; }
        public List<Subject> Subjects { get; set; }
    }
}