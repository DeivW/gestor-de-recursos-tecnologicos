using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_RT.Modelo
{
    public class AsignacionCientificoCI
    {
        private DateTime fechaDesde;
        private DateTime fechaHasta;
        private PersonalCientifico cientifico;
        private List<Turno> turnos = new List<Turno>();

        public AsignacionCientificoCI()
        {
        }

        public AsignacionCientificoCI(DateTime fechaDesde, PersonalCientifico cientifico)
        {
            this.fechaDesde = fechaDesde;
            this.cientifico = cientifico;
        }

        public AsignacionCientificoCI(DateTime fechaDesde, DateTime fechaHasta, PersonalCientifico cientifico)
        {
            this.fechaDesde = fechaDesde;
            this.fechaHasta = fechaHasta;
            this.cientifico = cientifico;
        }
        public bool esCientificoActivo(PersonalCientifico personal){

            if (this.fechaHasta > DateTime.Now) //Es asignacion actual
            {
                return this.cientifico.Equals(personal);
            }      
            return false;
        }
        public void agregarTurno(Turno turno)
        {
            this.turnos.Add(turno);
        }
    }
}
