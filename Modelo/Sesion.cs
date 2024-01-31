using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_RT.Modelo
{
    public class Sesion
    {
        private DateTime fechaHoraInicio;
        private DateTime fechaHoraHasta;
        private Usuario usuarioEnSesion;

        public Sesion(DateTime fechaHoraInicio)
        {
            this.fechaHoraInicio = fechaHoraInicio;
        }
        public void setUsuario(Usuario usu)
        {
            this.usuarioEnSesion = usu;

        }

        public PersonalCientifico obtenerCientificoEnSesion()
        {
            return this.usuarioEnSesion.getCientifico();

        }
    }
}
