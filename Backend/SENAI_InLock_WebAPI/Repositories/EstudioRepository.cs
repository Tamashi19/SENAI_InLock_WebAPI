using senai.inLock.webAPI.Domains;
using SENAI_InLock_WebAPI.Domains;
using SENAI_InLock_WebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;


namespace SENAI_InLock_WebAPI.Repositories
{

    public class EstudioRepository : IEstudiosRepository
    {
    private readonly string stringConexao = "Data Source=NOTE0113E2\\SQLEXPRESS; initial catalog=inLockGames; user Id=sa; pwd=Senai@132";
        
        public List<Estudio> ListarComJogos()
        {
            List<Estudio> listaEstudios = new List<Estudio>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                
                string querySelectAllStudio = "SELECT idEstudio, nomeEstudio FROM Estudio";

               
                con.Open();

             
                SqlDataReader readerEstudios;

                
                using (SqlCommand cmd = new SqlCommand(querySelectAllStudio, con))
                {
                    
                    readerEstudios = cmd.ExecuteReader();

                
                    while (readerEstudios.Read())
                    {
                        List<Jogo> listaJogos = new List<Jogo>();

                        Estudio estudio = new Estudio()
                        {
                            IdEstudio = Convert.ToInt32(readerEstudios[0]),
                            NomeEstudio = readerEstudios[1].ToString()
                        };

                        using (SqlConnection conGames = new SqlConnection(stringConexao))
                        {
                            string querySelectAllGames = "SELECT idJogo, nomeJogo, descricao, dataLancamento, valor FROM jogo WHERE idEstudio = @idEstudio";

                            conGames.Open();

                            SqlDataReader readerGames;

                            using (SqlCommand cmdGames = new SqlCommand(querySelectAllGames, conGames))
                            {
                                cmdGames.Parameters.AddWithValue("@idEstudio", estudio.IdEstudio);
                                readerGames = cmdGames.ExecuteReader();

                                while (readerGames.Read())
                                {
                                    Jogo jogo = new Jogo()
                                    {
                                        IdJogo = Convert.ToInt32(readerGames[0]),

                                        NomeJogo = readerGames[1].ToString(),

                                        Descricao = readerGames[2].ToString(),

                                        DataLancamento = Convert.ToDateTime(readerGames[3]),

                                        Valor = Convert.ToDecimal(readerGames[4])
                                    };

                                    listaJogos.Add(jogo);
                                }
                            }
                            estudio.ListaJogos = listaJogos;

                            listaEstudios.Add(estudio);
                        }
                    }
                }
            }

          
            return listaEstudios;
        }

      
    }
}