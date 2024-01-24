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
    public partial class egitim_Goruntule : Form
    {
        public egitim_Goruntule()
        {
            InitializeComponent();
        }

        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter adapter;
        DataTable tablo;

        void egitimGoruntule()
        {
            conn = new SqlConnection("Data Source=KARAGOZ;Initial Catalog=egitim;Integrated Security=True");
            adapter = new SqlDataAdapter("SELECT EGITIM_ID, EGITIM_KODU, EGITIM_ADI, EGITIM_TUR_ID,  EGITIM_KONU, " +
                "EGITIM_YER, EGITIM_ACK, EGITIM_SERTIFIKA, EGITIM_DURUM_TUR_ID, EGITIM_DURUM_ACK," +
                "EGITIM_KATILIMCI_SAYI, EGITIM_GECME_NOTU, EGITIM_SINAV_ID, EGITIM_ZAMAN.ZAMAN_ID, " +
                "BASLANGIC_TRH, BITIS_TRH, BASLANGIC_SAAT, BITIS_SAAT, SURE, EGITMEN.EGITMEN_ID, AD, SOYAD, UNVAN " +
                "FROM EGITIM,EGITIM_ZAMAN,EGITMEN WHERE EGITIM.ZAMAN_ID = EGITIM_ZAMAN.ZAMAN_ID AND EGITIM.EGITMEN_ID=EGITMEN.EGITMEN_ID", conn);
            tablo = new DataTable();
            conn.Open();
            adapter.Fill(tablo);
            dataGridView1.DataSource = tablo;
            conn.Close();
        }

        private void egitim_Goruntule_Load(object sender, EventArgs e)
        {
            egitimGoruntule();
           
        }
    }
}
