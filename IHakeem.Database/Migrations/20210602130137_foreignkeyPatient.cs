using Microsoft.EntityFrameworkCore.Migrations;

namespace iHakeem.Database.Migrations
{
    public partial class foreignkeyPatient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "PatientId",
                table: "SurgicalHistory",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "PatientId",
                table: "SocialHistory",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "PatientId",
                table: "RecreationalDrugsHistory",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "PatientId",
                table: "PatientMedicalHistory",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "PatientId",
                table: "MyPhysicians",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "PatientId",
                table: "ExerciseHistory",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_SurgicalHistory_PatientId",
                table: "SurgicalHistory",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialHistory_PatientId",
                table: "SocialHistory",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_RecreationalDrugsHistory_PatientId",
                table: "RecreationalDrugsHistory",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientMedicalHistory_PatientId",
                table: "PatientMedicalHistory",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_MyPhysicians_PatientId",
                table: "MyPhysicians",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseHistory_PatientId",
                table: "ExerciseHistory",
                column: "PatientId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseHistory_Patient_PatientId",
                table: "ExerciseHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_MyPhysicians_Patient_PatientId",
                table: "MyPhysicians");

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

            migrationBuilder.DropIndex(
                name: "IX_SurgicalHistory_PatientId",
                table: "SurgicalHistory");

            migrationBuilder.DropIndex(
                name: "IX_SocialHistory_PatientId",
                table: "SocialHistory");

            migrationBuilder.DropIndex(
                name: "IX_RecreationalDrugsHistory_PatientId",
                table: "RecreationalDrugsHistory");

            migrationBuilder.DropIndex(
                name: "IX_PatientMedicalHistory_PatientId",
                table: "PatientMedicalHistory");

            migrationBuilder.DropIndex(
                name: "IX_MyPhysicians_PatientId",
                table: "MyPhysicians");

            migrationBuilder.DropIndex(
                name: "IX_ExerciseHistory_PatientId",
                table: "ExerciseHistory");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "SurgicalHistory");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "SocialHistory");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "RecreationalDrugsHistory");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "PatientMedicalHistory");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "MyPhysicians");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "ExerciseHistory");
        }
    }
}
