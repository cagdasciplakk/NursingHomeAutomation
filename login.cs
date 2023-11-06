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

namespace HuzurEviOtomasyonu
{
    public partial class login : Form
    {
        SqlConnection con;
        SqlDataAdapter da;
        SqlDataReader dr;
        SqlCommand cmd;
        DataSet ds;
        public static string SqlCon = @"Data Source=CAKI\SQLEXPRESS;Initial Catalog=deneme;Integrated Security=True";
        // User Id=sa, password=XXXXXXX

        public int denemeSayisi = 0;

        public static string KullanicimSession = "";

       
        public login()
        {
            InitializeComponent();
            con = new SqlConnection(SqlCon);
            da = new SqlDataAdapter("select * from Tbl_HuzurEviGirisT", con);
        }

        public void Login()
        {
            string sorgu = "select *from Tbl_HuzurEviGirisT where TcKimlikNo=@user and Parola=@pass";
            con = new SqlConnection(SqlCon);
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@user", maskedTextBox_Tc.Text);
            cmd.Parameters.AddWithValue("@pass", VeriTabani.MD5Sifrele(textBox_parola.Text));

            con.Open();
            dr = cmd.ExecuteReader();
            //eger veri geldiyse
            if (dr.Read())
            {
                MessageBox.Show("Tebrikler giris basarili...");
            }
            else
            {
                MessageBox.Show("Kullanici adi veya sifre hatali...");
                maskedTextBox_Tc.Clear();
                textBox_parola.Clear();
                maskedTextBox_Tc.Focus();
            }
            con.Close();
        }




        private void login_Load(object sender, EventArgs e)
        {

        }

        private void button_cikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_giris_Click(object sender, EventArgs e)
        {
            if (VeriTabani.LoginKontrol(maskedTextBox_Tc.Text, textBox_parola.Text))
            {
                //MessageBox.Show("Tebrikler giris basarili...");
                this.Hide();
                KullanicimSession = maskedTextBox_Tc.Text;
                if (KullanicimSession == "11111111111")
                {
                    // yonetici ise
                    Yonetici_Form a = new Yonetici_Form();
                    a.Show();
                }
                else
                {
                    // kullanici ise 
                    İslemler a = new İslemler();
                    a.Show();
                }

                //Form1 a = new Form1();
                //a.Show();
            }
            else
            {
                MessageBox.Show("Kullanici adi veya sifre hatali...");
                denemeSayisi++;
                if (denemeSayisi == 3)
                {
                    MessageBox.Show("3 defa hatali giris yaptiniz...");
                    Application.Exit();
                }
            }
        }
    }
}
