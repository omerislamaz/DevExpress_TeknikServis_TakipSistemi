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
    public partial class FrmPersonel : Form
    {

        DBTeknikServisEntities db = new DBTeknikServisEntities();
        public FrmPersonel()
        {
            InitializeComponent();
        }

        void Listele()
        {
            var tablo = (from x in db.TBLPERSONEL
                         select new
                         {
                             x.ID,
                             x.AD,
                             x.SOYAD,
                             DEPARTMAN = x.TBLDEPARTMAN.AD,
                             x.FOTOGRAF,
                             x.MAIL
                         });
            // var deger = db.TBLPERSONEL.ToList();
            gridControl1.DataSource = tablo.ToList();
            gridView1.OptionsBehavior.Editable = false;

            var Lookupdeger = (from y in db.TBLDEPARTMAN
                               select new
                               {
                                   y.ID,
                                   y.AD,
                               }).ToList();
            LkpDepartman.Properties.DataSource = Lookupdeger;

        }

        void Temizle()
        {
            TxtId.Text = "";
            TxtAd.Text = "";
            TxtSoyad.Text = "";
            TxtFotograf.Text = "";
            TxtTelefon.Text = "";
            LkpDepartman.EditValue = null;
        }

        private void FrmPersonel_Load(object sender, EventArgs e)
        {
            Listele();

            string ad1, soyad1, ad2, soyad2, ad3, soyad3, ad4, soyad4;

            //1.Personel
            ad1 = db.TBLPERSONEL.First(x => x.ID == 1).AD;
            soyad1 = db.TBLPERSONEL.First(x => x.ID == 1).SOYAD;
            labelControl6.Text = ad1 + " " + soyad1;
            labelControl8.Text = db.TBLPERSONEL.First(x => x.ID == 1).MAIL;
            labelControl7.Text = db.TBLPERSONEL.First(x => x.ID == 1).TBLDEPARTMAN.AD;

            //2.Personel
            ad2 = db.TBLPERSONEL.First(x => x.ID == 2).AD;
            soyad2 = db.TBLPERSONEL.First(x => x.ID == 2).SOYAD;
            labelControl11.Text = ad2 + " " + soyad2;
            labelControl10.Text = db.TBLPERSONEL.First(x => x.ID == 2).MAIL;
            labelControl9.Text = db.TBLPERSONEL.First(x => x.ID == 2).TBLDEPARTMAN.AD;

            //3.Personel
            ad3 = db.TBLPERSONEL.First(x => x.ID == 3).AD;
            soyad3 = db.TBLPERSONEL.First(x => x.ID == 3).SOYAD;
            labelControl24.Text = ad3 + " " + soyad3;
            labelControl23.Text = db.TBLPERSONEL.First(x => x.ID == 3).MAIL;
            labelControl22.Text = db.TBLPERSONEL.First(x => x.ID == 3).TBLDEPARTMAN.AD;

            //4.Personel
            ad4 = db.TBLPERSONEL.First(x => x.ID == 4).AD;
            soyad4 = db.TBLPERSONEL.First(x => x.ID == 4).SOYAD;
            labelControl18.Text = ad4 + " " + soyad4;
            labelControl16.Text = db.TBLPERSONEL.First(x => x.ID == 4).MAIL;
            labelControl15.Text = db.TBLPERSONEL.First(x => x.ID == 4).TBLDEPARTMAN.AD;

            LkpDepartman.Properties.PopulateColumns();
            LkpDepartman.Properties.Columns["ID"].Visible = false;
           
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TBLPERSONEL t = new TBLPERSONEL();
            t.AD = TxtAd.Text.ToUpper();
            t.SOYAD = TxtSoyad.Text.ToUpper();
            t.DEPARTMAN = byte.Parse(LkpDepartman.EditValue.ToString());
            db.TBLPERSONEL.Add(t);
            db.SaveChanges();
            MessageBox.Show("Personel Sisteme eklendi");
            Listele();

        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            Listele();
        }
    }
}
