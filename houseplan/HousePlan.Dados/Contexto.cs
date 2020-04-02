using HousePlan.Dominio;
using HousePlan.Dados.Configuracoes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HousePlan.Dados
{
    public class Contexto : DbContext
    {   
        //. CLASSES - ENTIDADES - TABELAS
        //. INICIO
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<UsuarioContato> UsuarioContato { get; set; }
        public DbSet<UsuarioEmpresa> UsuarioEmpresa { get; set; }
        public DbSet<UsuarioEndereco> UsuarioEndereco { get; set; }
        public DbSet<UsuarioTerreno> UsuarioTerreno { get; set; }
        public DbSet<Terreno> Terreno { get; set; }
        public DbSet<StatusContrato> StatusContato { get; set; }
        public DbSet<ProjetoImagens> ProjetoImagens { get; set; }
        public DbSet<Projeto> Projeto { get; set; }
        public DbSet<ContratoProjeto> ContratoProjeto { get; set; }
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<EmpresaContato> EmpresaContato { get; set; }
        public DbSet<EmpresaTerreno> EmpresaTerreno { get; set; }
        public DbSet<ContatoTipo> ContatoTipo { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=201.62.57.93;database=dbLAB2_2020;user id=visualstudio;password=visualstudio;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            //. DEFINIÇÃO DAS CONFIGURAÇÕES DAS CLASSES
            //. INICIO
            modelBuilder.ApplyConfiguration(new UsuarioConfiguracoes());
            modelBuilder.ApplyConfiguration(new UsuarioContatoConfiguracoes());
            modelBuilder.ApplyConfiguration(new UsuarioEmpresaConfiguracoes());
            modelBuilder.ApplyConfiguration(new UsuarioEnderecoConfiguracoes());
            modelBuilder.ApplyConfiguration(new UsuarioTerrenoConfiguracoes());
            modelBuilder.ApplyConfiguration(new TerrenoConfiguracoes());
            modelBuilder.ApplyConfiguration(new StatusContratoConfiguracoes());
            modelBuilder.ApplyConfiguration(new ProjetoConfiguracoes());
            modelBuilder.ApplyConfiguration(new ProjetoImagensConfiguracoes());
            modelBuilder.ApplyConfiguration(new ContratoProjetoConfiguracoes());
            modelBuilder.ApplyConfiguration(new EmpresaConfiguracoes());
            modelBuilder.ApplyConfiguration(new EmpresaContatoConfiguracoes());
            modelBuilder.ApplyConfiguration(new EmpresaTerrenoConfiguracoes());
            modelBuilder.ApplyConfiguration(new ContatoTipoConfiguracoes());
          

        }
    }
}
