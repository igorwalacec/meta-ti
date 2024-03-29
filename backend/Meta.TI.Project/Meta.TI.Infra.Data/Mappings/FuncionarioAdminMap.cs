﻿using Meta.TI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Meta.TI.Infra.Data.Mappings
{
    public class FuncionarioAdminMap : IEntityTypeConfiguration<FuncionarioAdmin>
    {
        public void Configure(EntityTypeBuilder<FuncionarioAdmin> builder)
        {
            builder.Property(f => f.Id)
                .HasColumnName("Id");

            builder.HasOne(f => f.Funcionario)
                .WithOne(f => f.FuncionarioAdmin)
                .HasForeignKey<FuncionarioAdmin>(t => t.IdFuncionario)
                .IsRequired();

            builder.HasOne(u => u.Hemocentro)
                .WithMany(u => u.FuncionariosAdmin)
                .HasForeignKey(u => u.IdHemocentro)
                .IsRequired();
        }
    }
}
