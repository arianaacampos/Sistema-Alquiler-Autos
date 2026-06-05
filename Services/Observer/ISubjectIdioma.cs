using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Observer
{
    public interface ISubjectIdioma
    {
        void Suscribir(IObserverIdioma observador);
        void Desuscribir(IObserverIdioma observador);
        void Notificar();
    }
}
