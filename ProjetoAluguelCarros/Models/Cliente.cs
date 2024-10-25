namespace ProjetoAluguelCarros.Models
{
    public class Cliente
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }
        public bool Ativo { get; set; }

        public Cliente()
        {
            
        }
    }
}
