using HousePlan.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HousePlan.Dados
{
    public class UsuarioContatoRepositorio : RepositorioBase<UsuarioContato>
    {
        public IEnumerable<UsuarioContato> ListarTodos()
        {
            return Contexto
                .UsuarioContato
                .Where(f => f.COD_CONTATO != 0); 
        }

        public int Max_COD_CONTATO()
        {
            return Contexto
                .UsuarioContato
                .Max(f => f.COD_CONTATO);
        }

        public IEnumerable<UsuarioContato> ListarAtivos()
        {
            return Contexto
                .UsuarioContato
                .Where(f => f.ATIVO == 1);
        }

    }
}