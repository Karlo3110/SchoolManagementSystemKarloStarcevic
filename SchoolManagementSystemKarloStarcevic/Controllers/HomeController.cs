using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystemKarloStarcevic.Data;
using SchoolManagementSystemKarloStarcevic.Models;
using System.Linq;

namespace SchoolManagementSystemKarloStarcevic.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var teachers = _context.Teachers.ToList();
            var students = _context.Students.ToList();
            var subjects = _context.Subjects.Include(s => s.Teacher).ToList();
            var classSchedule = _context.ClassSchedules.Include(cs => cs.Teacher).Include(cs => cs.Subject).ToList();

            ViewBag.Teachers = teachers;
            ViewBag.Students = students;
            ViewBag.Subjects = subjects;
            ViewBag.ClassSchedule = classSchedule;

            return View();
        }
    }
}
