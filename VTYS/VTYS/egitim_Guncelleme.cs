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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using System.ComponentModel.Design;

namespace VTYS
{
    public partial class egitim_Guncelleme : Form
    {
        public egitim_Guncelleme()
        {
            InitializeComponent();
        }
        SqlConnection Baglanti = new SqlConnection(@"Data Source=KARAGOZ;Initial Catalog=egitim;Integrated Security=True");


        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter adapter;
        DataTable tablo;

        private void btn_guncelle_Click(object sender, EventArgs e)
        {
            Baglanti.Open();
            SqlCommand commandAdd1 = new SqlCommand("UPDATE EGITIM SET EGITIM_KODU=@EGITIM_KODU, EGITIM_ADI=@EGITIM_ADI, " +
                "EGITIM_TUR_ID=@EGITIM_TUR_ID, ZAMAN_ID=@ZAMAN_ID, EGITMEN_ID=@EGITMEN_ID, EGITIM_KONU=@EGITIM_KONU, " +
                "EGITIM_YER=@EGITIM_YER, EGITIM_ACK=@EGITIM_ACK, EGITIM_SERTIFIKA=@EGITIM_SERTIFIKA, EGITIM_DURUM_TUR_ID=@EGITIM_DURUM_TUR_ID," +
                "EGITIM_DURUM_ACK=@EGITIM_DURUM_ACK,EGITIM_KATILIMCI_SAYI=@EGITIM_KATILIMCI_SAYI, EGITIM_GECME_NOTU=@EGITIM_GECME_NOTU, " +
                "EGITIM_SINAV_ID= @EGITIM_SINAV_ID WHERE EGITIM_ID = @EGITIM_ID", Baglanti);
            SqlCommand commandAdd2 = new SqlCommand("UPDATE EGITMEN SET AD=@AD, SOYAD=@SOYAD, UNVAN=@UNVAN WHERE EGITMEN_ID = @EGITMEN_ID", Baglanti);
            SqlCommand commandAdd = new SqlCommand("UPDATE EGITIM_ZAMAN SET BASLANGIC_TRH=@BASLANGIC_TRH, BITIS_TRH=@BITIS_TRH, " +
                "BASLANGIC_SAAT=@BASLANGIC_SAAT, BITIS_SAAT=@BITIS_SAAT, SURE=@SURE WHERE ZAMAN_ID = @ZAMAN_ID", Baglanti);
            try
            {
                commandAdd1.Parameters.AddWithValue("@EGITIM_ID", txt_egitimId.Text);
                commandAdd1.Parameters.AddWithValue("@EGITIM_KODU", txt_egitimKodu.Text);
                commandAdd1.Parameters.AddWithValue("@EGITIM_ADI", txt_egitimAdi.Text);
                commandAdd1.Parameters.AddWithValue("@EGITIM_TUR_ID", int.Parse(txt_egitimTurId.Text));
                commandAdd1.Parameters.AddWithValue("@ZAMAN_ID", int.Parse(txt_zamanId.Text));
                commandAdd1.Parameters.AddWithValue("@EGITMEN_ID", int.Parse(txt_egitmenId.Text));
                commandAdd1.Parameters.AddWithValue("@EGITIM_KONU", txt_egitimKonu.Text);
                commandAdd1.Parameters.AddWithValue("@EGITIM_YER", txt_egitimYer.Text);
                commandAdd1.Parameters.AddWithValue("@EGITIM_ACK", txt_egitimAck.Text);
                commandAdd1.Parameters.AddWithValue("@EGITIM_SERTIFIKA", Convert.ToInt16(checkbox1.Checked));
                commandAdd1.Parameters.AddWithValue("@EGITIM_DURUM_TUR_ID", int.Parse(txt_egitimDurumTurId.Text));
                commandAdd1.Parameters.AddWithValue("@EGITIM_DURUM_ACK", txt_egitimDurumAck.Text);
                commandAdd1.Parameters.AddWithValue("@EGITIM_KATILIMCI_SAYI", int.Parse(txt_egitimKatilimciSayi.Text));
                commandAdd1.Parameters.AddWithValue("@EGITIM_GECME_NOTU", decimal.Parse(txt_egitimGecmeNotu.Text));
                commandAdd1.Parameters.AddWithValue("@EGITIM_SINAV_ID", int.Parse(txt_egitimSinavId.Text));
                commandAdd1.ExecuteNonQuery();
            }
            catch (Exception)
            {

                MessageBox.Show("Veri tiplerini doğru giriniz.");
            }
            try
            {
                commandAdd2.Parameters.AddWithValue("@EGITMEN_ID", int.Parse(txt_egitmenId.Text));
                commandAdd2.Parameters.AddWithValue("@AD", txt_egitmenAdi.Text);
                commandAdd2.Parameters.AddWithValue("@SOYAD", txt_egitmenSoyadi.Text);
                commandAdd2.Parameters.AddWithValue("@UNVAN", txt_egitmenUnvani.Text);
                commandAdd2.ExecuteNonQuery();
            }
            catch (Exception)
            {

                MessageBox.Show("Veri tiplerini doğru giriniz.");
            }
            try
            {
                commandAdd.Parameters.AddWithValue("@ZAMAN_ID", int.Parse(txt_zamanId.Text));
                commandAdd.Parameters.AddWithValue("@BASLANGIC_TRH", datetime_BaslangicTarihiUpdate.Value);
                commandAdd.Parameters.AddWithValue("@BITIS_TRH", datetime_BitisTarihiUpdate.Value);
                commandAdd.Parameters.AddWithValue("@BASLANGIC_SAAT", int.Parse(txt_baslangicSaati.Text));
                commandAdd.Parameters.AddWithValue("@BITIS_SAAT", int.Parse(txt_bitisSaati.Text));
                commandAdd.Parameters.AddWithValue("@SURE", int.Parse(txt_sure.Text));
                commandAdd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                MessageBox.Show("Veri tiplerini doğru giriniz.");
            }
            guncel();
            Baglanti.Close();

        }

        void guncel() {
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
        private void egitim_Guncelleme_Load(object sender, EventArgs e)
        {
            guncel();

        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            txt_egitimId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txt_egitimKodu.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txt_egitimAdi.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txt_egitimTurId.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txt_egitimKonu.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txt_egitimYer.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txt_egitimAck.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            if (int.Parse(dataGridView1.CurrentRow.Cells[7].Value.ToString()) == 1)
            {
                checkbox1.Checked = true;
            }
            else 
            {
                checkbox1.Checked = false;
            }
            txt_egitimDurumTurId.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            txt_egitimDurumAck.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            txt_egitimKatilimciSayi.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            txt_egitimGecmeNotu.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
            txt_egitimSinavId.Text = dataGridView1.CurrentRow.Cells[12].Value.ToString();
            txt_zamanId.Text = dataGridView1.CurrentRow.Cells[13].Value.ToString();
            datetime_BaslangicTarihiUpdate.Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[14].Value);
            datetime_BitisTarihiUpdate.Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[15].Value);
            txt_baslangicSaati.Text = dataGridView1.CurrentRow.Cells[16].Value.ToString();
            txt_bitisSaati.Text = dataGridView1.CurrentRow.Cells[17].Value.ToString();
            txt_sure.Text = dataGridView1.CurrentRow.Cells[18].Value.ToString();
            txt_egitmenId.Text = dataGridView1.CurrentRow.Cells[19].Value.ToString();
            txt_egitmenAdi.Text = dataGridView1.CurrentRow.Cells[20].Value.ToString();
            txt_egitmenSoyadi.Text = dataGridView1.CurrentRow.Cells[21].Value.ToString();
            txt_egitmenUnvani.Text = dataGridView1.CurrentRow.Cells[22].Value.ToString();


        }
    }
}
