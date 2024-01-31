using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_RT.Modelo
{
    public class CentroInvestigacion
    {
        private string nombre;
        private string correo;
        private List<RecursoTeconologico> recursos;
        private List<AsignacionCientificoCI> cientificos;

        public CentroInvestigacion()
        {
            this.cientificos = new List<AsignacionCientificoCI>();
        }

        public CentroInvestigacion(string nombre)
        {
            this.nombre = nombre;
            this.cientificos = new List<AsignacionCientificoCI>();
        }

        public CentroInvestigacion(string nombre, string correo, List<RecursoTeconologico> recursos)
        {
            this.nombre = nombre;
            this.correo = correo;
            this.recursos = recursos;
            this.cientificos = new List<AsignacionCientificoCI>();
        }
        public string getNombre()
        {
            return this.nombre;
        }
        public void agregarAsignacion(AsignacionCientificoCI asignacion)
        {
            this.cientificos.Add(asignacion);
        }
        public AsignacionCientificoCI esMiCientifico(PersonalCientifico cientifico)
        {
            foreach (AsignacionCientificoCI asignacion in this.cientificos)
            {
                if (asignacion.esCientificoActivo(cientifico))
                {
                    return asignacion;
                }
            }
            return null;
        }
    }
}
