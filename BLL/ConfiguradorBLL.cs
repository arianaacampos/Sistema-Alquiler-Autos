using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BLL
{
    public class ConfiguradorBLL
    {
        public void GuardarInstancia(string nuevaInstancia)
        {
            ConfiguradorBD.GuardarInstancia(nuevaInstancia);
        }
        public bool ProbarConexionActual()
        {
            try
            {
                using (SqlConnection cx = new SqlConnection(ConfiguradorBD.ObtenerCadena()))
                {
                    cx.Open();
                    return true; 
                }
            }
            catch
            {
                return false; 
            }
        }

        public bool ProbarNuevaConexion(string instancia)
        {
            string cadenaPrueba = $"Data Source={instancia};Initial Catalog=DB_AlquilerAutos;Integrated Security=True;";
            try
            {
                using (SqlConnection cx = new SqlConnection(cadenaPrueba))
                {
                    cx.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
