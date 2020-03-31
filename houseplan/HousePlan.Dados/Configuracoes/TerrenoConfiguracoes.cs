using HousePlan.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HousePlan.Dados.Configuracoes
{
    public class TerrenoConfiguracoes : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("TB_TERRENO","HousePlan");
            builder.HasKey("COD_TERRENO"); 

            builder.Property(f => f.COD_TERRENO).HasColumnName("COD_TERRENO").IsRequired();
            builder.Property(f => f.PAIS).HasColumnName("PAIS");
            builder.Property(f => f.ESTADO).HasColumnName("ESTADO");
            builder.Property(f => f.CIDADE).HasColumnName("CIDADE");
            builder.Property(f => f.BAIRRO).HasColumnName("BAIRRO");
            builder.Property(f => f.LOGRADOURO).HasColumnName("LOGRADOURO");
            builder.Property(f => f.METRAGEM).HasColumnName("METRAGEM");
            builder.Property(f => f.VALOR).HasColumnName("VALOR");
            builder.Property(f => f.ATIVO).HasColumnName("ATIVO");
            builder.Property(f => f.CRIADO).HasColumnName("CRIADO");
            builder.Property(f => f.DELETADO).HasColumnName("DELETADO");
            builder.Property(f => f.ATUALIZADO).HasColumnName("ATUALIZADO");
            builder.Property(f => f.CRIADO_POR).HasColumnName("CRIADO_POR");
            builder.Property(f => f.ATUALIZADO_POR).HasColumnName("ATUALIZADO_POR");

        }
    }
}
