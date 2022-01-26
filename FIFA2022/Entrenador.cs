using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mundial
{
    class Entrenador : Persona
    {
        string tactica;
        public string Tactica
        {
            get { return Tactica; }
            set { tactica = value; }
        }
    }
}
