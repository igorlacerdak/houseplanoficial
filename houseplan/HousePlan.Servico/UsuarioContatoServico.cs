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

    public class UsuarioContatoServico
    {

        private readonly UsuarioContatoRepositorio _usuarioContato;

        public UsuarioContatoServico()
        {
            _usuarioContato = new UsuarioContatoRepositorio();
        }


        public NotificationResult Salvar(UsuarioContato entidade)
        {
            var NotificationResult = new NotificationResult();

            try
            {

                if (entidade.COD_CONTATO == 0)
                {
                    entidade.CRIADO = DateTime.Now;
                    entidade.COD_CONTATO = _usuarioContato.Max_COD_CONTATO() + 1;


                    if (entidade.COD_CONTATO_TIPO == 0 )
                        NotificationResult.Add(new NotificationError("Tipo de Contato invalido!", NotificationErrorType.USER));

                    if (NotificationResult.IsValid)
                    {
                        _usuarioContato.Adicionar(entidade);
                        NotificationResult.Add("Contato Cadastro com Sucesso!");  
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

        public NotificationResult Excluir(UsuarioContato entidade)
        {
            var NotificationResult = new NotificationResult();

            try
            {
                if (entidade.COD_CONTATO != 0)
                {

                    entidade.DELETADO = DateTime.Now;
                    entidade.ATIVO = 0;

                    if (NotificationResult.IsValid)
                    {
                        _usuarioContato.Update(entidade);
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


        public NotificationResult Atualizar(UsuarioContato entidade)
        {
            var NotificationResult = new NotificationResult();

            try
            {
                if (entidade.COD_CONTATO != 0)

                    entidade.COD_CONTATO = entidade.COD_CONTATO;
                    entidade.ATUALIZADO = DateTime.Now;

                if (NotificationResult.IsValid)
                {
                    _usuarioContato.Update(entidade);
                    NotificationResult.Add("Contato Alterado com Sucesso!");

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

            public IEnumerable<UsuarioContato> ListarTodos()
        {
            return _usuarioContato.ListarTodos();
        }

        public IEnumerable<UsuarioContato> ListarAtivos()
        {
            return _usuarioContato.ListarAtivos();
        }
    }
}
