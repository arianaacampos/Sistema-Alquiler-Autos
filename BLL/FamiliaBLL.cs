using DAL;
using Services.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class FamiliaBLL
    {
        private FamiliaDAL _dal = new FamiliaDAL();

        public List<Componente> ObtenerTodos() => _dal.ObtenerTodos();
        public int Crear(Componente f)
        {
            int id = _dal.Insertar(f);
            new DvBLL().RecalcularTodo();
            return id;
        }
        public List<Componente> ObtenerHijos(int id) => _dal.ObtenerHijos(id);

        public void AsignarComponente(int idPadre, Componente hijo, bool esPatente)
        {
            if (idPadre == hijo.Id && !esPatente) throw new Exception("Recursividad: No se puede asignar a sí misma.");

            if (esPatente) _dal.AsignarPatente(idPadre, hijo.Id);
            else _dal.AsignarSubFamilia(idPadre, hijo.Id);
            new DvBLL().RecalcularTodo();
        }

        public void QuitarComponente(int idPadre, Componente hijo, bool esPatente)
        {
            if (esPatente) _dal.QuitarPatente(idPadre, hijo.Id);
            else _dal.QuitarSubFamilia(idPadre, hijo.Id);
            new DvBLL().RecalcularTodo();
        }

        public void Eliminar(int id)
        {
            _dal.Eliminar(id);
            new DvBLL().RecalcularTodo();
        }
    }
}
