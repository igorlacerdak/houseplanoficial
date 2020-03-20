using HousePlan.Dados;
using HousePlan.Dominio;
using System;
using System.Collections.Generic;

namespace HousePlan.Servico
{
    public class UsuarioServico
    {
        private readonly UsuarioRepositorio _usuario;

        public UsuarioServico()
        {
            _usuario = new UsuarioRepositorio();
        }

        public IEnumerable<Usuario> ListarTodos()
        {
            return _usuario.ListarTodos();
        }
    }
}
