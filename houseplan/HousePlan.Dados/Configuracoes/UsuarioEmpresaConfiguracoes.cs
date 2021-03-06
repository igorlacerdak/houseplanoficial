﻿using HousePlan.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HousePlan.Dados.Configuracoes
{
    public class UsuarioEmpresaConfiguracoes : IEntityTypeConfiguration<UsuarioEmpresa>
    {
        public void Configure(EntityTypeBuilder<UsuarioEmpresa> builder)
        {
            builder.ToTable("TB_USUARIO_EMPRESA","HousePlan");
            builder.HasKey("COD_USUARIO_EMPRESA");

            builder.Property(f => f.COD_USUARIO_EMPRESA).HasColumnName("COD_USUARIO_EMPRESA").IsRequired();
            builder.Property(f => f.COD_USUARIO).HasColumnName("COD_USUARIO");
            builder.Property(f => f.COD_EMPRESA).HasColumnName("COD_EMPRESA");
            builder.Property(f => f.ATIVO).HasColumnName("ATIVO");
            builder.Property(f => f.CRIADO).HasColumnName("CRIADO");
            builder.Property(f => f.DELETADO).HasColumnName("DELETADO");
            builder.Property(f => f.ATUALIZADO).HasColumnName("ATUALIZADO");
            builder.Property(f => f.CRIADO_POR).HasColumnName("CRIADO_POR");
            builder.Property(f => f.ATUALIZADO_POR).HasColumnName("ATUALIZADO_POR");

            builder.HasOne(f => f.Usuario)
                   .WithMany()
                   .HasForeignKey(f => f.COD_USUARIO);

            builder.HasOne(f => f.Empresa)
                   .WithMany()
                   .HasForeignKey(f => f.COD_EMPRESA);

        }
    }
}
