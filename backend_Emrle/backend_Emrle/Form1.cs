using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;
using System.IO;

namespace backend_Emrle
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //ZOBRAZENÍ DATABÁZE OBJEDNÁVEK
        private void button1_Click(object sender, EventArgs e)
        {
            using (var c = new MySqlConnection("Server=localhost;User ID=root;Password=;Database=backend"))
            {
                c.Open();
                MySqlCommand cmm = c.CreateCommand();
                cmm.CommandType = CommandType.Text;
                cmm.CommandText = "SELECT * FROM objednane";
                DataTable data = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmm);
                adapter.Fill(data);
                dataGridView1.DataSource = data;
                c.Close();
            }
        }
        //ZOBRAZENÍ DATABÁZE SLUŽEB
        private void button6_Click(object sender, EventArgs e)
        {
            using (var c = new MySqlConnection("Server=localhost;User ID=root;Password=;Database=backend"))
            {
                c.Open();
                MySqlCommand cmm = c.CreateCommand();
                cmm.CommandType = CommandType.Text;
                cmm.CommandText = "SELECT * FROM zvirata"; 
                cmm.ExecuteNonQuery();
                DataTable data = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmm);
                adapter.Fill(data);
                dataGridView1.DataSource = data;
                c.Close();
            }
        }
        //ZOBRAZENÍ DATABÁZE FAKTUR
        private void button7_Click(object sender, EventArgs e)
        {
            using (var c = new MySqlConnection("Server=localhost;User ID=root;Password=;Database=backend"))
            {
                c.Open();
                MySqlCommand cmm = c.CreateCommand();
                cmm.CommandType = CommandType.Text;
                cmm.CommandText = "SELECT * FROM faktura"; ;
                cmm.ExecuteNonQuery();
                DataTable data = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmm);
                adapter.Fill(data);
                dataGridView1.DataSource = data;
                c.Close();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
            string hodnota = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox1.Text = hodnota;
            }
            catch
            {
            }
        }
        //POTVRZENÍ OBJEDNÁVKY
        private void button2_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "")
            {
                string message = "Zadejte id objednávky";
                MessageBox.Show(message);
            }
            else
            {

                using (var connection = new MySqlConnection("Server=localhost;User ID=root;Password=;Database=backend"))
                {
                    string F = "SELECT Faktura FROM objednane WHERE id = " + textBox1.Text;
                    connection.Open();
                    MySqlCommand commandd8 = new MySqlCommand(F, connection);
                    F = commandd8.ExecuteScalar().ToString();
                    connection.Close();

                    string Q = "SELECT Stav FROM objednane WHERE id = " + textBox1.Text;
                    connection.Open();
                    MySqlCommand commandd = new MySqlCommand(Q, connection);
                    Q = commandd.ExecuteScalar().ToString();
                    connection.Close();

                    if (F == "VYSTAVENA")
                    {
                        string message = "Faktura byla vystavena, není možné potvrdit nebo zrušit objednávku.";
                        MessageBox.Show(message);
                    }

                    else if (Q == "ZAPLACENA")
                    {
                        string message = "Objednávka zaplacena, není nutné jí potvrdit.";
                        MessageBox.Show(message);
                    }
                    else
                    {
                        connection.Open();
                        MySqlCommand command = connection.CreateCommand();
                        command.CommandType = CommandType.Text;
                        command.CommandText = "UPDATE objednane SET Provedení = 'PROVEDENA' WHERE id = " + textBox1.Text;
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                   
                }
            }
        }
        //ZRUŠENÍ OBJEDNÁVKY
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                string message = "Zadejte id objednávky";
                MessageBox.Show(message);
            }
            else
            {
                using (var connection = new MySqlConnection("Server=localhost;User ID=root;Password=;Database=backend"))
                {
                    string Q = "SELECT Stav FROM objednane WHERE id = " + textBox1.Text;
                    connection.Open();
                    MySqlCommand commandd = new MySqlCommand(Q, connection);
                    Q = commandd.ExecuteScalar().ToString();
                    connection.Close();

                    string F = "SELECT Faktura FROM objednane WHERE id = " + textBox1.Text;
                    connection.Open();
                    MySqlCommand commandd8 = new MySqlCommand(F, connection);
                    F = commandd8.ExecuteScalar().ToString();
                    connection.Close();

                    if (F == "VYSTAVENA")
                    {
                        string message = "Faktura byla vystavena, není možné potvrdit nebo zrušit objednávku.";
                        MessageBox.Show(message);
                    }
                    else if (Q == "ZAPLACENA")
                    {
                        string message = "Objednávka zaplacena, není nutné jí rušit.";
                        MessageBox.Show(message);
                    }
                    else
                    {
                        connection.Open();
                        MySqlCommand command = connection.CreateCommand();
                        command.CommandType = CommandType.Text;
                        command.CommandText = "UPDATE objednane SET Provedení = 'ZRUSENA' WHERE id = " + textBox1.Text;
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                    
                }
            }
        }
        //ZAPLACENÍ OBJEDNÁVKY
        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                string message = "Zadejte id objednávky";
                MessageBox.Show(message);
            }
            
            else
            {
                using (var connection = new MySqlConnection("Server=localhost;User ID=root;Password=;Database=backend"))
                {
                    string QQQ = "SELECT Stav FROM objednane WHERE id = " + textBox1.Text;
                    connection.Open();
                    MySqlCommand commandd5 = new MySqlCommand(QQQ, connection);
                    QQQ = commandd5.ExecuteScalar().ToString();
                    connection.Close();

                    string Q =  "SELECT Provedení FROM objednane WHERE id = " + textBox1.Text;
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(Q, connection);
                    Q = command.ExecuteScalar().ToString();
                    connection.Close();

                    string QQ = "SELECT Faktura FROM objednane WHERE id = " + textBox1.Text;
                    connection.Open();
                    MySqlCommand command3 = new MySqlCommand(QQ, connection);
                    Q = command3.ExecuteScalar().ToString();
                    connection.Close();

                    if (QQQ == "ZAPLACENA")
                    {
                        string message = "Objednávka zaplacena, není nutné jí platit znovu.";
                        MessageBox.Show(message);
                    }
                    else if (QQ == "")
                    {
                        string message = "Faktura nebyla vystavena, nemůže být zaplacena";
                        MessageBox.Show(message);
                    }
                    else if (Q == "ZRUSENA")
                    {
                        string message = "Zrušená objednávka nemůže být zaplacena";
                        MessageBox.Show(message);
                    }
                    else if  (Q == "")
                    {
                        string message = "Objednávka nebyla přijata ani zrušena";
                        MessageBox.Show(message);
                    }
                    
                    else
                    {
                            connection.Open();
                            MySqlCommand commandd = connection.CreateCommand();
                            commandd.CommandType = CommandType.Text;
                            commandd.CommandText = "UPDATE objednane SET Stav = 'ZAPLACENA' WHERE id = " + textBox1.Text;
                            commandd.ExecuteNonQuery();
                            connection.Close();
                    }
                }
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 48 && e.KeyChar != 49 && e.KeyChar != 50 && e.KeyChar != 51 && e.KeyChar != 52 && e.KeyChar != 53
               && e.KeyChar != 54 && e.KeyChar != 55 && e.KeyChar != 56 && e.KeyChar != 57
               && e.KeyChar != 13  && e.KeyChar != 43 
               && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
        //VYSTAVENÍ FAKTURY
        private void button4_Click(object sender, EventArgs e)
        {

            using (var connection = new MySqlConnection("Server=localhost;User ID=root;Password=;Database=backend"))
            {
                string Q = "SELECT Provedení FROM objednane WHERE id = " + textBox1.Text;
                connection.Open();
                MySqlCommand commanddd = new MySqlCommand(Q, connection);
                Q = commanddd.ExecuteScalar().ToString();
                connection.Close();

                string QQ = "SELECT Stav FROM objednane WHERE id = " + textBox1.Text;
                connection.Open();
                MySqlCommand commandd4 = new MySqlCommand(QQ, connection);
                QQ = commandd4.ExecuteScalar().ToString();
                connection.Close();

                

                if (QQ == "ZAPLACENA")
                {
                    string message = "Objednávka zaplacena, není nutné jí potvrdit.";
                    MessageBox.Show(message);
                }
                else if (Q == "ZRUSENA")
                {
                    string message = "Zrušená objednávka nemůže mít fakturu";
                    MessageBox.Show(message);
                }
                else if (Q == "")
                {
                    string message = "Objednávka nebyla přijata ani zrušena, nemůže mít fakturu";
                    MessageBox.Show(message);
                }
                
                else
                {

                    connection.Open();
                    MySqlCommand commandd = connection.CreateCommand();
                    commandd.CommandType = CommandType.Text;
                    commandd.CommandText = "UPDATE objednane SET Faktura = 'VYSTAVENA' WHERE id = " + textBox1.Text;
                    commandd.ExecuteNonQuery();
                    connection.Close();

                
                string jmeno = "";
                int cena = 0;
                int nabid_id = 0;
                int idf = 0;
                
                DateTime datum = DateTime.Now;

                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT objednane.id,objednane.jmeno,objednane.datum,objednane.nabid_id,zvirata.cena FROM objednane,zvirata WHERE objednane.id ='" + textBox1.Text + "' ";
                command.ExecuteNonQuery();
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    jmeno = reader.GetString("jmeno");
                    datum = reader.GetDateTime("datum");
                    nabid_id = reader.GetInt32("nabid_id");
                    cena = reader.GetInt32("cena");
                    //idf = reader.GetInt32("idf");
                }
                reader.Close();


                    MySqlCommand c; 
                string query = "INSERT INTO faktura (id_objednavky,jmeno,nabid_id,rezervacedatum) VALUES(@id,@jmeno,@nabid_id,@datum)";
                c = new MySqlCommand(query, connection);
                c.Parameters.AddWithValue("jmeno",jmeno);
                c.Parameters.AddWithValue("datum", datum);
                c.Parameters.AddWithValue("nabid_id", nabid_id);
                c.Parameters.AddWithValue("cena", cena);
                c.Parameters.AddWithValue("id", textBox1.Text);
                //c.Parameters.AddWithValue("idf", idf);
                c.ExecuteNonQuery();

                    string query1 = "SELECT cena FROM zvirata WHERE id =" + nabid_id;
                    MySqlCommand command6 = new MySqlCommand(query1, connection);
                    query1 = command6.ExecuteScalar().ToString();
                    command.CommandText = "UPDATE faktura SET cena =" + Convert.ToInt32(query1) +  " WHERE id_objednavky ="  + Convert.ToInt32(textBox1.Text);
                    command.ExecuteNonQuery();

                    string query2 = "SELECT idf FROM faktura WHERE id_objednavky='" + textBox1.Text + "' ";
                    MySqlCommand command7 = new MySqlCommand(query2, connection);
                    query2 = command7.ExecuteScalar().ToString();


                    string[] lines =
                {
                    "                       FAKTURA TERAPEUTICKÝCH ZVÍŘAT",
                    "                                   EMRLE",
                    "                                číslo faktury " + query2,
                    "----------------------------------------------------------------------------",
                    "   Objednaná služba číslo ." + nabid_id + "  pro uživatele  " + jmeno + "'",
                    "   datum provedení '" + datum +  "        Cena je '" + cena + "' Kč",
                    "----------------------------------------------------------------------------",
                    
                };
                    string docPath = Path.GetFullPath(@"C: \Users\Vlastnik\source\repos\backend_Emrle\faktura");
                    using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "faktura " + query2 + ".txt")))
                    {
                        foreach (string line in lines)
                            outputFile.WriteLine(line);
                    }
                }
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            using (var c = new MySqlConnection("Server=localhost;User ID=root;Password=;Database=backend"))
            {
                c.Open();
                MySqlCommand cmm = c.CreateCommand();
                cmm.CommandType = CommandType.Text;
                //cmm.CommandText = "SELECT * FROM faktura";
                cmm.CommandText = "SELECT * FROM objednane WHERE email ='" + textBox3.Text + "' AND datum >= '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' AND datum <= '" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "'";
                cmm.ExecuteNonQuery();
                DataTable data = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmm);
                adapter.Fill(data);
                dataGridView1.DataSource = data;
                c.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
