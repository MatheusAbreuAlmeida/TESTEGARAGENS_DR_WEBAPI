namespace TESTEGARAGENS_DR_WEBAPI.Models
{
    public class FormaPagamento
    {
        public FormaPagamento() { }
        public FormaPagamento(int id, 
                       string codigo, 
                       string descricao)

        {
            this.Id = id;
            this.Codigo = codigo;
            this.Descricao = descricao;
        }
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
    }
}