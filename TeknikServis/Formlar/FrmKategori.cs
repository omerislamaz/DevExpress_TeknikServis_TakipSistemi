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
    public partial class FrmKategori : Form
    {
        public FrmKategori()
        {
            InitializeComponent();
        }

        DBTeknikServisEntities db = new DBTeknikServisEntities();

        void Listele()
        {
            // var degerler = db.TBLKATEGORI.ToList();
            var sutunlar = from x in db.TBLKATEGORI
                           select new
                           {
                               x.ID,
                               x.AD,
                           };
            gridControl1.DataSource = sutunlar.ToList();
            gridView1.OptionsBehavior.Editable = false;
        }
        private void FrmKategori_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {

            if (TxtAd.Text != "" && TxtAd.Text.Length <= 30)
            {
                TBLKATEGORI t = new TBLKATEGORI();
                t.AD = TxtAd.Text.ToUpper();
                db.TBLKATEGORI.Add(t);
                db.SaveChanges();
                MessageBox.Show("Kategori Başarıyla Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                TxtAd.Text = "";
                Listele();
            }
            else
            {
                MessageBox.Show("Kategori Adı Boş Geçilemez ve Kategori Adı 30 Karakterden Izun Olamaz", "BILGI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            // gridview üzerindeki satıra 1 kere tıklama ile değerleri, textbox araçlarına aktarma alanı  
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            TxtId.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            TxtAd.Text = gridView1.GetFocusedRowCellValue("AD").ToString();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            DialogResult sil = MessageBox.Show("Veri Silinecektir. Onaylıyor musunuz?","Onay",MessageBoxButtons.YesNo,MessageBoxIcon.Question);

            if (sil == DialogResult.Yes)
            {
                int id = int.Parse(TxtId.Text);
                var deger = db.TBLKATEGORI.Find(id);
                db.TBLKATEGORI.Remove(deger);
                db.SaveChanges();
                MessageBox.Show("Kategori Başarı ile Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Listele();
                TxtAd.Text = "";
                TxtId.Text = "";
            }
            else if (sil == DialogResult.No)
            {
                MessageBox.Show("Silme İşlemi İptal Edildi");
            }

        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtId.Text);
            var deger = db.TBLKATEGORI.Find(id);
            deger.AD = TxtAd.Text.ToUpper();
            db.SaveChanges();
            MessageBox.Show("Kategori Başarı ile Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            Listele();
            TxtAd.Text = "";
            TxtId.Text = "";
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            Listele();
        }
    }
}
