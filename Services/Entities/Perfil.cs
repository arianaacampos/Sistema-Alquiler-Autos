using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Entities
{
    public class Perfil : Componente
    {
        private List<Componente> _hijos;

        public Perfil()
        {
            _hijos = new List<Componente>();
        }

        public override void AgregarHijo(Componente c)
        {
            if (!_hijos.Contains(c))
            {
                _hijos.Add(c);
            }
        }

        public override void QuitarHijo(Componente c)
        {
            if (_hijos.Contains(c))
            {
                _hijos.Remove(c);
            }
        }

        public override IList<Componente> ObtenerHijos()
        {
            return _hijos;
        }

        public override void VaciarHijos()
        {
            _hijos.Clear();
        }
    }
}
