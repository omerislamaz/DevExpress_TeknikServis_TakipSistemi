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
    public partial class FrmYeniUrun : Form
    {
        public FrmYeniUrun()
        {
            InitializeComponent();
        }
        DBTeknikServisEntities db = new DBTeknikServisEntities();

        private void FrmYeniUrun_Load(object sender, EventArgs e)
        {
            lookUpEdit1.Properties.DataSource = (from x in db.TBLKATEGORI
                                                 select new
                                                 {
                                                     x.ID,
                                                     x.AD,
                                                 }).ToList();
            lookUpEdit1.Properties.PopulateColumns();
            lookUpEdit1.Properties.Columns["ID"].Visible = false;
        }

        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            DBTeknikServisEntities db = new DBTeknikServisEntities();
            TBLURUN t = new TBLURUN();
            t.AD = TxtUrunAd.Text.ToUpper();
            t.ALISFIYAT = decimal.Parse(TxtAlisFiyat.Text);
            t.SATISFIYAT = decimal.Parse(TxtSatisFiyat.Text);
            t.STOK = short.Parse(TxtStok.Text);
            t.KATEGORI = byte.Parse(lookUpEdit1.EditValue.ToString());
            t.MARKA = TxtMarka.Text.ToUpper();
            db.TBLURUN.Add(t);
            db.SaveChanges();
            MessageBox.Show("Ürünler Başarıyla Kaydedildi");
        }

        private void TxtUrunAd_Click(object sender, EventArgs e)
        {
            TxtUrunAd.Text = "";
            TxtUrunAd.Focus();
        }
    }
}
