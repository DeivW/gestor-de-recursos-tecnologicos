using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_RT.Modelo
{ 
    public class TipoRecursoTeconologico
    {
        private string descripcion;
        private string nombre;


        public TipoRecursoTeconologico()
        { }
        public TipoRecursoTeconologico(string desc, string nom)
        {
            this.descripcion = desc;
            this.nombre = nom;
        }
        public string getNombre()
        {
            return this.nombre;
        }

    }
}
