using System.Linq;
using Meta.TI.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Meta.TI.Infra.Data.Context
{
    public class MetaTiContext : DbContext
    {
        public MetaTiContext(DbContextOptions options) : base(options){}
        public DbSet<Estado> Estado { get; set; }
        public DbSet<Cidade> Cidade { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<TipoSanguineo> TipoSanguineo { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<DiaSemana> DiaSemana { get; set; }
        public DbSet<Hemocentro> Hemocentro { get; set; }
        public DbSet<EstoqueSanguineo> EstoqueSanguineo { get; set; }
        public DbSet<Expediente> Expediente { get; set; }
        public DbSet<Telefone> Telefone { get; set; }
        public DbSet<Funcionario> Funcionario { get; set; }
        public DbSet<Informativo> Informativo { get; set; }
        public DbSet<FeedSolicitacao> FeedSolicitacao { get; set; }
        public DbSet<Campanha> Campanha { get; set; }
        public DbSet<Agendamento> Agendamento { get; set; }
        public DbSet<TipoSexo> TipoSexo { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                    .Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MetaTiContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }
    }
}
