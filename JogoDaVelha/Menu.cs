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
                    // # Criação do 1 e 2 jogador, sem nome e com pontuação 0
                    Jogador jogador1 = new Jogador("",0);
                    Jogador jogador2 = new Jogador("",0);

                    Console.Write("\nDigite o nome do 1 jogador: ");
                    jogador1.nome = Console.ReadLine();

                    Console.Write("Digite o nome do 2 jogador: ");
                    jogador2.nome = Console.ReadLine();

                    // # Chamar a Função de chamar o tabuleiro para jogar
                    Tabuleiro.CriarTabuleiro();

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
