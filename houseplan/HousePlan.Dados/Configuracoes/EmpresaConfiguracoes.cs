using HousePlan.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HousePlan.Dados.Configuracoes
{
    public class EmpresaConfiguracoes : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("TB_EMPRESA","HousePlan");
            builder.HasKey("COD_EMPRESA"); 

            builder.Property(f => f.COD_EMPRESA).HasColumnName("COD_EMPRESA").IsRequired();
            builder.Property(f => f.COD_EMPRESA_SEDE).HasColumnName("COD_EMPRESA_SEDE");
            builder.Property(f => f.RAZAO_SOCIAL).HasColumnName("RAZAO_SOCIAL");
            builder.Property(f => f.NOME_FANTASIA).HasColumnName("NOME_FANTASIA");
            builder.Property(f => f.CNPJ).HasColumnName("CNPJ");
            builder.Property(f => f.PAIS).HasColumnName("PAIS");
            builder.Property(f => f.ESTADO).HasColumnName("ESTADO");
            builder.Property(f => f.CIDADE).HasColumnName("CIDADE");
            builder.Property(f => f.BAIRRO).HasColumnName("BAIRRO");
            builder.Property(f => f.LOGRADOURO).HasColumnName("LOGRADOURO");
            builder.Property(f => f.NUMERO).HasColumnName("NUMERO");
            builder.Property(f => f.CEP).HasColumnName("CEP");
            builder.Property(f => f.ATIVO).HasColumnName("ATIVO");
            builder.Property(f => f.CRIADO).HasColumnName("CRIADO");
            builder.Property(f => f.DELETADO).HasColumnName("DELETADO");
            builder.Property(f => f.ATUALIZADO).HasColumnName("ATUALIZADO");
            builder.Property(f => f.CRIADO_POR).HasColumnName("CRIADO_POR");
            builder.Property(f => f.ATUALIZADO_POR).HasColumnName("ATUALIZADO_POR");

        }
    }
}
