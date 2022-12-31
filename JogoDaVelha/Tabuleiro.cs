using JogoDaVelha;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace JogoDaVelha
{
    internal class Tabuleiro
    {
        // # Criar a Matriz - 3 linhas e 3 colunas
        public static string[,] tabuleiro = new string[3, 3];

        //  Variaveis globais para realizar a substituição do intervalo [0-9] por X ou O do método EscolhaJogador
        public static string escolhaJogador1;
        public static string escolhaJogador2;

        // Variáveis para o método de pontuação
        public static int pontuacaoJogador1 = 0;
        public static int pontuacaoJogador2 = 0;
        public static int qtdEmpate = 0;


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
            Console.WriteLine(@"
                              ╔═══════════╗");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"                                {tabuleiro[0, 0]} | {tabuleiro[0, 1]} | {tabuleiro[0, 2] } ");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("                               -----------");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"                                {tabuleiro[1, 0]} | {tabuleiro[1, 1]} | {tabuleiro[1, 2] } ");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("                               -----------\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"                                {tabuleiro[2, 0]} | {tabuleiro[2, 1]} | {tabuleiro[2, 2] } ");
            Console.ResetColor();
            
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(@"
                              ╚═══════════╝");
            Console.ResetColor();
        }


        /*
            Método EscolhaJogador - Verificação jogador 1 e 2:
            - Pegar o input do jogador para saber qual valor da matriz ele deseja substituir pelo X ou O
            - Verificar se esse input está no intervalo de [0-9]
            - Por ultimo percorro a matriz novamente substituindo o Número do input que o usuário digitou, pela letra que
            está no jogador
            - Isso tudo está em loop infinito até que o usuário digite o número no intervalo correto da matriz [0-9]
        */
        
        // Casting da escolha do jogador
        public static int escolhaJogadorUm;
        public static int escolhaJogadorDois;
        public static void EscolhaJogador(string jogarDeNovo)
        {
            do
            {

                // Input do usuario
                Console.Write($"\nJogador {Program.jogador1.nome} - Escolha o valor do tabuleiro que você quer preencher {Program.jogador1.letraJogo}: ");
                escolhaJogador1 = Console.ReadLine();

                // Casting do input do jogador
                escolhaJogadorUm = int.Parse(escolhaJogador1);

                // Checagem do intervalo [0-9]
                if (escolhaJogadorUm < 0 || escolhaJogadorUm > 9)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("\n\nNúmero não pertence ao intervalo [0-9] digite um número novamente: ");
                    Console.ResetColor();

                    string novoNumero = Console.ReadLine();
                    escolhaJogador1 = novoNumero;
                }


                // Substituição na matriz do numero por X ou O
                for (int linhas = 0; linhas < 3; linhas++)
                {
                    for (int colunas = 0; colunas < 3; colunas++)
                    {
                        if (tabuleiro[linhas,colunas] == escolhaJogador1)
                        {

                            tabuleiro[linhas, colunas] = Program.jogador1.letraJogo;

                            System.Threading.Thread.Sleep(200);
                            Console.Clear();

                            // # Decorar o menu
                            EstilizarMenu("Jogo da Velha", ConsoleColor.Red);

                            // # Método que verifica se deu velha
                            VerificaEmpate(jogarDeNovo);

                            // # Método que verifica se a vitória é horizontal e pergunta se deseja jogar de novo
                            VerificaVitoriaHorizontal(jogarDeNovo);

                            // # Método que verifica se a vitória é vertical e pergunta se deseja jogar de novo
                            VerificaVitoriaVertical(jogarDeNovo);

                            // # Método que verifica se a vitória é diagonal e pergunta se deseja jogar de novo
                            VerificaVitoriaDiagonal(jogarDeNovo);

                            MostrarTabuleiro();

                        }

                    }
                }


                // Input do usuario
                Console.Write($"\nJogador {Program.jogador2.nome} - Escolha o valor do tabuleiro que você quer preencher com {Program.jogador2.letraJogo}: ");
                escolhaJogador2 = Console.ReadLine();

                // Casting do input do jogador
                escolhaJogadorDois = int.Parse(escolhaJogador2);


                // Checagem do intervalo [0-9]
                if (escolhaJogadorDois < 0 || escolhaJogadorDois > 9)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("\n\nNúmero não pertence ao intervalo [0-9] digite um número novamente: ");
                    Console.ResetColor();

                    string novoNumero = Console.ReadLine();
                    escolhaJogador2 = novoNumero;
                }

                // Substituição na matriz do numero por X ou O
                for (int linhas = 0; linhas < 3; linhas++)
                {
                    for (int colunas = 0; colunas < 3; colunas++)
                    {
                        if (tabuleiro[linhas, colunas] == escolhaJogador2)
                        {

                            tabuleiro[linhas, colunas] = Program.jogador2.letraJogo;

                            System.Threading.Thread.Sleep(200);
                            Console.Clear();

                            // # Decorar o menu
                            EstilizarMenu("Jogo da Velha", ConsoleColor.Red);

                            // # Método que verifica se deu velha
                            VerificaEmpate(jogarDeNovo);

                            // # Método que verifica se a vitória é horizontal e pergunta se deseja jogar de novo
                            VerificaVitoriaHorizontal(jogarDeNovo);

                            // # Método que verifica se a vitória é vertical e pergunta se deseja jogar de novo
                            VerificaVitoriaVertical(jogarDeNovo);

                            // # Método que verifica se a vitória é diagonal e pergunta se deseja jogar de novo
                            VerificaVitoriaDiagonal(jogarDeNovo);
                        }

                    }
                }



                // # Checagem para quando usuário escolha o mesmo numero já preenchido na matriz
                while (escolhaJogadorUm == escolhaJogadorDois || escolhaJogadorDois == escolhaJogadorUm)
                {
                    if (int.Parse(escolhaJogador1) == int.Parse(escolhaJogador2))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("\n\nNúmero já preenchido escolha outro: ");
                        Console.ResetColor();

                        string novoNumero = Console.ReadLine();
                        escolhaJogador2 = novoNumero;
                    }
                    else if (int.Parse(escolhaJogador2) == int.Parse(escolhaJogador1))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("\n\nNúmero já preenchido escolha outro: ");
                        Console.ResetColor();

                        string novoNumero = Console.ReadLine();
                        escolhaJogador1 = novoNumero;
                    }
                    else
                    {
                        break;
                    }
                }
               


            } while (escolhaJogadorUm <= 0 && escolhaJogadorUm >= 9 && escolhaJogadorDois <= 0 && escolhaJogadorDois >= 9);

            
        }

        // # Método para perguntar ao usuário se ele deseja jogar de novo
        public static void JogarDeNovo(string jogarDeNovo)
        {
            // # Interface do submenu
            EstilizarMenu("SubMenu Jogo da Velha", ConsoleColor.Blue);
            do
            {

                Console.WriteLine("\n\n1 - Jogar de novo");
                Console.WriteLine("2 - Ver pontuação dos jogadores");
                Console.WriteLine("3 - Sair do jogo\n");

                Console.Write("Digite: ");

                jogarDeNovo = Console.ReadLine();
                switch (jogarDeNovo)
                {
                    case "1":
                        System.Threading.Thread.Sleep(1300);
                        Console.Clear();

                        // Interface do xadrex
                        EstilizarMenu("Jogo da Velha", ConsoleColor.DarkRed);

                        // # Vai iniciar o jogo e resetar o intervalo [0-9]
                        PreencherTabuleiro();
                        Program.IniciarJogo();
                        break;
                    case "2":
                        System.Threading.Thread.Sleep(1000);
                        Console.Clear();

                        // Interface do xadrex
                        EstilizarMenu("Pontuação", ConsoleColor.DarkGreen);
                        
                        MostrarPontuacao();
                        break;
                    case "3":
                        Console.Clear();

                        EstilizarMenu("--------------   Encerrando aplicação  --------------", ConsoleColor.Red);
                        System.Environment.Exit(0);
                        break;
                }

            } while (jogarDeNovo != "3");

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
                
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n\nJogador {Program.jogador1.nome} Venceu a partida !");
                Console.ResetColor();

                pontuacaoJogador1++;
                MostrarTabuleiro();

                System.Threading.Thread.Sleep(3000);
                Console.Clear();

                JogarDeNovo(jogarDeNovo);
            }
            if (Program.jogador1.letraJogo == "O" && linhaHorizontalO)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n\nJogador {Program.jogador1.nome} Venceu a partida ! ");
                Console.ResetColor();

                pontuacaoJogador1++;
                MostrarTabuleiro();

                System.Threading.Thread.Sleep(3000);
                Console.Clear();

                JogarDeNovo(jogarDeNovo);
            }
            if (Program.jogador2.letraJogo == "X" && linhaHorizontalX)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n\nJogador {Program.jogador2.nome} Venceu a partida ! ");
                Console.ResetColor();

                pontuacaoJogador2++;
                MostrarTabuleiro();

                System.Threading.Thread.Sleep(3000);
                Console.Clear();

                JogarDeNovo(jogarDeNovo);
            }
            if (Program.jogador2.letraJogo == "O" && linhaHorizontalO)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n\nJogador {Program.jogador2.nome} Venceu a partida !");
                Console.ResetColor();

                pontuacaoJogador2++;
                MostrarTabuleiro();

                System.Threading.Thread.Sleep(3000);
                Console.Clear();

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
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n\nJogador {Program.jogador1.nome} Venceu a partida :D");
                Console.ResetColor();

                pontuacaoJogador1++;
                MostrarTabuleiro();

                System.Threading.Thread.Sleep(3000);
                Console.Clear();

                JogarDeNovo(jogarDeNovo);
            }
            if (Program.jogador1.letraJogo == "O" && linhaVerticalO)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n\nJogador {Program.jogador1.nome} Venceu a partida :D");
                Console.ResetColor();

                pontuacaoJogador1++;
                MostrarTabuleiro();

                System.Threading.Thread.Sleep(3000);
                Console.Clear();

                JogarDeNovo(jogarDeNovo);
            }
            if (Program.jogador2.letraJogo == "X" && linhaVerticalX)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n\nJogador {Program.jogador2.nome} Venceu a partida :D");
                Console.ResetColor();

                pontuacaoJogador2++;
                MostrarTabuleiro();

                System.Threading.Thread.Sleep(3000);
                Console.Clear();

                JogarDeNovo(jogarDeNovo);
            }
            if (Program.jogador2.letraJogo == "O" && linhaVerticalO)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n\nJogador {Program.jogador2.nome} Venceu a partida :D");
                Console.ResetColor();

                pontuacaoJogador2++;
                MostrarTabuleiro();

                System.Threading.Thread.Sleep(3000);
                Console.Clear();

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
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n\nJogador {Program.jogador1.nome} Venceu a partida :D");
                Console.ResetColor();

                pontuacaoJogador1++;
                MostrarTabuleiro();

                System.Threading.Thread.Sleep(3000);
                Console.Clear();

                JogarDeNovo(jogarDeNovo);
            }
            if (Program.jogador1.letraJogo == "O" && linhaDiagonalO)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n\nJogador {Program.jogador1.nome} Venceu a partida :D");
                Console.ResetColor();

                pontuacaoJogador1++;
                MostrarTabuleiro();

                System.Threading.Thread.Sleep(3000);
                Console.Clear();

                JogarDeNovo(jogarDeNovo);
            }
            if (Program.jogador2.letraJogo == "X" && linhaDiagonalX)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n\nJogador {Program.jogador2.nome} Venceu a partida :D");
                Console.ResetColor();

                pontuacaoJogador2++;
                MostrarTabuleiro();

                System.Threading.Thread.Sleep(3000);
                Console.Clear();

                JogarDeNovo(jogarDeNovo);
            }
            if (Program.jogador2.letraJogo == "O" && linhaDiagonalO)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n\nJogador {Program.jogador2.nome} Venceu a partida :D");
                Console.ResetColor();

                pontuacaoJogador2++;
                MostrarTabuleiro();

                System.Threading.Thread.Sleep(3000);
                Console.Clear();

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

                        // Esses métodos logo após a verificação checam o intervalo [0-9] para ver se houve alguma vitória horizontal, vertical ou diagonal antes de cair no else que seria o empate
                        VerificaVitoriaHorizontal(jogarDeNovo);
                        VerificaVitoriaVertical(jogarDeNovo);
                        VerificaVitoriaDiagonal(jogarDeNovo);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n***  Deu velha  ***");
                        Console.ResetColor();

                        MostrarTabuleiro();

                        qtdEmpate++;

                        System.Threading.Thread.Sleep(3000);
                        Console.Clear();

                        JogarDeNovo(jogarDeNovo);
                    }


                }
            }
        }

        // # Método para armazenar pontuação dos jogadores
        public static void MostrarPontuacao()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("[ ");
            Console.ResetColor();

            Console.Write($"Jogador {Program.jogador1.nome} está com {pontuacaoJogador1} pontos");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" ]");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" [");
            Console.ResetColor();


            Console.Write($"Jogador {Program.jogador2.nome} está com {pontuacaoJogador2} pontos");
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" ]");
            Console.ResetColor();

            Console.WriteLine("\n\n");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("[ ");
            Console.ResetColor();

            Console.Write($"Quantidade de empates: {qtdEmpate}");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" ]");
            Console.ResetColor();


            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("   [ ");
            Console.ResetColor();

            Console.Write($"Quantidade de jogadas: {qtdEmpate + pontuacaoJogador1 + pontuacaoJogador2}");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" ]");
            Console.ResetColor();


            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\n------------------------------------------------------------------\n");
            Console.ResetColor();

        }

        // # Método para estilizar a interface do terminal
        public static void EstilizarMenu(string texto, ConsoleColor cor)
        {
            Console.Clear();
            Console.BackgroundColor = cor;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("                     ");
            Console.Write("┌─┐");
            Console.Write("└─┘");
            Console.Write($"  {texto}  ");
            Console.Write("┌─┐");
            Console.Write("└─┘");
            Console.Write("                     ");
            Console.WriteLine("\n");
            Console.ResetColor();
        }
    }
}
