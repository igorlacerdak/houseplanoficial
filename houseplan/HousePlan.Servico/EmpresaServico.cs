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

        public NotificationResult Atualizar(Empresa entidade)
        {
            var NotificationResult = new NotificationResult();

            try
            {
                if (entidade.COD_EMPRESA != 0)

                    entidade.COD_EMPRESA = entidade.COD_EMPRESA;
                    entidade.ATUALIZADO = DateTime.Now;

                if (NotificationResult.IsValid)
                {
                    _empresa.Update(entidade);
                    NotificationResult.Add("Empresa Alterado com Sucesso!");

                    return NotificationResult;
                }

                else
                {
                    return NotificationResult.Add(new NotificationError("O codigo informado não existe!", NotificationErrorType.USER));

                }
            }
            catch (Exception ex)
            {
                return NotificationResult.Add(new NotificationError("O codigo informado não existe!", NotificationErrorType.USER));
            }

        }



        public NotificationResult Excluir(Empresa entidade)
        {
            var NotificationResult = new NotificationResult();

            try
            {
                if (entidade.COD_EMPRESA != 0)
                {

                    entidade.DELETADO = DateTime.Now;
                    entidade.ATIVO = 0;

                    if (NotificationResult.IsValid)
                    {
                        _empresa.Update(entidade);
                        NotificationResult.Add("Empresa excluido com Sucesso!");

                        return NotificationResult;
                    }

                    else
                        return NotificationResult.Add(new NotificationError("O codigo informado não existe!", NotificationErrorType.USER));
                }

                else
                    return NotificationResult.Add(new NotificationError("O codigo informado não existe!", NotificationErrorType.USER));
            }

            catch (Exception ex)
            {
                return NotificationResult.Add(new NotificationError(ex.Message));
            }
        }

        public IEnumerable<Empresa> ListarTodos()
        {
            return _empresa.ListarTodos();
        }

        public Empresa ObterEmpresaPorID(int COD_EMPRESA)
        {
            return _empresa.ObterEmpresaPorID(COD_EMPRESA);
        }
    }
}
