using System;
using System.Drawing;
using System.Windows.Forms;

namespace usecky
{
    public partial class Form1 : Form
    {
        double[,] rovnice;
        int[,] usecky;
        double[,] pruseciky;
        public Form1()
        {
            InitializeComponent();
            ProcessText();
            ParseIntoEquations();
            IntersectionEquationSolver();
        }
        int IntersectionEquationSolver()
        {
            int count = 0;
            double vysledekx = -90;
            double vysledeky = -90;

            pruseciky = new double[2,(rovnice.Length*rovnice.Length)/16-rovnice.Length/4];
            for (int j = 0; j < rovnice.Length / 4; j++)
            {
                for (int i = 0; i < rovnice.Length / 4; i++)
                {
                    if (i != j)
                    {
                        if ((rovnice[0, i] * rovnice[1, j]) - (rovnice[1, i] * rovnice[0, j]) != 0)
                        {
                            vysledekx = (rovnice[1, i] * rovnice[2, j] - rovnice[2, i] * rovnice[1, j]) / ((rovnice[0, i] * rovnice[1, j]) - (rovnice[1, i] * rovnice[0, j]));
                        }
                        else
                        {
                            continue;
                        }

                        if ((rovnice[0, i] * rovnice[1, j]) - (rovnice[0, j] * rovnice[1, i]) != 0)
                        {
                            vysledeky = (rovnice[0, j] * rovnice[2, i] - rovnice[2, j] * rovnice[0, i]) / ((rovnice[0, i] * rovnice[1, j]) - (rovnice[0, j] * rovnice[1, i]));
                        }
                        else
                        {
                            continue;
                        }

                            pruseciky[0, count] = vysledekx;
                            pruseciky[1, count] = vysledeky;
                            count++;
                    }
                }

            }
            return count;

        }
        void DrawCircle(int x, int y)
        {
            Graphics l = this.CreateGraphics();
            Pen green = new Pen(Color.Green, 2);
            Rectangle rectangle = new Rectangle(x + 100-10/2, -y  + this.Height - 100-10/2, 10, 10);
            l.DrawEllipse(green, rectangle);

        }
        void ParseIntoEquations()
        {
            int[] rovnicetemp = new int[4];
            int[] vektory = new int[2];
            rovnice = new double[4, usecky.Length / 4];
            for (int i = 0; i < usecky.Length / 4; i++)
            {
                vektory[1] = -(usecky[2, i] - usecky[0, i]);
                vektory[0] = usecky[3, i] - usecky[1, i];
                rovnice[0, i] = vektory[0];
                rovnice[1, i] = vektory[1];
                rovnice[2, i] = -vektory[0] * usecky[0, i] - vektory[1] * usecky[1, i];
                rovnice[3, i] = 0;
            }
            for (int i = 0; i < usecky.Length / 4; i++)
            {
                string test = "(" + rovnice[0, i].ToString() + "x)\t+\t" + "(" + rovnice[1, i].ToString() + ")y\t+\t" + "(" + rovnice[2, i].ToString() + ")\t=\t" + rovnice[3, i].ToString();
                listBox1.Items.Add(test);
            }
        }
        void ProcessText()
        {
            string[] lines = System.IO.File.ReadAllLines("usecky.txt");
            int o = 0;
            int u = 0;
            foreach (string a in lines)
            {
                if (!a.StartsWith("#"))
                {
                    u++;
                }
            }
            usecky = new int[4, u];
            foreach (string a in lines)
            {
                if (!a.StartsWith("#"))
                {
                    string[] temp = a.Split(';');
                    for (int i = 0; i < 4; i++)
                    {
                        usecky[i, o] = Convert.ToInt32(temp[i]);
                    }
                    o++;
                }
            }
        }
        void Graf()
        {
            Graphics l = this.CreateGraphics();
            Pen red = new Pen(Color.Red, 2);
            l.DrawLine(red, 100, this.Height - 100, 100, 0);
            for (int i = 0; i < 10; i++)
            {
                l.DrawLine(red, 100 + i * 50, this.Height - 100, 100 + i * 50, this.Height - 100 - 20);
                l.DrawLine(red, 100, this.Height - 100 - i * 50, 100 + 20, this.Height - 100 - i * 50);
            }
            l.DrawLine(red, 100, this.Height - 100, this.Width, this.Height - 100);
            l.DrawLine(red, 100, this.Height - 100, 100, 0);
        }
        void Usecky(int x1, int y1, int x2, int y2)
        {
            Graphics l = this.CreateGraphics();
            Pen red = new Pen(Color.Red, 2);
            l.DrawLine(red, 100 + x1 * 50, this.Height - 100 - y1 * 50, 100 + x2 * 50, this.Height - 100 - y2 * 50);
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graf();
            for (int i = 0; i < usecky.Length / 4; i++)
                Usecky(usecky[0, i], usecky[1, i], usecky[2, i], usecky[3, i]);
            for(int i = 0; i < IntersectionEquationSolver(); i++)
            {
                string test = "X = "+pruseciky[0, i].ToString() +"Y = " +pruseciky[1, i].ToString();
                listBox1.Items.Add(test);
                DrawCircle(Convert.ToInt32(pruseciky[0,i]*50),Convert.ToInt32(pruseciky[1,i]*50));
            }
        }
    }
}
