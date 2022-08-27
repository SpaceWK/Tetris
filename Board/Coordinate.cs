using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TetrisFinal1
{
    // Coordonatele in forma (x, y)
    class Coordinate
    {

        // creez coordonate noi (x, y)
        public Coordinate(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        // coordonata x
        public int x { get; set; }

 
        // coordonata y
        public int y { get; set; }
    }
}