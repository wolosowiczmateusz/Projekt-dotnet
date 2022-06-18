using System.ComponentModel.DataAnnotations;
namespace RzeczyDoOddaniaV2.Models
{
    public class Zainteresowany
    {
        public int Id { get; set; }
        [Required]
        public string Nazwa_Zainteresowanego { get; set; }
        
        public int OfertaId { get; set; }
        public Oferta Oferta { get; set; }

    }
}
