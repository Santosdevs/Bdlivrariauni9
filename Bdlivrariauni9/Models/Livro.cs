namespace LivrariaAPI.Models
{
    public class Livro
    {
        public int IdLivro { get; set; }
        public string NomeLivro { get; set; } = string.Empty;  // Inicializando com valor padrão
        public decimal Preco { get; set; }
        public int QuantidadePag { get; set; }
        public string Editora { get; set; } = string.Empty;  // Inicializando com valor padrão
        public string Categoria { get; set; } = string.Empty;  // Inicializando com valor padrão
        public string Autor { get; set; } = string.Empty;  // Inicializando com valor padrão
    }
}
