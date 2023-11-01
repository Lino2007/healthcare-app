using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HealthcareApp.Models.DataModels;
using HealthcareApp.Repository;

namespace HealthcareApp.Controllers
{
    public class MedicalReportsController : Controller
    {
        private readonly HealthcareDbContext _context;

        public MedicalReportsController(HealthcareDbContext context)
        {
            _context = context;
        }

        // GET: MedicalReports
        public async Task<IActionResult> Index()
        {
            var healthcareDbContext = _context.MedicalReports.Include(m => m.PatientAdmission);
            return View(await healthcareDbContext.ToListAsync());
        }

        // GET: MedicalReports/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.MedicalReports == null)
            {
                return NotFound();
            }

            var medicalReport = await _context.MedicalReports
                .Include(m => m.PatientAdmission)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (medicalReport == null)
            {
                return NotFound();
            }

            return View(medicalReport);
        }

        // GET: MedicalReports/Create
        public IActionResult Create()
        {
            ViewData["PatientAdmissionId"] = new SelectList(_context.PatientAdmissions, "Id", "Id");
            return View();
        }

        // POST: MedicalReports/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,DateCreated,PatientAdmissionId")] MedicalReport medicalReport)
        {
            if (ModelState.IsValid)
            {
                medicalReport.Id = Guid.NewGuid();
                _context.Add(medicalReport);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PatientAdmissionId"] = new SelectList(_context.PatientAdmissions, "Id", "Id", medicalReport.PatientAdmissionId);
            return View(medicalReport);
        }

        // GET: MedicalReports/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.MedicalReports == null)
            {
                return NotFound();
            }

            var medicalReport = await _context.MedicalReports.FindAsync(id);
            if (medicalReport == null)
            {
                return NotFound();
            }
            ViewData["PatientAdmissionId"] = new SelectList(_context.PatientAdmissions, "Id", "Id", medicalReport.PatientAdmissionId);
            return View(medicalReport);
        }

        // POST: MedicalReports/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Description,DateCreated,PatientAdmissionId")] MedicalReport medicalReport)
        {
            if (id != medicalReport.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medicalReport);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicalReportExists(medicalReport.Id))
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
            ViewData["PatientAdmissionId"] = new SelectList(_context.PatientAdmissions, "Id", "Id", medicalReport.PatientAdmissionId);
            return View(medicalReport);
        }

        // GET: MedicalReports/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.MedicalReports == null)
            {
                return NotFound();
            }

            var medicalReport = await _context.MedicalReports
                .Include(m => m.PatientAdmission)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (medicalReport == null)
            {
                return NotFound();
            }

            return View(medicalReport);
        }

        // POST: MedicalReports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.MedicalReports == null)
            {
                return Problem("Entity set 'HealthcareDbContext.MedicalReports'  is null.");
            }
            var medicalReport = await _context.MedicalReports.FindAsync(id);
            if (medicalReport != null)
            {
                _context.MedicalReports.Remove(medicalReport);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedicalReportExists(Guid id)
        {
          return (_context.MedicalReports?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
