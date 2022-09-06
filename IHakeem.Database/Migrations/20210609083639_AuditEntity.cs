using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace iHakeem.Database.Migrations
{
    public partial class AuditEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "SurgicalHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "SurgicalHistory",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "SurgicalHistory",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "SurgicalHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "SurgicalHistory",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "SocialHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "SocialHistory",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "SocialHistory",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "SocialHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "SocialHistory",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "RecreationalDrugsHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "RecreationalDrugsHistory",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "RecreationalDrugsHistory",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "RecreationalDrugsHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "RecreationalDrugsHistory",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "PharmacyInformation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "PharmacyInformation",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "PharmacyInformation",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "PharmacyInformation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "PharmacyInformation",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "PatientMedicalHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "PatientMedicalHistory",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "PatientMedicalHistory",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "PatientMedicalHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "PatientMedicalHistory",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "PatientAllergiesHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "PatientAllergiesHistory",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "PatientAllergiesHistory",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "PatientAllergiesHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "PatientAllergiesHistory",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "MyPhysicians",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "MyPhysicians",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "MyPhysicians",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "MyPhysicians",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "MyPhysicians",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "ExerciseHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "ExerciseHistory",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ExerciseHistory",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "ExerciseHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "ExerciseHistory",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "CurrentMedication",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "CurrentMedication",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CurrentMedication",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "CurrentMedication",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "CurrentMedication",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "HospitalizationInformation",
                columns: table => new
                {
                    Id = table.Column<long>(type: "BIGINT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HospitalName = table.Column<string>(type: "NVARCHAR(250)", nullable: true),
                    HospitaliazationYear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<long>(type: "bigint", nullable: true),
                    ReasonId = table.Column<long>(type: "bigint", nullable: true),
                    location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HospitalizaitonNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientId = table.Column<long>(type: "bigint", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HospitalizationInformation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HospitalizationInformation_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HospitalizationInformation_PatientId",
                table: "HospitalizationInformation",
                column: "PatientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HospitalizationInformation");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "SurgicalHistory");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "SurgicalHistory");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "SurgicalHistory");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "SurgicalHistory");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "SurgicalHistory");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "SocialHistory");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "SocialHistory");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "SocialHistory");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "SocialHistory");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "SocialHistory");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "RecreationalDrugsHistory");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "RecreationalDrugsHistory");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "RecreationalDrugsHistory");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "RecreationalDrugsHistory");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "RecreationalDrugsHistory");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "PharmacyInformation");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "PharmacyInformation");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "PharmacyInformation");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "PharmacyInformation");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "PharmacyInformation");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "PatientMedicalHistory");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "PatientMedicalHistory");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "PatientMedicalHistory");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "PatientMedicalHistory");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "PatientMedicalHistory");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "PatientAllergiesHistory");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "PatientAllergiesHistory");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "PatientAllergiesHistory");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "PatientAllergiesHistory");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "PatientAllergiesHistory");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "MyPhysicians");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "MyPhysicians");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "MyPhysicians");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "MyPhysicians");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "MyPhysicians");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ExerciseHistory");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "ExerciseHistory");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ExerciseHistory");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "ExerciseHistory");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "ExerciseHistory");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "CurrentMedication");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "CurrentMedication");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CurrentMedication");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "CurrentMedication");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "CurrentMedication");
        }
    }
}
