using System;

namespace LivrariaAPI.Models
{
    public class CompraDoLivro
    {
        public int IdCompra { get; set; }
        public string NomeLivro { get; set; }
        public string FormaPagamento { get; set; }
        public DateTime DataEntrega { get; set; }

        // Foreign Keys
        public Livro Livro { get; set; }
        public Compra Compra { get; set; }
    }
}
