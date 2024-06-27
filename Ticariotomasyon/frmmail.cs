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

namespace Ticariotomasyon
{
    public partial class frmmail : Form
    {
        public frmmail()
        {
            InitializeComponent();
        }
        public string mail;
        private void frmmail_Load(object sender, EventArgs e)
        {
            txtmail .Text = mail;
        }

        private void brngönder_Click(object sender, EventArgs e)
        {
            MailMessage mesajım = new MailMessage();
            SmtpClient istemci = new SmtpClient();
            istemci.Credentials = new System.Net.NetworkCredential("Mail", "Şifre");

            istemci.Port = 587;
            istemci.Host = "smtp.live.com";
            istemci .EnableSsl = true;
            mesajım .To .Add (txtmail .Text );
            mesajım.From = new MailAddress("Mail");
            mesajım.Subject = txtkonu.Text;
            mesajım.Body = txtmesaj.Text;
            istemci.Send(mesajım);

        }
    }
}
