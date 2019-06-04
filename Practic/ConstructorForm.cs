using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App
{
    public partial class ConstructorForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-IJHI4LO\SQLEXPRESS;Initial Catalog=Dedeshko_Zaharchenko;Integrated Security=True");
        private class Tkani
        {
            public int id { get; set; }
            public string название { get; set; }
            public string цвет { get; set; }
            public double цена { get; set; }

            public Tkani(int i, string n, string c, double p)
            {
                id = i;
                название = n;
                цвет = c;
                цена = p;
            }
        }

   
        public ConstructorForm()
        {
            
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)

        {

        }

        private void ConstructorForm_Load(object sender, EventArgs e)
        {
            // заполнение Combobox1 - списком из таблицы Ткани
            tkaniTableAdapter.Fill(test2DataSet2.Tkani);

            // заполнение Combobox2 - списком из таблицы Фурнитуры
            furnitureTableAdapter.Fill(test2.Furniture);

        }

        /*
        public void fillCombos()
        {
            String sql = "SELECT id, название, цвет, цена FROM tkani";
            connection.Open();
            SqlCommand command = new SqlCommand(sql,connection);
            SqlDataReader reader = command.ExecuteReader();
            List<Tkani> listoftkani = new List<Tkani>();
            
            while(reader.Read())
            {
                listoftkani.Add(new Tkani(Convert.ToInt32(reader["id"]),
                    reader["название"].ToString()+","+ reader["цвет"].ToString(),
                    reader["цвет"].ToString(),
                    Convert.ToDouble(reader["цена"])));
            }
            comboBox1.DataSource = listoftkani;
            comboBox1.DisplayMember = "название";
            reader.Close();
        }
        */

        private void button2_Click_1(object sender, EventArgs e)
        {
            // выбранный идентификатор фурнитуры
            int selected_furniture = Convert.ToInt32(comboBox2.SelectedValue);
            // выбранный идентификатор ткани
            int selected_tkani = Convert.ToInt32(comboBox1.SelectedValue);

            try
            {
                con.Open();
                Random random = new Random();
                String artikul = "User-" + random.Next(1000000);
                SqlCommand command = new SqlCommand("INSERT INTO izdelia (Наименование, Длина, Ширина) " +
                    "VALUES (@name,@width,@height); SELECT SCOPE_IDENTITY(); ", con);
                command.Parameters.AddWithValue("@name", textBox1.Text);
                command.Parameters.AddWithValue("@width", textBox2.Text);
                command.Parameters.AddWithValue("@height", textBox3.Text);

                int izdelia = Convert.ToInt32(command.ExecuteScalar());

                SqlCommand command1 = new SqlCommand("INSERT INTO Furniture_izdelia (ID_фурнитуры, ID_изделия, Размещение, Ширина, Длина, Поворот, Количество) " +
                   "VALUES (" + selected_furniture + "," + izdelia + ", 0, 0, 0, 0, 0);", con);
                command1.ExecuteScalar();

                SqlCommand command2 = new SqlCommand("INSERT INTO tkani_izdelia (ID_ткани, ID_изделия) " +
                  "VALUES (" + selected_tkani + "," + izdelia + ");", con);
                command2.ExecuteScalar();

                MessageBox.Show("Изделие успешно добавлено");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";

                con.Close();

            }
            catch
            {
                MessageBox.Show("Ошибка !\n");

            }

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //DataRowView item = (DataRowView)comboBox1.SelectedItem;
            //MessageBox.Show(item.Row.ItemArray[3].ToString());
            Draw();
        }

        private void Draw()
        {

            if (textBox2.Text.Trim().Length == 0 || textBox3.Text.Trim().Length == 0)
            {
                MessageBox.Show("Введите размеры изделия!");
            }
            else
            {
                Graphics g = panel1.CreateGraphics();
                g.Clear(Color.White);
                Pen p = new Pen(Color.Black, 1);
                int w = Convert.ToInt32(textBox2.Text.Trim());
                int h = Convert.ToInt32(textBox3.Text.Trim());
                g.DrawRectangle(p, 10, 10, w, h);

                DataRowView item = (DataRowView)comboBox1.SelectedItem;
                String color = item.Row.ItemArray[3].ToString();
                String ris = item.Row.ItemArray[4].ToString();
                Brush brush;
                if (ris.Contains("jpg"))
                {
                    Image img = Image.FromFile(ris);
                    Bitmap bimage = new Bitmap(img);
                    TextureBrush tb = new TextureBrush(bimage);
                    g.FillRectangle(tb, 11, 11, w - 1, h - 1);
                }
                else
                {
                    switch (color)
                    {
                        case "красный":
                            brush = new SolidBrush(Color.Red);
                            g.FillRectangle(brush, 11, 11, w - 1, h - 1);
                            break;
                        case "зеленый":
                            brush = new SolidBrush(Color.FromArgb(255, 0, 255, 0));
                            g.FillRectangle(brush, 11, 11, w - 1, h - 1);
                            break;
                        default:
                            brush = new SolidBrush(Color.White);
                            g.FillRectangle(brush, 11, 11, w - 1, h - 1);
                            break;
                    }
                }
            }


        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Form addtkan = new AddTkani();
            addtkan.Show();
        }

        private void ConstructorForm_Activated(object sender, EventArgs e)
        {
            tkaniTableAdapter.Fill(test2DataSet2.Tkani);
        }

        private void ConstructorForm_Enter(object sender, EventArgs e)
        {
            // MessageBox.Show("1234");
        }

        private void ConstructorForm_Load_1(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "test2DataSet2.Tkani". При необходимости она может быть перемещена или удалена.
            //this.tkaniTableAdapter.Fill(this.test2DataSet2.Tkani);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "test2.Furniture". При необходимости она может быть перемещена или удалена.
            this.furnitureTableAdapter.Fill(this.test2.Furniture);
         ;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


    }
}