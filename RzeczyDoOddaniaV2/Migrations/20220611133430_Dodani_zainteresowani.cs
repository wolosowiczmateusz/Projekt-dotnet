using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RzeczyDoOddaniaV2.Migrations
{
    public partial class Dodani_zainteresowani : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "User",
                table: "Oferty",
                newName: "Wlasciciel");

            migrationBuilder.CreateTable(
                name: "Zainteresowani",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa_Zainteresowanego = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OfertaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zainteresowani", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Zainteresowani_Oferty_OfertaId",
                        column: x => x.OfertaId,
                        principalTable: "Oferty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Zainteresowani_OfertaId",
                table: "Zainteresowani",
                column: "OfertaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Zainteresowani");

            migrationBuilder.RenameColumn(
                name: "Wlasciciel",
                table: "Oferty",
                newName: "User");
        }
    }
}
