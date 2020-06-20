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
    public class ProjetoController : ControllerBase
    {
        private readonly ProjetoServico projetoServico;

        public ProjetoController()
        {
            projetoServico = new ProjetoServico();
        }

        [HttpGet("Empresa")]

        public Projeto ProjetoEmpresa(int COD_PROJETO)
        {
            return projetoServico.ProjetoEmpresa(COD_PROJETO);
        }


        [HttpPost("Salvar")]
        public NotificationResult Salvar(Projeto entidade)
        {
            return projetoServico.Salvar(entidade);
        }


        [HttpDelete("Excluir")]
        public NotificationResult Excluir(Projeto entidade)
        {
            return projetoServico.Excluir(entidade);
        }


        [HttpPut("Atualizar")]
        public NotificationResult Atualizar(Projeto entidade)
        {
            return projetoServico.Atualizar(entidade);
        }

    }
}