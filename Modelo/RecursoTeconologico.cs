using Gestion_de_RT.Modelo.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Gestion_de_RT.Modelo.Turno;

namespace Gestion_de_RT.Modelo
{
    public class RecursoTeconologico
    {
        private int duracionMantPrev;
        private DateTime fechaAlta;
        private int numeroRT;
        private TipoRecursoTeconologico tipoRT;
        private List<CambioEstadoRT> cambiosEstado = new List<CambioEstadoRT>();
        private int numero;
        private CentroInvestigacion CI;
        private int fraccionamientoTurnos;
        private List<Turno> turnos;
        private int tiempoAntelacionReserva = 3;
        private Modelo modelo;

        public RecursoTeconologico(TipoRecursoTeconologico tipoRT, int num)
        {
            this.tipoRT = tipoRT;
            this.numero = num;
            this.fraccionamientoTurnos = 8;
            // this.cambiosEstado = new List<CambioEstadoRT>();
        }

        public RecursoTeconologico(int duracionMantPrev, DateTime fechaAlta, int numeroRT)
        {
            this.duracionMantPrev = duracionMantPrev;
            this.fechaAlta = fechaAlta;
            this.numeroRT = numeroRT;
            this.fraccionamientoTurnos = 8;
            //this.cambiosEstado = new List<CambioEstadoRT>();
        }
        public Tuple<int, string, string> mostrarDatos()
        {
            int numero = this.getNumero();
            string modeloMarca = this.miModeloYMarca();
            string CI = this.miCI();
            Tuple<int, string, string> datos = new Tuple<int, string, string>(numero, modeloMarca, CI);
            return datos;
        }
        public string miModeloYMarca()
        {
                return this.modelo.getMarcaYModelo();
        }
        public string miCI()
        {
            return this.CI.getNombre();
        }
        public int getNumero()
        {

            return this.numero;
        }
        public void setCI(CentroInvestigacion ci)
        {
            this.CI = ci;
        }
        public void setModelo(Modelo modelo)
        {
            this.modelo = modelo;
        }
        public void cambiarEstado(CambioEstadoRT cambioEstado)
        {
            this.cambiosEstado.Add(cambioEstado);
        }
        public bool esTipo(TipoRecursoTeconologico tipoRT)
        {
            return this.tipoRT == tipoRT;
        }
        public bool esActivo()
        {
            foreach (CambioEstadoRT cambioEstado in this.cambiosEstado)
            {
                if (cambioEstado.esActual())
                {
                    return cambioEstado.esEstadoReservable();
                }
            }
            return false;
        }
        public int getFraccionamiento()
        {
            return this.fraccionamientoTurnos;

        }
        public AsignacionCientificoCI esCientificoActivoDeMiCI(PersonalCientifico personal)
        {
            return this.CI.esMiCientifico(personal);     
        }
        public void setTurnos(List<Turno> turnos)
        {
            this.turnos = turnos;
        }
        public List<Turno> getTurnos()
        {
            return this.turnos;
        }
        public List<Tuple<string, DateTime, string>> mostrarTurnos(bool pertenece)
        {
            List<Tuple<string, DateTime, string>> datosTurnos = new List<Tuple<string, DateTime, string>>();
            if (!pertenece)
            {
                foreach (Turno turno in this.turnos)
                {
                    if (turno.tieneFechaGeneracionMayorA(DateTime.Now) && (turno.getFechaHoraInicio() > DateTime.Now.AddDays(this.tiempoAntelacionReserva)))
                    {
                        datosTurnos.Add(new Tuple<string, DateTime, string>(turno.getDiaSemana(), turno.getFechaHoraInicio(), turno.mostrarEstado()));
                    }
                }
            }
            else
            {
                foreach (Turno turno in this.turnos)
                {
                    if (turno.tieneFechaGeneracionMayorA(DateTime.Now))
                    {
                        datosTurnos.Add(new Tuple<string, DateTime, string>(turno.getDiaSemana(), turno.getFechaHoraInicio(), turno.mostrarEstado()));
                    }
                }
            }

            return datosTurnos;
        }

        public void reservarTurno(DateTime fechaTurno, AsignacionCientificoCI asignacion)
        {
            foreach (Turno turno in this.turnos)
            {
                if (turno.getFechaHoraInicio() == fechaTurno)
                {
                    turno.enReserva(asignacion);
                   // Console.WriteLine("FIN CU REY");
                }
            }

        }
    }
}
