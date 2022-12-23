using JogoDaVelha;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoDaVelha
{
    internal class Tabuleiro
    {
        // # Criar a Matriz - 3 linhas e 3 colunas
        public static string[,] tabuleiro = new string[3, 3];


        // # Método que preenche tabuleiro com números, para o usuário preencher com X ou O
        public static void PreencherTabuleiro()
        {
            for (int linhas = 0; linhas<3; linhas++)
		    {
                for (int colunas = 0; colunas <3; colunas++)
                {
                    // # Linha 1
                    tabuleiro[0,0] = "1";
                    tabuleiro[0,1] = "2";
                    tabuleiro[0,2] = "3";

                    // # Linha 2
                    tabuleiro[1,0] = "4";
                    tabuleiro[1,1] = "5";
                    tabuleiro[1,2] = "6";


                    // # Linha 3
                    tabuleiro[2, 0] = "7";
                    tabuleiro[2, 1] = "8";
                    tabuleiro[2, 2] = "9";
                }
		    }
        }


        // # Método Mostrar Tabuleiro
        public static void MostrarTabuleiro()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($" {tabuleiro[0,0]}  | {tabuleiro[0,1]} |  {tabuleiro[0,2]}");
            Console.WriteLine($" {tabuleiro[1,0]}  | {tabuleiro[1,1]} |  {tabuleiro[1,2]}");
            Console.WriteLine($" {tabuleiro[2,0]}  | {tabuleiro[2,1]} |  {tabuleiro[2,2]}\n");
            Console.ResetColor();
        }


        // # Variável publica para verificar a matriz na horizontal
        public static bool linhaHorizontalX;
        public static bool linhaHorizontalO;

        // # Método que verifica se a vitória foi horizontal
        public static void VerificaVitoriaHorizontal()
        {
            // Percorro a matriz e verifico se as linhas estão X X X  ou  O O O, e vai retornar um booleano true ou false
            for (int linhas = 0; linhas < 3; linhas++)
            {
                for (int colunas = 0; colunas < 3; colunas++)
                {
                    /*
                     # Verifica se a primeira, segunda, terceira linha da matriz
                     teve as linhas prenchidas na ordem orizontal X X X
                    */
                    linhaHorizontalX = 
                    (
                        tabuleiro[0, 0] == "X" &&
                        tabuleiro[0, 1] == "X" &&
                        tabuleiro[0, 2] == "X"
                    )
                    ||
                    (
                        tabuleiro[1, 0] == "X" &&
                        tabuleiro[1, 1] == "X" &&
                        tabuleiro[1, 2] == "X"
                     )
                     ||
                     (
                        tabuleiro[2, 0] == "X" &&
                        tabuleiro[2, 1] == "X" &&
                        tabuleiro[2, 2] == "X"
                     );

                    /*
                      # Verifica se a primeira, segunda, terceira linha da matriz
                      teve as linhas prenchidas na ordem orizontal O O O
                     */
                    linhaHorizontalO =
                    (
                        tabuleiro[0, 0] == "O" &&
                        tabuleiro[0, 1] == "O" &&
                        tabuleiro[0, 2] == "O"
                    )
                    ||
                    (
                        tabuleiro[1, 0] == "O" &&
                        tabuleiro[1, 1] == "O" &&
                        tabuleiro[1, 2] == "O"
                     )
                     ||
                     (
                        tabuleiro[2, 0] == "O" &&
                        tabuleiro[2, 1] == "O" &&
                        tabuleiro[2, 2] == "O"
                     );

                }
            }
        }


        // # Variáveis que vão guardar a escolha do jogador caso seja X ou O
        public static string escolhaJogador1;
        public static string escolhaJogador2;


        // # Método que inicia jogo
        public static void IniciarJogo()
        {
            while (true)
            {
                // # Dar opção pro usuário qual valor da matriz ele quer prencher :

                Console.Write($"\nJogador 1 {Program.jogador1.nome} - Escolha o valor do tabuleiro que você quer preencher {Program.jogador1.letraJogo}: ");
                escolhaJogador1 = Console.ReadLine();

                Console.Write($"\nJogador 2 {Program.jogador2.nome} - Escolha o valor do tabuleiro que você quer preencher com {Program.jogador2.letraJogo}: ");
                escolhaJogador2 = Console.ReadLine();


                //- Aqui eu vou percorrer a matriz, e comparar e ver se é igual a escolha do jogador se for, eu vou substituir o número pela letra
                
                for (int linhas = 0; linhas < 3; linhas++)
                {
                    for (int colunas = 0; colunas < 3; colunas++)
                    {
                        if (tabuleiro[linhas,colunas] == escolhaJogador1)
                        {
                            tabuleiro[linhas, colunas] = Program.jogador1.letraJogo;
                        }
                        if (tabuleiro[linhas, colunas] == escolhaJogador2)
                        {
                            tabuleiro[linhas, colunas] = Program.jogador2.letraJogo;
                        }
                    }
                }

                // # Quando matriz for trocada de número por X ou O, invoco a função mostra o tabuleiro para mostrar como está o jogo atual
                MostrarTabuleiro();

                // # Método que verifica se a vitória é horizontal
                VerificaVitoriaHorizontal();


                // # Mostra mensagem caso a vitória tenha sido horizontal tanto de X como de O
                if (Program.jogador1.letraJogo == "X" && linhaHorizontalX)
                {
                    Console.WriteLine($"\nJogador {Program.jogador1.nome} Venceu a partida :D");
                    break;
                }
                if (Program.jogador1.letraJogo == "O" && linhaHorizontalO)
                {
                    Console.WriteLine($"\nJogador {Program.jogador1.nome} Venceu a partida :D");
                    break;
                }
                if (Program.jogador2.letraJogo == "X" && linhaHorizontalX)
                {
                    Console.WriteLine($"\nJogador {Program.jogador2.nome} Venceu a partida :D");
                    break;
                }
                if (Program.jogador2.letraJogo == "O" && linhaHorizontalO)
                {
                    Console.WriteLine($"\nJogador {Program.jogador2.nome} Venceu a partida :D");
                    break;
                }
            }


        }

    }
}
