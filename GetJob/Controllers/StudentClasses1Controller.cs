using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CleanArchitecture.DomainCore.Models;
using CleanArchitecture.Infrastucture.Data.Context;

namespace GetJob.Controllers
{
    public class StudentClasses1Controller : Controller
    {
        private readonly GetJobDbContext _context;

        public StudentClasses1Controller(GetJobDbContext context)
        {
            _context = context;
        }

        // GET: StudentClasses1
        public async Task<IActionResult> Index(string text,string text1)
        {
            /* var result = new List<StudentClass>();
             var studs = _context.StudentClasses.ToList();
             for (int i = 0; i < studs.Count(); i++)
             {

                 if (!String.IsNullOrEmpty(text))
                 {
                     // result[i].Students = _context.Students.Where(d => d.Name.Contains(text)).FirstOrDefault();
                     studs[i].Students = _context.Students.Where(x => x.Id == studs[i].StudentsId && x.Name.Contains(text)).FirstOrDefault();
                 }
             }*/

            var getJobDbContext = _context.StudentClasses.Include(s => s.Class).Include(s => s.Students).Where(s => s.Students.Name.Contains(text)).Where(s => s.Students.Surname.Contains(text1)).Include(s => s.Class.Subjects).Include(s => s.Class.Classroom).Include(s => s.Class.Teachers); ;



                return View(getJobDbContext);
            
          
          /*  for (int i = 0; i < studs.Count(); i++)
            {

                if (!String.IsNullOrEmpty(text))
                {
                    // result[i].Students = _context.Students.Where(d => d.Name.Contains(text)).FirstOrDefault();
                    studs[i].Students = _context.Students.Where(x => x.Id == studs[i].StudentsId && x.Name.Contains(text)).FirstOrDefault();
                    studs[i].Class = _context.Classes.Where(x => x.Id == studs[i].ClassId).FirstOrDefault();
                    
                    if (studs[i].Students != null)
                    {
                        result.Add(studs[i]);
                    }
                }
           




            }

            return View( result);
           */
        }

        // GET: StudentClasses1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentClass = await _context.StudentClasses
                .Include(s => s.Class)
                .Include(s => s.Students)
                .AsNoTracking()
                .Include(s => s.Class.Subjects)
                .Include(s => s.Class.Classroom)
                .Include(s => s.Class.Teachers)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentClass == null)
            {
                return NotFound();
            }

            return View(studentClass);
        }

        // GET: StudentClasses1/Create
        [HttpGet]
        public IActionResult Create()
        {

            ViewData["ClassId"] = new SelectList(_context.Classes, "Id", "Time");
              ViewData["StudentsId"] = new SelectList(_context.Students, "Id", "Surname");
           // PopulateDepartmentsDropDownList();





            return View();

            
            
        }

        

        // POST: StudentClasses1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClassId,StudentsId")] StudentClass studentClass,Classes classes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentClass);

               // _context.Add(classes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }

            
                 
            ViewData["ClassId"] = new SelectList(_context.Classes, "Id", "Time",studentClass.Class.Time);

            ViewData["StudentsId"] = new SelectList(_context.Students, "Id", "Name", studentClass.Students.Name);

            
           /* PopulateDepartmentsDropDownList(studentClass.StudentsId);
            PopulateDepartmentsDropDownList(studentClass.ClassId);*/
            return View(studentClass);
        }

       
        // GET: StudentClasses1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentClass = await _context.StudentClasses.FindAsync(id);
            if (studentClass == null)
            {
                return NotFound();
            }
            PopulateDepartmentsDropDownList(studentClass.ClassId);
            PopulateDepartmentsDropDownList(studentClass.StudentsId);
            /*ViewData["ClassId"] = new SelectList(_context.Classes, "Id", "Id", studentClass.ClassId);
            ViewData["StudentsId"] = new SelectList(_context.Students, "Id", "Id", studentClass.StudentsId);*/
            return View(studentClass);
        }

        // POST: StudentClasses1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("Id,ClassId,StudentsId")] StudentClass studentClass)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseToUpdate = await _context.StudentClasses
                .FirstOrDefaultAsync(c => c.Id== id);

            if (await TryUpdateModelAsync<StudentClass>(courseToUpdate,
                "",
                c => c.Id, c => c.ClassId, c => c.StudentsId))
            {
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException /* ex */)
                {
                    //Log the error (uncomment ex variable name and write a log.)
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                }
                return RedirectToAction(nameof(Index));
            }
            PopulateDepartmentsDropDownList(courseToUpdate.ClassId);
            PopulateDepartmentsDropDownList(courseToUpdate.StudentsId);
            return View(courseToUpdate);
            /*
            if (id != studentClass.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentClass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentClassExists(studentClass.Id))
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
            ViewData["ClassId"] = new SelectList(_context.Classes, "Id", "Id", studentClass.ClassId);
            ViewData["StudentsId"] = new SelectList(_context.Students, "Id", "Id", studentClass.StudentsId);
            return View(studentClass);*/
        }
        private void PopulateDepartmentsDropDownList(object selectedStudents = null, object selectedClass = null, object selectedClasses = null)
        {
            var studentsQuery = from a in _context.Students

                                orderby a.Name select a ;

            ViewBag.StudentsId = new SelectList(studentsQuery.AsNoTracking(),
                                                "StudentsId",
                                                "Name",
                                                
                                                selectedStudents);
            var classesQuery = from a in _context.Classes

                                orderby a.Time
                                select a;

            ViewBag.Classes = new SelectList(classesQuery.AsNoTracking(),
                                                "classesId",
                                                "Time",

                                                selectedClasses);
        }
        // GET: StudentClasses1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentClass = await _context.StudentClasses
                .Include(s => s.Class)
                .Include(s => s.Students)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentClass == null)
            {
                return NotFound();
            }

            return View(studentClass);
        }

        // POST: StudentClasses1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studentClass = await _context.StudentClasses.FindAsync(id);
            _context.StudentClasses.Remove(studentClass);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentClassExists(int id)
        {
            return _context.StudentClasses.Any(e => e.Id == id);
        }
    }
}
