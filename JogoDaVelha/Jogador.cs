using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoDaVelha
{
    internal class Jogador
    {
        // # Variáveis públicas internas da classe Usuário
        public string nome;
        public int pontuacao;

        public Jogador(string nome, int pontuacao) 
        {
            this.nome = nome;
            this.pontuacao = pontuacao;
        }
    }
}
