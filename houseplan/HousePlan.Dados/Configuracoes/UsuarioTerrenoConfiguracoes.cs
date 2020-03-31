using HousePlan.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HousePlan.Dados.Configuracoes
{
    public class UsuarioTerrenoConfiguracoes : IEntityTypeConfiguration<UsuarioTerreno>
    {
        public void Configure(EntityTypeBuilder<UsuarioTerreno> builder)
        {
            builder.ToTable("TB_USUARIO_TERRENO","HousePlan");
            builder.HasKey("COD_USUARIO_TERRENO");

            builder.Property(f => f.COD_USUARIO_TERRENO).HasColumnName("COD_USUARIO_TERRENO").IsRequired();
            builder.Property(f => f.COD_USUARIO).HasColumnName("COD_USUARIO");
            builder.Property(f => f.COD_TERRENO).HasColumnName("COD_TERRENO");
            builder.Property(f => f.CONTATO).HasColumnName("CONTATO");
            builder.Property(f => f.ATIVO).HasColumnName("ATIVO");
            builder.Property(f => f.CRIADO).HasColumnName("CRIADO");
            builder.Property(f => f.DELETADO).HasColumnName("DELETADO");
            builder.Property(f => f.ATUALIZADO).HasColumnName("ATUALIZADO");
            builder.Property(f => f.CRIADO_POR).HasColumnName("CRIADO_POR");
            builder.Property(f => f.ATUALIZADO_POR).HasColumnName("ATUALIZADO_POR");

        }
    }
}
