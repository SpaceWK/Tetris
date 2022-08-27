using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TetrisFinal1
{
    class Block
    {
        public Block(BlockPositionSpawner positionSpawner)
        {
            // decid ce piesa ii
            Random random = new Random();
            Piesa startPos = positionSpawner.Next();
            squares = startPos.position;
            color = startPos.color;

            // setez pozitia initiala
            x = 3;
            y = 0;
        }

        public Color color { get; set; }

        // squares[row, col]. Col = 0, Row = 1 for GetLength()
        public Boolean[,] squares;

        public int x { get; set; }

        public int y { get; set; }


        // Clonez piesa curenta
        public Block Clone()
        {
            return (Block)this.MemberwiseClone();
        }

        // convertest coordonatele patratului cu cele din tabela
        public Coordinate toBoardCoordinates(Coordinate coord)
        {
            coord.x += x;
            coord.y += y;

            return coord;
        }

        public bool isSingleCell()
        {
            int count = 0;

            for (int col = 0; col < squares.GetLength(0); col++)
                for (int row = 0; row < squares.GetLength(1); row++)
                    if (squares[col, row])
                        count++;

            return count == 1;
        }

        // rotesc piesa in sensul acelor
        public void rotateClockwise()
        {
            rotateAntiClockwise();
            rotateAntiClockwise();
            rotateAntiClockwise();
        }

        public void rotateAntiClockwise()
        {
            Boolean[,] temp = new Boolean[squares.GetLength(0), squares.GetLength(1)];

            for (int col = 0; col < squares.GetLength(0); col++)
                for (int row = 0; row < squares.GetLength(1); row++)
                    temp[squares.GetLength(1) - 1 - row, col] = squares[col, row];

            squares = temp;
        }

    }
}