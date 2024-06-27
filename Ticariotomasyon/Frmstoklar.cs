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
using DevExpress.Internal;

namespace Ticariotomasyon
{
    public partial class Frmstoklar : Form
    {
        public Frmstoklar()
        {
            InitializeComponent();
        }
        sqlbaglantısı bgl = new sqlbaglantısı();

        private void Frmstoklar_Load(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("select ÜRÜNAD , sum (ADET) as 'ADET'   from tblürünler group by ÜRÜNAD", bgl.baglantı());

            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1 .DataSource = dt; 


            //charta stok miktarı listeleme


            SqlCommand  komut = new SqlCommand("select ÜRÜNAD , sum (ADET) as 'ADET'   from tblürünler group by ÜRÜNAD", bgl.baglantı());

            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                chartControl1.Series["Series 1"].Points.AddPoint(Convert.ToString (dr[0]), int.Parse(dr[1].ToString()));

            }
            bgl .baglantı ().Close ();

            SqlCommand komut2 = new SqlCommand("select İL ,count (*) from tblfirmalar group by İL", bgl.baglantı());
            SqlDataReader dr2= komut2.ExecuteReader();
            while (dr2.Read())
            {
                chartControl2.Series["Series 1"].Points .AddPoint (Convert.ToString(dr2[0]), int.Parse(dr2[1].ToString()));
            }
            bgl .baglantı ().Close ();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            frmstokdetay  fr = new frmstokdetay ();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            if (dr != null)
            {
                fr.ad = dr["ÜRÜNAD"].ToString();

            }
            fr.Show();
        }
    }
}
