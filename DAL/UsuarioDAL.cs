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

        public List<Usuario> Listar()
        {
            List<Usuario> lista = new List<Usuario>();
            using (SqlConnection mCon = new SqlConnection(connectionString))
            {
                string mCommandText = "SELECT * FROM Usuarios";
                SqlCommand mCom = new SqlCommand(mCommandText, mCon);
                mCon.Open();
                using (SqlDataReader mDt = mCom.ExecuteReader())
                {
                    while (mDt.Read())
                    {
                        Usuario usuario = new Usuario();
                        usuario.ID_Usuario = Convert.ToInt32(mDt["ID_Usuario"]);

                        usuario.DNI = Convert.ToString(mDt["DNI"] == DBNull.Value ? "" : mDt["DNI"]);
                        usuario.Apellido = Convert.ToString(mDt["Apellido"] == DBNull.Value ? "" : mDt["Apellido"]);
                        usuario.Nombre = Convert.ToString(mDt["Nombre"] == DBNull.Value ? "" : mDt["Nombre"]);
                        usuario.NombreUsuario = Convert.ToString(mDt["NombreUsuario"]);
                        usuario.Rol = Convert.ToString(mDt["Rol"] == DBNull.Value ? "" : mDt["Rol"]);
                        usuario.Email = Convert.ToString(mDt["Email"] == DBNull.Value ? "" : mDt["Email"]);

                        // Convertimos el booleano solo si no es nulo
                        usuario.Bloqueado = mDt["Bloqueado"] != DBNull.Value && Convert.ToBoolean(mDt["Bloqueado"]);
                        usuario.Activo = mDt["Activo"] != DBNull.Value && Convert.ToBoolean(mDt["Activo"]);

                        lista.Add(usuario);
                    }
                }
            }
            return lista;
        }

        public void Alta(Usuario usuario)
        {
            using (SqlConnection mCon = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Usuarios (DNI, Apellido, Nombre, NombreUsuario, Clave, Rol, Email, IntentosFallidos, Bloqueado, Activo) VALUES (@DNI, @Apellido, @Nombre, @NombreUsuario, @Clave, @Rol, @Email, 0, 0, 1)"; SqlCommand mCom = new SqlCommand(query, mCon);
                mCom.Parameters.AddWithValue("@DNI", usuario.DNI);
                mCom.Parameters.AddWithValue("@Apellido", usuario.Apellido);
                mCom.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                mCom.Parameters.AddWithValue("@NombreUsuario", usuario.NombreUsuario);
                mCom.Parameters.AddWithValue("@Clave", usuario.Clave);
                mCom.Parameters.AddWithValue("@Rol", usuario.Rol);
                mCom.Parameters.AddWithValue("@Email", usuario.Email);

                mCon.Open();
                mCom.ExecuteNonQuery();
            }
        }

        public void Modificar(Usuario usuario)
        {
            using (SqlConnection mCon = new SqlConnection(connectionString))
            {
                string mCommandText = "UPDATE Usuarios SET DNI = @DNI, Apellido = @Apellido, Nombre = @Nombre, NombreUsuario = @NombreUsuario, Rol = @Rol, Email = @Email, Activo = @Activo, Bloqueado = @Bloqueado, IntentosFallidos = @IntentosFallidos WHERE ID_Usuario = @ID";
                SqlCommand mCom = new SqlCommand(mCommandText, mCon);

                mCom.Parameters.AddWithValue("@DNI", usuario.DNI);
                mCom.Parameters.AddWithValue("@Apellido", usuario.Apellido);
                mCom.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                mCom.Parameters.AddWithValue("@NombreUsuario", usuario.NombreUsuario);
                mCom.Parameters.AddWithValue("@Rol", usuario.Rol);
                mCom.Parameters.AddWithValue("@Email", usuario.Email);
                mCom.Parameters.AddWithValue("@Activo", usuario.Activo);
                mCom.Parameters.AddWithValue("@Bloqueado", usuario.Bloqueado);

                mCom.Parameters.AddWithValue("@IntentosFallidos", usuario.IntentosFallidos);

                mCom.Parameters.AddWithValue("@ID", usuario.ID_Usuario);

                mCon.Open();
                mCom.ExecuteNonQuery();
            }
        }


        public Usuario ObtenerPorNombre(string nombreUsuario)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT ID_Usuario, NombreUsuario, Clave, IntentosFallidos, Bloqueado, Rol, Nombre, Apellido FROM Usuarios WHERE NombreUsuario = @Usuario";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Usuario", nombreUsuario.Trim());

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
                        usu.Rol = dr["Rol"].ToString();

                        usu.Nombre = dr["Nombre"] != DBNull.Value ? dr["Nombre"].ToString() : "";
                        usu.Apellido = dr["Apellido"] != DBNull.Value ? dr["Apellido"].ToString() : "";

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
        public void CambiarClave(string nombreUsuario, string nuevaClaveHasheada)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "UPDATE Usuarios SET Clave = @NuevaClave WHERE NombreUsuario = @Usuario";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@NuevaClave", nuevaClaveHasheada);
                cmd.Parameters.AddWithValue("@Usuario", nombreUsuario);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}