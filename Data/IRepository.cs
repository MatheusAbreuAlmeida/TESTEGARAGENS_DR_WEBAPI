using System;
using TESTEGARAGENS_DR_WEBAPI.Models;

namespace TESTEGARAGENS_DR_WEBAPI.Data
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        bool SaveChanges();

        public string TotalPrizeCalc(Passagem passagem);
        Passagem[] GetAllPassagens(string cod);
        Passagem[] GetTotalPassagens(string cod);
        Passagem[] GetTotalPassagensWithTimeSpan(string cod,string startDate, string endDate);
        Passagem[] GetAllPassagensExitLess(string cod);
        Passagem[] GetPassagemById(int id,string cod);
        Garagem[] GetGaragemByCod(string cod);
        FormaPagamento[] GetFormaPagamentoByCod(string cod);
    }
}