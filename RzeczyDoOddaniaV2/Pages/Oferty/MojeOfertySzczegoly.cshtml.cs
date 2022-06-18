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
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using RzeczyDoOddaniaV2.Services;
using RzeczyDoOddaniaV2.Interfaces;

namespace RzeczyDoOddaniaV2.Pages.Oferty
{
    [Authorize]
    public class MojeOfertySzczegolyModel : PageModel
    {
        private readonly IOfertyDBRepository _ofertyDBRepository;
        private readonly IOfertyDBService _ofertyDBService;
        private readonly ILogger<CreateModel> _logger;
        private readonly DataContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly UserManager<ApplicationUser> _userManager;

        public MojeOfertySzczegolyModel(DataContext context, ILogger<CreateModel> logger, IWebHostEnvironment webHostEnvironment
            , UserManager<ApplicationUser> userManager, IOfertyDBService ofertyDBService, IOfertyDBRepository ofertyDBRepository)
        {
            _ofertyDBRepository = ofertyDBRepository;
            _ofertyDBService = ofertyDBService;
            _webHostEnvironment = webHostEnvironment;
            _context = context;
            _userManager = userManager;
            _logger = logger;
        }

        [BindProperty]
        public Oferta Oferta { get; set; } = default!;
        [BindProperty]
        public IList<Zainteresowany> Zainteresowani { get; set; }
        [BindProperty]
        public Adres Adres { get; set; }

        [BindProperty]
        public IList<Zainteresowany> ListaZainteresowanych { get; set; }
        [BindProperty]
        public Zainteresowany Zainteresowany { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            var adres = await _ofertyDBService.GetAdresById(id);
            if (id == null || _context.Oferty == null)
            {
                return NotFound();
            }

            var oferta = await _ofertyDBService.GetOfertaById(id);

            if (oferta == null)
            {
                return NotFound();
            }
            else
            {
                Oferta = oferta;
                var zainteresowani = await _ofertyDBService.GetZainteresowaniById(Oferta.Id);
                Zainteresowani = zainteresowani;
                Adres = adres;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            Oferta.Zarezerwowana = Zainteresowany.Nazwa_Zainteresowanego;
            _context.Attach(Oferta).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return RedirectToPage("/Oferty/MojeOferty");
        }


        public async Task<IActionResult> OnPostRealizacjaAsync()
        {
            Oferta.Realizacja = true;
            _context.Attach(Oferta).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return RedirectToPage("/Oferty/MojeOferty");
        }
    }
}
