using RzeczyDoOddaniaV2.Models;
namespace RzeczyDoOddaniaV2.Interfaces
{
    public interface IOfertyDBRepository
    {
        IQueryable<Komentarz> GetKomentarze();
        IQueryable<Ocena> GetOceny();
        IQueryable<Zdjecie> GetZdjecia();
        IQueryable<Oferta> GetOferty();
        IQueryable<Kategoria> GetKategorie();
        IQueryable<Adres> GetAdresy();
        IQueryable<Zainteresowany> GetZainteresowani();
        IQueryable<OfertaKategoria> GetOfertyKategorie();
    }
}
