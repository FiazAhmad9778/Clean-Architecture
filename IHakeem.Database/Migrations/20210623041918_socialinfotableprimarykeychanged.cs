using Microsoft.EntityFrameworkCore.Migrations;

namespace iHakeem.Database.Migrations
{
    public partial class socialinfotableprimarykeychanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PatientSocialInformation");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "PatientEmergencyContact",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "DoctorWorkExperience",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "DoctorSkillsAndTraining",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "DoctorService",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "DoctorReference",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "DoctorMembership",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "DoctorLicenseAndCertification",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "DoctorEducation",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "DoctorAwardsAndRecognition",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "SocialInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: false),
                    Url = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DoctorSocialInfo",
                columns: table => new
                {
                    DoctorId = table.Column<long>(type: "bigint", nullable: false),
                    SocialInformationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorSocialInfo", x => new { x.SocialInformationId, x.DoctorId });
                    table.ForeignKey(
                        name: "FK_DoctorSocialInfo_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctorSocialInfo_SocialInfo_SocialInformationId",
                        column: x => x.SocialInformationId,
                        principalTable: "SocialInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatientSocialInfo",
                columns: table => new
                {
                    PatientId = table.Column<long>(type: "bigint", nullable: false),
                    SocialInformationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientSocialInfo", x => new { x.SocialInformationId, x.PatientId });
                    table.ForeignKey(
                        name: "FK_PatientSocialInfo_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientSocialInfo_SocialInfo_SocialInformationId",
                        column: x => x.SocialInformationId,
                        principalTable: "SocialInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DoctorSocialInfo_DoctorId",
                table: "DoctorSocialInfo",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorSocialInfo_SocialInformationId",
                table: "DoctorSocialInfo",
                column: "SocialInformationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PatientSocialInfo_PatientId",
                table: "PatientSocialInfo",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientSocialInfo_SocialInformationId",
                table: "PatientSocialInfo",
                column: "SocialInformationId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoctorSocialInfo");

            migrationBuilder.DropTable(
                name: "PatientSocialInfo");

            migrationBuilder.DropTable(
                name: "SocialInfo");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "PatientEmergencyContact");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "DoctorWorkExperience");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "DoctorSkillsAndTraining");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "DoctorService");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "DoctorReference");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "DoctorMembership");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "DoctorLicenseAndCertification");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "DoctorEducation");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "DoctorAwardsAndRecognition");

            migrationBuilder.CreateTable(
                name: "PatientSocialInformation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: false),
                    PatientId = table.Column<long>(type: "bigint", nullable: false),
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
                name: "IX_PatientSocialInformation_PatientId",
                table: "PatientSocialInformation",
                column: "PatientId");
        }
    }
}
