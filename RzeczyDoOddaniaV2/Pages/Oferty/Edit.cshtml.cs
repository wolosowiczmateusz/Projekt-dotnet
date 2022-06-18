using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RzeczyDoOddaniaV2.Data;
using RzeczyDoOddaniaV2.Models;

namespace RzeczyDoOddaniaV2.Pages.Oferty
{
    public class EditModel : PageModel
    {
        private readonly RzeczyDoOddaniaV2.Data.DataContext _context;

        public EditModel(RzeczyDoOddaniaV2.Data.DataContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Adres Adres { get; set; }

        [BindProperty]
        public Oferta Oferta { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Oferty == null)
            {
                return NotFound();
            }



            var oferta =  await _context.Oferty.FirstOrDefaultAsync(m => m.Id == id);
            if (oferta == null)
            {
                return NotFound();
            }
            Oferta = oferta;
            var adres = await _context.Adresy.FirstOrDefaultAsync(m => m.OfertaId == Oferta.Id);
            Adres = adres;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            _context.Attach(Oferta).State = EntityState.Modified;
            _context.SaveChanges();
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OfertaExists(Oferta.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool OfertaExists(int id)
        {
          return (_context.Oferty?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
