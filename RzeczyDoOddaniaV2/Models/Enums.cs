using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;

namespace RzeczyDoOddaniaV2.Models
{
    public enum Rodzaje_kategorii
    {
        [Display(Name = "Motoryzacja")]
        Motoryzacja,
        [Display(Name = "Dom i ogród")]
        Dom_i_ogrod,
        [Display(Name = "Elektronika")]
        Elektronika,
        [Display(Name = "Odzież")]
        Odziez,
        [Display(Name = "Rolnictwo")]
        Rolnictwo,
        [Display(Name = "Jedzenie")]
        Jedzenie,
        [Display(Name = "Zwierzęta")]
        Zwierzeta,
        [Display(Name = "Sport")]
        Sport,
        [Display (Name = "Dla dzieci")]
        Dla_dzieci
    } 
}
