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
    public class DetalleFalla
    {
        public string Tabla { get; set; }
        public string FilaID { get; set; }
        public string Error { get; set; }
        public string Columnas { get; set; }
    }
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
        public List<DetalleFalla> EscanearFallas()
        {
            List<DetalleFalla> fallas = new List<DetalleFalla>();

            foreach (var item in TablasCriticas)
            {
                string nombreTabla = item.Key;
                string pkColumna = item.Value;

                DataTable dt = _dal.LeerTabla(nombreTabla);
                string dvvAlmacenado = _dal.ObtenerDVV(nombreTabla);
                StringBuilder sbDvv = new StringBuilder();

                List<string> listaColumnas = new List<string>();
                foreach (DataColumn col in dt.Columns)
                {
                    if (col.ColumnName != "DVH") listaColumnas.Add(col.ColumnName);
                }
                string stringColumnas = string.Join(", ", listaColumnas);

                bool fallaEnFila = false;

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
                        fallaEnFila = true; 
                        fallas.Add(new DetalleFalla
                        {
                            Tabla = nombreTabla,
                            FilaID = idFila,
                            Columnas = stringColumnas,
                            Error = "Falla DVH: Registro alterado externamente en SQL."
                        });
                    }
                }

                string dvvCalculado = Criptografia.EncriptarHash(sbDvv.ToString());

                if (dvvCalculado != dvvAlmacenado && !fallaEnFila)
                {
                    fallas.Add(new DetalleFalla
                    {
                        Tabla = nombreTabla,
                        FilaID = "N/A (Afecta a la cantidad de filas)",
                        Columnas = "Todas",
                        Error = "Falla DVV: Se insertaron o eliminaron registros directamente en SQL."
                    });
                }
            }
            return fallas;
        }

              
        
        public DataTable ObtenerHistorialLog()
        {
            return _dal.ObtenerHistorialDV();
        }
    }
}
