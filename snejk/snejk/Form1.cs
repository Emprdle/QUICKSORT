using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace snejk
{
    public partial class Form1 : Form
    {
        List<PictureBox> snake = new List<PictureBox>();
        PictureBox jidlo = new PictureBox() {
            Size = new Size(50, 50),
            BackColor = Color.Orange,
        };
        int a=0;
        int b=0;
        int score = 0;
        public Form1()
        {

            InitializeComponent();
            GenerateHead();
            this.Controls.Add(jidlo);
            GenerateFood();
            label1.Text = score.ToString();
            label1.SendToBack();
            
        }
        void GenerateHead()
        {
            PictureBox head = new PictureBox()
            {
                Size = new Size(50, 50),
                BackColor = Color.LawnGreen,
                Location = new Point(((this.Width / 2) / 50) * 50, ((this.Height / 2) / 50) * 50)
            };

            snake.Add(head);
            this.Controls.Add(head);
        }
        void MoveSnake(int z)
        {
            if (z == 1)
            {
                PictureBox body = new PictureBox()
                {
                    Location = new Point(0,0),
                    Size = new Size(50,50),
                    BackColor = Color.Black
                };
                this.Controls.Add(body);
                snake.Add(body);
            }
            for (int i = snake.Count-1; i > 0; i--)
            {
                snake[i].Location = snake[i - 1].Location;
            }
            snake[0].Location = new Point(snake[0].Location.X + a, snake[0].Location.Y + b);
            Kolize();

        }
        void GenerateFood()
        {
            Random random = new Random();
            jidlo.Location = new Point((random.Next(0,this.Size.Width)/50)*50, (random.Next(0, this.Size.Height) / 50) * 50);
        }
        void Kolize()
        {
            for (int i = 1; i < snake.Count; i++) 
            {
                if (snake[0].Bounds.IntersectsWith(snake[i].Bounds))
                {
                    GameOver();
                }
            }
            if (snake[0].Location.X + snake[0].Width > this.Width ||
                snake[0].Location.Y + snake[0].Height > this.Height ||
                snake[0].Location.X + snake[0].Width < 0 ||
                snake[0].Location.Y + snake[0].Height < 0)
            {
                GameOver();
            }
        }
        void GameOver()
        {
            engine.Enabled = false;
            MessageBox.Show("KONEC HRY");
        }
        void Eat()
        {
            if (snake[0].Bounds.IntersectsWith(jidlo.Bounds))
            {
                GenerateFood();
                MoveSnake(1);
                score++;
                label1.Text = score.ToString();
            }
        }

        private void engine_Tick(object sender, EventArgs e)
        {
            MoveSnake(0);
            Eat();
        }
        
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Right && a != -50)
            {
                a = 50;
                b = 0;
            }
            else if (e.KeyData == Keys.Left && a != 50)
            {
                a = -50;
                b = 0;
            }
            else if (e.KeyData == Keys.Up && b != 50)
            {
                a = 0;
                b = -50;
            }
            else if (e.KeyData == Keys.Down && b != -50)
            {
                a = 0;
                b = 50;
            }


        }
    }
}
