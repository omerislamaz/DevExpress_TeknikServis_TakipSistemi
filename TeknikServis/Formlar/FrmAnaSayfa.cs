using DevExpress.XtraGrid.Views.Grid;
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
    public partial class FrmAnaSayfa : Form
    {
        DBTeknikServisEntities db = new DBTeknikServisEntities();
        public FrmAnaSayfa()
        {
            InitializeComponent();
        }

        public void NotListele()
        {
            var deger = db.TBLNOTLARIM.Where(x => x.DURUM == false).OrderBy(y => y.TARIH).ToList();

            // (from x in db.TBLNOTLARIM.OrderBy(y => y.TARIH).Where(x => x.TARIH == bugun)
            //select new
            //             {
            //                 x.BASLIK,
            //                 x.ICERIK,
            //             });

            gridControl4.DataSource = deger.ToList();
        }
        private void FrmAnaSayfa_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from x in db.TBLURUN
                                       select new
                                       {
                                           x.AD,
                                           x.STOK,
                                       }).OrderBy(z => z.STOK).Where(x => x.STOK < 30).ToList();

            label2.Text = db.TBLURUN.Where(x => x.STOK < 30).Count().ToString();


            gridControl2.DataSource = (from y in db.TBLCARI
                                       select new
                                       {
                                           y.AD,
                                           y.SOYAD,
                                           y.IL

                                       }).OrderBy(x => x.IL).ToList();
            label3.Text = db.TBLCARI.Select(x => x.IL).Distinct().Count().ToString();


            gridControl3.DataSource = db.urunkategori().ToList();

            DateTime bugun = DateTime.Today;

            NotListele();


            string konu1, konu2, konu3, konu4, konu5, konu6, konu7, konu8, konu9, konu10, ad1, ad2, ad3, ad4, ad5, ad6, ad7, ad8, ad9, ad10;

            konu1 = db.TBLILETISIM.First(X => X.ID == 1).KONU;
            ad1 = db.TBLILETISIM.First(X => X.ID == 1).ADSOYAD;
            labelControl1.Text = konu1 + "---" + ad1;

            konu2 = db.TBLILETISIM.First(X => X.ID == 2).KONU;
            ad2 = db.TBLILETISIM.First(X => X.ID == 2).ADSOYAD;
            labelControl2.Text = konu2 + "---" + ad2;

            konu3 = db.TBLILETISIM.First(X => X.ID == 3).KONU;
            ad3 = db.TBLILETISIM.First(X => X.ID == 3).ADSOYAD;
            labelControl3.Text = konu3 + "---" + ad3;

            konu4 = db.TBLILETISIM.First(X => X.ID == 4).KONU;
            ad4 = db.TBLILETISIM.First(X => X.ID == 4).ADSOYAD;
            labelControl4.Text = konu4 + "---" + ad4;

            konu5 = db.TBLILETISIM.First(X => X.ID == 5).KONU;
            ad5 = db.TBLILETISIM.First(X => X.ID == 5).ADSOYAD;
            labelControl5.Text = konu5 + "---" + ad5;

            konu6 = db.TBLILETISIM.First(X => X.ID == 6).KONU;
            ad6 = db.TBLILETISIM.First(X => X.ID == 6).ADSOYAD;
            labelControl6.Text = konu6 + "---" + ad6;

            konu7 = db.TBLILETISIM.First(X => X.ID == 7).KONU;
            ad7 = db.TBLILETISIM.First(X => X.ID == 7).ADSOYAD;
            labelControl7.Text = konu7 + "---" + ad7;

            konu8 = db.TBLILETISIM.First(X => X.ID == 8).KONU;
            ad8 = db.TBLILETISIM.First(X => X.ID == 8).ADSOYAD;
            labelControl8.Text = konu8 + "---" + ad8;

            konu9= db.TBLILETISIM.First(X => X.ID == 9).KONU;
            ad9 = db.TBLILETISIM.First(X => X.ID == 9).ADSOYAD;
            labelControl9.Text = konu9 + "---" + ad9;

            konu10 = db.TBLILETISIM.First(X => X.ID == 10).KONU;
            ad10 = db.TBLILETISIM.First(X => X.ID == 10).ADSOYAD;
            labelControl10.Text = konu10 + "---" + ad10;


        }


        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {
            //
        }

        private void groupControl5_Paint(object sender, PaintEventArgs e)
        {
            //
        }

        private void gridView4_DoubleClick(object sender, EventArgs e)
        {            
         // gridviewden id değerini aldım. 
            int id = int.Parse(gridView4.GetFocusedRowCellValue("ID").ToString());

            //aldığım id değerini acılmasını istediğim sayfaya gönderdim.
            Formlar.FrmNotlarPopup fr = new Formlar.FrmNotlarPopup();
            fr.notid = id.ToString();

            // anasayfada satır acıldığı için notun durumunu okundu yaptım ve kaydettim, acılan not okundu olarak bu gridviewde gösterilmeyecek.
            var deger = db.TBLNOTLARIM.Find(id);
            deger.DURUM = true;
            db.SaveChanges();
          

            fr.Show();
            NotListele();

        }
    }
}
