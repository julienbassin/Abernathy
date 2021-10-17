using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Abernathy.Demographics.Service.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StreetName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    HouseNumber = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    ZIPCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Town = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    State = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gender",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gender", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhoneNumber",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneNumber", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GenderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patient_Gender",
                        column: x => x.GenderId,
                        principalTable: "Gender",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AddressPatient",
                columns: table => new
                {
                    AddressesId = table.Column<int>(type: "int", nullable: false),
                    PatientsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressPatient", x => new { x.AddressesId, x.PatientsId });
                    table.ForeignKey(
                        name: "FK_AddressPatient_Address_AddressesId",
                        column: x => x.AddressesId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AddressPatient_Patient_PatientsId",
                        column: x => x.PatientsId,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatientPhoneNumber",
                columns: table => new
                {
                    PatientsId = table.Column<int>(type: "int", nullable: false),
                    PhoneNumbersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientPhoneNumber", x => new { x.PatientsId, x.PhoneNumbersId });
                    table.ForeignKey(
                        name: "FK_PatientPhoneNumber_Patient_PatientsId",
                        column: x => x.PatientsId,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientPhoneNumber_PhoneNumber_PhoneNumbersId",
                        column: x => x.PhoneNumbersId,
                        principalTable: "PhoneNumber",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Gender",
                columns: new[] { "Id", "Type" },
                values: new object[] { 1, "Male" });

            migrationBuilder.InsertData(
                table: "Gender",
                columns: new[] { "Id", "Type" },
                values: new object[] { 2, "Female" });

            migrationBuilder.InsertData(
                table: "Patient",
                columns: new[] { "Id", "Age", "DateOfBirth", "FirstName", "GenderId", "LastName" },
                values: new object[,]
                {
                    { 1, 53, new DateTime(1968, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lucas", 1, "Ferguson" },
                    { 3, 69, new DateTime(1952, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Edward", 1, "Arnold" },
                    { 4, 75, new DateTime(1946, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Anthony", 1, "Sharp" },
                    { 8, 75, new DateTime(1945, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Max", 1, "Buckland" },
                    { 10, 61, new DateTime(1959, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bailey", 1, "Piers" },
                    { 2, 69, new DateTime(1952, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pippa", 2, "Rees" },
                    { 5, 61, new DateTime(1958, 6, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wendy", 2, "Ince" },
                    { 6, 72, new DateTime(1949, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tracey", 2, "Ross" },
                    { 7, 55, new DateTime(1966, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Claire", 2, "Wilson" },
                    { 9, 57, new DateTime(1964, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Clark", 2, "Natalie" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AddressPatient_PatientsId",
                table: "AddressPatient",
                column: "PatientsId");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_GenderId",
                table: "Patient",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientPhoneNumber_PhoneNumbersId",
                table: "PatientPhoneNumber",
                column: "PhoneNumbersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddressPatient");

            migrationBuilder.DropTable(
                name: "PatientPhoneNumber");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Patient");

            migrationBuilder.DropTable(
                name: "PhoneNumber");

            migrationBuilder.DropTable(
                name: "Gender");
        }
    }
}
