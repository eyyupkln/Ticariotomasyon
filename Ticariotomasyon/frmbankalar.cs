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
using DevExpress.Data.Linq.Helpers;

namespace Ticariotomasyon
{
    public partial class frmbankalar : Form
    {
        public frmbankalar()
        {
            InitializeComponent();
        }
        sqlbaglantısı bgl = new sqlbaglantısı();

        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(" EXECUTE BANKABİLGİLERİ ",bgl.baglantı ());
            da .Fill (dt);
            gridControl1.DataSource = dt;

        }

        void firmalistesi()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select ID,AD from tblfirmalar ", bgl.baglantı());
            da .Fill (dt);
            
            cmbfirma .Properties .ValueMember = "ID";
            cmbfirma .Properties.DisplayMember = "AD";
            cmbfirma .Properties.DataSource = dt;
            

        }
        private void frmbankalar_Load(object sender, EventArgs e)
        {
            listele ();
            sehirlistesi();
            firmalistesi();
        }

        void temizle()
        {
            txtıd.Text = "";
            txtbankaad.Text = "";
            txthesapno.Text = "";
            txthesaptürü.Text = "";
            txtyetkili.Text = "";
            txtıban.Text = "";
            txtşube.Text = "";
            msktarih.Text = "";
            msktel.Text = "";
            cmbfirma.Text = "";
            cmbil.Text = "";
            cmbilçe.Text = "";
        }
        void sehirlistesi()
        {
            SqlCommand komut = new SqlCommand("select ŞEHİR from tbliller  ", bgl.baglantı());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                cmbil.Properties.Items.Add(dr[0]);
            }
            bgl.baglantı().Close();
        }
        private void btnkaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into tblbankalar (BANKADI,İL,İLÇE,ŞUBE,IBAN,HESAPNO,YETKİLİ,TELEFON,TARİH,HESAPTÜRÜ,FİRMAID) VALUES (@P1,@P2,@P3,@P4,@P5,@P6,@P7,@P8,@P9,@P10,@P11)", bgl.baglantı());
            komut.Parameters.AddWithValue("@P1", txtbankaad.Text);
            komut.Parameters.AddWithValue("@P2", cmbil .Text);
            komut.Parameters.AddWithValue("@P3", cmbilçe .Text);
            komut.Parameters.AddWithValue("@P4", txtşube .Text);
            komut.Parameters.AddWithValue("@P5", txtıban .Text);
            komut.Parameters.AddWithValue("@P6", txthesapno .Text);
            komut.Parameters.AddWithValue("@P7", txtyetkili .Text);
            komut.Parameters.AddWithValue("@P8", msktel .Text);
            komut.Parameters.AddWithValue("@P9", msktarih .Text);
            komut.Parameters.AddWithValue("@P10", txthesaptürü .Text);
            komut.Parameters.AddWithValue("@P11", cmbfirma  .EditValue );
            komut .ExecuteNonQuery ();
            bgl.baglantı().Close();
            MessageBox.Show("Banka bilgisi sisteme kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();

        }
        
        private void cmbil_Properties_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            cmbilçe.Properties.Items.Clear();
            SqlCommand komut = new SqlCommand("select İLÇE from tblilçeler where ŞEHİR = @p1", bgl.baglantı());
            komut.Parameters.AddWithValue("@p1", cmbil.SelectedIndex + 1);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                cmbilçe.Properties.Items.Add(dr[0]);
            }
            bgl.baglantı().Close();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            if (dr != null)
            {
                txtıd .Text = dr["ID"].ToString();
                txtbankaad .Text = dr["BANKADI"].ToString();
                cmbil .Text = dr["İL"].ToString();
                cmbilçe .Text = dr["İLÇE"].ToString();
                txtşube .Text = dr["ŞUBE"].ToString();
                txtıban .Text = dr["IBAN"].ToString();
                txthesapno .Text = dr["HESAPNO"].ToString();
                txtyetkili .Text = dr["YETKİLİ"].ToString();
                msktel .Text = dr["TELEFON"].ToString();
                msktarih .Text = dr["TARİH"].ToString();
                txthesaptürü  .Text = dr["HESAPTÜRÜ"].ToString();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("delete from tblbankalar where ID=@P1", bgl.baglantı());
            komut .Parameters .AddWithValue ("@P1",txtıd .Text );
            komut.ExecuteNonQuery();
            MessageBox .Show ("Banka bilgisi sistemden silindi ","Bilgi",MessageBoxButtons.OK , MessageBoxIcon.Warning  );
            temizle();
            listele();
        }

        private void btngüncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update tblbankalar set BANKADI=@P1,İL=@P2,İLÇE=@P3,ŞUBE=@P4,IBAN=@P5,HESAPNO=@P6,YETKİLİ=@P7,TELEFON=@P8,TARİH=@P9,HESAPTÜRÜ=@P10,FİRMAID=@P11 WHERE ID=@P12", bgl.baglantı());
            komut.Parameters.AddWithValue("@P1", txtbankaad.Text);
            komut.Parameters.AddWithValue("@P2", cmbil.Text);
            komut.Parameters.AddWithValue("@P3", cmbilçe.Text);
            komut.Parameters.AddWithValue("@P4", txtşube.Text);
            komut.Parameters.AddWithValue("@P5", txtıban.Text);
            komut.Parameters.AddWithValue("@P6", txthesapno.Text);
            komut.Parameters.AddWithValue("@P7", txtyetkili.Text);
            komut.Parameters.AddWithValue("@P8", msktel.Text);
            komut.Parameters.AddWithValue("@P9", msktarih.Text);
            komut.Parameters.AddWithValue("@P10", txthesaptürü.Text);
            komut.Parameters.AddWithValue("@P11", cmbfirma.EditValue);
            komut.Parameters.AddWithValue("@P12", txtıd.EditValue);
            komut.ExecuteNonQuery();
            bgl.baglantı().Close();
            MessageBox.Show("Banka bilgisi güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
            temizle();
        }
    }
}
