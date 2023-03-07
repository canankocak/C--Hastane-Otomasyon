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

namespace Proje_Hastane_Otomasyon
{
    public partial class FrmHastaGiris : Form
    {
        public FrmHastaGiris()
        {
            InitializeComponent();
        }
        SqlBaglantisi bgl = new SqlBaglantisi();
        private void LnkUye_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Hasta üye olmak istediğinde onu kayıt arayüzüne ulaştırır.
            FrmHastaKayit fr = new FrmHastaKayit();
            fr.Show();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            //KAYIT YAPAN HASTANIN GİRİŞ EKRANINA GİRDİĞİ TC VE ŞİFRESİ İLE HASTA DETAY ARAYÜZÜNÜ AÇMASI
            SqlCommand komut = new SqlCommand("Select * From Tbl_Hastalar Where HastaTc=@p1 and HastaSifre=@p2", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", MskTc.Text);
            komut.Parameters.AddWithValue("@p2", TxtSifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                FrmHastaDetay fr = new FrmHastaDetay();
                fr.tc=MskTc.Text;
                fr.Show();
                this.Hide();
            } //EĞER DOĞRU TC VE ŞİFRE GİRDİYSE ÜSTTEKİ KODLARLA HASTA DETAYA GİRİŞ YAPABİLDİ.
            else
            {
                MessageBox.Show("Hatalı TC veya şifre","BİLGİ",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            bgl.baglanti().Close();
        }

        private void BtnGeri_Click(object sender, EventArgs e)
        {
            FrmGirisler fg = new FrmGirisler();
            fg.Show();
            this.Hide();
        }
    }
}
