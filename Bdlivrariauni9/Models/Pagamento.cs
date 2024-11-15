using System;

namespace LivrariaAPI.Models
{
    public class Pagamento
    {
        public int IdPagamento { get; set; }
        public string FormaPagamento { get; set; } = string.Empty;  // Inicializando com string vazia
        public int IdCompra { get; set; }

        // Foreign Key
        public Compra Compra { get; set; } = new Compra();  // Inicializando com um novo objeto Compra
    }
}
