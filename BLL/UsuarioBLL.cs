using DAL;
using Services.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UsuarioBLL
    {
        private UsuarioDAL _usuarioDAL = new UsuarioDAL();

        public string ValidarLogin(string nombreUsuario, string claveIngresada)
        {

            Usuario usu = _usuarioDAL.ObtenerPorNombre(nombreUsuario);

            if (usu == null)
            {
                return "El usuario ingresado no existe";
            }
            if (usu.Bloqueado)
            {
                return "Su cuenta se encuentra bloqueada por superar el limite";
            }

            string claveHasheada = Criptografia.EncriptarHash(claveIngresada);


            if (usu.Clave == claveHasheada)
            {

                usu.IntentosFallidos = 0;
                _usuarioDAL.ActualizarIntentos(usu);
                new DvBLL().RecalcularTodo();
                return "OK";
            }
            else
            {

                usu.IntentosFallidos += 1;

                if (usu.IntentosFallidos >= 3)
                {
                    usu.Bloqueado = true;
                    _usuarioDAL.ActualizarIntentos(usu);
                    return "Contraseña incorrecta. Su cuenta ha sido bloqueada tras 3 intentos";
                }

                _usuarioDAL.ActualizarIntentos(usu);
                return "Contraseña incorrecta. Le quedan " + (3 - usu.IntentosFallidos) + " intentos.";
                new DvBLL().RecalcularTodo();
            }
        }
        public List<Usuario> Listar()
        {
            return _usuarioDAL.Listar();
        }

        public void Alta(Usuario usuario)
        {
            
            _usuarioDAL.Alta(usuario);
            BitacoraBLL bitacora = new BitacoraBLL();
            bitacora.Registrar(Sesion.Instancia.UsuarioActual, "Usuario", "Alta Usuario", "Media");
            new DvBLL().RecalcularTodo();
        }

        public void Modificar(Usuario usuario)
        {
            _usuarioDAL.Modificar(usuario);
            BitacoraBLL bitacora = new BitacoraBLL();
            bitacora.Registrar(Sesion.Instancia.UsuarioActual, "Usuario", "Modificación Usuario", "Media");
            new DvBLL().RecalcularTodo();
        }
        public string CambiarClave(string nombreUsuario, string claveActual, string nuevaClave)
        {
            Usuario usu = _usuarioDAL.ObtenerPorNombre(nombreUsuario);

            if (usu == null)
            {
                return "Error: No se encontro el usuario";
            }

            string hashActual = Criptografia.EncriptarHash(claveActual);
            if (usu.Clave != hashActual)
            {
                return "La clave es incorrecta";
            }

            string nuevaClaveHash = Criptografia.EncriptarHash(nuevaClave);
            _usuarioDAL.CambiarClave(nombreUsuario, nuevaClaveHash);

            BitacoraBLL bitacora = new BitacoraBLL();
            bitacora.Registrar(nombreUsuario, "Usuario", "Cambiar Clave", "Media");
            new DvBLL().RecalcularTodo();
            return "OK";
        }
        public Services.Entities.Usuario ObtenerPorNombre(string nombreUsuario)
        {
            return _usuarioDAL.ObtenerPorNombre(nombreUsuario);
        }
        public void ModificarIdiomaUsuario(string nombreUsuario, string idioma)
        {
            DAL.UsuarioDAL gestorDatosUsuario = new DAL.UsuarioDAL();
            gestorDatosUsuario.ActualizarIdiomaPreferencia(nombreUsuario, idioma);
            new DvBLL().RecalcularTodo();
        }
    }
}