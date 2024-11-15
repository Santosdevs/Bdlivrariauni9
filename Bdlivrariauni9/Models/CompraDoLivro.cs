namespace LivrariaAPI.Models
{
    public class CompraDoLivro
    {
        public int IdCompra { get; set; }
        public int IdLivro { get; set; }

        public string NomeLivro { get; set; } = string.Empty;
        public string FormaPagamento { get; set; } = string.Empty;
        public DateTime DataEntrega { get; set; }

        // Foreign Keys
        public Livro Livro { get; set; } = new Livro();
        public Compra Compra { get; set; } = new Compra();
    }
}
