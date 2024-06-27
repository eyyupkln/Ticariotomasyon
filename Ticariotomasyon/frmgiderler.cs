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
    public partial class frmgiderler : Form
    {
        public frmgiderler()
        {
            InitializeComponent();
        }
        sqlbaglantısı bgl = new sqlbaglantısı();
        
        void giderlistesi()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from tblgiderler order by ID Asc ", bgl.baglantı());
             da.Fill (dt);
            gridControl1 .DataSource = dt;
        }

        void temizle()
        {
            txtıd.Text = "";
            txtsu.Text = "";
            txtekstra.Text = "";
            txtdoğalgaz.Text = "";
            txtelektrik.Text = "";
            txtinternet.Text = "";
            txtmaaşlar.Text = "";
            cmbay.Text = "";
            cmbyıl.Text = "";
            rcnotlar.Text = "";

        }
        private void frmgiderler_Load(object sender, EventArgs e)
        {
            giderlistesi();

        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into tblgiderler (AY,YIL ,ELEKTRİK,SU ,DOĞALGAZ,İNTERNET,MAAŞLAR,EKSTRA,NOTLAR) VALUES (@P1,@P2,@P3,@P4,@P5,@P6,@P7,@P8,@P9)",bgl .baglantı ());
            komut.Parameters.AddWithValue("@p1", cmbay.Text);
            komut.Parameters.AddWithValue("@p2", cmbyıl .Text);
            komut.Parameters.AddWithValue("@p3",decimal .Parse ( txtelektrik .Text));
            komut.Parameters.AddWithValue("@p4",decimal .Parse ( txtsu .Text));
            komut.Parameters.AddWithValue("@p5",decimal .Parse ( txtdoğalgaz .Text));
            komut.Parameters.AddWithValue("@p6",decimal .Parse ( txtinternet .Text));
            komut.Parameters.AddWithValue("@p7",decimal .Parse ( txtmaaşlar .Text));
            komut.Parameters.AddWithValue("@p8",decimal .Parse ( txtekstra .Text));
            komut.Parameters.AddWithValue("@p9", ( rcnotlar .Text));
            komut .ExecuteNonQuery ();
            bgl.baglantı();
            MessageBox .Show ("Gider sisteme kaydedildi","Bilgi",MessageBoxButtons.OK , MessageBoxIcon.Information );
           giderlistesi ();
            
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            if (dr != null)
            {
                txtıd.Text = dr["ID"].ToString();
                cmbay .Text = dr["AY"].ToString();
                cmbyıl .Text = dr["YIL"].ToString();
                txtelektrik .Text = dr["ELEKTRİK"].ToString();
                txtsu .Text = dr["SU"].ToString();
                txtdoğalgaz .Text = dr["DOĞALGAZ"].ToString();
                txtinternet .Text = dr["İNTERNET"].ToString();
                txtmaaşlar .Text = dr["MAAŞLAR"].ToString();
                txtekstra .Text = dr["EKSTRA"].ToString();
                rcnotlar .Text = dr["NOTLAR"].ToString();
            }
        }

        private void btntemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("delete from tblgiderler where ID=@P1", bgl.baglantı());
            komut .Parameters.AddWithValue ("@P1",txtıd.Text);
            komut .ExecuteNonQuery ();
            bgl.baglantı();
            MessageBox .Show ("Gider tablodan silindi","Bilgi",MessageBoxButtons.OK ,MessageBoxIcon.Information );
            giderlistesi();
            temizle ();

        }
          
        private void btngüncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update tblgiderler set AY=@P1,YIL=@P2,ELEKTRİK=@P3,SU=@P4 ,DOĞALGAZ=@P5,İNTERNET=@P6,MAAŞLAR=@P7,EKSTRA=@P8,NOTLAR=@P9 WHERE ID=@P10",bgl.baglantı ());
            komut.Parameters.AddWithValue("@p1", cmbay.Text);
            komut.Parameters.AddWithValue("@p2", cmbyıl.Text);
            komut.Parameters.AddWithValue("@p3", decimal.Parse(txtelektrik.Text));
            komut.Parameters.AddWithValue("@p4", decimal.Parse(txtsu.Text));
            komut.Parameters.AddWithValue("@p5", decimal.Parse(txtdoğalgaz.Text));
            komut.Parameters.AddWithValue("@p6", decimal.Parse(txtinternet.Text));
            komut.Parameters.AddWithValue("@p7", decimal.Parse(txtmaaşlar.Text));
            komut.Parameters.AddWithValue("@p8", decimal.Parse(txtekstra.Text));
            komut.Parameters.AddWithValue("@p9", rcnotlar.Text);
            komut.Parameters.AddWithValue("@P10", txtıd.Text);
            komut.ExecuteNonQuery();
            bgl.baglantı();
            MessageBox.Show("Gider bilgisi güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            giderlistesi();
            temizle();
        }
    }
}
