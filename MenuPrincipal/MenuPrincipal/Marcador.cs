using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MenuPrincipal
{   
        public struct Marcador
        {
            public Marcador(int puntosEquipo1, int puntosEquipo2)
                : this()
            {
                PuntosEquipo1 = puntosEquipo1;
                PuntosEquipo2 = puntosEquipo2;
            }

            public int PuntosEquipo1 { get; set; }
            public int PuntosEquipo2 { get; set; }
        }
    }

