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
    public partial class FrmDepartman : Form
    {
        public FrmDepartman()
        {
            InitializeComponent();
        }

        DBTeknikServisEntities DB = new DBTeknikServisEntities();

        void Listele()
        {
            var degerler = (from x in DB.TBLDEPARTMAN
                            select new
                            {
                                x.ID,
                                x.AD,
                                x.ACIKLAMA
                            }).ToList();
            gridControl1.DataSource = degerler;
            gridView1.OptionsBehavior.Editable = false;
            labelControl11.Text = DB.TBLDEPARTMAN.Count().ToString();
            labelControl13.Text = DB.TBLPERSONEL.Count().ToString();
            var mindepertman = DB.TBLPERSONEL.GroupBy(x => x.DEPARTMAN).OrderBy(y => y.Count()).FirstOrDefault()?.Key;

            labelControl15.Text = DB.TBLDEPARTMAN.Where(x=>x.ID== mindepertman).Select(y=>y.AD).FirstOrDefault();

            var maxdepertman = DB.TBLPERSONEL.GroupBy(x => x.DEPARTMAN).OrderByDescending(y => y.Count()).FirstOrDefault()?.Key;

            labelControl17.Text = DB.TBLDEPARTMAN.Where(x => x.ID == maxdepertman).Select(y => y.AD).FirstOrDefault();

        }

        void Temizle()
        {
            TxtAd.Text = "";
            RchAciklama.Text = "";
            TxtId.Text = "";
        }
        private void FrmDepartman_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TBLDEPARTMAN t = new TBLDEPARTMAN();
            if (TxtAd.Text.Length <= 50 && TxtAd.Text != "" && RchAciklama.Text.Length >= 1)
            {
                t.AD = TxtAd.Text.ToUpper();
                t.ACIKLAMA = RchAciklama.Text.ToUpper();
                DB.TBLDEPARTMAN.Add(t);
                DB.SaveChanges();
                Listele();
                Temizle();
                MessageBox.Show("Departman Kayıt Edildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Kayıt Yapılamadı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnFormTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            TxtId.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            TxtAd.Text = gridView1.GetFocusedRowCellValue("AD").ToString();
            RchAciklama.Text = gridView1.GetFocusedRowCellValue("ACIKLAMA").ToString();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtId.Text);
            var deger = DB.TBLDEPARTMAN.Find(id);
            DB.TBLDEPARTMAN.Remove(deger);
            DB.SaveChanges();
            MessageBox.Show("Departman Başarıyla Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
            Temizle();

        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtId.Text);
            var deger = DB.TBLDEPARTMAN.Find(id);
            deger.AD = TxtAd.Text.ToUpper();
            deger.ACIKLAMA = RchAciklama.Text.ToUpper();
            DB.SaveChanges();
            MessageBox.Show("Departman Başarıyla Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
            Temizle();

        }
    }
}
