using DataBaseConnection;
using HackanixAI;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace stringOperations
{
    class StringProcessor
    {
        private char[] delimeters = { ' ', ',', '.', ':', '\t' };
        private TextBox tb;
        private TextBox lb;
        private string[] seperated;
        private SQLConn conn;
        public StringProcessor(string UserInput,ref TextBox tb,ref TextBox lb)
        {
            this.seperated = UserInput.Split(delimeters);
            this.tb = tb;
            this.lb = lb;
            this.conn = new SQLConn("datasource=localhost;port=3306;username=root;password=1234");
        }
        public void matchTheCase()
        {
            bool matchFound = false;
            string tempMatch;
            string matchingID;
            string connectionString = "datasource=localhost;port=3306;username=root;password=1234";
            foreach (string i in this.seperated)
            {
                string query = "select * from Hack_Health.Body_Part";
                MySqlConnection conlevel1 = new MySqlConnection(connectionString);
                MySqlDataAdapter adpt1 = new MySqlDataAdapter();
                MySqlCommand cmd1 = new MySqlCommand(query, conlevel1);
                conlevel1.Open();
                MySqlDataReader readerL1 = cmd1.ExecuteReader();
                while (readerL1.Read())
                {
                    tempMatch = readerL1.GetString("Part").ToLower();
                    if (tempMatch.Contains(i.ToLower()))
                    {
                        //Adding data to the list box; details of the body part and the remedy
                        matchingID = readerL1.GetString("id");
                        query = "select * from Hack_Health.Body_Part_has_Pain_Nature where Body_Part_id =" + matchingID;
                        tb.AppendText("If you have an issue with " + i + " such as ");
                        MySqlConnection conlevel2 = new MySqlConnection(connectionString);
                        MySqlDataAdapter adpt2 = new MySqlDataAdapter();
                        MySqlCommand cmd2 = new MySqlCommand(query, conlevel2);
                        conlevel2.Open();
                        MySqlDataReader readerL2 = cmd2.ExecuteReader();

                        while (readerL2.Read())
                        {
                            matchingID = readerL2.GetString("Pain_Nature_id");
                            query = "select * from Hack_Health.Pain_Nature where id = " + matchingID;
                            //making the new connection to operate in the 3rd level
                            MySqlConnection conlevel3 = new MySqlConnection(connectionString);
                            MySqlDataAdapter adpt3 = new MySqlDataAdapter();
                            MySqlCommand cmd3 = new MySqlCommand(query, conlevel3);
                            conlevel3.Open();
                            MySqlDataReader readerL3 = cmd3.ExecuteReader();
                            while (readerL3.Read())
                            {
                                foreach (string j in this.seperated)
                                {
                                    if ((j.ToLower()).Contains((readerL3.GetString("pain")).ToLower()))
                                    {
                                        matchFound = true;
                                        tb.AppendText(" " + readerL3.GetString("pain"));
                                        lb.AppendText(" " + readerL3.GetString("details"));
                                    }
                                }
                            }
                            conlevel3.Close();
                        }
                        conlevel2.Close();
                    }
                    break;
                }
                conlevel1.Close();
            }
            if (!matchFound)
            {
                Form2 f2 = new Form2();
                f2.Show();
            }
        }
    }
}
