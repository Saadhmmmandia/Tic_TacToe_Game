using System;
using System.Drawing;
using System.Windows.Forms;
using Tic_TacToe_Game.Properties;

namespace Tic_TacToe_Game
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        enum enPlayerTurn
        {
            Player1 = 1,
            Player2 = 2,
        }
        enum enPlayerWine
        {

            Player1 = 1,
            Player2 = 2,
            
        }
        private static enPlayerTurn ePlayerTurn = enPlayerTurn.Player1;
        private static enPlayerWine PlayerWine;
        private static int CounterP = 0;
        private void Paint_PlaceGame(object sender, PaintEventArgs e)
        {
            Color White = Color.FromArgb(255, 255, 255);
            Pen Pen = new Pen(White);
            Pen.Width = 10;
            //Pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            Pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            Pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            e.Graphics.DrawLine(Pen, 500, 150, 500, 650);
            e.Graphics.DrawLine(Pen, 720, 150, 720, 650);
            e.Graphics.DrawLine(Pen, 300, 300, 900, 300);
            e.Graphics.DrawLine(Pen, 300, 480, 900, 480);
        }

        void restartGame()
        {
            for(int i = 0; i < 5; i++) {
                CheckedP1[i] = "";
            }
            for (int i = 0; i < 5; i++)
            {
                CheckedP2[i] = "";
            }
            CounterP = 0;
            ePlayerTurn = enPlayerTurn.Player1;
            PlayerWine = 0;
            Lb_ShowTurn.Text = "Player 1";
            Lb_ShowWinner.Text = "In Progress";
            pictureBox1.Enabled = true;
            pictureBox2.Enabled = true;
            pictureBox3.Enabled = true;
            pictureBox4.Enabled = true;
            pictureBox5.Enabled = true;
            pictureBox6.Enabled = true;
            pictureBox7.Enabled = true;
            pictureBox8.Enabled = true;
            pictureBox9.Enabled = true;

            pictureBox1.Image = Resources.question_mark_96;
            pictureBox2.Image = Resources.question_mark_96;
            pictureBox3.Image = Resources.question_mark_96;
            pictureBox4.Image = Resources.question_mark_96;
            pictureBox5.Image = Resources.question_mark_96;
            pictureBox6.Image = Resources.question_mark_96;
            pictureBox7.Image = Resources.question_mark_96;
            pictureBox8.Image = Resources.question_mark_96;
            pictureBox9.Image = Resources.question_mark_96;

            isLockedPb1 = false;
            isLockedPb2 = false;
            isLockedPb3 = false;
            isLockedPb4 = false;
            isLockedPb5 = false;
            isLockedPb6 = false;
            isLockedPb7 = false;
            isLockedPb8 = false;
            isLockedPb9 = false;

            pictureBox1.BackColor = Color.FromArgb(255, 0,0, 0);
            pictureBox2.BackColor = Color.FromArgb(255, 0,0, 0);
            pictureBox3.BackColor = Color.FromArgb(255, 0,0, 0);
            pictureBox4.BackColor = Color.FromArgb(255, 0, 0, 0);
            pictureBox5.BackColor = Color.FromArgb(255, 0, 0, 0);
            pictureBox6.BackColor = Color.FromArgb(255, 0, 0, 0);
            pictureBox7.BackColor = Color.FromArgb(255, 0, 0, 0);
            pictureBox8.BackColor = Color.FromArgb(255, 0, 0, 0);
            pictureBox9.BackColor = Color.FromArgb(255, 0, 0, 0);
        }
        private void btn_RestartGame_Click(object sender, EventArgs e)
        {
            restartGame();
        }


        enPlayerTurn PlayerTurn()
        {
            if (ePlayerTurn == enPlayerTurn.Player1)
            {
                ePlayerTurn = enPlayerTurn.Player2;
            }
            else
            {
                ePlayerTurn = enPlayerTurn.Player1;
            }
            return ePlayerTurn;
        }
        private static string[] CheckedP1 = new string[5];
        private static string[] CheckedP2 = new string[5];

        static bool IsExist(string[] Checked, string searchPosition)
        {
           
             return Array.Exists(Checked, element => element == searchPosition); 
        }
        bool checkPlayerHasWon(string[] Checked)
        {
            //ORIZEANTAL
            if (IsExist(Checked, "(1,1)") && IsExist(Checked, "(1,2)") && IsExist(Checked, "(1,3)"))
            {
                pictureBox1.BackColor = Color.FromArgb(255, 0, 255, 0);
                pictureBox2.BackColor = Color.FromArgb(255, 0, 255, 0);
                pictureBox3.BackColor = Color.FromArgb(255, 0, 255, 0);
                return true;
            }
            if (IsExist(Checked, "(2,1)") && IsExist(Checked, "(2,2)") && IsExist(Checked, "(2,3)"))
            {
                pictureBox4.BackColor = Color.FromArgb(255, 0, 255, 0);
                pictureBox5.BackColor = Color.FromArgb(255, 0, 255, 0); 
                pictureBox6.BackColor = Color.FromArgb(255, 0, 255, 0);
                return true;
            }
            if (IsExist(Checked, "(3,1)") && IsExist(Checked, "(3,2)") && IsExist(Checked, "(3,3)"))
            {
                pictureBox7.BackColor = Color.FromArgb(255, 0, 255, 0);
                pictureBox8.BackColor = Color.FromArgb(255, 0, 255, 0);
                pictureBox9.BackColor = Color.FromArgb(255, 0, 255, 0);
                return true;
            }
            //vertical
            if (IsExist(Checked, "(1,1)") && IsExist(Checked, "(2,1)") && IsExist(Checked, "(3,1)"))
            {
                pictureBox1.BackColor = Color.FromArgb(255, 0, 255, 0);
                pictureBox4.BackColor = Color.FromArgb(255, 0, 255, 0);
                pictureBox7.BackColor = Color.FromArgb(255, 0, 255, 0);
                return true;
            }
            if (IsExist(Checked, "(1,2)") && IsExist(Checked, "(2,2)") && IsExist(Checked, "(3,2)"))
            {
                pictureBox2.BackColor = Color.FromArgb(255, 0, 255, 0);
                pictureBox5.BackColor = Color.FromArgb(255, 0, 255, 0);
                pictureBox8.BackColor = Color.FromArgb(255, 0, 255, 0);
                return true;
            }
            if (IsExist(Checked, "(1,3)") && IsExist(Checked, "(2,3)") && IsExist(Checked, "(3,3)"))
            {
                pictureBox3.BackColor = Color.FromArgb(255, 0, 255, 0);
                pictureBox6.BackColor = Color.FromArgb(255, 0, 255, 0);
                pictureBox9.BackColor = Color.FromArgb(255, 0, 255, 0);
                return true;
            }
            //diagonal
            if (IsExist(Checked, "(1,1)") && IsExist(Checked, "(2,2)") && IsExist(Checked, "(3,3)"))
            {
                pictureBox1.BackColor = Color.FromArgb(255, 0, 255, 0);
                pictureBox5.BackColor = Color.FromArgb(255, 0, 255, 0);
                pictureBox9.BackColor = Color.FromArgb(255, 0, 255, 0);
                return true;
            }
            if (IsExist(Checked, "(1,3)") && IsExist(Checked, "(2,2)") && IsExist(Checked, "(3,1)"))
            {
                pictureBox3.BackColor = Color.FromArgb(255, 0, 255, 0);
                pictureBox5.BackColor = Color.FromArgb(255, 0, 255, 0);
                pictureBox7.BackColor = Color.FromArgb(255, 0, 255, 0);
                return true;
            }

            return false;

        }

        

        enPlayerWine PlayerWinner(string PositionChecked)
        {
            
            if (ePlayerTurn == enPlayerTurn.Player1 && CounterP < 5 )
            {
                CheckedP1[CounterP] = PositionChecked;
                CounterP++;
                if (CounterP >= 3)
                {
                    if (checkPlayerHasWon(CheckedP1) == true)
                    {
                        PlayerWine = enPlayerWine.Player1;
                        return PlayerWine;
                    }
                }
                
            }
            else if (ePlayerTurn == enPlayerTurn.Player2 && CounterP < 5)
            {
                CheckedP2[CounterP - 1] = PositionChecked;

                if (CounterP >= 3)
                {
                    if (checkPlayerHasWon(CheckedP2) == true)
                    {
                        PlayerWine = enPlayerWine.Player2;
                        return PlayerWine;
                    }
                }
            }
          
                return PlayerWine;
        }
        void Gameover()
        {
            MessageBox.Show("Game Over", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
            pictureBox1.Enabled = false;
            pictureBox2.Enabled = false;
            pictureBox3.Enabled = false;
            pictureBox4.Enabled = false;
            pictureBox5.Enabled = false;
            pictureBox6.Enabled = false;
            pictureBox7.Enabled = false;
            pictureBox8.Enabled = false;
            pictureBox9.Enabled = false;
        }
        void ShowPlayerTurn()
        {
            ePlayerTurn = PlayerTurn();
            if (ePlayerTurn == enPlayerTurn.Player1)
            {
                Lb_ShowTurn.Text = "Player 1";
            }
            else if (ePlayerTurn == enPlayerTurn.Player2)
            {
                Lb_ShowTurn.Text = "Player 2";
            }
        }
        void ShowPlayerWinner(string PositionChecked)
        {
            PlayerWine = PlayerWinner(PositionChecked);
            if (PlayerWine == enPlayerWine.Player1)
            {
                Lb_ShowWinner.Text = "Player 1";
                Lb_ShowTurn.Text = "Game Over";
                Gameover();
            }
            else if (PlayerWine == enPlayerWine.Player2)
            {
                Lb_ShowWinner.Text = "Player 2";
                Lb_ShowTurn.Text = "Game Over";
                Gameover();
            }
            else if (CounterP == 5)
            {
                Lb_ShowWinner.Text = "Draw";
                Lb_ShowTurn.Text = "Game Over";
                Gameover();
            }

        }
        void Play(string PositionChecked)
        {

            ShowPlayerWinner(PositionChecked);
            ShowPlayerTurn();
        }
        private bool isLockedPb1 = false;
        private bool isLockedPb2 = false;
        private bool isLockedPb3 = false;
        private bool isLockedPb4 = false;
        private bool isLockedPb5 = false;
        private bool isLockedPb6 = false;
        private bool isLockedPb7 = false;
        private bool isLockedPb8 = false;
        private bool isLockedPb9 = false;
        private void pictureBox1_Click(object sender, EventArgs e)
        {

            if (!isLockedPb1)
            {

                isLockedPb1 = true;
                if (ePlayerTurn == enPlayerTurn.Player1)
                {
                    pictureBox1.Image = Resources.X;
                }
                else if (ePlayerTurn == enPlayerTurn.Player2)
                {
                    pictureBox1.Image = Resources.O;
                }


                Play(Convert.ToString(pictureBox1.Tag));

            }
            else
            {
                MessageBox.Show("Wrong Choice", "warnning", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (!isLockedPb2)
            {
                isLockedPb2 = true;
                if (ePlayerTurn == enPlayerTurn.Player1)
                {
                    pictureBox2.Image = Resources.X;
                }
                else if (ePlayerTurn == enPlayerTurn.Player2)
                {
                    pictureBox2.Image = Resources.O;
                }

                Play(Convert.ToString(pictureBox2.Tag));

            }
            else
            {
                MessageBox.Show("Wrong Choice", "warnning", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (!isLockedPb3)
            {
                isLockedPb3 = true;
                if (ePlayerTurn == enPlayerTurn.Player1)
                {
                    pictureBox3.Image = Resources.X;
                }
                else if (ePlayerTurn == enPlayerTurn.Player2)
                {
                    pictureBox3.Image = Resources.O;
                }

                Play(Convert.ToString(pictureBox3.Tag));

            }
            else
            {
                MessageBox.Show("Wrong Choice", "warnning", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }


        private void pictureBox4_Click_1(object sender, EventArgs e)
        {
            if (!isLockedPb4)
            {
                isLockedPb4 = true;
                if (ePlayerTurn == enPlayerTurn.Player1)
                {
                    pictureBox4.Image = Resources.X;
                }
                else if (ePlayerTurn == enPlayerTurn.Player2)
                {
                    pictureBox4.Image = Resources.O;
                }

                Play(Convert.ToString(pictureBox4.Tag));

            }
            else
            {
                MessageBox.Show("Wrong Choice", "warnning", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (!isLockedPb5)
            {
                isLockedPb5 = true;
                if (ePlayerTurn == enPlayerTurn.Player1)
                {
                    pictureBox5.Image = Resources.X;
                }
                else if (ePlayerTurn == enPlayerTurn.Player2)
                {
                    pictureBox5.Image = Resources.O;
                }

                Play(Convert.ToString(pictureBox5.Tag));

            }
            else
            {
                MessageBox.Show("Wrong Choice", "warnning", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (!isLockedPb6)
            {
                isLockedPb6 = true;
                if (ePlayerTurn == enPlayerTurn.Player1)
                {
                    pictureBox6.Image = Resources.X;
                }
                else if (ePlayerTurn == enPlayerTurn.Player2)
                {
                    pictureBox6.Image = Resources.O;
                }

                Play(Convert.ToString(pictureBox6.Tag));

            }
            else
            {
                MessageBox.Show("Wrong Choice", "warnning", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            if (!isLockedPb7)
            {
                isLockedPb7 = true;
                if (ePlayerTurn == enPlayerTurn.Player1)
                {
                    pictureBox7.Image = Resources.X;
                }
                else if (ePlayerTurn == enPlayerTurn.Player2)
                {
                    pictureBox7.Image = Resources.O;
                }

                Play(Convert.ToString(pictureBox7.Tag));

            }
            else
            {
                MessageBox.Show("Wrong Choice", "warnning", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            if (!isLockedPb8)
            {
                isLockedPb8 = true;
                if (ePlayerTurn == enPlayerTurn.Player1)
                {
                    pictureBox8.Image = Resources.X;
                }
                else if (ePlayerTurn == enPlayerTurn.Player2)
                {
                    pictureBox8.Image = Resources.O;
                }

                Play(Convert.ToString(pictureBox8.Tag));

            }
            else
            {
                MessageBox.Show("Wrong Choice", "warnning", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            if (!isLockedPb9)
            {
                isLockedPb9 = true;
                if (ePlayerTurn == enPlayerTurn.Player1)
                {
                    pictureBox9.Image = Resources.X;
                }
                else if (ePlayerTurn == enPlayerTurn.Player2)
                {
                    pictureBox9.Image = Resources.O;
                }

                Play(Convert.ToString(pictureBox9.Tag));

            }
            else
            {
                MessageBox.Show("Wrong Choice", "warnning", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }

}

