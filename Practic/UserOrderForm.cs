/*using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Practic
{
    public partial class UserOrderForm : Form

   
    {
        ComboBox listBox;
        private class Order
        {
            
            // Поля внутреннего класса 
            // Фактически - это поля из таблицы товаров
            public String name { get; set; }
            public int id { get; set; }
            public int count { get; set; }
            public double price { get; set; }
            // Конструктор класса
            public Order(String name, int i, int c, double p)
            {
                this.name = name;
                this.id = i;
                this.count = c;
                this.price = p;
            }
        }
        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-IJHI4LO\SQLEXPRESS;Initial Catalog=Dedeshko_Zaharchenko;Integrated Security=True");
        double total = 0;
        double izdelie_price = 0;
        List<Order> cart = new List<Order>();
        String user = "";
        double order_total = 0;

        public UserOrderForm(String u)
        {
            InitializeComponent();
            this.user = u;
            listBox = comboBox1;

        }


            private void UserOrderForm_Load_1(object sender, EventArgs e)
        {
            
                        // TODO: эта строка кода загружает данные в таблицу 'Dedeshko_ZaharchenkoDataSet2.Izdelia'. Вы можете переместить или удалить её по мере необходимости.
            izdeliaTableAdapter1.Fill(dedeshko_ZaharchenkoDataSet21.Izdelia);

            System.Object[] items2 = new System.Object[101];
            for (int i = 0; i < 101; i++)
            {
                items2[i] = i;
            }
            comboBox2.Items.AddRange(items2);
        }
        private void textBox1_Leave(object sender, EventArgs e)
        {


        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();

                SqlCommand command = new SqlCommand("INSERT INTO [Zakaz] ([Дата], [Номер], [Заказчик], [Менеджер], [Стоймость]) " +
                    "VALUES (getdate(),@Номер,@Заказчик,@Менеджер,@Стоймость); SELECT SCOPE_IDENTITY(); ", connection);
                command.Parameters.AddWithValue("@Номер", "Новый");
                command.Parameters.AddWithValue("@Заказчик", this.user);
                command.Parameters.AddWithValue("@Менеджер", "manager");
                command.Parameters.AddWithValue("@Стоймость", order_total);

                int order = Convert.ToInt32(command.ExecuteScalar());

                List<Order> order_unique = new List<Order>();

                var uniqueNames = cart.Select(c => c.id).Distinct().ToList();

                foreach (int v in uniqueNames)
                {
                    double p = 0;
                    int c = 0;
                    string n = "";
                    foreach (Order o in cart)
                    {
                        if (v == o.id)
                        {
                            p += o.price;
                            c += o.count;
                            n = o.name;
                        }

                    }
                    order_unique.Add(new Order(n, v, c, p));

                }


                foreach (Order cart_item in order_unique)
                {

                    SqlCommand command1 = new SqlCommand("INSERT INTO Zakaznue_izdelia (Id_zakaz, [ID_изделия], counter) " +
                   " VALUES (" + order + ", " + cart_item.id + ", " + cart_item.count + ") ", connection);
                    command1.ExecuteScalar();
                }
                MessageBox.Show("Ваш заказ N" + order + "  забронирован!");
                connection.Close();
            }
            catch
            {
                MessageBox.Show("Ошибка !\n");

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataRowView item = (DataRowView)comboBox1.SelectedItem;
            string name = item.Row.ItemArray[2].ToString();
            cart.Add(new Order(name, Convert.ToInt32(comboBox1.SelectedValue), Convert.ToInt32(comboBox2.SelectedIndex), total));

            UpdateCart(cart);
        }
        private void UpdateCart(List<Order> c)
        {
            order_total = 0;
            StringBuilder s = new StringBuilder();
            foreach (Order cart_item in c)
            {
                s.Append("Изделие:" + cart_item.name + ", Кол-во: " + cart_item.count + ", цена:" + cart_item.price);
                s.Append("\n");
                order_total += cart_item.price;
            }
            s.Append("Итого: " + order_total);
            label8.Text = s.ToString();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            cart.RemoveAt(cart.Count() - 1);
            UpdateCart(cart);
        }

        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            {
                DataRowView item = (DataRowView)comboBox1.SelectedItem;

                if (item != null)
                {
                    double item_width = Convert.ToDouble(item.Row.ItemArray[3]);
                    double item_height = Convert.ToDouble(item.Row.ItemArray[4]);

                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT tkani.ID, tkani.ширина, tkani.длина, tkani.цена FROM Tkani INNER JOIN Tkani_izdelia ON ID = Id_IzdeliaTkani WHERE ID=" + comboBox1.SelectedValue
                                                    , connection);
                    SqlDataReader reader = command.ExecuteReader();
                    int id = 0;
                    double width = 0;
                    double height = 0;
                    double price = 0;
                    while (reader.Read())
                    {
                        id = Convert.ToInt32(reader[0] == DBNull.Value ? 0 : reader[0]);
                        width = Convert.ToDouble(reader[1] == DBNull.Value ? 0 : reader[1]);
                        height = Convert.ToDouble(reader[2] == DBNull.Value ? 0 : reader[2]);
                        price = Convert.ToDouble(reader[3] == DBNull.Value ? 0 : reader[3]);
                    }

                    izdelie_price = (item_width * item_height * price) / (width * height);
                    total = izdelie_price * Convert.ToInt32(comboBox2.SelectedIndex);
                    label6.Text = total.ToString();


                    reader.Close();
                    connection.Close();
                }

            }

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            total = izdelie_price * Convert.ToInt32(comboBox2.SelectedIndex);
            label6.Text = total.ToString();
        }
    }
}
*/

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

namespace Practic
{
    public partial class UserOrderForm : Form
    {


        private class Order
        {
            // Поля внутреннего класса 
            // Фактически - это поля из таблицы товаров
            public String name { get; set; }
            public int id { get; set; }
            public int count { get; set; }
            public double price { get; set; }
            // Конструктор класса
            public Order(String name, int i, int c, double p)
            {
                this.name = name;
                this.id = i;
                this.count = c;
                this.price = p;
            }
        }
        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-IJHI4LO\SQLEXPRESS;Initial Catalog=Dedeshko_Zaharchenko;Integrated Security=True"); double total = 0;
        double izdelie_price = 0;
        List<Order> cart = new List<Order>();
        String user = "";
        double order_total = 0;

        public UserOrderForm(String u)
        {
            InitializeComponent();
            this.user = u;
        }

        private void UserOrderForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dedeshko_ZaharchenkoDataSet4.Izdelia". При необходимости она может быть перемещена или удалена.
            this.izdeliaTableAdapter.Fill(this.dedeshko_ZaharchenkoDataSet4.Izdelia);


            System.Object[] items2 = new System.Object[101];
            for (int i = 0; i < 101; i++)
            {
                items2[i] = i;
            }
            comboBox2.Items.AddRange(items2);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataRowView item = (DataRowView)comboBox1.SelectedItem;
            String name = item.Row.ItemArray[2].ToString();
            cart.Add(new Order(name, Convert.ToInt32(comboBox1.SelectedValue), Convert.ToInt32(comboBox2.SelectedIndex), total));

            UpdateCart(cart);
        }

        private void UpdateCart(List<Order> c)
        {
            order_total = 0;
            StringBuilder s = new StringBuilder();
            foreach (Order cart_item in c)
            {
                s.Append("Изделие:" + cart_item.name + "\n" + "Кол-во:" + cart_item.count +"\n" + "цена:" + cart_item.price);
                s.Append("\n");
                order_total += cart_item.price;
            }
            s.Append("Итого: " + order_total);
            label8.Text = s.ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView item = (DataRowView)comboBox1.SelectedItem;

            if (item != null)
            {
                double item_width = Convert.ToDouble(item.Row.ItemArray[3]);
                double item_height = Convert.ToDouble(item.Row.ItemArray[4]);

                connection.Open();
                SqlCommand command = new SqlCommand("SELECT tkani.ID, tkani.ширина, tkani.длина, tkani.цена as tp, Furniture.ID_furniture,Furniture.Ширина,Furniture.Длина,Furniture.Цена FROM Tkani INNER JOIN Tkani_izdelia ON tkani.ID = Tkani_izdelia.ID_Tkani JOIN Furniture_izdelia ON Furniture_izdelia.ID_изделия = "+ comboBox1.SelectedValue + " join Furniture on Furniture.ID_furniture=Furniture_izdelia.[ID_фурнитуры] where Tkani_izdelia.ID_Izdelia=" + comboBox1.SelectedValue, connection);
                SqlDataReader reader = command.ExecuteReader();
                int id = 0;
                double width = 0;
                double height = 0;
                double price = 0;
                while (reader.Read())
                {
                    id = Convert.ToInt32(reader[0] == DBNull.Value ? 0 : reader[0]);
                    width = Convert.ToDouble(reader[1] == DBNull.Value ? 0 : reader[1]);
                    height = Convert.ToDouble(reader[2] == DBNull.Value ? 0 : reader[2]);
                    price = Convert.ToDouble(reader[3] == DBNull.Value ? 0 : reader[3]);
                }

                izdelie_price = (item_width * item_height * price) / (width * height);
                total = izdelie_price * Convert.ToInt32(comboBox2.SelectedIndex);
                label6.Text = total.ToString();


                reader.Close();
                connection.Close();
            }

        }


        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            total = izdelie_price * Convert.ToInt32(comboBox2.SelectedIndex);
            label6.Text = total.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();

                SqlCommand command = new SqlCommand("INSERT INTO [Zakaz] ([Дата], [Номер], [Заказчик], [Менеджер], [Стоймость]) " +
                    "VALUES (getdate(),@Номер,@Заказчик,@Менеджер,@Стоймость); SELECT SCOPE_IDENTITY(); ", connection);
                command.Parameters.AddWithValue("@Номер", "Новый");
                command.Parameters.AddWithValue("@Заказчик", this.user);
                command.Parameters.AddWithValue("@Менеджер", "manager");
                command.Parameters.AddWithValue("@Стоймость", order_total);

                int order = Convert.ToInt32(command.ExecuteScalar());

                List<Order> order_unique = new List<Order>();

                var uniqueNames = cart.Select(c => c.id).Distinct().ToList();

                foreach (int v in uniqueNames)
                {
                    double p = 0;
                    int c = 0;
                    String n = "";
                    foreach (Order o in cart)
                    {
                        if (v == o.id)
                        {
                            p += o.price;
                            c += o.count;
                            n = o.name;
                        }

                    }
                    order_unique.Add(new Order(n, v, c, p));

                }


                foreach (Order cart_item in order_unique)
                {

                    SqlCommand command1 = new SqlCommand("INSERT INTO Zakaznue_izdelia (Id_zakaz, [ID_изделия], counter) " +
                    " VALUES (" + order + ", " + cart_item.id + ", " + cart_item.count + ") ", connection);
                    command1.ExecuteScalar();
                }
                MessageBox.Show("Ваш заказ N" + order + "  забронирован!");
                connection.Close();
            }
            catch
            {
                MessageBox.Show("Ошибка !\n");

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            cart.RemoveAt(cart.Count() - 1);
            UpdateCart(cart);
        }

        
    }
}