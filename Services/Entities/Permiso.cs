using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Entities
{
    public class Permiso : Componente
    {
        public override void AgregarHijo(Componente c)
        {
            
        }

        public override IList<Componente> ObtenerHijos()
        {
            return new List<Componente>();
        }

        public override void QuitarHijo(Componente c)
        {
            
        }

        public override void VaciarHijos()
        {
           
        }
    }
}
