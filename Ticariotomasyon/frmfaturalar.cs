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
    public partial class frmfaturalar : Form
    {
        public frmfaturalar()
        {
            InitializeComponent();
        }

       sqlbaglantısı bgl= new sqlbaglantısı();


        void listele()
        {
            SqlDataAdapter da = new SqlDataAdapter("select *  from tblfaturabilgi", bgl.baglantı());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
                
        }
        void temizle()
        {
            txtalıcı.Text = "";
            txtarih.Text = "";
            txtsaat.Text = "";
            txtseri.Text = "";
            txtsırano.Text = "";
            txtteslimalan.Text = "";
            txtteslimden.Text = "";
            txtıd.Text = "";
            txtvergid.Text = "";

        }
        private void FATURALAR_Load(object sender, EventArgs e)
        {
            listele ();
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            if (txtfaturaıd.Text  == "")
            {
                SqlCommand komut = new SqlCommand("insert into tblfaturabilgi (SERİ , SIRANO,TARİH,SAAT,VERGİDAİRE,ALICI,TESLİMEDEN,TESLİMALAN) VALUES (@P1,@P2,@P3,@P4,@P5,@P6,@P7,@P8) ", bgl.baglantı());
                komut.Parameters.AddWithValue("@P1", txtseri.Text);
                komut.Parameters.AddWithValue("@P2", txtsırano .Text);
                komut.Parameters.AddWithValue("@P3", txtarih .Text );
                komut.Parameters.AddWithValue("@P4", txtsaat.Text);
                komut.Parameters.AddWithValue("@P5", txtvergid .Text);
                komut.Parameters.AddWithValue("@P6", txtalıcı .Text);
                komut.Parameters.AddWithValue("@P7", txtteslimden .Text);
                komut.Parameters.AddWithValue("@P8", txtteslimalan .Text);
                komut .ExecuteNonQuery ();
                bgl.baglantı();
                MessageBox .Show ("Fatura bilgisi kaydedildi ","Bilgi",MessageBoxButtons.OK ,MessageBoxIcon.Information );
                listele ();


            }
            if(txtfaturaıd .Text != ""&& comboBox1 .Text =="Firma")
            {
                double miktar, tutar, fiyat;
                tutar = Convert .ToDouble (txtfiyat .Text);
                miktar = Convert .ToDouble (txtmiktar  .Text);
                tutar = miktar * tutar;
                txttutar .Text = tutar.ToString ();

                SqlCommand komut2 = new SqlCommand("insert into tblfaturadetay (ÜRÜNAD,MİKTAR,FİYAT,TUTAR ,FATURABİLGİID) VALUES (@P1,@P2,@P3,@P4,@P5) ", bgl.baglantı());
                komut2.Parameters.AddWithValue("@p1", txtürünad.Text);
                komut2.Parameters.AddWithValue("@p2", txtmiktar .Text);
                komut2.Parameters.AddWithValue("@p3",decimal .Parse ( txtfiyat .Text));
                komut2.Parameters.AddWithValue("@p4",decimal .Parse ( txttutar .Text));
                komut2.Parameters.AddWithValue("@p5", txtfaturaıd .Text);
                komut2.ExecuteNonQuery();
                bgl.baglantı();


                //hareket tablosu veri girişi

                SqlCommand komut3 = new SqlCommand("insert into tblfirmahareketler (ÜRÜNID,ADET,PERSONEL,FİRMA,FİYAT,TOPLAM,FATURAID,TARİH) VALUES (@F1,@F2,@F3,@F4,@F5,@F6,@F7,@F8)", bgl.baglantı());
                komut3.Parameters.AddWithValue("@F1", txtürünıd.Text);
                komut3.Parameters.AddWithValue("@F2", txtmiktar.Text);
                komut3.Parameters.AddWithValue("@F3", txtpersonel.Text);
                komut3.Parameters.AddWithValue("@F4", txtfirma.Text);
                komut3.Parameters.AddWithValue("@F5", decimal.Parse(txtfiyat.Text));
                komut3.Parameters.AddWithValue("@F6", decimal.Parse(txttutar.Text));
                komut3.Parameters.AddWithValue("@F7", txtfaturaıd.Text);
                komut3.Parameters.AddWithValue("@F8", txtarih.Text);
                komut3.ExecuteNonQuery();
                bgl.baglantı().Close();

                //stok sayısı azaltma

                SqlCommand komut4 = new SqlCommand("update tblürünler set ADET=ADET-@K1 WHERE ID=@K2", bgl.baglantı());
                komut4.Parameters.AddWithValue("@K1", txtmiktar.Text);
                komut4 .Parameters .AddWithValue ("K2",txtürünıd .Text );
                komut4 .ExecuteNonQuery();
                bgl .baglantı ().Close();


                MessageBox.Show("Faturaya ait ürün  kaydedildi ", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();

            }
            if (txtfaturaıd.Text != ""&&comboBox1 .Text =="Müşteri")
            {
                double miktar, tutar, fiyat;
                tutar = Convert.ToDouble(txtfiyat.Text);
                miktar = Convert.ToDouble(txtmiktar.Text);
                tutar = miktar * tutar;
                txttutar.Text = tutar.ToString();

                SqlCommand komut2 = new SqlCommand("insert into tblfaturadetay (ÜRÜNAD,MİKTAR,FİYAT,TUTAR ,FATURABİLGİID) VALUES (@P1,@P2,@P3,@P4,@P5) ", bgl.baglantı());
                komut2.Parameters.AddWithValue("@p1", txtürünad.Text);
                komut2.Parameters.AddWithValue("@p2", txtmiktar.Text);
                komut2.Parameters.AddWithValue("@p3", decimal.Parse(txtfiyat.Text));
                komut2.Parameters.AddWithValue("@p4", decimal.Parse(txttutar.Text));
                komut2.Parameters.AddWithValue("@p5", txtfaturaıd.Text);
                komut2.ExecuteNonQuery();
                bgl.baglantı();


                //hareket tablosu veri girişi

                SqlCommand komut3 = new SqlCommand("insert into tblmüşterihareket (ÜRÜNID,ADET,PERSONEL,MÜŞTERİ,FİYAT,TOPLAM,FATURAID,TARİH) VALUES (@F1,@F2,@F3,@F4,@F5,@F6,@F7,@F8)", bgl.baglantı());
                komut3.Parameters.AddWithValue("@F1", txtürünıd.Text);
                komut3.Parameters.AddWithValue("@F2", txtmiktar.Text);
                komut3.Parameters.AddWithValue("@F3", txtpersonel.Text);
                komut3.Parameters.AddWithValue("@F4", txtfirma.Text);
                komut3.Parameters.AddWithValue("@F5", decimal.Parse(txtfiyat.Text));
                komut3.Parameters.AddWithValue("@F6", decimal.Parse(txttutar.Text));
                komut3.Parameters.AddWithValue("@F7", txtfaturaıd.Text);
                komut3.Parameters.AddWithValue("@F8", txtarih.Text);
                komut3.ExecuteNonQuery();
                bgl.baglantı().Close();

                //stok sayısı azaltma

                SqlCommand komut4 = new SqlCommand("update tblürünler set ADET=ADET-@K1 WHERE ID=@K2", bgl.baglantı());
                komut4.Parameters.AddWithValue("@K1", txtmiktar.Text);
                komut4.Parameters.AddWithValue("K2", txtürünıd.Text);
                komut4.ExecuteNonQuery();
                bgl.baglantı().Close();


                MessageBox.Show("Faturaya ait ürün  kaydedildi ", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();

            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                txtıd.Text = dr["FATURABİLGİID"].ToString();
                txtsırano.Text = dr["SIRANO"].ToString();
                txtseri.Text = dr["SERİ"].ToString();
                txtarih .Text = dr["TARİH"].ToString();
                txtsaat .Text = dr["SAAT"].ToString();
                txtvergid .Text = dr["VERGİDAİRE"].ToString();
                txtalıcı .Text = dr["ALICI"].ToString();
                txtteslimden .Text = dr["TESLİMEDEN"].ToString();
                txtteslimalan .Text = dr["TESLİMALAN"].ToString();
            }
        }

        private void btntemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("delete from tblfaturabilgi where FATURABİLGİID=@P1", bgl.baglantı());
            komut.Parameters.AddWithValue("@P1", txtıd.Text);
            komut.ExecuteNonQuery();
            bgl.baglantı().Close ();
            MessageBox.Show("Fatura silindi  ", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Question  );
            listele();
        }

        private void btngüncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update tblfaturabilgi set SERİ=@P1,SIRANO=@P2,TARİH=@P3,SAAT=@P4,VERGİDAİRE=@P5,ALICI=@P6,TESLİMEDEN=@P7,TESLİMALAN=@P8 WHERE FATURABİLGİID=@P9", bgl.baglantı());
            komut.Parameters.AddWithValue("@P1", txtseri.Text);
            komut.Parameters.AddWithValue("@P2", txtsırano.Text);
            komut.Parameters.AddWithValue("@P3", txtarih.Text);
            komut.Parameters.AddWithValue("@P4", txtsaat.Text);
            komut.Parameters.AddWithValue("@P5", txtvergid.Text);
            komut.Parameters.AddWithValue("@P6", txtalıcı.Text);
            komut.Parameters.AddWithValue("@P7", txtteslimden.Text);
            komut.Parameters.AddWithValue("@P8", txtteslimalan.Text);
            komut.Parameters.AddWithValue("@P9", txtıd .Text);

            komut.ExecuteNonQuery();
            bgl.baglantı().Close ();


            MessageBox.Show("Fatura bilgisi güncellendi ", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            frmfaturaürünler fr = new frmfaturaürünler();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            if (dr != null )
            {
                fr.id= dr["FATURABİLGİID"].ToString ();

            }
            fr.Show();
        }

        private void btntemzile_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select ÜRÜNAD,SATIŞFİYAT FROM tblürünler where ID = @p1", bgl.baglantı());
            komut.Parameters.AddWithValue("@p1", txtürünıd.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read () )
            {
                txtürünad.Text = dr[0].ToString();
                txtfiyat.Text = dr[1].ToString();
            }
            bgl.baglantı().Close();

        }
    }
}
