using HousePlan.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HousePlan.Dados
{
    public class EmpresaRepositorio : RepositorioBase<Empresa>
    {
        public IEnumerable<Empresa> ListarTodos()
        {
            return Contexto
                .Empresa
                .Where(f => f.COD_EMPRESA != 0);
        }
        public Empresa ObterEmpresaPorID (int COD_EMPRESA)
        {
            return Contexto
                .Empresa.FirstOrDefault(f => f.COD_EMPRESA == COD_EMPRESA);
        }
    }
}