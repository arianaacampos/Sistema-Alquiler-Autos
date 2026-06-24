using DAL;
using Services.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PatenteBLL
    {
        private PatenteDAL _dal = new PatenteDAL();
        public List<Componente> ObtenerTodos() => _dal.ObtenerTodos();
        public void Crear(Componente p) => _dal.Insertar(p);
        public void Eliminar(int id) => _dal.Eliminar(id);
    }
}
