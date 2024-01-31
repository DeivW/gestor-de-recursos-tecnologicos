using Gestion_de_RT.Modelo.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_RT.Modelo
{
    public class Turno
    {
        private string diaSemana;
        private DateTime fechaGeneracion;
        private DateTime fechaHoraFin;
        private DateTime fechaHoraInicio;
        private List<CambioEstadoTurno> cambiosEstado = new List<CambioEstadoTurno>();
        private EstadoTurno estado;
        private struct datosTurno
        {
            DateTime fechaHora;
            string estado;
        }



        public Turno()
        {
        }

        public Turno(DateTime fechaGeneracion, DateTime fechaHoraInicio, DateTime fechaHoraFin, EstadoTurno estado, string diaSemana)
        {
            this.estado = estado;
            this.crearCambioEstado(estado);
            this.fechaGeneracion = fechaGeneracion;
            this.fechaHoraInicio = fechaHoraInicio;
            this.fechaHoraFin = fechaHoraFin;
            this.diaSemana = diaSemana;

        }
        public void setEstado(EstadoTurno estado)
        {
            this.estado = estado;
        }
        public void crearCambioEstado(EstadoTurno estado)
        {
            this.cambiosEstado.Add(new CambioEstadoTurno(DateTime.Now, estado));

        }
        public void agregarCambioEstado(CambioEstadoTurno cambio)
        {
            this.cambiosEstado.Add(cambio);
        }
        public bool tieneFechaGeneracionMayorA(DateTime fecha)
        {
            return this.fechaGeneracion < fecha;
        }
        public DateTime getFechaHoraInicio()
        {
            return this.fechaHoraInicio;
        }
        public string getDiaSemana()
        {
            return this.diaSemana;
        }
        public string mostrarEstado()
        {
            //string res = "";
            //foreach (CambioEstadoTurno cambio in this.cambiosEstado)
            //{
            //    if (cambio.esActual()){
            //        res = cambio.mostrarEstado();
            //    }
            //}
            return this.estado.getNombre();
        }
        public void enReserva(AsignacionCientificoCI asignacion)
        {
            estado.enReserva(this, this.cambiosEstado, asignacion);
        }

        //    foreach (CambioEstadoTurno cambioEstado in this.cambiosEstado)
        //    {
        //        if (cambioEstado.esActual())
        //        {
        //            cambioEstado.setFechaHoraHasta(DateTime.Now);
        //        }
        //    }
        //    this.cambiosEstado.Add(new CambioEstadoTurno(DateTime.Now, estadoReservado));
        //}
    }

}
