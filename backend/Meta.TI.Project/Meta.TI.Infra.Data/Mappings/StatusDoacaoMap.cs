using System;
using System.Collections.Generic;
using System.Text;
using Meta.TI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Meta.TI.Infra.Data.Mappings
{
    public class StatusDoacaoMap : IEntityTypeConfiguration<StatusDoacao>
    {
        public void Configure(EntityTypeBuilder<StatusDoacao> builder)
        {
            builder.Property(s => s.Id)
               .ValueGeneratedOnAdd()
               .HasColumnName("Id");

            builder.Property(s => s.IdStatus)
                .HasColumnType("int")
                .HasColumnName("IdStatus")
                .IsRequired();

            builder.Property(s => s.Descricao)
                .HasColumnType("varchar(50)")
                .HasColumnName("Descricao")
                .IsRequired();

            builder.HasMany(q => q.ResultadoAptidao)
                .WithOne(t => t.StatusDoacao)
                .HasForeignKey(q => q.IdStatus);

            builder.HasData(
                new StatusDoacao { Id = 1, IdStatus = 1, Descricao = "Apto para doar" },
                new StatusDoacao { Id = 2, IdStatus = 2, Descricao = "Não apto para doar" }
                );
        }
    }
}
