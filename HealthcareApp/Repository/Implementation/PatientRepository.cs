using HealthcareApp.Models.DataModels;
using HealthcareApp.Repository.Interface;

namespace HealthcareApp.Repository.Implementation
{
    public class PatientRepository : CrudRepository<Patient>, IPatientRepository
    {
        public PatientRepository(HealthcareDbContext context) : base(context)
        {
        }
    }
}
