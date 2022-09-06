using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace iHakeem.Database.Migrations
{
    public partial class doctorworkexperienceandrelationchanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PatientGaurdian_PatientId",
                table: "PatientGaurdian");

            migrationBuilder.DropIndex(
                name: "IX_DoctorSkillsAndTraining_DoctorId",
                table: "DoctorSkillsAndTraining");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "DoctorSkillsAndTraining");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "DoctorSkillsAndTraining");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "DoctorSkillsAndTraining");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "DoctorSkillsAndTraining");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "DoctorSkillsAndTraining");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "DoctorEducation");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "DoctorEducation");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "DoctorEducation");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "DoctorEducation");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "DoctorEducation");

            migrationBuilder.CreateTable(
                name: "DoctorService",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorId = table.Column<long>(type: "bigint", nullable: false),
                    ServiceId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorService", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoctorService_LookupData_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "LookupData",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DoctorWorkExperience",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorId = table.Column<long>(type: "bigint", nullable: false),
                    JobTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrgnizationName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    SuperVisor = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    SuperVisorContact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: false),
                    Contact = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Fax = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ISCurrentlyWorking = table.Column<bool>(type: "bit", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: false),
                    State = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: false),
                    City = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorWorkExperience", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoctorWorkExperience_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PatientGaurdian_PatientId",
                table: "PatientGaurdian",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorSkillsAndTraining_DoctorId",
                table: "DoctorSkillsAndTraining",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorService_ServiceId",
                table: "DoctorService",
                column: "ServiceId",
                unique: true,
                filter: "[ServiceId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorWorkExperience_DoctorId",
                table: "DoctorWorkExperience",
                column: "DoctorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoctorService");

            migrationBuilder.DropTable(
                name: "DoctorWorkExperience");

            migrationBuilder.DropIndex(
                name: "IX_PatientGaurdian_PatientId",
                table: "PatientGaurdian");

            migrationBuilder.DropIndex(
                name: "IX_DoctorSkillsAndTraining_DoctorId",
                table: "DoctorSkillsAndTraining");

            migrationBuilder.AddColumn<long>(
                name: "CreatedBy",
                table: "DoctorSkillsAndTraining",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "DoctorSkillsAndTraining",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "DoctorSkillsAndTraining",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "UpdatedBy",
                table: "DoctorSkillsAndTraining",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "DoctorSkillsAndTraining",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CreatedBy",
                table: "DoctorEducation",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "DoctorEducation",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "DoctorEducation",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "UpdatedBy",
                table: "DoctorEducation",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "DoctorEducation",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PatientGaurdian_PatientId",
                table: "PatientGaurdian",
                column: "PatientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DoctorSkillsAndTraining_DoctorId",
                table: "DoctorSkillsAndTraining",
                column: "DoctorId",
                unique: true);
        }
    }
}
