using DevExpress.Utils.Behaviors.Common;
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
    public partial class FrmCariListesi : Form
    {
        public FrmCariListesi()
        {
            InitializeComponent();
        }

        DBTeknikServisEntities db = new DBTeknikServisEntities();
        void Listele()
        {
            var deger = from x in db.TBLCARI
                        select new
                        {
                            x.ID,
                            x.AD,
                            x.SOYAD,
                            x.IL,
                            x.ILCE
                        };
            gridControl1.DataSource = deger.ToList();
            gridView1.OptionsBehavior.Editable = false;
        }

        void temizle()
        {
            TxtId.Text = "";
            TxtAd.Text = "";
            TxtSoyad.Text = "";
            TxtTelefon.Text = "";
            TxtVergiDairesi.Text = "";
            TxtVergiNo.Text = "";
            TxtBanka.Text = "";
            TxtAdres.Text = "";
            lookUpEdit1.EditValue = null;
            lookUpEdit2.EditValue = null;
        }


        void il()
        {
            var ildegeri = from x in db.TBLIL
                           select new
                           {
                               x.ID,
                               x.SEHIRADI
                           };
        }

        private void FrmCariListesi_Load(object sender, EventArgs e)
        {
            Listele();

            labelControl11.Text = db.TBLCARI.Count().ToString();


            labelControl13.Text = db.TBLCARI.Count(x => x.STATU == "AKTİF").ToString();


            labelControl21.Text = db.TBLCARI.GroupBy(c => c.IL).OrderByDescending(g => g.Count()).FirstOrDefault()?.Key;



            labelControl15.Text = (from x in db.TBLCARI
                                   select x.ILCE).Distinct().Count().ToString();

            labelControl17.Text = (from x in db.TBLCARI
                                   select x.IL).Distinct().Count().ToString();


            labelControl19.Text = db.TBLCARI.Count(x => x.STATU == "PASİF").ToString();


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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            //
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

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TBLCARI t = new TBLCARI();
            t.AD = TxtAd.Text.ToUpper();
            t.SOYAD = TxtSoyad.Text.ToUpper();
            t.IL = lookUpEdit1.Text;
            t.ILCE = lookUpEdit2.Text;
            db.TBLCARI.Add(t);
            db.SaveChanges();
            Listele();
            temizle();
            MessageBox.Show("Cari Sisteme Eklendi");
        }
    }
}
