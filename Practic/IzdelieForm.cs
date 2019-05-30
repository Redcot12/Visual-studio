using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practic
{
    public partial class IzdelieForm : Form
    {
        public IzdelieForm()
        {
            InitializeComponent();
        }

        private void IzdelieForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dedeshko_ZaharchenkoDataSet2.Izdelia". При необходимости она может быть перемещена или удалена.
            this.izdeliaTableAdapter.Fill(this.dedeshko_ZaharchenkoDataSet2.Izdelia);

        }

    }
}
