using ESG.InclusaoDiversidade.Models;
using Microsoft.EntityFrameworkCore;

namespace ESG.InclusaoDiversidade.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<FuncionarioModel> Funcionarios { get; set; }
        public DbSet<EquipeModel> Equipes { get; set; }
        public DbSet<BancoTalentosModel> Candidatos { get; set; }
        public DbSet<TreinamentoModel> Treinamentos { get; set; }
        public DbSet<ParticipacaoTreinamentoModel> Participacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // FUNCIONÁRIO
            modelBuilder.Entity<FuncionarioModel>(entity =>
            {
                entity.HasKey(f => f.FuncionarioID);

                entity.Property(f => f.Nome).IsRequired().HasMaxLength(100);
                entity.Property(f => f.Genero).IsRequired().HasMaxLength(50);
                entity.Property(f => f.Etnia).IsRequired().HasMaxLength(50);
                entity.Property(f => f.Deficiencia).HasMaxLength(100);
                entity.Property(f => f.Cargo).IsRequired().HasMaxLength(100);
                entity.Property(f => f.Salario).HasColumnType("decimal(18,2)");

                entity.HasOne(f => f.Equipe)
                      .WithMany(e => e.Funcionarios)
                      .HasForeignKey(f => f.EquipeID)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // EQUIPE
            modelBuilder.Entity<EquipeModel>(entity =>
            {
                entity.HasKey(e => e.EquipeID);
                entity.Property(e => e.NomeEquipe).IsRequired().HasMaxLength(100);
            });

            // BANCO DE TALENTOS
            modelBuilder.Entity<BancoTalentosModel>(entity =>
            {
                entity.HasKey(c => c.CandidatoID);
                entity.Property(c => c.Nome).IsRequired().HasMaxLength(100);
                entity.Property(c => c.Genero).IsRequired().HasMaxLength(50);
                entity.Property(c => c.Etnia).IsRequired().HasMaxLength(50);
                entity.Property(c => c.Deficiencia).HasMaxLength(100);
                entity.Property(c => c.CargoPretendido).IsRequired().HasMaxLength(100);
                entity.Property(c => c.Status).IsRequired().HasMaxLength(50);
            });

            // TREINAMENTO
            modelBuilder.Entity<TreinamentoModel>(entity =>
            {
                entity.HasKey(t => t.TreinamentoID);
                entity.Property(t => t.Titulo).IsRequired().HasMaxLength(150);
                entity.Property(t => t.Descricao).HasMaxLength(500);
                entity.Property(t => t.Tipo).IsRequired().HasMaxLength(100);
            });

            // PARTICIPAÇÃO EM TREINAMENTO
            modelBuilder.Entity<ParticipacaoTreinamentoModel>(entity =>
            {
                entity.HasKey(p => p.ParticipacaoID);

                entity.HasOne(p => p.Funcionario)
                      .WithMany(f => f.Participacoes)
                      .HasForeignKey(p => p.FuncionarioID)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(p => p.Treinamento)
                      .WithMany(t => t.Participacoes)
                      .HasForeignKey(p => p.TreinamentoID)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.Property(p => p.DataParticipacao).IsRequired();
                entity.Property(p => p.Estrelas).IsRequired();
            });
        }
    }
}





