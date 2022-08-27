using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TetrisFinal1
{

    // pozitia posibila a blocului de start
    class PossibleBlockStartPositions : BlockPositionSpawner
    {

        public PossibleBlockStartPositions()
        {
            setPossiblePositions(currentBucket);
            setPossiblePositions(nextBucket);
        }


        public Piesa[] currentBucket = new Piesa[7];

        public Piesa[] nextBucket = new Piesa[7];

 
        // pozitia posibila cu care pot incepe
        private void setPossiblePositions(Piesa[] bucket)
        {
            bucket[0] = new Linie();

            bucket[1] = new Lstanga();

            bucket[2] = new Ldreapta();

            bucket[3] = new Cub();

            bucket[4] = new zigzagDreapta();

            bucket[5] = new zigzagDreapta();

            bucket[6] = new Triunghi();
        }
    }
}