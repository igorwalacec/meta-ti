using Meta.TI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Meta.TI.Infra.Data.Mappings
{
    public class DiaSemanaMap : IEntityTypeConfiguration<DiaSemana>
    {
        public void Configure(EntityTypeBuilder<DiaSemana> builder)
        {
            builder.Property(d => d.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("Id");

            builder.Property(d => d.Nome)
                .HasColumnType("varchar(100)")
                .HasColumnName("Nome")
                .IsRequired();

            builder.HasData(
                new DiaSemana
                {
                    Id = 1,
                    Nome = "Domingo"
                },
                new DiaSemana
                {
                    Id = 2,
                    Nome = "Segunda-feira"
                },
                new DiaSemana
                {
                    Id = 3,
                    Nome = "Terça-feira"
                },
                new DiaSemana
                {
                    Id = 4,
                    Nome = "Quarta-feira"
                },
                new DiaSemana
                {
                    Id = 5,
                    Nome = "Quinta-feira"
                },
                new DiaSemana
                {
                    Id = 6,
                    Nome = "Sexta-feira"
                },
                new DiaSemana
                {
                    Id = 7,
                    Nome = "Sábado"
                }
            );

        }
    }
}
