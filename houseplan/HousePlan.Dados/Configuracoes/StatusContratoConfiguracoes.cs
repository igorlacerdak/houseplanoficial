using HousePlan.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HousePlan.Dados.Configuracoes
{
    public class StatusContratoConfiguracoes : IEntityTypeConfiguration<StatusContrato>
    {
        public void Configure(EntityTypeBuilder<StatusContrato> builder)
        {
            builder.ToTable("TB_STATUS_CONTRATO","HousePlan");
            builder.HasKey("COD_STATUS"); 

            builder.Property(f => f.COD_STATUS).HasColumnName("COD_STATUS").IsRequired();
            builder.Property(f => f.DESCRICAO).HasColumnName("DESCRICAO");
            builder.Property(f => f.ATIVO).HasColumnName("ATIVO");
            builder.Property(f => f.CRIADO).HasColumnName("CRIADO");
            builder.Property(f => f.DELETADO).HasColumnName("DELETADO");
            builder.Property(f => f.ATUALIZADO).HasColumnName("ATUALIZADO");
            builder.Property(f => f.CRIADO_POR).HasColumnName("CRIADO_POR");
            builder.Property(f => f.ATUALIZADO_POR).HasColumnName("ATUALIZADO_POR");

        }
    }
}
