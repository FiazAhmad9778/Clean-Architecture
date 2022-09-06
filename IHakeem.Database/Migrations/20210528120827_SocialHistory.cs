using Microsoft.EntityFrameworkCore.Migrations;

namespace iHakeem.Database.Migrations
{
    public partial class SocialHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SocialHistory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SmokingId = table.Column<long>(type: "bigint", nullable: false),
                    TobaccoTypeId = table.Column<long>(type: "bigint", nullable: false),
                    NumberOfYears = table.Column<long>(type: "bigint", nullable: false),
                    AmountPerDay = table.Column<long>(type: "bigint", nullable: false),
                    QuitYear = table.Column<long>(type: "bigint", nullable: false),
                    SmokingNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CaffeineId = table.Column<long>(type: "bigint", nullable: false),
                    NumberOfCaffeinatedDrinksPerDay = table.Column<long>(type: "bigint", nullable: false),
                    CaffeineNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AlcoholId = table.Column<long>(type: "bigint", nullable: false),
                    NumberOfDrinksPerWeek = table.Column<long>(type: "bigint", nullable: false),
                    PreferredDrink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AlcoholNotes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialHistory", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SocialHistory");
        }
    }
}
