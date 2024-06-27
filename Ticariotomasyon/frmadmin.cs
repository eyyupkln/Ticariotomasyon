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

namespace Ticariotomasyon
{
    public partial class frmadmin : Form
    {
        public frmadmin()
        {
            InitializeComponent();
        }

       
        sqlbaglantısı bgl= new sqlbaglantısı();
        private void button1_MouseHover(object sender, EventArgs e)
        {
            btngirşyap.BackColor = Color.Yellow;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            btngirşyap.BackColor = Color.LightSeaGreen ;
        }
        
        private void btngirşyap_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select * from tbladmin where KULLANICIAD=@P1 AND ŞİFRE=@P2", bgl.baglantı());
            komut.Parameters.AddWithValue("@p1", txtkullanıcıad.Text);
            komut .Parameters .AddWithValue("@p2",txtşifre .Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                frmanamodül fr = new frmanamodül();
                fr.kullanıcı = txtkullanıcıad.Text;
                fr.Show();
                this .Hide();
            }
            else
            {
                MessageBox.Show("Hatalı kullanıcı adı veya şifre ", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            bgl .baglantı ().Close();
        }
    }
}
