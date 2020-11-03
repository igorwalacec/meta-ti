using System;
using System.Collections.Generic;
using System.Text;
using Meta.TI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Meta.TI.Infra.Data.Mappings
{
    public class NotificacoesMap : IEntityTypeConfiguration<Notificacoes>
    {
        public void Configure(EntityTypeBuilder<Notificacoes> builder)
        {
            builder.Property(e => e.Id)
                .HasColumnName("Id")
                .IsRequired();

            builder.HasOne(e => e.Usuario)
                .WithMany(e => e.Notificacoes)
                .HasForeignKey(e => e.IdUsuario)
                .IsRequired();

            builder.Property(u => u.Descricao)
             .HasColumnType("varchar(200)")
             .HasColumnName("Descricao")
             .IsRequired();

            builder.Property(u => u.Titulo)
             .HasColumnType("varchar(50)")
             .HasColumnName("Titulo")
             .IsRequired();

            builder.Property(u => u.DataCriacao)
                .HasColumnType("datetime")
                .HasColumnName("DataCriacao")
                .IsRequired();
        }
    }
}
