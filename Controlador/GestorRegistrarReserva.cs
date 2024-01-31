using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gestion_de_RT.Modelo;
using Gestion_de_RT.Modelo.State;
using static Gestion_de_RT.Modelo.Turno;

namespace Gestion_de_RT
{
    public class GestorRegistrarReserva
    {
        private PantallaRegistrarReserva pantalla;
        private List<Estado> estados;
        private List<TipoRecursoTeconologico> tipoRecursos;
        private TipoRecursoTeconologico tipoRTSeleccionado;
        private List<RecursoTeconologico> RTs;
        private RecursoTeconologico RTSeleccionado;
        private Sesion sesionActual;
        private PersonalCientifico cientificoEnSesion;
        private DateTime turnoSeleccionado;
        private AsignacionCientificoCI asignacion;
        //private Estado estadoTurnoReservado;


        public GestorRegistrarReserva()
        {
        }

        public GestorRegistrarReserva(List<TipoRecursoTeconologico>tiposRT)
        {
            this.tipoRecursos = tiposRT;
        }

        /*
         * Métodos de seteo.
         */
        public void setPantalla(PantallaRegistrarReserva pantalla)
        {
            this.pantalla = pantalla;
        }
        public void setEstados(List<Estado> estados)
        {
            this.estados = estados;
        }
        public void setRTs(List<RecursoTeconologico> RT)
        {
            this.RTs = RT;
        }
        public void setSesionActual(Sesion sesion)
        {
            this.sesionActual = sesion;
        }

        /*
         * Método para hacer una nueva reserva que desencadena en la busqueda de tipos de RT.
         */
        public void nuevaReserva()
        {
            this.buscarTipoRT();
        }

        /*
         * Método que busca los tipos de recurso tecnológico disponibles.
         */
        private void buscarTipoRT()
        {
            List<string> vecNombresTipoRT = new List<string>();
            for (int i = 0; i < this.tipoRecursos.Count; i++)
            {
                vecNombresTipoRT.Add(this.tipoRecursos[i].getNombre());
            }
            pantalla.listarTiposRT(vecNombresTipoRT);
        }

        /*
         * Método que toma la selección del tipo de recurso tecnológico por parte del usuario.
         */
        public void tomarSeleccionTipoRT(string tipoRTSelec)
        {
            foreach (TipoRecursoTeconologico tipoRT in this.tipoRecursos)
            {
                if(tipoRT.getNombre().Equals(tipoRTSelec)){
                    this.tipoRTSeleccionado = tipoRT;
                }
            }
            this.buscarRTActivoTipo();

        }

        /*
         * Método que busca los recursos tecnológicos activos del tipo selecionado por el usuario.
         */
        public void buscarRTActivoTipo()
        {
            List<RecursoTeconologico> RTCandidatos = new List<RecursoTeconologico>();
            foreach (RecursoTeconologico RT in this.RTs)
            {
                if (RT.esTipo(this.tipoRTSeleccionado))
                {
                    if (RT.esActivo())
                    {
                        RTCandidatos.Add(RT);
                    }

                }
            }

            List<Tuple<int, string, string>> datosRTs = new List<Tuple<int, string, string>>();
            List<int> numRT = new List<int>();
            foreach (RecursoTeconologico RT in RTCandidatos)
            {
                datosRTs.Add(RT.mostrarDatos());
                numRT.Add(RT.getNumero());
            }
            
            pantalla.listarRT(this.agruparPorCI(datosRTs));

        }
        
        /*
         * Método que agrupa los recursos tecnológicos según su Centro de investigación.
         */
        public List<Tuple<int, string, string>> agruparPorCI(List<Tuple<int, string, string>> datosRTs)
        {
            //List<String> centros = new List<string>();
            //foreach (var tupla in datosRTs)
            //{
            //    if (!centros.Contains(tupla.Item3))
            //    {
            //        centros.Add(tupla.Item3);
            //    }

            //}
            //List<String> centrosOrdenados = centros.Sort(

            datosRTs.Sort();

            return datosRTs;
        }

        /*
         * Método que toma la selección del recurso tecnológico por parte del usuario.
         */
        public void tomarSeleccionRT(int numRT)
        {
            foreach (RecursoTeconologico RT in this.RTs)
            {
                if (RT.getNumero().Equals(numRT))
                {
                    this.RTSeleccionado = RT;
                }
            }
            this.obtenerCientificoEnSesion();

        }

        /*
         * Método que obtiene al cientifico que inició la sesión. 
         */
        public void obtenerCientificoEnSesion()
        {
            this.cientificoEnSesion = this.sesionActual.obtenerCientificoEnSesion();
            this.validarPertenencia();
        }

        /*
         * Método que valida la pertenencia del cientifico al centro de investigación del recurso.
         */
        public void validarPertenencia()
        {
            AsignacionCientificoCI asignacion = this.RTSeleccionado.esCientificoActivoDeMiCI(this.cientificoEnSesion);
            this.asignacion = asignacion;
            bool pertenece = false;
            if (asignacion == null)
            {
                pantalla.mostrarMensajePertenencia(false);
            }
            else
            {
                pantalla.mostrarMensajePertenencia(true);
                pertenece = true;
            }
            //pantalla.mostrarMensajePertenencia(this.RTSeleccionado.esCientificoActivoDeMiCI(this.cientificoEnSesion));

            // this.RTSeleccionado.esCientificoActivoDeMiCI(cientificoEnSesion);
            //this.buscarTurnos(this.RTSeleccionado.esCientificoActivoDeMiCI(this.cientificoEnSesion));
            this.buscarTurnos(pertenece);
        }

        /*
         * Método que busca los turnos del recurso tecnológico y los envía a la pantalla.
         */
        public void buscarTurnos(bool pertenece)
        {
            List<Tuple<string, DateTime, string>> datosTurnos = new List<Tuple<string, DateTime, string>>();
            datosTurnos = this.RTSeleccionado.mostrarTurnos(pertenece);
            pantalla.presentarTurnos(datosTurnos);
            
        }

        /*
         * Método que toma la selección del turno del recurso tecnológico por parte del usuario
         */
        public void tomarSeleccionTurno(DateTime fechaTurno)
        {
            //this.turnoSeleccionado = fechaTurno;
            pantalla.pedirConfirmacion(fechaTurno, this.presentarFormasNotificacion());
        }

        /*
         * Método que retorna las formas de notificación posibles.
         */
        public List<String> presentarFormasNotificacion()
        {
            List<String> formasNotif = new List<string>();
            formasNotif.Add("Whatsapp");
            formasNotif.Add("Email");
            return formasNotif;
        }

        /*
         * Método que toma la confirmacion de la reserva del turno del recurso tecnológico por parte del usuario
         */
        public void tomarConfirmacion(DateTime fechaConfirmada)
        {
            this.turnoSeleccionado = fechaConfirmada;
            this.registrarReservaTurnoRT();
        }

        /*
         * Método que registra la reserva del turno para el recurso tecnológico.
         */
        public void registrarReservaTurnoRT()
        {
            this.RTSeleccionado.reservarTurno(this.turnoSeleccionado,asignacion);
        }

        /*
         * Método que envía la notificacion al usuario por la forma seleccionada.
         */
        private void notificarTurnoReservado()
        {
            String emailCientifico = this.cientificoEnSesion.getEmail();
            InterfazCorreo.enviarEmail(emailCientifico);
        }
    }

 
}
