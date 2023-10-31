using HealthcareApp.Models.DataModels;
using HealthcareApp.Models.Shared;
using Microsoft.EntityFrameworkCore;

namespace HealthcareApp.Repository
{
    public class HealthcareDbContext : DbContext
    {
        public DbSet<Doctor> Doctors { get; set; } = null!;
        public DbSet<Patient> Patients { get; set; } = null!;
        public DbSet<MedicalReport> MedicalReports { get; set; } = null!;
        public DbSet<PatientAdmission> PatientAdmissions { get; set; } = null!;

        public HealthcareDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Doctor>().HasData(
                new Doctor { Id = new Guid("6a2e6559-3442-416c-afda-e35232824ce4"), Firstname = "James", 
                             Lastname = "Smith", Title = Models.Shared.DoctorTitle.Specialist, Code = "DC1" },
                new Doctor { Id = new Guid("7a2e6559-3442-416c-afda-e35232824ce4"), Firstname = "Kevin", 
                             Lastname = "May", Title = Models.Shared.DoctorTitle.Specialist, Code = "DC2" }
            );

            modelBuilder.Entity<Patient>().HasData(
                new Patient { Id = new Guid("8a2e6559-3442-416c-afda-e35232824ce4"), Firstname = "Michels", 
                              Lastname = "Jones", DateOfBirth = DateTime.Now, Gender = Gender.Male, Address = "Address 1", TelephoneNumber = "00023323" },
                new Patient { Id = new Guid("9a2e6559-3442-416c-afda-e35232824ce4"), Firstname = "James", 
                              Lastname = "Lynn", DateOfBirth = DateTime.Now, Gender = Gender.Male }
            );
        }
    }
}
