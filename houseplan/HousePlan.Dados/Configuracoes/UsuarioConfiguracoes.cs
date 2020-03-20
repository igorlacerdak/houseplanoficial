using HousePlan.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HousePlan.Dados.Configuracoes
{
    public class UsuarioConfiguracoes : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("TB_USUARIO","HousePlan");
            builder.HasKey("COD_USUARIO"); 

            builder.Property(f => f.COD_USUARIO).HasColumnName("COD_USUARIO").IsRequired();
            builder.Property(f => f.NOME).HasColumnName("NOME");
            builder.Property(f => f.CPF).HasColumnName("CPF");
            builder.Property(f => f.EMAIL).HasColumnName("EMAIL");
            builder.Property(f => f.LOGIN).HasColumnName("LOGIN");
            builder.Property(f => f.SENHA).HasColumnName("SENHA");
            builder.Property(f => f.URL_FOTO).HasColumnName("URL_FOTO");
            builder.Property(f => f.ATIVO).HasColumnName("ATIVO");
            builder.Property(f => f.CRIADO).HasColumnName("CRIADO");
            builder.Property(f => f.DELETADO).HasColumnName("DELETADO");
            builder.Property(f => f.ATUALIZADO).HasColumnName("ATUALIZADO");
            builder.Property(f => f.CRIADO_POR).HasColumnName("CRIADO_POR");
            builder.Property(f => f.ATUALIZADO_POR).HasColumnName("ATUALIZADO_POR");


        }
    }
}
