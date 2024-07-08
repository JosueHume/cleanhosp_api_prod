using CleanHospAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CleanHosp.Context
{
    public class CleanHospContext : DbContext
    {
        public CleanHospContext(DbContextOptions<CleanHospContext> options)
            : base(options)
        {
        }

        public DbSet<Ala> Alas { get; set; }
        public DbSet<Local> Locais { get; set; }
        public DbSet<Limpeza> Limpezas { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Equipamento> Equipamentos { get; set; }
        public DbSet<ProdutosUtilizados> ProdutosUtilizados { get; set; }
        public DbSet<EquipamentosUtilizados> EquipamentosUtilizados { get; set; }
        public DbSet<LimpezaAndamento> LimpezasAndamento { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Equipamento>()
                .Property(e => e.DataAquisicao)
                .HasColumnType("timestamp with time zone");

            modelBuilder.Entity<LimpezaAndamento>()
                .Property(l => l.DataInicio)
                .HasColumnType("timestamp with time zone");

            modelBuilder.Entity<LimpezaAndamento>()
                .Property(l => l.DataFim)
                .HasColumnType("timestamp with time zone");
        }
    }
}
