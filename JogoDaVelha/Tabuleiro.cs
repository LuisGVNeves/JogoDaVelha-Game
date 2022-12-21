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
        // Usuário escolher letra X ou O
        public static string escolhaLetraJogador;
        
        // # Criação do 1 e 2 jogador, sem nome e com pontuação 0
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
            escolhaLetraJogador = Console.ReadLine();

            if(escolhaLetraJogador == "X")
            {
                jogador1.letraJogo = "X";
                jogador2.letraJogo = "O";
            }
            else
            {
                jogador2.letraJogo = "O";
                jogador2.letraJogo = "X";
            }

            Console.WriteLine($"\nJogador 1 {jogador1.nome} começa com {jogador1.letraJogo}");
            Console.WriteLine($"\nJogador 2 {jogador2.nome} começa com {jogador2.letraJogo}");
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


        // # Dar opção pro usuário qual valor da matriz ele quer prencher :
        public static void IniciarJogo()
        {
            Console.Write("\nJogador 1 - escolha o valor do tabuleiro que você quer preencher: ");
            string escolhaJogador1 = Console.ReadLine();
            
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
                        MostrarTabuleiro();
                    }
                }
            }

        }

        /*
         
            0 | 1 | 2 
            3 | 4 | 5 
            6 | 7 | 8 
            prompt - qual opcao deseja escolher: 0

            X | 1 | 2 
            3 | 4 | 5 
            6 | 7 | 8
        */

    }
}
