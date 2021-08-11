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
                    HouseNumber = table.Column<int>(type: "int", maxLength: 6, nullable: false),
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
                name: "PatientAddress",
                columns: table => new
                {
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientAddress", x => new { x.PatientId, x.AddressId });
                    table.ForeignKey(
                        name: "FK_PatientAddress_Address",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientAddress_Patient",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatientPhoneNumbers",
                columns: table => new
                {
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    PhoneNumberId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientPhoneNumbers", x => new { x.PatientId, x.PhoneNumberId });
                    table.ForeignKey(
                        name: "FK_PatientPhoneNumber_Patient",
                        column: x => x.PhoneNumberId,
                        principalTable: "PhoneNumber",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientPhoneNumber_PhoneNumber",
                        column: x => x.PatientId,
                        principalTable: "Patient",
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
                    { 1, 0, new DateTime(1960, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "James", 1, "Smith" },
                    { 3, 0, new DateTime(2010, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Masaaki", 1, "Abe" },
                    { 5, 0, new DateTime(1960, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nurma", 1, "Haitam" },
                    { 7, 0, new DateTime(2010, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brian", 1, "Aleesami" },
                    { 10, 0, new DateTime(1960, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "King", 1, "Andrew" },
                    { 11, 0, new DateTime(2010, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Locke", 1, "Brian" },
                    { 2, 0, new DateTime(1960, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jiyeon", 2, "Lee" },
                    { 4, 0, new DateTime(2010, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Anna", 2, "Svensson" },
                    { 6, 0, new DateTime(1960, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lucy", 2, "Johnson" },
                    { 8, 0, new DateTime(2010, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Elizabeth", 2, "van Lingen" },
                    { 9, 0, new DateTime(1960, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Okparaebo", 2, "Vivienne" },
                    { 12, 0, new DateTime(2010, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wang", 2, "Su Lin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Patient_GenderId",
                table: "Patient",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientAddress_AddressId",
                table: "PatientAddress",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientPhoneNumbers_PhoneNumberId",
                table: "PatientPhoneNumbers",
                column: "PhoneNumberId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PatientAddress");

            migrationBuilder.DropTable(
                name: "PatientPhoneNumbers");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "PhoneNumber");

            migrationBuilder.DropTable(
                name: "Patient");

            migrationBuilder.DropTable(
                name: "Gender");
        }
    }
}
