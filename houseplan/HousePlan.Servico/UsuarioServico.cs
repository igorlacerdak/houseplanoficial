using HousePlan.Comum.NotificationPattern;
using HousePlan.Dados;
using HousePlan.Comum;
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

                if (entidade.COD_USUARIO == 0)
                {
                    entidade.CRIADO = DateTime.Now;
                    entidade.COD_USUARIO = _usuario.Max_COD_USUARIO() + 1;


                    if (!CPFUtil.Validar(entidade.CPF))
                        NotificationResult.Add(new NotificationError("CPF invalido!", NotificationErrorType.USER));

                    if (!EmailUtil.ValidarEmail(entidade.EMAIL))
                        NotificationResult.Add(new NotificationError("O Email informado é invalido!", NotificationErrorType.USER));

                    if (NotificationResult.IsValid)
                    {
                        _usuario.Adicionar(entidade);
                        NotificationResult.Add("Usuario Cadastro com Sucesso!");  
                    }

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
