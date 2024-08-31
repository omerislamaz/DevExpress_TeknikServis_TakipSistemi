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
    public partial class FrmUrunSatis : Form
    {
        public FrmUrunSatis()
        {
            InitializeComponent();
        }

        DBTeknikServisEntities db = new DBTeknikServisEntities();

        void Temizle()
        {
            lookUpEdit1.EditValue = null;
            lookUpEdit2.EditValue = null;
            lookUpEdit3.EditValue = null;
            TxtTarih.Text = "";
            TxtAdet.Text = "";
            TxtSatisFiyat.Text = "";
            TxtSeriNo.Text = "";
        }
        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TBLURUNHAREKET t = new TBLURUNHAREKET();
            t.URUN = int.Parse(lookUpEdit1.EditValue.ToString());
            t.MUSTERI = int.Parse(lookUpEdit2.EditValue.ToString());
            t.PERSONEL = short.Parse(lookUpEdit3.EditValue.ToString());
            t.TARIH = DateTime.Parse(TxtTarih.Text);
            t.ADET = short.Parse(TxtAdet.Text);
            t.FIYAT = decimal.Parse(TxtSatisFiyat.Text);
            t.URUNSERINO = TxtSeriNo.Text.ToUpper();
            db.TBLURUNHAREKET.Add(t);
            db.SaveChanges();
            Temizle();
            MessageBox.Show("Ürün Satışı Yapıldı");
        }

        private void FrmUrunSatis_Load(object sender, EventArgs e)
        {

            //
            var urun = from x in db.TBLURUN
                       select new
                       {
                           x.ID,
                           x.AD
                       };
            lookUpEdit1.Properties.DataSource = urun.ToList();
            // 1-->> vtye ait sütunları lookupeditte göstermek için kullanılır
            lookUpEdit1.Properties.PopulateColumns();
            // 2-->> gizlenmesi istenilen sütunları belirler
            lookUpEdit1.Properties.Columns["ID"].Visible = false;



            //
            var cari = from x in db.TBLCARI
                       select new
                       {
                           x.ID,
                           Musteri = x.AD + " " + x.SOYAD
                       };
            lookUpEdit2.Properties.DataSource = cari.ToList();

            // 1-->> vtye ait sütunları lookupeditte göstermek için kullanılır
            lookUpEdit2.Properties.PopulateColumns();

            // 2-->> gizlenmesi istenilen sütunları belirler
            lookUpEdit2.Properties.Columns["ID"].Visible = false;


            //
            var pers = from x in db.TBLPERSONEL
                       select new
                       {
                           x.ID,
                           Personel = x.AD + " " + x.SOYAD
                       };
            lookUpEdit3.Properties.DataSource = pers.ToList();
            // 1-->> vtye ait sütunları lookupeditte göstermek için kullanılır
            lookUpEdit3.Properties.PopulateColumns();
            // 2-->> gizlenmesi istenilen sütunları belirler
            lookUpEdit3.Properties.Columns["ID"].Visible = false;
        }

        private void TxtTarih_MouseClick(object sender, MouseEventArgs e)
        {
            //
        }

        private void TxtTarih_Click(object sender, EventArgs e)
        {
            TxtTarih.Text = DateTime.Now.ToString("d");

        }
    }
}
