using System.ComponentModel.DataAnnotations;
namespace RzeczyDoOddaniaV2.Models
{
    public class Komentarz
    {
        public int Id { get; set; }
        public string Komentujacy { get; set; }

        public string Tresc { get; set; }    
        public string Sprzedawca { get; set; }

        public int IdOferty { get; set; }
    }
}
