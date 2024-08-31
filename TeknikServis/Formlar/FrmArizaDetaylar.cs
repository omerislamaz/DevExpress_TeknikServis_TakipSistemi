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
    public partial class FrmArizaDetaylar : Form
    {
        public FrmArizaDetaylar()
        {
            InitializeComponent();
        }
        DBTeknikServisEntities db = new DBTeknikServisEntities();

        void temizle()
        {
            richTextBox1.Text = "";
            TxtSeriNo.Text = "";
            TxtTarih.Text = "";
        }
        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TBLURUNTAKIP t = new TBLURUNTAKIP();
            t.ACIKLAMA = richTextBox1.Text;
            t.SERINO = TxtSeriNo.Text;
            t.TARIH = DateTime.Parse(TxtTarih.Text);
            db.TBLURUNTAKIP.Add(t);


            //2nci güncelleme
            TBLURUNKABUL tb = new TBLURUNKABUL();
            int urunid = int.Parse(id.ToString());
            var deger = db.TBLURUNKABUL.Find(urunid);
            deger.URUNDURUMDETAY = comboBox1.Text;
            db.SaveChanges();
            temizle();


            MessageBox.Show("Ürün arıza detayları güncellendi");
        }



        private void textEdit2_Click(object sender, EventArgs e)
        {
            TxtTarih.Text = DateTime.Now.ToShortDateString();
        }

        private void richTextBox1_Click(object sender, EventArgs e)
        {
            // richTextBox1.Text = "";
        }

        private void TxtSeriNo_Click(object sender, EventArgs e)
        {
            //TxtSeriNo.Text = "";
        }

        public string id, serino;
        private void FrmArizaDetaylar_Load(object sender, EventArgs e)
        {
           
            TxtSeriNo.Text = serino;
        }
    }
}
