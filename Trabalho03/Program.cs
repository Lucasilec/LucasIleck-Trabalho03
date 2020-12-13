using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Trabalho03.Entity;

namespace Trabalho03
{
    class Program
    {
        static void Main(string[] args)
        {
            GeradorTabuleiro gerar = new GeradorTabuleiro();
            JogadoresMetodos j = new JogadoresMetodos();

            //mostrar lista de jogadores
            j.MostrarJogadores();
            // O Jogador

            //pede que insira um novo jogador ou escolha 1 da lista
            Jogador jogador = null;
            int  escRegistrar;
            bool vaiWhile = true;
            while (vaiWhile)
            {
                vaiWhile = true;
                Console.Write("Deseja registrar um novo jogador: 1-Sim / 2-não: ");
                bool foi = int.TryParse(Console.In.ReadLine(), out escRegistrar);
                switch (escRegistrar)
                {
                    case 1:
                        bool IniciarWhile = true;

                        while (IniciarWhile)
                        {
                            IniciarWhile = true;
                            Console.WriteLine("Digite o nome do novo jogador: ");
                            string nomeJogadorNovo = Console.In.ReadLine();
                            bool achouNome = j.PesquisarJogadorRepetido(nomeJogadorNovo);
                            if (achouNome)
                            {
                                j.InserirJogador(nomeJogadorNovo);
                                jogador = j.ImportarDados(nomeJogadorNovo);
                                vaiWhile = false;
                                IniciarWhile = false;
                            }
                            else if (!achouNome)
                            {
                                Console.WriteLine("Esse nome ja foi registrado");
                                Thread.Sleep(300);
                                Console.Clear();
                            }
                        }
                        break;
                    case 2:
                        Console.Write("Digite o nome do Jogador: ");
                        string nomeJogador = Console.In.ReadLine();
                        jogador = j.ImportarDados(nomeJogador);
                        vaiWhile = false;
                        break;
                                
                }
            }

            // Iniciar o Jogo

            //Mostrar Tabela do caça-palavras   
            gerar.IniciarMatriz();
           
           
            bool encerrarPrograma = true;
            do
            {
                Console.Clear();
                Console.WriteLine("Bem Vindo Campeão");
                Console.WriteLine();
                gerar.MostrarMatriz();
                Console.WriteLine();
                Console.WriteLine("1-Tentar uma palavra:");
                Console.WriteLine("2-Gerar um Novo:");
                Console.WriteLine("3-Encerar Programa:");
                int escolher = 0;
                bool foi2;
                do
                {
                    foi2 = int.TryParse(Console.In.ReadLine(), out escolher);
                } while (!foi2);
                switch (escolher)
                {
                    case 1:
                        Console.Clear();
                        string carregando = "";
                        string pontinhu = ".";
                        for (int k = 0; k < 3; k++)
                        {
                            Console.Clear();
                            Console.Write("Carregando");
                            for (int i = 0; i < 4; i++)
                            {

                                Console.Write(carregando);
                                carregando = pontinhu;
                                Thread.Sleep(300);
                            }
                        }
                        Console.Clear();
                        Console.WriteLine("Digite a palavra: ");
                        string palavra = Console.In.ReadLine();
                        int pontuacao = gerar.Jogar(palavra);
                        Console.WriteLine();
                        Console.WriteLine("Pontos feito na partida: {0}", pontuacao);
                        Console.WriteLine();
                        j.UpdatePontuacao(jogador.Nome, pontuacao);
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("Precione Enter para Continuar");
                        Console.In.ReadLine();
                        Console.Clear();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine();
                       
                        gerar.GerarLetras();
                        string carregando1 = "";
                        string pontinhu1 = ".";
                        for (int k = 0; k < 3; k++)
                        {
                            Console.Clear();
                            Console.WriteLine("Gerando Caça-Palavra");
                            Console.Write("Carregando");
                            for (int i = 0; i < 4; i++)
                            {
                               
                                Console.Write(carregando1);
                                carregando = pontinhu1;
                                Thread.Sleep(500);
                            }
                        }
                        Console.Clear();
                        break;
                    case 3:
                        encerrarPrograma = false;
                        Console.WriteLine("encerrando o Programa!!");
                        Thread.Sleep(1000);
                        break;
                }
            } while (encerrarPrograma);
        }
    }
}

