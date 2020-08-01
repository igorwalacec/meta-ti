using Meta.TI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Meta.TI.Infra.Data.Mappings
{
    public class TipoSexoMap : IEntityTypeConfiguration<TipoSexo>
    {
        public void Configure(EntityTypeBuilder<TipoSexo> builder)
        {
            builder.Property(t => t.Id)
               .ValueGeneratedOnAdd()
               .HasColumnName("Id");

            builder.Property(t => t.Descricao)
                .HasColumnType("varchar(50)")
                .HasColumnName("Descricao")
                .IsRequired();

            builder.HasData(
                new TipoSexo
                {
                    Id = 1,
                    Descricao = "Masculino"
                },
                new TipoSexo
                {
                    Id = 2,
                    Descricao = "Feminino"
                },
                new TipoSexo
                {
                    Id = 3,
                    Descricao = "Outros"
                }
                );
        }
    }
}
