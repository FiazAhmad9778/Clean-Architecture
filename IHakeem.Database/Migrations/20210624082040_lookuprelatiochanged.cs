using Microsoft.EntityFrameworkCore.Migrations;

namespace iHakeem.Database.Migrations
{
    public partial class lookuprelatiochanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctorLicenseAndCertification_LookupData_LicenseOrCertificateTypeId",
                table: "DoctorLicenseAndCertification");

            migrationBuilder.DropForeignKey(
                name: "FK_DoctorReference_LookupData_RelationId",
                table: "DoctorReference");

            migrationBuilder.DropIndex(
                name: "IX_Patients_BloodGroupId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_EthnicityId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_MaritialStatusId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_PreferedLanguageId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_PatientGaurdian_RelationId",
                table: "PatientGaurdian");

            migrationBuilder.DropIndex(
                name: "IX_DoctorSkillsAndTraining_EducationTypeId",
                table: "DoctorSkillsAndTraining");

            migrationBuilder.DropIndex(
                name: "IX_DoctorService_ServiceId",
                table: "DoctorService");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_MaritialStatusId",
                table: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_DoctorReference_RelationId",
                table: "DoctorReference");

            migrationBuilder.DropIndex(
                name: "IX_DoctorLicenseAndCertification_LicenseOrCertificateTypeId",
                table: "DoctorLicenseAndCertification");

            migrationBuilder.DropIndex(
                name: "IX_DoctorEducation_EducationTypeId",
                table: "DoctorEducation");

            migrationBuilder.AlterColumn<string>(
                name: "RelationId",
                table: "DoctorReference",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LicenseOrCertificateTypeId",
                table: "DoctorLicenseAndCertification",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_BloodGroupId",
                table: "Patients",
                column: "BloodGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_EthnicityId",
                table: "Patients",
                column: "EthnicityId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_MaritialStatusId",
                table: "Patients",
                column: "MaritialStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_PreferedLanguageId",
                table: "Patients",
                column: "PreferedLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientGaurdian_RelationId",
                table: "PatientGaurdian",
                column: "RelationId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorSkillsAndTraining_EducationTypeId",
                table: "DoctorSkillsAndTraining",
                column: "EducationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorService_ServiceId",
                table: "DoctorService",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_MaritialStatusId",
                table: "Doctors",
                column: "MaritialStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorReference_RelationId",
                table: "DoctorReference",
                column: "RelationId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorLicenseAndCertification_LicenseOrCertificateTypeId",
                table: "DoctorLicenseAndCertification",
                column: "LicenseOrCertificateTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorEducation_EducationTypeId",
                table: "DoctorEducation",
                column: "EducationTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorLicenseAndCertification_LookupData_LicenseOrCertificateTypeId",
                table: "DoctorLicenseAndCertification",
                column: "LicenseOrCertificateTypeId",
                principalTable: "LookupData",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorReference_LookupData_RelationId",
                table: "DoctorReference",
                column: "RelationId",
                principalTable: "LookupData",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctorLicenseAndCertification_LookupData_LicenseOrCertificateTypeId",
                table: "DoctorLicenseAndCertification");

            migrationBuilder.DropForeignKey(
                name: "FK_DoctorReference_LookupData_RelationId",
                table: "DoctorReference");

            migrationBuilder.DropIndex(
                name: "IX_Patients_BloodGroupId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_EthnicityId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_MaritialStatusId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_PreferedLanguageId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_PatientGaurdian_RelationId",
                table: "PatientGaurdian");

            migrationBuilder.DropIndex(
                name: "IX_DoctorSkillsAndTraining_EducationTypeId",
                table: "DoctorSkillsAndTraining");

            migrationBuilder.DropIndex(
                name: "IX_DoctorService_ServiceId",
                table: "DoctorService");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_MaritialStatusId",
                table: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_DoctorReference_RelationId",
                table: "DoctorReference");

            migrationBuilder.DropIndex(
                name: "IX_DoctorLicenseAndCertification_LicenseOrCertificateTypeId",
                table: "DoctorLicenseAndCertification");

            migrationBuilder.DropIndex(
                name: "IX_DoctorEducation_EducationTypeId",
                table: "DoctorEducation");

            migrationBuilder.AlterColumn<string>(
                name: "RelationId",
                table: "DoctorReference",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LicenseOrCertificateTypeId",
                table: "DoctorLicenseAndCertification",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patients_BloodGroupId",
                table: "Patients",
                column: "BloodGroupId",
                unique: true,
                filter: "[BloodGroupId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_EthnicityId",
                table: "Patients",
                column: "EthnicityId",
                unique: true,
                filter: "[EthnicityId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_MaritialStatusId",
                table: "Patients",
                column: "MaritialStatusId",
                unique: true,
                filter: "[MaritialStatusId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_PreferedLanguageId",
                table: "Patients",
                column: "PreferedLanguageId",
                unique: true,
                filter: "[PreferedLanguageId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PatientGaurdian_RelationId",
                table: "PatientGaurdian",
                column: "RelationId",
                unique: true,
                filter: "[RelationId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorSkillsAndTraining_EducationTypeId",
                table: "DoctorSkillsAndTraining",
                column: "EducationTypeId",
                unique: true,
                filter: "[EducationTypeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorService_ServiceId",
                table: "DoctorService",
                column: "ServiceId",
                unique: true,
                filter: "[ServiceId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_MaritialStatusId",
                table: "Doctors",
                column: "MaritialStatusId",
                unique: true,
                filter: "[MaritialStatusId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorReference_RelationId",
                table: "DoctorReference",
                column: "RelationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DoctorLicenseAndCertification_LicenseOrCertificateTypeId",
                table: "DoctorLicenseAndCertification",
                column: "LicenseOrCertificateTypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DoctorEducation_EducationTypeId",
                table: "DoctorEducation",
                column: "EducationTypeId",
                unique: true,
                filter: "[EducationTypeId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorLicenseAndCertification_LookupData_LicenseOrCertificateTypeId",
                table: "DoctorLicenseAndCertification",
                column: "LicenseOrCertificateTypeId",
                principalTable: "LookupData",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorReference_LookupData_RelationId",
                table: "DoctorReference",
                column: "RelationId",
                principalTable: "LookupData",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
