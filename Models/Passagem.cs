using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TESTEGARAGENS_DR_WEBAPI.Models
{
    public class Passagem
    {
        public Passagem() { }
        public Passagem(int id, 
                       string garagem, 
                       string carroPlaca, 
                       string carroMarca, 
                       string carroModelo,
                       DateTime dataHoraEntrada,
                       DateTime dataHoraSaida,
                       string formaPagamento,
                       decimal precoTotal)
        {
            this.Id = id;
            this.Garagem = garagem;
            this.CarroPlaca = carroPlaca;
            this.CarroMarca = carroMarca;
            this.CarroModelo = carroModelo;
            this.DataHoraEntrada = dataHoraEntrada;
            this.DataHoraSaida = dataHoraSaida;
            this.FormaPagamento = formaPagamento;
            this.PrecoTotal = precoTotal;
        }
        public int Id { get; set; }
        public string Garagem { get; set; }
        public string CarroPlaca { get; set; }
        public string CarroMarca { get; set; }
        public string CarroModelo { get; set; }
        public DateTime DataHoraEntrada { get; set; }
        public Nullable<DateTime> DataHoraSaida { get; set; }
        public string FormaPagamento { get; set; }
        public Nullable<decimal> PrecoTotal { get; set; }

    }
}