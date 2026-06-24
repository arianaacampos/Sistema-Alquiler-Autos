using DAL;
using Services.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RolBLL
    {
        private RolDAL _dal = new RolDAL();

        public List<Componente> ObtenerTodos() => _dal.ObtenerTodos();
        public void Eliminar(int id) => _dal.Eliminar(id);
        public int Crear(Componente r) => _dal.Insertar(r);
        public List<Componente> ObtenerHijos(int id) => _dal.ObtenerHijos(id);

        public void AsignarComponente(int idRol, Componente hijo, bool esPatente)
        {
            if (esPatente) _dal.AsignarPatente(idRol, hijo.Id);
            else _dal.AsignarFamilia(idRol, hijo.Id);
        }

        public void QuitarComponente(int idRol, Componente hijo, bool esPatente)
        {
            if (esPatente) _dal.QuitarPatente(idRol, hijo.Id);
            else _dal.QuitarFamilia(idRol, hijo.Id);
        }
    }
}
