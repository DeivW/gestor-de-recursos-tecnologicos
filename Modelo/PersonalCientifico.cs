using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_RT.Modelo
{
    public class PersonalCientifico
    {
        private string apellido;
        private string nombre;
        private int legajo;
        private string correoPersonal;
        private int documento;
        private Usuario usuario;

        public PersonalCientifico(string apellido, string nombre, int legajo, Usuario usu)
        {
            this.apellido = apellido;
            this.nombre = nombre;
            this.legajo = legajo;
            this.usuario = usu;
        }

        public PersonalCientifico(string apellido, string nombre, int legajo, string correoPersonal, int documento, Usuario usuario)
        {
            this.apellido = apellido;
            this.nombre = nombre;
            this.legajo = legajo;
            this.correoPersonal = correoPersonal;
            this.documento = documento;
            this.usuario = usuario;
        }
        public String getEmail()
        {
            return this.correoPersonal;
        }
        public override bool Equals(object obj)
        {
            return obj is PersonalCientifico cientifico &&
                   apellido == cientifico.apellido &&
                   nombre == cientifico.nombre &&
                   legajo == cientifico.legajo;
        }
    }
}
