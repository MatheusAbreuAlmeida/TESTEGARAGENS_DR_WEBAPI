using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http.Features;
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
            return _context.SaveChanges() > 0;
        }

        public decimal TotalPrizeCalc(Passagem passagem)
        {
            Decimal precoTotal = 0;

            if (passagem.DataHoraSaida != null)
            {
                TimeSpan estadia = passagem.DataHoraSaida - passagem.DataHoraEntrada;
                var garagem = this.GetGaragemByCod(passagem.Garagem).FirstOrDefault();
                var horasEstadia = estadia.TotalHours;
                var minutosEstadia = estadia.TotalHours;

                if (passagem.FormaPagamento == "MEN")
                {
                    return precoTotal = 0;
                }

                else if (horasEstadia > 2 && minutosEstadia > 30)
                {
                  _ = decimal.Parse(garagem.Preco_1aHora);
                  var demaisHoras = horasEstadia - 1;
                  precoTotal = (decimal)demaisHoras * decimal.Parse(garagem.Preco_HorasExtra);
                }

                else if (horasEstadia > 1 && minutosEstadia < 30)
                {
                  precoTotal += decimal.Parse(garagem.Preco_1aHora);
                  precoTotal += decimal.Parse(garagem.Preco_HorasExtra) / 2;
                }

                else if (horasEstadia < 1)
                {
                    precoTotal = decimal.Parse(garagem.Preco_1aHora);
                }

                return precoTotal;
            }

            return precoTotal;
        }

        public Passagem[] GetAllPassagens(string cod)
        {
            IQueryable<Passagem> query = _context.Passagens;

            query = query.AsNoTracking()
                         .Where(Passagem => Passagem.Garagem == cod)
                         .OrderBy(a => a.Id);

            return query.ToArray();
        }

         public Passagem[] GetTotalPassagens(string cod)
         {
            IQueryable<Passagem> query = _context.Passagens;

            query = query.AsNoTracking()
                         .Where(Passagem => Passagem.Garagem == cod)
                         .Where(Passagem => Passagem.DataHoraEntrada != null)
                         .Where(Passagem => Passagem.DataHoraSaida != null)
                         .OrderBy(a => a.Id);

            return query.ToArray();
         }

        public Passagem[] GetAllPassagensExitLess(string cod)
        {
            IQueryable<Passagem> query = _context.Passagens;

            query = query.AsNoTracking()
                         .Where(Passagem => Passagem.Garagem == cod)
                         .Where(Passagem => Passagem.DataHoraSaida == null)
                         .OrderBy(a => a.Id);

            return query.ToArray();
        }

        public Passagem[] GetPassagemById(int id, string cod)
        {
            IQueryable<Passagem> query = _context.Passagens;

            query = query.AsNoTracking()
                         .OrderBy(a => a.Id)
                         .Where(Passagem => Passagem.Garagem == cod)
                         .Where(Passagem => Passagem.Id == id);

            return query.ToArray();
        }

        public Garagem[] GetGaragemByCod(string cod)
        {
            IQueryable<Garagem> query = _context.Garagens;

            query = query.AsNoTracking()
                         .OrderBy(a => a.Id)
                         .Where(Garagem => Garagem.Codigo == cod);

            return query.ToArray();
        }

        public FormaPagamento[] GetFormaPagamentoByCod(string cod)
        {
            IQueryable<FormaPagamento> query = _context.FormasPagamento;

            query = query.AsNoTracking()
                         .OrderBy(a => a.Id)
                         .Where(FormaPagamento => FormaPagamento.Codigo == cod);

            return query.ToArray();
        }

        public Passagem[] GetTotalPassagensWithTimeSpan(string cod, string startDate, string endDate)
        {
            IQueryable<Passagem> query = _context.Passagens;

             var DataHoraEntrada = DateTime.Parse(startDate);
             var DataHoraSaida = DateTime.Parse(endDate);

            query = query.AsNoTracking()
                         .Where(Passagem => Passagem.Garagem == cod)
                         .Where(Passagem => Passagem.DataHoraSaida == DataHoraSaida)
                         .Where(Passagem => Passagem.DataHoraEntrada == DataHoraEntrada)
                         .OrderBy(a => a.Id);

            return query.ToArray();
        }
    }
}