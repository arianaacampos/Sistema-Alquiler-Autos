using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Entities
{
    public class Sesion
    {
        private static Sesion _instancia;
        private static readonly object _lock = new object();

        public string UsuarioActual { get; set; }
        public List<Componente> Permisos { get; set; } = new List<Componente>();

        public bool TienePermiso(string nombrePermiso)
        {

            return Permisos.Any(p => p.Nombre.Trim().ToLower() == nombrePermiso.Trim().ToLower());
        }
        private Sesion() { }

        public static Sesion Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    lock (_lock)
                    {
                        if (_instancia == null)
                        {
                            _instancia = new Sesion();
                        }
                    }
                }
                return _instancia;
            }
        }

        public void FinalizarSesion()
        {
            lock (_lock)
            {
                _instancia = null;
                UsuarioActual = null;
                Permisos.Clear();
            }
        }
    }
}
