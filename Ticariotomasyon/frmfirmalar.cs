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
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon.BackstageView.Accessible;

namespace Ticariotomasyon
{
    public partial class frmfirmalar : Form
    {
        public frmfirmalar()
        {
            InitializeComponent();
        }
        sqlbaglantısı bgl = new sqlbaglantısı();
        void firmalistesi()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from tblfirmalar ",bgl.baglantı ());
            DataTable dt = new DataTable();
            dt.Columns.Add(
             );
            da.Fill( dt );
            gridControl1 .DataSource = dt;
        }

        void temizle()
        {
            txtad.Text = "";
            txtıd.Text = "";
            txtygörev.Text = "";
            txtyetkili.Text = "";
            txtvergidaire.Text = "";
            txttc.Text = "";
            
            txtsektör.Text = "";
            txtmail.Text = "";
           
            mskfax.Text = "";
            msktel1.Text = "";
            msktel2.Text = "";
            msktel3.Text = "";
            rcadres.Text = "";
            txtkod1.Text = "";
            txtkod2.Text = "";
            txtkod3.Text = "";
            cmbil.Text = "";
            cmbilçe.Text = "";
             txtad .Focus ();
        }
        private void frmfirmalar_Load(object sender, EventArgs e)
        {
            firmalistesi ();
            sehirlistesi ();
            cariakodcıklamalar();
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

        void cariakodcıklamalar()
        {
            SqlCommand komut = new SqlCommand("select FİRMAKOD1 from tblkodlar ", bgl.baglantı());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                rckod1 .Text = dr[0].ToString();
            }
            bgl.baglantı().Close();
        }
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                txtıd.Text = dr["ID"].ToString();
                txtad.Text = dr["AD"].ToString();
                txtygörev .Text = dr["YETKİLİSTATÜ"].ToString();
                txtyetkili .Text = dr["YETKİLİADSOYAD"].ToString();
                txttc .Text = dr["YETKİLİTC"].ToString();
                txtsektör .Text = dr["SEKTÖR"].ToString();
                msktel1 .Text = dr["TELEFON1"].ToString();
                msktel2 .Text = dr["TELEFON2"].ToString();
                msktel3.Text = dr["TELEFON3"].ToString();
                txtmail .Text = dr["MAİL"].ToString();
                mskfax .Text = dr["FAX"].ToString();
                cmbil .Text = dr["İL"].ToString();
                cmbilçe .Text = dr["İLÇE"].ToString();
                txtvergidaire .Text = dr["VERGİDAİRE"].ToString();
                rcadres .Text = dr["ADRES"].ToString();
                txtkod1 .Text = dr["OZELKOD1"].ToString();
                txtkod2 .Text = dr["OZELKOD2"].ToString();
                txtkod3 .Text = dr["OZELKOD3"].ToString();
            
            }
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into tblfirmalar (AD,YETKİLİSTATÜ,YETKİLİADSOYAD,YETKİLİTC,SEKTÖR,TELEFON1,TELEFON2,TELEFON3,MAİL,FAX,İL,İLÇE,VERGİDAİRE,ADRES,OZELKOD1,OZELKOD2,OZELKOD3) VALUES (@P1,@P2,@P3,@P4,@p5,@P6,@P7,@P8,@P9,@P10,@P11,@P12,@P13,@P14,@P15,@P16,@P17)", bgl.baglantı());

            komut.Parameters.AddWithValue("@P1", txtad.Text);
            komut.Parameters.AddWithValue("@P2", txtyetkili .Text);
            komut.Parameters.AddWithValue("@P3", txtygörev .Text);
            komut.Parameters.AddWithValue("@P4", txttc .Text);
            komut.Parameters.AddWithValue("@P5", txtsektör .Text);
            komut.Parameters.AddWithValue("@P6", msktel1 .Text);
            komut.Parameters.AddWithValue("@P7", msktel2  .Text);
            komut.Parameters.AddWithValue("@P8", msktel3 .Text);
            komut.Parameters.AddWithValue("@P9", txtmail .Text);
            komut.Parameters.AddWithValue("@P10", mskfax .Text);
            komut.Parameters.AddWithValue("@P11", cmbil .Text);
            komut.Parameters.AddWithValue("@P12", cmbilçe .Text);
            komut.Parameters.AddWithValue("@P13", txtvergidaire .Text);
            komut.Parameters.AddWithValue("@P14", rcadres .Text);
            komut.Parameters.AddWithValue("@P15", txtkod1 .Text);
            komut.Parameters.AddWithValue("@P16", txtkod2 .Text);
            komut.Parameters.AddWithValue("@P17", txtkod3.Text);
            komut .ExecuteNonQuery ();
            bgl.baglantı ().Close ();
            MessageBox .Show ("Firma sisteme kaydedildi ","Bilgi",MessageBoxButtons.OK ,MessageBoxIcon.Information );
            firmalistesi();
            temizle();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            temizle();
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

        private void btnsil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("delete from tblfirmalar where ID=@P1", bgl.baglantı());
            komut.Parameters.AddWithValue("@P1", txtıd.Text);
            komut.ExecuteNonQuery();
            bgl.baglantı().Close();
            firmalistesi();
            MessageBox.Show("Firma listeden silindi ", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            temizle();
        }

        private void btngüncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update tblfirmalar set AD=@P1,YETKİLİSTATÜ=@P2,YETKİLİADSOYAD=@P3,YETKİLİTC=@P4,SEKTÖR=@P5,TELEFON1=@P6,TELEFON2=@P7,TELEFON3=@P8,MAİL=@P9,FAX=@P10,İL=@P11,İLÇE=@P12,VERGİDAİRE=@P13,ADRES=@P14,OZELKOD1=@P15,OZELKOD2=@P16,OZELKOD3=@P17 WHERE ID=@P18 ", bgl.baglantı());
            komut.Parameters.AddWithValue("@P1", txtad.Text);
            komut.Parameters.AddWithValue("@P2", txtyetkili.Text);
            komut.Parameters.AddWithValue("@P3", txtygörev.Text);
            komut.Parameters.AddWithValue("@P4", txttc.Text);
            komut.Parameters.AddWithValue("@P5", txtsektör.Text);
            komut.Parameters.AddWithValue("@P6", msktel1.Text);
            komut.Parameters.AddWithValue("@P7", msktel2.Text);
            komut.Parameters.AddWithValue("@P8", msktel3.Text);
            komut.Parameters.AddWithValue("@P9", txtmail.Text);
            komut.Parameters.AddWithValue("@P10", mskfax.Text);
            komut.Parameters.AddWithValue("@P11", cmbil.Text);
            komut.Parameters.AddWithValue("@P12", cmbilçe.Text);
            komut.Parameters.AddWithValue("@P13", txtvergidaire.Text);
            komut.Parameters.AddWithValue("@P14", rcadres.Text);
            komut.Parameters.AddWithValue("@P15", txtkod1.Text);
            komut.Parameters.AddWithValue("@P16", txtkod2.Text);
            komut.Parameters.AddWithValue("@P17", txtkod3.Text);
            komut.Parameters.AddWithValue("@P18", txtıd.Text);
            komut.ExecuteNonQuery();
            bgl.baglantı().Close();
            MessageBox.Show("Firma bilgileri güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            firmalistesi();
            temizle();
        }
    }
}
