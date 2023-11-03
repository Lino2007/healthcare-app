using HealthcareApp.Models.DataModels;

namespace HealthcareApp.Repository.Interface
{
    public interface IPatientAdmissionRepository : ICrudRepository<PatientAdmission>
    {
        Task<List<PatientAdmission>> GetAllDetailedPatientAdmissions();
        Task<PatientAdmission?> GetDetailedPatientAdmission(Guid id);
    }
}
