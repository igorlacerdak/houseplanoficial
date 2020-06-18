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
    public interface IUsuarioServico
    {
        Task<Usuario> Authenticate(string username, string password);
        Task<IEnumerable<Usuario>> GetAll();
    }

    public class UsuarioServico : IUsuarioServico
    {

        private readonly UsuarioRepositorio _usuario;

        private List<Usuario> listaUsuarios = new List<Usuario>
        {
            new Usuario {COD_USUARIO = 1, NOME = "Teste", EMAIL = "igorlacerdasantos@hotmail.com", LOGIN = "igor", SENHA = "igor"}
        };

        public async Task<Usuario> Authenticate(string login, string senha)
        {
            var usuario = await Task.Run(() => listaUsuarios.SingleOrDefault(x => x.LOGIN == login && x.SENHA == senha));

            if (usuario == null)
                return null;

            usuario.SENHA = null;
            return usuario;
        
        }

        public async Task<IEnumerable<Usuario>> GetAll()
        {
            return await Task.Run(() => listaUsuarios.Select(x =>
            {
                x.SENHA = null;
                return x;
            }));
        }

        public UsuarioServico()
        {
            _usuario = new UsuarioRepositorio();
        }

        public Usuario ObterUsuarioPorID(int COD_USUARIO)
        {
            return _usuario.ObterUsuarioPorID(COD_USUARIO);
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

        public NotificationResult Excluir(Usuario entidade)
        {
            var NotificationResult = new NotificationResult();

            try
            {
                if (entidade.COD_USUARIO != 0)
                {

                    entidade.DELETADO = DateTime.Now;
                    entidade.ATIVO = 0;

                    if (NotificationResult.IsValid)
                    {
                        _usuario.Update(entidade);
                        NotificationResult.Add("Usuario excluido com Sucesso!");

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


        public NotificationResult Atualizar(Usuario entidade)
        {
            var NotificationResult = new NotificationResult();

            try
            {
                if (entidade.COD_USUARIO != 0)

                    entidade.COD_USUARIO = entidade.COD_USUARIO;
                    entidade.ATUALIZADO = DateTime.Now;

                if (NotificationResult.IsValid)
                {
                    _usuario.Update(entidade);
                    NotificationResult.Add("Usuario Alterado com Sucesso!");

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

            public IEnumerable<Usuario> ListarTodos()
        {
            return _usuario.ListarTodos();
        }

        public IEnumerable<Usuario> ListarAtivos()
        {
            return _usuario.ListarAtivos();
        }
    }
}
