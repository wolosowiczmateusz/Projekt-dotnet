using RzeczyDoOddaniaV2.Interfaces;
using RzeczyDoOddaniaV2.Models;
using RzeczyDoOddaniaV2.Pages;
using RzeczyDoOddaniaV2.Services;
using RzeczyDoOddaniaV2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace RzeczyDoOddaniaV2.Repositories
{
    public class OfertyDBRepository :IOfertyDBRepository
    {
        public DataContext _context;

        public OfertyDBRepository(DataContext context)
        {
            _context = context;
        }

        public IQueryable<Komentarz> GetKomentarze()
        {
            return _context.Komentarze;
        }

        public IQueryable<Ocena> GetOceny()
        {
            return _context.Oceny;
        }

        public IQueryable<Zainteresowany> GetZainteresowani()
        {
            return _context.Zainteresowani;
        }

        public IQueryable<Oferta> GetOferty()
        {
            return _context.Oferty;
        }

        public IQueryable<Zdjecie> GetZdjecia()
        {
            return _context.Zdjecia;
        }

        public IQueryable<Kategoria> GetKategorie()
        {
            return _context.Kategorie;
        }

        public IQueryable<Adres> GetAdresy()
        {
            return _context.Adresy;
        }

        public IQueryable<OfertaKategoria> GetOfertyKategorie()
        {
            return _context.OfertyKategorie;
        }

    }
}
