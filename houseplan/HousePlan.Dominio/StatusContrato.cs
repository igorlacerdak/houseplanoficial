using System;
using System.Collections.Generic;
using System.Text;

namespace HousePlan.Dominio
{
   public class StatusContrato 
    {
        public StatusContrato()

        {
            CRIADO = DateTime.Now;
            
        }

        public int COD_STATUS { get; set; }
        public string DESCRICAO { get; set; }
        public int ATIVO { get; set; }
        public DateTime CRIADO { get; set; }
        public DateTime ATUALIZADO { get; set; }
        public DateTime DELETADO { get; set; }
        public int CRIADO_POR { get; set; }
        public int ATUALIZADO_POR { get; set; }

    }

}
