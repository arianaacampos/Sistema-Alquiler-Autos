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
        public string DNI {  get; set; }
        public string Apellido { get; set; }
        public string Nombre {  get; set; }
        public string Rol {  get; set; }
        public string Email { get; set; }
        public bool Activo { get; set; }
        public string IdiomaPreferencia { get; set; }

        public Usuario() { }

        public Usuario(string nombreUsuario, string clave)
        {
            NombreUsuario = nombreUsuario;
            Clave = clave;
            IntentosFallidos = 0;
            Bloqueado = false;
            Activo = true;
        }
    }
}
