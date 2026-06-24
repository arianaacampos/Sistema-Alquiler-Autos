using Services.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL
{
    public class PatenteDAL
    {
        private string connectionString = "Data Source=.;Initial Catalog=DB_AlquilerAutos;Integrated Security=True;Pooling=False;";

        public List<Componente> ObtenerTodos()
        {
            List<Componente> lista = new List<Componente>();
            using (SqlConnection cx = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT IdPatente, Nombre FROM Patente", cx);
                cx.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Patente { Id = Convert.ToInt32(dr["IdPatente"]), Nombre = dr["Nombre"].ToString() });
                    }
                }
            }
            return lista;
        }

        public void Insertar(Componente p)
        {
            using (SqlConnection cx = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Patente (Nombre) VALUES (@nom)", cx);
                cmd.Parameters.AddWithValue("@nom", p.Nombre);
                cx.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Eliminar(int id)
        {
            using (SqlConnection cx = new SqlConnection(connectionString))
            {
                cx.Open();
                new SqlCommand($"DELETE FROM Familia_Patente WHERE IdPatente = {id}", cx).ExecuteNonQuery();
                new SqlCommand($"DELETE FROM Rol_Patente WHERE IdPatente = {id}", cx).ExecuteNonQuery();
                new SqlCommand($"DELETE FROM Patente WHERE IdPatente = {id}", cx).ExecuteNonQuery();
            }
        }
    }
}
