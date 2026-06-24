using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Entities
{
    public class Patente : Componente
    {
        public override void Agregar(Componente c)
        {
            throw new Exception("No se pueden agregar hijos a una Patente.");
        }

        public override void Quitar(Componente c)
        {
            throw new Exception("No se pueden quitar hijos de una Patente.");
        }

        public override List<Componente> ObtenerHijos()
        {
            return new List<Componente>(); 
        }
    }
}
