using System.Linq;
using Microsoft.EntityFrameworkCore;
using TESTEGARAGENS_DR_WEBAPI.Models;

namespace TESTEGARAGENS_DR_WEBAPI.Data
{
    public class Repository : IRepository
    {
        private readonly DAL _context;
        public Repository(DAL context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
             _context.Remove(entity);
        }

        public void Update<T>(T entity) where T : class
        {
             _context.Update(entity);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0);
        }

        public Passagem[] GetAllPassagens(bool IncludelocalAndPgto)
        {
            IQueryable<Passagem> query = _context.Passagens;

            // if(IncludelocalAndPgto)
            // {
              
            // } TODO METODO PARA RETORNAR GARAGEM E PGTO

            query = query.AsNoTracking()
                         .OrderBy(a => a.Id);

            return query.ToArray();
        }

        public Passagem[] GetAllPassagemById(int id,bool IncludelocalAndPgto)
        {
            IQueryable<Passagem> query = _context.Passagens;

            // if(IncludelocalAndPgto)
            // {

            // } TODO METODO PARA RETORNAR GARAGEM E PGTO

            query = query.AsNoTracking()
                         .OrderBy(a => a.Id)
                         .Where(Passagem => Passagem.Id == id);

            return query.ToArray();
        }

    }
}