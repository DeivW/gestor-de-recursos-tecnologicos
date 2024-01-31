using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_RT.Modelo
{
    public class Marca
    {
        string nombre;
        List<Modelo> modelos;

        public Marca(string nombre)
        {
            this.nombre = nombre;
        }
        public string getNombre()
        {
            return this.nombre;
        }
        public void setModelos(List<Modelo> modelos)
        {
            this.modelos = modelos;
            foreach (Modelo modelo in modelos)
            {
                modelo.setMarca(this);
            }
        }
    }
}
