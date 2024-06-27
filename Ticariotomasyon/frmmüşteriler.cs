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
using DevExpress.DirectX.Common.Direct2D;

namespace Ticariotomasyon
{
    public partial class frmmüşteriler : Form
    {
        public frmmüşteriler()
        {
            InitializeComponent();
        }
        sqlbaglantısı bgl = new sqlbaglantısı();

        void listele()
        {
            DataTable dt = new DataTable(); 
            SqlDataAdapter da = new SqlDataAdapter("select * from tblmüşteriler ",bgl .baglantı ());
            da.Fill (dt);
            gridControl1 .DataSource = dt;
            
        }

        void sehirlistesi()
        {
            SqlCommand komut = new SqlCommand("select ŞEHİR from tbliller  ",bgl.baglantı ());
            SqlDataReader dr = komut.ExecuteReader ();
            while (dr.Read ())
            {
                cmbil.Properties.Items.Add(dr[0]);
            }
            bgl .baglantı ().Close ();
        }
        private void frmmüşteriler_Load(object sender, EventArgs e)
        {
            listele ();
            sehirlistesi ();

        }

        private void cmbil_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbilçe .Properties.Items.Clear ();
            SqlCommand komut = new SqlCommand ("select İLÇE from tblilçeler where ŞEHİR = @p1",bgl.baglantı ());
            komut .Parameters .AddWithValue ("@p1",cmbil .SelectedIndex+1);
            SqlDataReader dr = komut .ExecuteReader ();
            while (dr.Read ())
            {
                cmbilçe .Properties .Items.Add(dr[0]);
            }
            bgl.baglantı ().Close ();
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into tblmüşteriler  (AD,SOYAD,TELEFON,TELEFON2,TC,MAİL,İL,İLÇE,ADRES,VERGİDAİRE) VALUES (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10)",bgl .baglantı ());
            komut.Parameters.AddWithValue("@p1", txtad.Text);
            komut.Parameters.AddWithValue("@p2", txtsoyad .Text); komut.Parameters.AddWithValue("@p3", msktel1 .Text); komut.Parameters.AddWithValue("@p4", msktel2 .Text); komut.Parameters.AddWithValue("@p5", msktc .Text); komut.Parameters.AddWithValue("@p6", txtmail .Text); komut.Parameters.AddWithValue("@p7", cmbil .Text); komut.Parameters.AddWithValue("@p8", cmbilçe .Text); komut.Parameters.AddWithValue("@p9", rcadres .Text); komut.Parameters.AddWithValue("@p10", txtvergidaire .Text);
            komut .ExecuteNonQuery ();
            bgl .baglantı ().Close ();
            MessageBox .Show ("Müşteri sisteme kaydedildi","Bilgi",MessageBoxButtons.OK , MessageBoxIcon.Information );
            listele();
            temizle();
        }
        void temizle()
        {
            txtıd.Text = "";
            txtad.Text = "";
            txtsoyad.Text = "";
            msktel1.Text = "";
            msktel2.Text = "";
            msktc.Text = "";
            txtmail.Text = "";
            cmbil.Text = "";
            cmbilçe.Text = "";
            rcadres.Text = "";
            txtvergidaire.Text = "";
            txtad.Focus();
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            temizle();

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                txtıd .Text = dr["ID"].ToString ();
                txtad.Text = dr["AD"].ToString();
                txtsoyad .Text = dr["SOYAD"].ToString(); 
                msktel1 .Text = dr["TELEFON"].ToString(); 
                msktel2 .Text = dr["TELEFON2"].ToString();
                msktc .Text = dr["TC"].ToString();
                txtmail .Text = dr["MAİL"].ToString(); 
                cmbil .Text = dr["İL"].ToString(); 
                cmbilçe.Text = dr["İLÇE"].ToString(); 
                txtvergidaire .Text = dr["VERGİDAİRE"].ToString();
                rcadres .Text = dr["ADRES"].ToString();
            }
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            DialogResult secim = new DialogResult();
            secim = MessageBox.Show("Müşteri Kaydınız Sileceksiniz. Emin Misiniz?", "Müşteri Kaydı Silme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (secim == DialogResult.Yes)
            {
                SqlCommand komut = new SqlCommand("delete  from tblmüşteriler where ID=@p1", bgl.baglantı());
                komut.Parameters.AddWithValue("@p1", txtıd.Text);
                komut.ExecuteNonQuery();
                bgl.baglantı().Close();
                MessageBox.Show("Müşteri sistemden silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                listele();
            }
        }

        private void btngüncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update tblmüşteriler set AD=@P1,SOYAD=@P2,TELEFON=@P3,TELEFON2=@P4,TC=@P5,MAİL=@P6,İL=@P7,İLÇE=@P8,VERGİDAİRE=@P9 ,ADRES = @P10 WHERE ID=@P11", bgl.baglantı());
            komut.Parameters.AddWithValue("@p1", txtad.Text);
            komut.Parameters.AddWithValue("@p2", txtsoyad.Text); komut.Parameters.AddWithValue("@p3", msktel1.Text); komut.Parameters.AddWithValue("@p4", msktel2.Text); komut.Parameters.AddWithValue("@p5", msktc.Text); komut.Parameters.AddWithValue("@p6", txtmail.Text); komut.Parameters.AddWithValue("@p7", cmbil.Text); komut.Parameters.AddWithValue("@p8", cmbilçe.Text); komut.Parameters.AddWithValue("@p9", txtvergidaire .Text ); komut.Parameters.AddWithValue("@p10", rcadres .Text );
            komut.Parameters.AddWithValue("@p11", txtıd.Text);
            komut.ExecuteNonQuery();
            bgl.baglantı().Close();
            MessageBox.Show("Müşteri bilgileri güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning );
            listele();
        }
    }
}
