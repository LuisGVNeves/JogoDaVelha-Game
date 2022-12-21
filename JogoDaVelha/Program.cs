namespace JogoDaVelha
{
    class Program
    {
        public static void Main(string[] args) 
        {

            string escolhaUsuario;

            while (true)
            {
                Menu.MostrarMenu();

                Console.Write("Deseja jogar o jogo da velha? SIM ou NÃO: ");
                escolhaUsuario = Console.ReadLine().ToUpper();

                if(escolhaUsuario == "SIM")
                {
                    Console.WriteLine("Jogando");
                    break;
                }
                else
                {
                    Console.ForegroundColor= ConsoleColor.Red;
                    Console.WriteLine("\n------ Encerrando aplicação ------");
                    Console.ResetColor();
                    break;
                }
            }

            
        }
    }
}