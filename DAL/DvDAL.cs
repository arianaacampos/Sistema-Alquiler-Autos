using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL
{
    public class DvDAL
    {
        private string connectionString = ConfiguradorBD.ObtenerCadena();

        private string masterConnectionString = ConfiguradorBD.ObtenerCadena().Replace("DB_AlquilerAutos", "master");

        public DataTable LeerTabla(string nombreTabla)
        {
            DataTable dt = new DataTable();
            using (SqlConnection cx = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand($"SELECT * FROM [{nombreTabla}]", cx);
                cx.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    dt.Load(dr);
                }
            }
            return dt;
        }

        public void ActualizarDVH(string tabla, string pkColumna, string id, string dvh)
        {
            using (SqlConnection cx = new SqlConnection(connectionString))
            {
                string query = $"UPDATE [{tabla}] SET DVH = @dvh WHERE {pkColumna} = @id";
                SqlCommand cmd = new SqlCommand(query, cx);
                cmd.Parameters.AddWithValue("@dvh", dvh);
                cmd.Parameters.AddWithValue("@id", id);
                cx.Open();
                cmd.ExecuteNonQuery();
            }
        }

 
        public void ActualizarDVV(string tabla, string dvv)
        {
            using (SqlConnection cx = new SqlConnection(connectionString))
            {

                string query = "IF EXISTS (SELECT 1 FROM DV WHERE Tabla = @tabla) " +
                               "UPDATE DV SET DVV = @dvv WHERE Tabla = @tabla " +
                               "ELSE " +
                               "INSERT INTO DV (Tabla, DVV) VALUES (@tabla, @dvv)";
                SqlCommand cmd = new SqlCommand(query, cx);
                cmd.Parameters.AddWithValue("@dvv", dvv);
                cmd.Parameters.AddWithValue("@tabla", tabla);
                cx.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public string ObtenerDVV(string tabla)
        {
            using (SqlConnection cx = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT DVV FROM DV WHERE Tabla = @tabla", cx);
                cmd.Parameters.AddWithValue("@tabla", tabla);
                cx.Open();
                var result = cmd.ExecuteScalar();
                return result != null ? result.ToString() : "";
            }
        }
    }
}
