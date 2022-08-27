using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisFinal1
{
    class Lstanga : Piesa
    {
        public Lstanga()
        {
            color = Color.Red;
            position = new Boolean[,]
                                        {{false, false, false, false},
                                        {false, true, false, false},
                                        {false, true, true, true},
                                        {false, false, false, false}};
        }


    }
}
