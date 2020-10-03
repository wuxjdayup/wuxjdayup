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

            while(mySqlDataReader.Read())
            {
                this.dataGridView1.Rows.Add(mySqlDataReader["No"].ToString(),mySqlDataReader["Name"].ToString(), (int)mySqlDataReader["sts"] == 1 ? "已使用":"未使用");
            }

         
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //this.dataGridView1.Columns.Add("a", "房间号");
            //this.dataGridView1.Columns.Add("b", "房间名");
            //this.dataGridView1.Columns.Add("c", "状态");

            //this.dataGridView1.Columns[0].HeaderCell.Value = "房间号";
            //this.dataGridView1.Columns[1].HeaderCell.Value = "房间名";
            //this.dataGridView1.Columns[2].HeaderCell.Value = "状态";
        }
    }
}
