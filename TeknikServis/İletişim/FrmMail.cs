using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace TeknikServis.İletişim
{
    public partial class FrmMail : Form
    {
        public FrmMail()
        {
            InitializeComponent();
        }
        DBTeknikServisEntities db=new DBTeknikServisEntities();
        private void FrmMail_Load(object sender, EventArgs e)
        {

        }

        private void BtnGonder_Click(object sender, EventArgs e)
        {
            MailMessage mail = new MailMessage();
            string frommail = "ornekhesap1001@gmail.com";
            string sifre = "zrae yuwh zhba euzw";
            string alici = TxtAlici.Text;
            string konu = TxtKonu.Text;
            string icerik = richTextBox1.Text;

            TBLGIDENMAIL t = new TBLGIDENMAIL();
            t.KIMDEN = frommail;
            t.KIME = alici;
            t.KONU = konu;
            t.ICERIK = icerik;
            t.GONDERIMTARIH = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.TBLGIDENMAIL.Add(t);
            db.SaveChanges();          

            mail.From = new MailAddress(frommail);
            mail.To.Add(alici);
            mail.Subject = konu;
            mail.Body = icerik;
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential(frommail, sifre);
            smtp.EnableSsl = true;
            smtp.Send(mail);
            MessageBox.Show("Mail Gönderildi");

            TxtAlici.Text = "";
            TxtKonu.Text = "";
            richTextBox1.Text = "";

        }

        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
