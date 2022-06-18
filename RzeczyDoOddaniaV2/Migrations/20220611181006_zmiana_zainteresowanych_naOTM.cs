using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RzeczyDoOddaniaV2.Migrations
{
    public partial class zmiana_zainteresowanych_naOTM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<int>(
                name: "OfertaId",
                table: "Zainteresowani",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Zainteresowani_OfertaId",
                table: "Zainteresowani",
                column: "OfertaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Zainteresowani_Oferty_OfertaId",
                table: "Zainteresowani",
                column: "OfertaId",
                principalTable: "Oferty",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zainteresowani_Oferty_OfertaId",
                table: "Zainteresowani");

            migrationBuilder.DropIndex(
                name: "IX_Zainteresowani_OfertaId",
                table: "Zainteresowani");

            migrationBuilder.DropColumn(
                name: "OfertaId",
                table: "Zainteresowani");

            migrationBuilder.CreateTable(
                name: "OfertyZainteresowani",
                columns: table => new
                {
                    OfertaId = table.Column<int>(type: "int", nullable: false),
                    ZainteresowanyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfertyZainteresowani", x => new { x.OfertaId, x.ZainteresowanyId });
                    table.ForeignKey(
                        name: "FK_OfertyZainteresowani_Oferty_OfertaId",
                        column: x => x.OfertaId,
                        principalTable: "Oferty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OfertyZainteresowani_Zainteresowani_ZainteresowanyId",
                        column: x => x.ZainteresowanyId,
                        principalTable: "Zainteresowani",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OfertyZainteresowani_ZainteresowanyId",
                table: "OfertyZainteresowani",
                column: "ZainteresowanyId");
        }
    }
}
