using Meta.TI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Meta.TI.Infra.Data.Mappings
{
    public class FeedSolicitacaoMap : IEntityTypeConfiguration<FeedSolicitacao>
    {
        public void Configure(EntityTypeBuilder<FeedSolicitacao> builder)
        {
            builder.Property(e => e.Id)
                .HasColumnName("Id");

            builder.HasOne(e => e.Hemocentro)
              .WithMany(e => e.FeedSolicitacoes)
              .HasForeignKey(e => e.IdHemocentro)
              .IsRequired();

            builder.HasOne(e => e.Usuario)
              .WithMany(e => e.FeedSolicitacoes)
              .HasForeignKey(e => e.IdUsuario)
              .IsRequired();

            builder.HasOne(e => e.TipoSanguineo)
              .WithMany(e => e.FeedSolicitacoes)
              .HasForeignKey(e => e.IdTipoSanguineo)
              .IsRequired();

            builder.Property(u => u.Descricao)
              .HasColumnType("varchar(200)")
              .HasColumnName("Descricao")
              .IsRequired();

            builder.Property(u => u.DataCriacao)
                .HasColumnType("datetime")
                .HasColumnName("DataCriacao")
                .IsRequired();

            builder.Property(u => u.DataAlteracao)
                .HasColumnType("datetime")
                .HasColumnName("DataAlteracao");
        }
    }
}
