using HousePlan.Comum.NotificationPattern;
using HousePlan.Dados;
using HousePlan.Comum;
using HousePlan.Dominio;
using System;
using System.Collections.Generic;

namespace HousePlan.Servico
{
    public class ProjetoServico
    {
        private readonly ProjetoRepositorio _projeto;

        public ProjetoServico()
        {
            _projeto = new ProjetoRepositorio();
        }


        public NotificationResult Salvar(Projeto entidade)
        {
            var NotificationResult = new NotificationResult();

            try
            {
                entidade.CRIADO = DateTime.Now;
               

                if (String.IsNullOrEmpty(entidade.TITULO))
                    NotificationResult.Add(new NotificationError("Necessario inserir um titulo!", NotificationErrorType.USER));

                if (String.IsNullOrEmpty(entidade.DESCRICAO))
                    NotificationResult.Add(new NotificationError("Necessario inserir descrição sobre o projeto!", NotificationErrorType.USER));

                if ((entidade.VALOR) < 0)
                    NotificationResult.Add(new NotificationError("Valor inserido invalido!", NotificationErrorType.USER));
                
                if (NotificationResult.IsValid)
                {
                    _projeto.Adicionar(entidade);
                    NotificationResult.Add("Projeto inserido com Sucesso!");
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
            return _projeto.ListarTodos();
        }
    }
}
