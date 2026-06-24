using Services.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL
{
    public class FamiliaDAL
    {
        private string connectionString = "Server=.;Database=SistemaAlquiler;Trusted_Connection=True;";

        public List<Componente> ObtenerTodos()
        {
            List<Componente> lista = new List<Componente>();
            using (SqlConnection cx = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT IdFamilia, Nombre FROM Familia", cx);
                cx.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Familia { Id = Convert.ToInt32(dr["IdFamilia"]), Nombre = dr["Nombre"].ToString() });
                    }
                }
            }
            return lista;
        }

        public int Insertar(Componente f)
        {
            using (SqlConnection cx = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Familia (Nombre) OUTPUT INSERTED.IdFamilia VALUES (@nom)", cx);
                cmd.Parameters.AddWithValue("@nom", f.Nombre);
                cx.Open();
                return (int)cmd.ExecuteScalar();
            }
        }

        public List<Componente> ObtenerHijos(int idFamilia)
        {
            List<Componente> hijos = new List<Componente>();
            using (SqlConnection cx = new SqlConnection(connectionString))
            {

                SqlCommand cmdP = new SqlCommand("SELECT p.IdPatente, p.Nombre FROM Patente p INNER JOIN Familia_Patente fp ON p.IdPatente = fp.IdPatente WHERE fp.IdFamilia = @id", cx);
                cmdP.Parameters.AddWithValue("@id", idFamilia);
                cx.Open();
                using (SqlDataReader dr = cmdP.ExecuteReader())
                {
                    while (dr.Read())
                        hijos.Add(new Patente { Id = Convert.ToInt32(dr["IdPatente"]), Nombre = dr["Nombre"].ToString() });
                }
                cx.Close();


                SqlCommand cmdF = new SqlCommand("SELECT f.IdFamilia, f.Nombre FROM Familia f INNER JOIN Familia_Familia ff ON f.IdFamilia = ff.IdHijo WHERE ff.IdPadre = @id", cx);
                cmdF.Parameters.AddWithValue("@id", idFamilia);
                cx.Open();
                using (SqlDataReader dr = cmdF.ExecuteReader())
                {
                    while (dr.Read())
                        hijos.Add(new Familia { Id = Convert.ToInt32(dr["IdFamilia"]), Nombre = dr["Nombre"].ToString() });
                }
            }
            return hijos;
        }

        public void AsignarPatente(int idFamilia, int idPatente)
        {
            EjecutarQuery($"INSERT INTO Familia_Patente (IdFamilia, IdPatente) VALUES ({idFamilia}, {idPatente})");
        }
        public void QuitarPatente(int idFamilia, int idPatente)
        {
            EjecutarQuery($"DELETE FROM Familia_Patente WHERE IdFamilia = {idFamilia} AND IdPatente = {idPatente}");
        }
        public void AsignarSubFamilia(int idPadre, int idHijo)
        {
            EjecutarQuery($"INSERT INTO Familia_Familia (IdPadre, IdHijo) VALUES ({idPadre}, {idHijo})");
        }
        public void QuitarSubFamilia(int idPadre, int idHijo)
        {
            EjecutarQuery($"DELETE FROM Familia_Familia WHERE IdPadre = {idPadre} AND IdHijo = {idHijo}");
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
                new SqlCommand($"DELETE FROM Familia_Patente WHERE IdFamilia = {id}", cx).ExecuteNonQuery();
                new SqlCommand($"DELETE FROM Familia_Familia WHERE IdPadre = {id} OR IdHijo = {id}", cx).ExecuteNonQuery();
                new SqlCommand($"DELETE FROM Rol_Familia WHERE IdFamilia = {id}", cx).ExecuteNonQuery();
                new SqlCommand($"DELETE FROM Familia WHERE IdFamilia = {id}", cx).ExecuteNonQuery();
            }
        }
    }
}
