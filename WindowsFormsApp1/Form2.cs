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

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connstr = "data source=192.168.3.8;database=Hotel_User;user id=wuxj;password=wuxj;pooling=false;charset=utf8";
            MySqlConnection conn = new MySqlConnection(connstr);
            string sql = "select * from roomsinfo ";
            MySqlCommand mySqlCommand = new MySqlCommand(sql, conn);

            conn.Open();

            MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
            listBox1.Items.Clear();
            while (mySqlDataReader.Read())
            {
               
                listBox1.Items.Add(mySqlDataReader["Name"].ToString());
            }
         
        }
    }
}
