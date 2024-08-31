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
    public partial class FrmFaturaKalem : Form
    {
        public FrmFaturaKalem()
        {
            InitializeComponent();
        }

        DBTeknikServisEntities db = new DBTeknikServisEntities();

        void Listele()
        {
            gridView1.OptionsBehavior.Editable = false;
            var degerler = from x in db.TBLFATURADETAY
                           select new
                           {
                               x.FATURADETAYID,
                               x.URUN,
                               x.ADET,
                               x.FIYAT,
                               x.TUTAR,
                               x.FATURAID,
                           };

            LkpUrun.Properties.DataSource = (from x in db.TBLURUN
                                             select new
                                             {
                                                 x.ID,
                                                 x.AD,
                                             }).ToList();


            gridControl1.DataSource = degerler.ToList();

        }

        void Temizle()
        {
            TxtFaturaID.Text = "";
            TxtId.Text = "";
            TxtAdet.Text = "";
            TxtFiyat.Text = "";
            TxtTutar.Text = "";
            LkpUrun.Text = "";
        }
        private void FrmFaturaKalem_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TBLFATURADETAY t = new TBLFATURADETAY();
            int urunid = Convert.ToInt32(LkpUrun.EditValue);
            var dgr = db.TBLURUN.Where(x => x.ID == urunid).Select(y => y.AD).FirstOrDefault();
            t.URUN = dgr;
            t.ADET = short.Parse(TxtAdet.Text);
            t.FIYAT = decimal.Parse(TxtFiyat.Text);
            t.TUTAR = decimal.Parse(TxtTutar.Text);
            t.FATURAID = int.Parse(TxtFaturaID.Text);
            db.TBLFATURADETAY.Add(t);
            db.SaveChanges();
            MessageBox.Show(dgr + ", " + TxtFaturaID.Text + " No'lu faturaya eklendi");
            Temizle();
            Listele();

        }

        private void LkpUrun_EditValueChanged(object sender, EventArgs e)
        {
            int urun = Convert.ToInt32(LkpUrun.EditValue);
            decimal satisfiyat = db.TBLURUN.Where(x => x.ID == urun).Select(y => (decimal)y.SATISFIYAT).FirstOrDefault();

            TxtFiyat.Text = satisfiyat.ToString("F2");

        }

        private void TxtAdet_TextChanged(object sender, EventArgs e)
        {
            int adet;
            decimal fiyat, tutar;
            if (string.IsNullOrEmpty(TxtAdet.Text))
            {
                TxtAdet.Text = "0";
                TxtTutar.Text = "0";
            }
            else
            {
                adet = int.Parse(TxtAdet.Text);
                fiyat = decimal.Parse(TxtFiyat.Text);
                tutar = adet * fiyat;
                TxtTutar.Text = tutar.ToString("F2");

            }

        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
