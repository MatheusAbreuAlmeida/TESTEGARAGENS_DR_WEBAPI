using System;

namespace TESTEGARAGENS_DR_WEBAPI.Dtos
{
    /// <summary>
    /// Esse é o DTO da Forma de pagamento
    /// </summary>
    public class FormaPagamentoDTO
    {
        /// <summary>
        /// Id da forma de pagamento
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Codigo da forma de pagamento
        /// </summary>
        public string Codigo { get; set; }
        /// <summary>
        /// Descrição da forma de pagamento
        /// </summary>
        public string Descricao { get; set; }

    }
}