using HealthcareApp.Models.DataModels;
using HealthcareApp.Models.Shared;
using HealthcareApp.Repository;
using HealthcareApp.Repository.Interface;
using HealthcareApp.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace HealthcareApp.Controllers
{
    public class PatientAdmissionsController : Controller
    {
        private readonly IPatientAdmissionRepository _patientAdmissionRepository;
        private readonly IDoctorRepository _doctorRepository;
        private readonly IPatientRepository _patientRepository;

        public PatientAdmissionsController(IPatientAdmissionRepository patientAdmissionRepository, IDoctorRepository doctorRepository, IPatientRepository patientRepository)
        {
            _patientAdmissionRepository = patientAdmissionRepository;
            _doctorRepository = doctorRepository;
            _patientRepository = patientRepository;
        }

        // GET: PatientAdmissions
        public async Task<IActionResult> Index()
        {
            return View(await _patientAdmissionRepository.GetAllDetailedPatientAdmissions());
        }

        // GET: PatientAdmissions/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var patientAdmission = await _patientAdmissionRepository.GetDetailedPatientAdmission(id.Value);
            if (patientAdmission is null)
            {
                return NotFound();
            }

            return View(patientAdmission);
        }

        // GET: PatientAdmissions/Create
        public async Task<IActionResult> Create()
        {
            await LoadSelectLists();
            return View();
        }

        // POST: PatientAdmissions/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AdmissionDateTime,PatientId,DoctorId,IsUrgent")] PatientAdmission patientAdmission)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _patientAdmissionRepository.Add(patientAdmission);
                }
                catch (DbObjectNotFound e)
                {
                    NotFound($"Patient Admission create operation failed: {e.Message}");
                }
                return RedirectToAction(nameof(Index));
            }
            await LoadSelectLists(patientAdmission.DoctorId, patientAdmission.PatientId);
            return View(patientAdmission);
        }

        // GET: PatientAdmissions/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var patientAdmission = await _patientAdmissionRepository.GetById(id.Value);
            if (patientAdmission is null)
            {
                return NotFound();
            }
            await LoadSelectLists(patientAdmission.DoctorId, patientAdmission.PatientId);
            return View(patientAdmission);
        }

        // POST: PatientAdmissions/Edit/5
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
                    await _patientAdmissionRepository.Update(patientAdmission);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!(await _patientAdmissionRepository.Exists(patientAdmission.Id)))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                catch(DbObjectNotFound e)
                {
                    return NotFound($"Patient Admission update operation failed: {e.Message}");
                }
                return RedirectToAction(nameof(Index));
            }
            await LoadSelectLists(patientAdmission.DoctorId, patientAdmission.PatientId);
            return View(patientAdmission);
        }

        public async Task<IActionResult> CancelAdmission(Guid id)
        {
            var patientAdmission = await _patientAdmissionRepository.GetById(id);
            if (patientAdmission is null)
            {
                return NotFound($"Patient Admission (id: {id}) not found, cancellation failed.");
            }

            patientAdmission.IsCancelled = true;
            try
            {
                await _patientAdmissionRepository.Update(patientAdmission);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!(await _patientAdmissionRepository.Exists(patientAdmission.Id)))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            catch (DbObjectNotFound e)
            {
                return NotFound($"Patient Admission update operation failed: {e.Message}");
            }

            return RedirectToAction(nameof(Index));
        }
 
        // GET: PatientAdmissions/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var patientAdmission = await _patientAdmissionRepository.GetDetailedPatientAdmission(id.Value);
            if (patientAdmission is null)
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
            var patientAdmission = await _patientAdmissionRepository.GetById(id);
            if (patientAdmission != null)
            {
                await _patientAdmissionRepository.Delete(id);
            }
           
            return RedirectToAction(nameof(Index));
        }

        private async Task<List<SelectListItem>> GetSpecialistSelectList(Guid? selectedSpecialist)
        {
            var specialists = await _doctorRepository.FindBy(d => d.Title == DoctorTitle.Specialist && !d.IsDeleted);
            var selectList = new List<SelectListItem>();

            foreach(var specialist in specialists)
            {
                selectList.Add(new SelectListItem(text: specialist.FullName, value: specialist.Id.ToString(),
                                                  selected: IsSelected(specialist.Id, selectedSpecialist)));  
            }
            return selectList;
        }

        private async Task<List<SelectListItem>> GetPatientSelectList(Guid? selectedPatient)
        {
            var patients = await _patientRepository.FindBy(p => !p.IsDeleted);
            var selectList = new List<SelectListItem>();

            foreach (var patient in patients)
            {
                selectList.Add(new SelectListItem(text: patient.FullName, value: patient.Id.ToString(),
                                                  selected: IsSelected(patient.Id, selectedPatient)));
            }
            return selectList;
        }

        private static bool IsSelected(Guid currentGuid, Guid? selected)
        {
            return selected is not null && currentGuid.Equals(selected);
        }

        private async Task LoadSelectLists(Guid? selectedSpecialist = null, Guid? selectedPatient = null)
        {
            ViewBag.SpecialistId = await GetSpecialistSelectList(selectedSpecialist);
            ViewBag.PatientId = await GetPatientSelectList(selectedPatient);
        }
    }
}
