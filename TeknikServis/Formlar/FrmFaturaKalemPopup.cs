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
    public partial class FrmFaturaKalemPopup : Form
    {
        public FrmFaturaKalemPopup()
        {
            InitializeComponent();
        }
        DBTeknikServisEntities db = new DBTeknikServisEntities();

        public int faturakalemid;
        private void FrmFaturaKalemPopup_Load(object sender, EventArgs e)
        {
            
            gridControl1.DataSource = (from x in db.TBLFATURADETAY.Where(Z => Z.FATURAID == faturakalemid)
                                       select new
                                       {
                                           x.FATURADETAYID,
                                           x.URUN,
                                           x.ADET,
                                           x.FIYAT,
                                           x.TUTAR,
                                           x.FATURAID,
                                       }).ToList();




            gridControl2.DataSource = (from x in db.TBLFATURABILGI.Where(Z => Z.ID == faturakalemid)
                                       select new
                                       {
                                           x.ID,
                                           x.SERI,
                                           x.SIRANO,
                                           x.TARIH,
                                           x.SAAT,
                                           x.VERGIDAIRE,
                                           Cari = x.TBLCARI.AD + " " + x.TBLCARI.SOYAD,
                                           Personel = x.TBLPERSONEL.AD + " " + x.TBLPERSONEL.SOYAD,
                                       }).ToList();

        }

        private void pictureEdit1_Click(object sender, EventArgs e)
        {
            string path = "Dosya1.pdf";
            gridControl1.ExportToPdf(path);

        }

        private void pictureEdit2_Click(object sender, EventArgs e)
        {
            string path = "Dosya1.xls";
            gridControl1.ExportToXls(path);
        }

        private void pictureEdit3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

