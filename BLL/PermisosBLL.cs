using DAL;
using Services.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PermisosBLL
    {
        private PermisosDAL _permisosDAL = new PermisosDAL();

        // Instanciamos tu gestor de bitácora que ya tenés programado
        private BitacoraBLL _bitacoraBLL = new BitacoraBLL();

        // 1. Método para CREAR
        public void CrearComponente(Componente componente, string tipoComponente)
        {
            // Validamos que no venga vacío (Cumple con "Verificar Creación")
            if (string.IsNullOrWhiteSpace(componente.Nombre))
            {
                throw new Exception("El nombre del componente no puede estar vacío.");
            }

            // Mandamos a guardar a la base de datos
            _permisosDAL.CrearComponente(componente, tipoComponente);

            // Reportamos a la Bitácora automáticamente
            string usuarioActivo = Sesion.Instancia.UsuarioActual ?? "Sistema";
            _bitacoraBLL.Registrar(usuarioActivo, "Perfiles", "Se creó un/a " + tipoComponente + ": " + componente.Nombre, "Media");
        }

        // 2. Método para ELIMINAR
        public void EliminarComponente(int idPermiso, string nombreComponente, string tipoComponente)
        {
            _permisosDAL.EliminarComponente(idPermiso);

            // Reportamos a la Bitácora
            string usuarioActivo = Sesion.Instancia.UsuarioActual ?? "Sistema";
            _bitacoraBLL.Registrar(usuarioActivo, "Perfiles", "Se eliminó el/la " + tipoComponente + ": " + nombreComponente, "Alta");
        }

        // 3. Método para LISTAR
        public List<Componente> ObtenerTodos()
        {
            return _permisosDAL.ObtenerTodos();
        }
        public void AsignarComponente(int idPadre, int idHijo)
        {
            _permisosDAL.GuardarRelacion(idPadre, idHijo);
            string usu = Sesion.Instancia.UsuarioActual ?? "Sistema";
            _bitacoraBLL.Registrar(usu, "Perfiles", "Se asignó un componente a otro", "Media");
        }

        public void QuitarComponente(int idPadre, int idHijo)
        {
            _permisosDAL.BorrarRelacion(idPadre, idHijo);
            string usu = Sesion.Instancia.UsuarioActual ?? "Sistema";
            _bitacoraBLL.Registrar(usu, "Perfiles", "Se quitó un componente de otro", "Media");
        }

        public List<Componente> ObtenerHijos(int idPadre)
        {
            return _permisosDAL.ObtenerHijos(idPadre);
        }
    }
}
