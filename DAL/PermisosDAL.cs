using Services.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL
{
    public class PermisosDAL
    {
        // Usamos la misma cadena de conexión que ya tenés en tus otros DAL
        private string connectionString = "Data Source=.;Initial Catalog=DB_AlquilerAutos;Integrated Security=True;";

        public void CrearComponente(Componente componente, string tipoComponente)
        {
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                string consulta = "INSERT INTO Permiso (Nombre, NombreInterno, TipoComponente) VALUES (@nombre, @nombreInterno, @tipo)";
                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@nombre", componente.Nombre);

                    // Si es Familia o Perfil, el NombreInterno suele ser vacío/null. 
                    // Si es un Permiso suelto, ahí sí guardamos el nombre (ej: "btnCrear").
                    comando.Parameters.AddWithValue("@nombreInterno", string.IsNullOrEmpty(componente.Permiso) ? (object)DBNull.Value : componente.Permiso);

                    comando.Parameters.AddWithValue("@tipo", tipoComponente);

                    conexion.Open();
                    comando.ExecuteNonQuery();
                }
            }
        }

        public void EliminarComponente(int idPermiso)
        {
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                // Para eliminar, PRIMERO hay que borrar si tiene hijos/padres (tabla intermedia) 
                // y SEGUNDO borrar el registro principal. Usamos una Transacción para que sea seguro.
                string consultaRelaciones = "DELETE FROM Familia_Permiso WHERE Id_Padre = @id OR Id_Hijo = @id";
                string consultaPermiso = "DELETE FROM Permiso WHERE Id_Permiso = @id";

                conexion.Open();
                using (SqlTransaction transaccion = conexion.BeginTransaction())
                {
                    try
                    {
                        using (SqlCommand cmd1 = new SqlCommand(consultaRelaciones, conexion, transaccion))
                        {
                            cmd1.Parameters.AddWithValue("@id", idPermiso);
                            cmd1.ExecuteNonQuery();
                        }

                        using (SqlCommand cmd2 = new SqlCommand(consultaPermiso, conexion, transaccion))
                        {
                            cmd2.Parameters.AddWithValue("@id", idPermiso);
                            cmd2.ExecuteNonQuery();
                        }

                        transaccion.Commit(); // Si todo salió bien, guardamos los cambios
                    }
                    catch (Exception ex)
                    {
                        transaccion.Rollback(); // Si hubo error, cancelamos todo para no romper la BD
                        throw new Exception("Error al eliminar el componente: " + ex.Message);
                    }
                }
            }
        }

        public List<Componente> ObtenerTodos()
        {
            List<Componente> lista = new List<Componente>();
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                string consulta = "SELECT Id_Permiso, Nombre, NombreInterno, TipoComponente FROM Permiso";
                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    conexion.Open();
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string tipo = reader["TipoComponente"].ToString();
                            Componente c;

                            // Aplicamos el polimorfismo del patrón Composite
                            if (tipo == "Perfil") c = new Perfil();
                            else if (tipo == "Familia") c = new Familia();
                            else c = new Permiso(); // Es un permiso hoja

                            c.Id = Convert.ToInt32(reader["Id_Permiso"]);
                            c.Nombre = reader["Nombre"].ToString();
                            c.Permiso = reader["NombreInterno"] != DBNull.Value ? reader["NombreInterno"].ToString() : "";

                            lista.Add(c);
                        }
                    }
                }
            }
            return lista;
        }
        public void GuardarRelacion(int idPadre, int idHijo)
        {
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                string consulta = "INSERT INTO Familia_Permiso (Id_Padre, Id_Hijo) VALUES (@padre, @hijo)";
                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@padre", idPadre);
                    comando.Parameters.AddWithValue("@hijo", idHijo);
                    conexion.Open();
                    comando.ExecuteNonQuery();
                }
            }
        }

        public void BorrarRelacion(int idPadre, int idHijo)
        {
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                string consulta = "DELETE FROM Familia_Permiso WHERE Id_Padre = @padre AND Id_Hijo = @hijo";
                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@padre", idPadre);
                    comando.Parameters.AddWithValue("@hijo", idHijo);
                    conexion.Open();
                    comando.ExecuteNonQuery();
                }
            }
        }

        public List<Componente> ObtenerHijos(int idPadre)
        {
            List<Componente> lista = new List<Componente>();
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                string consulta = @"SELECT p.Id_Permiso, p.Nombre, p.TipoComponente 
                                    FROM Permiso p 
                                    INNER JOIN Familia_Permiso fp ON p.Id_Permiso = fp.Id_Hijo 
                                    WHERE fp.Id_Padre = @padre";
                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@padre", idPadre);
                    conexion.Open();
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string tipo = reader["TipoComponente"].ToString();
                            Componente c;
                            if (tipo == "Perfil") c = new Perfil();
                            else if (tipo == "Familia") c = new Familia();
                            else c = new Permiso();

                            c.Id = Convert.ToInt32(reader["Id_Permiso"]);
                            c.Nombre = reader["Nombre"].ToString();
                            lista.Add(c);
                        }
                    }
                }
            }
            return lista;
        }
    }
}
