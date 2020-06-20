using HousePlan.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HousePlan.Dados
{
    public class ProjetoRepositorio : RepositorioBase<Projeto>
    {
        public IEnumerable<Usuario> ListarTodos()
        {
            return Contexto
                .Usuario
                .Where(f => f.COD_USUARIO != 0);
        }

        public int Max_COD_PROJETO()
        {
            return Contexto
                .Projeto
                .Max(f => f.COD_PROJETO);
        }

        public IEnumerable<Projeto> ListarAtivos()
        {
            return Contexto
                .Projeto
                .Where(f => f.ATIVO == 1);
        }

        public Projeto ProjetoEmpresa(int COD_PROJETO)
        {
            return Contexto
                .Projeto
                .FirstOrDefault(f => f.COD_PROJETO == COD_PROJETO);
        }
    }
}