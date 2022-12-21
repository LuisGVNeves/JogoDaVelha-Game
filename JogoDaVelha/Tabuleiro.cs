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

        // # Desenhar na Matriz
        public static void CriarTabuleiro()
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
