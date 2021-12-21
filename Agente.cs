using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IA_TP01_D
{
    class Agente
    {
        public string Estado { get; set; }

        public Agente(string pEstadoInicial)
        {
            Estado = pEstadoInicial;
        }

        public void Activar(Percepcion percepcion, ICollection<Regla> reglas)
        {
            Estado = percepcion.Descripcion;
            ICollection<Regla> reglasPosibles = ObtenerReglas(reglas);
            Accion accion = DecidirAccion(reglasPosibles);
            RealizarAccion(accion);
        }

        public Accion DecidirAccion(ICollection<Regla> reglas)
        {
            List<Accion> accionesDisponibles = new List<Accion>();
            foreach (Regla regla in reglas)
            {
                accionesDisponibles.Add(regla.Accion);
            }
            return accionesDisponibles.OrderByDescending(x => x.Valor).First();
        }

        public void RealizarAccion(Accion accion)
        {
            if (accion.Descripcion.Equals("Limpiar"))
            {
                Estado = "Limpio";
            }
        }

        public ICollection<Regla> ObtenerReglas(ICollection<Regla> reglas)
        {
            return reglas.Where(x => x.EstadoInicial == Estado).ToList();
        }
    }
}
