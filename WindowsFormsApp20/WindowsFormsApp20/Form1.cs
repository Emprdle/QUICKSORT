using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp20
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int[] RR = { 5, 7, 9, 1, 4, 7, 6, 2, 3, 4 };

        }

        private void Sort(int[] array,int levo, int pravo)
        {
            if(levo < pravo)
            {
                int index = SROVNANI(array,levo,pravo);
                Sort(array,levo,index - 1);
                Sort(array,index + 1,pravo);
            }
        }

        private int SROVNANI(int[] array, int levo, int pravo)
        {
            int pivot = array[pravo];
            int vybrane = levo - 1;

            for (int i = levo; i < pravo; i++)
            {
                if(array[i] <= pivot)
                {
                    vybrane++;
                    int tempp = array[i];
                    array[i] = array[vybrane];
                    array[vybrane] = tempp;
                }
            }
            int temp = array[pravo];
            array[pravo] = array[vybrane + 1];
            array[vybrane + 1] = temp;
            return vybrane + 1;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            int[] RR = { 5, 7, 9, 4, 7, 6, 2, 3, 4 };
            Sort(RR, 0, RR.Length - 1);
            label1.Text = Convert.ToString(RR[0]);
        }
    }
}
