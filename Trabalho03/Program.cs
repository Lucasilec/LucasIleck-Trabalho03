using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho03.Entity;

namespace Trabalho03
{
    class Program
    {
        static void Main(string[] args)
        {
            Jogadores jogador = new Jogadores();
            GeradorTabuleiro geradorTabuleiro = new GeradorTabuleiro();
            geradorTabuleiro.IniciarMatriz();
            Console.ReadLine();

            Console.Write("Insira a palavra: ");

            string palavra = Console.In.ReadLine();
            jogador.Pontuacao = geradorTabuleiro.Jogar(palavra);
            geradorTabuleiro.MostrarMatriz();
        }
    }
}

