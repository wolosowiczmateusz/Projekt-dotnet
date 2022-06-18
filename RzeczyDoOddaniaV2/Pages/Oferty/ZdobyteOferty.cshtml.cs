using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RzeczyDoOddaniaV2.Data;
using RzeczyDoOddaniaV2.Models;
using RzeczyDoOddaniaV2.Interfaces;

namespace RzeczyDoOddaniaV2.Pages.Oferty
{
    [Authorize]
    public class ZdobyteOfertyModel : PageModel
    {
        private readonly IOfertyDBRepository _ofertyDBRepository;
        private readonly IOfertyDBService _ofertyDBService;
        private readonly ILogger<IndexModel> _logger;
        private readonly DataContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly UserManager<ApplicationUser> _userManager;

        public ZdobyteOfertyModel(DataContext context, ILogger<IndexModel> logger, IWebHostEnvironment webHostEnvironment
            , UserManager<ApplicationUser> userManager, IOfertyDBService ofertyDBService, IOfertyDBRepository ofertyDBRepository)
        {
            _ofertyDBRepository = ofertyDBRepository;
            _ofertyDBService = ofertyDBService;
            _webHostEnvironment = webHostEnvironment;
            _context = context;
            _userManager = userManager;
            _logger = logger;
        }

        public IList<Oferta> Oferty { get; set; }

        public IList<Zdjecie> Zdjecia { get; set; }

        public async Task OnGetAsync()
        {
            if (_context.Oferty != null)
            {
                Oferty = await _ofertyDBService.GetZdobyteOferty(_userManager.GetUserName(User));
                var zdjecia = await _ofertyDBRepository.GetZdjecia().ToListAsync();
                Zdjecia = zdjecia;
            }
        }
    }
}
