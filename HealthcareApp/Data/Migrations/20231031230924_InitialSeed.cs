using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HealthcareApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "Code", "Firstname", "Lastname", "Title" },
                values: new object[,]
                {
                    { new Guid("6a2e6559-3442-416c-afda-e35232824ce4"), "DC1", "James", "Smith", "Specialist" },
                    { new Guid("7a2e6559-3442-416c-afda-e35232824ce4"), "DC2", "Kevin", "May", "Specialist" }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "Address", "DateOfBirth", "Firstname", "Gender", "Lastname", "TelephoneNumber" },
                values: new object[,]
                {
                    { new Guid("8a2e6559-3442-416c-afda-e35232824ce4"), "Address 1", new DateTime(2023, 11, 1, 0, 9, 24, 653, DateTimeKind.Local).AddTicks(6917), "Michels", "Male", "Jones", "00023323" },
                    { new Guid("9a2e6559-3442-416c-afda-e35232824ce4"), null, new DateTime(2023, 11, 1, 0, 9, 24, 653, DateTimeKind.Local).AddTicks(6964), "James", "Male", "Lynn", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("6a2e6559-3442-416c-afda-e35232824ce4"));

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: new Guid("7a2e6559-3442-416c-afda-e35232824ce4"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("8a2e6559-3442-416c-afda-e35232824ce4"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("9a2e6559-3442-416c-afda-e35232824ce4"));
        }
    }
}
