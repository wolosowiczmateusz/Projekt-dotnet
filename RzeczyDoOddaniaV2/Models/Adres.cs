using System.ComponentModel.DataAnnotations;
namespace RzeczyDoOddaniaV2.Models
{
    public class Adres
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Ulica jest wymagana!")]
        [RegularExpression(@"^((?!^City$)[a-zA-Z '])+$", ErrorMessage = "Podaj prawidłową nazwę ulicy")]
        public string Ulica { get; set; }
        [Required(ErrorMessage = "Numer domu jest wymagany!")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Podaj prawidłowy numer domu")]
        public string Nr_domu { get; set; }
        [Required(ErrorMessage = "Miejscowość jest wymagana!")]
        [RegularExpression(@"^((?!^City$)[a-zA-Z '])+$", ErrorMessage = "Podaj prawidłową miejscowość")]
        public string Miasto { get; set; }
        [Required(ErrorMessage = "Kod pocztowy jest wymagany!")]
        [RegularExpression(@"[0-9\- \s]{6}$", ErrorMessage ="Podaj prawidłowy kod pocztowy")]
        public string Kod_Pocztowy { get; set; }



        public int OfertaId { get; set; }

        public Oferta Oferta { get; set; }


    }
}
