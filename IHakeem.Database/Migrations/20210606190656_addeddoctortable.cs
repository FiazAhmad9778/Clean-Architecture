using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace iHakeem.Database.Migrations
{
    public partial class addeddoctortable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CurrentMedication_Patient_PatientId",
                table: "CurrentMedication");

            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseHistory_Patient_PatientId",
                table: "ExerciseHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_MyPhysicians_Patient_PatientId",
                table: "MyPhysicians");

            migrationBuilder.DropForeignKey(
                name: "FK_Patient_AspNetUsers_UserId",
                table: "Patient");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientAllergiesHistory_Patient_PatientId",
                table: "PatientAllergiesHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientMedicalHistory_Patient_PatientId",
                table: "PatientMedicalHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_RecreationalDrugsHistory_Patient_PatientId",
                table: "RecreationalDrugsHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_SocialHistory_Patient_PatientId",
                table: "SocialHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_SurgicalHistory_Patient_PatientId",
                table: "SurgicalHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Patient",
                table: "Patient");

            migrationBuilder.RenameTable(
                name: "Patient",
                newName: "Patients");

            migrationBuilder.RenameIndex(
                name: "IX_Patient_UserId",
                table: "Patients",
                newName: "IX_Patients_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Patients",
                table: "Patients",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctors_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_UserId",
                table: "Doctors",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CurrentMedication_Patients_PatientId",
                table: "CurrentMedication",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseHistory_Patients_PatientId",
                table: "ExerciseHistory",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MyPhysicians_Patients_PatientId",
                table: "MyPhysicians",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientAllergiesHistory_Patients_PatientId",
                table: "PatientAllergiesHistory",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientMedicalHistory_Patients_PatientId",
                table: "PatientMedicalHistory",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_AspNetUsers_UserId",
                table: "Patients",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecreationalDrugsHistory_Patients_PatientId",
                table: "RecreationalDrugsHistory",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SocialHistory_Patients_PatientId",
                table: "SocialHistory",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SurgicalHistory_Patients_PatientId",
                table: "SurgicalHistory",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CurrentMedication_Patients_PatientId",
                table: "CurrentMedication");

            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseHistory_Patients_PatientId",
                table: "ExerciseHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_MyPhysicians_Patients_PatientId",
                table: "MyPhysicians");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientAllergiesHistory_Patients_PatientId",
                table: "PatientAllergiesHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientMedicalHistory_Patients_PatientId",
                table: "PatientMedicalHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_AspNetUsers_UserId",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_RecreationalDrugsHistory_Patients_PatientId",
                table: "RecreationalDrugsHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_SocialHistory_Patients_PatientId",
                table: "SocialHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_SurgicalHistory_Patients_PatientId",
                table: "SurgicalHistory");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Patients",
                table: "Patients");

            migrationBuilder.RenameTable(
                name: "Patients",
                newName: "Patient");

            migrationBuilder.RenameIndex(
                name: "IX_Patients_UserId",
                table: "Patient",
                newName: "IX_Patient_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Patient",
                table: "Patient",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CurrentMedication_Patient_PatientId",
                table: "CurrentMedication",
                column: "PatientId",
                principalTable: "Patient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseHistory_Patient_PatientId",
                table: "ExerciseHistory",
                column: "PatientId",
                principalTable: "Patient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MyPhysicians_Patient_PatientId",
                table: "MyPhysicians",
                column: "PatientId",
                principalTable: "Patient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Patient_AspNetUsers_UserId",
                table: "Patient",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientAllergiesHistory_Patient_PatientId",
                table: "PatientAllergiesHistory",
                column: "PatientId",
                principalTable: "Patient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientMedicalHistory_Patient_PatientId",
                table: "PatientMedicalHistory",
                column: "PatientId",
                principalTable: "Patient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecreationalDrugsHistory_Patient_PatientId",
                table: "RecreationalDrugsHistory",
                column: "PatientId",
                principalTable: "Patient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SocialHistory_Patient_PatientId",
                table: "SocialHistory",
                column: "PatientId",
                principalTable: "Patient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SurgicalHistory_Patient_PatientId",
                table: "SurgicalHistory",
                column: "PatientId",
                principalTable: "Patient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
