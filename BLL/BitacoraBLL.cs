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
            if (string.IsNullOrEmpty(usuario))
            {
                usuario = "SISTEMA";
            }

            Bitacora nuevaBitacora = new Bitacora(usuario, modulo, evento, criticidad);

            dal.RegistrarEvento(nuevaBitacora);
        }

        public List<Bitacora> Consultar()
        {
            return dal.ConsultarBitacora();
        }
    }
}
