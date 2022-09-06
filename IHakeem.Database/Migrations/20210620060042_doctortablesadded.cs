using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace iHakeem.Database.Migrations
{
    public partial class doctortablesadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DoctorAwardsAndRecognition",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorId = table.Column<long>(type: "bigint", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Institute = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    AwardDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: false),
                    State = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: false),
                    City = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorAwardsAndRecognition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoctorAwardsAndRecognition_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DoctorLicenseAndCertification",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorId = table.Column<long>(type: "bigint", nullable: false),
                    LicenseOrCertificateNo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    LicenseOrCertificateTypeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateOfIssue = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfExpiry = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: false),
                    State = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: false),
                    City = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorLicenseAndCertification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoctorLicenseAndCertification_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctorLicenseAndCertification_LookupData_LicenseOrCertificateTypeId",
                        column: x => x.LicenseOrCertificateTypeId,
                        principalTable: "LookupData",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DoctorMembership",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorId = table.Column<long>(type: "bigint", nullable: false),
                    Designation = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: false),
                    State = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: false),
                    City = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: false),
                    CurrentlyMember = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorMembership", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoctorMembership_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DoctorReference",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorId = table.Column<long>(type: "bigint", nullable: false),
                    RelationId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contact = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Fax = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DurationAssociated = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorReference", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoctorReference_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctorReference_LookupData_RelationId",
                        column: x => x.RelationId,
                        principalTable: "LookupData",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DoctorAwardsAndRecognition_DoctorId",
                table: "DoctorAwardsAndRecognition",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorLicenseAndCertification_DoctorId",
                table: "DoctorLicenseAndCertification",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorLicenseAndCertification_LicenseOrCertificateTypeId",
                table: "DoctorLicenseAndCertification",
                column: "LicenseOrCertificateTypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DoctorMembership_DoctorId",
                table: "DoctorMembership",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorReference_DoctorId",
                table: "DoctorReference",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorReference_RelationId",
                table: "DoctorReference",
                column: "RelationId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoctorAwardsAndRecognition");

            migrationBuilder.DropTable(
                name: "DoctorLicenseAndCertification");

            migrationBuilder.DropTable(
                name: "DoctorMembership");

            migrationBuilder.DropTable(
                name: "DoctorReference");
        }
    }
}
