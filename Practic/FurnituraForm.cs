using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App
{
    public partial class FurnituraForm : Form
    {
        public FurnituraForm()
        {
            InitializeComponent();
        }

        private void FurnituraForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'test2DataSet.furniture' table. You can move, or remove it, as needed.
            furnitureTableAdapter.Fill(test2DataSet.Furniture);

        }

        private void FurnituraForm_Load_1(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "test2.Furniture". При необходимости она может быть перемещена или удалена.
            this.furnitureTableAdapter.Fill(this.test2DataSet.Furniture);

        }
    }
}