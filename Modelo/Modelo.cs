using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_RT.Modelo
{
    public class Modelo
    {
        string nombre;
        Marca miMarca;

        public Modelo(string nombre)
        {
            this.nombre = nombre;
        }
        public string getMarcaYModelo()
        {
            return this.miMarca.getNombre() + " " + this.nombre;
        }
        public void setMarca(Marca marca)
        {
            this.miMarca = marca;
        }
        
    }
}
