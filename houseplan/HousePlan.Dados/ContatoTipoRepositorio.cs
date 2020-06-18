using HousePlan.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HousePlan.Dados
{
    public class ContatoTipoRepositorio : RepositorioBase<ContatoTipo>
    {
        public IEnumerable<ContatoTipo> ListarTodos()
        {
            return Contexto
                .ContatoTipo
                .Where(f => f.COD_CONTATO_TIPO != 0); 
        }

        public int Max_COD_CONTATO_TIPO()
        {
            return Contexto
                .ContatoTipo
                .Max(f => f.COD_CONTATO_TIPO);
        }

        public IEnumerable<ContatoTipo> ListarAtivos()
        {
            return Contexto
                .ContatoTipo
                .Where(f => f.ATIVO == 1);
        }

    }
}