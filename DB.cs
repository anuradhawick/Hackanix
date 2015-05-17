using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;
namespace DataBaseConnection
{
    class DBConn
    {
        MySqlConnection Conn;
        private string ConnectionString;
        public DBConn(string ConnectionString)
        {
            this.ConnectionString = ConnectionString;
            Conn = new MySqlConnection(ConnectionString);
        }
        public void SaveToDB(string QueryString)
        {
            
            MySqlCommand Comm = new MySqlCommand(QueryString, Conn);
            try
            {
                Conn.Open();
                Comm.ExecuteReader();
                MessageBox.Show("Data saved successfully!", "Save");
            }
            catch (Exception)
            {

                MessageBox.Show("Operation failed!","Save");
            }
            finally
            {
                Conn.Close();
            }
        }

        public void UpdateToDB(string QueryString ) 
        {
            MySqlCommand Comm = new MySqlCommand(QueryString, Conn);
            try
            {
                Conn.Open();
                Comm.ExecuteReader();
                MessageBox.Show("Data updated successfully!", "Update");
            }
            catch (Exception)
            {

                MessageBox.Show("Operation failed!", "Update");
            }
            finally
            {
                Conn.Close();
            }
        
        }

        public void DeleteFromDB(string QueryString) 
        {
            MySqlCommand Comm = new MySqlCommand(QueryString, Conn);
            try
            {
                Conn.Open();
                Comm.ExecuteReader();
                MessageBox.Show("Data deleted successfully!", "Delete");
            }
            catch (Exception)
            {

                MessageBox.Show("Operation failed!", "Delete");
            }
            finally
            {
                Conn.Close();
            }
          
            
        }

        public DataTable SearchFromDB(string QueryString) 
        {
            MySqlCommand Comm = new MySqlCommand(QueryString, Conn);
            try
            {
                Conn.Open();
                MySqlDataAdapter DataAdp = new MySqlDataAdapter();
                DataAdp.SelectCommand = Comm;
                DataTable Datatbl = new DataTable();
                DataAdp.Fill(Datatbl);
                return Datatbl;
            }
            catch (Exception)
            {
                MessageBox.Show("Operation failed!", "Search");
                return null;
            }
            finally
            {
                Conn.Close();
            }
        }
    }
}
