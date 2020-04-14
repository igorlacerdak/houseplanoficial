using HousePlan.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HousePlan.Dados.Configuracoes
{
    public class ProjetoConfiguracoes : IEntityTypeConfiguration<Projeto>
    {
        public void Configure(EntityTypeBuilder<Projeto> builder)
        {
            builder.ToTable("TB_PROJETO","HousePlan");
            builder.HasKey("COD_PROJETO"); 

            builder.Property(f => f.COD_PROJETO).HasColumnName("COD_PROJETO").IsRequired();
            builder.Property(f => f.COD_EMPRESA).HasColumnName("COD_EMPRESA");
            builder.Property(f => f.DESCRICAO).HasColumnName("DESCRICAO");
            builder.Property(f => f.TITULO).HasColumnName("TITULO");
            builder.Property(f => f.STATUS).HasColumnName("STATUS");
            builder.Property(f => f.AUTOR).HasColumnName("AUTOR");
            builder.Property(f => f.METRAGEM).HasColumnName("METRAGEM");
            builder.Property(f => f.VALOR).HasColumnName("VALOR");
            builder.Property(f => f.ATIVO).HasColumnName("ATIVO");
            builder.Property(f => f.CRIADO).HasColumnName("CRIADO");
            builder.Property(f => f.DELETADO).HasColumnName("DELETADO");
            builder.Property(f => f.ATUALIZADO).HasColumnName("ATUALIZADO");
            builder.Property(f => f.CRIADO_POR).HasColumnName("CRIADO_POR");
            builder.Property(f => f.ATUALIZADO_POR).HasColumnName("ATUALIZADO_POR");

            builder.HasOne(f => f.Empresa)
                   .WithMany()
                   .HasForeignKey(f => f.COD_EMPRESA);


        }
    }
}
