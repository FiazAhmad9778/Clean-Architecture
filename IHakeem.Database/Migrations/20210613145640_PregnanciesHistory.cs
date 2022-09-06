using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace iHakeem.Database.Migrations
{
    public partial class PregnanciesHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PregnanciesHistory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "BIGINT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mammogram = table.Column<string>(type: "NVARCHAR(250)", nullable: true),
                    BreastExam = table.Column<string>(type: "NVARCHAR(500)", nullable: true),
                    PapSmear = table.Column<string>(type: "NVARCHAR(500)", nullable: true),
                    DoYouUseContraceptionId = table.Column<long>(type: "BIGINT", nullable: false),
                    KindOfContraception = table.Column<string>(type: "NVARCHAR(500)", nullable: true),
                    AgeAtFirstMenses = table.Column<string>(type: "NVARCHAR(500)", nullable: true),
                    MenstrualPeriods = table.Column<string>(type: "NVARCHAR(500)", nullable: true),
                    AgeAtMenopause = table.Column<string>(type: "NVARCHAR(500)", nullable: true),
                    HotFlashesOrOtherSymptoms = table.Column<string>(type: "NVARCHAR(500)", nullable: true),
                    GynaecologicalConditionsOrProblems = table.Column<string>(type: "NVARCHAR(500)", nullable: true),
                    Notes = table.Column<string>(type: "NVARCHAR(500)", nullable: true),
                    PatientId = table.Column<long>(type: "BIGINT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<long>(type: "BIGINT", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<long>(type: "BIGINT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PregnanciesHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PregnanciesHistory_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PregnanciesHistory_PatientId",
                table: "PregnanciesHistory",
                column: "PatientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PregnanciesHistory");
        }
    }
}
