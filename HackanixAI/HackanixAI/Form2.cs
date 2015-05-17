using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HackanixAI
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string bodyPart = comboBox1.SelectedItem.ToString();
            string body = textBox1.Text;
            List<string> docs = new List<string>();
            string from = "no_reply@novacare.com";
            string query = "select * from Hack_Health.Doctor";
            string connectionString = "datasource=localhost;port=3306;username=root;password=1234";
            MySqlConnection conlevel1 = new MySqlConnection(connectionString);
            MySqlDataAdapter adpt1 = new MySqlDataAdapter();
            MySqlCommand cmd1 = new MySqlCommand(query, conlevel1);
            conlevel1.Open();
            MySqlDataReader readerL1 = cmd1.ExecuteReader();
            while (readerL1.Read())
            {
                
                string spec = readerL1.GetString("specializationArea");
                string doc = readerL1.GetString("email");
                if (bodyPart.Equals("Other"))
                {
                    docs.Add(doc);
                }
                else
                {
                    if (spec.Equals(bodyPart))
                    {
                        docs.Add(doc);
                    }
                }
            }
            string subject = "novaCare help desk";
            foreach(string i in docs)
            {
                try
                {
                    MailMessage message = new MailMessage(from, i, subject, body);
                    SmtpClient client = new SmtpClient("smtp.live.com", 587);
                    client.EnableSsl = true;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential("anuradha.sanjeewa@live.com", "774217285");
                    client.Send(message);
                    MessageBox.Show("Mail sent to the relevant set of doctors", "Contact doctor");
                }
                catch (Exception)
                {
                    MessageBox.Show("Mail could not be sent", "Contact doctor");
                }
            }
            conlevel1.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
