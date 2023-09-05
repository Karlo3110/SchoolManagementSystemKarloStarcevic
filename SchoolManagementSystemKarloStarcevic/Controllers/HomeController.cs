using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
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
            //storeanje lista predmeta, profesora, studenta, objava i rasporeda za prikaz na View-u
            var teachers = _context.Teachers.ToList();
            var students = _context.Students.ToList();
            var subjects = _context.Subjects.Include(s => s.Teacher).ToList();
            var classSchedule = _context.ClassSchedules.Include(cs => cs.Teacher).Include(cs => cs.Subject).ToList();
            var posts = _context.Posts.Include(p => p.User).OrderByDescending(p => p.DateOfPosting).Take(5).ToList();

            ViewBag.Teachers = teachers;
            ViewBag.Students = students;
            ViewBag.Subjects = subjects;
            ViewBag.ClassSchedule = classSchedule;
            ViewBag.Posts = posts;

            return View();
        }
    }
}
