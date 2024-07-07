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
            modelBuilder.Entity<LimpezaAndamento>()
                .HasOne(la => la.Local)
                .WithMany()  
                .HasForeignKey(la => la.LocalId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<LimpezaAndamento>()
                .HasOne(la => la.Pessoa)
                .WithMany() 
                .HasForeignKey(la => la.PessoaId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<LimpezaAndamento>()
                .HasOne(la => la.Limpeza)
                .WithMany()  
                .HasForeignKey(la => la.LimpezaId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<LimpezaAndamento>()
                .HasMany(la => la.ProdutosUtilizados)
                .WithOne()
                .HasForeignKey(pu => pu.LimpezaAndamentoId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<LimpezaAndamento>()
                .HasMany(la => la.EquipamentosUtilizados)
                .WithOne()
                .HasForeignKey(eu => eu.LimpezaAndamentoId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Equipamento>()
                .Property(e => e.DataAquisicao)
                .HasColumnType("timestamp with time zone");
        }
    }
}
