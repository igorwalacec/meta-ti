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
            builder.Property(e => e.UF)
                .HasColumnType("varchar(2)")
                .HasColumnName("UF")
                .IsRequired();

            builder.HasData(
                new Estado { Id = 1, Nome = "Acre", UF = "AC" },
                new Estado { Id = 2, Nome = "Alagoas", UF = "AL" },
                new Estado { Id = 3, Nome = "Amazonas", UF = "AM" },
                new Estado { Id = 4, Nome = "Amapá", UF = "AP" },
                new Estado { Id = 5, Nome = "Bahia", UF = "BA" },
                new Estado { Id = 6, Nome = "Ceará", UF = "CE" },
                new Estado { Id = 7, Nome = "Distrito Federal", UF = "DF" },
                new Estado { Id = 8, Nome = "Espírito Santo", UF = "ES" },
                new Estado { Id = 9, Nome = "Goiás", UF = "GO" },
                new Estado { Id = 10, Nome = "Maranhão", UF = "MA" },
                new Estado { Id = 11, Nome = "Minas Gerais", UF = "MG" },
                new Estado { Id = 12, Nome = "Mato Grosso do Sul", UF = "MS" },
                new Estado { Id = 13, Nome = "Mato Grosso", UF = "MT" },
                new Estado { Id = 14, Nome = "Pará", UF = "PA" },
                new Estado { Id = 15, Nome = "Paraíba", UF = "PB" },
                new Estado { Id = 16, Nome = "Pernambuco", UF = "PE" },
                new Estado { Id = 17, Nome = "Piauí", UF = "PI" },
                new Estado { Id = 18, Nome = "Paraná", UF = "PR" },
                new Estado { Id = 19, Nome = "Rio de Janeiro", UF = "RJ" },
                new Estado { Id = 20, Nome = "Rio Grande do Norte", UF = "RN" },
                new Estado { Id = 21, Nome = "Rondônia", UF = "RO" },
                new Estado { Id = 22, Nome = "Roraima", UF = "RR" },
                new Estado { Id = 23, Nome = "Rio Grande do Sul", UF = "RS" },
                new Estado { Id = 24, Nome = "Santa Catarina", UF = "SC" },
                new Estado { Id = 25, Nome = "Sergipe", UF = "SE" },
                new Estado { Id = 26, Nome = "São Paulo", UF = "SP" },
                new Estado { Id = 27, Nome = "Tocantins", UF = "TO" }
            );

            builder.HasMany(e => e.Cidades).WithOne(e => e.Estado).IsRequired();
        }
    }
}
