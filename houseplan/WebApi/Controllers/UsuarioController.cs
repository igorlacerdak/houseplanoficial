using System;
using System.Collections.Generic;
using HousePlan.Comum.NotificationPattern;
using System.Linq;
using System.Threading.Tasks;
using HousePlan.Dominio;
using HousePlan.Servico;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HousePlan.Comum;

namespace WebApi.Controllers
{
/// <summary>
/// Usuario Controller Aplicãções em API
/// </summary>
///
    [Route("[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioServico usuarioServico;
        public UsuarioController()
        {
            usuarioServico = new UsuarioServico();
        }
        
        /// <summary>
        /// Listar Todos Usuarios Ativos no Sistema
        /// </summary>
        /// <returns></returns>
        
        [HttpGet("ListarTodos")]
        public IEnumerable<Usuario> ListarTodos()
        {
            return usuarioServico.ListarTodos();
        }

        /// <summary>
        /// Inserir usuario no Sistema
        /// </summary>
        /// <param name="entidade"></param>
        /// <returns></returns>
        [HttpPost("Salvar")]  
        public NotificationResult Salvar (Usuario entidade)
        {
            return usuarioServico.Salvar(entidade);
        }


        [HttpDelete("Excluir")]
        public string Excluir(Usuario entidade)
        {
            return usuarioServico.Excluir(entidade);
        }
    }
}