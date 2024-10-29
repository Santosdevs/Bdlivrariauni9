using System;

namespace LivrariaAPI.Models
{
    public class Compra
    {
        public int IdCompra { get; set; }
        public string NomeCliente { get; set; }
        public string NomeLivro { get; set; }
        public DateTime DataCompra { get; set; }
        public decimal Valor { get; set; }
        public string NomeVendedor { get; set; }

        // Foreign Keys
        public Vendedor Vendedor { get; set; }
        public Livro Livro { get; set; }
        public Cliente Cliente { get; set; }
    }
}
