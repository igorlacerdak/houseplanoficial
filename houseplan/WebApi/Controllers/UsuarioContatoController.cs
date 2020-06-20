using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HousePlan.Comum.NotificationPattern;
using HousePlan.Dominio;
using HousePlan.Servico;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsuarioContatoController : ControllerBase
    {
        private readonly UsuarioContatoServico usuarioContatoServico;

        public UsuarioContatoController()
        {
            usuarioContatoServico = new UsuarioContatoServico();
        }

        [HttpGet("UsuarioContato")]

        public IEnumerable<UsuarioContato> ObterContatoPorUsuario(int COD_USUARIO)
        {
            return usuarioContatoServico.ObterContatoPorUsuario(COD_USUARIO);
        }


        [HttpPost("Salvar")]
        public NotificationResult Salvar(UsuarioContato entidade)
        {
            return usuarioContatoServico.Salvar(entidade);
        }


        [HttpDelete("Excluir")]
        public NotificationResult Excluir(UsuarioContato entidade)
        {
            return usuarioContatoServico.Excluir(entidade);
        }


        [HttpPut("Atualizar")]
        public NotificationResult Atualizar(UsuarioContato entidade)
        {
            return usuarioContatoServico.Atualizar(entidade);
        }

    }
}