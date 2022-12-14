using Microsoft.EntityFrameworkCore.Migrations;

namespace iHakeem.Database.Migrations
{
    public partial class addedIsDeletedColuminDoctorSocialHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "DoctorSocialInfo",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "DoctorSocialInfo");
        }
    }
}
