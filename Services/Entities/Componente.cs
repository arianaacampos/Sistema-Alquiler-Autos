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

        public abstract void Agregar(Componente c);
        public abstract void Quitar(Componente c);
        public abstract List<Componente> ObtenerHijos();
    }
}
