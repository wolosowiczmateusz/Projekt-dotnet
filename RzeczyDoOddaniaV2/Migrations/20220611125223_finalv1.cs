using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RzeczyDoOddaniaV2.Migrations
{
    public partial class finalv1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OfertaKategorie_Kategorie_KategoriaId",
                table: "OfertaKategorie");

            migrationBuilder.DropForeignKey(
                name: "FK_OfertaKategorie_Oferty_OfertaId",
                table: "OfertaKategorie");

            migrationBuilder.DropIndex(
                name: "IX_Zdjecia_OfertaId",
                table: "Zdjecia");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OfertaKategorie",
                table: "OfertaKategorie");

            migrationBuilder.DropIndex(
                name: "IX_OfertaKategorie_OfertaId",
                table: "OfertaKategorie");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "OfertaKategorie");

            migrationBuilder.RenameTable(
                name: "OfertaKategorie",
                newName: "OfertyKategorie");

            migrationBuilder.RenameColumn(
                name: "Nazwa",
                table: "Kategorie",
                newName: "NazwaKategorii");

            migrationBuilder.RenameIndex(
                name: "IX_OfertaKategorie_KategoriaId",
                table: "OfertyKategorie",
                newName: "IX_OfertyKategorie_KategoriaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OfertyKategorie",
                table: "OfertyKategorie",
                columns: new[] { "OfertaId", "KategoriaId" });

            migrationBuilder.CreateTable(
                name: "Komentarze",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    komentarz = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Komentarze", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Oceny",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ocena = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oceny", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Kategorie",
                columns: new[] { "Id", "NazwaKategorii" },
                values: new object[,]
                {
                    { 1, "Motoryzacja" },
                    { 2, "Dom i ogród" },
                    { 3, "Elektronika" },
                    { 4, "Odzież" },
                    { 5, "Rolnictwo" },
                    { 6, "Jedzenie" },
                    { 7, "Zwierzęta" },
                    { 8, "Sport" },
                    { 9, "Dla dzieci" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Zdjecia_OfertaId",
                table: "Zdjecia",
                column: "OfertaId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OfertyKategorie_Kategorie_KategoriaId",
                table: "OfertyKategorie",
                column: "KategoriaId",
                principalTable: "Kategorie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OfertyKategorie_Oferty_OfertaId",
                table: "OfertyKategorie",
                column: "OfertaId",
                principalTable: "Oferty",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OfertyKategorie_Kategorie_KategoriaId",
                table: "OfertyKategorie");

            migrationBuilder.DropForeignKey(
                name: "FK_OfertyKategorie_Oferty_OfertaId",
                table: "OfertyKategorie");

            migrationBuilder.DropTable(
                name: "Komentarze");

            migrationBuilder.DropTable(
                name: "Oceny");

            migrationBuilder.DropIndex(
                name: "IX_Zdjecia_OfertaId",
                table: "Zdjecia");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OfertyKategorie",
                table: "OfertyKategorie");

            migrationBuilder.DeleteData(
                table: "Kategorie",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Kategorie",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Kategorie",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Kategorie",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Kategorie",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Kategorie",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Kategorie",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Kategorie",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Kategorie",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.RenameTable(
                name: "OfertyKategorie",
                newName: "OfertaKategorie");

            migrationBuilder.RenameColumn(
                name: "NazwaKategorii",
                table: "Kategorie",
                newName: "Nazwa");

            migrationBuilder.RenameIndex(
                name: "IX_OfertyKategorie_KategoriaId",
                table: "OfertaKategorie",
                newName: "IX_OfertaKategorie_KategoriaId");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "OfertaKategorie",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OfertaKategorie",
                table: "OfertaKategorie",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Zdjecia_OfertaId",
                table: "Zdjecia",
                column: "OfertaId");

            migrationBuilder.CreateIndex(
                name: "IX_OfertaKategorie_OfertaId",
                table: "OfertaKategorie",
                column: "OfertaId");

            migrationBuilder.AddForeignKey(
                name: "FK_OfertaKategorie_Kategorie_KategoriaId",
                table: "OfertaKategorie",
                column: "KategoriaId",
                principalTable: "Kategorie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OfertaKategorie_Oferty_OfertaId",
                table: "OfertaKategorie",
                column: "OfertaId",
                principalTable: "Oferty",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
