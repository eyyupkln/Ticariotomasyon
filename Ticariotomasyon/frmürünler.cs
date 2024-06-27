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
using DevExpress.Utils.Extensions;

namespace Ticariotomasyon
{
    public partial class frmürünler : Form
    {
        public frmürünler()
        {
            InitializeComponent();
        }
        sqlbaglantısı bgl = new sqlbaglantısı();

        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from tblürünler",bgl .baglantı ());
            da.Fill (dt);
            gridControl1 .DataSource = dt;



        }
        private void frmürünler_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            // verileri kaydetme 

            SqlCommand komut = new SqlCommand("insert into tblürünler (ÜRÜNAD,MARKA,MODEL,YIL,ADET,ALIŞFİYAT,SATIŞFİYAT,DETAY) VALUES (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8) ",bgl .baglantı ());
            komut.Parameters.AddWithValue("@p1", txtad.Text);
            komut .Parameters .AddWithValue ("@p2",txtmarka.Text);
            komut .Parameters .AddWithValue ("@p3",txtmodel .Text);
            komut.Parameters.AddWithValue("@p4", mskyıl.Text);
            komut .Parameters .AddWithValue ("@p5",int .Parse (numadet.Text ).ToString ());
            komut .Parameters .AddWithValue ("@p6",decimal .Parse (txtalışfiyat .Text).ToString ());
            komut .Parameters .AddWithValue("@p7",decimal .Parse (txtsatışfiyat .Text).ToString ());
            komut .Parameters .AddWithValue ("@p8",rcdetay .Text);
            komut .ExecuteNonQuery ();
            bgl .baglantı().Close ();
            MessageBox .Show ("Ürün eklendi","Bilgi",MessageBoxButtons.OK , MessageBoxIcon.Information );
            listele ();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            SqlCommand komutsil = new SqlCommand("delete from tblürünler where ID=@p1", bgl.baglantı());
            komutsil.Parameters.AddWithValue("@p1", txtıd.Text);
            komutsil .ExecuteNonQuery ();
            bgl .baglantı ().Close ();
            MessageBox.Show("Ürün silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error );
            listele();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            txtıd.Text = dr["ID"].ToString ();
            txtad.Text = dr["ÜRÜNAD"].ToString ();
            txtmarka .Text = dr["MARKA"].ToString ();
            txtmodel .Text = dr["MODEL"].ToString ();
            mskyıl .Text = dr["YIL"].ToString();
            numadet .Value  =decimal .Parse ( dr["ADET"].ToString());
            txtalışfiyat .Text = dr["ALIŞFİYAT"].ToString();
            
            txtsatışfiyat .Text = dr["SATIŞFİYAT"].ToString();
            rcdetay .Text = dr["DETAY"].ToString();


        }

        private void btngüncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update tblürünler set ÜRÜNAD=@p1,MARKA=@p2,MODEL=@p3,YIL=@p4,ADET=@p5,ALIŞFİYAT=@p6,SATIŞFİYAT=@p7,DETAY=@p8 where ID=@p9",bgl .baglantı ());
            komut.Parameters.AddWithValue("@p1", txtad.Text);
            komut.Parameters.AddWithValue("@p2", txtmarka.Text);
            komut.Parameters.AddWithValue("@p3", txtmodel.Text);
            komut.Parameters.AddWithValue("@p4", mskyıl.Text);
            komut.Parameters.AddWithValue("@p5", int .Parse(numadet.Text  ).ToString());
            komut.Parameters.AddWithValue("@p6", decimal.Parse(txtalışfiyat.Text.ToString()));
            komut.Parameters.AddWithValue("@p7", decimal.Parse(txtsatışfiyat.Text.ToString()));
            komut.Parameters.AddWithValue("@p8", rcdetay.Text);
            komut .Parameters .AddWithValue ("@p9",txtıd.Text);
            komut.ExecuteNonQuery();
            bgl.baglantı().Close();
            MessageBox.Show("Ürün bilgisi güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning );
            listele();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            txtıd.Text = "";
            txtad.Text = "";
            txtmarka.Text = "";
            txtmodel.Text = "";
            txtalışfiyat.Text = "";
            txtsatışfiyat.Text = "";
            mskyıl.Text = "";
            rcdetay.Text = "";
            numadet.Text = "";
            txtad .Focus ();
        }
    }
}
