using DevExpress.XtraEditors;
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
    public partial class FrmArizaliUrunKaydi : Form
    {
        public FrmArizaliUrunKaydi()
        {
            InitializeComponent();
        }
        DBTeknikServisEntities db = new DBTeknikServisEntities();

        void temizle()
        {
            TxtSeriNo.Text = "";
            lookUpEdit1.Text = "";
            lookUpEdit2.Text = "";

            TxtTarih.Text = "";
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {

            TBLURUNKABUL t = new TBLURUNKABUL();
            string cari = TxtSeriNo.Text;

            t.CARI = int.Parse(lookUpEdit1.EditValue.ToString());
            t.GELISTARIHI = DateTime.Parse(TxtTarih.Text);
            t.PERSONEL = short.Parse(lookUpEdit2.EditValue.ToString());
            t.URUNSERINO = TxtSeriNo.Text;
            t.URUNDURUMDETAY = "Ürün Kayıt Oldu";
            db.TBLURUNKABUL.Add(t);
            db.SaveChanges();
            temizle();
            MessageBox.Show("Arıza Kaydı Oluşturuldu");

        }

        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmArizaliUrunKaydi_Load(object sender, EventArgs e)
        {
            //Müşteri
            lookUpEdit1.Properties.DataSource = (from x in db.TBLCARI
                                                 select new
                                                 {
                                                     x.ID,
                                                     MÜŞTERİ = x.AD + " " + x.SOYAD,
                                                 }).ToList();
            lookUpEdit1.Properties.PopulateColumns();
            lookUpEdit1.Properties.Columns["ID"].Visible = false;

            //Personel
            lookUpEdit2.Properties.DataSource = (from x in db.TBLPERSONEL
                                                 select new
                                                 {
                                                     x.ID,
                                                     PERSONEL = x.AD + " " + x.SOYAD,
                                                 }).ToList();
            lookUpEdit2.Properties.PopulateColumns();
            lookUpEdit2.Properties.Columns["ID"].Visible = false;

        }

        private void TxtTarih_Click(object sender, EventArgs e)
        {
            TxtTarih.Text = DateTime.Now.ToShortDateString();
        }
    }
}
