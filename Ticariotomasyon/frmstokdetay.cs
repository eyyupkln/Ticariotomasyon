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
    public partial class frmstokdetay : Form
    {
        public frmstokdetay()
        {
            InitializeComponent();
        }

        public String ad;

        sqlbaglantısı bgl= new sqlbaglantısı();
        private void frmstokdetay_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from tblürünler where ÜRÜNAD='"+ad +"'",bgl .baglantı ());
            da .Fill (dt);
            gridControl1 .DataSource = dt;


        }
    }
}
