using System;

namespace TESTEGARAGENS_DR_WEBAPI.Dtos
{
    public class PassagemDTO
  {
        public int Id { get; set; }
        public string Garagem { get; set; }
        public string CarroPlaca { get; set; }
        public string DataHoraEntrada { get; set; }
        public string DataHoraSaida { get; set; }
        public string FormaPagamento { get; set; }
        public string PrecoTotal { get; set; }
        public TimeSpan Estadia { get; set; }
    }
}