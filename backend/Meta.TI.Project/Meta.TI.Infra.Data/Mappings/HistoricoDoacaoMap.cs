using System;
using System.Collections.Generic;
using System.Text;
using Meta.TI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Meta.TI.Infra.Data.Mappings
{
    public class HistoricoDoacaoMap : IEntityTypeConfiguration<HistoricoDoacao>
    {
        public void Configure(EntityTypeBuilder<HistoricoDoacao> builder)
        {
            builder.Property(h => h.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("Id");

            builder.Property(h => h.IdUsuario)
               .HasColumnName("IdUsuario")
               .IsRequired();

            builder.Property(h => h.DataCadastro)
                .HasColumnType("datetime")
                .HasColumnName("DataCadastro")
                .IsRequired();

            builder.Property(h => h.IdHemocentro)
               .HasColumnName("IdHemocentro")
               .IsRequired();

            builder.HasOne(h => h.Hemocentro)
                .WithMany(t => t.HistoricoDoacao)
                .HasForeignKey(h => h.IdHemocentro);
        }
    }
}
