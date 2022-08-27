using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisFinal1
{
    class Piesa
    {
       public Color color;
       public Boolean[,] position;
    
        public Color getColor()
        {
            return color;
        }

        public Boolean[,] getPozition()
        {
            return position;
        }
    }


}
