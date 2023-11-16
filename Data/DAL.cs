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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<FormaPagamento>()
                .HasData(new List<FormaPagamento>(){
                    new FormaPagamento(1, "DIN", "Dinheiro"),
                    new FormaPagamento(2, "MEN", "Mensalista"),
                    new FormaPagamento(3, "PIX", "Pix"),
                    new FormaPagamento(4, "TAG", "Tag"),
                    new FormaPagamento(5, "CDE","Cartão de Débito"),
                    new FormaPagamento(6, "CCR","Cartão de Crédito"),
                });
            
            builder.Entity<Garagem>()
                .HasData(new List<Garagem>{
                    new Garagem(1, "EVO01", "Estamplaza Vila Olimpia","40","10","550"),
                    new Garagem(2, "PLJK01", "Plaza JK","35","12","380"),
                    new Garagem(3, "SZJK01", "Spazio JK","30","15","350"),
                    new Garagem(4, "CSLU01", "Condominio São Luiz","50","12","550"),
                    new Garagem(5, "COTO01", "Corporate Tower Itaim","30","12","360")
                });
            
            builder.Entity<Passagem>()
                .HasData(new List<Passagem>(){
                    new Passagem(1, "EVO01", "ABC-0O12", "Honda","FIT","04/09/2023 13:30","04/09/2023 15:15","PIX",null),
                    new Passagem(2, "EVO01", "DKO-3927", "Toyota","Yaris","05/09/2023 08:40","05/09/2023 09:55","CCR",null),
                    new Passagem(3, "EVO01", "SPE-9F42", "Fiat","Argo","04/09/2023 10:15","04/09/2023 11:20","TAG",null),
                });
        }
    }
}