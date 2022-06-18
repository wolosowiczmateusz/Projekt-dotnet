using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RzeczyDoOddaniaV2.Data;
using RzeczyDoOddaniaV2.Models;
using RzeczyDoOddaniaV2.Interfaces;

namespace RzeczyDoOddaniaV2.Pages.Oferty
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly DataContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IOfertyDBService _ofertyDBService;
        private readonly IOfertyDBRepository _ofertyDBRepository;

        public IndexModel(DataContext context, ILogger<IndexModel> logger, IWebHostEnvironment webHostEnvironment
            , UserManager<ApplicationUser> userManager, IOfertyDBService ofertyDBService, IOfertyDBRepository ofertyDBRepository)
        {
            _ofertyDBRepository = ofertyDBRepository;
            _ofertyDBService = ofertyDBService;
            _webHostEnvironment = webHostEnvironment;
            _context = context;
            _userManager = userManager;
            _logger = logger;
        }
        public string Wyszukiwanie { get; set; }

        public IList<Oferta> OfertyDobre { get; set; }
        public IList<Oferta> Oferty { get;set; }
        public IList<Oferta> Oferty_tmp { get; set; }
        public IList<OfertaKategoria> OfertyKategorie { get; set; }

        public IList<Adres> Adresy { get; set; }
        public IList<Zdjecie> Zdjecia { get;set; }

        public async Task OnGetAsync(string wyszukiwanie, int? id)
        {
            IQueryable<Oferta> ofertyIQ = from s in _context.Oferty select s;
            Adresy = await _ofertyDBRepository.GetAdresy().ToListAsync();

            if (!String.IsNullOrEmpty(wyszukiwanie) && id == null)
            {
                ofertyIQ = ofertyIQ.Where(o => o.Adres.Miasto.Contains(wyszukiwanie)
                                          || o.Adres.Ulica.Contains(wyszukiwanie));
                Oferty = await ofertyIQ.ToListAsync();
                Zdjecia = await _ofertyDBRepository.GetZdjecia().ToListAsync();
            }
            else
            {
                if(id == null)
                {
                    Oferty = await ofertyIQ.ToListAsync();
                    Zdjecia = await _ofertyDBRepository.GetZdjecia().ToListAsync();
                }
                else
                {
                    Zdjecia = await _ofertyDBRepository.GetZdjecia().ToListAsync();
                    Oferty_tmp = await _ofertyDBRepository.GetOferty().ToListAsync();
                    OfertyKategorie = await _ofertyDBRepository.GetOfertyKategorie().ToListAsync();

                    Oferty = await _ofertyDBService.GetOfertyByKategorie(Oferty_tmp, OfertyKategorie, id);
                }
                
            }
        }
    }
}
