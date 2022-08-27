using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisFinal1
{
    class zigzagDreapta : Piesa
    {
        public zigzagDreapta()
        {
            color = Color.Yellow;
            position = new Boolean[,]
                                        {{false, false, false, false},
                                        {false, false, true, true},
                                        {false, true, true, false},
                                        {false, false, false, false}};
        }


    }
}
