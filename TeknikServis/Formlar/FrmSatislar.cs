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
    public partial class FrmSatislar : Form
    {
        public FrmSatislar()
        {
            InitializeComponent();
        }

        DBTeknikServisEntities db = new DBTeknikServisEntities();
        private void FrmSatislar_Load(object sender, EventArgs e)
        {
            var degerler = (from x in db.TBLURUNHAREKET
                            select new
                            {
                                x.HAREKETID,
                                x.TBLURUN.AD,
                                MUSTERİ = x.TBLCARI.AD + " " + x.TBLCARI.SOYAD,
                                PERSONEL = x.TBLPERSONEL.AD + " " + x.TBLPERSONEL.SOYAD,
                                x.TARIH,
                                x.ADET,
                                x.FIYAT,
                                x.URUNSERINO,
                            }).ToList();
            gridControl1.DataSource = degerler;
            gridView1.OptionsBehavior.Editable = false;
        }
    }
}
