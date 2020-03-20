using HousePlan.Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace HousePlan.Dados
{
    public class UsuarioRepositorio : RepositorioBase<Usuario>
    {
        public IEnumerable<Usuario> ListarTodos()
        {
            return Contexto
                .Usuario;
 
        }
    }
}