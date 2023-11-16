using TESTEGARAGENS_DR_WEBAPI.Models;

namespace TESTEGARAGENS_DR_WEBAPI.Data
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        bool SaveChanges();

        Passagem[] GetAllPassagens(bool IncludelocalAndPgto);
        Passagem[] GetAllPassagemById(int id,bool IncludelocalAndPgto);

    }
}