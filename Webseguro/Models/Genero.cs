using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webseguro.Models
{
    public class Genero
    {
        public Genero()
        {
            Persona = new HashSet<Persona>();
        }

        public int Codigo { get; set; }
        public string Contenido { get; set; }
        public int Estado { get; set; }

        public virtual ICollection<Persona> Persona { get; set; }
    }
}
