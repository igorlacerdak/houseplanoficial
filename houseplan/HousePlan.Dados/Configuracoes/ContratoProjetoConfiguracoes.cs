using HousePlan.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HousePlan.Dados.Configuracoes
{
    public class ContratoProjetoConfiguracoes : IEntityTypeConfiguration<ContratoProjeto>
    {
        public void Configure(EntityTypeBuilder<ContratoProjeto> builder)
        {
            builder.ToTable("TB_CONTRATO_PROJETO","HousePlan");
            builder.HasKey("COD_CONTRATO"); 

            builder.Property(f => f.COD_CONTRATO).HasColumnName("COD_CONTRATO").IsRequired();
            builder.Property(f => f.COD_PROJETO).HasColumnName("COD_PROJETO");
            builder.Property(f => f.COD_USUARIO).HasColumnName("COD_USUARIO");
            builder.Property(f => f.COD_STATUS).HasColumnName("COD_STATUS");
            builder.Property(f => f.COD_TERRENO).HasColumnName("COD_TERRENO");
            builder.Property(f => f.VALOR_CONTRATO).HasColumnName("VALOR_CONTRATO");
            builder.Property(f => f.ATIVO).HasColumnName("ATIVO");
            builder.Property(f => f.CRIADO).HasColumnName("CRIADO");
            builder.Property(f => f.DELETADO).HasColumnName("DELETADO");
            builder.Property(f => f.ATUALIZADO).HasColumnName("ATUALIZADO");
            builder.Property(f => f.CRIADO_POR).HasColumnName("CRIADO_POR");
            builder.Property(f => f.ATUALIZADO_POR).HasColumnName("ATUALIZADO_POR");

        }
    }
}
