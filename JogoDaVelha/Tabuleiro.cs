using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoDaVelha
{
    internal class Tabuleiro
    {
        // # Iniciar Game
        public static void IniciarGame()
        {
            // # Criação do 1 e 2 jogador, sem nome e com pontuação 0
            Jogador jogador1 = new Jogador("", 0);
            Jogador jogador2 = new Jogador("", 0);

            Console.Write("\nDigite o nome do 1 jogador: ");
            jogador1.nome = Console.ReadLine();

            Console.Write("Digite o nome do 2 jogador: ");
            jogador2.nome = Console.ReadLine();
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
                    tabuleiro[1,0] = "3";
                    tabuleiro[1,1] = "4";
                    tabuleiro[1,2] = "5";


                    // # Linha 3
                    tabuleiro[2, 0] = "6";
                    tabuleiro[2, 1] = "7";
                    tabuleiro[2, 2] = "8";
                }
		    }
        }

        // # Mostrar Tabuleiro
        public static void MostrarTabuleiro()
        {
            Console.WriteLine($" {tabuleiro[0,0]}  | {tabuleiro[0,1]} |  {tabuleiro[0,2]}");
            Console.WriteLine($" {tabuleiro[1,0]}  | {tabuleiro[1,1]} |  {tabuleiro[1,2]}");
            Console.WriteLine($" {tabuleiro[2,0]}  | {tabuleiro[2,1]} |  {tabuleiro[2,2]}");
        }


        // # Dar opção pro usuário qual valor da matriz ele quer prencher exemplo:


        /*
         
            0 | 1 | 2 
            3 | 4 | 5 
            6 | 7 | 8 
            prompt - voce deseja ser o X ou O: X
            prompt - qual opcao deseja escolher: 0

            X | 1 | 2 
            3 | 4 | 5 
            6 | 7 | 8
        */

    }
}
