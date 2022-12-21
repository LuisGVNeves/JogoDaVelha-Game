using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoDaVelha
{
    internal class Menu
    {

        // # Método mostrar Menu
        public static void MostrarMenu()
        {
            Console.ForegroundColor= ConsoleColor.Black;
            Console.BackgroundColor= ConsoleColor.Red;
            Console.WriteLine("-----------------  BEM-VINDO AO JOGO DA VELHA  -----------------\n");
            Console.ResetColor();
        }
    }
}
