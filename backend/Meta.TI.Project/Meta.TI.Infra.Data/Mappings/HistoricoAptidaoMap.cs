using System;
using System.Collections.Generic;
using System.Text;
using Meta.TI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Meta.TI.Infra.Data.Mappings
{
    class HistoricoAptidaoMap : IEntityTypeConfiguration<HistoricoAptidao>
    {
        public void Configure(EntityTypeBuilder<HistoricoAptidao> builder)
        {
            builder.Property(q => q.Id)
               .ValueGeneratedOnAdd()
               .HasColumnName("Id");

            builder.HasOne(q => q.ResultadoAptidao)
                .WithMany(t => t.HistoricoAptidao)
                .HasForeignKey(q => q.ResultadoAptidao_Id);

            builder.HasOne(q => q.Usuario)
                .WithMany(t => t.HistoricoAptidao)
                .HasForeignKey(q => q.Usuario_Id);
        }
    }
}
