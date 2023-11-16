using System;

namespace TESTEGARAGENS_DR_WEBAPI.Models
{
    public class Garagem
    {        
        public Garagem() { }
        public Garagem(int id, 
                       string codigo, 
                       string nome, 
                       string preco_1aHora, 
                       string preco_HorasExtra,
                       string preco_Mensalista)

        {
            this.Id = id;
            this.Codigo = codigo;
            this.Nome = nome;
            this.Preco_1aHora = preco_1aHora;
            this.Preco_HorasExtra = preco_HorasExtra;
            this.Preco_Mensalista = preco_Mensalista;
        }
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string Preco_1aHora { get; set; }
        public string Preco_HorasExtra { get; set; }
        public string Preco_Mensalista { get; set; }

        public static implicit operator Garagem(string v)
        {
            throw new NotImplementedException();
        }
    }
}