using Services.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UsuarioDAL
    {
        private string connectionString = "Data Source=.;Initial Catalog=DB_AlquilerAutos;Integrated Security=True;";

        public Usuario ObtenerPorNombre(string nombreUsuario)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT ID_Usuario, NombreUsuario, Clave, IntentosFallidos, Bloqueado FROM Usuarios WHERE NombreUsuario = @Usuario";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Usuario", nombreUsuario); 

                con.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        Usuario usu = new Usuario();
                        usu.ID_Usuario = Convert.ToInt32(dr["ID_Usuario"]);
                        usu.NombreUsuario = dr["NombreUsuario"].ToString();
                        usu.Clave = dr["Clave"].ToString();
                        usu.IntentosFallidos = Convert.ToInt32(dr["IntentosFallidos"]);
                        usu.Bloqueado = Convert.ToBoolean(dr["Bloqueado"]);
                        return usu;
                    }
                    return null; 
                }
            }
        }

        public void ActualizarIntentos(Usuario usu)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "UPDATE Usuarios SET IntentosFallidos = @Intentos, Bloqueado = @Bloqueado WHERE ID_Usuario = @ID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Intentos", usu.IntentosFallidos);
                cmd.Parameters.AddWithValue("@Bloqueado", usu.Bloqueado);
                cmd.Parameters.AddWithValue("@ID", usu.ID_Usuario);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
