using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace iHakeem.Database.Migrations
{
    public partial class doctoreducationandtraining : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DoctorEducation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EducationTypeId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DoctorId = table.Column<long>(type: "bigint", nullable: false),
                    DegreeName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    Institute = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Majors = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DegreeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: false),
                    State = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: false),
                    City = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorEducation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoctorEducation_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctorEducation_LookupData_EducationTypeId",
                        column: x => x.EducationTypeId,
                        principalTable: "LookupData",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DoctorSkillsAndTraining",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EducationTypeId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DoctorId = table.Column<long>(type: "bigint", nullable: false),
                    SkillName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Institute = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    SuperVisor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SuperVisorContact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: false),
                    State = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: false),
                    City = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorSkillsAndTraining", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoctorSkillsAndTraining_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctorSkillsAndTraining_LookupData_EducationTypeId",
                        column: x => x.EducationTypeId,
                        principalTable: "LookupData",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DoctorEducation_DoctorId",
                table: "DoctorEducation",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorEducation_EducationTypeId",
                table: "DoctorEducation",
                column: "EducationTypeId",
                unique: true,
                filter: "[EducationTypeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorSkillsAndTraining_DoctorId",
                table: "DoctorSkillsAndTraining",
                column: "DoctorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DoctorSkillsAndTraining_EducationTypeId",
                table: "DoctorSkillsAndTraining",
                column: "EducationTypeId",
                unique: true,
                filter: "[EducationTypeId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoctorEducation");

            migrationBuilder.DropTable(
                name: "DoctorSkillsAndTraining");
        }
    }
}
