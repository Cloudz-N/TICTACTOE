using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TICTACTOE
{
    public partial class Form1 : Form
    {
        bool Xturn = true;
        byte Xturn_count = 0;
        int X = 0;
        int O = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Cscores();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button Turn = (Button)sender;
            if (Xturn)
                Turn.Text = "X";
            else
                Turn.Text = "O";

            Xturn = !Xturn;
            Turn.Enabled = false;

            Win();
        }

        private void Win()
        {
            bool Winner = false;

            if ((Box1.Text == Box2.Text) && (Box2.Text == Box3.Text) && (!Box1.Enabled)) // 1-3
                Winner = true;
            else if ((Box1.Text == Box5.Text) && (Box5.Text == Box9.Text) && (!Box1.Enabled)) // 1-9
                Winner = true;
            else if ((Box1.Text == Box4.Text) && (Box4.Text == Box7.Text) && (!Box1.Enabled)) // 1-7
                Winner = true;
            else if((Box2.Text == Box5.Text) && (Box5.Text == Box8.Text) && (!Box2.Enabled)) // 2-8
                Winner = true;
            else if((Box3.Text == Box6.Text) && (Box6.Text == Box9.Text) && (!Box3.Enabled)) // 3-9
                Winner = true;
            else if((Box3.Text == Box5.Text) && (Box5.Text == Box7.Text) && (!Box3.Enabled)) // 3-7
                Winner = true;
            else if((Box4.Text == Box5.Text) && (Box5.Text == Box6.Text) && (!Box4.Enabled)) // 4-6
                Winner = true;
            else if((Box7.Text == Box8.Text) && (Box8.Text == Box9.Text) && (!Box7.Enabled)) // 7-9
                Winner = true;

            if (Winner)
            {
                if (Xturn == true)
                {
                    MessageBox.Show("O WON!");
                    O += 1;
                    Oscore.Text = O.ToString();
                    newgame();
                }
                else if (Xturn == false)
                {
                    MessageBox.Show("X WON!");
                    X += 1;
                    Xscore.Text = X.ToString();
                    newgame();
                }
                else if (Xturn_count == 9)
                {
                    MessageBox.Show("XO DRAW!");
                    newgame();
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Reset_Click(object sender, EventArgs e)
        {
            newgame();
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            Xscore.Clear();
            Oscore.Clear();
            Cscores();
        }

        private void newgame()
        {
            Xturn = true;
            Xturn_count = 0;
            Box1.Enabled = true;
            Box1.Text = "";
            Box2.Enabled = true;
            Box2.Text = "";
            Box3.Enabled = true;
            Box3.Text = "";
            Box4.Enabled = true;
            Box4.Text = "";
            Box5.Enabled = true;
            Box5.Text = "";
            Box6.Enabled = true;
            Box6.Text = "";
            Box7.Enabled = true;
            Box7.Text = "";
            Box8.Enabled = true;
            Box8.Text = "";
            Box9.Enabled = true;
            Box9.Text = "";
        }

        private void Xscore_TextChanged(object sender, EventArgs e)
        {
            Xscore.ReadOnly = true;
        }

        private void Oscore_TextChanged(object sender, EventArgs e)
        {
            Oscore.ReadOnly = true;
        }

        private void theme_Click(object sender, EventArgs e)
        {
            Box1.Enabled = false;
            Box2.Enabled = false;
            Box3.Enabled = false;
            Box4.Enabled = false;
            Box5.Enabled = false;
            Box6.Enabled = false;
            Box7.Enabled = false;
            Box8.Enabled = false;
            Box9.Enabled = false;
            Random colors = new Random();
            Color clr = Color.FromArgb(colors.Next(0, 255));
            Box1.BackColor = clr;
            Box2.BackColor = clr;
            Box3.BackColor = clr;
            Box4.BackColor = clr;
            Box5.BackColor = clr;
            Box6.BackColor = clr;
            Box7.BackColor = clr;
            Box8.BackColor = clr;
            Box9.BackColor = clr;
            newgame();
        }
        private void Cscores()
        {
            Oscore.Text = O.ToString();
            Xscore.Text = X.ToString();
        }
    }
}
