using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RzeczyDoOddaniaV2.Migrations
{
    public partial class komentarze : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Sprzedawca",
                table: "Komentarze",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sprzedawca",
                table: "Komentarze");
        }
    }
}
