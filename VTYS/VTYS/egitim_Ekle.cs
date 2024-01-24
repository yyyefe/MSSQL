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
using System.ComponentModel.Design;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace VTYS
{
    public partial class egitim_Ekle : Form
    {
        public egitim_Ekle()
        {
            InitializeComponent();
        }

        void ekle()
        {
            string BaglantiAdresi = "Data Source=KARAGOZ;Initial Catalog=egitim;Integrated Security=True";
            SqlConnection Baglanti = new SqlConnection();
            Baglanti.ConnectionString = BaglantiAdresi;

            Baglanti.Open();

            if(txt_zamanId.Text == "")
            {
                SqlCommand commandAdd = new SqlCommand(" INSERT INTO EGITIM_ZAMAN(BASLANGIC_TRH, BITIS_TRH, BASLANGIC_SAAT, BITIS_SAAT, SURE)" +
                "VALUES(@BASLANGIC_TRH, @BITIS_TRH, @BASLANGIC_SAAT, @BITIS_SAAT, @SURE)", Baglanti);

                try
                {
                    commandAdd.Parameters.AddWithValue("@BASLANGIC_TRH", datetime_baslangicTarihi.Value); // Örnek veritabanına ekleme şekli
                    commandAdd.Parameters.AddWithValue("@BITIS_TRH", datetime_BitisTarihi.Value);
                    commandAdd.Parameters.AddWithValue("@BASLANGIC_SAAT", int.Parse(txt_baslangicSaati.Text));
                    commandAdd.Parameters.AddWithValue("@BITIS_SAAT", int.Parse(txt_bitisSaati.Text));
                    commandAdd.Parameters.AddWithValue("@SURE", int.Parse(txt_sure.Text));
                    commandAdd.ExecuteNonQuery();
                }
                catch (Exception)
                {

                    MessageBox.Show("Veri tiplerini doğru giriniz.");
                }

                SqlCommand cmd_zaman = new SqlCommand("SELECT TOP 1 ZAMAN_ID FROM EGITIM_ZAMAN ORDER BY ZAMAN_ID DESC", Baglanti);

                SqlDataReader oku = cmd_zaman.ExecuteReader();
                while (oku.Read())
                {
                    txt_zamanId.Text = oku["ZAMAN_ID"].ToString();
                }
                oku.Close();
            }
            if(txt_egitmenId.Text == "")
            {

                SqlCommand commandAdd2 = new SqlCommand("INSERT INTO EGITMEN (AD, SOYAD, UNVAN)" +
                    "VALUES  (@AD, @SOYAD, @UNVAN)", Baglanti);

                try
                {
                    commandAdd2.Parameters.AddWithValue("@AD", txt_egitmenAdi.Text);
                    commandAdd2.Parameters.AddWithValue("@SOYAD", txt_egitmenSoyadi.Text);
                    commandAdd2.Parameters.AddWithValue("@UNVAN", txt_egitmenUnvani.Text);
                    commandAdd2.ExecuteNonQuery();
                }
                catch (Exception)
                {

                    MessageBox.Show("Veri tiplerini doğru giriniz.");
                }

                SqlCommand cmd_egıtmen = new SqlCommand("SELECT TOP 1 EGITMEN_ID FROM EGITMEN ORDER BY EGITMEN_ID DESC", Baglanti);

                SqlDataReader oku2 = cmd_egıtmen.ExecuteReader();
                while (oku2.Read())
                {
                    txt_egitmenId.Text = oku2["EGITMEN_ID"].ToString();
                }
                oku2.Close();
            }

            SqlCommand commandAdd1 = new SqlCommand("INSERT INTO EGITIM (EGITIM_KODU, EGITIM_ADI, EGITIM_TUR_ID," +
                "ZAMAN_ID, EGITMEN_ID, EGITIM_KONU, EGITIM_YER, EGITIM_ACK, EGITIM_SERTIFIKA, EGITIM_DURUM_TUR_ID, EGITIM_DURUM_ACK, " +
                "EGITIM_KATILIMCI_SAYI, EGITIM_GECME_NOTU, EGITIM_SINAV_ID) VALUES(@EGITIM_KODU, @EGITIM_ADI, @EGITIM_TUR_ID," +
                "@ZAMAN_ID, @EGITMEN_ID, @EGITIM_KONU, @EGITIM_YER, @EGITIM_ACK, @EGITIM_SERTIFIKA, @EGITIM_DURUM_TUR_ID, " +
                "@EGITIM_DURUM_ACK,@EGITIM_KATILIMCI_SAYI, @EGITIM_GECME_NOTU, @EGITIM_SINAV_ID)", Baglanti);

            try
            {
                commandAdd1.Parameters.AddWithValue("@EGITIM_KODU", txt_egitimKodu.Text);
                commandAdd1.Parameters.AddWithValue("@EGITIM_ADI", txt_egitimAdi.Text);
                commandAdd1.Parameters.AddWithValue("@EGITIM_TUR_ID", int.Parse(txt_egitimTurId.Text));
                commandAdd1.Parameters.AddWithValue("@ZAMAN_ID", int.Parse(txt_zamanId.Text));
                commandAdd1.Parameters.AddWithValue("@EGITMEN_ID", int.Parse(txt_egitmenId.Text));
                commandAdd1.Parameters.AddWithValue("@EGITIM_KONU", txt_egitimKonu.Text);
                commandAdd1.Parameters.AddWithValue("@EGITIM_YER", txt_egitimYer.Text);
                commandAdd1.Parameters.AddWithValue("@EGITIM_ACK", txt_egitimAck.Text);
                commandAdd1.Parameters.AddWithValue("@EGITIM_SERTIFIKA", Convert.ToInt16(check_sertifika.Checked));
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

            Baglanti.Close();

        }

        private void btn_egitimEkle_Click(object sender, EventArgs e)
        {
          
            ekle();
        }


      
        private void btn_kontrol_egitmen_Click(object sender, EventArgs e)
        {
            string BaglantiAdresi = "Data Source=KARAGOZ;Initial Catalog=egitim;Integrated Security=True";
            SqlConnection Baglanti = new SqlConnection();
            Baglanti.ConnectionString = BaglantiAdresi;
            SqlCommand cmd = new SqlCommand("SELECT * FROM EGITMEN WHERE AD = @AD AND SOYAD = @SOYAD", Baglanti);
            Baglanti.Open();
            cmd.Parameters.AddWithValue("@AD", txt_egitmenAdi.Text);
            cmd.Parameters.AddWithValue("@SOYAD", txt_egitmenSoyadi.Text);
            SqlDataReader oku = cmd.ExecuteReader();
            while (oku.Read())
            {
                txt_egitmenId.Text = oku["EGITMEN_ID"].ToString();
                txt_egitmenUnvani.Text = oku["UNVAN"].ToString();
            }
            Baglanti.Close();
        }
    }
}
