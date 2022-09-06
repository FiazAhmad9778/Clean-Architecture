using Microsoft.EntityFrameworkCore.Migrations;

namespace iHakeem.Database.Migrations
{
    public partial class lookuptablerelationchanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_LookupData_LookupId",
                table: "LookupData");

            migrationBuilder.CreateIndex(
                name: "IX_LookupData_LookupId",
                table: "LookupData",
                column: "LookupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_LookupData_LookupId",
                table: "LookupData");

            migrationBuilder.CreateIndex(
                name: "IX_LookupData_LookupId",
                table: "LookupData",
                column: "LookupId",
                unique: true);
        }
    }
}
