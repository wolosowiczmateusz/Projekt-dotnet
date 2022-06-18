using System.ComponentModel.DataAnnotations;
namespace RzeczyDoOddaniaV2.Models
{
    public class Ocena
    {
        public int Id { get; set; }
        public string Oceniajacy { get; set; }
        [RegularExpression(@"^[1-9]{1-5}$", ErrorMessage = "Podaj ocenę od 1 do 5")]
        public int ocena { get; set; }
        public string Sprzedawca { get; set; }

        public int IdOferty { get; set; }
    }
}
