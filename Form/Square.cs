using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TetrisFinal1
{

    // un patrat de afisare pe tabela
    public partial class Square : UserControl
    {
        public Square(int row, int col)
        {
            InitializeComponent();
            this.Name = "square" + row.ToString() + col.ToString();
            this.row = row;
            this.column = col;
        }


        // numele patratului
        public new string Name { get; set; }

        // linia pe care se afla
        public int row { get; set; }

        // coloana pe care se afla
        public int column { get; set; }

        // culoarea patratului
        public int color
        {
            set
            {
   
                this.BackColor = Color.FromArgb(value);
            }
        }
    }
}