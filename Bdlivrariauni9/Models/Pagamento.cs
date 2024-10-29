using System;

namespace LivrariaAPI.Models
{
    public class Pagamento
    {
        public int IdPagamento { get; set; }
        public string FormaPagamento { get; set; }
        public int IdCompra { get; set; }

        // Foreign Key
        public Compra Compra { get; set; }
    }
}

