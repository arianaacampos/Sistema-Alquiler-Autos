using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL
{
    public class RespaldoDAL
    {

        private string connectionString = ConfiguradorBD.ObtenerCadena();

        private string masterConnectionString = ConfiguradorBD.ObtenerCadena().Replace("DB_AlquilerAutos", "master");

        public void RealizarBackup(string rutaCompleta)
        {
            using (SqlConnection cx = new SqlConnection(connectionString))
            {
                string query = $"BACKUP DATABASE [DB_AlquilerAutos] TO DISK = '{rutaCompleta}'";
                SqlCommand cmd = new SqlCommand(query, cx);
                cx.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void RealizarRestore(string rutaOrigen)
        {
            using (SqlConnection cx = new SqlConnection(masterConnectionString))
            {
                string query = $@"
                    ALTER DATABASE [DB_AlquilerAutos] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
                    RESTORE DATABASE [DB_AlquilerAutos] FROM DISK = '{rutaOrigen}' WITH REPLACE;
                    ALTER DATABASE [DB_AlquilerAutos] SET MULTI_USER;";

                SqlCommand cmd = new SqlCommand(query, cx);
                cx.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
