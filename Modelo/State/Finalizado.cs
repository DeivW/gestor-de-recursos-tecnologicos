using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_RT.Modelo.State
{
    public class Finalizado : EstadoTurno
    {
        public Finalizado(string nombre) : base(nombre)
        {

        }
        public bool esFinalizado()
        {
            return true;
        }
    }
}
