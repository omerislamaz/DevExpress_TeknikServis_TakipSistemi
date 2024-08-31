using CefSharp.WinForms;
using CefSharp;
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
    public partial class FrmYoutube : Form
    {
        public FrmYoutube()
        {
            InitializeComponent();
        }
        ChromiumWebBrowser browser;

        private void FrmYoutube_Load(object sender, EventArgs e)
        {
            browser = new ChromiumWebBrowser("https://www.youtube.com/");
            panel1.Controls.Add(browser);
            panel1.Dock = DockStyle.Fill;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            //
        }
    }
}
