using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace iHakeem.Database.Migrations
{
    public partial class PatientGuardianUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CreatedBy",
                table: "PatientGaurdian",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "PatientGaurdian",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "PatientGaurdian",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "UpdatedBy",
                table: "PatientGaurdian",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "PatientGaurdian",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "PatientGaurdian");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "PatientGaurdian");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "PatientGaurdian");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "PatientGaurdian");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "PatientGaurdian");
        }
    }
}
