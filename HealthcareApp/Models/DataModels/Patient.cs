using HealthcareApp.Models.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthcareApp.Models.DataModels
{
    public class Patient
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 2)]
        public string Firstname { get; set; } = null!;

        [Required]
        [StringLength(30, MinimumLength = 2)]
        public string Lastname { get; set; } = null!;

        public DateTime DateOfBirth { get; set; }

        [Column(TypeName = "nvarchar(10)")]
        public Gender Gender { get; set; }

        [StringLength(50, MinimumLength = 2)]
        public string? Address { get; set; }

        [StringLength(25, MinimumLength = 6)]
        public string? TelephoneNumber { get; set; }

        public ICollection<PatientAdmission> PatientAdmissions { get; } = new List<PatientAdmission>();

    }
}
