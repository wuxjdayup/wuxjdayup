using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username, password;
            username = textBox1.Text;
            password = textBox2.Text;
            if (username == "" || password == "")
            {
                MessageBox.Show("用户名或密码不能为空");
                return;
            }
            try
            {
                string connstr = "data source=192.168.3.8;database=Hotel_User;user id=wuxj;password=wuxj;pooling=false;charset=utf8";
                MySqlConnection conn = new MySqlConnection(connstr);
                string sql = "select * from usersinfo where username = @user and password = @pass";
                MySqlCommand mySqlCommand = new MySqlCommand(sql, conn);
                mySqlCommand.Parameters.Add(new MySqlParameter("@user", username));
                mySqlCommand.Parameters.Add(new MySqlParameter("@pass", password));

                conn.Open();

                MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();

                if (mySqlDataReader.Read())
                {
                    Form2 form2 = new Form2();
                    form2.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("用户名或密码错误！");
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("用户名或密码错误！" + ex.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string username, password;
            username = textBox1.Text;
            password = textBox2.Text;
            if (username == "" || password == "")
            {
                MessageBox.Show("用户名或密码不能为空");
                return;
            }

            try
            {
                string connstr = "data source=192.168.3.8;database=Hotel_User;user id=wuxj;password=wuxj;pooling=false;charset=utf8";
                MySqlConnection conn = new MySqlConnection(connstr);
                string sql = "insert into usersinfo  (username,password) values (@user , @pass)";
                MySqlCommand mySqlCommand = new MySqlCommand(sql, conn);
                mySqlCommand.Parameters.Add(new MySqlParameter("@user", username));
                mySqlCommand.Parameters.Add(new MySqlParameter("@pass", password));

                conn.Open();
                mySqlCommand.ExecuteNonQuery();

                MessageBox.Show("注册成功！");

            }
            catch (Exception ex)
            {
                MessageBox.Show("用户名或密码错误！" + ex.Message);
            }
        }
    }
}
