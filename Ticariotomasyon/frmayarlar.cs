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
    public partial class frmayarlar : Form
    {
        public frmayarlar()
        {
            InitializeComponent();
        }
        sqlbaglantısı bgl = new sqlbaglantısı();
        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from tbladmin", bgl.baglantı());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        private void frmayarlar_Load(object sender, EventArgs e)
        {
            listele();
            txtkullanıcıad.Text = "";
            txtşifre .Text = "";
        }

        private void btnişlemn_Click(object sender, EventArgs e)
        {
            if (btnişlemn.Text == "KAYDET")
            {

                SqlCommand komut = new SqlCommand("insert into tbladmin values (@p1,@p2)", bgl.baglantı());
                komut.Parameters.AddWithValue("@p1", txtkullanıcıad.Text);
                komut.Parameters.AddWithValue("@p2", txtşifre.Text);
                komut.ExecuteNonQuery();
                bgl.baglantı().Close();
                MessageBox.Show("Admin sisteme kaydedildi.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();
            }
            if (btnişlemn .Text == "GÜNCELLE")
            {
                SqlCommand komut = new SqlCommand("update  tbladmin set ŞİFRE=@P2 WHERE KULLANICIAD=@P1", bgl.baglantı());
                komut.Parameters.AddWithValue("@p1", txtkullanıcıad.Text);
                komut.Parameters.AddWithValue("@p2", txtşifre.Text);
                komut.ExecuteNonQuery();
                bgl.baglantı().Close();
                MessageBox.Show("Admin bilgisi güncellendi.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning );
                listele();
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            if (dr != null)
            {
                txtkullanıcıad.Text = dr["KULLANICIAD"].ToString();
                txtşifre.Text = dr["ŞİFRE"].ToString();

            }
        }

        private void txtkullanıcıad_EditValueChanged(object sender, EventArgs e)
        {
            if (txtkullanıcıad.Text != "")
            {
                btnişlemn.Text = "GÜNCELLE";
                btnişlemn.BackColor = Color.GreenYellow;
            }
            else
            {
                btnişlemn.Text = "KAYDET";
                btnişlemn.BackColor = Color.Salmon;
            }
               
        }
    }
}
