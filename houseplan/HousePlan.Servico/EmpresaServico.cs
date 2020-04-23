using HousePlan.Comum.NotificationPattern;
using HousePlan.Dados;
using HousePlan.Comum;
using HousePlan.Dominio;
using System;
using System.Collections.Generic;

namespace HousePlan.Servico
{
    public class EmpresaServico
    {
        private readonly EmpresaRepositorio _empresa;

        public EmpresaServico()
        {
            _empresa = new EmpresaRepositorio();
        }


        public NotificationResult Salvar(Empresa entidade)
        {
            var NotificationResult = new NotificationResult();

            try
            {
                entidade.CRIADO = DateTime.Now;
               

                if (!CNPJUtil.Validar(entidade.CNPJ))
                    NotificationResult.Add(new NotificationError("CNPJ invalido!", NotificationErrorType.USER));

                if (String.IsNullOrEmpty(entidade.RAZAO_SOCIAL))
                    NotificationResult.Add(new NotificationError("Necessario inserir Razão Social!", NotificationErrorType.USER));
                
                if (NotificationResult.IsValid)
                {
                    _empresa.Adicionar(entidade);
                    NotificationResult.Add("Empresa cadastrada com Sucesso!");
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
            return _empresa.ListarTodos();
        }
    }
}
