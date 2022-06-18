using RzeczyDoOddaniaV2.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RzeczyDoOddaniaV2.Interfaces
{
    public interface IOfertyDBService
    {
        IQueryable<Komentarz> GetKomentarzeFromUser(string user);
        IQueryable<Ocena> GetOcenyFromUser(string user);
        IList<SelectListItem> GetListaKategorii();
        Task<Oferta> DodajZdjDoOferty(List<IFormFile> Images, Oferta oferta);
        Task<Oferta> GetOfertaById(int? id);
        Task<Adres> GetAdresById(int? id);
        Task<IList<Oferta>> GetOfertyByUser(string user);
        Task<IList<Zdjecie>> GetZdjeciaById(int? id);
        Task<IList<Komentarz>> GetKomentarzeById(int? id);
        Task<IList<Ocena>> GetOcenyById(int? id);
        Task<IList<Zainteresowany>> GetZainteresowaniById(int? id);
        Task<IList<Oferta>> GetZdobyteOferty(string user);
        Task<Komentarz> AddKomentarz(Oferta oferta, IList<Komentarz> listaKomentarzy, Komentarz komentarz, string user);
        Task<Ocena> AddOcena(Oferta oferta, IList<Ocena> listaOcen, Ocena ocena, string user);
        Task<List<Oferta>> GetOfertyByKategorie(IList<Oferta> oferty, IList<OfertaKategoria> ofertyKategorie, int? id);
    } 
}
