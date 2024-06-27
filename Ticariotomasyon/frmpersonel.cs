using DevExpress.XtraPrinting.BarCode;
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
    public partial class frmpersonel : Form
    {
        public frmpersonel()
        {
            InitializeComponent();
        }
        sqlbaglantısı bgl = new sqlbaglantısı();

        void personelliste()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from tblpersoneller ",bgl.baglantı ());
            da.Fill(dt);
            gridControl1 .DataSource = dt;
        }

        void sehirlistesi()
        {
            SqlCommand komut = new SqlCommand("select ŞEHİR from tbliller  ", bgl.baglantı());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                cmbil.Properties.Items.Add(dr[0]);
            }
            bgl.baglantı().Close();
        }

        void temizle()
        {
            txtıd.Text = "";
            txtad.Text = "";
            txtsoyad.Text = "";
            txtmail.Text = "";
            txtgörev.Text = "";
            msktc.Text = "";
            msktel1.Text = "";
            cmbil.Text = "";
            cmbilçe.Text = "";
            rcadres.Text = "";
        }
        private void frmpersonel_Load(object sender, EventArgs e)
        {
            personelliste ();
            sehirlistesi ();
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into tblpersoneller (AD,SOYAD,TELEFON,TC,MAİL,İL,İLÇE,ADRES,GÖREV) VALUES (@P1,@P2,@P3,@P4,@P5,@P6,@P7,@P8,@P9)", bgl.baglantı());
            komut.Parameters.AddWithValue("@p1", txtad.Text);
            komut.Parameters.AddWithValue("@p2", txtsoyad .Text);
            komut.Parameters.AddWithValue("@p3", msktel1 .Text);
            komut.Parameters.AddWithValue("@p4", msktc .Text);
            komut.Parameters.AddWithValue("@p5", txtmail  .Text);
            komut.Parameters.AddWithValue("@p6", cmbil  .Text);
            komut.Parameters.AddWithValue("@p7", cmbilçe  .Text);
            komut.Parameters.AddWithValue("@p8", rcadres .Text);
            komut.Parameters.AddWithValue("@p9", txtgörev .Text);
            komut.ExecuteNonQuery ();
            bgl .baglantı ().Close ();
            MessageBox.Show("Personel sisteme kaydedildi", "Bilgi ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            personelliste();

        }

        private void cmbil_Properties_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbilçe.Properties.Items.Clear();
            SqlCommand komut = new SqlCommand("select İLÇE from tblilçeler where ŞEHİR = @p1", bgl.baglantı());
            komut.Parameters.AddWithValue("@p1", cmbil.SelectedIndex + 1);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                cmbilçe.Properties.Items.Add(dr[0]);
            }
            bgl.baglantı().Close();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                txtıd .Text = dr["ID"].ToString();
                txtad.Text = dr["AD"].ToString();
                txtsoyad .Text = dr["SOYAD"].ToString();
                msktel1 .Text = dr["TELEFON"].ToString();
                msktc .Text = dr["TC"].ToString();
                txtmail .Text = dr["MAİL"].ToString();
                cmbil .Text = dr["İL"].ToString();
                cmbilçe .Text = dr["İLÇE"].ToString();
                rcadres .Text = dr["ADRES"].ToString();
                txtgörev .Text = dr["GÖREV"].ToString();

            }
        }

        private void btntemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("delete from tblpersoneller where ID=@P1", bgl.baglantı());
            komut.Parameters .AddWithValue ("@p1",txtıd.Text);
            komut.ExecuteNonQuery();
            bgl.baglantı().Close();
            MessageBox.Show("Personel sistemden silindi", "Bilgi ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            personelliste();
        }

        private void btngüncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update tblpersoneller set AD=@p1,SOYAD=@p2,TELEFON=@p3,TC=@p4,MAİL=@p5,İL=@p6,İLÇE=@p7,ADRES=@p9,GÖREV=@p9 where ID=@p10", bgl.baglantı());
            komut.Parameters.AddWithValue("@p1", txtad.Text);
            komut.Parameters.AddWithValue("@p2", txtsoyad.Text);
            komut.Parameters.AddWithValue("@p3", msktel1.Text);
            komut.Parameters.AddWithValue("@p4", msktc.Text);
            komut.Parameters.AddWithValue("@p5", txtmail.Text);
            komut.Parameters.AddWithValue("@p6", cmbil.Text);
            komut.Parameters.AddWithValue("@p7", cmbilçe.Text);
            komut.Parameters.AddWithValue("@p8", rcadres.Text);
            komut.Parameters.AddWithValue("@p9", txtgörev.Text);
            komut .Parameters .AddWithValue ("@p10",txtıd .Text );
            komut.ExecuteNonQuery();
            bgl.baglantı().Close();
            MessageBox.Show("Personel bilgisi güncellendi", "Bilgi ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            personelliste();
        }
    }
}
