using GerenciamentoImobiliario.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoImobiliario.Data.Infra.DataContext
{
    public class GerenciamentoImobiliarioDataContext : DbContext
    {
        public DbSet<Imovel> Imoveis { get; set; }
        public DbSet<Proprietario> Proprietarios { get; set; }
        public DbSet<Locacao> Locacoes { get; set; }
        public DbSet<Corretor> Corretores { get; set; }
        public DbSet<Inquilino> Inquilinos { get; set; }
        public GerenciamentoImobiliarioDataContext(DbContextOptions<GerenciamentoImobiliarioDataContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //    optionsBuilder.UseSqlServer("connectionstring");
                optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=local_database;User Id=postgres;Password=local_password;");
            }
        }
    }
}
