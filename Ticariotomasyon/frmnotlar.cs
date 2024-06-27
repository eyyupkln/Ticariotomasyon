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
    public partial class frmnotlar : Form
    {
        public frmnotlar()
        {
            InitializeComponent();
        }
        sqlbaglantısı bgl = new sqlbaglantısı();

        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from tblnotlar ",bgl .baglantı ());
            da .Fill (dt);
            gridControl1 .DataSource = dt;

        }

        void temizle()
        {
            txtoluşturan.Text = "";
            txthitap.Text = "";
            txtıd.Text = "";
            txtdetay.Text = "";
            msktarih.Text = "";
            msksaat.Text = "";
            txtbaşlık.Text = "";
        }
        private void frmnotlar_Load(object sender, EventArgs e)
        {
            listele();
            temizle ();
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into tblnotlar (TARİH ,SAAT,BAŞLIK , DETAY,OLUŞTURAN,HİTAP) VALUES (@P1,@P2,@P3,@P4,@P5,@P6) ",bgl .baglantı ());
            komut.Parameters.AddWithValue("@P1", msktarih.Text);
            komut.Parameters.AddWithValue("@P2", msksaat .Text);
            komut.Parameters.AddWithValue("@P3", txtbaşlık .Text);
            komut.Parameters.AddWithValue("@P4", txtdetay .Text);
            komut.Parameters.AddWithValue("@P5", txtoluşturan .Text);

            komut.Parameters.AddWithValue("@P6", txthitap .Text);
            komut .ExecuteNonQuery ();
            bgl .baglantı ().Close ();
            MessageBox.Show("Not sisteme kaydedildi ", "Bilgi ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            listele ();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            if (dr != null)
            {
                txtıd.Text = dr["ID"].ToString();
                txthitap .Text = dr["HİTAP"].ToString();
                txtdetay .Text = dr["DETAY"].ToString();
                txtbaşlık .Text = dr["BAŞLIK"].ToString();
                msktarih .Text = dr["TARİH"].ToString();
                msksaat .Text = dr["SAAT"].ToString();
                txtoluşturan .Text = dr["OLUŞTURAN"].ToString();
            }
        }

        private void btntemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("delete from tblnotlar where ID=@P1", bgl.baglantı());
            komut .Parameters .AddWithValue ("@P1",txtıd .Text);
            komut .ExecuteNonQuery ();
            bgl .baglantı ().Close ();
            MessageBox .Show ("Not sistemden silindi","Bilgi",MessageBoxButtons.OK ,MessageBoxIcon.Information );
            listele();
                
        }

        private void btngüncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update tblnotlar set TARİH=@P1,SAAT=@P2,BAŞLIK=@P3,DETAY=@P4,OLUŞTURAN=@P5,HİTAP=@P6 WHERE ID=@P7", bgl.baglantı());
              
            komut.Parameters.AddWithValue("@P1", msktarih.Text);
            komut.Parameters.AddWithValue("@P2", msksaat.Text);
            komut.Parameters.AddWithValue("@P3", txtbaşlık.Text);
            komut.Parameters.AddWithValue("@P4", txtdetay.Text);
            komut.Parameters.AddWithValue("@P5", txtoluşturan.Text);

            komut.Parameters.AddWithValue("@P6", txthitap.Text);
            komut.Parameters.AddWithValue("@P7", txtıd.Text);
            komut.ExecuteNonQuery();
            bgl.baglantı().Close();
            MessageBox.Show("Not bilgisi güncellendi ", "Bilgi ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            listele();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            frmnotdetay fr= new frmnotdetay();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            if (dr != null)
            {
                fr.metin = dr["DETAY"].ToString();
                
            }
            fr.Show();
        }
    }
}
