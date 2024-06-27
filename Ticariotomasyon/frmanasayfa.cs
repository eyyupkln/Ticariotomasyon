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
using System.Xml;

namespace Ticariotomasyon
{
    public partial class frmanasayfa : Form
    {
        public frmanasayfa()
        {
            InitializeComponent();
        }
        sqlbaglantısı bgl = new sqlbaglantısı();

        void azalanstok()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT ÜRÜNAD,SUM(ADET) AS 'ADET' FROM tblürünler group by ÜRÜNAD having sum(ADET)<=100 ORDER BY SUM(ADET) ", bgl.baglantı());

            DataTable dt = new DataTable();
            da .Fill(dt);
            gridControl1 .DataSource = dt;
        }

        void ajanda()
        {
            SqlDataAdapter da = new SqlDataAdapter("select top 7 TARİH,SAAT,BAŞLIK FROM tblnotlar order by ID desc", bgl.baglantı());
            DataTable dt = new DataTable();
            da .Fill(dt);
            gridControl4 .DataSource = dt;
        }
        void firmahareketleri()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("exec firmahareket2", bgl.baglantı());
            da.Fill(dt);
            gridControl2.DataSource = dt;
        }

        void fihrist()
        {
            SqlDataAdapter da = new SqlDataAdapter("select AD,TELEFON1 FROM tblfirmalar", bgl.baglantı());
            DataTable dt= new DataTable();
            da .Fill(dt);
            gridControl3.DataSource = dt;



        }
        void haberler()
        {
            XmlTextReader xmloku = new XmlTextReader("https://www.hurriyet.com.tr/rss/anasayfa");
            while (xmloku.Read())
            {
                if (xmloku .Name == "title")
                {
                    listBox1 .Items .Add (xmloku.ReadString   ());
                }
            }
        }
        private void frmanasayfa_Load(object sender, EventArgs e)
        {
            azalanstok();
            ajanda  ();
            firmahareketleri();
            fihrist();

            haberler();

            webBrowser1.Navigate("https://www.tcmb.gov.tr/kurlar/today.xml");
        }
    }
}
