using HousePlan.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HousePlan.Dados
{
    public class UsuarioRepositorio : RepositorioBase<Usuario>
    {
        public IEnumerable<Usuario> ListarTodos()
        {
            return Contexto
                .Usuario
                .Where(f => f.COD_USUARIO != 0); 
        }

        public int Max_COD_USUARIO()
        {
            return Contexto
                .Usuario
                .Max(f => f.COD_USUARIO);
        }

        public IEnumerable<Usuario> ListarAtivos()
        {
            return Contexto
                .Usuario
                .Where(f => f.ATIVO == 1);
        }

    }
}