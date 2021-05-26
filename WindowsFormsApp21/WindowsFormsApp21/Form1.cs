using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp21
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Random rndm = new Random();
            int[] arrays = { 5, 7, 9, 1, 4, 7, 6, 2, 3, 4 };
            Boolean B;
            //int pivot = rndm.Next(1,9);
            int R = arrays[0];

            do
            {
                B = false;
                for (int x = 0; x < arrays.Length - 1; x++)
                {
                    if(x <  R )
                    {
                        int temp = arrays[x];
                        arrays[x] = arrays[R + 1];
                        arrays[R + 1] = temp;
                        B = true;
                    }
                }
                MessageBox.Show(Convert.ToString(arrays[0]) + Convert.ToString(arrays[1]) + Convert.ToString(arrays[2]) + Convert.ToString(arrays[3]) + Convert.ToString(arrays[4]) + Convert.ToString(arrays[5]) + Convert.ToString(arrays[6]) + Convert.ToString(arrays[7]) + Convert.ToString(arrays[8]) + Convert.ToString(arrays[9]));
            } while (B);
            
        }
        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
