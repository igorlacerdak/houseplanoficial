using GraphQL.Types;
using HousePlan;
using HousePlan.Dominio;
using HousePlan.Servico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiGraphQL.Types;

namespace WebApiGraphQL.Queries
{
    public class BlogQuery : ObjectGraphType<object>
    {
        public BlogQuery(UsuarioServico _usuario)
        {
            Field<ListGraphType<UsuarioType>>("usuario",
                arguments: new QueryArguments(new QueryArgument[]
                {
                    new QueryArgument<IdGraphType>{Name="COD_USUARIO"},
                    new QueryArgument<StringGraphType>{Name="NOME"}
                }),

                resolve: contexto =>
                {
                    var filtro = new Usuario()
                    {
                        COD_USUARIO = contexto.GetArgument<int>("COD_USUARIO"),
                        NOME = contexto.GetArgument<string>("NOME"),
                    };

                    return _usuario.ObterUsuarios(filtro);
                }

                );
        }
    }
}
