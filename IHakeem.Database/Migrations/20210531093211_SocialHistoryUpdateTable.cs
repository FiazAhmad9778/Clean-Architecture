using Microsoft.EntityFrameworkCore.Migrations;

namespace iHakeem.Database.Migrations
{
    public partial class SocialHistoryUpdateTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDepressedAndHopeless",
                table: "SocialHistory",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsInterestedOrPleasure",
                table: "SocialHistory",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDepressedAndHopeless",
                table: "SocialHistory");

            migrationBuilder.DropColumn(
                name: "IsInterestedOrPleasure",
                table: "SocialHistory");
        }
    }
}
