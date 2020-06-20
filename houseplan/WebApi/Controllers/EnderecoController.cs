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
    public class EnderecoController : ControllerBase
    {
        private readonly EnderecoServico enderecoServico;

        public EnderecoController()
        {
            enderecoServico = new EnderecoServico();
        }

        [HttpGet("EnderecoUsuario")]

        public UsuarioEndereco ObterUsuarioEndereco(int COD_USUARIO)
        {
            return enderecoServico.ObterEnderecoUsuario(COD_USUARIO);
        }


        [HttpPost("Salvar")]
        public NotificationResult Salvar(UsuarioEndereco entidade)
        {
            return enderecoServico.Salvar(entidade);
        }


        [HttpDelete("Excluir")]
        public NotificationResult Excluir(UsuarioEndereco entidade)
        {
            return enderecoServico.Excluir(entidade);
        }


        [HttpPut("Atualizar")]
        public NotificationResult Atualizar(UsuarioEndereco entidade)
        {
            return enderecoServico.Atualizar(entidade);
        }
    }
}