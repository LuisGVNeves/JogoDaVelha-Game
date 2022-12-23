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
        // # Instanciação dos jogadores
        public static Jogador jogador1 = new Jogador("","", 0);
        public static Jogador jogador2 = new Jogador("","", 0);


        // # Iniciar entrada do Game
        public static void IniciarEntradaDoJogo()
        {
            Console.Write("\nDigite o nome do 1 jogador: ");
            jogador1.nome = Console.ReadLine();

            Console.Write("Digite o nome do 2 jogador: ");
            jogador2.nome = Console.ReadLine();
            
            Console.Write("\nJogador 1 qual você quer ser? letra X ou O: ");
            jogador1.letraJogo = Console.ReadLine().ToUpper();

            if(jogador1.letraJogo == "X")
            {
                jogador2.letraJogo = "O";
            }
            else
            {
                jogador1.letraJogo = "O";
                jogador2.letraJogo = "X";
            }

            Console.WriteLine($"\nJogador {jogador1.nome} começa com: {jogador1.letraJogo}");
            Console.WriteLine($"\nJogador {jogador2.nome} começa com: {jogador2.letraJogo}\n\n");
        }

        // # Criar a Matriz - 3 linhas e 3 colunas
        public static string[,] tabuleiro = new string[3, 3];

        // # Preencher Tabuleiro com os números
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

        // # Mostrar Tabuleiro
        public static void MostrarTabuleiro()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($" {tabuleiro[0,0]}  | {tabuleiro[0,1]} |  {tabuleiro[0,2]}");
            Console.WriteLine($" {tabuleiro[1,0]}  | {tabuleiro[1,1]} |  {tabuleiro[1,2]}");
            Console.WriteLine($" {tabuleiro[2,0]}  | {tabuleiro[2,1]} |  {tabuleiro[2,2]}");
            Console.ResetColor();


        }

        // # Variável publica para verificar a matriz
        public static bool linhaHorizontalX;
        
        // # Método que verifica se a vitória foi horizontal
        public static void VerificaVitoriaHorizontal()
        {
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

                }
            }
            if (jogador1.letraJogo == "X" && linhaHorizontalX)
            {
                Console.WriteLine($"\nJogador {jogador1.nome} Venceu a partida :D");
            }
            if(jogador2.letraJogo == "X" && linhaHorizontalX)
            {
                Console.WriteLine($"\nJogador {jogador2.nome} Venceu a partida :D");
            }
        }


        public static void IniciarJogo()
        {
            bool verificador = true;
            while (verificador)
            {
                // # Dar opção pro usuário qual valor da matriz ele quer prencher :
                Console.Write($"\nJogador 1 {jogador1.nome} - Escolha o valor do tabuleiro que você quer preencher {jogador1.letraJogo}: ");
                string escolhaJogador1 = Console.ReadLine();

                Console.Write($"\nJogador 2 {jogador2.nome} - Escolha o valor do tabuleiro que você quer preencher com {jogador2.letraJogo}: ");
                string escolhaJogador2 = Console.ReadLine();

                /*
                    - Aqui eu vou percorrer a matriz, e comparar e ver se é igual a escolha do jogador
                    se for, eu vou substituir o número pela letra e mostrar o tabuleiro de novo
                */
                for (int linhas = 0; linhas < 3; linhas++)
                {
                    for (int colunas = 0; colunas < 3; colunas++)
                    {
                        if (tabuleiro[linhas,colunas] == escolhaJogador1)
                        {
                            tabuleiro[linhas, colunas] = jogador1.letraJogo;
                        }
                        if (tabuleiro[linhas, colunas] == escolhaJogador2)
                        {
                            tabuleiro[linhas, colunas] = jogador2.letraJogo;
                        }
                    }
                }

                // # Quando matriz for trocada de número por X ou O, a função mostra o tabuleiro para mostrar como está o jogo
                MostrarTabuleiro();

                // # Métodos que verificam os preenchimentos e vitória, se tudo tiver bem, break loop infinito
                VerificaVitoriaHorizontal();
                

            }


        }

    }
}
