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
    public partial class FrmFaturaKalemleri : Form
    {
        public FrmFaturaKalemleri()
        {
            InitializeComponent();
        }

        DBTeknikServisEntities db = new DBTeknikServisEntities();
        private void BtnAra_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(TxtId.Text);
            var degerler = (from x in db.TBLFATURADETAY
                            select new
                            {
                                x.FATURADETAYID,
                                x.URUN,
                                x.ADET,
                                x.FIYAT,
                                x.TUTAR,
                                x.FATURAID,
                            }).Where(X => X.FATURAID == id).ToList();

            gridControl1.DataSource = degerler;
            gridView1.OptionsBehavior.Editable = false;
        }
    }
}
