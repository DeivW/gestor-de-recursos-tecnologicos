using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_RT.Modelo.State
{
    public class Disponible : EstadoTurno
    {
        private string nombre;
        private CambioEstadoTurno actual;
        private EstadoTurno proxEstado;
        private AsignacionCientificoCI asignacion;
        private Turno t;


        public Disponible(string nombre) : base(nombre)
        {
        }

        /*
        * Métodos getters.
        */
        public string getNombre()
        {
            return this.nombre;
        }

        /*
        * Método que agrega el turno a la asignacion del cientifico.
        */
        private void asignarTurnoAAsignacion()
        {
            if (!(this.asignacion == null)) { this.asignacion.agregarTurno(t); }
        }

        /*
        * Método que busca el último cambio de estado del turno.
        */
        private void buscarHistorialActual(List<CambioEstadoTurno> historial)
        {
            foreach (CambioEstadoTurno cambioEstado in historial)
            {
                if (cambioEstado.esActual())
                {
                    this.actual = cambioEstado;
                    break;
                }
            }
        }

        /*
        * Método que crea y retorna un nuevo cambio de estado.
        */
        private CambioEstadoTurno crearHistorialTurno()
        {
            return new CambioEstadoTurno(DateTime.Now, this.proxEstado);
        }

        /*
        * Método que crea el proximo estado concreto RESERVADO y lo guarda.
        */
        private void crearProximoEstado()
        {
            this.proxEstado = new Reservado("Reservado");
        }

        /*
        * Método polimórfico que desencadena la busqueda de cambio de estado, la creación del próximo estado, creación y seteo del cambio de estado, 
        * y el seteo del estado a la clase turno. Cambio de estado propiamente dicho.
        */
        public override void enReserva(Turno t, List<CambioEstadoTurno> historial, AsignacionCientificoCI asignacion)
        {
            this.buscarHistorialActual(historial);
            actual.setFechaHoraHasta(DateTime.Now);
            this.crearProximoEstado();
            CambioEstadoTurno ce = this.crearHistorialTurno();
            this.asignarTurnoAAsignacion();  
            t.agregarCambioEstado(ce);
            t.setEstado(this.proxEstado);
        }

        /*
        * Método no implementado.
        */
        public void anular()
        {

        }
    }
}
