using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace iHakeem.Database.Migrations
{
    public partial class DetailPregnancies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DetailPregnancies",
                columns: table => new
                {
                    Id = table.Column<long>(type: "BIGINT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeliveryDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    DeliveryTypeId = table.Column<long>(type: "BIGINT", nullable: false),
                    GenderId = table.Column<long>(type: "BIGINT", nullable: false),
                    NumberOfPregnancies = table.Column<string>(type: "NVARCHAR(250)", nullable: true),
                    NumberOfLivingChildrens = table.Column<string>(type: "NVARCHAR(500)", nullable: true),
                    NumberOfAbortions = table.Column<string>(type: "NVARCHAR(500)", nullable: true),
                    NumberOfMiscarriages = table.Column<string>(type: "NVARCHAR(500)", nullable: true),
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
                    table.PrimaryKey("PK_DetailPregnancies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetailPregnancies_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetailPregnancies_PatientId",
                table: "DetailPregnancies",
                column: "PatientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetailPregnancies");
        }
    }
}
