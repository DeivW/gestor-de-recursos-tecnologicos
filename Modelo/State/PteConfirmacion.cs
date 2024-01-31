using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_RT.Modelo.State
{
    public class PteConfirmacion : EstadoTurno
    {
        public PteConfirmacion(string nombre) : base(nombre)
        {

        }
        public void anular()
        {

        }
        public void cancelarPorMan()
        {

        }
        public void enReserva(Turno t, CambioEstadoTurno[] historial, AsignacionCientificoCI asignacion)
        {

        }
        public void rechazar()
        {

        }


    }
}
