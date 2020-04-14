using HousePlan.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HousePlan.Dados.Configuracoes
{
    public class UsuarioEnderecoConfiguracoes : IEntityTypeConfiguration<UsuarioEndereco>
    {
        public void Configure(EntityTypeBuilder<UsuarioEndereco> builder)
        {
            builder.ToTable("TB_USUARIO_ENDERECO","HousePlan");
            builder.HasKey("COD_ENDERECO"); 

            builder.Property(f => f.COD_ENDERECO).HasColumnName("COD_ENDERECO").IsRequired();
            builder.Property(f => f.COD_USUARIO).HasColumnName("COD_USUARIO");
            builder.Property(f => f.PAIS).HasColumnName("PAIS");
            builder.Property(f => f.ESTADO).HasColumnName("ESTADO");
            builder.Property(f => f.CIDADE).HasColumnName("CIDADE");
            builder.Property(f => f.BAIRRO).HasColumnName("BAIRRO");
            builder.Property(f => f.LOGRADOURO).HasColumnName("LOGRADOURO");
            builder.Property(f => f.NUMERO).HasColumnName("NUMERO");
            builder.Property(f => f.CEP).HasColumnName("CEP");
            builder.Property(f => f.REFERENCIA).HasColumnName("REFERENCIA");
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
