using Microsoft.AspNetCore.Identity;

namespace RzeczyDoOddaniaV2.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }

        public string Miasto { get; set; }

    }
}
