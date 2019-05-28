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
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-IJHI4LO\SQLEXPRESS;Initial Catalog=Dedeshko_Zaharchenko;Integrated Security=True");
        double total = 0;
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
           // izdeliaTableAdapter1.Fill(Dedeshko_ZaharchenkoDataSet2.Izdelia);

            System.Object[] items2 = new System.Object[101];
            for (int i = 0; i < 101; i++)
            {
                items2[i] = i;
            }
            comboBox2.Items.AddRange(items2);

        }
    }
}
