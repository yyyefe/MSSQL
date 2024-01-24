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
    public partial class katilimci_Goruntule : Form
    {
        public katilimci_Goruntule()
        {
            InitializeComponent();
        }

        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter adapter;
        DataTable tablo;
        
        void katilimciGoruntle()
        {
            conn = new SqlConnection("Data Source=KARAGOZ;Initial Catalog=egitim;Integrated Security=True");

            if (cmbSec.SelectedIndex==0)
            {
                adapter = new SqlDataAdapter("SELECT KIMLIK_ID, TC, AD, SOYAD," +
                    "DOGUM_YERI, EMAIL, TELEFON, UNVAN_ID FROM OGRENCI where PSF_ID is  null", conn);
                tablo = new DataTable();
                conn.Open();
                adapter.Fill(tablo);
                dataGridView1.DataSource = tablo;
                conn.Close();
            }
            if (cmbSec.SelectedIndex == 1)
            {
                adapter = new SqlDataAdapter("SELECT O.KIMLIK_ID, O.TC, O.AD, O.SOYAD, " +
                    "O.DOGUM_YERI, O.EMAIL, O.TELEFON, O.UNVAN_ID FROM OGRENCI O, EGITIM_DETAY EA " +
                    "where EA.EGITIM_ID=1 and O.KIMLIK_ID=EA.KIMLIK_ID ", conn);
                tablo = new DataTable();
                conn.Open();
                adapter.Fill(tablo);
                dataGridView1.DataSource = tablo;
                conn.Close();
            }
            if (cmbSec.SelectedIndex == 2)
            {
                adapter = new SqlDataAdapter("SELECT O.KIMLIK_ID, O.TC, O.AD, O.SOYAD, " +
                    "O.DOGUM_YERI, O.EMAIL, O.TELEFON, O.UNVAN_ID FROM OGRENCI O, EGITIM_DETAY EA " +
                    "where EA.EGITIM_ID=2 and O.KIMLIK_ID=EA.KIMLIK_ID ", conn);
                tablo = new DataTable();
                conn.Open();
                adapter.Fill(tablo);
                dataGridView1.DataSource = tablo;
                conn.Close();
            }
            if (cmbSec.SelectedIndex == 3)
            {
                adapter = new SqlDataAdapter("SELECT O.KIMLIK_ID, O.TC, O.AD, O.SOYAD, " +
                    "O.DOGUM_YERI, O.EMAIL, O.TELEFON, O.UNVAN_ID FROM OGRENCI O, EGITIM_DETAY EA " +
                    "where EA.EGITIM_ID=3 and O.KIMLIK_ID=EA.KIMLIK_ID ", conn);
                tablo = new DataTable();
                conn.Open();
                adapter.Fill(tablo);
                dataGridView1.DataSource = tablo;
                conn.Close();
            }
            
        }
        private void katilimci_Goruntule_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection("Data Source=KARAGOZ;Initial Catalog=egitim;Integrated Security=True");
            adapter = new SqlDataAdapter("SELECT O.KIMLIK_ID, O.TC, O.AD, O.SOYAD, " +
                    "O.DOGUM_YERI, O.EMAIL, O.TELEFON, O.UNVAN_ID FROM OGRENCI O where PSF_ID is  null", conn);
            tablo = new DataTable();
            conn.Open();
            adapter.Fill(tablo);
            dataGridView1.DataSource = tablo;
            conn.Close();
        }

        private void cmbSec_SelectedIndexChanged(object sender, EventArgs e)
        {
            katilimciGoruntle();
        }
    }
}
