using GraphQL.Types;
using HousePlan.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiGraphQL.Types
{
    public class UsuarioType : ObjectGraphType<Usuario>
    {
        public UsuarioType()
        {
            Name = "Usuario";
            Field(f => f.COD_USUARIO, type: typeof(IdGraphType)).Description("Id usuário");
            Field(f => f.CPF).Description("CPF do usuário");
            Field(f => f.NOME).Description("Nome do usuário");
            Field(f => f.EMAIL).Description("Email do usuário");
            Field(f => f.LOGIN).Description("Login do usuário");
            Field(f => f.SENHA).Description("Senha do Usuario");
            Field(f => f.ATIVO).Description("Ativação do Usuario");
            Field(f => f.CRIADO, type: typeof(DateTimeGraphType)).Description("Data criação do usuario");
        }
    }
}
