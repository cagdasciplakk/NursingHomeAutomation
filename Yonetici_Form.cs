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
    public partial class Yonetici_Form : Form
    {


        SqlConnection con;
        SqlDataAdapter da;
        SqlCommand cmd;
        DataSet ds;
        public static string SqlCon = @"Data Source=CAKI\SQLEXPRESS;Initial Catalog=deneme;Integrated Security=True";
        // User Id=sa, password=XXXXXXX
        void GridDoldur()
        {
            con = new SqlConnection(SqlCon);
            da = new SqlDataAdapter("select * from Tbl_HuzurEviGirisT", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "Tbl_HuzurEviGirisT");
            dataGridView1.DataSource = ds.Tables["Tbl_HuzurEviGirisT"];
            con.Close();
        }
            public Yonetici_Form()
        {
            InitializeComponent();
        }

        private void Yonetici_Form_Load(object sender, EventArgs e)
        {
            VeriTabani.GridTumunuDoldur(dataGridView1, "Tbl_HuzurEviGirisT");
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[0].HeaderText = "TC Kimlik No";
            dataGridView1.Columns[2].HeaderCell.Value = "Son Giris Tarihi";
            dataGridView1.Columns[2].Width = 500;

        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            maskedTextBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            maskedTextBox1.Clear();
            textBox2.Clear();
            dateTimePicker1.Value = DateTime.Now;
            maskedTextBox1.Focus();
            MessageBox.Show("Kayıt Eklemek İçin TC Kimlik No Ve Şifre Giriniz");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand();
            string sql = "insert into Tbl_HuzurEviGirisT(TckimlikNo, Parola, Tarih) values ('" + maskedTextBox1.Text + "' , '" + VeriTabani.MD5Sifrele(textBox2.Text) + "', '" + dateTimePicker1.Value.ToString("yyyy-MM-dd hh:mm:ss") + "')";
            cmd.Parameters.AddWithValue("@TckimlikNo", maskedTextBox1.Text);
            cmd.Parameters.AddWithValue("@Parola", VeriTabani.MD5Sifrele(textBox2.Text));
            cmd.Parameters.AddWithValue("@Tarih", DateTime.Now);

            VeriTabani.KomutYollaParametreli(sql, cmd);


            GridDoldur();
            MessageBox.Show("Kayıt Başarıyla Gerçekleştirildi");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(SqlCon);
            string sql = "delete from Tbl_HuzurEviGirisT where TCkimlikNo=@user and Parola=@pass";
            cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@user", maskedTextBox1.Text);
            cmd.Parameters.AddWithValue("@pass", textBox2.Text);

            con.Open();
            cmd.Connection = con;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            con.Close();
            GridDoldur();
            MessageBox.Show("Kayıt Başarıyla Silindi");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(SqlCon);
            string sql = "update Tbl_HuzurEviGirisT set Parola='" + VeriTabani.MD5Sifrele(textBox2.Text) + "' where TCkimlikNo='" + maskedTextBox1.Text + "'";
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            con.Close();

            GridDoldur();

            MessageBox.Show("Kayıt Başarıyla Güncellendi");
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
