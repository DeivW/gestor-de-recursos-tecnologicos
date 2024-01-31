using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_RT.Modelo.State
{
    public abstract class EstadoTurno
    {

        private string nombre;

        public EstadoTurno(string nombre)
        {
            this.nombre = nombre;
        }
        public string getNombre()
        {
            return this.nombre;
        }

        public void anular()
        {

        }
        public void cancelar()
        {

        }
        public void ancelarPorMant()
        {

        }
        public virtual void enReserva(Turno t, List<CambioEstadoTurno> historial, AsignacionCientificoCI asignacion)
        {
            
        }
        public bool esCanceladoPorMant()
        {
            return false;
        }
        public bool esFinalizado()
        {
            return false;
        }
        public bool esNoEjecutado()
        {
            return false;
        }
        public bool esReservado()
        {
            return false;
        }
        public void rechazar()
        {
            
        }
        public void registrarFinUso()
        {

        }
        public void registrarInicioUso()
        {

        }
        public void registrarNoUso()
        {

        }





    }
}
