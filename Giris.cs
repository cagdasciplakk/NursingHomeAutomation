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
    public partial class Form1 : Form
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


    


        public Form1()
        {
            InitializeComponent();
            con = new SqlConnection(SqlCon);
            da = new SqlDataAdapter("select * from tbl_HuzurEviGiriss", con);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (VeriTabani.LoginKontrol(maskedTextBox1.Text, textBox2.Text))
            {
                MessageBox.Show("Tebrikler giris basarili...");
                this.Hide();
                KullanicimSession = maskedTextBox1.ToString();
                
                
                Form1 a = new Form1();
                a.Show();
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

        private void Form1_Load(object sender, EventArgs e)
        {
             void Login()
            {
                string sorgu = "select *from tbl_HuzurEviGiriss where TcKimlikNo=@user and parola=@pass";
                con = new SqlConnection(SqlCon);
                cmd = new SqlCommand(sorgu, con);
                cmd.Parameters.AddWithValue("@user", maskedTextBox1.Text);
                cmd.Parameters.AddWithValue("@pass", VeriTabani.MD5Sifrele(textBox2.Text));

                con.Open();
                dr = cmd.ExecuteReader();
                //eger veri geldiyse
                if (dr.Read())
                {
                    MessageBox.Show("Tebrikler giriş başarılı...");
                }
                else
                {
                    MessageBox.Show("Kimlik numarası veya parola hatalı...");
                    maskedTextBox1.Clear();
                    textBox2.Clear();
                    maskedTextBox1.Focus();
                }
                con.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
