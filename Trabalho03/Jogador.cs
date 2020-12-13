using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho03
{
    public class Jogador
    {
        public string Nome { get; set; }
        public int Pontuacao { get; set; }

        public Jogador(string nome, int pontuacao)
        {
            Nome = nome;
            Pontuacao = pontuacao;
        }

        public Jogador()
        {
        }
    }
}
