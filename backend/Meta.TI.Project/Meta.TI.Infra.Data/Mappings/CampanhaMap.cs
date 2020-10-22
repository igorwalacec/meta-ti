using System;
using System.Collections.Generic;
using System.Text;
using Meta.TI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Meta.TI.Infra.Data.Mappings
{
    public class CampanhaMap : IEntityTypeConfiguration<Campanha>
    {
        public void Configure(EntityTypeBuilder<Campanha> builder)
        {
            builder.Property(e => e.Id)
                .HasColumnName("Id");

            builder.HasOne(e => e.Hemocentro)
              .WithMany(e => e.Campanhas)
              .HasForeignKey(e => e.IdHemocentro)
              .IsRequired();

            builder.Property(u => u.Titulo)
             .HasColumnType("varchar(50)")
             .HasColumnName("Titulo")
             .IsRequired();

            builder.Property(u => u.Descricao)
             .HasColumnType("varchar(200)")
             .HasColumnName("Descricao")
             .IsRequired();

            builder.Property(u => u.DataCriacao)
                .HasColumnType("datetime")
                .HasColumnName("DataCriacao")
                .IsRequired();


            builder.Property(u => u.DataAlteracao)
                .HasColumnType("datetime")
                .HasColumnName("DataAlteracao");
        }
    }
}
