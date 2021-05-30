using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Data.SqlClient;
using System.IO;
namespace kasa
{
    public partial class Form1 : Form
    {
        SqlConnection r;
        SQLiteConnection c;

        public Form1()
        {
            InitializeComponent();
            c = new SQLiteConnection();
            c.ConnectionString = "Data Source = database.db";
        }
        SQLiteDataAdapter adpt;
        DataTable datatable;
        int CENA = 0;
        int celkova = 0;
        string[] strSplit;
        string[] strSplitD;
        double Kremrole = 0;
        

        private void Form1_Load(object sender, EventArgs e)
        {
    
            textBox2.Enabled = true;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox1.Text += "|-------------------------------------------------------------------------------------------|" + Environment.NewLine;
            textBox1.Text += "|                                      EMRLE SHOP                              |" + Environment.NewLine;
            textBox1.Text += "|-------------------------------------------------------------------------------------------|" + Environment.NewLine;
            c.Open();
            textBox2.Select();
            SQLiteCommand cmd = new SQLiteCommand(c);
            cmd.CommandText = "CREATE TABLE IF NOT EXISTS tab1(ID INT NOT NULL PRIMARY KEY , Carkod INT NULL, Produkt TEXT NULL, Cena INT NULL, Mnozstvi INT NULL )";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "CREATE TABLE IF NOT EXISTS tab8(ID INTEGER PRIMARY KEY AUTOINCREMENT, IDProduktu INT , Mnozstvi INT NULL, Doba DATEIME NULL )";
            cmd.ExecuteNonQuery();
            //cmd.CommandText = "INSERT INTO tab1 (ID,Carkod,Produkt,Cena,Mnozstvi) VALUES (4, 444444, 'brusle', 2000, 30)";
            //cmd.CommandText = "UPDATE tab1 SET Carkod = 1111111 WHERE ID = 1 ";
            c.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            adpt = new SQLiteDataAdapter("SELECT * FROM tab1", c);
            datatable = new DataTable();
            adpt.Fill(datatable);
            dataGridView1.DataSource = datatable;

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            adpt = new SQLiteDataAdapter("SELECT * FROM tab8", c);
            datatable = new DataTable();
            adpt.Fill(datatable);
            dataGridView1.DataSource = datatable;
        }

       
        private void textBox2_KeyUp(object sender, KeyPressEventArgs e)
        {
            if ( e.KeyChar != 48 && e.KeyChar != 49 && e.KeyChar != 50 && e.KeyChar != 51 && e.KeyChar != 52 && e.KeyChar != 53
                && e.KeyChar != 54 && e.KeyChar != 55 && e.KeyChar != 56 && e.KeyChar != 57 
                && e.KeyChar != 13 && e.KeyChar != 47 && e.KeyChar != 44 && e.KeyChar != 43 && e.KeyChar != 42
                && e.KeyChar != 8)
            {
                e.Handled = true;
            }

            if (e.KeyChar == (char)Keys.Enter)
            {
                
                c = new SQLiteConnection();
                c.ConnectionString = "Data Source = database.db";
                c.Open();
                SQLiteCommand command = new SQLiteCommand("SELECT Cena,Carkod FROM tab1 WHERE Carkod = @ide", c);
                strSplit = new string[2];
                strSplitD = new string[2];
                SQLiteCommand com4;
                SQLiteCommand com5;
                SQLiteCommand com6;
               
                if (textBox2.Text.Contains("*"))
                    {
                    if (textBox2.Text == "*"  )
                    {
                        textBox2.Text = "0";
                    }
                    else
                    { 
                        string str = textBox2.Text;
                            strSplit = str.Split('*');
                            // [0] - kod | [1] - mnozstvi
                            string Q = "SELECT Mnozstvi FROM tab1 WHERE Carkod = " + int.Parse(strSplit[0]);
                            com4 = new SQLiteCommand(Q, c);
                            int count = Convert.ToInt32(com4.ExecuteScalar());

                            string QQ = "SELECT Produkt FROM tab1 WHERE Carkod = " + int.Parse(strSplit[0]);
                            com5 = new SQLiteCommand(QQ, c);

                            string QQQ = "SELECT Cena FROM tab1 WHERE Carkod = " + int.Parse(strSplit[0]);
                            com6 = new SQLiteCommand(QQQ, c);
                        
                            if(count > 0)
                            {
                                if( count >= int.Parse(strSplit[1]))
                                {
                                    command.CommandText = $"UPDATE tab1 SET Mnozstvi = Mnozstvi - {int.Parse(strSplit[1])} WHERE Carkod = {int.Parse(strSplit[0])}";
                                    command.ExecuteNonQuery();
                                    command.CommandText = $"INSERT INTO tab8 (IDProduktu,Mnozstvi,Doba) VALUES ((SELECT ID From tab1 WHERE Carkod = {int.Parse(strSplit[0])}),{int.Parse(strSplit[1])},'" + DateTime.Now + "')";
                                    command.ExecuteNonQuery();
                                    CENA =  (Convert.ToInt32(com6.ExecuteScalar()) * int.Parse(strSplit[1]));
                                    celkova = celkova + CENA;
                                textBox1.Text += "|" + "    " + com5.ExecuteScalar() + "    " + com6.ExecuteScalar() + " KČ/KUS" + "    x" + int.Parse(strSplit[1]) + "    " + CENA + "KČ"+ "        " + "|" + Environment.NewLine;
                                    CENA = 0;
                                }
                                //else textBox1.Text += "0";
                            }
                            else if( count <= 0)
                            {
                                //textBox1.Text += "0";
                            }
                    }
                }   
                else if (textBox2.Text.Contains("/"))
                {
                    if (textBox2.Text == "/")
                    {
                        textBox2.Text = "0";
                    }
                    else
                    {  
                        string strD = textBox2.Text;
                        strSplitD = strD.Split('/');
                        command.CommandText = $"UPDATE tab1 SET Mnozstvi = Mnozstvi + (SELECT Mnozstvi FROM tab8 WHERE ID = {int.Parse(strSplitD[0])}) WHERE ID = (SELECT IDProduktu FROM tab8 WHERE ID = {int.Parse(strSplitD[0])})";
                        command.ExecuteNonQuery();
                        command.CommandText = $"DELETE FROM tab8 WHERE ID = {int.Parse(strSplitD[0])}";
                        command.ExecuteNonQuery();
                    }
                }
                else if (textBox2.Text.Contains("+"))
                {
                    textBox2.Enabled = false;

                    textBox1.Text += "|-------------------------------------------------------------------------------------------|" + Environment.NewLine;
                    textBox1.Text += "CENA CELKEM                   " + celkova + "KČ" + Environment.NewLine;
                    textBox1.Text += "|-------------------------------------------------------------------------------------------|" + Environment.NewLine;
                    textBox3.Enabled = true;
                    textBox3.Focus();
                }
                else
                {
                    string str = textBox2.Text;
                    strSplit = str.Split(' ');
                    if(textBox2.Text.Length == 0)
                    {
                        textBox2.Text = "0";
                    }
                    else
                    {

                    
                    string Q = "SELECT Mnozstvi FROM tab1 WHERE Carkod = " + int.Parse(strSplit[0]);
                    com4 = new SQLiteCommand(Q, c);
                    int count = Convert.ToInt32(com4.ExecuteScalar());

                    string QQ = "SELECT Produkt FROM tab1 WHERE Carkod = " + int.Parse(strSplit[0]);
                    com5 = new SQLiteCommand(QQ, c);

                    string QQQ = "SELECT Cena FROM tab1 WHERE Carkod = " + int.Parse(strSplit[0]);
                    com6 = new SQLiteCommand(QQQ, c);
                    

                    if (count > 0)
                    {
                        command.CommandText = $"UPDATE tab1 SET Mnozstvi = Mnozstvi - 1 WHERE Carkod = {int.Parse(textBox2.Text)}";
                        command.ExecuteNonQuery();
                        command.CommandText = $"INSERT INTO tab8 (IDProduktu,Mnozstvi,Doba) VALUES ((SELECT ID From tab1 WHERE Carkod = {int.Parse(textBox2.Text)}),1,'" + DateTime.Now + "')";
                        command.ExecuteNonQuery();
                        CENA =  (Convert.ToInt32(com6.ExecuteScalar()) * 1);
                        celkova = celkova + CENA;
                        textBox1.Text += "|" + "    " + com5.ExecuteScalar() + "    " + com6.ExecuteScalar() + " KČ/KUS" + "    x"+"1" + "    " + CENA + "KČ" + "        " + "|" + Environment.NewLine;
                        CENA = 0;
                    }
                    }
                }
                textBox2.Clear();

                //--------------------------------------------------------------------------------------------------------------------------------------------
                
                
            }

            if (e.KeyChar == (char)Keys.Add)
            {
                //textBox1.Text += CENA;
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void textBox4_KeyUp(object sender, KeyEventArgs e)
        {
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 43 && e.KeyChar != 8 && e.KeyChar != 13)
            {
                e.Handled = true;
            }

            if (e.KeyChar == (char)Keys.Enter)
            {
                StreamWriter A = new StreamWriter(Application.StartupPath + "\\form\\" + "uctenka.txt");
                A.Write(textBox1.Text);
                A.Close();
            }
            if (textBox4.Text.Contains("+"))
            {
                textBox1.Clear();
                textBox4.Clear();
                textBox2.Enabled = true;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                textBox1.Text += "|-------------------------------------------------------------------------------------------|" + Environment.NewLine;
                textBox1.Text += "|                                      EMRLE SHOP                              |" + Environment.NewLine;
                textBox1.Text += "|-------------------------------------------------------------------------------------------|" + Environment.NewLine;
                textBox2.Focus();
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 48 && e.KeyChar != 49 && e.KeyChar != 50 && e.KeyChar != 51 && e.KeyChar != 52 && e.KeyChar != 53
                && e.KeyChar != 54 && e.KeyChar != 55 && e.KeyChar != 56 && e.KeyChar != 57  
                && e.KeyChar != 13  && e.KeyChar != 44 
                && e.KeyChar != 8)
            {
                e.Handled = true;
            }

            if (e.KeyChar == (char)Keys.Enter)
            {
                if (textBox3.Text.Length == 0)
                {
                    textBox3.Text = "0";
                }

                double DODANI = Convert.ToDouble(textBox3.Text);
                Kremrole += DODANI;
                textBox1.Text += "CELKOVÁ PŘIJATÁ HOTOVOST      " + Kremrole + "KČ" + Environment.NewLine;


                if (celkova > Kremrole)
                {
                    textBox1.Text += "ZBÝVÁ ZAPLATIT     " + (celkova - Kremrole) + "KČ" + Environment.NewLine;
                    //textBox1.Text += Kremrole + Environment.NewLine;
                }
                if (celkova <= Kremrole)
                {
                    textBox1.Text += "|-------------------------------------------------------------------------------------------|" + Environment.NewLine;
                    textBox1.Text += "VRÁCENO                                  " + Math.Round(Kremrole - celkova) + "KČ" + Environment.NewLine;
                    textBox1.Text += "ČAS NÁKUPU                           " + DateTime.Now + Environment.NewLine;
                    textBox1.Text += "|-------------------------------------------------------------------------------------------|" + Environment.NewLine;
                    textBox3.Enabled = false;
                    textBox4.Enabled = true;
                    Kremrole = 0;
                    celkova = 0;
                }
                textBox3.Clear();
                textBox4.Focus();
            }
        }
    }
}
