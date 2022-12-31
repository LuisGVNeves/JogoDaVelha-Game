using System.Net.NetworkInformation;
using static JogoDaVelha.Tabuleiro;

namespace JogoDaVelha
{
    class Program
    {
        // # Instanciação dos jogadores da classe Jogador
        public static Jogador jogador1 = new Jogador("", "", 0);
        public static Jogador jogador2 = new Jogador("", "", 0);


        // # Método Mostrar a interface inicial do jogo
        public static void MostrarInterfaceJogo()
        {
            // # Menu inicial
            EstilizarMenu("BEM-VINDO AO JOGO DA VELHA", ConsoleColor.Red);


            // # Variável escolha do usuário
            string escolhaUsuario;
            do
            {
                Console.Write("Deseja jogar o jogo da velha? SIM ou NÃO: ");
                escolhaUsuario = Console.ReadLine().ToUpper();

                if (escolhaUsuario == "SIM")
                {

                    Console.Write("\nDigite o nome do 1 jogador: ");
                    jogador1.nome = Console.ReadLine();

                    Console.Write("Digite o nome do 2 jogador: ");
                    jogador2.nome = Console.ReadLine();

                    Console.Write("\nJogador 1 qual você quer ser? letra X ou O: ");
                    jogador1.letraJogo = Console.ReadLine().ToUpper();


                    if (jogador1.letraJogo == "X")
                    {
                        jogador2.letraJogo = "O";
                    }
                    else
                    {
                        jogador2.letraJogo = "X";
                    }

                    Console.WriteLine($"\nJogador {jogador1.nome} começa com: {jogador1.letraJogo}");
                    Console.WriteLine($"\nJogador {jogador2.nome} começa com: {jogador2.letraJogo}");

                    // # Inicia o game
                    IniciarJogo();
                    break;
                }
                else
                {
                    EstilizarMenu("Encerrando aplicação", ConsoleColor.Red);
                    break;
                }
            }
            while (escolhaUsuario != "NAO" && escolhaUsuario != "NÃO");

        }

        // # Variável para parar o looping infinito no método iniciarJogo e começar uma nova partida
        public static string jogarDeNovo;


        // # Método que inicia o jogo
        public static void IniciarJogo()
        {
            // Preenche a matriz com números [0-9]
            PreencherTabuleiro();

            do
            {
                // # Quando matriz for trocada de número [0-9] por X ou O, invoco a função mostra o tabuleiro para mostrar como está o jogo atual
                MostrarTabuleiro();

                // Método para perguntar ao usuário se ele deseja X ou O para preencher na matriz e trocar os números da matriz pela escolha do jogar X ou O
                EscolhaJogador(jogarDeNovo);

                // # Método que verifica se deu velha
                VerificaEmpate(jogarDeNovo);

                // # Método que verifica se a vitória é diagonal e pergunta se deseja jogar de novo
                VerificaVitoriaDiagonal(jogarDeNovo);
                
                // # Método que verifica se a vitória é horizontal e pergunta se deseja jogar de novo
                VerificaVitoriaHorizontal(jogarDeNovo);

                // # Método que verifica se a vitória é vertical e pergunta se deseja jogar de novo
                VerificaVitoriaVertical(jogarDeNovo);
            } while (jogarDeNovo != "NAO" && jogarDeNovo != "NÃO");

        }


        public static void Main(string[] args)
        {
            MostrarInterfaceJogo();
        }

    }


}