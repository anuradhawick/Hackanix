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
    public partial class Form3 : Form
    {
        string docPW;
        string userpw;
        string docName;
        string userName;
        public Form3()
        {
            docName = "doc1";
            docPW = "123doc";
            userName = "user1";
            userpw = "123user";
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "select * from Hack_Health.Account" ;
            string connectionString="datasource=localhost;port=3306;username=root;password=1234";
            //making the new connection to operate in the 3rd level
            MySqlConnection conlevel = new MySqlConnection(connectionString);
            MySqlDataAdapter adpt = new MySqlDataAdapter();
            MySqlCommand cmd3 = new MySqlCommand(query, conlevel);
            conlevel.Open();
            MySqlDataReader readerL = cmd3.ExecuteReader();
            bool match = false;
            while(readerL.Read())
            {
                string username = readerL.GetString("username");
                string passsword=readerL.GetString("password");
                string type=readerL.GetString("usertype");
                if(username.Equals(textBox1.Text) && passsword.Equals(textBox2.Text) && ((string)comboBox1.SelectedItem).Equals(type))
                {
                    if (comboBox1.SelectedItem.ToString().Equals("Doctor"))
                    {
                       
                        (new Form4(readerL.GetString("id"))).Show();

                        Hide();
                    }
                    else
                    {
                        (new Form1()).Show();

                        Hide();
                    }
                    match = true;
                    break;
                }
            }
            if (!match)
            {
                MessageBox.Show("Login failure, please check username and password!", "Login failure");
                textBox2.Text = null;
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            button3.Visible = false;
        }
    }
}
