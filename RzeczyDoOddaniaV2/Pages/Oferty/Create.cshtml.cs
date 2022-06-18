using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RzeczyDoOddaniaV2.Data;
using RzeczyDoOddaniaV2.Models;
using RzeczyDoOddaniaV2.Interfaces;
using RzeczyDoOddaniaV2.Services;

namespace RzeczyDoOddaniaV2.Pages.Oferty
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly ILogger<CreateModel> _logger;
        private readonly DataContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IOfertyDBService _ofertyDBService;

        public CreateModel(DataContext context, ILogger<CreateModel> logger, IWebHostEnvironment webHostEnvironment
            , UserManager<ApplicationUser> userManager, IOfertyDBService ofertyDBService)
        {
            _ofertyDBService = ofertyDBService;
            _webHostEnvironment = webHostEnvironment;
            _context = context;
            _userManager = userManager;
            _logger = logger;
        }

        [BindProperty]
        public List<IFormFile> Images { get; set; }

        [BindProperty]
        public Oferta Oferta { get; set; }

        [BindProperty]
        public Zdjecie Zdjecie { get; set; }

        [BindProperty]
        public Adres Adres { get; set; }

        [BindProperty]
        public IList<SelectListItem> ListaKategorii { get; set; }
        
        
        [BindProperty]
        public IList<Oferta> ListaOfert { get; set; }

        public IActionResult OnGet()
        {
            ListaKategorii = _ofertyDBService.GetListaKategorii();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {

            if (_context.Oferty == null || Oferta == null)
            {
                return Page();
            }
            if (!Images.Any())
            {
                ViewData["Message"] = "Musisz dodać conajmniej jedno zdjęcie";
                return Page();
            }

            // dodawanie kategorii
            IList<OfertaKategoria> OfertyKategorie = new List<OfertaKategoria>();
            foreach (SelectListItem kategoria in ListaKategorii)
            {
                if (kategoria.Selected)
                {
                    OfertyKategorie.Add(new OfertaKategoria { KategoriaId = Convert.ToInt32(kategoria.Value) });
                }
            }


            Oferta.OfertyKategorie = OfertyKategorie;
            Oferta.Wlasciciel = _userManager.GetUserName(User);
            Oferta = await _ofertyDBService.DodajZdjDoOferty(Images, Oferta);
            Oferta.Adres = Adres;
            _context.Oferty.Add(Oferta);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
