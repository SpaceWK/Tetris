using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TetrisFinal1
{
    class Board
    { 
        public Board(int noOfRows, int noOfColumns)
        {
            board = new int[noOfColumns, noOfRows + hiddenRows];
            blockSpawner = new BlockSpawner();

            // initializez tabela cu o culoare 
            for (int col = 0; col < noOfColumns; col++)
                for (int row = 0; row < noOfRows + hiddenRows; row++)
                    board[col, row] = boardColor;

            numberOfColumns = noOfColumns;
            numberOfRows = noOfRows;
            numberOfRowsTotal = noOfRows + hiddenRows;

            tick(); 
        }


        BlockSpawner blockSpawner;

        public int rowsDestroyed = 0;

        public int score = 0;

        public readonly int hiddenRows = 20;

        int boardColor = Color.PeachPuff.ToArgb();

        // tabela de inceput
        // board[col, row]
        public int[,] board;

        public Block currentBlock;

        int numberOfColumns;

        int numberOfRows;

        int numberOfRowsTotal;


        public void tick()
        {
            if (currentBlock == null || !canDropFurther())
            {
                spawnBlock();
            }

            lowerBlock();
            manageFullRows();
        }


        private void spawnBlock()
        {
            // blochez blocul care ajunge la pozitia sa
            lockBlock();

            // pornesc cu urm bloc
            currentBlock = blockSpawner.Next();
            currentBlock.y = hiddenRows - 2;
            currentBlock.x = (numberOfColumns - currentBlock.squares.GetLength(1)) / 2;
        }


        private void lockBlock()
        {
            if (currentBlock != null)
            {
                Coordinate coord = null;

                for (int col = 0; col < currentBlock.squares.GetLength(0); col++)
                {
                    for (int row = 0; row < currentBlock.squares.GetLength(1); row++)
                    {
                     
                        if (currentBlock.squares[row, col])
                        {
                            coord = currentBlock.toBoardCoordinates(new Coordinate(col, row));
                           
                            board[coord.x, coord.y] = currentBlock.color.ToArgb();
                        }
                    }
                }

                if (currentBlock.isSingleCell() && coord != null)
                {
                    List<int> filledPositions = new List<int>();

                    // caut sa vad daca s a umplut vre un patrat
                    for (int col = 0; col < numberOfColumns; col++)
                        if (board[col, coord.y] != boardColor)
                            filledPositions.Add(col);

                    for (int col = 0; col < numberOfColumns; col++)
                    {
                   
                        if (filledPositions.Contains(col) && col - 1 >= 0 && board[col - 1, coord.y] == boardColor)
                            board[col - 1, coord.y] = currentBlock.color.ToArgb();

                      
                        if (filledPositions.Contains(col) && col + 1 < numberOfColumns && board[col + 1, coord.y] == boardColor)
                            board[col + 1, coord.y] = currentBlock.color.ToArgb();
                    }
                }
            }
        }


        private void manageFullRows()
        {
            int rowsDestroyedStart = rowsDestroyed;

            for (int row = hiddenRows; row < numberOfRowsTotal; row++)
                manageFullRow(row);

            // adaug puncte in plus pentru mai multe linii distruse
            score += (rowsDestroyed - rowsDestroyedStart) * (rowsDestroyed - rowsDestroyedStart);
        }

        // verific daca linia s a implut, iar apoi elimin toata linia mai jos
        private void manageFullRow(int rowToCheck)
        {
            if (hasFullRow(rowToCheck))
                removeRow(rowToCheck);
        }

  
        private Boolean hasFullRow(int rowToCheck)
        {
            Boolean full = true;

            for (int col = 0; col < numberOfColumns; col++)
                if (board[col, rowToCheck] == boardColor)
                    full = false;

            return full;
        }


        private void removeRow(int rowToRemove)
        {
            if (rowToRemove == 0)
                return;

            for (int row = rowToRemove; row > 0; row--)
            {

                for (int col = 0; col < numberOfColumns; col++)
                {

                    board[col, row] = board[col, row - 1];
                }
            }

            rowsDestroyed++;
        }



        public void rotateBlock()
        {
            if (canRotate())
                currentBlock.rotateClockwise();
        }

        public void lowerBlock()
        {
            if (canDropFurther())
                currentBlock.y++;
        }

        public void moveBlockLeft()
        {
            if (canMoveToSide(false))
                currentBlock.x--;
        }

        public void moveBlockRight()
        {
            if (canMoveToSide(true))
                currentBlock.x++;
        }



        // verific daca se afla un patrat in pozitia specificata
        private Boolean hasSquare(Coordinate coord)
        {
            Boolean hasSquare = false;

            if (coord.x < numberOfColumns && coord.x >= 0 &&
                    coord.y < numberOfRowsTotal && coord.y >= 0 &&
                        board[coord.x, coord.y] != boardColor)
            {
                hasSquare = true;
            }

            return hasSquare;
        }

        // verific daca patratul poate sa fie in pozitia aceea
        private Boolean canBeHere(Block block)
        {
            Boolean canBeHere = true;

            for (int col = 0; col < block.squares.GetLength(0); col++)
            {
                for (int row = 0; row < block.squares.GetLength(1); row++)
                {
 
                    if (block.squares[row, col])
                    {
   
                        Coordinate coord = block.toBoardCoordinates(new Coordinate(col, row));
                        if (hasSquare(coord) || coord.x >= numberOfColumns || coord.x < 0
                                || coord.y >= numberOfRowsTotal)
                        {
                            canBeHere = false;
                        }
                    }
                }
            }

            return canBeHere;
        }



        // verific daca piesa se poate roti
        private Boolean canRotate()
        {
            Boolean canRotate = true;

            Block whenRotated = currentBlock.Clone();
            whenRotated.rotateClockwise();

            if (!canBeHere(whenRotated))
                canRotate = false;

            return canRotate;
        }

        // verific daca blocul poate cadea in continuare
        private Boolean canDropFurther()
        {
            Boolean canDrop = true;

            Block whenDropped = currentBlock.Clone();
            whenDropped.y++;

            if (!canBeHere(whenDropped))
                canDrop = false;

            return canDrop;
        }

        // verific daca blocul se poate muta intr o parte
        private Boolean canMoveToSide(Boolean toRight)
        {
            Boolean canMove = true;

            Block whenMoved = currentBlock.Clone();
            if (toRight)
                whenMoved.x++;
            else
                whenMoved.x--;

            if (!canBeHere(whenMoved))
                canMove = false;

            return canMove;
        }

    }
}