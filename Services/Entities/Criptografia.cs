using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Services.Entities
{
    public static class Criptografia
    {
        public static string EncriptarHash(string textoPlano)
        {
            // Instanciamos el algoritmo SHA256
            using (SHA256 sha256 = SHA256.Create())
            {
                // convertimos el texto a un arreglo de Bytes
                byte[] bytesOriginales = Encoding.UTF8.GetBytes(textoPlano);
                byte[] bytesHasheados = sha256.ComputeHash(bytesOriginales);

                // Convertimos esos números a un texto legible 
                StringBuilder resultado = new StringBuilder();
                for (int i = 0; i < bytesHasheados.Length; i++)
                {
                    resultado.Append(bytesHasheados[i].ToString("x2"));
                }

                return resultado.ToString();
            }
        }
    }
}
