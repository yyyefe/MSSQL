using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;

namespace VTYS
{
    public partial class MailSending : Form
    {
        public MailSending()
        {
            InitializeComponent();
        }

        private void MailSending_Load(object sender, EventArgs e)
        {
            
        }

        private void egitimSec_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (egitimSec.SelectedIndex == 0)
            {
                SqlConnection conn;
                SqlCommand cmd;
                SqlDataAdapter adapter;
                DataTable tablo;

                conn = new SqlConnection("Data Source=KARAGOZ;Initial Catalog=egitim;Integrated Security=True");
                adapter = new SqlDataAdapter("SELECT  AD, SOYAD ,EMAIL FROM OGRENCI", conn);
                tablo = new DataTable();
                conn.Open();
                adapter.Fill(tablo);
                dgKatilimcilar.DataSource = tablo;
                conn.Close();
            }
            if (egitimSec.SelectedIndex == 1)
            {
                SqlConnection conn;
                SqlCommand cmd;
                SqlDataAdapter adapter;
                DataTable tablo;

                conn = new SqlConnection("Data Source=KARAGOZ;Initial Catalog=egitim;Integrated Security=True");
                adapter = new SqlDataAdapter("SELECT AD, SOYAD ,EMAIL FROM OGRENCI O,EGITIM_DETAY ED " +
                    "WHERE EGITIM_ID=1 AND ED.KIMLIK_ID=O.KIMLIK_ID ", conn);
                tablo = new DataTable();
                conn.Open();
                adapter.Fill(tablo);
                dgKatilimcilar.DataSource = tablo;
                conn.Close();
            }
            if (egitimSec.SelectedIndex == 2)
            {
                SqlConnection conn;
                SqlCommand cmd;
                SqlDataAdapter adapter;
                DataTable tablo;

                conn = new SqlConnection("Data Source=KARAGOZ;Initial Catalog=egitim;Integrated Security=True");
                adapter = new SqlDataAdapter("SELECT AD, SOYAD ,EMAIL FROM OGRENCI O,EGITIM_DETAY ED " +
                    "WHERE EGITIM_ID=2 AND ED.KIMLIK_ID=O.KIMLIK_ID ", conn);
                tablo = new DataTable();
                conn.Open();
                adapter.Fill(tablo);
                dgKatilimcilar.DataSource = tablo;
                conn.Close();
            }
            if (egitimSec.SelectedIndex == 3)
            {
                SqlConnection conn;
                SqlCommand cmd;
                SqlDataAdapter adapter;
                DataTable tablo;

                conn = new SqlConnection("Data Source=KARAGOZ;Initial Catalog=egitim;Integrated Security=True");
                adapter = new SqlDataAdapter("SELECT AD, SOYAD ,EMAIL FROM OGRENCI O,EGITIM_DETAY ED " +
                    "WHERE EGITIM_ID=3 AND ED.KIMLIK_ID=O.KIMLIK_ID ", conn);
                tablo = new DataTable();
                conn.Open();
                adapter.Fill(tablo);
                dgKatilimcilar.DataSource = tablo;
                conn.Close();
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            dgGonderilecekler.Rows.Add(dgKatilimcilar.CurrentRow.Cells[0].Value.ToString(), 
                dgKatilimcilar.CurrentRow.Cells[1].Value.ToString(), dgKatilimcilar.CurrentRow.Cells[2].Value.ToString());
          
        }

        private void dgKatilimcilar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnTmnEkle_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow row in dgKatilimcilar.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    dgGonderilecekler.Rows.Add(row.Cells[0].Value.ToString(), 
                        row.Cells[1].Value.ToString(), row.Cells[2].Value.ToString());

                }
            }


        }

        private void btnTmzle_Click(object sender, EventArgs e)
        {
            dgGonderilecekler.Rows.Clear();
        }

        private void btnGndr_Click(object sender, EventArgs e)
        {
            MailGondermeNesnesi mgn = new MailGondermeNesnesi();

            foreach (DataGridViewRow row in dgGonderilecekler.Rows)
            {
                if (row.Cells[2].Value != null)
                {
                    if (txtEk.Text=="")
                    {
                        mgn.GmailEksiz(txtAd.Text,
                            txtMail.Text,
                            txtSifre.Text,
                            row.Cells["EMAIL"].Value.ToString(),
                            txtBaslik.Text,
                            txticerik.Text
                            );
                    }
                    else
                    {
                        mgn.Gmail(txtAd.Text,
                            txtMail.Text,
                            txtSifre.Text,
                            row.Cells["EMAIL"].Value.ToString(),
                            txtBaslik.Text,
                            txticerik.Text,
                            txtEk.Text);
                    }
                        

                    

                }
            }


        }

        private void btnEk_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Gönderi İçin Ek Dosya Seçebilirsiniz.";
            ofd.ShowDialog();
            txtEk.Text = ofd.FileName;
        }
    }
}
