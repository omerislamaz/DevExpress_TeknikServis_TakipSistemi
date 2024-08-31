using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeknikServis.Formlar
{
    public partial class FrmYeniKategori : Form
    {

        DBTeknikServisEntities db = new DBTeknikServisEntities();
        public FrmYeniKategori()
        {
            InitializeComponent();
        }

        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (TxtKategoriAd.Text != "" && TxtKategoriAd.Text.Length <= 30)
            {
                TBLKATEGORI t = new TBLKATEGORI();
                t.AD = TxtKategoriAd.Text.ToUpper();
                db.TBLKATEGORI.Add(t);
                db.SaveChanges();
                MessageBox.Show("Yeni Kategori Başarıyla Kayıt Edildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtKategoriAd.Text = "";
                this.Close();
                Formlar.FrmKategori fr = new FrmKategori();
                fr.Show();
            }
            else
            {
                MessageBox.Show("Lütfen karakter sayısını 0-30 arasında giriniz", "Uyaro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void pictureEdit2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
