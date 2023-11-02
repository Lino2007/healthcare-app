using HealthcareApp.Models.DataModels;
using HealthcareApp.Repository.Interface;

namespace HealthcareApp.Repository.Implementation
{
    public class PatientAdmissionRepository : CrudRepository<PatientAdmission>, IPatientAdmissionRepository
    {
        public PatientAdmissionRepository(HealthcareDbContext context) : base(context)
        {
        }
    }
}
