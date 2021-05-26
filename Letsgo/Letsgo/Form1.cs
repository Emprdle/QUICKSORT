using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Letsgo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.BackgroundImage = Properties.Resources.FINALE;
            BÍLÝ.Enabled = false;
            button2.Enabled = false;
        }

        string[] strSplitX;
        string[] strSplitY;

        private void Kontrola(string a)
        {
            string textbox = ČERNÝ.Text;
            strSplitX = new string[3];
            string str = textbox;
            strSplitX = str.Split('X', 'Y');
            listBox1.Items.Add(strSplitX[1] + "." + strSplitX[2] + "/"); 
            //MessageBox.Show();
            string SOURADNICE = "X" + (Convert.ToInt32(strSplitX[1]) +1) + "Y" + (Convert.ToInt32(strSplitX[2]));
           // string SOURADNICE1 = "X" + (Convert.ToInt32(strSplitX[1]) -1) + "Y" + (Convert.ToInt32(strSplitX[2]));
            listBox1.Items.Add(SOURADNICE);
            //listBox1.Items.Add(SOURADNICE1);

            try
            {
                Control Verný = this.Controls.Find(SOURADNICE, true)[0];
                //Control Verný1 = this.Controls.Find(SOURADNICE1, true)[0];
                if (a == textbox && Verný.BackgroundImage == Properties.Resources.BLACK)
                { 
                    label3.Text += "We did it";
                }
            }
            catch (Exception e)
            {
                //listBox1.Items.Add();
                listBox1.Items.Add(e.Message);
                label3.Text += ".";
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool Y = false;
            bool F = false;
            foreach (Control item in this.Controls)
            {
                string Prom = ČERNÝ.Text;
                if (item is PictureBox)
                {
                    if (item.Name == Prom)
                    {
                        if (item.BackgroundImage != null)
                        {
                            MessageBox.Show("NEMŮŽEŠ NA POLE VLOŽIT DALŠÍ POSTAVU KDYŽ UŽ TAM JE");
                        }
                        else
                        {
                            Y = true;
                            item.Visible = true;
                            item.BackgroundImage = Properties.Resources.BLACK;
                            item.Enabled = false;
                            Kontrola(item.Name);
                        }
                    }
                }
                
            }
            if (!Y)
            {
                MessageBox.Show("Není validní souřadnice");
                ČERNÝ.Clear();
                ČERNÝ.Enabled = true;
            }
            else
            {
                ČERNÝ.Clear();
                ČERNÝ.Enabled = false;
                button1.Enabled = false;
                BÍLÝ.Enabled = true;
                button2.Enabled = true;
            }
            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            strSplitY = new string[2];
            bool Y = false;
            foreach (Control item in this.Controls)
            {
                string Prom = BÍLÝ.Text;
                if (item is PictureBox)
                {
                    if(item.Name == Prom)
                    {
                        string str = Prom;
                        strSplitY = str.Split('X', 'Y');
                        if (item.BackgroundImage != null)
                        {
                            MessageBox.Show("NEMŮŽEŠ NA POLE VLOŽIT DALŠÍ POSTAVU KDYŽ UŽ TAM JE");
                        }
                        else
                        {
                            Y = true;
                            item.Visible = true;
                            item.BackgroundImage = Properties.Resources.WHITE;
                            item.Enabled = false;
                        }
                    }
                }
            }
            if (!Y)
            {
                MessageBox.Show("Není validní souřadnice");
                BÍLÝ.Clear();
                BÍLÝ.Enabled = true;
            }
            else
            {
                BÍLÝ.Clear();
                BÍLÝ.Enabled = false;
                button2.Enabled = false;
                ČERNÝ.Enabled = true;
                button1.Enabled = true;
            }

        }
    }
}
