using System;
using System.Drawing;
using System.Windows.Forms;

namespace Pattern_Command_Game_Cross_and_Zeroes
{
    public partial class Form1 : Form, IGame
    {
        public Form1()
        {
            InitializeComponent();
        }
        public int[] FieldCells { get; set; }
        public int IsWinner { get; set; }

        public event Action<int> SomethingHappendOnTheField;
        public event Action Reset;
        public event Action PlayerUndo;

        private void click(object sender, EventArgs e)
        {
            SomethingHappendOnTheField?.Invoke(int.Parse((sender as Button)?.AccessibleName));
            FillCells();
            WinnerDeclare();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            PlayerUndo?.Invoke();
            FillCells();
            WinnerDeclare();
        }

        private void FillCells()
        {
            if (FieldCells[0] != 1)
                button1_1.Image = FieldCells[0] == 2 ? Image.FromFile(@"../../zero.bmp") : null;
            else
                button1_1.Image = Image.FromFile(@"../../cross.bmp");

            if (FieldCells[1] != 1)
                button1_2.Image = FieldCells[1] == 2 ? Image.FromFile(@"../../zero.bmp") : null;
            else
                button1_2.Image = Image.FromFile(@"../../cross.bmp");

            if (FieldCells[2] != 1)
                button1_3.Image = FieldCells[2] == 2 ? Image.FromFile(@"../../zero.bmp") : null;
            else
                button1_3.Image = Image.FromFile(@"../../cross.bmp");

            if (FieldCells[3] != 1)
                button2_1.Image = FieldCells[3] == 2 ? Image.FromFile(@"../../zero.bmp") : null;
            else
                button2_1.Image = Image.FromFile(@"../../cross.bmp");

            if (FieldCells[4] != 1)
                button2_2.Image = FieldCells[4] == 2 ? Image.FromFile(@"../../zero.bmp") : null;
            else
                button2_2.Image = Image.FromFile(@"../../cross.bmp");

            if (FieldCells[5] != 1)
                button2_3.Image = FieldCells[5] == 2 ? Image.FromFile(@"../../zero.bmp") : null;
            else
                button2_3.Image = Image.FromFile(@"../../cross.bmp");

            if (FieldCells[6] != 1)
                button3_1.Image = FieldCells[6] == 2 ? Image.FromFile(@"../../zero.bmp") : null;
            else
                button3_1.Image = Image.FromFile(@"../../cross.bmp");

            if (FieldCells[7] != 1)
                button3_2.Image = FieldCells[7] == 2 ? Image.FromFile(@"../../zero.bmp") : null;
            else
                button3_2.Image = Image.FromFile(@"../../cross.bmp");

            if (FieldCells[8] != 1)
                button3_3.Image = FieldCells[8] == 2 ? Image.FromFile(@"../../zero.bmp") : null;
            else
                button3_3.Image = Image.FromFile(@"../../cross.bmp");

            button10.Focus();
        }

        private void WinnerDeclare()
        {
            if (IsWinner == 0) return; 
            foreach (var control in Controls)
            {
                if (control is Button)
                    (control as Button).Enabled = false;
            }
            switch (IsWinner)
            {
                case 1:
                    labelWon.Visible = true;
                    break;
                case 2:
                    labelLoose.Visible = true;
                    break;
            }
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var control in Controls)
            {
                if (!(control is Button)) continue;
                (control as Button).Image = null;
                (control as Button).Enabled = true;
            }
            labelWon.Visible = false;
            labelLoose.Visible = false;
            IsWinner = 0;
            Reset?.Invoke();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
