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
    public class EmpresaController : ControllerBase
    {
        private readonly EmpresaServico empresaServico;

        public EmpresaController()
        {
            empresaServico = new EmpresaServico();
        }

        [HttpGet("Empresa")]

        public Empresa ObterEmpresaPorID(int COD_USUARIO)
        {
            return empresaServico.ObterEmpresaPorID(COD_USUARIO);
        }


        [HttpPost("Salvar")]
        public NotificationResult Salvar(Empresa entidade)
        {
            return empresaServico.Salvar(entidade);
        }


        [HttpDelete("Excluir")]
        public NotificationResult Excluir(Empresa entidade)
        {
            return empresaServico.Excluir(entidade);
        }


        [HttpPut("Atualizar")]
        public NotificationResult Atualizar(Empresa entidade)
        {
            return empresaServico.Atualizar(entidade);
        }
    }
}