using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoDaVelha
{
    internal class Menu
    {
        public static string escolhaUsuario;



        // # Método mostrar Menu
        public static void MostrarMenu()
        {
            Console.ForegroundColor= ConsoleColor.Black;
            Console.BackgroundColor= ConsoleColor.Red;
            Console.WriteLine("-----------------  BEM-VINDO AO JOGO DA VELHA  -----------------\n");
            Console.ResetColor();

            // # True até ser usuário não querer jogar 
            while (true)
            {
                Console.Write("Deseja jogar o jogo da velha? SIM ou NÃO: ");
                escolhaUsuario = Console.ReadLine().ToUpper();

                if (escolhaUsuario == "SIM")
                {
                    Console.WriteLine("Jogando");
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n------ Encerrando aplicação ------");
                    Console.ResetColor();
                    break;
                }

            }

        }
    }
}
