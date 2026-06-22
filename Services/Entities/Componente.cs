using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Entities
{
    public abstract class Componente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Permiso { get; set; } 

        public abstract void AgregarHijo(Componente c);
        public abstract void QuitarHijo(Componente c);
        public abstract void VaciarHijos();
        public abstract IList<Componente> ObtenerHijos();
    }
}
