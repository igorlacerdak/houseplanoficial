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


        public bool ValidarCPF()
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            CPF = CPF.Trim();
            CPF = CPF.Replace(".", "").Replace("-", "");
            if (CPF.Length != 11)
                return false;
            tempCpf = CPF.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return CPF.EndsWith(digito);
        }


        public static string Registros()
        {
            return "ID\t\tNOME\t\tCPF\t\tEMAIL\t\tCRIADO";
        }

        public override string ToString()
        {
            return $"{COD_USUARIO}\t\t{NOME}\t\t{CPF}\t\t{EMAIL}\t\t{CRIADO}";
        }

    }

}
