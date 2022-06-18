using Microsoft.EntityFrameworkCore;
using RzeczyDoOddaniaV2.Models;

namespace RzeczyDoOddaniaV2.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {

        }
        public DbSet<Komentarz> Komentarze { get; set; }
        public DbSet<Ocena> Oceny { get; set; }
        public DbSet<Oferta> Oferty { get; set; }
        public DbSet<Adres> Adresy { get; set; }
        public DbSet<Kategoria> Kategorie { get; set; }
        public DbSet<Zdjecie> Zdjecia { get; set; }
        public DbSet<Zainteresowany> Zainteresowani { get; set; }
        public DbSet<OfertaKategoria> OfertyKategorie { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OfertaKategoria>().HasKey(OK => new { OK.OfertaId, OK.KategoriaId });
            modelBuilder.Entity<Kategoria>().HasData(
                new Kategoria { Id = 1, NazwaKategorii = "Motoryzacja" },
                new Kategoria { Id = 2, NazwaKategorii = "Dom i ogród" },
                new Kategoria { Id = 3, NazwaKategorii = "Elektronika" },
                new Kategoria { Id = 4, NazwaKategorii = "Odzież" },
                new Kategoria { Id = 5, NazwaKategorii = "Rolnictwo" },
                new Kategoria { Id = 6, NazwaKategorii = "Jedzenie" },
                new Kategoria { Id = 7, NazwaKategorii = "Zwierzęta" },
                new Kategoria { Id = 8, NazwaKategorii = "Sport" },
                new Kategoria { Id = 9, NazwaKategorii = "Dla dzieci" }
                );
        }

    }
}
