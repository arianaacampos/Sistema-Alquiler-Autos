using DAL;
using Services.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BitacoraBLL
    {
        private BitacoraDAL dal = new BitacoraDAL();

        public void Registrar(string usuario, string modulo, string evento, string criticidad)
        {
            Bitacora nuevaBitacora = new Bitacora(usuario, modulo, evento, criticidad);
            dal.RegistrarEvento(nuevaBitacora);
        }

        public List<Bitacora> Consultar()
        {
            return dal.ConsultarBitacora();
        }
        public List<Bitacora> ConsultarFiltrado(DateTime desde, DateTime hasta, string usuario, string modulo, string evento, string criticidad)
        {
            return dal.ConsultarConFiltros(desde, hasta, usuario, modulo, evento, criticidad);
        }

    }
}
