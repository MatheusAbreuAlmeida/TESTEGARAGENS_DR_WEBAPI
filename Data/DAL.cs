using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TESTEGARAGENS_DR_WEBAPI.Models;

namespace TESTEGARAGENS_DR_WEBAPI.Data
{
    public class DAL : DbContext
    {
        public DAL(DbContextOptions<DAL> options) : base(options) {}
        public DbSet<Passagem> Passagens { get; set; }
        public DbSet<FormaPagamento> FormasPagamento { get; set; }
        public DbSet<Garagem> Garagens { get; set; }

    }
}