using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DevExpress.Pdf.Native.BouncyCastle.Asn1.X509.SigI;

namespace Ticariotomasyon
{
    public partial class frmraporlar : Form
    {
        public frmraporlar()
        {
            InitializeComponent();
        }

        sqlbaglantısı  bgl = new sqlbaglantısı();
        void firmalistesi()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from tblfirmalar ", bgl.baglantı());
            DataTable dt = new DataTable();
            dt.Columns.Add(
             );
            da.Fill(dt);
            gridControl2.DataSource = dt;
        }


        void müşterilistesi()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from tblmüşteriler ", bgl.baglantı());
            DataTable dt = new DataTable();
            dt.Columns.Add(
             );
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        void personel()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from tblpersoneller ", bgl.baglantı());
            DataTable dt = new DataTable();
            dt.Columns.Add(
             );
            da.Fill(dt);
            gridControl7.DataSource = dt;
        }

        void gider()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from tblgiderler ", bgl.baglantı());
            DataTable dt = new DataTable();
            dt.Columns.Add(
             );
            da.Fill(dt);
            gridControl6.DataSource = dt;
        }
        private void frmraporlar_Load(object sender, EventArgs e)
        {
            gider();
            personel();
          
            firmalistesi ();
            müşterilistesi();
        }

        
    }
}
