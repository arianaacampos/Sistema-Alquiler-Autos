using Services.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BitacoraDAL
    {
        private string connectionString = "Data Source=.;Initial Catalog=DB_AlquilerAutos;Integrated Security=True;";

        public void RegistrarEvento(Services.Entities.Bitacora evento)
        {
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                string consulta = "INSERT INTO Bitacora (FechaHora, Usuario, Modulo, Evento, Criticidad) " +
                                  "VALUES (@fecha, @usuario, @modulo, @evento, @criticidad)";

                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@fecha", evento.FechaHora);
                    comando.Parameters.AddWithValue("@usuario", evento.Usuario);
                    comando.Parameters.AddWithValue("@modulo", evento.Modulo);
                    comando.Parameters.AddWithValue("@evento", evento.Evento);
                    comando.Parameters.AddWithValue("@criticidad", evento.Criticidad);

                    try
                    {
                        conexion.Open(); 
                        comando.ExecuteNonQuery(); 
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al guardar en la bitacora de la base de datos: " + ex.Message);
                    }
                }
            }
        }
        public List<Bitacora> ConsultarBitacora()
        {
            List<Bitacora> listaEventos = new List<Bitacora>();

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                string consulta = "SELECT ID_Bitacora, FechaHora, Usuario, Modulo, Evento, Criticidad FROM Bitacora ORDER BY FechaHora DESC";

                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    try
                    {
                        conexion.Open();
                        using (SqlDataReader reader = comando.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Bitacora b = new Bitacora();
                                b.ID_Bitacora = Convert.ToInt32(reader["ID_Bitacora"]);
                                b.FechaHora = Convert.ToDateTime(reader["FechaHora"]);
                                b.Usuario = reader["Usuario"].ToString();
                                b.Modulo = reader["Modulo"].ToString();
                                b.Evento = reader["Evento"].ToString();
                                b.Criticidad = reader["Criticidad"].ToString();
                                listaEventos.Add(b);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al consultar la bitacora: " + ex.Message);
                    }
                }
            }
            return listaEventos;
        }
        public List<Bitacora> ConsultarConFiltros(DateTime desde, DateTime hasta, string usuario, string modulo, string evento, string criticidad)
        {
            List<Bitacora> listaEventos = new List<Bitacora>();
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                string consulta = "SELECT ID_Bitacora, FechaHora, Usuario, Modulo, Evento, Criticidad FROM Bitacora WHERE FechaHora >= @desde AND FechaHora <= @hasta";

                if (!string.IsNullOrEmpty(usuario)) consulta += " AND Usuario = @usuario";
                if (!string.IsNullOrEmpty(modulo)) consulta += " AND Modulo = @modulo";
                if (!string.IsNullOrEmpty(evento)) consulta += " AND Evento = @evento";
                if (!string.IsNullOrEmpty(criticidad)) consulta += " AND Criticidad = @criticidad";

                consulta += " ORDER BY FechaHora DESC";

                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@desde", desde);
                    comando.Parameters.AddWithValue("@hasta", hasta);
                    if (!string.IsNullOrEmpty(usuario)) comando.Parameters.AddWithValue("@usuario", usuario);
                    if (!string.IsNullOrEmpty(modulo)) comando.Parameters.AddWithValue("@modulo", modulo);
                    if (!string.IsNullOrEmpty(evento)) comando.Parameters.AddWithValue("@evento", evento);
                    if (!string.IsNullOrEmpty(criticidad)) comando.Parameters.AddWithValue("@criticidad", criticidad);

                    conexion.Open();
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Bitacora b = new Bitacora();
                            b.ID_Bitacora = Convert.ToInt32(reader["ID_Bitacora"]);
                            b.FechaHora = Convert.ToDateTime(reader["FechaHora"]);
                            b.Usuario = reader["Usuario"].ToString();
                            b.Modulo = reader["Modulo"].ToString();
                            b.Evento = reader["Evento"].ToString();
                            b.Criticidad = reader["Criticidad"].ToString();
                            listaEventos.Add(b);
                        }
                    }
                }
            }
            return listaEventos;
        }

    }
}
