using System;
using System.Collections.Generic;
using System.Text;
using Meta.TI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Meta.TI.Infra.Data.Mappings
{
    public class AgendamentoMap : IEntityTypeConfiguration<Agendamento>
    {
        public void Configure(EntityTypeBuilder<Agendamento> builder)
        {
            builder.Property(e => e.Id)
                .HasColumnName("Id")
                .IsRequired();

            builder.HasOne(e => e.Usuario)
                .WithMany(e => e.Agendamentos)
                .HasForeignKey(e => e.IdUsuario)
                .IsRequired();

            builder.HasOne(e => e.Hemocentro)
                .WithMany(e => e.Agendamentos)
                .HasForeignKey(e => e.IdHemocentro)
                .IsRequired();

            builder.Property(u => u.DataAgendamento)
                .HasColumnType("datetime")
                .HasColumnName("DataAgendamento")
                .IsRequired();
        }
    }
}
