using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HealthcareApp.Models.DataModels;
using HealthcareApp.Repository;

namespace HealthcareApp.Controllers
{
    public class PatientAdmissionsController : Controller
    {
        private readonly HealthcareDbContext _context;

        public PatientAdmissionsController(HealthcareDbContext context)
        {
            _context = context;
        }

        // GET: PatientAdmissions
        public async Task<IActionResult> Index()
        {
            var healthcareDbContext = _context.PatientAdmissions.Include(p => p.Doctor).Include(p => p.Patient);
            return View(await healthcareDbContext.ToListAsync());
        }

        // GET: PatientAdmissions/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.PatientAdmissions == null)
            {
                return NotFound();
            }

            var patientAdmission = await _context.PatientAdmissions
                .Include(p => p.Doctor)
                .Include(p => p.Patient)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (patientAdmission == null)
            {
                return NotFound();
            }

            return View(patientAdmission);
        }

        // GET: PatientAdmissions/Create
        public IActionResult Create()
        {
            ViewData["DoctorId"] = new SelectList(_context.Doctors, "Id", "Code");
            ViewData["PatientId"] = new SelectList(_context.Patients, "Id", "Firstname");
            return View();
        }

        // POST: PatientAdmissions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AdmissionDateTime,PatientId,DoctorId,IsUrgent")] PatientAdmission patientAdmission)
        {
            if (ModelState.IsValid)
            {
                patientAdmission.Id = Guid.NewGuid();
                _context.Add(patientAdmission);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DoctorId"] = new SelectList(_context.Doctors, "Id", "Code", patientAdmission.DoctorId);
            ViewData["PatientId"] = new SelectList(_context.Patients, "Id", "Firstname", patientAdmission.PatientId);
            return View(patientAdmission);
        }

        // GET: PatientAdmissions/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.PatientAdmissions == null)
            {
                return NotFound();
            }

            var patientAdmission = await _context.PatientAdmissions.FindAsync(id);
            if (patientAdmission == null)
            {
                return NotFound();
            }
            ViewData["DoctorId"] = new SelectList(_context.Doctors, "Id", "Code", patientAdmission.DoctorId);
            ViewData["PatientId"] = new SelectList(_context.Patients, "Id", "Firstname", patientAdmission.PatientId);
            return View(patientAdmission);
        }

        // POST: PatientAdmissions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,AdmissionDateTime,PatientId,DoctorId,IsUrgent")] PatientAdmission patientAdmission)
        {
            if (id != patientAdmission.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(patientAdmission);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatientAdmissionExists(patientAdmission.Id))
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
            ViewData["DoctorId"] = new SelectList(_context.Doctors, "Id", "Code", patientAdmission.DoctorId);
            ViewData["PatientId"] = new SelectList(_context.Patients, "Id", "Firstname", patientAdmission.PatientId);
            return View(patientAdmission);
        }

        // GET: PatientAdmissions/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.PatientAdmissions == null)
            {
                return NotFound();
            }

            var patientAdmission = await _context.PatientAdmissions
                .Include(p => p.Doctor)
                .Include(p => p.Patient)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (patientAdmission == null)
            {
                return NotFound();
            }

            return View(patientAdmission);
        }

        // POST: PatientAdmissions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.PatientAdmissions == null)
            {
                return Problem("Entity set 'HealthcareDbContext.PatientAdmissions'  is null.");
            }
            var patientAdmission = await _context.PatientAdmissions.FindAsync(id);
            if (patientAdmission != null)
            {
                _context.PatientAdmissions.Remove(patientAdmission);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PatientAdmissionExists(Guid id)
        {
          return (_context.PatientAdmissions?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
