using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmStack.Migrations
{
    public partial class UpdateLoginSignup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "AdminLogins",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AdminLogins",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "AdminLogins");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AdminLogins");
        }
    }
}
