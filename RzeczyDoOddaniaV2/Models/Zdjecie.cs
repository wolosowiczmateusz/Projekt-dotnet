namespace RzeczyDoOddaniaV2.Models
{
    public class Zdjecie
    {
        public int Id { get; set; }

        public string ZdjeciePath { get; set; }
        public int OfertaId { get; set; }
        public Oferta Oferta { get; set; }
    }
}
