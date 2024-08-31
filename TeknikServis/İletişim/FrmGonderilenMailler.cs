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
    public partial class FrmGonderilenMailler : Form
    {
        public FrmGonderilenMailler()
        {
            InitializeComponent();
        }

        DBTeknikServisEntities db = new DBTeknikServisEntities();
        private void FrmGonderilenMailler_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from x in db.TBLGIDENMAIL.OrderByDescending(x => x.GONDERIMTARIH)
                                       select new
                                       {
                                           x.ID,
                                           x.GONDERIMTARIH,
                                           x.KIMDEN,
                                           x.KIME,
                                           x.KONU
                                       }).ToList();
            gridView1.BestFitColumns();
            gridView1.OptionsBehavior.Editable = false;

        }
    }
}
