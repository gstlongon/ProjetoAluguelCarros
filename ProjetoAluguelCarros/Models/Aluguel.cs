namespace ProjetoAluguelCarros.Models
{
    public class Aluguel
    {
        public string Id { get; set; }
        public Cliente Cliente { get; set; }
        public Carro Carro { get; set; }
        public DateTime Data { get; set; }

        public Aluguel(Cliente cliente, Carro carro, DateTime data)
        {
            Cliente = cliente;
            Carro = carro;
            Data = data;
        }

        private Aluguel() { }
    }
}
