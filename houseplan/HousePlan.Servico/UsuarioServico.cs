using HousePlan.Comum.NotificationPattern;
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


        public NotificationResult Salvar(Usuario entidade)
        {
            var NotificationResult = new NotificationResult();

            try
            {
                entidade.CRIADO = DateTime.Now;
                entidade.CPF = "123456789";

                if (!entidade.ValidarCPF())
                    NotificationResult.Add(new NotificationError("CPF Invalido!", NotificationErrorType.BUSINESS_RULES));

                if (NotificationResult.IsValid)
                {
                    _usuario.Adicionar(entidade);
                }

                return NotificationResult;
            }

            catch(Exception ex)
            {
                return NotificationResult.Add(new NotificationError(ex.Message));
            }
        }

        public string Excluir(Usuario entidade)
        {
            return "";
        }

        public IEnumerable<Usuario> ListarTodos()
        {
            return _usuario.ListarTodos();
        }
    }
}
