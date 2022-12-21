namespace JogoDaVelha
{
    class Program
    {
        public static void Main(string[] args) 
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("-----------------  BEM-VINDO AO JOGO DA VELHA  -----------------\n");
            Console.ResetColor();


            // # Mostra Interface ao usuário
            Menu.MostrarMenu();

            
        }
    }
}