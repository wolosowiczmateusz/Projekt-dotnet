using System.ComponentModel.DataAnnotations;

namespace RzeczyDoOddaniaV2.Models
{
    public class Oferta
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Nazwa oferty jest wymagana!")]
        public string? Nazwa { get; set; }
        [Required(ErrorMessage = "Opis oferty jest wymagany!")]
        public string? Opis { get; set; }
        public Adres? Adres { get; set; }

        public string? Wlasciciel { get; set; }
        public string? Zarezerwowana { get; set; }
        public DateTime? DataWygasniecia { get; set; }
        public bool? Realizacja { get; set; }

        public IList<Zdjecie> Zdjecia { get; set; }
        public IList<Zainteresowany> Zainteresowani { get; set; }
        public IList<OfertaKategoria> OfertyKategorie { get; set; }


    }

}
