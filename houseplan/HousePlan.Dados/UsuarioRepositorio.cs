using HousePlan.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace HousePlan.Dados
{
    public class UsuarioRepositorio : RepositorioBase<Usuario>
    {
        public IEnumerable<Usuario> ListarTodos()
        {
            return Contexto
                .Usuario
                .Where(f => f.COD_USUARIO != 0); 
        }

        public int Max_COD_USUARIO()
        {
            return Contexto
                .Usuario
                .Max(f => f.COD_USUARIO);
        }

        public IEnumerable<Usuario> ListarAtivos()
        {
            return Contexto
                .Usuario
                .Where(f => f.ATIVO == 1);
        }

        public Usuario ObterUsuarioPorID(int COD_USUARIO)
        {
            return Contexto
                .Usuario.FirstOrDefault(f => f.COD_USUARIO == COD_USUARIO);
        }

        public async Task<List<Usuario>> ObterUsuarios(Usuario filtro)
        {
            var query = Contexto.Usuario.AsTracking();
            if (filtro.COD_USUARIO > 0)
                query = query.Where(w => w.COD_USUARIO == filtro.COD_USUARIO);
            if (!string.IsNullOrEmpty(filtro.NOME))
                query = query.Where(w => filtro.NOME.Contains(w.NOME));
            return await query.ToListAsync();
        }

        public Usuario Alterar(Usuario dbUsuario ,Usuario usuario)
        {
            dbUsuario.NOME = usuario.NOME;
            dbUsuario.CPF = usuario.CPF;
            dbUsuario.EMAIL = usuario.EMAIL;
            dbUsuario.LOGIN = usuario.LOGIN;

            Contexto.SaveChanges();

            return dbUsuario;

        }

        public Usuario Inserir(Usuario usuario)
        {
            Contexto.Add(usuario);
            Contexto.SaveChanges();

            return usuario;
        }


        public Usuario Excluir(Usuario usuario)
        {
            usuario.ATIVO = 1;
            Contexto.SaveChanges();

            return usuario;
        }

    }
}