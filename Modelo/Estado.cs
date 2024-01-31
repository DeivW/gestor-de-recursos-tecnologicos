using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_RT.Modelo
{
    public class Estado
    {
        private string ambito;
        private string nombre;
        private string descripcion;


        public Estado(string ambito, string nombre)
        {
            this.ambito = ambito;
            this.nombre = nombre;
        }

        public Estado(string ambito, string nombre, string descripcion)
        {
            this.ambito = ambito;
            this.nombre = nombre;
            this.descripcion = descripcion;
        }

        public bool esReservable()
        {
            if (this.nombre.Equals("Ingresado") || this.nombre.Equals("Disponible"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool esAmbitoTurno()
        {
            return this.ambito.Equals("Turno");
        }
        public string getNombre()
        {
            return this.nombre;
        }
        public bool esReservado()
        {
            return this.nombre.Equals("Reservado");
        }
    }
}
