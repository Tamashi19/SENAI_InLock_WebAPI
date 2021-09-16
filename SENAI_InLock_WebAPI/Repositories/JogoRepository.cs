using SENAI_InLock_WebAPI.Domains;
using SENAI_InLock_WebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SENAI_InLock_WebAPI.Repositories
{
    public class JogoRepository : IJogoRepository
    
    {
        private readonly string stringConexao = "Data Source=DESKTOP-PM35QPG\\SQLEXPRESS; initial catalog=inLockGames; user Id=sa; pwd=senai@132";

        public void Atualizar(int id, Jogo jogoAtualizado)
        {
            throw new NotImplementedException();
        }

        public Jogo BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Jogo novoJogo)
        {
          
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
             
                string queryInsert = "INSERT INTO jogo(nomeJogo, descricao, dataLancamento, valor, idEstudio)" +
                                     "VALUES(@nomeJogo, @descricao, @dataLancamento, @valor, @idEstudio)";

               
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                
                    cmd.Parameters.AddWithValue("@nomeJogo", novoJogo.NomeJogo);
                    cmd.Parameters.AddWithValue("@descricao", novoJogo.Descricao);
                    cmd.Parameters.AddWithValue("@dataLancamento", novoJogo.DataLancamento);
                    cmd.Parameters.AddWithValue("@valor", novoJogo.Valor);
                    cmd.Parameters.AddWithValue("@idEstudio", novoJogo.IdEstudio);

                
                    con.Open();

                 
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<Jogo> ListarTodos()
        {
         
            List<Jogo> listaJogos = new List<Jogo>();

          
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
        
                string querySelectAll = "SELECT J.idJogo, nomeJogo, descricao, dataLancamento, valor, J.idEstudio, E.nomeEstudio FROM jogo J " +
                                        "INNER JOIN estudio E " +
                                        "ON J.idEstudio = E.idEstudio";

               
                con.Open();

               
                SqlDataReader rdr;

              
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                 
                    rdr = cmd.ExecuteReader();

                   
                    while (rdr.Read())
                    {
                 
                        Jogo jogo = new Jogo()
                        {
                        
                            IdJogo = Convert.ToInt32(rdr[0]),

                            NomeJogo = rdr[1].ToString(),

                            Descricao = rdr[2].ToString(),

                            DataLancamento = Convert.ToDateTime(rdr[3]),

                            Valor = Convert.ToDecimal(rdr[4]),

                            IdEstudio = Convert.ToInt32(rdr[5]),

                            Estudio = new Estudio()
                            {
                                NomeEstudio = rdr[6].ToString()
                            }
                        };

                     
                        listaJogos.Add(jogo);
                    }
                }
            }

        
            return listaJogos;
        }
    }
}
