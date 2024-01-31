
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_RT.Modelo
{
    public class CambioEstadoRT
    {
        private DateTime fechaDesde;
        private DateTime fechaHasta;
        private Estado estado;

        public CambioEstadoRT()
        {
        }

        public CambioEstadoRT(DateTime fechaDesde, Estado estado)
        {
            this.fechaDesde = fechaDesde;
            this.estado = estado;
        }

        public CambioEstadoRT(DateTime fechaDesde, DateTime fechaHasta, Estado estado)
        {
            this.fechaDesde = fechaDesde;
            this.fechaHasta = fechaHasta;
            this.estado = estado;
        }
        public void setFechaHasta(DateTime fh)
        {
            this.fechaHasta = fh;
        }

        public bool esActual()
        {
            return this.fechaHasta < new DateTime(2000, 01, 01);
        }
        public bool esEstadoReservable()
        {
            return this.estado.esReservable();

        }
    }

}
