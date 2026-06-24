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

        public void AsignarPerfilAUsuario(int idUsuario, int idRol)
        {
            _dal.AsignarPerfilAUsuario(idUsuario, idRol);
        }

        public List<Componente> ObtenerPermisosDelUsuario(int idUsuario)
        {
            List<Componente> listaPatentesPlanas = new List<Componente>();
            HashSet<int> familiasVisitadas = new HashSet<int>(); 

            int idRol = _dal.ObtenerRolDeUsuario(idUsuario);
            if (idRol > 0)
            {
                ExtraerPatentesRecursivo(idRol, listaPatentesPlanas, true, familiasVisitadas);
            }
            return listaPatentesPlanas;
        }

        private void ExtraerPatentesRecursivo(int idPadre, List<Componente> listaPlana, bool padreEsRol, HashSet<int> visitadas)
        {
           
            if (!padreEsRol)
            {
                if (visitadas.Contains(idPadre)) return;
                visitadas.Add(idPadre);
            }

            var hijos = padreEsRol ? _dal.ObtenerHijos(idPadre) : new FamiliaBLL().ObtenerHijos(idPadre);

            foreach (var hijo in hijos)
            {
                if (hijo.GetType().Name == "Patente")
                {
                    if (!listaPlana.Any(p => p.Id == hijo.Id))
                    {
                        listaPlana.Add(hijo);
                    }
                }
                else if (hijo.GetType().Name == "Familia")
                {

                    ExtraerPatentesRecursivo(hijo.Id, listaPlana, false, visitadas);
                }
            }
        }
    }
}
