using HousePlan.Comum.NotificationPattern;
using HousePlan.Dados;
using HousePlan.Comum;
using HousePlan.Dominio;
using System;
using System.Collections.Generic;

namespace HousePlan.Servico
{
    public class ContatoTipoServico
    {
        private readonly ContatoTipoRepositorio _contatoTipo;

        public ContatoTipoServico()
        {
            _contatoTipo = new ContatoTipoRepositorio();
        }


        public NotificationResult Salvar(ContatoTipo entidade)
        {
            var NotificationResult = new NotificationResult();

            try
            {
                entidade.CRIADO = DateTime.Now;
                entidade.COD_CONTATO_TIPO = _contatoTipo.Max_COD_CONTATO_TIPO() + 1;

                if (entidade.COD_CONTATO_TIPO == 0)
                    NotificationResult.Add(new NotificationError("Necessario selecionar um tipo de contato!", NotificationErrorType.USER));

                if (NotificationResult.IsValid)
                {
                    _contatoTipo.Adicionar(entidade);
                    NotificationResult.Add("Tipo de Contato inserido com Sucesso!");
                }

                return NotificationResult;
            }

            catch(Exception ex)
            {
                return NotificationResult.Add(new NotificationError(ex.Message));
            }
        }


        public IEnumerable<ContatoTipo> ListarTodos()
        {
            return _contatoTipo.ListarTodos();
        }
    }
}
