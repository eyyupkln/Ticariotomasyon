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
using DevExpress.XtraRichEdit.Layout.Export;
using DevExpress.Charts;

namespace Ticariotomasyon
{
    public partial class frmkasa : Form
    {
        public frmkasa()
        {
            InitializeComponent();
        }
        sqlbaglantısı bgl = new sqlbaglantısı();

        void müşterihareket()
        {
            DataTable dt = new DataTable(); 
            SqlDataAdapter da = new SqlDataAdapter("execute MÜŞTERİHAREKETLER",bgl .baglantı ());
            da.Fill(dt);
            gridControl1 .DataSource = dt;
        }
        void firmaharektler()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("execute FİRMAHAREKETLER", bgl.baglantı());
            da.Fill(dt);
            gridControl3.DataSource = dt;
        }
        void giderlistesi()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from tblgiderler order by ID Asc ", bgl.baglantı());
            da.Fill(dt);
            gridControl2.DataSource = dt;
        }

        public string ad;
        private void frmkasa_Load(object sender, EventArgs e)
        {
            giderlistesi();
            lblaktifkullanıcı.Text = ad;
            müşterihareket();
            firmaharektler();

            //sorguları yazarak istatistik çekme


            SqlCommand komut = new SqlCommand("select sum(TUTAR) FROM tblfaturadetay", bgl.baglantı());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                lbltoplamtutare.Text = dr[0].ToString() + "TL";
            }
            bgl.baglantı().Close();

            // son ayın faturaları 
            SqlCommand komut2 = new SqlCommand("select (ELEKTRİK + SU + DOĞALGAZ + İNTERNET + EKSTRA) FROM tblgiderler order by ID asc", bgl.baglantı());
            SqlDataReader dr2 = komut2 .ExecuteReader();
            while (dr2.Read())
            {
                lblödeme.Text = dr2[0].ToString() + "TL";
            }
            bgl .baglantı ().Close ();


            // son ayın personel maaşları 

            SqlCommand komut3 = new SqlCommand("select MAAŞLAR from tblgiderler  order by ID asc ", bgl.baglantı());
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                lblpersonelmaaşları.Text = dr3[0].ToString() + "TL";
            }
            bgl .baglantı ().Close ();


            //MÜŞTERİ SAYISI 

            SqlCommand komut4 = new SqlCommand("select count(*) from tblmüşteriler ", bgl.baglantı());
            SqlDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {
                lblmüşterisayısı .Text = dr4[0].ToString();
            }
            bgl.baglantı().Close();


            //firma sayısı 
            SqlCommand komut5 = new SqlCommand("select count(*) from tblfirmalar ", bgl.baglantı());
            SqlDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read())
            {
                lblfirmasayısı .Text = dr5[0].ToString();
            }
            bgl.baglantı().Close();

            // toplam firma şehir sayısı 

            
            SqlCommand komut6 = new SqlCommand("select count(distinct(İL)) from tblfirmalar ", bgl.baglantı());
            SqlDataReader dr6 = komut6.ExecuteReader();
            while (dr6.Read())
            {
                lblfirmaşehirsayısı .Text = dr6[0].ToString();
            }
            bgl.baglantı().Close();

            //TOPLAM MÜŞTERİ ŞEHİR SAYISI 

            SqlCommand komut7 = new SqlCommand("select count(distinct(İL)) from tblmüşteriler ", bgl.baglantı());
            SqlDataReader dr7 = komut7.ExecuteReader();
            while (dr7.Read())
            {
                lblmüşterişehirsayısı .Text = dr7[0].ToString();
            }
            bgl.baglantı().Close();

            //TOPLAM PERSONEL ŞEHİR SAYISI 

            SqlCommand komut8 = new SqlCommand("select count(*) from tblpersoneller ", bgl.baglantı());
            SqlDataReader dr8 = komut8.ExecuteReader();
            while (dr8.Read())
            {
                lblpersonelsayısı .Text = dr8[0].ToString();
            }
            bgl.baglantı().Close();



            //TOPLAM stok ŞEHİR SAYISI 

            SqlCommand komut9= new SqlCommand("select sum(ADET) from tblürünler ", bgl.baglantı());
            SqlDataReader dr9 = komut9.ExecuteReader();
            while (dr9.Read())
            {
                lblstoksayısı .Text = dr9[0].ToString();
            }
            bgl.baglantı().Close();




        }
        int sayaç = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            sayaç++;

            if(sayaç >0 && sayaç <= 5)
            {
                chartControl1.Series["AYLAR"].Points.Clear();
                groupControl8.Text = "ELEKTRİK";
                //1.charta elektrik faturası son 4 ay listeleme 
                SqlCommand komut10 = new SqlCommand("select top 4 AY,ELEKTRİK from tblgiderler order by ID desc", bgl.baglantı());
                SqlDataReader dr10 = komut10.ExecuteReader();
                while (dr10.Read())
                {
                    chartControl1.Series["AYLAR"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr10[0], dr10[1]));
                }
                bgl.baglantı().Close();


            }
            if (sayaç >5 && sayaç <= 10)
            {
                chartControl1.Series["AYLAR"].Points.Clear(); 
                groupControl8.Text = "SU";
                //2.charta elektrik faturası son 4 ay listeleme 
                SqlCommand komut11 = new SqlCommand("select top 4 AY,SU from tblgiderler order by ID desc", bgl.baglantı());
                SqlDataReader dr11 = komut11.ExecuteReader();
                while (dr11.Read())
                {
                    chartControl1.Series["AYLAR"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr11[0], dr11[1]));
                }
                bgl.baglantı().Close();
            }
            if (sayaç >10 && sayaç <= 15)
            {
                chartControl1.Series["AYLAR"].Points.Clear();
                groupControl8.Text = "İNTERNET";
                
                //2.charta elektrik faturası son 4 ay listeleme 
                SqlCommand komut12 = new SqlCommand("select top 4 AY,İNTERNET from tblgiderler order by ID desc", bgl.baglantı());
                SqlDataReader dr12 = komut12.ExecuteReader();
                while (dr12.Read())
                {
                    chartControl1.Series["AYLAR"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr12[0], dr12[1]));
                }
                bgl.baglantı().Close();


            }
            if (sayaç >15 && sayaç <= 20)
            {
                chartControl1.Series["AYLAR"].Points.Clear();
                groupControl8.Text = "DOĞALGAZ";
                //2.charta elektrik faturası son 4 ay listeleme 
                SqlCommand komut13 = new SqlCommand("select top 4 AY,DOĞALGAZ from tblgiderler order by ID desc", bgl.baglantı());
                SqlDataReader dr13 = komut13.ExecuteReader();
                while (dr13.Read())
                {
                    chartControl1.Series["AYLAR"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr13[0], dr13[1]));
                }
                bgl.baglantı().Close();
            }
            if( sayaç >20 && sayaç <= 25)
            {
                chartControl1.Series["AYLAR"].Points.Clear();
                groupControl8.Text = "EKSTRA";
                //2.charta elektrik faturası son 4 ay listeleme 
                SqlCommand komut14 = new SqlCommand("select top 4 AY,EKSTRA from tblgiderler order by ID desc", bgl.baglantı());
                SqlDataReader dr14 = komut14.ExecuteReader();
                while (dr14.Read())
                {
                    chartControl1.Series["AYLAR"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr14[0], dr14[1]));
                }
                bgl.baglantı().Close();
            }
            if (sayaç == 26)
            {
                sayaç = 0;
            }
            
        }
        int sayaç2 = 0;
        private void timer2_Tick(object sender, EventArgs e)
        {
            sayaç2++;

            if (sayaç2 > 0 && sayaç2 <= 5)
            {
                chartControl2.Series["AYLAR"].Points.Clear();
                groupControl9.Text = "ELEKTRİK";
                //1.charta elektrik faturası son 4 ay listeleme 
                SqlCommand komut10 = new SqlCommand("select top 4 AY,ELEKTRİK from tblgiderler order by ID desc", bgl.baglantı());
                SqlDataReader dr10 = komut10.ExecuteReader();
                while (dr10.Read())
                {
                    chartControl2.Series["AYLAR"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr10[0], dr10[1]));
                }
                bgl.baglantı().Close();


            }
            if (sayaç2 > 5 && sayaç2 <= 10)
            {
                chartControl2.Series["AYLAR"].Points.Clear();
                groupControl9.Text = "SU";
                //2.charta elektrik faturası son 4 ay listeleme 
                SqlCommand komut11 = new SqlCommand("select top 4 AY,SU from tblgiderler order by ID desc", bgl.baglantı());
                SqlDataReader dr11 = komut11.ExecuteReader();
                while (dr11.Read())
                {
                    chartControl2.Series["AYLAR"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr11[0], dr11[1]));
                }
                bgl.baglantı().Close();
            }
            if (sayaç2 > 10 && sayaç2 <= 15)
            {
                chartControl2.Series["AYLAR"].Points.Clear();
                groupControl9.Text = "İNTERNET";

                //2.charta elektrik faturası son 4 ay listeleme 
                SqlCommand komut12 = new SqlCommand("select top 4 AY,İNTERNET from tblgiderler order by ID desc", bgl.baglantı());
                SqlDataReader dr12 = komut12.ExecuteReader();
                while (dr12.Read())
                {
                    chartControl2.Series["AYLAR"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr12[0], dr12[1]));
                }
                bgl.baglantı().Close();


            }
            if (sayaç2 > 15 && sayaç2 <= 20)
            {
                chartControl2.Series["AYLAR"].Points.Clear();
                groupControl9.Text = "DOĞALGAZ";
                //2.charta elektrik faturası son 4 ay listeleme 
                SqlCommand komut13 = new SqlCommand("select top 4 AY,DOĞALGAZ from tblgiderler order by ID desc", bgl.baglantı());
                SqlDataReader dr13 = komut13.ExecuteReader();
                while (dr13.Read())
                {
                    chartControl2.Series["AYLAR"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr13[0], dr13[1]));
                }
                bgl.baglantı().Close();
            }
            if (sayaç2 > 20 && sayaç2 <= 25)
            {
                chartControl2.Series["AYLAR"].Points.Clear();
                groupControl9.Text = "EKSTRA";
                //2.charta elektrik faturası son 4 ay listeleme 
                SqlCommand komut14 = new SqlCommand("select top 4 AY,EKSTRA from tblgiderler order by ID desc", bgl.baglantı());
                SqlDataReader dr14 = komut14.ExecuteReader();
                while (dr14.Read())
                {
                    chartControl2.Series["AYLAR"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr14[0], dr14[1]));
                }
                bgl.baglantı().Close();
            }
            if (sayaç2 == 26)
            {
                sayaç2 = 0;
            }
        }
    }
}
