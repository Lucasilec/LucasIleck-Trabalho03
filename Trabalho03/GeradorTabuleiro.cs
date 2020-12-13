using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho03.Entity
{
    public class GeradorTabuleiro
    {
        public enum Letras
        {
            A,
            D,
            E,
            F,
            B,
            C,
            G,
            I,
            U,
            H,
            J,
            V,
            K,
            L,
            M,
            O,
            Q,
            N,
            T,
            P,
            R,
            S,
            Z
        }
        public char[][] Matriz { get; set; }
        /// <summary>
        /// Esse metodo cria um tabuleiro com o tamanho dado pelo usuario
        /// </summary>
        public void GerarTabuleiro()
        {
            Matriz = new char[3][];
            for (int i = 0; i < Matriz.Length; i++)
            {
                Matriz[i] = new char[3];
            }
        }
        public void GerarLetras()
        {
            int valorRam;
            Random ram = new Random();
            for (int i = 0; i < Matriz.Length; i++)
            {
                for (int j = 0; j < Matriz[i].Length; j++)
                {
                    if (i == 0)
                    {
                        if (i == 0 && j == 0)
                        {
                            valorRam = ram.Next(0, 2);
                        }
                        else if (i == 0 && j == 1)
                        {
                            valorRam = ram.Next(2, 4);
                        }
                        else
                        {
                            valorRam = ram.Next(4, 6);
                        }
                    }
                    else if (i == 1)
                    {
                        if (j == 0)
                        {
                            valorRam = ram.Next(6, 9);
                        }
                        else if (j == 1)
                        {
                            valorRam = ram.Next(9, 12);
                        }
                        else
                        {
                            valorRam = ram.Next(12, 14);
                        }
                    }
                    else
                    {
                        if (j == 0)
                        {
                            valorRam = ram.Next(14, 17);
                        }
                        else if (j == 1)
                        {
                            valorRam = ram.Next(17, 20);
                        }
                        else
                        {
                            valorRam = ram.Next(20, 23);
                        }
                    }
                    Matriz[i][j] = Convert.ToChar(Convert.ToString((Letras)valorRam));
                }
            }
        }
        public void MostrarMatriz()
        {
            
            for (int i = 0; i < Matriz.Length; i++)
            {
                for (int j = 0; j < Matriz[i].Length; j++)
                {
                    Console.Write("|{0}|", Matriz[i][j]);
                    
                }
                Console.WriteLine();
            }
        }
        public void IniciarMatriz()
        {
            GerarTabuleiro();
            GerarLetras();
        }
        public int Jogar(string palavra)
        {          
            // esse "sairFor" serve para fechar o primeiro for caso a letra for encontrada 
            bool sairFor = true;
            //esta variavel "a" e usada como encrementador do vetor de char da string "palavra".
            int a = 0;
            // Aqui esta a ultima posiçao da letra
            int P1 = 0;
            int P2 = 0;
            // um char para guardar a ultima letra
            char ultimaLetra = ' ';
            // guardar a pnultima checagem para não repetir a letra novamente
            int P1anterior = 0;
            int P2anterior = 0;
            // a quantidade de palavras encontradas na sequencia
            int PalavarsEncontradada = 0;
            while (a < palavra.Length)
            {
                sairFor = true;
                for (int i = 0; i < Matriz.Length && sairFor == true; i++)
                {
                    for (int j = 0; j < Matriz[i].Length; j++)
                    {
                        if (Matriz[i][j] == palavra[a])
                        {
                            if (a == 0)
                            {
                                ultimaLetra = Matriz[i][j];                         
                                PalavarsEncontradada++;
                                P1anterior = P1;
                                P2anterior = P2;
                                P1 = i;
                                P2 = j;
                                sairFor = false;
                                break;
                            }
                            else if (a > 0 && Matriz[i][j] != Matriz[P1anterior][P2anterior])
                            {
                                if (i == (P1 + 1) && j == (P2 + 1)
                                                  ||
                                    i == (P1 - 1) && j == (P2 - 1)
                                                  ||
                                    i == (P1) && j == (P2 - 1)
                                                  ||
                                    i == (P1) && j == (P2 + 1)
                                                  ||
                                    i == (P1 - 1) && j == (P2)
                                                  ||
                                    i == (P1 + 1) && j == (P2)
                                                  ||
                                    i == (P1 + 1) && j == (P2 - 1)
                                                  ||
                                    i == (P1 - 1) && j == (P2 + 1))
                                {

                                    //Console.WriteLine($"{Matriz[i][j]} É vizinho de {ultimaLetra}");
                                    ultimaLetra = Matriz[i][j];                                
                                    PalavarsEncontradada++;
                                    // P1 e P2 anterior serve para registrar a posição de um numero anterior eviatando repetições
                                    P1anterior = P1;
                                    P2anterior = P2;
                                    P1 = i;
                                    P2 = j;
                                    sairFor = false;
                                    break;
                                }
                                else
                                {
                                    //Console.WriteLine($"{Matriz[i][j]} Não e um vizinho de {ultimaLetra}");
                                    //Console.WriteLine($"Tadinho do {Matriz[i][j]}");
                                    break;
                                }
                            }
                        }
                    }
                }
                a++;
            }
            Console.WriteLine("PALAVRAS ESCONTRADAS: {0}", PalavarsEncontradada);
            return PalavarsEncontradada / 2;
            
        }
    }
}
