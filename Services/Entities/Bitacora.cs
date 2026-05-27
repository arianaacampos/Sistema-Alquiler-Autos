using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Entities
{
    public class Bitacora
    {
        public int ID_Bitacora { get; set; }
        public DateTime FechaHora { get; set; }
        public string Usuario { get; set; } 
        public string Modulo { get; set; }  
        public string Evento { get; set; }  
        public string Criticidad { get; set; } 

        public Bitacora() { }

        public Bitacora(string usuario, string modulo, string evento, string criticidad)
        {
            this.FechaHora = DateTime.Now; 
            this.Usuario = usuario;
            this.Modulo = modulo;
            this.Evento = evento;
            this.Criticidad = criticidad;
        }
    }
}
