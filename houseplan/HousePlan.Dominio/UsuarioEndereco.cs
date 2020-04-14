using System;
using System.Collections.Generic;
using System.Text;

namespace HousePlan.Dominio
{
   public class UsuarioEndereco
    {
        public UsuarioEndereco()

        {
            CRIADO = DateTime.Now;
            
        }
        public int COD_ENDERECO { get; set; }
        public int COD_USUARIO { get; set; }
        public string PAIS { get; set; }
        public string ESTADO { get; set; }
        public string CIDADE { get; set; }
        public string BAIRRO { get; set; }
        public string LOGRADOURO { get; set; }
        public string NUMERO { get; set; }
        public string CEP { get; set; }
        public string REFERENCIA { get; set; }
        public int ATIVO { get; set; }
        public DateTime CRIADO { get; set; }
        public DateTime ATUALIZADO { get; set; }
        public DateTime DELETADO { get; set; }
        public int CRIADO_POR { get; set; }
        public int ATUALIZADO_POR { get; set; }

        public Usuario Usuario { get; set; }

    }

}
