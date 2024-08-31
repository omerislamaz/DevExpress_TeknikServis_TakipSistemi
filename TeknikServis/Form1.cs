using DevExpress.XtraEditors.ColorPick.Picker;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TeknikServis.Formlar;
using TeknikServis.İletişim;

namespace TeknikServis
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Formlar.FrmUrunListesi fr4;
        private void BtnUrunListesiFormu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr4 == null || fr4.IsDisposed)
            {
                fr4 = new Formlar.FrmUrunListesi();
                fr4.MdiParent = this;
                fr4.Show();
            }
        }

        Formlar.FrmYoutube fr5;
        private void barButtonItem30_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr5 == null || fr5.IsDisposed)
            {
                fr5 = new Formlar.FrmYoutube();
                fr5.MdiParent = this;
                fr5.Show();
            }
        }

        Formlar.FrmYeniUrun fr6;
        private void BtnYeniUrun_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr6 == null || fr6.IsDisposed)
            {
                fr6 = new Formlar.FrmYeniUrun();
                //  fr6.MdiParent = this;
                fr6.Show();
            }
        }

        Formlar.FrmKategori fr2;
        private void BtnKategoriListe_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (fr2 == null || fr2.IsDisposed)
            {
                fr2 = new Formlar.FrmKategori();
                fr2.MdiParent = this;
                fr2.Show();
            }

        }

        Formlar.FrmYeniKategori fr3;
        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr3 == null || fr3.IsDisposed)
            {
                fr3 = new Formlar.FrmYeniKategori();
                fr3.Show();
            }

        }

        Formlar.FrmIstatistik fr7;
        private void BtnIstatistik_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr7 == null || fr7.IsDisposed)
            {
                fr7 = new Formlar.FrmIstatistik();
                fr7.MdiParent = this;
                fr7.Show();
            }
        }

        Formlar.FrmMarkalar fr8;
        private void BtnMarkaIst_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr8 == null || fr8.IsDisposed)
            {
                fr8 = new Formlar.FrmMarkalar();
                fr8.MdiParent = this;
                fr8.Show();
            }
        }

        Formlar.FrmCariListesi fr14;
        private void BtnCariListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (fr14 == null || fr14.IsDisposed)
            {
                fr14 = new Formlar.FrmCariListesi();
                fr14.MdiParent = this;
                fr14.Show();
            }
        }

        Formlar.FrmCariIller fr18;
        private void BtnCariIlIstatisigi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr18 == null || fr18.IsDisposed)
            {
                fr18 = new Formlar.FrmCariIller();
                fr18.MdiParent = this;
                fr18.Show();
            }
        }

        Formlar.FrmCariEkle fr15;
        private void BtnYeniCari_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr15 == null || fr15.IsDisposed)
            {
                fr15 = new Formlar.FrmCariEkle();
                // fr.MdiParent = this;
                fr15.Show();
            }
        }

        Formlar.FrmDepartman fr16;
        private void BtnDepartmanListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr16 == null || fr16.IsDisposed)
            {
                fr16 = new Formlar.FrmDepartman();
                fr16.MdiParent = this;
                fr16.Show();
            }
        }
        Formlar.FrmYeniDepartman fr19;
        private void barButtonItem26_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr19 == null || fr19.IsDisposed)
            {
                fr19 = new Formlar.FrmYeniDepartman();
                // fr.MdiParent = this;
                fr19.Show();
            }
        }

        Formlar.FrmPersonel fr17;
        private void BtnPersonelListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr17 == null || fr17.IsDisposed)
            {
                fr17 = new Formlar.FrmPersonel();
                fr17.MdiParent = this;
                fr17.Show();
            }

        }

        private void BtnHesapMakinesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("Calc.exe");
        }
        Formlar.FrmKurlar fr20;
        private void BtnDovizKurlari_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr20 == null || fr20.IsDisposed)
            {
                fr20 = new Formlar.FrmKurlar();
                fr20.MdiParent = this;
                fr20.Show();
            }
        }

        private void BtnWord_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("winword.exe");
        }

        private void BtnExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("excel.exe");
        }

        Formlar.FrmNotlar fr13;
        private void BtnAjanda_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr13 == null || fr13.IsDisposed)
            {
                Formlar.FrmNotlar fr13 = new Formlar.FrmNotlar();
                fr13.MdiParent = this;
                fr13.Show();
            }
        }

        Formlar.FrmArizaListesi fr9;
        private void BtnArizaliUrunListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr9 == null || fr9.IsDisposed)
            {
                fr9 = new Formlar.FrmArizaListesi();
                fr9.MdiParent = this;
                fr9.Show();
            }
        }
        Formlar.FrmUrunSatis fr12;
        private void BtnYeniUrunSatisi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr12 == null || fr12.IsDisposed)
            {
                fr12 = new Formlar.FrmUrunSatis();
                fr12.Show();
            }
        }

        Formlar.FrmSatislar fr11;
        private void BtnSatisListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr11 == null || fr11.IsDisposed)
            {
                fr11 = new Formlar.FrmSatislar();
                fr11.MdiParent = this;
                fr11.Show();
            }
        }

        Formlar.FrmArizaliUrunKaydi fr10;
        private void BtnArizaliUrunKaydi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr10 == null || fr10.IsDisposed)
            {
                fr10 = new Formlar.FrmArizaliUrunKaydi();
                fr10.Show();
            }
        }

        Formlar.FrmArizaDetaylar fr21;
        private void BtnArizaUrunAciklama_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr21 == null || fr21.IsDisposed)
            {
                fr21 = new Formlar.FrmArizaDetaylar();
                // fr.MdiParent = this;
                fr21.Show();
            }
        }

        private void BtnArizaliUrunDetaylari_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmArizaliUrunDetayListesi fr = new Formlar.FrmArizaliUrunDetayListesi();
            fr.MdiParent = this;
            fr.Show();
        }

        private void BtnQRCode_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmQRCode fr = new Formlar.FrmQRCode();
            // fr.MdiParent = this;
            fr.Show();
        }

        Formlar.FrmFaturaListesi fr22;
        private void BtnFaturaListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr22 == null || fr22.IsDisposed)
            {
                fr22 = new Formlar.FrmFaturaListesi();
                fr22.MdiParent = this;
                fr22.Show();
            }
        }

        Formlar.FrmFaturaKalem fr23;
        private void BtnFaturaKalem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr23 == null || fr23.IsDisposed)
            {
                fr23 = new Formlar.FrmFaturaKalem();
                fr23.MdiParent = this;
                fr23.Show();
            }
        }

        Formlar.FrmFaturaKalemleri fr24;
        private void BtnFaturaKalemListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr24 == null || fr24.IsDisposed)
            {
                fr24 = new Formlar.FrmFaturaKalemleri();
                fr24.MdiParent = this;
                fr24.Show();
            }
        }

        Formlar.FrmGauge fr25;
        private void BtnHakkimizda_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr25 == null || fr25.IsDisposed)
            {
                fr25 = new Formlar.FrmGauge();
                fr25.MdiParent = this;
                fr25.Show();
            }
        }

        Formlar.FrmHarita fr26;
        private void BtnHaritalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr26 == null || fr26.IsDisposed)
            {
                fr26 = new Formlar.FrmHarita();
                fr26.MdiParent = this;
                fr26.Show();
            }
        }

        Formlar.FrmGoogleHarita fr27;
        private void BtnGoogleHarita_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr27 == null || fr27.IsDisposed)
            {
                fr27 = new Formlar.FrmGoogleHarita();
                fr27.MdiParent = this;
                fr27.Show();
            }
        }

        Formlar.FrmRapor fr28;
        private void BtnRaporSihirbazi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr28 == null || fr28.IsDisposed)
            {
                fr28 = new Formlar.FrmRapor();
                // fr.MdiParent = this;
                fr28.Show();
            }
        }

        Formlar.FrmAnaSayfa fr;
        private void Form1_Load(object sender, EventArgs e)
        {

            if (fr == null || fr.IsDisposed)
            {
                fr = new Formlar.FrmAnaSayfa();
                fr.MdiParent = this;
                fr.Show();
            }

        }


        private void BtnAnaForm_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr == null || fr.IsDisposed)
            {
                fr = new Formlar.FrmAnaSayfa();
                fr.MdiParent = this;
                fr.Show();
            }


        }

        İletişim.FrmRehber fr29;
        private void BtnRehber_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr29 == null || fr29.IsDisposed)
            {
                fr29 = new İletişim.FrmRehber();
                fr29.MdiParent = this;
                fr29.Show();
            }
        }

        İletişim.FrmGelenMesajlar fr30;
        private void BtnGelenMesajlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr30 == null || fr30.IsDisposed)
            {
                fr30 = new FrmGelenMesajlar();
                fr30.MdiParent = this;
                fr30.Show();
            }
        }

        İletişim.FrmMail fr31;
        private void BtnYaniMail_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr31 == null || fr31.IsDisposed)
            {
                fr31 = new FrmMail();
                fr31.Show();
            }
        }

        İletişim.FrmGonderilenMailler fr32;
        private void BtnMailler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr32 == null || fr32.IsDisposed)
            {
                fr32 = new FrmGonderilenMailler();
                fr32.MdiParent = this;
                fr32.Show();
            }
        }
    }
}
