using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VTYS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnEgitimEkle_Click(object sender, EventArgs e)
        {
            this.Hide();
            egitim_Ekle egitim_Ekle = new egitim_Ekle();
            egitim_Ekle.ShowDialog();
            this.Show();
        }

        private void btnKatilimciEkle_Click(object sender, EventArgs e)
        {
            this.Hide();
            katilimci_Ekle katilimci_Ekle = new katilimci_Ekle();
            katilimci_Ekle.ShowDialog();
            this.Show();
        }

        private void btnEgitimGoruntule_Click(object sender, EventArgs e)
        {
            this.Hide();
            egitim_Goruntule egitim_Goruntule = new egitim_Goruntule();
            egitim_Goruntule.Show();
            this.Show();
        }

        private void btnKatilimciGoruntule_Click(object sender, EventArgs e)
        {
            this.Hide();
            katilimci_Goruntule katilimci_Goruntule = new katilimci_Goruntule();
            katilimci_Goruntule.Show();
            this.Show();
        }

        private void btnEgitimGuncelle_Click(object sender, EventArgs e)
        {
            this.Hide();
            egitim_Guncelleme egitim_Guncelleme = new egitim_Guncelleme();
            egitim_Guncelleme.ShowDialog();
            this.Show();
        }

        private void btnKatilimciGuncelle_Click(object sender, EventArgs e)
        {
            this.Hide();
            katilimci_Guncelle katilimci_Guncelleme = new katilimci_Guncelle();
            katilimci_Guncelleme.ShowDialog();
            this.Show();
        }

        

        private void button1_Click_1(object sender, EventArgs e)
        {
            
            this.Hide();
            MailSending ms = new MailSending();
            ms.ShowDialog();
            this.Show();
        }

    }
}
