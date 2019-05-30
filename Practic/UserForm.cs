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

        private void изделияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IzdelieForm Iz = new IzdelieForm();
            Iz.Show();
        }
    }
}
