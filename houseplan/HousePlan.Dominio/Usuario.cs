using System;
using System.Collections.Generic;
using System.Text;

namespace HousePlan.Dominio
{
   public class Usuario
    {
        public Usuario()
        {
            CRIADO = DateTime.Now;
            
        }

        public int COD_USUARIO { get; set; }
        public string NOME { get; set; }
        public string CPF { get; set; }
        public string EMAIL { get; set; }
        public string LOGIN { get; set; }
        public string SENHA { get; set; }
        public string URL_FOTO { get; set; }
        public int ATIVO { get; set; }
        public DateTime CRIADO { get; set; }
        public DateTime? DELETADO { get; set; }
        public DateTime? ATUALIZADO { get; set; }
        public int CRIADO_POR { get; set; }
        public int? ATUALIZADO_POR { get; set; }

    }

}
