using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Break_out
{
    public partial class Form1 : Form
    {
        bool Doleva;
        bool Doprava;
        bool isGameOver;

        int lvls = 3;
        int f = 15;
        int level =1;
        int score;
        int ballx;
        int bally;
        int HracRychlost;
       
        Random rnd = new Random();

        PictureBox[] blockArray;

        public Form1()
        {
            InitializeComponent();
            this.BackgroundImage = Properties.Resources.unnamed;
            polozBloky();
        }

        private void setupGame()
        {
            
            score = 0;
            ballx = 5;
            bally = 5;
            HracRychlost = 15;
            txtScore.Text = "Score: " + score;
            lvl.Text = "LVL: " + level;            
            gameTimer.Start();
           
            foreach(Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "blocks")
                {
                    x.BackColor = Color.Purple;
                }
            }            
        }

        private void gameOver(string message)
        {
            isGameOver = true;
            gameTimer.Stop();

            txtScore.Text = "Score: " + score;
            lvl.Text = "LVL: " + level + " " + message;
        }

        private void polozBloky()
        {
            blockArray = new PictureBox[f];
            int a = 0;
            int top = 30;
            int left = 50;

            for(int i = 0; i < blockArray.Length; i++)
            {
                blockArray[i] = new PictureBox();
                blockArray[i].Height = 32;
                blockArray[i].Width = 100;
                blockArray[i].Tag = "blocks";
                blockArray[i].BackColor = Color.Pink;             
                if (a == 5)
                {
                    top = top + 50;
                    left = 50;
                    a = 0;
                }

                if(a < 5)
                {
                    a++;
                    blockArray[i].Left = left;
                    blockArray[i].Top = top;
                    this.Controls.Add(blockArray[i]);
                    left = left + 130;
                }
                
            }
            setupGame();
        }

        private void mainGameTimerEvent(object sender, EventArgs e)
        {
            
            txtScore.Text = "Score: 0" + score;
          
            if (Doleva == true && player.Left > 0)
            {
                player.Left -= HracRychlost;
            }

            if (Doprava == true && player.Left < 585)
            {
                player.Left += HracRychlost;
            }

            ball.Left += ballx;
            ball.Top += bally;


            if (ball.Left < 0 || ball.Left > 662)
            {
                ballx = -ballx;           
            }
            if (ball.Top < 0)
            {
                bally = -bally;
            }
            if (ball.Bounds.IntersectsWith(player.Bounds))
            {
                bally = rnd.Next(5, 12) * -1;

                if (ballx < 0)
                {
                    ballx = rnd.Next(5, 12) * -1;
                }
                else
                {
                    ballx = rnd.Next(5, 12);
                }

            }

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "blocks")
                {
                    if (ball.Bounds.IntersectsWith(x.Bounds))
                    {
                        score += 1;                      
                        bally = -bally;
                        this.Controls.Remove(x);
                    }
                }
            }

            if (score == f)
            {
                
                if (f == 25)
                {
                    gameOver("VÝHRA");
                }
                else
                {
                    level++;
                    f += 5;
                    
                    polozBloky();                  
                    ball.SetBounds(315, 422, 25, 25);
                    player.SetBounds(278, 483, 100, 32);
                }
                
            }

            if (ball.Top > 510)
            {
                if (lvls == 1)
                {
                    gameTimer.Enabled = false;
                    gameOver("PROHRA");    
                }
                lvls--;
                ball.SetBounds(315, 422, 25, 25);
                player.SetBounds(278, 483, 100, 32);
                
            }

            HP.Text = "ŽIVOTY: " + lvls;
        }

        private void keyisdown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Left)
            {
                Doleva = true;
            }
            if(e.KeyCode == Keys.Right)
            {
                Doprava = true;
            }
        }

        private void keyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                Doleva = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                Doprava = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
