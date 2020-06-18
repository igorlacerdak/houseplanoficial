using HousePlan.Comum.NotificationPattern;
using HousePlan.Dados;
using HousePlan.Comum;
using Microsoft.Extensions.Options;
using System.Linq;
using HousePlan.Dominio;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HousePlan.Servico
{

    public class EnderecoServico
    {

        private readonly EnderecoRepositorio _endereco;

        public EnderecoServico()
        {
            _endereco = new EnderecoRepositorio();
        }


        public NotificationResult Salvar(UsuarioEndereco entidade)
        {
            var NotificationResult = new NotificationResult();

            try
            {

                if (entidade.COD_ENDERECO == 0)
                {
                    entidade.CRIADO = DateTime.Now;
                    entidade.COD_ENDERECO = _endereco.Max_COD_ENDERECO() + 1;


                    if (entidade.CEP == null )
                        NotificationResult.Add(new NotificationError("CEP invalido!", NotificationErrorType.USER));

                    if (NotificationResult.IsValid)
                    {
                        _endereco.Adicionar(entidade);
                        NotificationResult.Add("Endereço Cadastro com Sucesso!");  
                    }

                    return NotificationResult;
                }

                else
                    return NotificationResult.Add(new NotificationError("Erro ao realizar cadastro!", NotificationErrorType.USER)); ;
            }

            catch(Exception ex)
            {
                return NotificationResult.Add(new NotificationError(ex.Message));
            }
        }

        public NotificationResult Excluir(UsuarioEndereco entidade)
        {
            var NotificationResult = new NotificationResult();

            try
            {
                if (entidade.COD_ENDERECO != 0)
                {

                    entidade.DELETADO = DateTime.Now;
                    entidade.ATIVO = 0;

                    if (NotificationResult.IsValid)
                    {
                        _endereco.Update(entidade);
                        NotificationResult.Add("Endereço excluido com Sucesso!");

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


        public NotificationResult Atualizar(UsuarioEndereco entidade)
        {
            var NotificationResult = new NotificationResult();

            try
            {
                if (entidade.COD_ENDERECO != 0)

                    entidade.COD_ENDERECO = entidade.COD_ENDERECO;
                    entidade.ATUALIZADO = DateTime.Now;

                if (NotificationResult.IsValid)
                {
                    _endereco.Update(entidade);
                    NotificationResult.Add("Endereço Alterado com Sucesso!");

                    return NotificationResult;
                }

                else
                {
                    return NotificationResult.Add(new NotificationError("O codigo informado não existe!", NotificationErrorType.USER));

                }
            }
            catch(Exception ex)
            {
                return NotificationResult.Add(new NotificationError("O codigo informado não existe!", NotificationErrorType.USER));
            }

        }

            public IEnumerable<UsuarioEndereco> ListarTodos()
        {
            return _endereco.ListarTodos();
        }

        public IEnumerable<UsuarioEndereco> ListarAtivos()
        {
            return _endereco.ListarAtivos();
        }
    }
}
