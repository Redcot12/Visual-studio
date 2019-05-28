namespace Practic
{
    partial class UserOrderForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.izdeliaTableAdapter1 = new Practic.Dedeshko_ZaharchenkoDataSet2TableAdapters.IzdeliaTableAdapter();
            this.dedeshko_ZaharchenkoDataSet21 = new Practic.Dedeshko_ZaharchenkoDataSet2();
            ((System.ComponentModel.ISupportInitialize)(this.dedeshko_ZaharchenkoDataSet21)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(171, 229);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(340, 215);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 1;
            // 
            // izdeliaTableAdapter1
            // 
            this.izdeliaTableAdapter1.ClearBeforeFill = true;
            // 
            // dedeshko_ZaharchenkoDataSet21
            // 
            this.dedeshko_ZaharchenkoDataSet21.DataSetName = "Dedeshko_ZaharchenkoDataSet2";
            this.dedeshko_ZaharchenkoDataSet21.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // UserOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Name = "UserOrderForm";
            this.Text = "UserOrderForm";
            ((System.ComponentModel.ISupportInitialize)(this.dedeshko_ZaharchenkoDataSet21)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private Dedeshko_ZaharchenkoDataSet2TableAdapters.IzdeliaTableAdapter izdeliaTableAdapter1;
        private Dedeshko_ZaharchenkoDataSet2 dedeshko_ZaharchenkoDataSet21;
    }
}