using RzeczyDoOddaniaV2.Interfaces;
using RzeczyDoOddaniaV2.Models;
using RzeczyDoOddaniaV2.Data;
using RzeczyDoOddaniaV2.Pages;
using RzeczyDoOddaniaV2.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace RzeczyDoOddaniaV2.Services
{
    public class OfertyDBService : IOfertyDBService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IOfertyDBRepository _repository;
        public DataContext _context;

        public OfertyDBService(DataContext context, IOfertyDBRepository repository, IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            _context = context;
            _repository = repository;
        }

        public IQueryable<Komentarz> GetKomentarzeFromUser(string user)
        {
            IQueryable<Komentarz> komentarze = _repository.GetKomentarze().Where(m => m.Sprzedawca == user);
            return komentarze;
        }
        public IQueryable<Ocena> GetOcenyFromUser(string user)
        {
            IQueryable<Ocena> oceny = _repository.GetOceny().Where(m => m.Sprzedawca == user);
            return oceny;
        }
        public IList<SelectListItem> GetListaKategorii()
        {
            var lista_kategorii = _repository.GetKategorie().ToList<Kategoria>().Select(m => new SelectListItem { Text = m.NazwaKategorii, Value = m.Id.ToString() }).ToList<SelectListItem>();
            return lista_kategorii;
        }
        public async Task<Oferta> DodajZdjDoOferty(List<IFormFile> Images, Oferta oferta)
        {
            oferta.Zdjecia = new List<Zdjecie>();
            foreach (var img in Images)
            {
                Zdjecie zdjecie = new Zdjecie();
                var FileUpload = Path.Combine(_webHostEnvironment.WebRootPath, "Images", img.FileName);
                using (var Fs = new FileStream(FileUpload, FileMode.Create))
                {
                    zdjecie.ZdjeciePath = img.FileName;
                    await img.CopyToAsync(Fs);
                }
                oferta.Zdjecia.Add(zdjecie);
            }
            return oferta;
        }
        
        public async Task<Oferta> GetOfertaById(int? id)
        {
            var oferta = _repository.GetOferty().Include(ok => ok.OfertyKategorie).ThenInclude(k => k.Kategorie).FirstOrDefaultAsync(m => m.Id == id);
            return await oferta;
        }
        public async Task<Adres> GetAdresById(int? id)
        {
            var adres = _repository.GetAdresy().FirstOrDefaultAsync(a => a.OfertaId == id);
            return await adres;
        }
        public async Task<IList<Oferta>> GetOfertyByUser(string user)
        {
            var oferty = _repository.GetOferty().Where(o => o.Wlasciciel == user).ToListAsync();
            return await oferty;
        }
        public async Task<IList<Zdjecie>> GetZdjeciaById(int? id)
        {
            var zdjecia = _repository.GetZdjecia().Where(z => z.OfertaId == id).ToListAsync();
            return await zdjecia;
        }
        public async Task<IList<Zainteresowany>> GetZainteresowaniById(int? id)
        {
            var zainteresowani = _repository.GetZainteresowani().Where(z => z.OfertaId == id).ToListAsync();
            return await zainteresowani;
        }

        public async Task<IList<Oferta>> GetZdobyteOferty(string user)
        {
            var oferty = _repository.GetOferty().Where(o => o.Realizacja == true && o.Zarezerwowana == user).ToListAsync();
            return await oferty;
        }
        public async Task<IList<Komentarz>> GetKomentarzeById(int? id)
        {
            var komentarze = _repository.GetKomentarze().Where(k=> k.IdOferty == id).ToListAsync();
            return await komentarze;
        }
        public async Task<IList<Ocena>> GetOcenyById(int? id)
        {
            var oceny = _repository.GetOceny().Where(o => o.IdOferty == id).ToListAsync();
            return await oceny;
        }

        public async Task<Komentarz> AddKomentarz(Oferta oferta, IList<Komentarz> listaKomentarzy, Komentarz komentarz, string user)
        {
            if(oferta.Realizacja == true)
            {
                bool czyBylDodanyKomentarz = false;
                foreach(var k in listaKomentarzy)
                {
                    if(k.IdOferty == oferta.Id)
                    {
                        czyBylDodanyKomentarz = true;
                        break;
                    }
                }
                if(czyBylDodanyKomentarz == true)
                {
                    
                }
                else
                {
                    komentarz.Komentujacy = user;
                    komentarz.IdOferty = oferta.Id;
                    komentarz.Sprzedawca = oferta.Wlasciciel;
                }
            }
            return komentarz;
        }

        public async Task<Ocena> AddOcena(Oferta oferta, IList<Ocena> listaOcen, Ocena ocena, string user)
        {
            if (oferta.Realizacja == true)
            {
                bool czyBylDodanyKomentarz = false;
                foreach (var l in listaOcen)
                {
                    if (l.IdOferty == oferta.Id)
                    {
                        czyBylDodanyKomentarz = true;
                        break;
                    }
                }
                if (czyBylDodanyKomentarz == true)
                {
                }
                else
                {
                    ocena.Oceniajacy = user;
                    ocena.IdOferty = oferta.Id;
                    ocena.Sprzedawca = oferta.Wlasciciel;
                }
            }
            return ocena;
        }

        public async Task<List<Oferta>> GetOfertyByKategorie(IList<Oferta> oferty, IList<OfertaKategoria> ofertyKategorie, int? id)
        {
            List<Oferta> o = new List<Oferta>();
            List<int> IdDobre = new List<int>();
            foreach(var ok in ofertyKategorie)
            {
                if( ok.KategoriaId == id)
                {
                    IdDobre.Add(ok.OfertaId);
                }
            }
            foreach(var i in IdDobre)
            {
                foreach(var oferta in oferty.ToList())
                {
                    if(oferta.Id == i)
                    {
                        o.Add(oferta);
                    }
                }
            }
            return o;
        }
    }
}
