using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RzeczyDoOddaniaV2.Data;
using RzeczyDoOddaniaV2.Models;

namespace RzeczyDoOddaniaV2.Pages.Oferty
{
    public class DeleteModel : PageModel
    {
        private readonly RzeczyDoOddaniaV2.Data.DataContext _context;

        public DeleteModel(RzeczyDoOddaniaV2.Data.DataContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Oferta Oferta { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Oferty == null)
            {
                return NotFound();
            }

            var oferta = await _context.Oferty.FirstOrDefaultAsync(m => m.Id == id);

            if (oferta == null)
            {
                return NotFound();
            }
            else 
            {
                Oferta = oferta;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Oferty == null)
            {
                return NotFound();
            }
            var oferta = await _context.Oferty.FindAsync(id);

            if (oferta != null)
            {
                Oferta = oferta;
                _context.Oferty.Remove(Oferta);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
