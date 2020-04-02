using System;
using System.Collections.Generic;
using HousePlan.Comum.NotificationPattern;
using System.Linq;
using System.Threading.Tasks;
using HousePlan.Dominio;
using HousePlan.Servico;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioServico usuarioServico;
        public UsuarioController()
        {
            usuarioServico = new UsuarioServico();
        }

        [HttpGet]
        public IEnumerable<Usuario> ListarTodos()
        {
            return usuarioServico.ListarTodos();
        }


        [HttpPost]
        
        public NotificationResult Salvar (Usuario entidade)
        {
            return usuarioServico.Salvar(entidade);
        }

        [HttpDelete]
        public string Excluir(Usuario entidade)
        {
            return usuarioServico.Excluir(entidade);
        }
    }
}