using DAL;
using Services.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DvBLL
    {
        private DvDAL _dal = new DvDAL();


        private Dictionary<string, string> TablasCriticas = new Dictionary<string, string>
        {
            { "Usuarios", "ID_Usuario" },
            { "Bitacora", "ID_Bitacora" },
            { "Rol", "IdRol" },
            { "Familia", "IdFamilia" },
            { "Patente", "IdPatente" }
        };

        public void RecalcularTodo()
        {
            foreach (var item in TablasCriticas)
            {
                string nombreTabla = item.Key;
                string pkColumna = item.Value;

                DataTable dt = _dal.LeerTabla(nombreTabla);
                StringBuilder sbDvv = new StringBuilder();

                foreach (DataRow row in dt.Rows)
                {
                    string filaConcatenada = "";
                    string idFila = row[pkColumna].ToString();

                    foreach (DataColumn col in dt.Columns)
                    {
                        if (col.ColumnName == "DVH") continue; 
                        filaConcatenada += row[col].ToString();
                    }

                    string dvhCalculado = Criptografia.EncriptarHash(filaConcatenada);
                    sbDvv.Append(dvhCalculado);

                    _dal.ActualizarDVH(nombreTabla, pkColumna, idFila, dvhCalculado);
                }

                string dvvFinal = Criptografia.EncriptarHash(sbDvv.ToString());
                _dal.ActualizarDVV(nombreTabla, dvvFinal);
            }
        }

        public bool ValidarIntegridad(out string mensajeError)
        {
            mensajeError = "";

            foreach (var item in TablasCriticas)
            {
                string nombreTabla = item.Key;
                string pkColumna = item.Value;

                DataTable dt = _dal.LeerTabla(nombreTabla);
                string dvvAlmacenado = _dal.ObtenerDVV(nombreTabla);
                StringBuilder sbDvv = new StringBuilder();

                foreach (DataRow row in dt.Rows)
                {
                    string filaConcatenada = "";
                    string idFila = row[pkColumna].ToString();
                    string dvhGuardado = row["DVH"] != DBNull.Value ? row["DVH"].ToString() : "";

                    foreach (DataColumn col in dt.Columns)
                    {
                        if (col.ColumnName == "DVH") continue;
                        filaConcatenada += row[col].ToString();
                    }

                    string dvhCalculado = Criptografia.EncriptarHash(filaConcatenada);
                    sbDvv.Append(dvhCalculado);

                    if (dvhCalculado != dvhGuardado)
                    {
                        mensajeError = $"Tabla '{nombreTabla}': El registro con ID {idFila} fue alterado externamente.";
                        return false;
                    }
                }

                string dvvCalculado = Criptografia.EncriptarHash(sbDvv.ToString());
                if (dvvCalculado != dvvAlmacenado)
                {
                    mensajeError = $"Tabla '{nombreTabla}': La cantidad de registros fue alterada (Se agregaron o eliminaron filas directamente en SQL).";
                    return false;
                }
            }

            return true;
        }
    }
}
