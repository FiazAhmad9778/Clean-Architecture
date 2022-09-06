using Microsoft.EntityFrameworkCore.Migrations;

namespace iHakeem.Database.Migrations
{
    public partial class CurrentMedication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CurrentMedication",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicineId = table.Column<long>(type: "bigint", nullable: false),
                    ReasonForTakingMedicine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dose = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoseFrequentId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AsNeeded = table.Column<bool>(type: "bit", nullable: false),
                    DoseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoctorNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PharmacyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PharmacyNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrentMedication", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CurrentMedication_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CurrentMedication_PatientId",
                table: "CurrentMedication",
                column: "PatientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CurrentMedication");
        }
    }
}
