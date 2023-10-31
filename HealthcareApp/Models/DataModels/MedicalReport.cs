using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthcareApp.Models.DataModels
{
    public class MedicalReport
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [StringLength(1024)]
        public string Description { get; set; } = null!;

        public DateTime DateCreated { get; set; }

        public Guid PatientAdmissionId { get; set; }

        [ForeignKey(nameof(PatientAdmissionId))]
        public PatientAdmission PatientAdmission { get; init; } = null!;

    }
}
