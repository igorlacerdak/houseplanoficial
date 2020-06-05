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
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Controllers
{
/// <summary>
/// Usuario Controller Aplicãções em API
/// </summary>
///
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioServico usuarioServico;
        public UsuarioController()
        {
            usuarioServico = new UsuarioServico();
        }
        
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody]Usuario userParam)
        {
            var usuario = await usuarioServico.Authenticate(userParam.LOGIN, userParam.SENHA);

            if (usuario == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(usuario);
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

        [HttpGet("ListarAtivos")]
        public IEnumerable<Usuario> ListarAtivos()
        {
            return usuarioServico.ListarAtivos();
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
        public NotificationResult Excluir(Usuario entidade)
        {
            return usuarioServico.Excluir(entidade);
        }


        [HttpPut("Atualizar")]
        public NotificationResult Atualizar(Usuario entidade)
        {
            return usuarioServico.Atualizar(entidade);
        }

    }
}