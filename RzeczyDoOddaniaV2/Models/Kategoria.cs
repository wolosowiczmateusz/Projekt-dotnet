namespace RzeczyDoOddaniaV2.Models
{
    public class Kategoria
    {
        public int Id { get; set; }
        public string NazwaKategorii { get; set; }


        public IList<OfertaKategoria> OfertyKategorie { get; set; }
    }
}
