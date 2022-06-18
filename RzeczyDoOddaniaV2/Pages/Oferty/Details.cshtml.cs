using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using RzeczyDoOddaniaV2.Data;
using RzeczyDoOddaniaV2.Models;
using RzeczyDoOddaniaV2.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RzeczyDoOddaniaV2.Pages.Oferty
{
    public class DetailsModel : PageModel
    {
        private readonly IOfertyDBService _ofertyDBService;
        private readonly ILogger<CreateModel> _logger;
        private readonly DataContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly UserManager<ApplicationUser> _userManager;

        public DetailsModel(DataContext context, ILogger<CreateModel> logger, IWebHostEnvironment webHostEnvironment
            , UserManager<ApplicationUser> userManager, IOfertyDBService ofertyDBService)
        {
            _ofertyDBService = ofertyDBService;
            _webHostEnvironment = webHostEnvironment;
            _context = context;
            _userManager = userManager;
            _logger = logger;
        }

        [BindProperty]
        public Oferta Oferta { get; set; } = default!;

        [BindProperty]
        public IList<Zainteresowany> ListaZainteresowanych { get; set; }

        [BindProperty]
        public Adres Adres { get; set; }
        [BindProperty]
        public bool KomentarzDodany{ get; set; }
        [BindProperty]
        public Komentarz Komentarz { get; set; }

        [BindProperty]
        public IList<Komentarz> ListaKomentarzy { get; set; }

        [BindProperty]
        public Ocena Ocena { get; set; }

        [BindProperty]
        public IList<Ocena> ListaOcen { get; set; }

        [BindProperty]
        public IList<Zdjecie> ListaZdjec { get; set; }

        [BindProperty]       
        public string user { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {

            if (id == null || _context.Oferty == null)
            {
                return NotFound();
            }
            var adres = await _ofertyDBService.GetAdresById(id);
            var oferta = await _ofertyDBService.GetOfertaById(id);
            //var oferta = Oferta.OfertyKategorie.Where(k=> k.Kategorie.NazwaKategorii == "aa");
            ListaZdjec = await _ofertyDBService.GetZdjeciaById(id);
            ListaKomentarzy = await _ofertyDBService.GetKomentarzeById(id);
            ListaOcen = await _ofertyDBService.GetOcenyById(id);
            if (oferta == null)
            {
                return NotFound();
            }
            else
            {
                Adres = adres;
                Oferta = oferta;
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {

            var user = _userManager.GetUserName(User);
            ListaKomentarzy = await _ofertyDBService.GetKomentarzeById(Oferta.Id);
            ListaZainteresowanych = await _ofertyDBService.GetZainteresowaniById(Oferta.Id);
            Zainteresowany zainteresowany = new Zainteresowany();
            zainteresowany.OfertaId = Oferta.Id;
            zainteresowany.Nazwa_Zainteresowanego = user;

            foreach (var zain in ListaZainteresowanych)
            {
                if (zain.Nazwa_Zainteresowanego == user && zain.OfertaId == Oferta.Id)
                {
                    return RedirectToPage("./Index");
                }
            }

            ListaZainteresowanych.Add(zainteresowany);
            Oferta.Zainteresowani = ListaZainteresowanych;

            _context.Attach(Oferta).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }

        public async Task<IActionResult> OnPostKomentarzAsync()
        {
            ListaKomentarzy = await _ofertyDBService.GetKomentarzeById(Oferta.Id);
            string user = _userManager.GetUserName(User);
            
            Komentarz = await _ofertyDBService.AddKomentarz(Oferta, ListaKomentarzy, Komentarz, user);
            if (Komentarz.Tresc != null)
            {
                _context.Komentarze.Add(Komentarz);
            }


            _context.Attach(Oferta).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return RedirectToPage("/Oferty/ZdobyteOferty");
        }
        public async Task<IActionResult> OnPostOcenaAsync()
        {
            ListaOcen = await _context.Oceny.Where(o => o.IdOferty == Oferta.Id).ToListAsync();
            string user = _userManager.GetUserName(User);
            Ocena = await _ofertyDBService.AddOcena(Oferta, ListaOcen, Ocena, user);
            if (Ocena.ocena != null)
            {
                _context.Oceny.Add(Ocena);
            }

            _context.Attach(Oferta).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return RedirectToPage("/Oferty/ZdobyteOferty");
        }
    }
}

