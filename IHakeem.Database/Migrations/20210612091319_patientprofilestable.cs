using Microsoft.EntityFrameworkCore.Migrations;

namespace iHakeem.Database.Migrations
{
    public partial class patientprofilestable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BloodGroupId",
                table: "Patients",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Patients",
                type: "nvarchar(55)",
                maxLength: 55,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Patients",
                type: "nvarchar(55)",
                maxLength: 55,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EthnicityId",
                table: "Patients",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HomeContact",
                table: "Patients",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaritialStatusId",
                table: "Patients",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PreferedLanguageId",
                table: "Patients",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrimaryAddress",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SecondaryAddress",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Patients",
                type: "nvarchar(55)",
                maxLength: 55,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WorkContact",
                table: "Patients",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ZipCode",
                table: "Patients",
                type: "nvarchar(55)",
                maxLength: 55,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "State",
                table: "PatientGaurdian",
                type: "nvarchar(55)",
                maxLength: 55,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GenderId",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TitleId",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PatientEmergencyContact",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<long>(type: "bigint", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: false),
                    RelationId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RelationId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientEmergencyContact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientEmergencyContact_LookupData_RelationId1",
                        column: x => x.RelationId1,
                        principalTable: "LookupData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PatientEmergencyContact_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatientSocialInformation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: false),
                    Url = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientSocialInformation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientSocialInformation_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IX_AspNetUsers_GenderId",
                table: "AspNetUsers",
                column: "GenderId",
                unique: true,
                filter: "[GenderId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_TitleId",
                table: "AspNetUsers",
                column: "TitleId",
                unique: true,
                filter: "[TitleId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PatientEmergencyContact_PatientId",
                table: "PatientEmergencyContact",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientEmergencyContact_RelationId1",
                table: "PatientEmergencyContact",
                column: "RelationId1");

            migrationBuilder.CreateIndex(
                name: "IX_PatientSocialInformation_PatientId",
                table: "PatientSocialInformation",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_LookupData_GenderId",
                table: "AspNetUsers",
                column: "GenderId",
                principalTable: "LookupData",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_LookupData_TitleId",
                table: "AspNetUsers",
                column: "TitleId",
                principalTable: "LookupData",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_LookupData_BloodGroupId",
                table: "Patients",
                column: "BloodGroupId",
                principalTable: "LookupData",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_LookupData_EthnicityId",
                table: "Patients",
                column: "EthnicityId",
                principalTable: "LookupData",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_LookupData_MaritialStatusId",
                table: "Patients",
                column: "MaritialStatusId",
                principalTable: "LookupData",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_LookupData_PreferedLanguageId",
                table: "Patients",
                column: "PreferedLanguageId",
                principalTable: "LookupData",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_LookupData_GenderId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_LookupData_TitleId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_LookupData_BloodGroupId",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_LookupData_EthnicityId",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_LookupData_MaritialStatusId",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_LookupData_PreferedLanguageId",
                table: "Patients");

            migrationBuilder.DropTable(
                name: "PatientEmergencyContact");

            migrationBuilder.DropTable(
                name: "PatientSocialInformation");

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
                name: "IX_AspNetUsers_GenderId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_TitleId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "BloodGroupId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "EthnicityId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "HomeContact",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "MaritialStatusId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "PreferedLanguageId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "PrimaryAddress",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "SecondaryAddress",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "WorkContact",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "GenderId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TitleId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "State",
                table: "PatientGaurdian",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(55)",
                oldMaxLength: 55);
        }
    }
}
