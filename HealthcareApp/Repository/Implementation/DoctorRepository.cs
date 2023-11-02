using HealthcareApp.Models.DataModels;
using HealthcareApp.Repository.Implementation;
using HealthcareApp.Repository.Interface;

namespace HealthcareApp.Repository.Implementation
{
    public class DoctorRepository : CrudRepository<Doctor>, IDoctorRepository
    {
        public DoctorRepository(HealthcareDbContext context) : base(context)
        {
        }
    }
}
