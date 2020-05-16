using Meta.TI.Domain.Models;
using Meta.TI.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Meta.TI.Infra.Data.Context
{
    public class MetaTiContext : DbContext
    {
        public MetaTiContext(DbContextOptions options) : base(options){}
        public DbSet<Estado> Estado { get; set; }
        public DbSet<Cidade> Cidade { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<TipoLogin> TipoLogin { get; set; }
        public DbSet<TipoSanguineo> TipoSanguineo { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<DiaSemana> DiaSemana { get; set; }
        public DbSet<Hemocentro> Hemocentro { get; set; }
        public DbSet<EstoqueSanguineo> EstoqueSanguineo { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EstadoMap());
            modelBuilder.ApplyConfiguration(new CidadeMap());
            modelBuilder.ApplyConfiguration(new EnderecoMap());
            modelBuilder.ApplyConfiguration(new TipoLoginMap());
            modelBuilder.ApplyConfiguration(new TipoSanguineoMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new DiaSemanaMap());
            modelBuilder.ApplyConfiguration(new HemocentroMap());
            modelBuilder.ApplyConfiguration(new EstoqueSanguineoMap());


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
