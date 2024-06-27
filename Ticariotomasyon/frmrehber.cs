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
    public partial class frmrehber : Form
    {
        public frmrehber()
        {
            InitializeComponent();
        }
        sqlbaglantısı bgl = new sqlbaglantısı ();

        private void frmrehber_Load(object sender, EventArgs e)
        {
            // MÜŞTERİ BİLGİLERİ 
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(" select AD,SOYAD,TELEFON,TELEFON2,MAİL from tblmüşteriler", bgl.baglantı());
            da.Fill (dt);
            gridControl1 .DataSource = dt;


            //FİRMA BİLGİLERİ 
           DataTable dt2= new DataTable ();
            SqlDataAdapter da2 = new SqlDataAdapter("select  AD,YETKİLİADSOYAD,TELEFON1,TELEFON2,TELEFON3,MAİL,FAX FROM tblfirmalar", bgl.baglantı());
            da2.Fill (dt2);
            gridControl2 .DataSource = dt2;

        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            frmmail fr = new frmmail();
            DataRow dr = gridView2.GetDataRow(gridView2.FocusedRowHandle);
            if (dr != null )
            {
                fr.mail = dr["MAİL"].ToString();

            }
            fr.Show();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            frmmail fr = new frmmail();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                fr.mail = dr["MAİL"].ToString();

            }
            fr.Show();
        }
    }
}
