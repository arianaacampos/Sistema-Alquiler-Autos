using DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
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

        public string ProbarNuevaConexion(string instancia)
        {
            string cadenaMaster = $"Data Source={instancia};Initial Catalog=master;Integrated Security=True;";
            string rutaScript = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ScriptBD.sql");

            try
            {
                using (System.Data.SqlClient.SqlConnection cx = new System.Data.SqlClient.SqlConnection(cadenaMaster))
                {
                    cx.Open();

                    System.Data.SqlClient.SqlCommand cmdCheck = new System.Data.SqlClient.SqlCommand("SELECT DB_ID('DB_AlquilerAutos')", cx);
                    object existe = cmdCheck.ExecuteScalar();

                    if (existe == DBNull.Value || existe == null)
                    {
                        System.Data.SqlClient.SqlCommand cmdCrear = new System.Data.SqlClient.SqlCommand("CREATE DATABASE DB_AlquilerAutos", cx);
                        cmdCrear.ExecuteNonQuery();

                        System.Threading.Thread.Sleep(2000);

                        if (!System.IO.File.Exists(rutaScript))
                        {

                            return "Falta el archivo ScriptBD.sql. El instalador no lo copió.";
                        }

                        string scriptCompleto = System.IO.File.ReadAllText(rutaScript);
                        string[] comandos = System.Text.RegularExpressions.Regex.Split(scriptCompleto, @"^\s*GO\s*$", System.Text.RegularExpressions.RegexOptions.Multiline | System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                        string cadenaTuBase = $"Data Source={instancia};Initial Catalog=DB_AlquilerAutos;Integrated Security=True;";
                        using (System.Data.SqlClient.SqlConnection cxNueva = new System.Data.SqlClient.SqlConnection(cadenaTuBase))
                        {
                            cxNueva.Open();
                            foreach (string comando in comandos)
                            {
                                if (!string.IsNullOrWhiteSpace(comando))
                                {
                                    using (System.Data.SqlClient.SqlCommand cmdEjecutar = new System.Data.SqlClient.SqlCommand(comando, cxNueva))
                                    {
                                        cmdEjecutar.ExecuteNonQuery();
                                    }
                                }
                            }
                        }
                    }
                    return "OK"; 
                }
            }
            catch (Exception ex)
            {

                return "Error al intentar crear la base de datos automáticamente:\n\n" + ex.Message;
            }
        }
    } 
}
