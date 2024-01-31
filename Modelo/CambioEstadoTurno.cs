using Gestion_de_RT.Modelo.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_RT.Modelo
{
    public class CambioEstadoTurno
    {
        private DateTime fechaDesde;
        private DateTime fechaHasta;
        private EstadoTurno estado;

        public CambioEstadoTurno(DateTime fechaDesde, EstadoTurno estado)
        {
            this.fechaDesde = fechaDesde;
            this.estado = estado;
        }
        public void setFechaHoraHasta(DateTime fechaHasta)
        {
            this.fechaHasta = fechaHasta;

        }
        public bool esActual()
        {
            return this.fechaHasta < new DateTime(2000, 01, 01);
        }
        public string mostrarEstado()
        {
            return this.estado.getNombre();
        }
    }
}
