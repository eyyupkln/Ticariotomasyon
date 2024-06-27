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
    public partial class frmfaturaüründüzenleme : Form
    {
        public frmfaturaüründüzenleme()
        {
            InitializeComponent();
        }
        public string urunıd;
        sqlbaglantısı bgl = new sqlbaglantısı();
        private void frmfaturaüründüzenleme_Load(object sender, EventArgs e)
        {
            txtürünıd.Text = urunıd;

            SqlCommand komut = new SqlCommand("select * from tblfaturadetay where FATURAÜRÜNID=@P1", bgl.baglantı());
            komut.Parameters.AddWithValue("@P1", urunıd);
            SqlDataReader dr = komut .ExecuteReader();
            while ( dr .Read())
            {
                txtfiyat .Text = dr[3].ToString ();
                txtmiktar .Text = dr[2].ToString ();
                txttutar .Text = dr[4].ToString ();
                txtürünad .Text = dr[1].ToString ();

                bgl.baglantı();
            }
        }

        private void btngüncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update tblfaturadetay set ÜRÜNAD=@P1,MİKTAR=@P2,FİYAT=@P3,TUTAR=@P4 WHERE FATURAÜRÜNID=@P5",bgl .baglantı ());
            komut .Parameters .AddWithValue ("@P1",txtürünad .Text);
            komut.Parameters.AddWithValue("@P2", txtmiktar .Text);
            komut.Parameters.AddWithValue("@P3",decimal .Parse ( txtfiyat .Text));
            komut.Parameters.AddWithValue("@P4", decimal .Parse ( txttutar .Text));
            komut.Parameters.AddWithValue("@P5", txtürünıd  .Text);

            komut .ExecuteNonQuery ();
            bgl.baglantı().Close();
            MessageBox .Show ("Değişiklikler kaydedildi","Bilgi",MessageBoxButtons.OK , MessageBoxIcon.Warning );

        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand ("delete from tblfaturadetay where FATURAÜRÜNID=@P1",bgl .baglantı ());
            komut.Parameters.AddWithValue("@P1", txtürünıd.Text);

            komut.ExecuteNonQuery();
            bgl.baglantı().Close();
            MessageBox.Show("Ürün silindi ", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
