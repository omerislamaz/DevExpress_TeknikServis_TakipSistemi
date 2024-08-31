using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Reflection;

namespace TeknikServis.Formlar
{
    public partial class FrmMarkalar : Form
    {
        public FrmMarkalar()
        {
            InitializeComponent();
        }
        DBTeknikServisEntities db = new DBTeknikServisEntities();
        private void FrmMarkalar_Load(object sender, EventArgs e)
        {
            var degerler = db.TBLURUN.OrderBy(x => x.MARKA).GroupBy(y => y.MARKA).Select(z => new
            {
                Marka = z.Key,
                Toplam = z.Count()
            });
            gridControl1.DataSource = degerler.ToList();
            gridView1.OptionsBehavior.Editable = false;

            labelControl2.Text = db.TBLURUN.Count().ToString();

            labelControl3.Text = (from x in db.TBLURUN
                                  select x.MARKA).Distinct().Count().ToString();

            labelControl5.Text = db.TBLURUN.OrderByDescending(x => x.SATISFIYAT).Select(y => y.AD).FirstOrDefault().ToString();

            labelControl7.Text = db.TBLURUN.OrderByDescending(x => x.STOK).Select(y => y.MARKA).FirstOrDefault().ToString();


            //chartControl1.Series["Series 1"].Points.AddPoint("SIEMENS", 4);
            //chartControl1.Series["Series 1"].Points.AddPoint("ARÇELIK", 6);
            //chartControl1.Series["Series 1"].Points.AddPoint("BEKO", 2);
            //chartControl1.Series["Series 1"].Points.AddPoint("TOSHIBA", 1);
            //chartControl1.Series["Series 1"].Points.AddPoint("LENOVO", 1);


            SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-R2R0K4B\SQLEXPRESS;Initial Catalog=DBTeknikServis;Integrated Security=True");

            baglanti.Open();
            SqlCommand komut = new SqlCommand("select MARKA,COuNT(*) FROM TBLURUN GROUP by MARKA", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                chartControl1.Series["Series 1"].Points.AddPoint(Convert.ToString(dr[0]), int.Parse(dr[1].ToString()));
            }
            baglanti.Close();



            baglanti.Open();
            SqlCommand komut2 = new SqlCommand(" select TBLKATEGORI.AD,COuNT(*) FROM TBLURUN\r\nINNER JOIN TBLKATEGORI ON TBLKATEGORI.ID = TBLURUN.KATEGORI GROUP by TBLKATEGORI.AD", baglanti);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                chartControl2.Series["Kategoriler"].Points.AddPoint(Convert.ToString(dr2[0]), int.Parse(dr2[1].ToString()));
            }
            baglanti.Close();

           
        }

        private void pictureEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}
