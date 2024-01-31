using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_RT.Modelo.State
{
    public class NoEjecutado : EstadoTurno
    {
        public NoEjecutado(string nombre) : base(nombre)
        {

        }
        public bool esNoEjecutado()
        {
            return true;
        }

    }
}
