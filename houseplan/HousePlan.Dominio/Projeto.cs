﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HousePlan.Dominio
{
   public class Projeto 
    {
        public Projeto()

        {
            CRIADO = DateTime.Now;
            
        }

        public int COD_PROJETO { get; set; }
        public int COD_EMPRESA { get; set; }
        public string DESCRICAO { get; set; }
        public string TITULO { get; set; }
        public string STATUS { get; set; }
        public string AUTOR { get; set; }
        public string METRAGEM { get; set; }
        public decimal VALOR { get; set; }
        public int ATIVO { get; set; }
        public DateTime CRIADO { get; set; }
        public DateTime ATUALIZADO { get; set; }
        public DateTime DELETADO { get; set; }
        public int CRIADO_POR { get; set; }
        public int ATUALIZADO_POR { get; set; }

        public Empresa Empresa { get; set; }

    }

}
