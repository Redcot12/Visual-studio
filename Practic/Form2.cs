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
using System.Windows;
using System.Configuration;


namespace Practic
{
    public partial class Form2 : Form
    {
        private SqlConnection sqlConnection = null;

        double a = 6;
        public Form2(SqlConnection con)
        {
            InitializeComponent();
            sqlConnection = con;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0) // проверяем  имя
            {

            }
            else MessageBox.Show("Укажите имя");

            if (comboBox1.Text.Length > 0) // проверяем роль
            {

            }
            else MessageBox.Show("Укажите Роль");

            if (textBox2.Text.Length > 0) // проверяем логин
            {

            }
            else MessageBox.Show("Укажите логин");

            if (textBox3.Text.Length > 0) // проверяем пароль
            {

            }
            else MessageBox.Show("Укажите пароль");


            if (textBox4.Text.Length > 0) // проверяем второй пароль
            {

            }
            else MessageBox.Show("Повторите пароль");

            if (textBox3.TextLength < 32)
            {

            }
            else
            {
                MessageBox.Show("Длина пароля превышает допустимую. Максимальная длина 32 символов.");
            }

            if (textBox3.Text.Length == 0)
            {
                MessageBox.Show("Одно из полей не заполнено");
            }
            else

            if (textBox3.TextLength > 6)
            {
                if (textBox3.TextLength < 32)
                {
                    if (textBox3.Text == textBox4.Text) // проверка на совпадение паролей
                    {
                        MessageBox.Show("Пользователь зарегистрирован");
                    }

                    else MessageBox.Show("Пароли не совподают");
                }
                else MessageBox.Show("Длина пароля превышает допустимую. Максимальная длина 32 символов.");
            }
            else MessageBox.Show("Длина пароля меньше допустимой. Минимальная длина 6 символа.");
            
            
            
                
           

            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-IJHI4LO\SQLEXPRESS;Initial Catalog=Dedeshko_Zaharchenko;Integrated Security=True");
            string sql = "INSERT INTO [Polzovatel] (Логин, Пароль, [Наименование],Роль) VALUES (@Логин, @Пароль, @Наименование,@Роль)";
            SqlCommand insertUserNameCommand = new SqlCommand(sql, con);
            insertUserNameCommand.Parameters.AddWithValue("Логин", textBox2.Text);
            insertUserNameCommand.Parameters.AddWithValue("Пароль", textBox3.Text);
            insertUserNameCommand.Parameters.AddWithValue("Наименование", textBox1.Text);
            insertUserNameCommand.Parameters.AddWithValue("Роль", comboBox1.Text);

            try
            {
                con.Open();
                int n = insertUserNameCommand.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Hide();
                Form1 y = new Form1();
                y.Show();

            }
            if (textBox3.TextLength < 6)
            {

            }
            else return;

        }

       
    }
}
