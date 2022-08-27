using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TetrisFinal1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            createSquares();
        }


        Boolean playing { get; set; }

        Board board;

        int numberOfColumns = 15;

        int numberOfRows = 25;
        // dimensiunea in px a patratului
        int squareDimensions = 25;

        // patratele ce sunt vizibile pe tabela
        Dictionary<string, Square> squares = new Dictionary<string, Square>();

        Input input = new Input();


        // Resets the game
        private void resetGame()
        {
            board = new Board(numberOfRows, numberOfColumns);
            createSquares();
            tickTimer.Enabled = true;
            playing = true;
        }

        private void tickTimer_Tick(object sender, EventArgs e)
        {
            if (playing)
            {
                board.tick();
                updateBoard();
                rowsCleared.Text = board.rowsDestroyed.ToString();
                score.Text = board.score.ToString();
            }
        }


        private String squaresKey(int row, int col)
        {
            return "R" + row.ToString() + "C" + col.ToString();
        }


        private void createSquares()
        {
            foreach (KeyValuePair<String, Square> val in squares)
            {
                val.Value.Dispose();
            }
            squares.Clear();

            for (int row = 0; row < numberOfRows; row++)
            {
                for (int col = 0; col < numberOfColumns; col++)
                {
                    Square square = new Square(row, col);
                    square.Width = squareDimensions;
                    square.Height = squareDimensions;
                    square.Parent = gameWindow;
                    square.Top = row * squareDimensions;
                    square.Left = col * squareDimensions;

                    squares.Add(squaresKey(row, col), square);
                }
            }
        }


        private void updateBoard()
        {
            Square square;
            for (int row = 0; row < numberOfRows; row++)
            {
                for (int col = 0; col < numberOfColumns; col++)
                {
                    squares.TryGetValue(squaresKey(row, col), out square);
                    square.color = board.board[col, row + board.hiddenRows];
                }
            }

            Block block = board.currentBlock;
            for (int row = 0; row < block.squares.GetLength(0); row++)
            {
                for (int col = 0; col < block.squares.GetLength(1); col++)
                {
                    Coordinate coord = new Coordinate(col, row);
                    coord = block.toBoardCoordinates(coord);
                    if (block.squares[row, col] && coord.x >= 0 && coord.x < numberOfColumns
                            && coord.y >= board.hiddenRows && coord.y < numberOfRows + board.hiddenRows)
                    {
                        squares.TryGetValue(squaresKey(coord.y - board.hiddenRows, coord.x), out square);
                        square.color = block.color.ToArgb();
                    }
                }
            }
        }



        // creez un joc nou pentru cand se apasa new game
        private void newGameButton_Click(object sender, EventArgs e)
        {
            resetGame();
        }

        private void TetrisGame_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (playing)
            {
                if (input.downKeyPressed)
                {
                    board.lowerBlock();
                }
                if (input.leftKeyPressed)
                {
                    board.moveBlockLeft();
                }
                if (input.rightKeyPressed)
                {
                    board.moveBlockRight();
                }
                if (input.rotateKeyPressed)
                {
                    board.rotateBlock();
                }
                updateBoard();
            }
        }

        // cand o tasta este apasata las controllerul sa proceseze actiunea
        private void TetrisGame_KeyDown(object sender, KeyEventArgs e)
        {

            char key = e.KeyCode.ToString().ToLower()[0];
            input.processKey(key, true);
        }

        // si pentru cand tasta este ridicata
        private void TetrisGame_KeyUp(object sender, KeyEventArgs e)
        {
            char key = e.KeyCode.ToString().ToLower()[0];
            input.processKey(key, false);
        }


    }
}