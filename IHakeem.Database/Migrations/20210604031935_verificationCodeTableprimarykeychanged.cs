using Microsoft.EntityFrameworkCore.Migrations;

namespace iHakeem.Database.Migrations
{
    public partial class verificationCodeTableprimarykeychanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserVerificationCodes",
                table: "UserVerificationCodes");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "UserVerificationCodes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserVerificationCodes",
                table: "UserVerificationCodes",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserVerificationCodes",
                table: "UserVerificationCodes");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "UserVerificationCodes",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserVerificationCodes",
                table: "UserVerificationCodes",
                columns: new[] { "Code", "Id" });
        }
    }
}
