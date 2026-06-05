using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Observer
{
    public class IdiomaManager : ISubjectIdioma
    {
        private static IdiomaManager _instancia;
        public static IdiomaManager Instancia
        {
            get
            {
                if (_instancia == null) _instancia = new IdiomaManager();
                return _instancia;
            }
        }

        private List<IObserverIdioma> _observadores = new List<IObserverIdioma>();
        private Dictionary<string, string> _traducciones = new Dictionary<string, string>();
        public string IdiomaActual { get; private set; } = "es-AR"; 

        private IdiomaManager()
        {
            CargarTraducciones(); 
        }
        public void Suscribir(IObserverIdioma observador)
        {
            if (!_observadores.Contains(observador))
                _observadores.Add(observador);
        }

        public void Desuscribir(IObserverIdioma observador)
        {
            if (_observadores.Contains(observador))
                _observadores.Remove(observador);
        }

        public void Notificar()
        {
            foreach (var obs in _observadores)
            {
                obs.ActualizarIdioma();
            }
        }

        public void CambiarIdioma(string nuevoIdioma)
        {
            IdiomaActual = nuevoIdioma;
            CargarTraducciones();
            Notificar();
        }

        private void CargarTraducciones()
        {
            string rutaArchivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Idiomas", $"{IdiomaActual}.json");

            if (File.Exists(rutaArchivo))
            {
                string json = File.ReadAllText(rutaArchivo);
                _traducciones = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            }
        }

        public string Traducir(string clave)
        {
            if (_traducciones.ContainsKey(clave))
                return _traducciones[clave];
            return clave;
        }
    }

    }

