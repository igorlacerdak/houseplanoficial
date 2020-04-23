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
    }
}