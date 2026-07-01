using DAL;
using Services.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RespaldoBLL
    {
        private RespaldoDAL _dal = new RespaldoDAL();

        public void RealizarBackup(string directorioSeleccionado)
        {
            string fechaHora = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string nombreArchivo = $"SistemaAlquiler_{fechaHora}.bak";
            string rutaCompleta = System.IO.Path.Combine(directorioSeleccionado, nombreArchivo);

            _dal.RealizarBackup(rutaCompleta);

            new BitacoraBLL().Registrar(Sesion.Instancia.UsuarioActual, "Admin", $"Backup exitoso generado en: {rutaCompleta}", "Alta");
        }

        public void RealizarRestore(string rutaArchivoBak)
        {
            _dal.RealizarRestore(rutaArchivoBak);
            string usuarioActivo = string.IsNullOrEmpty(Sesion.Instancia.UsuarioActual) ? "Sistema_Emergencia" : Sesion.Instancia.UsuarioActual;

            new BitacoraBLL().Registrar(usuarioActivo, "Admin", $"Restore exitoso ejecutado desde: {rutaArchivoBak}", "Alta");
            new DvBLL().RecalcularTodo();
        }
    }
}
