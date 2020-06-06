using GraphQL;
using GraphQL.Types;
using HousePlan.Dominio;
using HousePlan.Servico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiGraphQL.Types;

namespace WebApiGraphQL.Mutations
{
    public class BlogMutation : ObjectGraphType<object>
    {
        public BlogMutation(UsuarioServico _usuario)
        {
            Name = "Mutation";
            Field<UsuarioType>("criarUsuario",
                arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<UsuarioInputType>> { Name = "usuario" }
                ),
                resolve: context =>
                {
                    var usuario = context.GetArgument<Usuario>("usuario");
                    return _usuario.Salvar(usuario);
                });

            Field<UsuarioType>("alterarUsuario",
                arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<UsuarioInputType>> { Name = "usuario" },
                new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "usuarioId" }
                ),
                resolve: context =>
                {
                    var usuario = context.GetArgument<Usuario>("usuario");
                    var cod = context.GetArgument<int>("usuarioId");

                    var entidade = _usuario.ObterUsuarioPorID(cod);
                    if (entidade == null)
                    {
                        context.Errors.Add(new ExecutionError("Não foi possivel encontrar usuário na base de dados."));
                        return null;
                    }
                    return _usuario.Atualizar(usuario);
                });

                Field<StringGraphType>("removerUsuario",
                arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "usuarioId" }
                ),
                resolve: context =>
                {
                    var cod = context.GetArgument<int>("usuarioId");
                    var dbUsuario = _usuario.ObterUsuarioPorID(cod);
                    if (dbUsuario == null)
                    {
                        context.Errors.Add(new ExecutionError("Não foi possivel encontrar usuário na base de dados."));
                        return null;
                    }
                    _usuario.Excluir(dbUsuario);
                    return $"O usuario com id {cod} foi removido";
                });
        }
    }
}
