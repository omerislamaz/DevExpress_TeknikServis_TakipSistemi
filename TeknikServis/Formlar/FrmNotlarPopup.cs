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
    public partial class FrmNotlarPopup : Form
    {
        public FrmNotlarPopup()
        {
            InitializeComponent();
        }
        DBTeknikServisEntities db = new DBTeknikServisEntities();

        public string notid;
        private void FrmNotlarPopup_Load(object sender, EventArgs e)
        {
            int sirano = int.Parse(notid);
            LblId.Text = notid.ToString();

            LblKayitTarihi.Text =db.TBLNOTLARIM.Where(x => x.ID == sirano).Select(y => y.KAYITTARIH).FirstOrDefault().ToString();
            LblKonu.Text =db.TBLNOTLARIM.Where(x => x.ID == sirano).Select(y => y.BASLIK).FirstOrDefault().ToString();
            richTextBox1.Text =db.TBLNOTLARIM.Where(x => x.ID == sirano).Select(y => y.ICERIK).FirstOrDefault().ToString();
            LblIlgiliTarih.Text =db.TBLNOTLARIM.Where(x => x.ID == sirano).Select(y => y.TARIH).FirstOrDefault().ToString();
           
        }

        private void pictureEdit1_Click(object sender, EventArgs e)
        {
           
          
            this.Close();
           

        }

      

    }
}
