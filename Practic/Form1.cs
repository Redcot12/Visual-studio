using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace Practic
{
    public partial class Form1 : Form
    {
        private SqlConnection sqlConnection = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
        

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0) // проверяем введён ли логин
            {
                if (textBox2.Text.Length > 0) // проверяем введён ли пароль
                {
                    SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-IJHI4LO\SQLEXPRESS;Initial Catalog=Dedeshko_Zaharchenko;Integrated Security=True");
                    con.Open();
                    string query = "SELECT * FROM [Polzovatel] WHERE [Логин]= '" + textBox1.Text + "' AND [Пароль] = '" + textBox2.Text + "'";
                    SqlDataAdapter sda = new SqlDataAdapter(query, con); //("SELECT * FROM user WHERE [Пользователи]= '"+ textBox1.Text +"' and [Пароль] = '" + textBox2.Text + "'", con);
                    DataTable dtbl = new DataTable();
                    sda.Fill(dtbl);
                    if (dtbl.Rows.Count > 0) // если такая запись существует
                    {
                        MessageBox.Show("Пользователь авторизовался"); // говорим, что авторизовался
                        this.Hide();
                        Form3 f = new Form3();
                        f.Show();

                    }
                    else MessageBox.Show("Пользователя не найден"); // выводим ошибку
                }
                else MessageBox.Show("Введите пароль"); // выводим ошибку
            }
            else MessageBox.Show("Введите логин"); // выводим ошибку
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Hide();
            Form1 f1 = new Form1();
            Form t = new Form2(sqlConnection);
            f1.Close();
            t.Show();
        }
    }
}

