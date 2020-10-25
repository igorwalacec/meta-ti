using System;
using System.Collections.Generic;
using System.Text;
using Meta.TI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Meta.TI.Infra.Data.Mappings
{
    public class RespostasAptidaoMap : IEntityTypeConfiguration<RespostasAptidao>
    {
        public void Configure(EntityTypeBuilder<RespostasAptidao> builder)
        {
            builder.Property(q => q.Id)
               .ValueGeneratedOnAdd()
               .HasColumnName("Id");

            builder.Property(q => q.Resposta)
                .HasColumnType("bit")
                .HasColumnName("Resposta")
                .IsRequired();

            builder.HasOne(q => q.QuestoesAptidao)
                .WithMany(t => t.RespostasAptidao)
                .HasForeignKey(q => q.QuestoesAptidao_Id);

            builder.HasOne(q => q.ResultadoAptidao)
                .WithMany(t => t.RespostasAptidao)
                .HasForeignKey(q => q.ResultadoAptidao_Id);       
        }
    }
}
