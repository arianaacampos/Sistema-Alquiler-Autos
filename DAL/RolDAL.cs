using Services.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class RolDAL
    {
        private string connectionString = "Data Source=.;Initial Catalog=DB_AlquilerAutos;Integrated Security=True;Pooling=False;";

        public List<Componente> ObtenerTodos()
        {
            List<Componente> lista = new List<Componente>();
            using (SqlConnection cx = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT IdRol, Nombre FROM Rol", cx);
                cx.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                        lista.Add(new Rol { Id = Convert.ToInt32(dr["IdRol"]), Nombre = dr["Nombre"].ToString() });
                }
            }
            return lista;
        }

        public int Insertar(Componente r)
        {
            using (SqlConnection cx = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Rol (Nombre) OUTPUT INSERTED.IdRol VALUES (@nom)", cx);
                cmd.Parameters.AddWithValue("@nom", r.Nombre);
                cx.Open();
                return (int)cmd.ExecuteScalar();
            }
        }

        public List<Componente> ObtenerHijos(int idRol)
        {
            List<Componente> hijos = new List<Componente>();
            using (SqlConnection cx = new SqlConnection(connectionString))
            {
                cx.Open(); 

   
                SqlCommand cmdP = new SqlCommand("SELECT p.IdPatente, p.Nombre FROM Patente p INNER JOIN Rol_Patente rp ON p.IdPatente = rp.IdPatente WHERE rp.IdRol = @id", cx);
                cmdP.Parameters.AddWithValue("@id", idRol);
                using (SqlDataReader dr = cmdP.ExecuteReader())
                {
                    while (dr.Read()) hijos.Add(new Patente { Id = Convert.ToInt32(dr["IdPatente"]), Nombre = dr["Nombre"].ToString() });
                }

                SqlCommand cmdF = new SqlCommand("SELECT f.IdFamilia, f.Nombre FROM Familia f INNER JOIN Rol_Familia rf ON f.IdFamilia = rf.IdFamilia WHERE rf.IdRol = @id", cx);
                cmdF.Parameters.AddWithValue("@id", idRol);
                using (SqlDataReader dr = cmdF.ExecuteReader())
                {
                    while (dr.Read()) hijos.Add(new Familia { Id = Convert.ToInt32(dr["IdFamilia"]), Nombre = dr["Nombre"].ToString() });
                }
            }
            return hijos;
        }

        public void AsignarPatente(int idRol, int idPatente)
        {
            EjecutarQuery($"INSERT INTO Rol_Patente (IdRol, IdPatente) VALUES ({idRol}, {idPatente})");
        }
        public void QuitarPatente(int idRol, int idPatente)
        {
            EjecutarQuery($"DELETE FROM Rol_Patente WHERE IdRol = {idRol} AND IdPatente = {idPatente}");
        }
        public void AsignarFamilia(int idRol, int idFamilia)
        {
            EjecutarQuery($"INSERT INTO Rol_Familia (IdRol, IdFamilia) VALUES ({idRol}, {idFamilia})");
        }
        public void QuitarFamilia(int idRol, int idFamilia)
        {
            EjecutarQuery($"DELETE FROM Rol_Familia WHERE IdRol = {idRol} AND IdFamilia = {idFamilia}");
        }

        private void EjecutarQuery(string query)
        {
            using (SqlConnection cx = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, cx); cx.Open(); cmd.ExecuteNonQuery();
            }
        }

        public void Eliminar(int id)
        {
            using (SqlConnection cx = new SqlConnection(connectionString))
            {
                cx.Open();
                new SqlCommand($"DELETE FROM Rol_Patente WHERE IdRol = {id}", cx).ExecuteNonQuery();
                new SqlCommand($"DELETE FROM Rol_Familia WHERE IdRol = {id}", cx).ExecuteNonQuery();
                new SqlCommand($"DELETE FROM Usuario_Rol WHERE IdRol = {id}", cx).ExecuteNonQuery();
                new SqlCommand($"DELETE FROM Rol WHERE IdRol = {id}", cx).ExecuteNonQuery();
            }
        }

        public void AsignarPerfilAUsuario(int idUsuario, int idRol)
        {
            using (SqlConnection cx = new SqlConnection(connectionString))
            {
                cx.Open();

                SqlCommand cmdBorrar = new SqlCommand("DELETE FROM Usuario_Rol WHERE ID_Usuario = @usu", cx);
                cmdBorrar.Parameters.AddWithValue("@usu", idUsuario);
                cmdBorrar.ExecuteNonQuery();


                SqlCommand cmdInsertar = new SqlCommand("INSERT INTO Usuario_Rol (ID_Usuario, IdRol) VALUES (@usu, @rol)", cx);
                cmdInsertar.Parameters.AddWithValue("@usu", idUsuario);
                cmdInsertar.Parameters.AddWithValue("@rol", idRol);
                cmdInsertar.ExecuteNonQuery();
            }
        }

        public int ObtenerRolDeUsuario(int idUsuario)
        {
            using (SqlConnection cx = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT IdRol FROM Usuario_Rol WHERE ID_Usuario = @usu", cx);
                cmd.Parameters.AddWithValue("@usu", idUsuario);
                cx.Open();
                var resultado = cmd.ExecuteScalar();
                return resultado != null ? Convert.ToInt32(resultado) : 0;
            }
        }
    }
}
