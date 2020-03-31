using HousePlan.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HousePlan.Dados.Configuracoes
{
    public class ProjetoImagensConfiguracoes : IEntityTypeConfiguration<ProjetoImagens>
    {
        public void Configure(EntityTypeBuilder<ProjetoImagens> builder)
        {
            builder.ToTable("TB_PROJETO_IMAGENS","HousePlan");
            builder.HasKey("COD_IMAGEM"); 

            builder.Property(f => f.COD_IMAGEM).HasColumnName("COD_IMAGEM").IsRequired();
            builder.Property(f => f.COD_PROJETO).HasColumnName("COD_PROJETO");
            builder.Property(f => f.URL).HasColumnName("URL");
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
