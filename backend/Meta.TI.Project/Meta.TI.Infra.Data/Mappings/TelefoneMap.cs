using Meta.TI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Meta.TI.Infra.Data.Mappings
{
    public class TelefoneMap : IEntityTypeConfiguration<Telefone>
    {
        public void Configure(EntityTypeBuilder<Telefone> builder)
        {
            builder.Property(t => t.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("Id");

            builder.Property(t => t.Numero)
                .HasColumnName("Numero")
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.HasOne(t => t.Hemocentro)
                .WithMany(t => t.Telefones)
                .HasForeignKey(t => t.IdHemocentro);
        }
    }
}
