﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TeknikServis.Formlar
{
    public partial class FrmCariIller : Form
    {
        public FrmCariIller()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-R2R0K4B\SQLEXPRESS;Initial Catalog=DBTeknikServis;Integrated Security=True");

        DBTeknikServisEntities db = new DBTeknikServisEntities();
        private void FrmCariIller_Load(object sender, EventArgs e)
        {
            gridView1.OptionsBehavior.Editable = false;

            //chartControl1.Series["Series 1"].Points.AddPoint("Ankara", 22);
            //chartControl1.Series["Series 1"].Points.AddPoint("İstanbul", 12);
            //chartControl1.Series["Series 1"].Points.AddPoint("İzmir", 8);
            //chartControl1.Series["Series 1"].Points.AddPoint("Bursa", 14);
            //chartControl1.Series["Series 1"].Points.AddPoint("Adana", 39);


            gridControl1.DataSource = db.TBLCARI.OrderBy(x => x.IL).
                GroupBy(x => x.IL).
                Select(z => new
                {
                    İL = z.Key,
                    TOPLAM = z.Count()
                }).OrderByDescending(y=>y.TOPLAM).ToList();




            baglanti.Open();
            SqlCommand komut = new SqlCommand("select IL,Count(*) From TBLCARI group by IL", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                chartControl1.Series["Series 1"].Points.AddPoint(Convert.ToString(dr[0]), int.Parse(dr[1].ToString()));
            }
            baglanti.Close();
        }
    }
}
