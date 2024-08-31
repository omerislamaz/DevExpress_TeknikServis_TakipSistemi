using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeknikServis.Formlar
{
    public partial class FrmArizaListesi : Form
    {
        public FrmArizaListesi()
        {
            InitializeComponent();
        }

        DBTeknikServisEntities db = new DBTeknikServisEntities();


        private void FrmArizaListesi_Load(object sender, EventArgs e)
        {
            gridView1.OptionsBehavior.Editable = false;
            var degerler = (from x in db.TBLURUNKABUL
                            select new
                            {
                                x.ISLEMID,
                                CARİ = x.TBLCARI.AD + " " + x.TBLCARI.SOYAD,
                                PERSONEL = x.TBLPERSONEL.AD + " " + x.TBLPERSONEL.SOYAD,
                                x.GELISTARIHI,
                                x.CIKISTARIHI,
                                ÜRÜNSERİNO = x.URUNSERINO,
                                x.URUNDURUMDETAY
                            }).ToList();
            gridControl1.DataSource = degerler;

            labelControl7.Text = db.TBLURUNKABUL.Count(x => x.URUNDURUM == true).ToString();
            labelControl3.Text = db.TBLURUNKABUL.Count(x => x.URUNDURUM == false).ToString();
            labelControl1.Text = db.TBLURUN.Count().ToString();
            labelControl5.Text = db.TBLURUNKABUL.Count(x => x.URUNDURUMDETAY == "Parça Bekliyor").ToString();
            labelControl11.Text = db.TBLURUNKABUL.Count(x => x.URUNDURUMDETAY == "Mesaj Bekliyor").ToString();
            labelControl13.Text = db.TBLURUNKABUL.Count(x => x.URUNDURUMDETAY == "İptal Bekliyor").ToString();


            SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-R2R0K4B\SQLEXPRESS;Initial Catalog=DBTeknikServis;Integrated Security=True");

            baglanti.Open();
            SqlCommand komut = new SqlCommand("select URUNDURUMDETAY,COuNT(*) FROM TBLURUNKABUL GROUP by URUNDURUMDETAY", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                chartControl1.Series["Series 1"].Points.AddPoint(Convert.ToString(dr[0]), int.Parse(dr[1].ToString()));
            }
            baglanti.Close();

        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmArizaDetaylar fr = new FrmArizaDetaylar();
            fr.id = gridView1.GetFocusedRowCellValue("ISLEMID").ToString();
            fr.serino = gridView1.GetFocusedRowCellValue("ÜRÜNSERİNO").ToString();
            fr.Show();
        }
    }
}
