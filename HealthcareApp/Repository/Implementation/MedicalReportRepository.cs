using HealthcareApp.Models.DataModels;
using HealthcareApp.Repository.Interface;

namespace HealthcareApp.Repository.Implementation
{
    public class MedicalReportRepository : CrudRepository<MedicalReport>, IMedicalReportRepository
    {
        public MedicalReportRepository(HealthcareDbContext context) : base(context)
        {
        }
    }
}
