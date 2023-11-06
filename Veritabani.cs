using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
//using System.Data;
using System.Security.Cryptography;
namespace HuzurEviOtomasyonu
{
    class VeriTabani
    {
        VeriTabani()
        {

        }



        static SqlConnection con;
        static SqlDataAdapter da;
        static SqlDataReader dr;
        static SqlCommand cmd;
        static System.Data.DataSet ds;
        public static string SqlCon = @"Data Source=CAKI\SQLEXPRESS;Initial Catalog=deneme;Integrated Security=True";
        // User Id=sa, password=XXXXXXX

        public static DataGridView GridTumunuDoldur(DataGridView gridim, string sqlSelectSorgu)
        {
            con = new SqlConnection(SqlCon);
            da = new SqlDataAdapter("select * from " + sqlSelectSorgu, con);
            ds = new System.Data.DataSet();
            con.Open();
            da.Fill(ds, sqlSelectSorgu);
            gridim.DataSource = ds.Tables[sqlSelectSorgu];
            //gridim.DataSource = ds.Tables[0];
            con.Close();
            return gridim;
        }
        public static string MD5Sifrele(string SifrelenecekMetin)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] dizi = Encoding.UTF8.GetBytes(SifrelenecekMetin);
            //dizinin hash degeri cikariliyor
            dizi = md5.ComputeHash(dizi);
            StringBuilder sb = new StringBuilder();
            foreach (byte item in dizi)
                sb.Append(item.ToString("x2").ToLower());
            return sb.ToString();
        }

        public static string SHA256Sifrele(string sifrelenecekMetin)
        {
            SHA256 sha256Hash = SHA256.Create();
            //byte dizi = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(sifrelenecekMetin));
            byte[] dizi = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(sifrelenecekMetin));
            dizi = sha256Hash.ComputeHash(dizi);

            StringBuilder sb = new StringBuilder();
            foreach (byte item in dizi)
                sb.Append(item.ToString("x2").ToLower());
            return sb.ToString();
        }

        public static bool BaglantiDurum()
        {
            //veritabani baglantisi kontrol
            using (con = new SqlConnection(SqlCon))
            {
                try
                {
                    con.Open();
                    // System.Windows.Forms.MessageBox.Show("Baglanti Kuruldu")
                    return true;
                }
                catch (SqlException exp)
                {
                    System.Windows.Forms.MessageBox.Show(exp.Message);
                    return false;
                }

            }

        }

        public static bool LoginKontrol(string TcKimlikNo, string Parola)
        {
            string sorgu = "select *from Tbl_HuzurEviGirisT where TcKimlikNo=@user and Parola=@pass";
            con = new SqlConnection(SqlCon);
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@user", TcKimlikNo);
            cmd.Parameters.AddWithValue("@pass", VeriTabani.MD5Sifrele(Parola));

            con.Open();
            dr = cmd.ExecuteReader();
            //eger veri geldiyse
            if (dr.Read())
            {
                //MessageBox.Show("Tebrikler giris basarili...");
                con.Close();
                return true;

            }
            else
            {
                con.Close();
                return false;

                //MessageBox.Show("Kullanici adi veya sifre hatali...");

            }

        }

        public static void KomutYolla(string sql)
        {
            con = new SqlConnection(SqlCon);
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            con.Close();

        }

        public static void KomutYollaParametreli(string sql, SqlCommand cmd)
        {
            con = new SqlConnection(SqlCon);
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }


}
