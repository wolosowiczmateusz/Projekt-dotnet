using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RzeczyDoOddaniaV2.Migrations
{
    public partial class zdjeciaOTM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Zdjecia_OfertaId",
                table: "Zdjecia");

            migrationBuilder.CreateIndex(
                name: "IX_Zdjecia_OfertaId",
                table: "Zdjecia",
                column: "OfertaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Zdjecia_OfertaId",
                table: "Zdjecia");

            migrationBuilder.CreateIndex(
                name: "IX_Zdjecia_OfertaId",
                table: "Zdjecia",
                column: "OfertaId",
                unique: true);
        }
    }
}
