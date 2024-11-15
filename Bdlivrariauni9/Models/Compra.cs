using System;

namespace LivrariaAPI.Models
{
    public class Compra
    {
        public int IdCompra { get; set; }
        public string NomeCliente { get; set; } = string.Empty;  // Inicializando com valor padrão
        public string NomeLivro { get; set; } = string.Empty;  // Inicializando com valor padrão
        public DateTime DataCompra { get; set; }
        public decimal Valor { get; set; }
        public string NomeVendedor { get; set; } = string.Empty;  // Inicializando com valor padrão

        // Foreign Keys (Inicializando com objetos vazios)
        public Vendedor Vendedor { get; set; } = new Vendedor();  // Inicializando com objeto vazio
        public Livro Livro { get; set; } = new Livro();  // Inicializando com objeto vazio
        public Cliente Cliente { get; set; } = new Cliente();  // Inicializando com objeto vazio
    }
}
