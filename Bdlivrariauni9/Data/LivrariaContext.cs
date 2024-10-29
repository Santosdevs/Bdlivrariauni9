using Microsoft.EntityFrameworkCore;
using LivrariaAPI.Models;

namespace LivrariaAPI.Data
{
    public class LivrariaContext : DbContext
    {
        public LivrariaContext(DbContextOptions<LivrariaContext> options) : base(options)
        {
        }

        public DbSet<Livro> Livros { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Vendedor> Vendedores { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<CompraDoLivro> CompraDoLivros { get; set; }
        public DbSet<Pagamento> Pagamentos { get; set; }
    }
}

