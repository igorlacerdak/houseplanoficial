using HousePlan.Dominio;
using HousePlan.Servico;
using System;
using System.Linq;

namespace ConsoleApp
{
    public class Program
    {
        private static UsuarioServico _usuario = new UsuarioServico();
        static void Main(string[] args)
        {
            Console.WriteLine("Imprimindo Usuario");
            Console.WriteLine("");

            var Usuarios = _usuario.ListarTodos();

            Console.WriteLine(Usuario.Registros());
            foreach (Usuario user in Usuarios)
                Console.WriteLine(user);
        }
    }
}
