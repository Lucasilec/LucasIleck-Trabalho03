using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho03
{
    public class JogadoresMetodos
    {
        SqlConnection conn = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\lucas\OneDrive\Área de Trabalho\LucasIleck-Trabalho03\LucasIleck-Trabalho03\Trabalho03\Database1.mdf;Integrated Security = True");
        SqlCommand cmd;
        SqlDataReader dr;
        public void InserirJogador(string nome)
        {
            string insertJogador = $"INSERT into Jogador (Nome, Pontuacao) values ('{nome}', 0)";
            cmd = new SqlCommand(insertJogador, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void MostrarJogadores()
        {
            string Select = "SELECT * FROM Jogador";
            cmd = new SqlCommand(Select, conn);
            conn.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Console.Write("Jogador: " + dr["Nome"] + " ,");
                Console.Write("Pontuação: " + dr["Pontuacao"]);
                Console.WriteLine();
            }
            
            Console.WriteLine();
            dr.Close();
            conn.Close();
        }
        /// <summary>
        /// Retorna false caso tenha encontrado um nome repetido.
        /// </summary>
        /// <param name="nomeJogador"></param>
        /// <returns></returns>
        public bool PesquisarJogadorRepetido(string nomeJogador)
        {
            bool achouNome = true;
            string selectNome = $"SELECT * FROM Jogador";
            cmd = new SqlCommand(selectNome, conn);
            conn.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (dr["Nome"].ToString() == nomeJogador)
                {
                    achouNome = false;
                }
            }
            conn.Close();
            return achouNome;
        }
        public Jogador ImportarDados(string nome)
        {
            Jogador j;
            int pontos = 0;
            string nomeDoCara = " ";
            string selectNome = $"SELECT * FROM Jogador";
            cmd = new SqlCommand(selectNome, conn);
            conn.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (dr["Nome"].ToString() == nome)
                {
                    nomeDoCara = Convert.ToString(dr["Nome"]);
                    pontos = Convert.ToInt32(dr["Pontuacao"]);
                }
            }
            conn.Close();
            j = new Jogador(nomeDoCara, pontos);
            return j;
        }
        public void UpdatePontuacao(string nome, int novaPontuacao)
        {
            int pontos = 0;
            string Select = "SELECT * FROM Jogador";
            cmd = new SqlCommand(Select, conn);
            conn.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (dr["Nome"].ToString() == nome)
                {
                    pontos = Convert.ToInt32(dr["Pontuacao"]);
                    break;
                }
            }
            dr.Close();
            conn.Close();
            pontos += novaPontuacao;

            string update = $"UPDATE Jogador Set Pontuacao = {pontos} WHERE Nome = '{nome}'";
            cmd = new SqlCommand(update, conn);
            conn.Open();           
            cmd.ExecuteNonQuery();
            conn.Close();

            string selecionarJogador = "SELECT * FROM Jogador";
            cmd = new SqlCommand(selecionarJogador, conn);
            conn.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (dr["Nome"].ToString() == nome)
                {
                    Console.Write("JOGADOR: " + dr["Nome"] + " ,");
                    Console.Write("PONTUAÇÃO: " + dr["Pontuacao"]);
                    break;
                }
            }
            dr.Close();
            conn.Close();
        }
        public void DeletarTabela()
        {
            string deletar = "DELETE  FROM Jogador";
            cmd = new SqlCommand(deletar, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
