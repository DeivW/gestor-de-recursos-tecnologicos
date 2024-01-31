using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_RT.Modelo
{
    public class Usuario
    {
        private string nombre;
        private int pass;
        private PersonalCientifico cientifico;

        public Usuario(string nombre, int pass)
        {
            this.nombre = nombre;
            this.pass = pass;
        }
        public string getNombre()
        {
            return this.nombre;
        }
        public int getPass()
        {
            return this.pass;
        }
        public void setCientifico(PersonalCientifico cientifico)
        {
            this.cientifico = cientifico;
        }
        public PersonalCientifico getCientifico()
        {
            return this.cientifico;
        }
    }
}
