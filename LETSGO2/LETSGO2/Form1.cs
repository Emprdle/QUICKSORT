using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LETSGO2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.BackgroundImage = Properties.Resources.FINALE;
            label1.Text = "Body: ";
            label2.Text = "Body: ";
            label5.Text = "Pokusy: " + pokusy1;
            label6.Text = "Pokusy: " + pokusy2;
        }
       
        int body = 0;
        int body1 = 0;
        int pokusy1 = 20;
        int pokusy2 = 20;
        bool X = false;
        string[] strSplitX;
        PictureBox[,] template = new PictureBox[9, 9];

        private void temp_click(object sender, EventArgs e)
        {
            if (pokusy1 == 0 && pokusy2 == 0)
            {
                if (body > body1)
                {
                    MessageBox.Show("VYHRÁL ČERNÝ");
                    Application.Exit();
                    
                }
                if (body < body1)
                {
                    MessageBox.Show("VYHRÁL BÍLÝ");
                    Application.Exit();
                }
                if (body == body1)
                {
                    MessageBox.Show("REMÍZA");
                    Application.Exit();
                }
            }
            PictureBox a = (PictureBox)sender;
            if (a.BackColor == Color.Transparent)
            {
                strSplitX = new string[3];
                string str = a.Name;
                strSplitX = str.Split('X', 'Y');
                //souradnice pravo-------------------------------------------------------------------------------------------------------------

                Control RICHTER = null;
                string R = "X" + (Convert.ToInt32(strSplitX[1])) + "Y" + (Convert.ToInt32(strSplitX[2]));
                if (!(R.Contains("10")) && !(R.Contains("9")) && !(R.Contains("-")))
                {
                    RICHTER = this.Controls.Find(R, true)[0];
                }

                Control PRAVO = null;
                Control PPRAVO = null;
                Control PPRAVOHORE = null;
                Control PPRAVODOLE = null;
                string SOURADNICEP = "X" + (Convert.ToInt32(strSplitX[1]) + 1) + "Y" + (Convert.ToInt32(strSplitX[2]));
                string SOURADNICEPP = "X" + (Convert.ToInt32(strSplitX[1]) + 2) + "Y" + (Convert.ToInt32(strSplitX[2]));
                string SOURADNICEPPHORE = "X" + (Convert.ToInt32(strSplitX[1]) + 1) + "Y" + (Convert.ToInt32(strSplitX[2]) - 1);
                string SOURADNICEPPDOLE = "X" + (Convert.ToInt32(strSplitX[1]) + 1) + "Y" + (Convert.ToInt32(strSplitX[2]) + 1);

                if (!(SOURADNICEP.Contains("9")))
                {
                    PRAVO = this.Controls.Find(SOURADNICEP, true)[0];
                }
                if (!(SOURADNICEPP.Contains("9")) && !(SOURADNICEPP.Contains("10")))
                {
                    PPRAVO = this.Controls.Find(SOURADNICEPP, true)[0];
                }
                if (!(SOURADNICEPPHORE.Contains("9")) && !(SOURADNICEPPHORE.Contains("-")))
                {
                    PPRAVOHORE = this.Controls.Find(SOURADNICEPPHORE, true)[0];
                }
                if (!(SOURADNICEPPDOLE.Contains("9")))
                {
                    PPRAVODOLE = this.Controls.Find(SOURADNICEPPDOLE, true)[0];
                }
                //souradnice vlevo-------------------------------------------------------------------------------------------------------------
                Control LEVO = null;
                Control LLEVO = null;
                Control LLEVOHORE = null;
                Control LLEVODOLE = null;
                string SOURADNICEL = "X" + (Convert.ToInt32(strSplitX[1]) - 1) + "Y" + (Convert.ToInt32(strSplitX[2]));
                string SOURADNICELL = "X" + (Convert.ToInt32(strSplitX[1]) - 2) + "Y" + (Convert.ToInt32(strSplitX[2]));
                string SOURADNICELLHORE = "X" + (Convert.ToInt32(strSplitX[1]) - 1) + "Y" + (Convert.ToInt32(strSplitX[2]) - 1);
                string SOURADNICELLDOLE = "X" + (Convert.ToInt32(strSplitX[1]) - 1) + "Y" + (Convert.ToInt32(strSplitX[2]) + 1);
                if (!(SOURADNICEL.Contains("-")))
                {
                    LEVO = this.Controls.Find(SOURADNICEL, true)[0];
                }
                if (!(SOURADNICELL.Contains("-")))
                {
                    LLEVO = this.Controls.Find(SOURADNICELL, true)[0];
                }
                if (!(SOURADNICELLHORE.Contains("-")))
                {
                    LLEVOHORE = this.Controls.Find(SOURADNICELLHORE, true)[0];
                }
                if (!(SOURADNICELLDOLE.Contains("-")) && !(SOURADNICELLDOLE.Contains("9")))
                {
                    LLEVODOLE = this.Controls.Find(SOURADNICELLDOLE, true)[0];
                }

                //souradnice hore-------------------------------------------------------------------------------------------------------------

                Control HORE = null;
                Control HHORE = null;
                Control HHOREDOLE = null;
                Control HHOREHORE = null;
                string SOURADNICEH = "X" + (Convert.ToInt32(strSplitX[1])) + "Y" + (Convert.ToInt32(strSplitX[2]) + 1);
                string SOURADNICEHH = "X" + (Convert.ToInt32(strSplitX[1])) + "Y" + (Convert.ToInt32(strSplitX[2]) + 2);
                string SOURADNICEHHHORE = "X" + (Convert.ToInt32(strSplitX[1]) - 1) + "Y" + (Convert.ToInt32(strSplitX[2]) + 1);
                string SOURADNICEHHDOLE = "X" + (Convert.ToInt32(strSplitX[1]) + 1) + "Y" + (Convert.ToInt32(strSplitX[2]) + 1);
                if (!(SOURADNICEH.Contains("9")))
                {
                    HORE = this.Controls.Find(SOURADNICEH, true)[0];
                }
                if (!(SOURADNICEHH.Contains("9")) && !(SOURADNICEHH.Contains("9")) && !(SOURADNICEHH.Contains("10")))
                {
                    HHORE = this.Controls.Find(SOURADNICEHH, true)[0];
                }
                if (!(SOURADNICEHHDOLE.Contains("-")) && !(SOURADNICEHHDOLE.Contains("9")) && !(SOURADNICEHHDOLE.Contains("10")))
                {
                    HHOREDOLE = this.Controls.Find(SOURADNICEHHDOLE, true)[0];
                }
                if (!(SOURADNICEHHHORE.Contains("-")) && !(SOURADNICEHHHORE.Contains("9")) && !(SOURADNICEHHHORE.Contains("10")))
                {
                    HHOREHORE = this.Controls.Find(SOURADNICEHHHORE, true)[0];
                }

                //souradnice dole-------------------------------------------------------------------------------------------------------------
                Control DOLE = null;
                Control DDOLE = null;
                Control DDOLEHORE = null;
                Control DDOLEDOLE = null;
                string SOURADNICED = "X" + (Convert.ToInt32(strSplitX[1])) + "Y" + (Convert.ToInt32(strSplitX[2]) - 1);
                string SOURADNICEDD = "X" + (Convert.ToInt32(strSplitX[1])) + "Y" + (Convert.ToInt32(strSplitX[2]) - 2);
                string SOURADNICEDDHORE = "X" + (Convert.ToInt32(strSplitX[1]) - 1) + "Y" + (Convert.ToInt32(strSplitX[2]) - 1);
                string SOURADNICEDDDOLE = "X" + (Convert.ToInt32(strSplitX[1]) + 1) + "Y" + (Convert.ToInt32(strSplitX[2]) - 1);

                if (!(SOURADNICED.Contains("-")))
                {
                    DOLE = this.Controls.Find(SOURADNICED, true)[0];
                }
                if (!(SOURADNICEDD.Contains("-")))
                {
                    DDOLE = this.Controls.Find(SOURADNICEDD, true)[0];
                }
                if (!(SOURADNICEDDHORE.Contains("-")))
                {
                    DDOLEHORE = this.Controls.Find(SOURADNICEDDHORE, true)[0];
                }
                if (!(SOURADNICEDDDOLE.Contains("-")) && !(SOURADNICEDDDOLE.Contains("9")))
                {
                    DDOLEDOLE = this.Controls.Find(SOURADNICEDDDOLE, true)[0];
                }

                if (X)
                {
                    a.BackColor = Color.White;
                }
                else
                {
                    a.BackColor = Color.Black;
                }
                X = !X;

                string A1 = "X" + (0) + "Y" + (0);
                string A2 = "X" + (0) + "Y" + (1);
                string A3 = "X" + (0) + "Y" + (1);
                Control AA1 = this.Controls.Find(A1, true)[0];
                Control AA2 = this.Controls.Find(A2, true)[0];
                Control AA3 = this.Controls.Find(A3, true)[0];
                string B1 = "X" + (8) + "Y" + (0);
                string B2 = "X" + (7) + "Y" + (0);
                string B3 = "X" + (8) + "Y" + (1);
                Control BB1 = this.Controls.Find(B1, true)[0];
                Control BB2 = this.Controls.Find(B2, true)[0];
                Control BB3 = this.Controls.Find(B3, true)[0];
                string C1 = "X" + (0) + "Y" + (8);
                string C2 = "X" + (0) + "Y" + (7);
                string C3 = "X" + (1) + "Y" + (8);
                Control CC1 = this.Controls.Find(C1, true)[0];
                Control CC2 = this.Controls.Find(C2, true)[0];
                Control CC3 = this.Controls.Find(C3, true)[0];
                string D1 = "X" + (8) + "Y" + (8);
                string D2 = "X" + (8) + "Y" + (7);
                string D3 = "X" + (7) + "Y" + (8);
                Control DD1 = this.Controls.Find(D1, true)[0];
                Control DD2 = this.Controls.Find(D2, true)[0];
                Control DD3 = this.Controls.Find(D3, true)[0];


                if (a.BackColor == Color.White)
                {
                    pokusy2--;
                    label6.Text = "Pokusy: " + pokusy2;
                    if (PRAVO != null && DOLE != null && HORE != null && LEVO != null)
                    {
                        if (DOLE.BackColor == Color.Black && HORE.BackColor == Color.Black && LEVO.BackColor == Color.Black && PRAVO.BackColor == Color.Black)
                        {
                            RICHTER.BackColor = Color.Transparent;
                            MessageBox.Show("Sebevražda není povolena brácho");
                        }
                    }
                    if (PRAVO != null && HORE != null && LEVO != null)
                    {
                        if (LEVO.Name.Contains("X0Y0") || LEVO.Name.Contains("X1Y0") || LEVO.Name.Contains("X2Y0") || LEVO.Name.Contains("X3Y0") || LEVO.Name.Contains("X4Y0") || LEVO.Name.Contains("X5Y0") || LEVO.Name.Contains("X6Y0") || LEVO.Name.Contains("X7Y0"))
                        {
                            if (LEVO.BackColor == Color.Black && PRAVO.BackColor == Color.Black && HORE.BackColor == Color.Black)
                            {
                                RICHTER.BackColor = Color.Transparent;
                                MessageBox.Show("Sebevražda není povolena brácho");
                            }
                        }
                    }
                    if (PRAVO != null && DOLE != null && LEVO != null)
                    {
                        if (LEVO.Name.Contains("X0Y8") || LEVO.Name.Contains("X1Y8") || LEVO.Name.Contains("X2Y8") || LEVO.Name.Contains("X3Y8") || LEVO.Name.Contains("X4Y8") || LEVO.Name.Contains("X5Y8") || LEVO.Name.Contains("X6Y8") || LEVO.Name.Contains("X7Y8"))
                        {
                            if (LEVO.BackColor == Color.Black && PRAVO.BackColor == Color.Black && DOLE.BackColor == Color.Black)
                            {
                                RICHTER.BackColor = Color.Transparent;
                                MessageBox.Show("Sebevražda není povolena brácho");
                            }
                        }
                    }
                    if (PRAVO != null && DOLE != null && HORE != null)
                    {
                        if (HORE.Name.Contains("X0Y0") || HORE.Name.Contains("X0Y1") || HORE.Name.Contains("X0Y2") || HORE.Name.Contains("X0Y3") || HORE.Name.Contains("X0Y4") || HORE.Name.Contains("X0Y5") || HORE.Name.Contains("X0Y6") || HORE.Name.Contains("X0Y7"))
                        {
                            if (HORE.BackColor == Color.Black && PRAVO.BackColor == Color.Black && DOLE.BackColor == Color.Black)
                            {
                                RICHTER.BackColor = Color.Transparent;
                                MessageBox.Show("Sebevražda není povolena brácho");
                            }
                        }
                    }
                    if (LEVO != null && DOLE != null && HORE != null)
                    {
                        if (HORE.Name.Contains("X8Y0") || HORE.Name.Contains("X8Y1") || HORE.Name.Contains("X8Y2") || HORE.Name.Contains("X8Y3") || HORE.Name.Contains("X8Y4") || HORE.Name.Contains("X8Y5") || HORE.Name.Contains("X8Y6") || HORE.Name.Contains("X8Y7"))
                        {
                            if (HORE.BackColor == Color.Black && LEVO.BackColor == Color.Black && DOLE.BackColor == Color.Black)
                            {
                                RICHTER.BackColor = Color.Transparent;
                                MessageBox.Show("Sebevražda není povolena brácho");
                            }
                        }
                    }



                    for (int x = 1; x <= 7; x++)
                    {
                        string xx = "X" + (x) + "Y" + (0);
                        string xx1 = "X" + (x) + "Y" + (1);
                        string xx2 = "X" + (x + 1) + "Y" + (0);
                        string xx3 = "X" + (x - 1) + "Y" + (0);
                        Control X = this.Controls.Find(xx, true)[0];
                        Control X1 = this.Controls.Find(xx1, true)[0];
                        Control X2 = this.Controls.Find(xx2, true)[0];
                        Control X3 = this.Controls.Find(xx3, true)[0];
                        if (X.BackColor == Color.Black)
                        {
                            if (X1.BackColor == Color.White && X2.BackColor == Color.White && X3.BackColor == Color.White)
                            {
                                X.BackColor = Color.Transparent;
                                body1++;
                                label2.Text = "Body: " + body1;
                            }
                        }
                    }
                    for (int x = 1; x <= 7; x++)
                    {
                        string xx = "X" + (x) + "Y" + (8);
                        string xx1 = "X" + (x) + "Y" + (7);
                        string xx2 = "X" + (x + 1) + "Y" + (8);
                        string xx3 = "X" + (x - 1) + "Y" + (8);
                        Control X = this.Controls.Find(xx, true)[0];
                        Control X1 = this.Controls.Find(xx1, true)[0];
                        Control X2 = this.Controls.Find(xx2, true)[0];
                        Control X3 = this.Controls.Find(xx3, true)[0];
                        if (X.BackColor == Color.Black)
                        {
                            if (X1.BackColor == Color.White && X2.BackColor == Color.White && X3.BackColor == Color.White)
                            {
                                X.BackColor = Color.Transparent;
                                body1++;
                                label2.Text = "Body: " + body1;
                            }
                        }
                    }
                    for (int y = 1; y <= 7; y++)
                    {
                        string yy = "X" + (0) + "Y" + (y);
                        string yy1 = "X" + (1) + "Y" + (y);
                        string yy2 = "X" + (0) + "Y" + (y + 1);
                        string yy3 = "X" + (0) + "Y" + (y - 1);
                        Control Y = this.Controls.Find(yy, true)[0];
                        Control Y1 = this.Controls.Find(yy1, true)[0];
                        Control Y2 = this.Controls.Find(yy2, true)[0];
                        Control Y3 = this.Controls.Find(yy3, true)[0];
                        if (Y.BackColor == Color.Black)
                        {
                            if (Y1.BackColor == Color.White && Y2.BackColor == Color.White && Y3.BackColor == Color.White)
                            {
                                Y.BackColor = Color.Transparent;
                                body1++;
                                label2.Text = "Body: " + body1;
                            }
                        }
                    }
                    for (int y = 1; y <= 7; y++)
                    {
                        string yy = "X" + (8) + "Y" + (y);
                        string yy1 = "X" + (7) + "Y" + (y);
                        string yy2 = "X" + (8) + "Y" + (y + 1);
                        string yy3 = "X" + (8) + "Y" + (y - 1);
                        Control Y = this.Controls.Find(yy, true)[0];
                        Control Y1 = this.Controls.Find(yy1, true)[0];
                        Control Y2 = this.Controls.Find(yy2, true)[0];
                        Control Y3 = this.Controls.Find(yy3, true)[0];
                        if (Y.BackColor == Color.Black)
                        {
                            if (Y1.BackColor == Color.White && Y2.BackColor == Color.White && Y3.BackColor == Color.White)
                            {
                                Y.BackColor = Color.Transparent;
                                body1++;
                                label2.Text = "Body: " + body1;
                            }
                        }
                    }

                    if(RICHTER.Name.Contains("X0Y0"))
                    {
                        if (AA2.BackColor == Color.Black && AA3.BackColor == Color.Black)
                        {
                            RICHTER.BackColor = Color.Transparent;
                            MessageBox.Show("Sebevražda není povolena brácho");
                        }
                    }
                    if (RICHTER.Name.Contains("X8Y0"))
                    {
                        if (BB2.BackColor == Color.Black && BB3.BackColor == Color.Black)
                        {
                            RICHTER.BackColor = Color.Transparent;
                            MessageBox.Show("Sebevražda není povolena brácho");
                        }
                    }
                    if (RICHTER.Name.Contains("X0Y8"))
                    {
                        if (CC2.BackColor == Color.Black && CC3.BackColor == Color.Black)
                        {
                            RICHTER.BackColor = Color.Transparent;
                            MessageBox.Show("Sebevražda není povolena brácho");
                        }
                    }
                    if (RICHTER.Name.Contains("X8Y8"))
                    {
                        if (DD2.BackColor == Color.Black && DD3.BackColor == Color.Black)
                        {
                            RICHTER.BackColor = Color.Transparent;
                            MessageBox.Show("Sebevražda není povolena brácho");
                        }
                    }

                    if (AA1.BackColor == Color.Black)
                    {
                        if (AA2.BackColor == Color.White && AA3.BackColor == Color.White)
                        {
                            AA1.BackColor = Color.Transparent;
                            body1++;
                            label2.Text = "Body: " + body1;
                        }
                    }

                    if (BB1.BackColor == Color.Black)
                    {
                        if (BB2.BackColor == Color.White && BB3.BackColor == Color.White)
                        {
                            BB1.BackColor = Color.Transparent;
                            body1++;
                            label2.Text = "Body: " + body1;
                        }
                    }

                    if (CC1.BackColor == Color.Black)
                    {
                        if (CC2.BackColor == Color.White && CC3.BackColor == Color.White)
                        {
                            CC1.BackColor = Color.Transparent;
                            body1++;
                            label2.Text = "Body: " + body1;
                        }
                    }

                    if (DD1.BackColor == Color.Black)
                    {
                        if (DD2.BackColor == Color.White && DD3.BackColor == Color.White)
                        {
                            DD1.BackColor = Color.Transparent;
                            body1++;
                            label2.Text = "Body: " + body1;
                        }
                    }

                    if (PRAVO != null && PPRAVO != null && PPRAVOHORE != null && PPRAVODOLE != null)
                    {
                        if (PRAVO.BackColor == Color.Black)
                        {
                            if (PPRAVO.BackColor == Color.White && PPRAVOHORE.BackColor == Color.White && PPRAVODOLE.BackColor == Color.White)
                            {
                                PRAVO.BackColor = Color.Transparent;
                                body1++;
                                label2.Text = "Body: " + body1;
                            }

                        }
                    }

                    if (LEVO != null && LLEVO != null && LLEVOHORE != null && LLEVODOLE != null)
                    {
                        if (LEVO.BackColor == Color.Black)
                        {
                            if (LLEVO.BackColor == Color.White && LLEVOHORE.BackColor == Color.White && LLEVODOLE.BackColor == Color.White)
                            {
                                LEVO.BackColor = Color.Transparent;
                                body1++;
                                label2.Text = "Body: " + body1;
                            }
                        }
                    }

                    if (HORE != null && HHORE != null && HHOREHORE != null && HHOREDOLE != null)
                    {
                        if (HORE.BackColor == Color.Black)
                        {
                            if (HHORE.BackColor == Color.White && HHOREHORE.BackColor == Color.White && HHOREDOLE.BackColor == Color.White)
                            {
                                HORE.BackColor = Color.Transparent;
                                body1++;
                                label2.Text = "Body: " + body1;
                            }
                        }
                    }

                    if (DOLE != null && LLEVO != null && DDOLEHORE != null && DDOLEDOLE != null && DDOLE != null)
                    {
                        if (DOLE.BackColor == Color.Black)
                        {
                            if (DDOLE.BackColor == Color.White && DDOLEHORE.BackColor == Color.White && DDOLEDOLE.BackColor == Color.White)
                            {
                                DOLE.BackColor = Color.Transparent;
                                body1++;
                                label2.Text = "Body: " + body1;
                            }
                        }
                    }

                }
                if (a.BackColor == Color.Black)
                {
                    pokusy1--;
                    label5.Text = "Pokusy: " + pokusy1;
                    if (PRAVO != null && DOLE != null && HORE != null && LEVO != null)
                    {
                        if (DOLE.BackColor == Color.White && HORE.BackColor == Color.White && LEVO.BackColor == Color.White && PRAVO.BackColor == Color.White)
                        {
                            RICHTER.BackColor = Color.Transparent;
                            MessageBox.Show("Sebevražda není povolena brácho");
                        }
                    }
                    if (PRAVO != null && HORE != null && LEVO != null)
                    {
                        if (LEVO.Name.Contains("X0Y0") || LEVO.Name.Contains("X1Y0") || LEVO.Name.Contains("X2Y0") || LEVO.Name.Contains("X3Y0") || LEVO.Name.Contains("X4Y0") || LEVO.Name.Contains("X5Y0") || LEVO.Name.Contains("X6Y0") || LEVO.Name.Contains("X7Y0"))
                        {
                            if (LEVO.BackColor == Color.White && PRAVO.BackColor == Color.White && HORE.BackColor == Color.White)
                            {
                                RICHTER.BackColor = Color.Transparent;
                                MessageBox.Show("Sebevražda není povolena brácho");
                            }
                        }
                    }
                    if (PRAVO != null && DOLE != null && LEVO != null)
                    {
                        if (LEVO.Name.Contains("X0Y8") || LEVO.Name.Contains("X1Y8") || LEVO.Name.Contains("X2Y8") || LEVO.Name.Contains("X3Y8") || LEVO.Name.Contains("X4Y8") || LEVO.Name.Contains("X5Y8") || LEVO.Name.Contains("X6Y8") || LEVO.Name.Contains("X7Y8"))
                        {
                            if (LEVO.BackColor == Color.White && PRAVO.BackColor == Color.White && DOLE.BackColor == Color.White)
                            {
                                RICHTER.BackColor = Color.Transparent;
                                MessageBox.Show("Sebevražda není povolena brácho");
                            }
                        }
                    }
                    if (PRAVO != null && DOLE != null && HORE != null)
                    {
                        if (HORE.Name.Contains("X0Y0") || HORE.Name.Contains("X0Y1") || HORE.Name.Contains("X0Y2") || HORE.Name.Contains("X0Y3") || HORE.Name.Contains("X0Y4") || HORE.Name.Contains("X0Y5") || HORE.Name.Contains("X0Y6") || HORE.Name.Contains("X0Y7"))
                        {
                            if (HORE.BackColor == Color.White && PRAVO.BackColor == Color.White && DOLE.BackColor == Color.White)
                            {
                                RICHTER.BackColor = Color.Transparent;
                                MessageBox.Show("Sebevražda není povolena brácho");
                            }
                        }
                    }
                    if (LEVO != null && DOLE != null && HORE != null)
                    {
                        if (HORE.Name.Contains("X8Y0") || HORE.Name.Contains("X8Y1") || HORE.Name.Contains("X8Y2") || HORE.Name.Contains("X8Y3") || HORE.Name.Contains("X8Y4") || HORE.Name.Contains("X8Y5") || HORE.Name.Contains("X8Y6") || HORE.Name.Contains("X8Y7"))
                        {
                            if (HORE.BackColor == Color.White && LEVO.BackColor == Color.White && DOLE.BackColor == Color.White)
                            {
                                RICHTER.BackColor = Color.Transparent;
                                MessageBox.Show("Sebevražda není povolena brácho");
                            }
                        }
                    }
                    for (int x = 1; x <= 7; x++)
                    {
                        string xx = "X" + (x) + "Y" + (0);
                        string xx1 = "X" + (x) + "Y" + (1);
                        string xx2 = "X" + (x + 1) + "Y" + (0);
                        string xx3 = "X" + (x - 1) + "Y" + (0);
                        Control X = this.Controls.Find(xx, true)[0];
                        Control X1 = this.Controls.Find(xx1, true)[0];
                        Control X2 = this.Controls.Find(xx2, true)[0];
                        Control X3 = this.Controls.Find(xx3, true)[0];
                        if (X.BackColor == Color.White)
                        {
                            if (X1.BackColor == Color.Black && X2.BackColor == Color.Black && X3.BackColor == Color.Black)
                            {
                                X.BackColor = Color.Transparent;
                                body++;
                                label1.Text = "Body: " + body;
                            }
                        }
                    }
                    for (int x = 1; x <= 7; x++)
                    {
                        string xx = "X" + (x) + "Y" + (8);
                        string xx1 = "X" + (x) + "Y" + (7);
                        string xx2 = "X" + (x + 1) + "Y" + (8);
                        string xx3 = "X" + (x - 1) + "Y" + (8);
                        Control X = this.Controls.Find(xx, true)[0];
                        Control X1 = this.Controls.Find(xx1, true)[0];
                        Control X2 = this.Controls.Find(xx2, true)[0];
                        Control X3 = this.Controls.Find(xx3, true)[0];
                        if (X.BackColor == Color.White)
                        {
                            if (X1.BackColor == Color.Black && X2.BackColor == Color.Black && X3.BackColor == Color.Black)
                            {
                                X.BackColor = Color.Transparent;
                                body++;
                                label1.Text = "Body: " + body;
                            }
                        }
                    }
                    for (int y = 1; y <= 7; y++)
                    {
                        string yy = "X" + (0) + "Y" + (y);
                        string yy1 = "X" + (1) + "Y" + (y);
                        string yy2 = "X" + (0) + "Y" + (y + 1);
                        string yy3 = "X" + (0) + "Y" + (y - 1);
                        Control Y = this.Controls.Find(yy, true)[0];
                        Control Y1 = this.Controls.Find(yy1, true)[0];
                        Control Y2 = this.Controls.Find(yy2, true)[0];
                        Control Y3 = this.Controls.Find(yy3, true)[0];
                        if (Y.BackColor == Color.White)
                        {
                            if (Y1.BackColor == Color.Black && Y2.BackColor == Color.Black && Y3.BackColor == Color.Black)
                            {
                                Y.BackColor = Color.Transparent;
                                body++;
                                label1.Text = "Body: " + body;
                            }
                        }
                    }
                    for (int y = 1; y <= 7; y++)
                    {
                        string yy = "X" + (8) + "Y" + (y);
                        string yy1 = "X" + (7) + "Y" + (y);
                        string yy2 = "X" + (8) + "Y" + (y + 1);
                        string yy3 = "X" + (8) + "Y" + (y - 1);
                        Control Y = this.Controls.Find(yy, true)[0];
                        Control Y1 = this.Controls.Find(yy1, true)[0];
                        Control Y2 = this.Controls.Find(yy2, true)[0];
                        Control Y3 = this.Controls.Find(yy3, true)[0];
                        if (Y.BackColor == Color.White)
                        {
                            if (Y1.BackColor == Color.Black && Y2.BackColor == Color.Black && Y3.BackColor == Color.Black)
                            {
                                Y.BackColor = Color.Transparent;
                                body++;
                                label1.Text = "Body: " + body;
                            }
                        }
                    }

                    if (RICHTER.Name.Contains("X0Y0"))
                    {
                        if (AA2.BackColor == Color.White && AA3.BackColor == Color.White)
                        {
                            RICHTER.BackColor = Color.Transparent;
                            MessageBox.Show("Sebevražda není povolena brácho");
                        }
                    }
                    if (RICHTER.Name.Contains("X8Y0"))
                    {
                        if (BB2.BackColor == Color.White && BB3.BackColor == Color.White)
                        {
                            RICHTER.BackColor = Color.Transparent;
                            MessageBox.Show("Sebevražda není povolena brácho");
                        }
                    }
                    if (RICHTER.Name.Contains("X0Y8"))
                    {
                        if (CC2.BackColor == Color.White && CC3.BackColor == Color.White)
                        {
                            RICHTER.BackColor = Color.Transparent;
                            MessageBox.Show("Sebevražda není povolena brácho");
                        }
                    }
                    if (RICHTER.Name.Contains("X8Y8"))
                    {
                        if (DD2.BackColor == Color.White && DD3.BackColor == Color.White)
                        {
                            RICHTER.BackColor = Color.Transparent;
                            MessageBox.Show("Sebevražda není povolena brácho");
                        }
                    }

                    if (AA1.BackColor == Color.White)
                    {
                        if (AA2.BackColor == Color.Black && AA3.BackColor == Color.Black)
                        {
                            AA1.BackColor = Color.Transparent;
                            body++;
                            label1.Text = "Body: " + body;
                        }
                    }

                    if (BB1.BackColor == Color.White)
                    {
                        if (BB2.BackColor == Color.Black && BB3.BackColor == Color.Black)
                        {
                            BB1.BackColor = Color.Transparent;
                            body++;
                            label1.Text = "Body: " + body;
                        }
                    }

                    if (CC1.BackColor == Color.White)
                    {
                        if (CC2.BackColor == Color.Black && CC3.BackColor == Color.Black)
                        {
                            CC1.BackColor = Color.Transparent;
                            body++;
                            label1.Text = "Body: " + body;
                        }
                    }

                    if (DD1.BackColor == Color.White)
                    {
                        if (DD2.BackColor == Color.Black && DD3.BackColor == Color.Black)
                        {
                            DD1.BackColor = Color.Transparent;
                            body++;
                            label1.Text = "Body: " + body;
                        }
                    }

                    if (PRAVO != null && PPRAVO != null && PPRAVOHORE != null && PPRAVODOLE != null )
                    {
                        if (PRAVO.BackColor == Color.White)
                        {
                            if (PPRAVO.BackColor == Color.Black && PPRAVOHORE.BackColor == Color.Black && PPRAVODOLE.BackColor == Color.Black)
                            {
                                PRAVO.BackColor = Color.Transparent;
                                body++;
                                label1.Text = "Body: " + body;
                            }
                            
                        }
                    }
                    
                    if (LEVO != null && LLEVO != null && LLEVOHORE != null && LLEVODOLE != null )
                    {
                        if (LEVO.BackColor == Color.White)
                        {
                            if (LLEVO.BackColor == Color.Black && LLEVOHORE.BackColor == Color.Black && LLEVODOLE.BackColor == Color.Black)
                            {
                                LEVO.BackColor = Color.Transparent;
                                body++;
                                label1.Text = "Body: " + body;
                            }
                        }
                    }
                    
                    if (HORE != null && HHORE != null && HHOREHORE != null && HHOREDOLE != null )
                    {
                        if (HORE.BackColor == Color.White)
                        {
                            if (HHORE.BackColor == Color.Black && HHOREHORE.BackColor == Color.Black && HHOREDOLE.BackColor == Color.Black)
                            {
                                HORE.BackColor = Color.Transparent;
                                body++;
                                label1.Text = "Body: " + body;
                            }
                        }
                    }
                    
                    if (DOLE != null && LLEVO != null && DDOLEHORE != null && DDOLEDOLE != null && DDOLE!= null)
                    {
                        if (DOLE.BackColor == Color.White)
                        {
                            if (DDOLE.BackColor == Color.Black && DDOLEHORE.BackColor == Color.Black && DDOLEDOLE.BackColor == Color.Black)
                            {
                                DOLE.BackColor = Color.Transparent;
                                body++;
                                label1.Text = "Body: " + body;
                            }
                        }
                    }
                    
                }
                
            }
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < template.GetLength(0); i++)
            {
                for (int k = 0; k < template.GetLength(1); k++)
                {
                    var temp = new PictureBox();
                    temp.Name = "X" + i + "Y" + k;
                    temp.BackColor = Color.Transparent;
                    temp.Text = i.ToString();
                    temp.Size = new Size(30, 30);
                    temp.Location = new Point(70 +  i * 55, 55 + k * 55);
                    template[i, k] = temp;
                    temp.Click += new EventHandler(temp_click);
                }
            }
            for (int i = 0; i < template.GetLength(0); i++)
            {
                for (int k = 0; k < template.GetLength(1); k++)
                {
                    this.Controls.Add(template[i, k]);
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
