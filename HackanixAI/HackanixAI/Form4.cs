using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HackanixAI
{
    public partial class Form4 : Form
    {
        string doctor_account_id;
        public Form4(string doctor_account_id)
        {
            this.doctor_account_id = doctor_account_id;
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            (new Form1()).Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int body_id_inc = 0;
            string body_id;
            int body_pain_id = 1;
            string doctor_id = null;
            bool ins=true;

            string query0 = "select * from Hack_Health.Doctor where Account_id="+doctor_account_id;
            string connectionString = "datasource=localhost;port=3306;username=root;password=1234";
            MySqlConnection conlevel0 = new MySqlConnection(connectionString);
            MySqlDataAdapter adpt0 = new MySqlDataAdapter();
            MySqlCommand cmd0 = new MySqlCommand(query0, conlevel0);
            conlevel0.Open();
            MySqlDataReader readerL0 = cmd0.ExecuteReader();
            while (readerL0.Read())
            {
                doctor_id = readerL0.GetString("id");
            }

            string query = "select * from Hack_Health.Body_Part";
            MySqlConnection conlevel1 = new MySqlConnection(connectionString);
            MySqlDataAdapter adpt1 = new MySqlDataAdapter();
            MySqlCommand cmd1 = new MySqlCommand(query, conlevel1);
            conlevel1.Open();
            MySqlDataReader readerL1 = cmd1.ExecuteReader();
            while (readerL1.Read())
            {
                ++body_id_inc;
                if ((readerL1.GetString("Part").ToLower()).Equals(textBox1.Text.ToLower()))
                {
                    ins=false;
                    body_id = readerL1.GetString("id");

                    string query2 = "select max(id) from Hack_Health.Pain_Nature";
                    MySqlConnection conlevel2 = new MySqlConnection(connectionString);
                    MySqlDataAdapter adpt2 = new MySqlDataAdapter();
                    MySqlCommand cmd2 = new MySqlCommand(query2, conlevel2);
                    conlevel2.Open();
                    MySqlDataReader readerL2 = cmd2.ExecuteReader();
                    if (readerL2.Read())
                    {
                        try
                        {
                            if (readerL2.GetInt32("max(id)") != 0)
                            {
                                body_pain_id = readerL2.GetInt32("max(id)");
                            }
                        }
                        catch (Exception)
                        {

                            //none
                        }
                    }
                    conlevel2.Close();

                    string query3 = "insert into Hack_Health.Pain_Nature values('" + (++body_pain_id) + "','" + textBox2.Text + "','" + textBox5.Text + "','"+doctor_id+"')";
                    MySqlConnection conlevel3 = new MySqlConnection(connectionString);
                    MySqlCommand cmd3 = new MySqlCommand(query3, conlevel3);
                    conlevel3.Open();
                    cmd3.ExecuteReader();
                    conlevel3.Close();

                    string query4 = "insert into Hack_Health.Body_Part_has_Pain_Nature values('" + body_id + "','" + body_pain_id + "')";
                    MySqlConnection conlevel4 = new MySqlConnection(connectionString);
                    MySqlCommand cmd4 = new MySqlCommand(query4, conlevel4);
                    conlevel4.Open();
                    cmd4.ExecuteReader();
                    conlevel4.Close();
                }
                else
                {
                  
                }
                
            }
            conlevel1.Close();
            if(ins)
            {
                
                string query11 = "insert into Hack_Health.Body_Part values('" + (++body_id_inc) + "','" + textBox1.Text + "')";
                MySqlConnection conlevel11 = new MySqlConnection(connectionString);
                MySqlCommand cmd11 = new MySqlCommand(query11, conlevel11);
                conlevel11.Open();
                cmd11.ExecuteReader();
                conlevel11.Close();

                string query2 = "select max(id) from Hack_Health.Pain_Nature";
                MySqlConnection conlevel2 = new MySqlConnection(connectionString);
                MySqlDataAdapter adpt2 = new MySqlDataAdapter();
                MySqlCommand cmd2 = new MySqlCommand(query2, conlevel2);
                conlevel2.Open();
                MySqlDataReader readerL2 = cmd2.ExecuteReader();
                if (readerL2.Read())
                {
                    try
                    {
                        if (readerL2.GetInt32("max(id)") != 0)
                        {
                            body_pain_id = readerL2.GetInt32("max(id)");
                        }
                    }
                    catch (Exception)
                    {

                        //none
                    }
                }
                conlevel2.Close();

                string query33 = "insert into Hack_Health.Pain_Nature values('" + (++body_pain_id) + "','" + textBox2.Text + "','" + textBox5.Text + "','" +doctor_id + "')";
                MySqlConnection conlevel33 = new MySqlConnection(connectionString);
                MySqlCommand cmd33 = new MySqlCommand(query33, conlevel33);
                conlevel33.Open();
                cmd33.ExecuteReader();
                conlevel33.Close();

                string query44 = "insert into Hack_Health.Body_Part_has_Pain_Nature values('" + body_id_inc + "','" + body_pain_id + "')";
                MySqlConnection conlevel44 = new MySqlConnection(connectionString);
                MySqlCommand cmd44 = new MySqlCommand(query44, conlevel44);
                conlevel44.Open();
                cmd44.ExecuteReader();
                conlevel44.Close();

            }
            textBox1.Text = null;
            textBox2.Text = null;
            textBox5.Text = null;
            MessageBox.Show("saved successfully !");

        }

       
        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
            textBox2.Text = null;
            textBox5.Text = null;
        }
    }
}
