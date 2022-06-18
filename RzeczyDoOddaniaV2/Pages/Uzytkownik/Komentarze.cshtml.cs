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
using RzeczyDoOddaniaV2.Services;
using RzeczyDoOddaniaV2.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace RzeczyDoOddaniaV2.Pages.Uzytkownik
{
    [Authorize]
    public class KomentarzeModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly DataContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IOfertyDBService _ofertyDBService;
        public KomentarzeModel(DataContext context, ILogger<IndexModel> logger, IWebHostEnvironment webHostEnvironment
            , UserManager<ApplicationUser> userManager, IOfertyDBService ofertyDBService)
        {
            _ofertyDBService = ofertyDBService;
            _webHostEnvironment = webHostEnvironment;
            _context = context;
            _userManager = userManager;
            _logger = logger;
        }
        [BindProperty]
        public List<Komentarz> Lista_Komentarzy { get; set; }

        [BindProperty]
        public List<Ocena> Lista_Ocen { get; set; }


        public async Task OnGetAsync()
        {
            var user = _userManager.GetUserName(User);
            Lista_Komentarzy = await _ofertyDBService.GetKomentarzeFromUser(user).ToListAsync();
            Lista_Ocen = await _ofertyDBService.GetOcenyFromUser(user).ToListAsync();
        }
    }
}
