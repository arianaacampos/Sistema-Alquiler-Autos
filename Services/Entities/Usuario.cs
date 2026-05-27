using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Entities
{
    public class Usuario
    {
        public int ID_Usuario { get; set; }
        public string NombreUsuario { get; set; }
        public string Clave { get; set; }
        public int IntentosFallidos { get; set; }
        public bool Bloqueado { get; set; }

        public Usuario() { }

        public Usuario(string nombreUsuario, string clave)
        {
            NombreUsuario = nombreUsuario;
            Clave = clave;
            IntentosFallidos = 0;
            Bloqueado = false;
        }
    }
}
