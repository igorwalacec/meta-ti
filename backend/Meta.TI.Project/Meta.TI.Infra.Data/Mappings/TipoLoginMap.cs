using Meta.TI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Meta.TI.Infra.Data.Mappings
{
    public class TipoLoginMap : IEntityTypeConfiguration<TipoLogin>
    {
        public void Configure(EntityTypeBuilder<TipoLogin> builder)
        {
            builder.Property(t => t.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("Id");

            builder.Property(t => t.Nome)
                .HasColumnType("varchar(100)")
                .HasColumnName("Nome")
                .IsRequired();

            builder.Property(t => t.SenhaObrigatoria)
                .HasColumnType("bit")
                .HasColumnName("SenhaObrigatoria")
                .IsRequired();        
        }
    }
}
