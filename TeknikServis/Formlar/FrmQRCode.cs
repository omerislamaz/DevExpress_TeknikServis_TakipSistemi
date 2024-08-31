using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MessagingToolkit.QRCode.Codec;

namespace TeknikServis.Formlar
{
    public partial class FrmQRCode : Form
    {
        public FrmQRCode()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
       

            if (textEdit1.Text == "")
            {
                MessageBox.Show("Boş alanları doldurun");
            }
            else
            {
                QRCodeEncoder enc = new QRCodeEncoder();

                pictureEdit1.Image = enc.Encode(textEdit1.Text);
            }
           
        }

        private void pictureEdit2_EditValueChanged(object sender, EventArgs e)
        {
            //
        }

        private void pictureEdit2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
