using Practic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App
{
    public partial class TkaniForm : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-IJHI4LO\SQLEXPRESS;Initial Catalog=Dedeshko_Zaharchenko;Integrated Security=True");
        WareForm ware;
        DataSet ds;
        SqlDataAdapter sda;
        DataSet changes;

        public TkaniForm()
        {
            InitializeComponent();
        }

        public void LoadList()
        {

            MessageBox.Show("123");
            String query = "SELECT * FROM Tkani";
            sda = new SqlDataAdapter(query, connection);
            ds = new DataSet();
            sda.Fill(ds, "Tkani");
            dataGridView1.DataSource = ds.Tables["Tkani"];
/*
            DataGridViewImageColumn img = new DataGridViewImageColumn();
            img.Name = "img";
            img.HeaderText = "Изображения";
            dataGridView1.Columns.Add(img);
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (dataGridView1.Rows[i].Cells[1].Value != null)
                {
                    string basePath = @"C:\Users\Степан\Pictures\";
                    string filename = dataGridView1.Rows[i].Cells[1].Value.ToString() + ".jpg";
                    string fullPath = basePath + filename;
                    Image image;
                    if (File.Exists(fullPath))
                    {
                        image = Image.FromFile(fullPath);
                    }
                    else
                    {
                        image = Image.FromFile(basePath + "empty.jpg");
                    }
                    dataGridView1.Rows[i].Cells["img"].Value = image;
                }
            }
            */
        }

        private void TkaniForm_Load(object sender, EventArgs e)
        {

          
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Close();
            
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            changes = ds.GetChanges();
            if (changes != null)
            {
                SqlCommandBuilder builder = new SqlCommandBuilder(sda);
                builder.GetInsertCommand();
                int updatesRows = sda.Update(changes, "Tkani");
                ds.AcceptChanges();
            }
            LoadList();


            MessageBox.Show("Успешно!", "Заголовок", MessageBoxButtons.OKCancel);

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            foreach (DataGridViewRow items in dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.RemoveAt(items.Index);
            }
           button3_Click_1(sender, e);
        }

        private void TkaniForm_Load_1(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tkaniDataSet3.Tkani". При необходимости она может быть перемещена или удалена.
            // this.tkaniTableAdapter.Fill(this.tkaniDataSet3.Tkani);
            LoadList();

        }
    }
}