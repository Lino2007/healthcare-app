﻿// <auto-generated />
using System;
using HealthcareApp.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HealthcareApp.Migrations
{
    [DbContext(typeof(HealthcareDbContext))]
    [Migration("20231101181246_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HealthcareApp.Models.DataModels.Doctor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(24)");

                    b.HasKey("Id");

                    b.ToTable("Doctors");

                    b.HasData(
                        new
                        {
                            Id = new Guid("6a2e6559-3442-416c-afda-e35232824ce4"),
                            Code = "DC1",
                            Firstname = "James",
                            Lastname = "Smith",
                            Title = "Specialist"
                        },
                        new
                        {
                            Id = new Guid("7b2e6559-3442-416c-afda-e35232824ce4"),
                            Code = "DC2",
                            Firstname = "Kevin",
                            Lastname = "May",
                            Title = "Specialist"
                        },
                        new
                        {
                            Id = new Guid("8c2e6559-3442-416c-afda-e35232824ce4"),
                            Code = "RES1",
                            Firstname = "Jane",
                            Lastname = "Johnson",
                            Title = "Resident"
                        },
                        new
                        {
                            Id = new Guid("9d2e6559-3442-416c-afda-e35232824ce4"),
                            Code = "RES2",
                            Firstname = "Michael",
                            Lastname = "Abrams",
                            Title = "Resident"
                        },
                        new
                        {
                            Id = new Guid("1e2e6559-3442-416c-afda-e35232824ce4"),
                            Code = "NS1",
                            Firstname = "Ken",
                            Lastname = "Richards",
                            Title = "Nurse"
                        },
                        new
                        {
                            Id = new Guid("2f2e6559-3442-416c-afda-e35232824ce4"),
                            Code = "NS2",
                            Firstname = "Melina",
                            Lastname = "Diericks",
                            Title = "Nurse"
                        });
                });

            modelBuilder.Entity("HealthcareApp.Models.DataModels.MedicalReport", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.Property<Guid>("PatientAdmissionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PatientAdmissionId");

                    b.ToTable("MedicalReports");

                    b.HasData(
                        new
                        {
                            Id = new Guid("93024ef8-c1e7-4fea-b4e3-abf161b88196"),
                            DateCreated = new DateTime(2023, 11, 1, 19, 12, 46, 643, DateTimeKind.Local).AddTicks(4986),
                            Description = "Description 1",
                            PatientAdmissionId = new Guid("81aea768-8434-4468-9cd7-8034a105f31a")
                        },
                        new
                        {
                            Id = new Guid("33024ef8-c1e7-4fea-b4e3-abf161b88196"),
                            DateCreated = new DateTime(2023, 11, 1, 19, 12, 46, 643, DateTimeKind.Local).AddTicks(4992),
                            Description = "Description 2",
                            PatientAdmissionId = new Guid("11aea768-8434-4468-9cd7-8034a105f31a")
                        },
                        new
                        {
                            Id = new Guid("53024ef8-c1e7-4fea-b4e3-abf161b88196"),
                            DateCreated = new DateTime(2023, 11, 1, 19, 12, 46, 643, DateTimeKind.Local).AddTicks(4996),
                            Description = "Description 3",
                            PatientAdmissionId = new Guid("21aea768-8434-4468-9cd7-8034a105f31a")
                        },
                        new
                        {
                            Id = new Guid("13024ef8-c1e7-4fea-b4e3-abf161b88196"),
                            DateCreated = new DateTime(2023, 11, 1, 19, 12, 46, 643, DateTimeKind.Local).AddTicks(5000),
                            Description = "Description 4",
                            PatientAdmissionId = new Guid("31aea768-8434-4468-9cd7-8034a105f31a")
                        },
                        new
                        {
                            Id = new Guid("23024ef8-c1e7-4fea-b4e3-abf161b88196"),
                            DateCreated = new DateTime(2023, 11, 1, 19, 12, 46, 643, DateTimeKind.Local).AddTicks(5004),
                            Description = "Description 5",
                            PatientAdmissionId = new Guid("41aea768-8434-4468-9cd7-8034a105f31a")
                        },
                        new
                        {
                            Id = new Guid("63024ef8-c1e7-4fea-b4e3-abf161b88196"),
                            DateCreated = new DateTime(2023, 11, 1, 19, 12, 46, 643, DateTimeKind.Local).AddTicks(5008),
                            Description = "Description 6",
                            PatientAdmissionId = new Guid("51aea768-8434-4468-9cd7-8034a105f31a")
                        });
                });

            modelBuilder.Entity("HealthcareApp.Models.DataModels.Patient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("TelephoneNumber")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.ToTable("Patients");

                    b.HasData(
                        new
                        {
                            Id = new Guid("1200a45e-8914-47bf-9035-e85aaad2b261"),
                            Address = "Address 1",
                            DateOfBirth = new DateTime(2000, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Firstname = "Michels",
                            Gender = "Male",
                            Lastname = "Jones",
                            TelephoneNumber = "00023323"
                        },
                        new
                        {
                            Id = new Guid("b226f2a3-8f68-4c85-b162-4b2204f8665d"),
                            DateOfBirth = new DateTime(1996, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Firstname = "Jenna",
                            Gender = "Female",
                            Lastname = "Lynn"
                        },
                        new
                        {
                            Id = new Guid("78eecc5e-5e7c-46d7-b472-3a1bddf289ba"),
                            Address = "Address 2",
                            DateOfBirth = new DateTime(1979, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Firstname = "Wolf",
                            Gender = "Male",
                            Lastname = "Warren",
                            TelephoneNumber = "555555"
                        },
                        new
                        {
                            Id = new Guid("73776586-b4db-4769-9228-f103e8499d4f"),
                            Address = "Address 3",
                            DateOfBirth = new DateTime(1975, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Firstname = "Nick",
                            Gender = "Male",
                            Lastname = "Oakenfold",
                            TelephoneNumber = "6666666"
                        },
                        new
                        {
                            Id = new Guid("2b99eca2-1421-4789-a3e1-00da3d953abe"),
                            Address = "Address 4",
                            DateOfBirth = new DateTime(1976, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Firstname = "Hannah",
                            Gender = "Female",
                            Lastname = "Brown",
                            TelephoneNumber = "7777777"
                        },
                        new
                        {
                            Id = new Guid("211a94b3-78cd-4a6b-babd-eb8c3a18cfea"),
                            Address = "Address 5",
                            DateOfBirth = new DateTime(1996, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Firstname = "Brock",
                            Gender = "Male",
                            Lastname = "Wallace",
                            TelephoneNumber = "1111122222"
                        });
                });

            modelBuilder.Entity("HealthcareApp.Models.DataModels.PatientAdmission", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("AdmissionDateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("DoctorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsUrgent")
                        .HasColumnType("bit");

                    b.Property<Guid>("PatientId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.ToTable("PatientAdmissions");

                    b.HasData(
                        new
                        {
                            Id = new Guid("81aea768-8434-4468-9cd7-8034a105f31a"),
                            AdmissionDateTime = new DateTime(2020, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DoctorId = new Guid("7b2e6559-3442-416c-afda-e35232824ce4"),
                            IsUrgent = false,
                            PatientId = new Guid("1200a45e-8914-47bf-9035-e85aaad2b261")
                        },
                        new
                        {
                            Id = new Guid("11aea768-8434-4468-9cd7-8034a105f31a"),
                            AdmissionDateTime = new DateTime(2021, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DoctorId = new Guid("7b2e6559-3442-416c-afda-e35232824ce4"),
                            IsUrgent = false,
                            PatientId = new Guid("b226f2a3-8f68-4c85-b162-4b2204f8665d")
                        },
                        new
                        {
                            Id = new Guid("21aea768-8434-4468-9cd7-8034a105f31a"),
                            AdmissionDateTime = new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DoctorId = new Guid("7b2e6559-3442-416c-afda-e35232824ce4"),
                            IsUrgent = false,
                            PatientId = new Guid("78eecc5e-5e7c-46d7-b472-3a1bddf289ba")
                        },
                        new
                        {
                            Id = new Guid("31aea768-8434-4468-9cd7-8034a105f31a"),
                            AdmissionDateTime = new DateTime(2021, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DoctorId = new Guid("6a2e6559-3442-416c-afda-e35232824ce4"),
                            IsUrgent = false,
                            PatientId = new Guid("73776586-b4db-4769-9228-f103e8499d4f")
                        },
                        new
                        {
                            Id = new Guid("41aea768-8434-4468-9cd7-8034a105f31a"),
                            AdmissionDateTime = new DateTime(2021, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DoctorId = new Guid("6a2e6559-3442-416c-afda-e35232824ce4"),
                            IsUrgent = false,
                            PatientId = new Guid("2b99eca2-1421-4789-a3e1-00da3d953abe")
                        },
                        new
                        {
                            Id = new Guid("51aea768-8434-4468-9cd7-8034a105f31a"),
                            AdmissionDateTime = new DateTime(2022, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DoctorId = new Guid("6a2e6559-3442-416c-afda-e35232824ce4"),
                            IsUrgent = false,
                            PatientId = new Guid("211a94b3-78cd-4a6b-babd-eb8c3a18cfea")
                        });
                });

            modelBuilder.Entity("HealthcareApp.Models.DataModels.MedicalReport", b =>
                {
                    b.HasOne("HealthcareApp.Models.DataModels.PatientAdmission", "PatientAdmission")
                        .WithMany()
                        .HasForeignKey("PatientAdmissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PatientAdmission");
                });

            modelBuilder.Entity("HealthcareApp.Models.DataModels.PatientAdmission", b =>
                {
                    b.HasOne("HealthcareApp.Models.DataModels.Doctor", "Doctor")
                        .WithMany("PatientAdmissions")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HealthcareApp.Models.DataModels.Patient", "Patient")
                        .WithMany("PatientAdmissions")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("HealthcareApp.Models.DataModels.Doctor", b =>
                {
                    b.Navigation("PatientAdmissions");
                });

            modelBuilder.Entity("HealthcareApp.Models.DataModels.Patient", b =>
                {
                    b.Navigation("PatientAdmissions");
                });
#pragma warning restore 612, 618
        }
    }
}
