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

        // # Variaveis globais para realizar as condições no método de verificar se houve empate
        public static string escolhaJogador1;
        public static string escolhaJogador2;

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

        // # Método para saber qual valor do intervalo [0-9] o usuário vai querer substituir pelo X ou O
        public static void EscolhaJogador(string jogarDeNovo)
        {

            Console.Write($"\nJogador {Program.jogador1.nome} - Escolha o valor do tabuleiro que você quer preencher {Program.jogador1.letraJogo}: ");
            escolhaJogador1 = Console.ReadLine();

            Console.Write($"\nJogador {Program.jogador2.nome} - Escolha o valor do tabuleiro que você quer preencher com {Program.jogador2.letraJogo}: ");
            escolhaJogador2 = Console.ReadLine();

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

        // # Método que verifica se houve empate no jogo
        public static void VerificaEmpate(string jogarDeNovo)
        {
            /*
               - Se o intervalo[1-9] estiver preenchido com numeros o código ocorre normalmente, porém, se não estiver, quer dizer que ele já está lotado de X e O, e se até o número 8 nenhuma função de checar vitoria, chegar empate entrar, então quer dizer que deu velha
               - Aqui eu vou percorrer a matriz, e comparar e ver se é igual a escolha do jogador se for, eu vou substituir o número do intervalo [1-9] pela letra

             */
            for (int linhas = 0; linhas < 3; linhas++)
            {
                for (int colunas = 0; colunas < 3; colunas++)
                {

                    if ((tabuleiro[0, 0] == "1") ||
                       (tabuleiro[0, 1] == "2") ||
                       (tabuleiro[0, 2] == "3") ||
                       (tabuleiro[1, 0] == "4") ||
                       (tabuleiro[1, 1] == "5") ||
                       (tabuleiro[1, 2] == "6") ||
                       (tabuleiro[2, 0] == "7") ||
                       (tabuleiro[2, 1] == "8"))
                    {
                        // Caso jogador2 queira preencher o mesmo campo que o jogador 1 já marcou que queria preencher
                        if (escolhaJogador2 == escolhaJogador1)
                        {
                            Console.Write("\nCampo já preenchido, por favor digite um campo que não foi usado: ");
                            string novoCampo = Console.ReadLine();

                            escolhaJogador2 = novoCampo;
                        }

                        // Substituindo o intervalo [0-9] para [X-O]
                        if (tabuleiro[linhas, colunas] == escolhaJogador1)
                        {
                            tabuleiro[linhas, colunas] = Program.jogador1.letraJogo;
                        }
                        if (tabuleiro[linhas, colunas] == escolhaJogador2)
                        {
                            tabuleiro[linhas, colunas] = Program.jogador2.letraJogo;
                        }

                        // Esses métodos logo após a verificação checam o intervalo [0-9] para ver se houve alguma vitória horizontal, vertical ou diagonal antes de cair no else que seria o empate
                        VerificaVitoriaHorizontal(jogarDeNovo);
                        VerificaVitoriaVertical(jogarDeNovo);
                        VerificaVitoriaDiagonal(jogarDeNovo);
                    }
                    else
                    {
                        MostrarTabuleiro();
                        Console.WriteLine("\nDeu velha");
                        JogarDeNovo(jogarDeNovo);
                    }


                }
            }
        }

    }
}
