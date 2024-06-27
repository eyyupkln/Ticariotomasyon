using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Ticariotomasyon
{
    internal class sqlbaglantısı
    {
        public SqlConnection baglantı()
        {
            SqlConnection baglan = new SqlConnection(@"Data Source=DESKTOP-AJM9AQ8\SQLEXPRESS;Initial Catalog=Ticariotomasyon;Integrated Security=True");
            baglan .Open();
            return baglan;
        }

    }
}
