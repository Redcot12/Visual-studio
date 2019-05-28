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
    public partial class RegForm : Form
    {
        private SqlConnection sqlConnection = null;

        double a = 6;
        int errors = 0;

        public RegForm(SqlConnection con)
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
            else
            {
                errors++;
                MessageBox.Show("Укажите имя");
            }
            if (comboBox1.Text.Length > 0) // проверяем роль
            {

            }
            else
            {
                errors++;
                MessageBox.Show("Укажите Роль");
            }

            if (textBox2.Text.Length > 0) // проверяем логин
            {

            }
            else
            {
                errors++;
                MessageBox.Show("Укажите логин");
            }
            if (textBox3.Text.Length > 0) // проверяем пароль
            {

            }
            else
            {
                errors++;
                MessageBox.Show("Укажите пароль");
            }

            if (textBox4.Text.Length > 0) // проверяем второй пароль
            {

            }
            else
            {
                errors++;
                MessageBox.Show("Повторите пароль");
            }
            if (textBox3.TextLength < 32)
            {

            }
            else
            {
                errors++;
                MessageBox.Show("Длина пароля превышает допустимую. Максимальная длина 32 символов.");
            }

            if (textBox3.Text.Length == 0)
            {
                errors++;
                MessageBox.Show("Одно из полей не заполнено");
            }
            else

            if (textBox3.TextLength > 5)
            {
                if (textBox3.TextLength < 33)
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
           


            if(errors == 0)
            {


                {

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
                        EntryForm y = new EntryForm();
                        y.Show();

                    }


                }
            }


        }
    }
}