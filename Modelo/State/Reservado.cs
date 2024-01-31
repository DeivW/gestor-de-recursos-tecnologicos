using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_RT.Modelo.State
{
    public class Reservado : EstadoTurno
    { 
        private string nombre;

        public Reservado(string nombre) : base(nombre)
        {
            this.nombre = "Reservado";
        }
        public void cancelar()
        {

        }
        public void registrarInicioUso()
        {

        }
        public void registrarNoUso()
        {

        }
        public string getNombre()
        {
            return this.nombre;
        }
    }
}
