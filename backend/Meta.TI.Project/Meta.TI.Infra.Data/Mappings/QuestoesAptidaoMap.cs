using System;
using System.Collections.Generic;
using System.Text;
using Meta.TI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Meta.TI.Infra.Data.Mappings
{
    public class QuestoesAptidaoMap : IEntityTypeConfiguration<QuestoesAptidao>
    {
        public void Configure(EntityTypeBuilder<QuestoesAptidao> builder)
        {
            builder.Property(q => q.Id)
               .ValueGeneratedOnAdd()
               .HasColumnName("Id");

            builder.Property(q => q.Pergunta)
                .HasColumnType("varchar(255)")
                .HasColumnName("Pergunta")
                .IsRequired();

            builder.Property(q => q.NumeroDiasAfastado)
                .HasColumnType("int")
                .HasColumnName("NumeroDiasAfastado")
                .IsRequired();

            builder.Property(q => q.ImpeditivoDefinitivo)
                .HasColumnType("bit")
                .HasColumnName("ImpeditivoDefinitivo")
                .IsRequired();

            builder.Property(q => q.ImpeditivoDeterminado)
                .HasColumnType("bit")
                .HasColumnName("ImpeditivoDeterminado")
                .IsRequired();

            builder.HasOne(q => q.TipoSexo)
                .WithMany(t => t.QuestoesAptidao)
                .HasForeignKey(q => q.IdTipoSexo);

            builder.HasData(
                new QuestoesAptidao { Id = 1, Pergunta = "Boas condições de saúde", NumeroDiasAfastado = -1, ImpeditivoDefinitivo = false, ImpeditivoDeterminado = true, IdTipoSexo = null },
                new QuestoesAptidao { Id = 2, Pergunta = "Possui um peso maior que 50kg?", NumeroDiasAfastado = -1, ImpeditivoDefinitivo = false, ImpeditivoDeterminado = true, IdTipoSexo = null },
                new QuestoesAptidao { Id = 3, Pergunta = "Possui mais que 18 anos?", NumeroDiasAfastado = -1, ImpeditivoDefinitivo = false, ImpeditivoDeterminado = true, IdTipoSexo = null },
                new QuestoesAptidao { Id = 4, Pergunta = "Pegou resfriado dentro dos ultimos 7 dias?", NumeroDiasAfastado = 7, ImpeditivoDefinitivo = false, ImpeditivoDeterminado = true, IdTipoSexo = null },
                new QuestoesAptidao { Id = 5, Pergunta = "Está gravida?", NumeroDiasAfastado = -1, ImpeditivoDefinitivo = false, ImpeditivoDeterminado = true, IdTipoSexo = 2 },
                new QuestoesAptidao { Id = 6, Pergunta = "Teve um parto normal nos ultimos 90 dias?", NumeroDiasAfastado = 90, ImpeditivoDefinitivo = false, ImpeditivoDeterminado = true, IdTipoSexo = 2 },
                new QuestoesAptidao { Id = 7, Pergunta = "Teve um parto cesario nos ultimos 180 dias?", NumeroDiasAfastado = 180, ImpeditivoDefinitivo = false, ImpeditivoDeterminado = true, IdTipoSexo = 2 },
                new QuestoesAptidao { Id = 8, Pergunta = "Está em periodo de amamentação?", NumeroDiasAfastado = -1, ImpeditivoDefinitivo = false, ImpeditivoDeterminado = true, IdTipoSexo = 2 },
                new QuestoesAptidao { Id = 9, Pergunta = "Ingeriu bebidas alcoolicas nas últimas 12 horas?", NumeroDiasAfastado = 1, ImpeditivoDefinitivo = false, ImpeditivoDeterminado = true, IdTipoSexo = null },
                new QuestoesAptidao { Id = 10, Pergunta = "Fez tatuagem ou maquiagem definitiva nos últimos 12 meses?", NumeroDiasAfastado = 365, ImpeditivoDefinitivo = false, ImpeditivoDeterminado = true, IdTipoSexo = null },
                new QuestoesAptidao { Id = 11, Pergunta = "Situações nas quais há maior risco de contrair doenças sexualmente transmissiveis?", NumeroDiasAfastado = 365, ImpeditivoDefinitivo = false, ImpeditivoDeterminado = true, IdTipoSexo = null },
                new QuestoesAptidao { Id = 12, Pergunta = "Passou por procedimentos endoscópico nos últimos 6 meses?", NumeroDiasAfastado = 183, ImpeditivoDefinitivo = false, ImpeditivoDeterminado = true, IdTipoSexo = null },
                new QuestoesAptidao { Id = 13, Pergunta = "Extração dentaria nos ultimos 7 dias?", NumeroDiasAfastado = 7, ImpeditivoDefinitivo = false, ImpeditivoDeterminado = true, IdTipoSexo = null },
                new QuestoesAptidao { Id = 14, Pergunta = "Cirurgia odontologica com anestesia geral nas últimas 4 semanas?", NumeroDiasAfastado = 30, ImpeditivoDefinitivo = false, ImpeditivoDeterminado = true, IdTipoSexo = null },
                new QuestoesAptidao { Id = 15, Pergunta = "Acumpuntura com material descartável nas ultimas 24 horas?", NumeroDiasAfastado = 1, ImpeditivoDefinitivo = false, ImpeditivoDeterminado = true, IdTipoSexo = null },
                new QuestoesAptidao { Id = 16, Pergunta = "Vácina contra gripe nas últimas 48 horas?", NumeroDiasAfastado = 2, ImpeditivoDefinitivo = false, ImpeditivoDeterminado = true, IdTipoSexo = null },
                new QuestoesAptidao { Id = 17, Pergunta = "Possui herpes labial ou genital?", NumeroDiasAfastado = -1, ImpeditivoDefinitivo = false, ImpeditivoDeterminado = true, IdTipoSexo = null },
                new QuestoesAptidao { Id = 18, Pergunta = "Possui herpes zoster?", NumeroDiasAfastado = -1, ImpeditivoDefinitivo = false, ImpeditivoDeterminado = true, IdTipoSexo = null },
                new QuestoesAptidao { Id = 19, Pergunta = "Esteve no Acre, Amapa, Amazonas, Rondonia, Roraima, Maranhão, Mato Grosso, Para e Tocantins nos ultimos 12 meses?", NumeroDiasAfastado = 365, ImpeditivoDefinitivo = false, ImpeditivoDeterminado = true, IdTipoSexo = null },
                new QuestoesAptidao { Id = 20, Pergunta = "Esteve nos EUA nos últimos 30 dias?", NumeroDiasAfastado = 30, ImpeditivoDefinitivo = false, ImpeditivoDeterminado = true, IdTipoSexo = null },
                new QuestoesAptidao { Id = 21, Pergunta = "Esteve em paises com alta prevalencia de malaria?", NumeroDiasAfastado = 365, ImpeditivoDefinitivo = false, ImpeditivoDeterminado = true, IdTipoSexo = null },
                new QuestoesAptidao { Id = 22, Pergunta = "Esteve em região de surto de febre amarela ou tomou a vacina após o retorno?", NumeroDiasAfastado = 30, ImpeditivoDefinitivo = false, ImpeditivoDeterminado = true, IdTipoSexo = null },
                new QuestoesAptidao { Id = 23, Pergunta = "Caso possuia febre amarela, fazem 6 meses após a recuperação completa?", NumeroDiasAfastado = 183, ImpeditivoDefinitivo = false, ImpeditivoDeterminado = true, IdTipoSexo = null },
                new QuestoesAptidao { Id = 24, Pergunta = "Possui hepatite desde os 11 anos?", NumeroDiasAfastado = -1, ImpeditivoDefinitivo = true, ImpeditivoDeterminado = false, IdTipoSexo = null },
                new QuestoesAptidao { Id = 25, Pergunta = "Possui evidencias clinicas ou laboratoriais de doenças infecciosas trasmissiveis pelo sangue?", NumeroDiasAfastado = -1, ImpeditivoDefinitivo = true, ImpeditivoDeterminado = false, IdTipoSexo = null },
                new QuestoesAptidao { Id = 26, Pergunta = "Usa drogas ilicitas injetaveis?", NumeroDiasAfastado = -1, ImpeditivoDefinitivo = true, ImpeditivoDeterminado = false, IdTipoSexo = null },
                new QuestoesAptidao { Id = 27, Pergunta = "Possui malaria?", NumeroDiasAfastado = -1, ImpeditivoDefinitivo = true, ImpeditivoDeterminado = false, IdTipoSexo = null }
            );
        }
    }
}
