using HousePlan.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HousePlan.Dados.Configuracoes
{
    public class UsuarioContatoConfiguracoes : IEntityTypeConfiguration<UsuarioContato>
    {
        public void Configure(EntityTypeBuilder<UsuarioContato> builder)
        {
            builder.ToTable("TB_USUARIO_CONTATO","HousePlan");
            builder.HasKey("COD_CONTATO");

            builder.Property(f => f.COD_CONTATO).HasColumnName("COD_CONTATO").IsRequired();
            builder.Property(f => f.COD_USUARIO).HasColumnName("COD_USUARIO");
            builder.Property(f => f.COD_CONTATO_TIPO).HasColumnName("COD_CONTATO_TIPO");
            builder.Property(f => f.CONTATO).HasColumnName("CONTATO");
            builder.Property(f => f.ATIVO).HasColumnName("ATIVO");
            builder.Property(f => f.CRIADO).HasColumnName("CRIADO");
            builder.Property(f => f.DELETADO).HasColumnName("DELETADO");
            builder.Property(f => f.ATUALIZADO).HasColumnName("ATUALIZADO");
            builder.Property(f => f.CRIADO_POR).HasColumnName("CRIADO_POR");
            builder.Property(f => f.ATUALIZADO_POR).HasColumnName("ATUALIZADO_POR");

            builder.HasOne(f => f.Usuario)
                   .WithMany()
                   .HasForeignKey(f => f.COD_USUARIO);

        }
    }
}
