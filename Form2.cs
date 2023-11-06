using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace HuzurEviOtomasyonu
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
          
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

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                richTextBox1.Text = MD5Sifrele(textBox1.Text);
                label5.Text = richTextBox1.Text.Length.ToString();
                richTextBox2.Text = SHA256Sifrele(textBox1.Text);
                label4.Text = richTextBox2.Text.Length.ToString();
            }
        }
    }
}
