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
                       string dataHoraEntrada,
                       string dataHoraSaida,
                       string formaPagamento,
                       string precoTotal)
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
        public string DataHoraEntrada { get; set; }
        public string DataHoraSaida { get; set; }
        public string FormaPagamento { get; set; }
        public string PrecoTotal { get; set; }
    }
}