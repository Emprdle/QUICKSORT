using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace Emrle
{
    public partial class Emrle : Form
    {
        string[] soubor = File.ReadAllLines(@"float-matrix-02-05.txt");
        string[] soubor1 = File.ReadAllLines(@"float-matrix-02-10.txt");
        string[] soubor2 = File.ReadAllLines(@"float-matrix-02-20.txt");
        string[] soubor3 = File.ReadAllLines(@"float-matrix-02-30.txt");
        string[] soubor4 = File.ReadAllLines(@"float-matrix-02-50.txt");
        string[] soubor0 = File.ReadAllLines(@"double-matrix-02-05.txt");
        string[] soubor01 = File.ReadAllLines(@"double-matrix-02-10.txt");
        string[] soubor02 = File.ReadAllLines(@"double-matrix-02-20.txt");
        string[] soubor03 = File.ReadAllLines(@"double-matrix-02-30.txt");
        string[] soubor04 = File.ReadAllLines(@"double-matrix-02-50.txt");
        private Stopwatch stopWatch;

        public Emrle()
        {
            InitializeComponent();  
            
        }


        public void button1_Click(object sender, EventArgs e)
        {
            textBox1.ResetText();
            Stopwatch stopWatch = new Stopwatch();
            //textBox1.Text = _ticks.ToString();
            float[,] dd = new float[soubor.Length, soubor.Length + 1];

            for (int i = 0; i < soubor.Length; i++)
            {
                for (int l = 0; l < soubor.Length + 1; l++)
                {
                    dd[i,l] = float.Parse(soubor[i].Split(',')[l]);
                }
            }
            //---------------------------------------------------------------
            float[,] dd1 = new float[soubor1.Length, soubor1.Length + 1];

            for (int i = 0; i < soubor1.Length; i++)
            {
                for (int l = 0; l < soubor1.Length + 1; l++)
                {
                    dd1[i, l] = float.Parse(soubor1[i].Split(',')[l]);
                }
            }
            //---------------------------------------------------------------
            float[,] dd2 = new float[soubor2.Length, soubor2.Length + 1];

            for (int i = 0; i < soubor2.Length; i++)
            {
                for (int l = 0; l < soubor2.Length + 1; l++)
                {
                    dd2[i, l] = float.Parse(soubor2[i].Split(',')[l]);
                }
            }
            //---------------------------------------------------------------
            float[,] dd3 = new float[soubor3.Length, soubor3.Length + 1];

            for (int i = 0; i < soubor3.Length; i++)
            {
                for (int l = 0; l < soubor3.Length + 1; l++)
                {
                    dd3[i, l] = float.Parse(soubor3[i].Split(',')[l]);
                }
            }
            //---------------------------------------------------------------
            float[,] dd4 = new float[soubor4.Length, soubor4.Length + 1];

            for (int i = 0; i < soubor4.Length; i++)
            {
                for (int l = 0; l < soubor4.Length + 1; l++)
                {
                    dd4[i, l] = float.Parse(soubor4[i].Split(',')[l]);
                }
            }
            //---------------------------------------------------------------
            float[,] dd5 = new float[soubor4.Length, soubor4.Length + 1];

            for (int i = 0; i < soubor4.Length; i++)
            {
                for (int l = 0; l < soubor4.Length + 1; l++)
                {
                    dd5[i, l] = float.Parse(soubor4[i].Split(',')[l]);
                }
            }
            //---------------------------------------------------------------


            stopWatch.Start();
            float[] vypis5 = G(dd5);
            stopWatch.Stop();    
            stopWatch.Reset();

            stopWatch.Start();
            float[] vypis = G(dd);
            stopWatch.Stop();
            textBox3.Text = stopWatch.ElapsedTicks.ToString();
            stopWatch.Reset();

            stopWatch.Start();
            float[] vypis1 = G(dd1);
            stopWatch.Stop();
            textBox4.Text = stopWatch.ElapsedTicks.ToString();
            stopWatch.Reset();

            stopWatch.Start();
            float[] vypis2 = G(dd2);
            stopWatch.Stop();
            textBox5.Text = stopWatch.ElapsedTicks.ToString();
            stopWatch.Reset();

            stopWatch.Start();
            float[] vypis3 = G(dd3);
            stopWatch.Stop();
            textBox6.Text = stopWatch.ElapsedTicks.ToString();
            stopWatch.Reset();

            stopWatch.Start();
            float[] vypis4 = G(dd4);
            stopWatch.Stop();
            textBox7.Text = stopWatch.ElapsedTicks.ToString();
            stopWatch.Reset();
            //---------------------------------------------------------------


            textBox1.Text += Convert.ToString("  5 :  ");
            for (int i = 0; i < vypis.Length; i++)
            {
                textBox1.Text += Convert.ToString(vypis[i] + " ");
            }
            textBox1.Text += Convert.ToString("                                                                                   10 :  ");
            
            for (int i = 0; i < vypis1.Length; i++)
            {
                textBox1.Text += Convert.ToString(vypis1[i] + " ");
            }
            textBox1.Text += Convert.ToString("                                                                     20 :  ");
            for (int i = 0; i < vypis2.Length; i++)
            {
                textBox1.Text += Convert.ToString(vypis2[i] + " ");
            }
            textBox1.Text += Convert.ToString("                                         30 :  ");
            for (int i = 0; i < vypis3.Length; i++)
            {
                textBox1.Text += Convert.ToString(vypis3[i] + " ");
            }
            textBox1.Text += Convert.ToString("           50 :  ");
            for (int i = 0; i < vypis4.Length; i++)
            {
                textBox1.Text += Convert.ToString(vypis4[i] + " ");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            textBox2.ResetText();
            Stopwatch stopWatch = new Stopwatch();
            double[,] fd = new double[soubor0.Length, soubor0.Length + 1];

            for (int i = 0; i < soubor0.Length; i++)
            {
                for (int l = 0; l < soubor0.Length + 1; l++)
                {
                    fd[i, l] = double.Parse(soubor0[i].Split(',')[l]);
                }
            }
            //---------------------------------------------------------------
            double[,] fd1 = new double[soubor01.Length, soubor01.Length + 1];

            for (int i = 0; i < soubor01.Length; i++)
            {
                for (int l = 0; l < soubor01.Length + 1; l++)
                {
                    fd1[i, l] = double.Parse(soubor01[i].Split(',')[l]);
                }
            }
            //---------------------------------------------------------------
            double[,] fd2 = new double[soubor02.Length, soubor02.Length + 1];

            for (int i = 0; i < soubor02.Length; i++)
            {
                for (int l = 0; l < soubor02.Length + 1; l++)
                {
                    fd2[i, l] = double.Parse(soubor2[i].Split(',')[l]);
                }
            }
            //---------------------------------------------------------------
            double[,] fd3 = new double[soubor03.Length, soubor03.Length + 1];

            for (int i = 0; i < soubor03.Length; i++)
            {
                for (int l = 0; l < soubor03.Length + 1; l++)
                {
                    fd3[i, l] = double.Parse(soubor03[i].Split(',')[l]);
                }
            }
            //---------------------------------------------------------------
            double[,] fd4 = new double[soubor04.Length, soubor04.Length + 1];

            for (int i = 0; i < soubor04.Length; i++)
            {
                for (int l = 0; l < soubor04.Length + 1; l++)
                {
                    fd4[i, l] = double.Parse(soubor04[i].Split(',')[l]);
                }
            }
            //---------------------------------------------------------------

            stopWatch.Start();
            double[] vypis = GG(fd);
            stopWatch.Stop();
            textBox8.Text = stopWatch.ElapsedTicks.ToString();
            stopWatch.Reset();

            stopWatch.Start();
            double[] vypis1 = GG(fd1);
            stopWatch.Stop();
            textBox9.Text = stopWatch.ElapsedTicks.ToString();
            stopWatch.Reset();

            stopWatch.Start();
            double[] vypis2 = GG(fd2);
            stopWatch.Stop();
            textBox10.Text = stopWatch.ElapsedTicks.ToString();
            stopWatch.Reset();

            stopWatch.Start();
            double[] vypis3 = GG(fd3);
            stopWatch.Stop();
            textBox11.Text = stopWatch.ElapsedTicks.ToString();
            stopWatch.Reset();

            stopWatch.Start();
            double[] vypis4 = GG(fd4);
            stopWatch.Stop();
            textBox12.Text = stopWatch.ElapsedTicks.ToString();
            stopWatch.Reset();

            double m = 0;
            string[] Casy = {textBox8.Text, textBox9.Text, textBox10.Text, textBox11.Text, textBox12.Text};
            double[] Casy1 = new double[5];
            for (int i = 0; i < Casy.Length; i++)
            {
                m =  Convert.ToDouble(Casy[i]) / Convert.ToDouble(Casy[0]);
                Casy1[i] = m;
            }

            for (int i = 0; i < 5; i++)
            {
                listBox1.Items.Add(Convert.ToString(Casy1[i]));
            }
            listBox1.Items.Add("V mém případě není časová složitost kubická.");
            listBox1.Items.Add("Výsledky jsou při větším množství hodnot nepřesnější");
            listBox1.Items.Add("(Při menším počtu hodnot jsou poměry vyrovnanější,");
            listBox1.Items.Add("(při větším počtu hodnot jsou poměry nepřesnější.");
            //---------------------------------------------------------------

            //textBox1.Text = Convert.ToString(dd[0,3]);

            textBox2.Text += Convert.ToString("  5 :  ");
            for (int i = 0; i < vypis.Length; i++)
            {
                textBox2.Text += Convert.ToString(vypis[i] + " ");
            }
            textBox2.Text += Convert.ToString("                                                                                   10 :  ");

            for (int i = 0; i < vypis1.Length; i++)
            {
                textBox2.Text += Convert.ToString(vypis1[i] + " ");
            }
            textBox2.Text += Convert.ToString("                                                                     20 :  ");
            for (int i = 0; i < vypis2.Length; i++)
            {
                textBox2.Text += Convert.ToString(vypis2[i] + " ");
            }
            textBox2.Text += Convert.ToString("                                         30 :  ");
            for (int i = 0; i < vypis3.Length; i++)
            {
                textBox2.Text += Convert.ToString(vypis3[i] + " ");
            }
            textBox2.Text += Convert.ToString("           50 :  ");
            for (int i = 0; i < vypis4.Length; i++)
            {
                textBox2.Text += Convert.ToString(vypis4[i] + " ");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        public float[] G(float[,] field)
        {
            
            int n = field.GetLength(0);
            float[] data = new float[n];

            for (int k = 0; k < n - 1; k++)
            {
                for (int i = k + 1; i < n; i++)
                {
                    float mux1 = (field[i, k]);
                    float mux2 = (field[k, k]);

                    float mux = - ( mux1 / mux2 );

                    for (int j = k; j < n + 1; j++)
                    {

                        field[i, j] = field[i, j] + mux * field[k, j];

                    }
                }
            }
            
            for( int i = n - 1; i > -1; i--)
            {
                float SUMA = 0;
                //float Xi = 0;
                //float ain1 = 0;

                for (int j = i + 1; j < n; j++ ) 
                {

                    SUMA += (field[i,j] * data[j]);   

                }
                data[i] = ((float)1 / field[i, i] * (field[i, n] - SUMA));
            }

            

            return data;
        }

        public double[] GG(double[,] field)
        {
            //timer1.Start();
            int n = field.GetLength(0);
            double[] dataa = new double[n];

            for (int k = 0; k < n - 1; k++)
            {
                for (int i = k + 1; i < n; i++)
                {
                    double mux1 = (field[i, k]);
                    double mux2 = (field[k, k]);

                    double mux = -(mux1 / mux2);

                    for (int j = k; j < n + 1; j++)
                    {

                        field[i, j] = field[i, j] + mux * field[k, j];

                    }
                }
            }

            for (int i = n - 1; i > -1; i--)
            {
                double SUMA = 0;
                //float Xi = 0;
                //float ain1 = 0;

                for (int j = i + 1; j < n; j++)
                {

                    SUMA += (field[i, j] * dataa[j]);

                }
                dataa[i] = ((double)1 / field[i, i] * (field[i, n] - SUMA));
            }
            
            return dataa;
        }

        
    }
}
