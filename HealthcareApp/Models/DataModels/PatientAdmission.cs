using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthcareApp.Models.DataModels
{
    public class PatientAdmission
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public DateTime AdmissionDateTime { get; set; }

        public Guid PatientId { get; set; }
        
        public Guid DoctorId { get; set; }

        public bool IsUrgent { get; set; }

        [ForeignKey(nameof(PatientId))]
        public Patient Patient { get; init; } = null!;

        [ForeignKey(nameof(DoctorId))]
        public Doctor Doctor { get; init; } = null!;

    }
}
