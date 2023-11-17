using System;

namespace TESTEGARAGENS_DR_WEBAPI.Dtos
{
    /// <summary>
    /// Esse é o DTO da passagem do veiculo pela garagem
    /// </summary>
    public class PassagemDTO
  {
        /// <summary>
        /// Id da passagem
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Garagem que foi registrado a passagem
        /// </summary>
        public string Garagem { get; set; }
        /// <summary>
        /// Placa do veiculo
        /// </summary>
        public string CarroPlaca { get; set; }
        /// <summary>
        /// Data de entrada do carro na garagem
        /// </summary>
        public string DataHoraEntrada { get; set; }
        /// <summary>
        /// Data de saida do carro na garagem
        /// </summary>
        public string DataHoraSaida { get; set; }
        /// <summary>
        /// Forma de pagamento registrado 
        /// </summary>
        public string FormaPagamento { get; set; }
        /// <summary>
        /// Preço a ser pago pela estadia do veiculo 
        /// </summary>
        public string PrecoTotal { get; set; }
        /// <summary>
        /// Tempo de estadia calculado entre a entrada e saida do veiculo
        /// </summary>
        public TimeSpan Estadia { get; set; }
        
    }
}