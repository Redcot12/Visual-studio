using App;
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
    public partial class UserForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-IJHI4LO\SQLEXPRESS;Initial Catalog=Dedeshko_Zaharchenko;Integrated Security=True");
        String user = "";
        public UserForm() { }
        public UserForm(String u)
        {
            InitializeComponent();
            this.user = u;
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            String sql = "select * from Izdelia";
            SqlDataAdapter sda = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            sda.Fill(ds, "Izdelia");
            dataGridView1.DataSource = ds.Tables["Izdelia"];


            DataGridViewImageColumn img = new DataGridViewImageColumn();
            Image image = Image.FromFile(@"C:\Users\Степан\Pictures\15030780.jpg");
            img.Image = image;
            dataGridView1.Columns.Add(img);
            img.HeaderText = "Image";
            img.Name = "img";
        }

        private void заказToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OrderListForm l = new OrderListForm();
           l.Show();
        }

        private void заказыToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Form order = new UserOrderForm(this.user);
            order.Show();
        }

        private void конструкторToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form constr = new ConstructorForm();
            constr.Show();
        }

        private void тканиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TkaniForm t = new TkaniForm();
            t.Show();
        }

        private void фурнитураToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FurnituraForm f = new FurnituraForm();
            f.Show();
        }
    }
}
