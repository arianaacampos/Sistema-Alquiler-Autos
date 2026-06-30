using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DAL
{
    public static class ConfiguradorBD
    {
        private static string archivoConfig = "instancia_sql.txt";

        public static string ObtenerCadena()
        {
            string instancia = ".";

            if (File.Exists(archivoConfig))
            {
                instancia = File.ReadAllText(archivoConfig).Trim();
            }

            return $"Data Source={instancia};Initial Catalog=DB_AlquilerAutos;Integrated Security=True;Pooling=False;";
        }

        public static void GuardarInstancia(string nuevaInstancia)
        {
            File.WriteAllText(archivoConfig, nuevaInstancia);
        }
    }
}
    

