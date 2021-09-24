using SENAI_InLock_WebAPI.Domains;
using SENAI_InLock_WebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace senai.inLock.webAPI.Domains
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly string stringConexao = "Data Source=NOTE0113E2\\SQLEXPRESS; initial catalog=inLockGames; user Id=sa; pwd=Senai@132";

        public Usuario Login(string email, string senha)
        {
          
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
               
                string querySelect = "SELECT idUsuario, email, U.idTipoUsuario, TU.titulo " +
                                     "FROM usuario U INNER JOIN tipoUsuario TU ON U.idTipoUsuario = TU.idTipoUsuario " +
                                     "WHERE email = @email AND senha = @senha";

               
                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    // Define os valores dos parâmetros
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@senha", senha);

                    con.Open();

                    
                    SqlDataReader rdr = cmd.ExecuteReader();

                    
                    if (rdr.Read())
                    {
                      
                        Usuario usuarioBuscado = new Usuario
                        {
                            
                            IdUsuario = Convert.ToInt32(rdr["idUsuario"]),
                            Email = rdr["email"].ToString(),
                            IdTipoUsuario = Convert.ToInt32(rdr["idTipoUsuario"]),
                            TipoUsuario = new TipoUsuario()
                            {
                                Titulo = rdr["titulo"].ToString()
                            }
                        };

                       
                        return usuarioBuscado;
                    }

                    
                    return null;
                }
            }
        }
    }
}
