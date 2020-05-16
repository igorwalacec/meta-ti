using Meta.TI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Meta.TI.Infra.Data.Mappings
{
    public class EstadoMap : IEntityTypeConfiguration<Estado>
    {
        public void Configure(EntityTypeBuilder<Estado> builder)
        {
            builder.Property(e => e.Id)                
                .ValueGeneratedOnAdd()
                .HasColumnName("Id");

            builder.Property(e => e.Nome)
                .HasColumnType("varchar(255)")
                .HasColumnName("Nome")
                .IsRequired();

            builder.HasMany(e => e.Cidades).WithOne(e => e.Estado).IsRequired();
        }
    }
}
