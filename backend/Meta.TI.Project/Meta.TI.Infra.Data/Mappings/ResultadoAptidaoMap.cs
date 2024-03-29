using System;
using System.Collections.Generic;
using System.Text;
using Meta.TI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Meta.TI.Infra.Data.Mappings
{
    class ResultadoAptidaoMap : IEntityTypeConfiguration<ResultadoAptidao>
    {
        public void Configure(EntityTypeBuilder<ResultadoAptidao> builder)
        {
            builder.Property(q => q.Id)
               .ValueGeneratedOnAdd()
               .HasColumnName("Id");

            builder.Property(u => u.DataResultado)
                .HasColumnType("datetime")
                .HasColumnName("DataResultado")
                .IsRequired();

            builder.Property(u => u.DataProximaDoacao)
                .HasColumnType("datetime")
                .HasColumnName("DataProximaDoacao")
                .IsRequired();

            builder.HasMany(q => q.RespostasAptidao)
                .WithOne(t => t.ResultadoAptidao)
                .HasForeignKey(q => q.Id);

            builder.Property(q => q.DiasAfastados)
                .HasColumnType("int")
                .HasColumnName("DiasAfastados")
                .IsRequired();

            builder.HasOne(q => q.StatusDoacao)
                .WithMany(t => t.ResultadoAptidao)
                .HasForeignKey(q => q.IdStatus);
        }
    }
}
