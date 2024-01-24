
namespace VTYS
{
    partial class katilimci_Goruntule
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cmbSec = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(273, 10);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(855, 355);
            this.dataGridView1.TabIndex = 0;
            // 
            // cmbSec
            // 
            this.cmbSec.FormattingEnabled = true;
            this.cmbSec.Items.AddRange(new object[] {
            "Hepsi",
            "Eğitim 1",
            "Eğitim 2",
            "Eğitim 3"});
            this.cmbSec.Location = new System.Drawing.Point(29, 22);
            this.cmbSec.Name = "cmbSec";
            this.cmbSec.Size = new System.Drawing.Size(226, 21);
            this.cmbSec.TabIndex = 1;
            this.cmbSec.Text = "Eğitimi seç";
            this.cmbSec.SelectedIndexChanged += new System.EventHandler(this.cmbSec_SelectedIndexChanged);
            // 
            // katilimci_Goruntule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1139, 370);
            this.Controls.Add(this.cmbSec);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "katilimci_Goruntule";
            this.Text = "katilimci_Goruntule";
            this.Load += new System.EventHandler(this.katilimci_Goruntule_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cmbSec;
    }
}