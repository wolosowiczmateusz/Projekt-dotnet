using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RzeczyDoOddaniaV2.Migrations
{
    public partial class ocena_i_koment_poprawki : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdOferty",
                table: "Oceny",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Oceniajacy",
                table: "Oceny",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Sprzedawca",
                table: "Oceny",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Komentujacy",
                table: "Komentarze",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdOferty",
                table: "Oceny");

            migrationBuilder.DropColumn(
                name: "Oceniajacy",
                table: "Oceny");

            migrationBuilder.DropColumn(
                name: "Sprzedawca",
                table: "Oceny");

            migrationBuilder.DropColumn(
                name: "Komentujacy",
                table: "Komentarze");
        }
    }
}
