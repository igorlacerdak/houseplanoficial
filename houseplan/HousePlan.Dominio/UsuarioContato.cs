using System;
using System.Collections.Generic;
using System.Text;

namespace HousePlan.Dominio
{
   public class UsuarioContato 
    {
        public UsuarioContato()

        {
            CRIADO = DateTime.Now;
            
        }
        public int COD_CONTATO { get; set; }
        public int COD_USUARIO { get; set; }
        public int COD_CONTATO_TIPO { get; set; }
        public string CONTATO { get; set; }
        public int ATIVO { get; set; }
        public DateTime CRIADO { get; set; }
        public DateTime ATUALIZADO { get; set; }
        public DateTime DELETADO { get; set; }
        public int CRIADO_POR { get; set; }
        public int ATUALIZADO_POR { get; set; }

        public Usuario Usuario { get; set; }
        public ContatoTipo ContatoTipo { get; set; }


    }

}
