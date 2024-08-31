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
    public partial class FrmFaturaListesi : Form
    {
        public FrmFaturaListesi()
        {
            InitializeComponent();
        }

        DBTeknikServisEntities db = new DBTeknikServisEntities();
        void Temizle()
        {
            TxtId.Text = "";
            TxtSeri.Text = "";
            TxtSiraNo.Text = "";
            TxtTarih.Text = "";
            TxtSaat.Text = "";
            TxtVergiDairesi.Text = "";
            LkpCari.EditValue = "";
            LkpPersonel.EditValue = "";
        }

        void Listele()
        {
            gridView1.OptionsBehavior.Editable = false;

            var deger = (from x in db.TBLFATURABILGI
                         select new
                         {
                             x.ID,
                             x.SERI,
                             x.SIRANO,
                             x.TARIH,
                             x.SAAT,
                             x.VERGIDAIRE,
                             CARİ = x.TBLCARI.AD + " " + x.TBLCARI.SOYAD,
                             PERSONEL = x.TBLPERSONEL.AD + " " + x.TBLPERSONEL.SOYAD
                         });
            gridControl1.DataSource = deger.ToList();


            LkpCari.Properties.DataSource = (from x in db.TBLCARI
                                             select new
                                             {
                                                 x.ID,
                                                 TANIM = x.AD + " " + x.SOYAD,
                                             }).ToList();
            LkpPersonel.Properties.DataSource = (from x in db.TBLPERSONEL
                                                 select new
                                                 {
                                                     x.ID,
                                                     TANIM = x.AD + " " + x.SOYAD,
                                                 }).ToList();

            TxtSaat.Text = DateTime.Now.ToString("t");
            TxtTarih.Text = DateTime.Now.ToString("d");

        }
        private void FrmFaturaListesi_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void BtnFormTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TBLFATURABILGI t = new TBLFATURABILGI();
            t.SERI = TxtSeri.Text.ToUpper();
            t.SIRANO = TxtSiraNo.Text.ToUpper();
            t.TARIH = Convert.ToDateTime(TxtTarih.Text);
            t.SAAT = TxtSaat.Text;
            t.VERGIDAIRE = TxtVergiDairesi.Text.ToUpper();
            t.CARI = int.Parse(LkpCari.EditValue.ToString());
            t.PERSONEL = short.Parse(LkpPersonel.EditValue.ToString());
            db.TBLFATURABILGI.Add(t);
            db.SaveChanges();
            MessageBox.Show("Fatura Sisteme kayıt edildi. Kalem girişi yapabilirsin.");
            Temizle();
            Listele();
            TxtSaat.Text = DateTime.Now.ToString("t");
            TxtTarih.Text = DateTime.Now.ToString("d");
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
           Formlar.FrmFaturaKalemPopup fr=new FrmFaturaKalemPopup();
            fr.faturakalemid=int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
            fr.Show();
        }
    }
}
