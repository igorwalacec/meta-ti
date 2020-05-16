using Meta.TI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Meta.TI.Infra.Data.Mappings
{
    public class EstoqueSanguineoMap : IEntityTypeConfiguration<EstoqueSanguineo>
    {
        public void Configure(EntityTypeBuilder<EstoqueSanguineo> builder)
        {
            builder.Property(e => e.Id)
                .HasColumnName("Id");

            builder.HasOne(e => e.TipoSanguineo)
                .WithMany(e => e.EstoqueSanguineo)
                .HasForeignKey(e => e.IdTipoSanguineo)
                .IsRequired();

            builder.HasOne(e => e.Hemocentro)
                .WithMany(e => e.EstoqueSanguineo)
                .HasForeignKey(e => e.IdHemocentro)
                .IsRequired();
        }
    }
}
