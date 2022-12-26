﻿using JogoDaVelha;
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
            Console.WriteLine($"\n {tabuleiro[0,0]}  | {tabuleiro[0,1]} |  {tabuleiro[0,2]}");
            Console.WriteLine($" {tabuleiro[1,0]}  | {tabuleiro[1,1]} |  {tabuleiro[1,2]}");
            Console.WriteLine($" {tabuleiro[2,0]}  | {tabuleiro[2,1]} |  {tabuleiro[2,2]}\n");
            
            Console.ResetColor();
        }


        // # Método para perguntar ao usuário se ele deseja X ou O para preencher na matriz e trocar os números da matriz pela escolha do jogador X ou O
        public static void EscolhaJogador(string jogarDeNovo)
        {
            string escolhaJogador1;
            string escolhaJogador2;

            Console.Write($"\nJogador {Program.jogador1.nome} - Escolha o valor do tabuleiro que você quer preencher {Program.jogador1.letraJogo}: ");
            escolhaJogador1 = Console.ReadLine();

            Console.Write($"\nJogador {Program.jogador2.nome} - Escolha o valor do tabuleiro que você quer preencher com {Program.jogador2.letraJogo}: ");
            escolhaJogador2 = Console.ReadLine();

            /*
             - Se o intervalo[1-9] estiver preenchido com numeros o código ocorre normalmente, porém, se não estiver, quer dizer que ele já está lotado de X e O, e se até o número 8 nenhuma função de checar vitoria, chegar empate entrar, então quer dizer que deu velha
             - Aqui eu vou percorrer a matriz, e comparar e ver se é igual a escolha do jogador se for, eu vou substituir o número do intervalo [1-9] pela letra

            */
            for (int linhas = 0; linhas < 3; linhas++)
            {
                for (int colunas = 0; colunas < 3; colunas++)
                {

                    if ((tabuleiro[0, 0] == "1") || (tabuleiro[0, 0] == "1") ||
                       (tabuleiro[0, 1] == "2") || (tabuleiro[0, 1] == "2") ||
                       (tabuleiro[0, 2] == "3") || (tabuleiro[0, 2] == "3") ||
                       (tabuleiro[1, 0] == "4") || (tabuleiro[1, 0] == "4") ||
                       (tabuleiro[1, 1] == "5") || (tabuleiro[1, 1] == "5") ||
                       (tabuleiro[1, 2] == "6") || (tabuleiro[1, 2] == "6") ||
                       (tabuleiro[2, 0] == "7") || (tabuleiro[2, 0] == "7") ||
                       (tabuleiro[2, 1] == "8") || (tabuleiro[2, 1] == "8"))
                    {
                        if(escolhaJogador1 == escolhaJogador2)
                        {
                            Console.Write("\nCampo já preenchido, por favor digite um campo que não foi usado: ");
                            string novoCampo = Console.ReadLine();

                            escolhaJogador1 = novoCampo;
                            tabuleiro[linhas, colunas] = Program.jogador1.letraJogo;
                        }
                        else if(escolhaJogador2 == escolhaJogador1)
                        {
                            Console.Write("\nCampo já preenchido, por favor digite um campo que não foi usado: ");
                            string novoCampo = Console.ReadLine();

                            escolhaJogador2 = novoCampo;
                            tabuleiro[linhas, colunas] = Program.jogador2.letraJogo;
                        }
                        else
                        {
                            if (tabuleiro[linhas, colunas] == escolhaJogador1)
                            {
                                tabuleiro[linhas, colunas] = Program.jogador1.letraJogo;
                            }
                            if (tabuleiro[linhas, colunas] == escolhaJogador2)
                            {
                                tabuleiro[linhas, colunas] = Program.jogador2.letraJogo;
                            }
                        }

                    }
                    else
                    {
                        MostrarTabuleiro();
                        Console.WriteLine("Deu velha");
                        JogarDeNovo(jogarDeNovo);
                    }


                }
            }


        }


        // # Método para perguntar ao usuário se ele deseja jogar de novo
        public static void JogarDeNovo(string jogarDeNovo)
        {
            Console.Write("Deseja jogar de novo SIM ou NÃO: ");
            jogarDeNovo = Console.ReadLine().ToUpper();

            if (jogarDeNovo == "SIM")
            {
                Program.IniciarJogo();
            }
            else
            {
                System.Environment.Exit(0);
            }
        }
        
        
        // # Método para verificar matriz na horizontal e ver se teve X X X ou O O O  na horizontal
        public static void VerificaVitoriaHorizontal(string jogarDeNovo)
        {
            bool linhaHorizontalX = true;
            bool linhaHorizontalO = true;

            // Percorro a matriz e verifico se as linhas estão X X X  ou  O O O, e vai retornar um booleano true ou false
            for (int linhas = 0; linhas < 3; linhas++)
            {
                for (int colunas = 0; colunas < 3; colunas++)
                {
                    // # Verifica se a primeira, segunda, terceira linha da matriz teve as linhas prenchidas na ordem orizontal X X X
                    
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


                    // # Verifica se a primeira, segunda, terceira linha da matriz teve as linhas prenchidas na ordem orizontal O O  O
                    
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

            // # Mostra mensagem caso a vitória tenha sido horizontal tanto de X como de O
            if (Program.jogador1.letraJogo == "X" && linhaHorizontalX)
            {
                Console.WriteLine($"\nJogador {Program.jogador1.nome} Venceu a partida :D");

                MostrarTabuleiro();
                PreencherTabuleiro();
                JogarDeNovo(jogarDeNovo);

            }
            if (Program.jogador1.letraJogo == "O" && linhaHorizontalO)
            {
                Console.WriteLine($"\nJogador {Program.jogador1.nome} Venceu a partida :D");

                MostrarTabuleiro();
                PreencherTabuleiro();
                JogarDeNovo(jogarDeNovo);
            }
            if (Program.jogador2.letraJogo == "X" && linhaHorizontalX)
            {
                Console.WriteLine($"\nJogador {Program.jogador2.nome} Venceu a partida :D");

                MostrarTabuleiro();
                PreencherTabuleiro();
                JogarDeNovo(jogarDeNovo);
            }
            if (Program.jogador2.letraJogo == "O" && linhaHorizontalO)
            {
                Console.WriteLine($"\nJogador {Program.jogador2.nome} Venceu a partida :D");
              
                MostrarTabuleiro();
                PreencherTabuleiro();
                JogarDeNovo(jogarDeNovo);
            }

        }



        // # Método para verificar matriz na vertical e ver se teve X X X ou O O O  na vertical
        public static void VerificaVitoriaVertical(string jogarDeNovo)
        {
            bool linhaVerticalX = true;
            bool linhaVerticalO = true;

            for (int linhas = 0; linhas < 3; linhas++)
            {
                for (int colunas = 0; colunas < 3; colunas++)
                {
                    // Coluna vertical verificando X

                    linhaVerticalX =
                    (
                        tabuleiro[0, 0] == "X" &&
                        tabuleiro[1, 0] == "X" &&
                        tabuleiro[2, 0] == "X"
                    )
                    ||
                    (
                        tabuleiro[0, 1] == "X" &&
                        tabuleiro[1, 1] == "X" &&
                        tabuleiro[2, 1] == "X"
                     )
                     ||
                     (
                        tabuleiro[0, 2] == "X" &&
                        tabuleiro[1, 2] == "X" &&
                        tabuleiro[2, 2] == "X"
                     );

                    // Coluna vertical verificando O
                    linhaVerticalO =
                    (
                        tabuleiro[0, 0] == "O" &&
                        tabuleiro[1, 0] == "O" &&
                        tabuleiro[2, 0] == "O"
                    )
                    ||
                    (
                        tabuleiro[0, 1] == "O" &&
                        tabuleiro[1, 1] == "O" &&
                        tabuleiro[2, 1] == "O"
                     )
                     ||
                     (
                        tabuleiro[0, 2] == "O" &&
                        tabuleiro[1, 2] == "O" &&
                        tabuleiro[2, 2] == "O"
                     );

                }
            }

            // # Mostra mensagem caso a vitória tenha sido vertical tanto de X como de O
            if (Program.jogador1.letraJogo == "X" && linhaVerticalX)
            {
                Console.WriteLine($"\nJogador {Program.jogador1.nome} Venceu a partida :D");
                MostrarTabuleiro();
                PreencherTabuleiro();
                JogarDeNovo(jogarDeNovo);
            }
            if (Program.jogador1.letraJogo == "O" && linhaVerticalO)
            {
                Console.WriteLine($"\nJogador {Program.jogador1.nome} Venceu a partida :D");
                MostrarTabuleiro();
                PreencherTabuleiro();
                JogarDeNovo(jogarDeNovo);
            }
            if (Program.jogador2.letraJogo == "X" && linhaVerticalX)
            {
                Console.WriteLine($"\nJogador {Program.jogador2.nome} Venceu a partida :D");
                MostrarTabuleiro();
                PreencherTabuleiro();
                JogarDeNovo(jogarDeNovo);
            }
            if (Program.jogador2.letraJogo == "O" && linhaVerticalO)
            {
                Console.WriteLine($"\nJogador {Program.jogador2.nome} Venceu a partida :D");
                MostrarTabuleiro();
                PreencherTabuleiro();
                JogarDeNovo(jogarDeNovo);
            }

        }



        // # Método para verificar matriz na diagonal e ver se teve X X X ou O O O  na diagonal
        public static void VerificaVitoriaDiagonal(string jogarDeNovo)
        {
            bool linhaDiagonalX = true;
            bool linhaDiagonalO = true;

            for (int linhas = 0; linhas < 3; linhas++)
            {
                for (int colunas = 0; colunas < 3; colunas++)
                {
                    // Coluna diagonal verificando X

                    linhaDiagonalX =
                    (
                        tabuleiro[2, 0] == "X" &&
                        tabuleiro[1, 1] == "X" &&
                        tabuleiro[0, 2] == "X"
                    )
                    ||
                    (
                        tabuleiro[0, 2] == "X" &&
                        tabuleiro[1, 1] == "X" &&
                        tabuleiro[2, 0] == "X"
                     )
                     ||
                     (
                        tabuleiro[0, 0] == "X" &&
                        tabuleiro[1, 1] == "X" &&
                        tabuleiro[2, 2] == "X"
                     )
                     ||
                     (
                        tabuleiro[2, 2] == "X" &&
                        tabuleiro[1, 1] == "X" &&
                        tabuleiro[0, 0] == "X"
                     );

                    // Coluna vertical verificando O
                    linhaDiagonalO =
                    (
                        tabuleiro[2, 0] == "O" &&
                        tabuleiro[1, 1] == "O" &&
                        tabuleiro[0, 2] == "O"
                    )
                    ||
                    (
                        tabuleiro[0, 2] == "O" &&
                        tabuleiro[1, 1] == "O" &&
                        tabuleiro[2, 0] == "O"
                     )
                     ||
                     (
                        tabuleiro[0, 0] == "O" &&
                        tabuleiro[1, 1] == "O" &&
                        tabuleiro[2, 2] == "O"
                     )
                     ||
                     (
                        tabuleiro[2, 2] == "O" &&
                        tabuleiro[1, 1] == "O" &&
                        tabuleiro[0, 0] == "O"
                     );

                }
            }

            // # Mostra mensagem caso a vitória tenha sido vertical tanto de X como de O
            if (Program.jogador1.letraJogo == "X" && linhaDiagonalX)
            {
                Console.WriteLine($"\nJogador {Program.jogador1.nome} Venceu a partida :D");
                MostrarTabuleiro();
                PreencherTabuleiro();
                JogarDeNovo(jogarDeNovo);
            }
            if (Program.jogador1.letraJogo == "O" && linhaDiagonalO)
            {
                Console.WriteLine($"\nJogador {Program.jogador1.nome} Venceu a partida :D");
                MostrarTabuleiro();
                PreencherTabuleiro();
                JogarDeNovo(jogarDeNovo);
            }
            if (Program.jogador2.letraJogo == "X" && linhaDiagonalX)
            {
                Console.WriteLine($"\nJogador {Program.jogador2.nome} Venceu a partida :D");
                MostrarTabuleiro();
                PreencherTabuleiro();
                JogarDeNovo(jogarDeNovo);
            }
            if (Program.jogador2.letraJogo == "O" && linhaDiagonalO)
            {
                Console.WriteLine($"\nJogador {Program.jogador2.nome} Venceu a partida :D");
                MostrarTabuleiro();
                PreencherTabuleiro();
                JogarDeNovo(jogarDeNovo);
            }

        }



        // # Método para verificar matriz na horizontal e ver se teve X X X ou O O O  na horizontal
        public static void VerificaEmpate(string jogarDeNovo)
        {
            bool[] linhasHorizontaisX = { true, true, true, true };
            bool[] linhasHorizontaisO = { true, true, true, true };

            bool[] linhasVerticaisX = { true, true, true, true };
            bool[] linhasVerticaisO = { true, true, true, true };

            // Percorro a matriz e verifico se as linhas estão X X X  ou  O O O, e vai retornar um booleano true ou false
            for (int linhas = 0; linhas < 3; linhas++)
            {
                for (int colunas = 0; colunas < 3; colunas++)
                {
                    // Linhas horizontais da matriz
                    linhasHorizontaisX[0] = (tabuleiro[0, 0] == "X" && tabuleiro[0, 1] == "X" && tabuleiro[0, 2] == "X");
                    linhasHorizontaisX[1] = (tabuleiro[1, 0] == "X" && tabuleiro[1, 1] == "X" && tabuleiro[1, 2] == "X");
                    linhasHorizontaisX[2] = (tabuleiro[2, 0] == "X" && tabuleiro[2, 1] == "X" && tabuleiro[2, 2] == "X");

                    linhasHorizontaisO[0] = (tabuleiro[0, 0] == "O" && tabuleiro[0, 1] == "O" && tabuleiro[0, 2] == "O");
                    linhasHorizontaisO[1] = (tabuleiro[1, 0] == "O" && tabuleiro[1, 1] == "O" && tabuleiro[1, 2] == "O");
                    linhasHorizontaisO[2] = (tabuleiro[2, 0] == "O" && tabuleiro[2, 1] == "O" && tabuleiro[2, 2] == "O");


                    // Linhas verticais da matriz
                    linhasVerticaisX[0] = (tabuleiro[0, 0] == "X" && tabuleiro[1, 0] == "X" && tabuleiro[2, 0] == "X");
                    linhasVerticaisX[1] = (tabuleiro[0, 1] == "X" && tabuleiro[1, 1] == "X" && tabuleiro[2, 1] == "X");
                    linhasVerticaisX[2] = (tabuleiro[0, 2] == "X" && tabuleiro[1, 2] == "X" && tabuleiro[2, 2] == "X");

                    linhasVerticaisO[0] = (tabuleiro[0, 0] == "O" && tabuleiro[1, 0] == "O" && tabuleiro[2, 0] == "O");
                    linhasVerticaisO[1] = (tabuleiro[0, 1] == "O" && tabuleiro[1, 1] == "O" && tabuleiro[2, 1] == "O");
                    linhasVerticaisO[2] = (tabuleiro[0, 2] == "O" && tabuleiro[1, 2] == "O" && tabuleiro[2, 2] == "O");

                }
            }

            #region # Region - mostra mensagem caso tenha sido empate na vertical ou na horizontal

            if ((linhasHorizontaisX[0] == true) && (linhasHorizontaisO[1] == true) || (linhasHorizontaisO[2] == true) ||
                (linhasHorizontaisX[1] == true) && (linhasHorizontaisO[0] == true) || (linhasHorizontaisO[2] == true) ||
                (linhasHorizontaisX[2] == true) && (linhasHorizontaisO[0] == true) || (linhasHorizontaisO[1] == true))
            {
                Console.WriteLine("\nEMPATE !");

                MostrarTabuleiro();
                PreencherTabuleiro();
                JogarDeNovo(jogarDeNovo);
            }
            else if (
                (linhasVerticaisX[0] == true) && (linhasVerticaisO[1] == true) || (linhasVerticaisO[2] == true) ||
                (linhasVerticaisX[1] == true) && (linhasVerticaisO[0] == true) || (linhasVerticaisO[2] == true) ||
                (linhasVerticaisX[2] == true) && (linhasVerticaisO[0] == true) || (linhasVerticaisO[1] == true)) 
            {
                Console.WriteLine("\nEMPATE !");

                MostrarTabuleiro();
                PreencherTabuleiro();
                JogarDeNovo(jogarDeNovo);
            }



            #endregion



        }



    }
}
