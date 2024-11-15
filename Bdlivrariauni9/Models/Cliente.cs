namespace LivrariaAPI.Models
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string Nome { get; set; } = string.Empty;  // Inicializando com valor padrão
        public string Email { get; set; } = string.Empty;  // Inicializando com valor padrão
        public string Endereco { get; set; } = string.Empty;  // Inicializando com valor padrão
        public int Idade { get; set; }
    }
}
