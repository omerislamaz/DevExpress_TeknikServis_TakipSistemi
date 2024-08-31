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
    public partial class FrmNotlar : Form
    {
        public FrmNotlar()
        {
            InitializeComponent();
        }

        DBTeknikServisEntities db = new DBTeknikServisEntities();

        void Listele()
        {
            gridControl1.DataSource = db.TBLNOTLARIM.Where(x => x.DURUM == false).ToList();
            gridControl2.DataSource = db.TBLNOTLARIM.Where(x => x.DURUM == true).ToList();
            gridView1.OptionsBehavior.Editable = false;
            gridView2.OptionsBehavior.Editable = false;
        }

        void temizle()
        {
            TxtBaslik.Text = "";
            TxtIcerik.Text = "";
            TxtId.Text = "";
            ChkDurum.Checked = false;
        }


        private void FrmNotlar_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TBLNOTLARIM t = new TBLNOTLARIM();
            t.BASLIK = TxtBaslik.Text.ToUpper();
            t.ICERIK = TxtIcerik.Text;
            t.TARIH = DateTime.Parse(TxtTarih.Text);
            t.KAYITTARIH = DateTime.Parse(DateTime.Now.ToLongDateString());
            t.DURUM = false;
            db.TBLNOTLARIM.Add(t);
            db.SaveChanges();
            MessageBox.Show("Not başarıyla kayıt edildi", "Başlık", MessageBoxButtons.OK, MessageBoxIcon.Information);
            temizle();
            Listele();

        }

        private void BtnFormTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            if (ChkDurum.Checked == true)
            {
                int id = int.Parse(TxtId.Text);
                var deger = db.TBLNOTLARIM.Find(id);
                deger.BASLIK = TxtBaslik.Text.ToUpper();
                deger.ICERIK = TxtIcerik.Text;
                deger.DURUM = true;
            }
            else if (ChkDurum.Checked == false)
            {
                int id = int.Parse(TxtId.Text);
                var deger = db.TBLNOTLARIM.Find(id);
                deger.BASLIK = TxtBaslik.Text.ToUpper();
                deger.ICERIK = TxtIcerik.Text;
                deger.DURUM = false;
            }
            db.SaveChanges();
            MessageBox.Show("Not başarıyla güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
            temizle();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            TxtId.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            TxtBaslik.Text = gridView1.GetFocusedRowCellValue("BASLIK").ToString();
            TxtIcerik.Text = gridView1.GetFocusedRowCellValue("ICERIK").ToString();
            ChkDurum.Checked = false;

        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            TxtId.Text = gridView2.GetFocusedRowCellValue("ID").ToString();
            TxtBaslik.Text = gridView2.GetFocusedRowCellValue("BASLIK").ToString();
            TxtIcerik.Text = gridView2.GetFocusedRowCellValue("ICERIK").ToString();
            ChkDurum.Checked = true;
        }
    }
}
