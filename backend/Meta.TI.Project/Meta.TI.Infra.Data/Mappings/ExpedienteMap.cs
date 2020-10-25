using Meta.TI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Meta.TI.Infra.Data.Mappings
{
    public class ExpedienteMap : IEntityTypeConfiguration<Expediente>
    {
        public void Configure(EntityTypeBuilder<Expediente> builder)
        {
            builder.Property(e => e.Id)
                .HasColumnName("Id");

            builder.HasOne(e => e.DiaSemana)
                .WithMany(e => e.Expedientes)
                .HasForeignKey(e => e.IdDiaSemana)
                .IsRequired();

            builder.HasOne(e => e.Hemocentro)
                .WithMany(e => e.Expedientes)
                .HasForeignKey(e => e.IdHemocentro)
                .IsRequired();

            builder.Property(u => u.Inicio)
               .HasColumnType("datetime")
               .HasColumnName("Inicio")
               .IsRequired();

            builder.Property(u => u.Fim)
               .HasColumnType("datetime")
               .HasColumnName("Fim")
               .IsRequired();
        }
    }
}
