using Microsoft.EntityFrameworkCore;
using LivrariaAPI.Models;

namespace LivrariaAPI.Data
{
    public class LivrariaContext : DbContext
    {
        public LivrariaContext(DbContextOptions<LivrariaContext> options) : base(options)
        {
        }

        // Definir as tabelas do banco de dados
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Vendedor> Vendedores { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<CompraDoLivro> CompraDoLivros { get; set; }
        public DbSet<Pagamento> Pagamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurações adicionais (se necessário)
            modelBuilder.Entity<Livro>().ToTable("Livro");
            modelBuilder.Entity<Cliente>().ToTable("Cliente");
            modelBuilder.Entity<Vendedor>().ToTable("Vendedor");
            modelBuilder.Entity<Compra>().ToTable("Compra");
            modelBuilder.Entity<CompraDoLivro>().ToTable("CompraDoLivro");
            modelBuilder.Entity<Pagamento>().ToTable("Pagamento");

            // Configurar a chave primária para a tabela CompraDoLivro (exemplo)
            modelBuilder.Entity<CompraDoLivro>().HasKey(cdl => new { cdl.IdCompra, cdl.IdLivro });

            base.OnModelCreating(modelBuilder);
        }
    }
}