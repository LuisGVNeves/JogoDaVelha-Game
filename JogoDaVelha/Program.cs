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

            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("-----------------  BEM-VINDO AO JOGO DA VELHA  -----------------\n");
            Console.ResetColor();

            // # Variável escolha do usuário
            string escolhaUsuario;
            do
            {
                Console.Write("Deseja jogar o jogo da velha? SIM ou NÃO: ");
                escolhaUsuario = Console.ReadLine().ToUpper();

                if (escolhaUsuario == "SIM")
                {
                    // # Iniciar a entrada inicial do Game
                    IniciarMenuJogo();
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
            while (escolhaUsuario != "NAO" && escolhaUsuario != "NÃO");

        }

        // # Método Iniciar Menu do Game
        public static void IniciarMenuJogo()
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
                jogador1.letraJogo = "O";
                jogador2.letraJogo = "X";
            }

            Console.WriteLine($"\nJogador {jogador1.nome} começa com: {jogador1.letraJogo}");
            Console.WriteLine($"\nJogador {jogador2.nome} começa com: {jogador2.letraJogo}\n\n");


            // # Preencher o tabuleiro com os números
            Tabuleiro.PreencherTabuleiro();

            // # Chamar a Função de chamar o tabuleiro para jogar
            Tabuleiro.MostrarTabuleiro();

            // # Iniciar o jogo
            Tabuleiro.IniciarJogo();
        }

        public static void Main(string[] args)
        {
            MostrarInterfaceJogo();
        }
    }
}