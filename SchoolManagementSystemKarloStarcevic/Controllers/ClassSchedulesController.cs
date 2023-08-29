using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystemKarloStarcevic.Data;
using SchoolManagementSystemKarloStarcevic.Models;

namespace SchoolManagementSystemKarloStarcevic.Controllers
{
    [Authorize]

    public class ClassSchedulesController : Controller
    {
        
        private readonly ApplicationDbContext _context;
       

        public ClassSchedulesController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        // GET: ClassSchedules
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ClassSchedules.Include(c => c.Subject).Include(c => c.Teacher);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ClassSchedules/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classSchedule = await _context.ClassSchedules
                .Include(c => c.Subject)
                .Include(c => c.Teacher)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (classSchedule == null)
            {
                return NotFound();
            }

            return View(classSchedule);
        }

        // GET: ClassSchedules/Create
        public IActionResult Create()
        {
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", "SubjectName");
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "Id", "FirstName");
            return View();
        }

        // POST: ClassSchedules/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StartTime,EndTime,TeacherId,SubjectId")] ClassSchedule classSchedule)
        {
            if (ModelState.IsValid)
            {
                _context.Add(classSchedule);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", "SubjectName", classSchedule.SubjectId);
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "Id", "FirstName", classSchedule.TeacherId);
            return View(classSchedule);
        }

        // GET: ClassSchedules/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classSchedule = await _context.ClassSchedules.FindAsync(id);
            if (classSchedule == null)
            {
                return NotFound();
            }
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", "SubjectName", classSchedule.SubjectId);
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "Id", "FirstName", classSchedule.TeacherId);
            return View(classSchedule);
        }

        // POST: ClassSchedules/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StartTime,EndTime,TeacherId,SubjectId")] ClassSchedule classSchedule)
        {
            if (id != classSchedule.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(classSchedule);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClassScheduleExists(classSchedule.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", "SubjectName", classSchedule.SubjectId);
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "Id", "FirstName", classSchedule.TeacherId);
            return View(classSchedule);
        }

        // GET: ClassSchedules/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classSchedule = await _context.ClassSchedules
                .Include(c => c.Subject)
                .Include(c => c.Teacher)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (classSchedule == null)
            {
                return NotFound();
            }

            return View(classSchedule);
        }

        // POST: ClassSchedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var classSchedule = await _context.ClassSchedules.FindAsync(id);
            _context.ClassSchedules.Remove(classSchedule);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClassScheduleExists(int id)
        {
            return _context.ClassSchedules.Any(e => e.Id == id);
        }
    }
}
