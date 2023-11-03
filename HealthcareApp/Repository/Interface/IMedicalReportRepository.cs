using HealthcareApp.Models.DataModels;

namespace HealthcareApp.Repository.Interface
{
    public interface IMedicalReportRepository : ICrudRepository<MedicalReport>
    {
        public Task<List<MedicalReport>> GetAllDetailedMedicalReports();
        public Task<MedicalReport?> GetDetailedMedicalReport(Guid id);

    }
}
