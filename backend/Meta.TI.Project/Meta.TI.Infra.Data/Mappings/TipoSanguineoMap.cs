using Meta.TI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Meta.TI.Infra.Data.Mappings
{
    public class TipoSanguineoMap : IEntityTypeConfiguration<TipoSanguineo>
    {
        public void Configure(EntityTypeBuilder<TipoSanguineo> builder)
        {
            builder.Property(t => t.Id)
               .ValueGeneratedOnAdd()
               .HasColumnName("Id");

            builder.Property(t => t.Nome)
                .HasColumnType("varchar(50)")
                .HasColumnName("Nome")
                .IsRequired();

            builder.HasData(
                new TipoSanguineo
                {
                    Id = 1,
                    Nome = "A+"
                },
                new TipoSanguineo
                {
                    Id = 2,
                    Nome = "A-"
                },
                new TipoSanguineo
                {
                    Id = 3,
                    Nome = "AB+"
                },
                new TipoSanguineo
                {
                    Id = 4,
                    Nome = "AB-"
                },
                new TipoSanguineo
                {
                    Id = 5,
                    Nome = "B+"
                },
                new TipoSanguineo
                {
                    Id = 6,
                    Nome = "B-"
                },
                new TipoSanguineo
                {
                    Id = 7,
                    Nome = "O+"
                },
                new TipoSanguineo
                {
                    Id = 8,
                    Nome = "O-"
                }
                );
        }
    }
}
