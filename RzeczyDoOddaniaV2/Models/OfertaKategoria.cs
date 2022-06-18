namespace RzeczyDoOddaniaV2.Models
{
    public class OfertaKategoria
    {
        public Oferta Oferty { get; set; }
        public int OfertaId { get; set; }

        public Kategoria Kategorie { get; set; }
        public int KategoriaId { get; set; }

    }
}
