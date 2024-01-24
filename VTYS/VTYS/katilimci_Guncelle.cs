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
using System.Security.Cryptography;

namespace VTYS
{
    public partial class katilimci_Guncelle : Form
    {
        public katilimci_Guncelle()
        {
            InitializeComponent();
        }

        SqlConnection Baglanti = new SqlConnection(@"Data Source=KARAGOZ;Initial Catalog=egitim;Integrated Security=True");
        

        private void btn_guncelle_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("UPDATE_Katılımcı", Baglanti);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TC", txt_tc.Text); // Örnek veritabanına ekleme şekli
            cmd.Parameters.AddWithValue("@AD", txt_ad.Text);
            cmd.Parameters.AddWithValue("@SOYAD", txt_soyad.Text);
            cmd.Parameters.AddWithValue("@DOGUM_IL_ID", int.Parse(txt_dogumIlId.Text));
            cmd.Parameters.AddWithValue("@DOGUM_YERI", txt_dogumYeri.Text);
            cmd.Parameters.AddWithValue("@DOGUM_TRH", datetime_DogumTarihiUpdate.Value);
            cmd.Parameters.AddWithValue("@EMAIL", txt_email.Text);
            cmd.Parameters.AddWithValue("@TELEFON", txt_telefon.Text);
            cmd.Parameters.AddWithValue("@UNVAN_ID", int.Parse(txt_unvanId.Text));
            cmd.Parameters.AddWithValue("@KIMLIK_ID", txt_kimlikId.Text);

            Baglanti.Open();
            cmd.ExecuteNonQuery();
            Baglanti.Close();

        }
        private void btn_bul_Click(object sender, EventArgs e)
        {
            Baglanti.Open();
            SqlCommand cmd = new SqlCommand("SELECT_Katılımcı", Baglanti);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TC", txt_tc.Text);
            SqlDataReader oku = cmd.ExecuteReader();
            while (oku.Read())
            {
                txt_kimlikId.Text = oku["KIMLIK_ID"].ToString();
                txt_ad.Text = oku["AD"].ToString();
                txt_soyad.Text = oku["SOYAD"].ToString();
                txt_dogumIlId.Text = oku["DOGUM_IL_ID"].ToString();
                txt_dogumYeri.Text = oku["DOGUM_YERI"].ToString();
                datetime_DogumTarihiUpdate.Value = (DateTime)oku["DOGUM_TRH"];
                txt_email.Text = oku["EMAIL"].ToString();
                txt_telefon.Text = oku["TELEFON"].ToString();
                txt_unvanId.Text = oku["UNVAN_ID"].ToString();
            }
            Baglanti.Close();
        }

    }
}
