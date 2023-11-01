﻿using HealthcareApp.Models.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthcareApp.Models.DataModels
{
    public class Doctor
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

        [Column(TypeName = "nvarchar(24)")]
        public DoctorTitle Title { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 2)]
        public string Code { get; set; } = null!;

        public ICollection<PatientAdmission> PatientAdmissions { get; } = new List<PatientAdmission>();
    }
}