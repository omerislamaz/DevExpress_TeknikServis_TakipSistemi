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
    public partial class FrmCariEkle : Form
    {

        DBTeknikServisEntities db=new DBTeknikServisEntities();
        void Temizle()
        {
            TxtAciklama.Text = "";
            TxtAd.Text = "";
            TxtSoyad.Text = "";
            TxtTelefon.Text = "";
            TxtMail.Text = "";
            lookUpEdit1.EditValue = null;
            lookUpEdit2.EditValue = null;
            TxtBanka.Text = "";
            TxtVergiDairesi.Text = "";
            TxtVergiNo.Text = "";
            TxtStatü.Text = "";
            TxtAdres.Text = "";
            TxtAciklama.Text = "";
        }
        public FrmCariEkle()
        {
            InitializeComponent();
        }

        private void pictureEdit13_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void pictureEdit13_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            DialogResult vazgec=MessageBox.Show("İşlem İptal Edilecek, Onaylıyor musun ?","Onay",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (vazgec == DialogResult.Yes)
            {
                this.Close();
            }
            else if(vazgec == DialogResult.No)
            {
                //
            }
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TBLCARI t= new TBLCARI();
            t.AD=TxtAd.Text.ToUpper();
            t.SOYAD=TxtSoyad.Text.ToUpper();
            t.TELEFON = TxtTelefon.Text;
            t.IL=lookUpEdit1.Text.ToUpper();
            t.ILCE=lookUpEdit2.Text.ToUpper();
            t.BANKA=TxtBanka.Text.ToUpper();
            t.VERGIDAIRESI=TxtVergiDairesi.Text.ToUpper();
            t.VERGINO = TxtVergiNo.Text;
            t.STATU=TxtStatü.Text.ToUpper();
            t.ADRES=TxtAdres.Text.ToUpper();
            db.TBLCARI.Add(t);
            db.SaveChanges();
            MessageBox.Show("Yeni Cari Sisteme Başarıyla Eklendi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            Temizle();
        }

        private void FrmCariEkle_Load(object sender, EventArgs e)
        {
            var ildegeri = from x in db.TBLIL
                           select new
                           {
                               x.ID,
                               x.SEHIRADI
                           };
            lookUpEdit1.Properties.DataSource = ildegeri.ToList();
            lookUpEdit1.Properties.PopulateColumns();
            lookUpEdit1.Properties.Columns["ID"].Visible = false;


        }

        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {

            int il = Convert.ToInt32(lookUpEdit1.EditValue);
            var ilcedegeri = (from x in db.TBLILCE.Where(X => X.SEHIR == il)
                              select new
                              {
                                  x.ID,
                                  x.ILCEADI
                              }).ToList();
            lookUpEdit2.Properties.DataSource = ilcedegeri.ToList();
            lookUpEdit2.Properties.PopulateColumns();
            lookUpEdit2.Properties.Columns["ID"].Visible = false;
        }
    }
}
