using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Students.Data;
using Students.Models;

namespace Students.Controllers
{
    public class StudentsClassesController : Controller
    {
        private readonly StudentsContext _context;

        public StudentsClassesController(StudentsContext context)
        {
            _context = context;
        }

        // GET: StudentsClasses
        public async Task<IActionResult> Index()
        {
            return View(await _context.StudentsClass.ToListAsync());
        }

        // GET: StudentsClasses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentsClass = await _context.StudentsClass
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentsClass == null)
            {
                return NotFound();
            }

            return View(studentsClass);
        }

        // GET: StudentsClasses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StudentsClasses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Surname,Birthday,Pesel")] StudentsClass studentsClass)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentsClass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(studentsClass);
        }

        // GET: StudentsClasses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentsClass = await _context.StudentsClass.FindAsync(id);
            if (studentsClass == null)
            {
                return NotFound();
            }
            return View(studentsClass);
        }

        // POST: StudentsClasses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Surname,Birthday,Pesel")] StudentsClass studentsClass)
        {
            if (id != studentsClass.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentsClass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentsClassExists(studentsClass.Id))
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
            return View(studentsClass);
        }

        // GET: StudentsClasses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentsClass = await _context.StudentsClass
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentsClass == null)
            {
                return NotFound();
            }

            return View(studentsClass);
        }

        // POST: StudentsClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studentsClass = await _context.StudentsClass.FindAsync(id);
            _context.StudentsClass.Remove(studentsClass);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentsClassExists(int id)
        {
            return _context.StudentsClass.Any(e => e.Id == id);
        }
    }
}
