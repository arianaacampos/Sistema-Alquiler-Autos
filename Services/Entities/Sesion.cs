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
            }
        }
    }
}
