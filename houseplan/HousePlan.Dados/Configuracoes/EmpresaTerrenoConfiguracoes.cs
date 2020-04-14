using HousePlan.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HousePlan.Dados.Configuracoes
{
    public class EmpresaTerrenoConfiguracoes : IEntityTypeConfiguration<EmpresaTerreno>
    {
        public void Configure(EntityTypeBuilder<EmpresaTerreno> builder)
        {
            builder.ToTable("TB_EMPRESA_TERRENO", "HousePlan");
            builder.HasKey("COD_EMPRESA_TERRENO");

            builder.Property(f => f.COD_EMPRESA_TERRENO).HasColumnName("COD_EMPRESA_TERRENO").IsRequired();
            builder.Property(f => f.COD_EMPRESA).HasColumnName("COD_EMPRESA");
            builder.Property(f => f.COD_TERRENO).HasColumnName("COD_TERRENO");
            builder.Property(f => f.ATIVO).HasColumnName("ATIVO");
            builder.Property(f => f.CRIADO).HasColumnName("CRIADO");
            builder.Property(f => f.DELETADO).HasColumnName("DELETADO");
            builder.Property(f => f.ATUALIZADO).HasColumnName("ATUALIZADO");
            builder.Property(f => f.CRIADO_POR).HasColumnName("CRIADO_POR");
            builder.Property(f => f.ATUALIZADO_POR).HasColumnName("ATUALIZADO_POR");

            builder.HasOne(f => f.Empresa)
                .WithMany()
                .HasForeignKey(f => f.COD_EMPRESA);
           
            builder.HasOne(f => f.Terreno)
                .WithMany()
                .HasForeignKey(f => f.COD_TERRENO);
    

        }
    }
}
