using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeknikServis.İletişim
{
    public partial class FrmGelenMesajlar : Form
    {
        DBTeknikServisEntities db=new DBTeknikServisEntities();
        public FrmGelenMesajlar()
        {
            InitializeComponent();
        }

        private void FrmGelenMesajlar_Load(object sender, EventArgs e)
        {
            labelControl11.Text = db.TBLILETISIM.Count().ToString();
            labelControl1.Text = db.TBLPERSONEL.Count().ToString();
            labelControl3.Text = db.TBLCARI.Count().ToString();
            labelControl5.Text = db.TBLKATEGORI.Count().ToString();
            labelControl7.Text = db.TBLURUN.Count().ToString();
            labelControl13.Text = db.TBLILETISIM.Where(x=>x.KONU=="Teşekkür").Count().ToString();
            labelControl17.Text = db.TBLILETISIM.Where(x=>x.KONU=="Rica").Count().ToString();
            labelControl15.Text = db.TBLILETISIM.Where(x=>x.KONU=="Şikayet").Count().ToString();

            gridControl1.DataSource = (from x in db.TBLILETISIM
                                       select new
                                       {
                                           x.ID,
                                           x.ADSOYAD,
                                           x.KONU,
                                           x.MAIL,
                                           x.MESAJ
                                       }).ToList();
            gridView1.BestFitColumns();
            gridView1.OptionsBehavior.Editable= false;
        }
    }
}
