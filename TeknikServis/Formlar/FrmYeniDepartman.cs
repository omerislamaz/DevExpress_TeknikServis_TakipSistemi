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
    public partial class FrmYeniDepartman : Form
    {
        DBTeknikServisEntities db = new DBTeknikServisEntities();
        public FrmYeniDepartman()
        {
            InitializeComponent();
        }

        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TBLDEPARTMAN t = new TBLDEPARTMAN();
            if (TxtAd.Text.Length <= 50 && TxtAd.Text != "" && RchAciklama.Text.Length >= 1)
            {
                t.AD = TxtAd.Text.ToUpper();
                t.ACIKLAMA = RchAciklama.Text.ToUpper();
                db.TBLDEPARTMAN.Add(t);
                db.SaveChanges();
                MessageBox.Show("Departman Kayıt Edildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtAd.Text = "";
                RchAciklama.Text = "";

            }
            else
            {
                MessageBox.Show("Kayıt Yapılamadı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
