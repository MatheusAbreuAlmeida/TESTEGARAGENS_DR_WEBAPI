using System;

namespace TESTEGARAGENS_DR_WEBAPI.Dtos
{
    /// <summary>
    /// Esse é o DTO da garagem do veiculo pela garagem
    /// </summary>
    public class GaragemDTO
    {
        /// <summary>
        /// Id da garagem
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Codigo da garagem
        /// </summary>
        public string Codigo { get; set; }
        /// <summary>
        /// Nome da garagem
        /// </summary>
        public string Nome { get; set; }
        /// <summary>
        /// Preço da primeira hora
        /// </summary>
        public string Preco_1aHora { get; set; }
        /// <summary>
        /// Preço das demais horas 
        /// </summary>
        public string Preco_HorasExtra { get; set; }
        /// <summary>
        /// Preço a ser pago pelo mensalista
        /// </summary>
        public string Preco_Mensalista { get; set; }

        public string QuantidadeCarrosTotal { get; set; }

        public string ValorPagamentos { get; set; }
    }
}