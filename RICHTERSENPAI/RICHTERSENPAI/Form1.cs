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

namespace RICHTERSENPAI
{
    public partial class Form1 : Form
    {
        public string s = "Michal je kokot";
        char[] P;
        List<Label> list = new List<Label>();
        int poradi = 0;
        Stopwatch stopWatch = new Stopwatch();

        public Form1()
        {
            InitializeComponent();
            int p = s.Length;
            P = s.ToCharArray();
            
            for (int i = 0; i < p ; i++)
            {
                Label L = new Label() { Name = "L", BackColor = Color.LightCoral,
                    Size = new Size(30,30),
                    Location = new Point(i*35, 50),
                    Text = Convert.ToString(P[i]),
                    Font = new Font("Arial",20)};
                list.Add(L);
                this.Controls.Add(L);
            }
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            stopWatch.Start();
            label2.Text = Convert.ToString(stopWatch.ElapsedMilliseconds);
            
            if ( P[poradi] == Convert.ToChar(e.KeyChar))
            {
                label1.Text = "Good";
                list[poradi].BackColor = Color.Green;
                poradi++;
            }
            else if (P[poradi] != Convert.ToChar(e.KeyChar))
            {
                label1.Text = "Bad";
                list[poradi].BackColor = Color.Red;
            }
            if( poradi == list.Count)
            {
                stopWatch.Stop();
                MessageBox.Show("prumer znaku za sekundu je " + list.Count / ((stopWatch.ElapsedMilliseconds)/1000) + "");
            }

        }

        
    }
}
