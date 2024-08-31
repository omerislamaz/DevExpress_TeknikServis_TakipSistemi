using CefSharp.WinForms;
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
    public partial class FrmGoogleHarita : Form
    {
        public FrmGoogleHarita()
        {
            InitializeComponent();
        }

        ChromiumWebBrowser browser;

        private void FrmGoogleHarita_Load(object sender, EventArgs e)
        {
            browser = new ChromiumWebBrowser("https://www.google.com/maps");
            panel1.Controls.Add(browser);
            panel1.Dock = DockStyle.Fill;
        }
    }
}
