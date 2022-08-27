using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TetrisFinal1
{
    class BlockSpawner
    {
        // creez urmatorul bloc care va fi jucat
        public BlockSpawner()
        {
            positionSpawner = new BlockPositionSpawner();
        }

        // specific pozitia urm. bloc
        BlockPositionSpawner positionSpawner;

        // returnez urmatorul bloc care va fi jucat
        public Block Next()
        {
            return new Block(positionSpawner);
        }
    }
}