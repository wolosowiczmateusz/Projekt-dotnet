using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RzeczyDoOddaniaV2.Migrations
{
    public partial class zainteresowany_poprawka : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Kupiec",
                table: "Oferty");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Kupiec",
                table: "Oferty",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
