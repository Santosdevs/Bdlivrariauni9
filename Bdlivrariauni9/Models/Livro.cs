namespace LivrariaAPI.Models
{
    public class Livro
    {
        public int IdLivro { get; set; }
        public string NomeLivro { get; set; }
        public decimal Preco { get; set; }
        public int QuantidadePag { get; set; }
        public string Editora { get; set; }
        public string Categoria { get; set; }
        public string Autor { get; set; }
    }
}
