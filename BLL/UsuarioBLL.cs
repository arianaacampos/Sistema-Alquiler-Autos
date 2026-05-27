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
                return "El usuario ingresado no existe.";
            }


            if (usu.Bloqueado)
            {
                return "Su cuenta se encuentra bloqueada por superar el límite de intentos. Contacte al administrador.";
            }

            string claveHasheada = Criptografia.EncriptarHash(claveIngresada);


            if (usu.Clave == claveHasheada)
            {

                usu.IntentosFallidos = 0;
                _usuarioDAL.ActualizarIntentos(usu);
                return "OK";
            }
            else
            {

                usu.IntentosFallidos += 1;

                if (usu.IntentosFallidos >= 3)
                {
                    usu.Bloqueado = true;
                    _usuarioDAL.ActualizarIntentos(usu);
                    return "Contraseña incorrecta. Su cuenta ha sido bloqueada tras 3 intentos fallidos.";
                }

                _usuarioDAL.ActualizarIntentos(usu);
                return "Contraseña incorrecta. Le quedan " + (3 - usu.IntentosFallidos) + " intentos.";
            }
        }
    }
}