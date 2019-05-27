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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }
        private void фToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form fur = new FurnituraForm();
            fur.Show();
            Close();
        }

        private void тканиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form tkani = new TkaniForm();
            tkani.Show();
            Close();
        }
    }
}
