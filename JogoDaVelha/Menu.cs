using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoDaVelha
{
    internal class Menu
    {
        // # Variável escolha do usuário
        public static string escolhaUsuario;

        // # Método mostrar Menu
        public static void MostrarMenu()
        {
            // # True até ser usuário não querer jogar 
            while (true)
            {
                Console.Write("Deseja jogar o jogo da velha? SIM ou NÃO: ");
                escolhaUsuario = Console.ReadLine().ToUpper();

                if (escolhaUsuario == "SIM")
                {
                    // # Iniciar a entrada inicial do Game
                    Tabuleiro.IniciarEntradaDoJogo();

                    // # Preencher o tabuleiro com os números
                    Tabuleiro.PreencherTabuleiro();

                    // # Chamar a Função de chamar o tabuleiro para jogar
                    Tabuleiro.MostrarTabuleiro();

                    // # Iniciar o jogo
                    Tabuleiro.IniciarJogo();

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
