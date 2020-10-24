using System;
using System.Collections.Generic;
using System.Text;
using Meta.TI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Meta.TI.Infra.Data.Mappings
{
    public class OrientacaoDoacaoMap : IEntityTypeConfiguration<OrientacaoDoacao>
    {
        public void Configure(EntityTypeBuilder<OrientacaoDoacao> builder)
        {
            builder.Property(q => q.Id)
              .ValueGeneratedOnAdd()
              .HasColumnName("Id");

            builder.Property(q => q.Orientacao)
                .HasColumnType("varchar(1500)")
                .HasColumnName("Orientacao")
                .IsRequired();

            builder.HasData(
                new OrientacaoDoacao { Id = 1, Orientacao = "Estar em boas condições de saúde." },
                new OrientacaoDoacao { Id = 2, Orientacao = "Ter entre 16 e 69 anos, desde que a primeira doação tenha sido feita até 60 anos (menores de 18 anos)." },
                new OrientacaoDoacao { Id = 3, Orientacao = "Pesar no minimo 50Kg." },
                new OrientacaoDoacao { Id = 4, Orientacao = "Estar descansado (ter dormido pelo menos 6 horas nas últimas 24 horas)." },
                new OrientacaoDoacao { Id = 5, Orientacao = "Estar alimentado (evitar alimentação gordurosa nas 4 horas que antecedem a doação)." },
                new OrientacaoDoacao { Id = 6, Orientacao = "Apresentar documento original com foto recente, que permita a identificação do usuario " +
                "(Carteira de Identidade, Cartão de Identidade de Profissional Liberal, Carteira de Trabalho " +
                "e Previdência Social, Carteira nacional de Habilitação e RNE-Registro Nacional de Estrangeiro)." }
                );

        }
    }
}
