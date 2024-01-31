using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gestion_de_RT.Modelo;
using Gestion_de_RT.Modelo.State;

namespace Gestion_de_RT
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            /*
                        CODIGO DURO - CREACION DE OBJETOS
             */
            TipoRecursoTeconologico tipo1 = new TipoRecursoTeconologico("Aumentos altos para realizar inspecciones", "Microscopios");
            TipoRecursoTeconologico tipo2 = new TipoRecursoTeconologico("Instrumento para realizar mediciones de peso de alta precisión", "Balanzas de precisión");
            List<TipoRecursoTeconologico> tiposRT = new List<TipoRecursoTeconologico>();
            tiposRT.Add(tipo1);
            tiposRT.Add(tipo2);
            GestorRegistrarReserva gestor = new GestorRegistrarReserva(tiposRT);
            // RECURSOS TECNOLOGICOS
            List<RecursoTeconologico> listaRTs = new List<RecursoTeconologico>();
            listaRTs.Add(new RecursoTeconologico(tipo1, 165));
            listaRTs.Add(new RecursoTeconologico(tipo1, 1));
            listaRTs.Add(new RecursoTeconologico(tipo2, 2));
            listaRTs.Add(new RecursoTeconologico(tipo2, 3));
            listaRTs.Add(new RecursoTeconologico(tipo2, 4));
            listaRTs.Add(new RecursoTeconologico(tipo1, 5));
            listaRTs.Add(new RecursoTeconologico(tipo2, 6));
            listaRTs.Add(new RecursoTeconologico(tipo1, 250));
            listaRTs.Add(new RecursoTeconologico(tipo1, 8));
            gestor.setRTs(listaRTs);
            // MODELOS Y MARCAS
            Marca marca1 = new Marca("Elektronic");
            Marca marca2 = new Marca("Samsung");
            
            List<Modelo.Modelo> listaModelos = new List<Modelo.Modelo>();
            listaModelos.Add(new Modelo.Modelo("X31-JK"));
            listaModelos.Add(new Modelo.Modelo("JASM-CSD21"));
            marca2.setModelos(listaModelos);
            // ASIGNACION DE MODELOS A LOS RT
            foreach (RecursoTeconologico RT in listaRTs)
            {
                RT.setModelo(listaModelos[0]);
            }
            // ESTADOS
            List<Estado> estados = new List<Estado>();
            estados.Add(new Estado("RT", "Reservado"));
            estados.Add(new Estado("RT", "Ingresado"));
            estados.Add(new Estado("RT", "Disponible"));
            estados.Add(new Estado("RT", "Baja"));
            estados.Add(new Estado("RT", "Mantenimiento"));
            estados.Add(new Estado("Turno", "Disponible"));
            estados.Add(new Estado("Turno", "Reservado"));
            gestor.setEstados(estados);
            // ESTADOS TURNO
            List<EstadoTurno> estadosTurno = new List<EstadoTurno>();
            estadosTurno.Add(new Disponible("Disponible"));
            estadosTurno.Add(new Reservado("Reservado"));
            // CAMBIOS DE ESTADO RT
            List<CambioEstadoRT> cambiosEstadoRT = new List<CambioEstadoRT>();
            //Mantenimiento
            cambiosEstadoRT.Add(new CambioEstadoRT(new DateTime(2022, 03, 15), new DateTime(2022, 05, 20), estados[4]));
            //Disponible
            cambiosEstadoRT.Add(new CambioEstadoRT(new DateTime(2022, 05, 20), estados[2]));
            //Reservado
            cambiosEstadoRT.Add(new CambioEstadoRT(new DateTime(2022, 02, 5), new DateTime(2022, 01, 01), estados[0]));
            //Ingresado
            cambiosEstadoRT.Add(new CambioEstadoRT(new DateTime(2022, 01, 01), new DateTime(2022, 03, 15), estados[1]));

            cambiosEstadoRT.Add(new CambioEstadoRT(new DateTime(2022, 02, 10), new DateTime(2022, 05, 25), estados[1]));
            // ASIGNAR CAMBIO ESTADO A LOS RT
            listaRTs[0].cambiarEstado(cambiosEstadoRT[3]);
            listaRTs[0].cambiarEstado(cambiosEstadoRT[0]);
            listaRTs[0].cambiarEstado(cambiosEstadoRT[1]);
            listaRTs[7].cambiarEstado(cambiosEstadoRT[3]);
            listaRTs[7].cambiarEstado(cambiosEstadoRT[0]);
            listaRTs[7].cambiarEstado(cambiosEstadoRT[1]);
            //  USUARIOS
            Usuario usu = new Usuario("admin", 123456);
            Usuario usu2 = new Usuario("admina", 123456);
            // PERSONAL CIENTIFICO
            PersonalCientifico personal = new PersonalCientifico("Wunderlin", "David", 84751, usu);
            PersonalCientifico personal2 = new PersonalCientifico("Perez", "David", 84748, usu);
            // ASIGNACION DE CIENTIFICO AL USUARIO
            usu.setCientifico(personal);
            usu2.setCientifico(personal2);
            List<Usuario> usus = new List<Usuario>();
            usus.Add(usu);
            usus.Add(usu2);
            // CENTRO DE INVESTIGACIÓN
            CentroInvestigacion CI = new CentroInvestigacion("CIDS", "holanda@gmail.com", new List<RecursoTeconologico>(listaRTs));
            // ASIGNACION DE CIENTIFICOS DEL CI
            AsignacionCientificoCI asignacion = new AsignacionCientificoCI(new DateTime(2022, 01, 01), new DateTime(2022, 12, 31), personal2);
            CI.agregarAsignacion(asignacion);
            // DEPENDENCIA DEL RT AL CI
            foreach (RecursoTeconologico rt in listaRTs)
            {
                rt.setCI(CI);
            }
            // GENERAR TURNOS         
            DateTime fechaActual = DateTime.Now;
            DateTime fecha = new DateTime(fechaActual.Year, fechaActual.Month, fechaActual.Day, 0, 0, 0);
            List<Turno> agendaTurnos = new List<Turno>();
            int cantTurnosDiarios = (24 / listaRTs[0].getFraccionamiento());
            int cantTurnosTotal = cantTurnosDiarios * 30;
            int duracionTurno = listaRTs[0].getFraccionamiento();

            for (int i = 0; i < 30; i++)
            {
                for (int j = 0; j < cantTurnosDiarios; j++)
                {
                    agendaTurnos.Add(new Turno(
                        fechaActual,
                        fecha.AddDays(i).AddHours(j * duracionTurno),
                        fecha.AddDays(i).AddHours(duracionTurno),
                        estadosTurno[0],
                        fecha.AddDays(i).ToString("dddd",
                        new CultureInfo("es-ES"))));
                }
            }

            agendaTurnos[5].crearCambioEstado(estadosTurno[1]);

            // GENERAR TURNOS         
            //DateTime fechaActual = DateTime.Now;
            //List<Turno> agendaTurnos = new List<Turno>();
            //int cantTurnosDiarios = (24 / listaRTs[0].getFraccionamiento());
            //for (int dia = 1; dia < 31; dia++)
            //{
            //    for (int j = 1; j <= cantTurnosDiarios; j++)
            //    {
            //        if (!(j > 1))
            //        {
            //            agendaTurnos.Add(new Turno(fechaActual, establecerDiaMes(fechaActual, dia), (new DateTime(establecerDiaMes(fechaActual, dia).Year,
            //            establecerDiaMes(fechaActual, dia).Month, establecerDiaMes(fechaActual, dia).Day,
            //            establecerDiaMes(fechaActual, dia).Hour + listaRTs[0].getFraccionamiento(), 0, 0)), estados[5], establecerDiaMes(fechaActual, dia).ToString("dddd",
            //            new CultureInfo("es-ES"))));
            //        }
            //        else
            //        {
            //            agendaTurnos.Add(new Turno(fechaActual, (new DateTime(establecerDiaMes(fechaActual, dia).Year,
            //            establecerDiaMes(fechaActual, dia).Month, establecerDiaMes(fechaActual, dia).Day,
            //            establecerDiaMes(fechaActual, dia).Hour + listaRTs[0].getFraccionamiento(), 0, 0)), 
            //            (new DateTime(establecerDiaMes(fechaActual, dia).Year,
            //            establecerDiaMes(fechaActual, dia).Month, establecerDiaMes(fechaActual, dia).Day,
            //            establecerDiaMes(fechaActual, dia).Hour + listaRTs[0].getFraccionamiento(), 0, 0)), estados[5], 
            //            (new DateTime(establecerDiaMes(fechaActual, dia).Year,
            //            establecerDiaMes(fechaActual, dia).Month, establecerDiaMes(fechaActual, dia).Day,
            //            establecerDiaMes(fechaActual, dia).Hour + listaRTs[0].getFraccionamiento(), 0, 0)).ToString("dddd",
            //            new CultureInfo("es-ES"))));
            //        }
            //    }

            //}



            listaRTs[0].setTurnos(agendaTurnos);
            listaRTs[7].setTurnos(agendaTurnos);
            //listaRTs[0].setTurnos(agendaTurnos);




            Sesion sesion = new Sesion(DateTime.Now);
            gestor.setSesionActual(sesion);

            Application.SetCompatibleTextRenderingDefault(false);
            PantallaRegistrarReserva pantalla = new PantallaRegistrarReserva(gestor);
            Application.EnableVisualStyles();
            Application.Run(new Login(pantalla, usus, sesion));


        }
        //public static DateTime establecerDiaMes(DateTime fechaActual, int dia)
        //{
        //    if ((fechaActual.Day + dia) > 30)
        //    {
        //        return new DateTime(2022, fechaActual.Month +1, (dia - (30 - fechaActual.Day)));
        //    }
        //    else
        //    {
        //        return new DateTime(fechaActual.Year, fechaActual.Month, fechaActual.Day + dia);
        //    }
        //}

    }
}
