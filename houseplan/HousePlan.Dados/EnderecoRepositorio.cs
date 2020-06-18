using HousePlan.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HousePlan.Dados
{
    public class EnderecoRepositorio : RepositorioBase<UsuarioEndereco>
    {
        public IEnumerable<UsuarioEndereco> ListarTodos()
        {
            return Contexto
                .UsuarioEndereco
                .Where(f => f.COD_USUARIO != 0); 
        }

        public int Max_COD_ENDERECO()
        {
            return Contexto
                .UsuarioEndereco
                .Max(f => f.COD_ENDERECO);
        }

        public IEnumerable<UsuarioEndereco> ListarAtivos()
        {
            return Contexto
                .UsuarioEndereco
                .Where(f => f.ATIVO == 1);
        }

    }
}