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

        public NotificationResult Atualizar(Projeto entidade)
        {
            var NotificationResult = new NotificationResult();

            try
            {
                if (entidade.COD_PROJETO != 0)

                    entidade.COD_PROJETO = entidade.COD_PROJETO;
                    entidade.ATUALIZADO = DateTime.Now;

                if (NotificationResult.IsValid)
                {
                    _projeto.Update(entidade);
                    NotificationResult.Add("Projeto Alterado com Sucesso!");

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

        public NotificationResult Excluir(Projeto entidade)
        {
            var NotificationResult = new NotificationResult();

            try
            {
                if (entidade.COD_PROJETO != 0)
                {

                    entidade.DELETADO = DateTime.Now;
                    entidade.ATIVO = 0;

                    if (NotificationResult.IsValid)
                    {
                        _projeto.Update(entidade);
                        NotificationResult.Add("Projeto excluido com Sucesso!");

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

        public IEnumerable<Usuario> ListarTodos()
        {
            return _projeto.ListarTodos();
        }

        public Projeto ProjetoEmpresa(int COD_PROJETO)
        {
            return _projeto.ProjetoEmpresa(COD_PROJETO);
        }
    }
}
