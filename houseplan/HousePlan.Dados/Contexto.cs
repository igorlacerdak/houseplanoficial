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
        public DbSet<Usuario> Usuario { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=201.62.57.93;database=dbLAB2_2020;user id=visualstudio;password=visualstudio;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioConfiguracoes());
        }
    }
}
