using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HealthcareApp.Models.DataModels;
using HealthcareApp.Repository;
using HealthcareApp.Repository.Interface;

namespace HealthcareApp.Controllers
{
    public class MedicalReportsController : Controller
    {
        private readonly HealthcareDbContext _context;
        private readonly IMedicalReportRepository _medicalReportRepository;

        public MedicalReportsController(HealthcareDbContext context, IMedicalReportRepository medicalReportRepository)
        {
            _context = context;
            _medicalReportRepository = medicalReportRepository;
        }


        // GET: MedicalReports
        public async Task<IActionResult> Index()
        {
            return View(await _medicalReportRepository.GetAllDetailedMedicalReports());
        }

        // GET: MedicalReports/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var medicalReport = await _medicalReportRepository.GetDetailedMedicalReport(id.Value);
            if (medicalReport is null)
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,DateCreated,PatientAdmissionId")] MedicalReport medicalReport)
        {
            if (ModelState.IsValid)
            {
                await _medicalReportRepository.Add(medicalReport);
                return RedirectToAction(nameof(Index));
            }
            ViewData["PatientAdmissionId"] = new SelectList(_context.PatientAdmissions, "Id", "Id", medicalReport.PatientAdmissionId);
            return View(medicalReport);
        }

        // GET: MedicalReports/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var medicalReport = await _medicalReportRepository.GetDetailedMedicalReport(id.Value);
            if (medicalReport is null)
            {
                return NotFound();
            }
            ViewData["PatientAdmissionId"] = new SelectList(_context.PatientAdmissions, "Id", "Id", medicalReport.PatientAdmissionId);
            return View(medicalReport);
        }

        // POST: MedicalReports/Edit/5
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
                   await _medicalReportRepository.Update(medicalReport);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!(await _medicalReportRepository.Exists(medicalReport.Id)))
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
            if (id is null)
            {
                return NotFound();
            }

            var medicalReport = await _medicalReportRepository.GetDetailedMedicalReport(id.Value);
            if (medicalReport is null)
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
            var medicalReport = await _medicalReportRepository.GetById(id);
            if (medicalReport is not null)
            {
                await _medicalReportRepository.Delete(id);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
