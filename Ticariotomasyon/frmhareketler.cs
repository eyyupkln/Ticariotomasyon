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
using DevExpress.Utils.DirectXPaint.Svg;

namespace Ticariotomasyon
{
    public partial class frmhareketler : Form
    {
        public frmhareketler()
        {
            InitializeComponent();
        }
        sqlbaglantısı bgl = new sqlbaglantısı();

        void firmahareketleri()
        {
        DataTable dt = new DataTable(); 
            SqlDataAdapter da = new SqlDataAdapter("exec FİRMAHAREKETLER",bgl .baglantı ());
            da.Fill(dt);
            gridControl2 .DataSource = dt;
        }

        void müşterihareketleri()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("exec MÜŞTERİHAREKETLER",bgl .baglantı ());
            da.Fill(dt);
            gridControl1 .DataSource = dt;
        }
        private void gridView2_DoubleClick(object sender, EventArgs e)
        {

        }

        private void frmhareketler_Load(object sender, EventArgs e)
        {
            firmahareketleri();
            müşterihareketleri();
        }
    }
}
