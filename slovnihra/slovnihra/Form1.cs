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

namespace slovnihra
{
    public partial class Form1 : Form
    {

        private int _ticks = 20;
        string filePath = @"C\Users\Vlastnik\Desktop\text1.txt";
        string[] words = File.ReadAllLines(filePath);
        //string[] words = { "Emrle", "Hemmerle", "Kremrolé", "Loli", "Trapka", "Michal", "Pedofil", "Hrubý", "Smažka", "Sračka", "Hipík", "Nigga", "Kadlec", "Richter" };
        Random rndm = new Random();
        int correct = 0;
        int incorrect = 0;


        public Form1()
        {
            InitializeComponent();
            lblword.Text = words[rndm.Next(0, words.Length) ];
        }

        private void lblword_Click(object sender, EventArgs e)
        {

        }

        private void checkGame(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                
                if (textBox1.Text == lblword.Text)
                {
                    correct++;
                    lblword.Text = words[rndm.Next(0, words.Length)];
                    textBox1.Text = null;
                }
                else
                {
                    incorrect++;
                    lblword.Text = words[rndm.Next(0, words.Length)];
                    textBox1.Text = null;
                }
                lblright.Text = "Correct: " + correct;
                lblwrong.Text = "Inorrect: " + incorrect;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            _ticks--;
            label3.Text = _ticks.ToString();
            if (_ticks == 0)
            {
                lblword.Text = "HOTOVO";
                textBox1.Enabled = false;
                this.Text = "HOTOVO";
                timer1.Stop();

                double výsledek = correct + incorrect;
                double výsledek2 = (100 / výsledek )  * correct;
                label6.Text = výsledek2.ToString() + "%";
            }

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            timer1.Start();
        }
    }
}
