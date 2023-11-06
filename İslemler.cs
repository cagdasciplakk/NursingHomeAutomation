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
    public partial class İslemler : Form
    {


        SqlConnection con;
        SqlDataAdapter da;
        SqlDataReader dr;
        SqlCommand cmd;
        DataSet ds;
        public static string SqlCon = @"Data Source=CAKI\SQLEXPRESS;Initial Catalog=deneme;Integrated Security=True";
        // User Id=sa, password=XXXXXXX

        public SqlConnection con2 = new SqlConnection(SqlCon);
        public SqlCommand cmd2 = new SqlCommand();
        public DataSet ds2 = new DataSet();
        void GridDoldur()
        {
            con = new SqlConnection(SqlCon);
            da = new SqlDataAdapter("select * from tbl_sakinEkle", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "tbl_sakinEkle");
            dataGridView1.DataSource = ds.Tables["tbl_sakinEkle"];
            con.Close();
        }
        void GridDoldur2()
        {
            con2 = new SqlConnection(SqlCon);
            da = new SqlDataAdapter("select * from ekle_aile", con2);
            ds2 = new DataSet();
            con2.Open();
            da.Fill(ds2, "ekle_aile");
            dataGridView2.DataSource = ds2.Tables["ekle_aile"];
            con2.Close();
        }
        void GridDoldur3(string sql)
        {
            con = new SqlConnection(SqlCon);
            da = new SqlDataAdapter(sql, con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "tbl_sakinEkle");
            dataGridView3.DataSource = ds.Tables["tbl_sakinEkle"];
            con.Close();
        }


        public İslemler()
        {
            InitializeComponent();
        }

        private void İslemler_Load(object sender, EventArgs e)
        {
            sqlSorgu = "select tbl_sakinEkle.*, ekle_aile.* from tbl_sakinEkle INNER JOIN ekle_aile ON tbl_sakinEkle. TC= ekle_aile.TC ";
            GridDoldur3(sqlSorgu);
            VeriTabani.GridTumunuDoldur(dataGridView1, "tbl_sakinEkle");
            VeriTabani.GridTumunuDoldur(dataGridView2, "ekle_aile");
          
        }

        void GridDoldurStoredProcedure2(string deger)
        {
            con = new SqlConnection(SqlCon);
            con.Open();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ListeBirlestir";
            cmd.Parameters.Add("TC", SqlDbType.NVarChar, 50).Value = "%" + deger + "%";
            //cmd1.Parameters.Add("urunID", SqlDbType.Int).Value = 5;

            da = new SqlDataAdapter(cmd);
            ds = new DataSet();

            da.Fill(ds);
            dataGridView3.DataSource = ds.Tables[0];
            con.Close();
            //cmd.ExecuteNonQuery();
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand();
            string sql = "insert into tbl_sakinEkle(TC, ADI, SOYADI, GSM_NO, DOGUM_YER, D_TARIHI, CINSIYET, KAN_GRUBU, MESLEK, GUVENCE, ADRES, RAHATSIZLIKLAR,RESIM) values (@param1,@param2,@param3,@param4,@param5,@param6,@param7,@param8,@param9,@param10,@param11,@param12,@param13)";
            cmd.Parameters.AddWithValue("@param1", masktext_tc.Text);
            cmd.Parameters.AddWithValue("@param2", textBox2.Text);
            cmd.Parameters.AddWithValue("@param3", textBox3_3.Text);
            cmd.Parameters.AddWithValue("@param4", masktext_cep.Text);
            cmd.Parameters.AddWithValue("@param5", combodyer.Text);
            cmd.Parameters.AddWithValue("@param6", mask_dt.Text);
            cmd.Parameters.AddWithValue("@param7", comboBox_cinsiyet.Text);
            cmd.Parameters.AddWithValue("@param8", combo_kan.Text);
            cmd.Parameters.AddWithValue("@param9", textBox_meslek.Text);
            cmd.Parameters.AddWithValue("@param10", combo_sgk.Text);
            cmd.Parameters.AddWithValue("@param11", textBox5.Text);
            cmd.Parameters.AddWithValue("@param12", textBox3.Text);
            cmd.Parameters.AddWithValue("@param13", txtResim.Text);

            VeriTabani.KomutYollaParametreli(sql, cmd);

            GridDoldur();

            MessageBox.Show("Kayıt Eklendi");
            masktext_tc.Clear();
            textBox2.Clear();
            textBox3_3.Clear();
            masktext_cep.Clear();
            combodyer.Text = string.Empty;
            mask_dt.Clear();
            comboBox_cinsiyet.Text= string.Empty;
            combo_kan.Text = string.Empty;
            textBox_meslek.Clear();
            combo_sgk.Text = string.Empty;
            textBox5.Clear();
            textBox3.Clear();
            txtResim.Clear();
            maskedTextBox3.Clear();
            pictureBox1.Image = null;
            masktext_tc.Focus();
            dataGridView3.Refresh();

        }

        private void btn_kydt_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand();
            string sql = "insert into ekle_aile (TC, ADI, SOYADI, GSM_NO, GSM_NOIKI, CINSIYET, MESLEK, SEHIR, ADRES) values ('" + mask_tc2.Text + "' , '" + txt_aile_ad.Text + "', '" + txt_aile_soyad.Text + "', '" + mask_aile_no.Text + "', '" + mask_aile_no2.Text + "', '" + combo_cinsiyet.Text + "', '" + textBox_meslek2.Text + "','" + com_aile_sehir.Text + "','" + textBox1.Text + "' )";
            cmd.Parameters.AddWithValue("@TC", mask_tc2.Text);
            cmd.Parameters.AddWithValue("@ADI", txt_aile_ad.Text);
            cmd.Parameters.AddWithValue("@SOYADI", txt_aile_soyad.Text);
            cmd.Parameters.AddWithValue("@GSM_NO", mask_aile_no.Text);
            cmd.Parameters.AddWithValue("@GSM_NOIKI", mask_aile_no2.Text);
            cmd.Parameters.AddWithValue("@CINSIYET", combo_cinsiyet.Text);
            cmd.Parameters.AddWithValue("@MESLEK", textBox_meslek2.Text);
            cmd.Parameters.AddWithValue("@SEHIR", com_aile_sehir.Text);
            cmd.Parameters.AddWithValue("@ADRES", textBox1.Text);

            VeriTabani.KomutYollaParametreli(sql, cmd);


            GridDoldur2();
            MessageBox.Show("Kayıt Yapıldı");
            mask_tc2.Clear();
            txt_aile_ad.Clear();
            txt_aile_soyad.Clear();
            mask_aile_no.Clear();
            mask_aile_no2.Clear();
            combo_cinsiyet.Text = string.Empty;
            textBox_meslek2.Clear();
            com_aile_sehir.Text = string.Empty;
            textBox1.Clear();
            maskedTextBox2.Clear();
            mask_tc2.Focus();
            dataGridView3.Refresh();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public string sqlSorgu;
        private void txt_ara_sil_TextChanged(object sender, EventArgs e)
        {

            if (maskedTextBox3.Text != "")
            {
                string sqlSorgu = "select * from tbl_sakinEkle where TC like '%" + maskedTextBox3 + "%' order by TC ASC ";
                con = new SqlConnection(SqlCon);
                da = new SqlDataAdapter("select * from tbl_sakinEkle", con);
                ds = new DataSet();
                con.Open();
                da.Fill(ds, "tbl_sakinEkle");
                dataGridView1.DataSource = ds.Tables["tbl_sakinEkle"];
                con.Close();
            }
        }

        private void textBox1_1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox3_3_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Silmek istediğinizden eminmisiniz?", "Silme uyarısı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {

                    string sqlSorgu = "delete from tbl_sakinEkle where TC='" + maskedTextBox3.Text + "'";
                    SqlCommand cmd = new SqlCommand(sqlSorgu, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    GridDoldur();
                    MessageBox.Show("Kaydınız Silindi", "Silinme uyarısı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    masktext_tc.Clear();
                    textBox2.Clear();
                    textBox3_3.Clear();
                    masktext_cep.Clear();
                    combodyer.Text = string.Empty;
                    mask_dt.Clear();
                    comboBox_cinsiyet.Text = string.Empty;
                    combo_kan.Text = string.Empty;
                    textBox_meslek.Clear();
                    combo_sgk.Text = string.Empty;
                    textBox5.Clear();
                    textBox3.Clear();
                    txtResim.Clear();
                    pictureBox1.Image = null;
                    maskedTextBox3.Clear();
                    masktext_tc.Focus();
                    dataGridView3.Refresh();
                }
                else
                {



                    con.Close();
                    MessageBox.Show("Silmek istediğiniz kişinin TC noyu sağdaki beyaz kısma yazınız!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }

            catch
            {
                con.Close();
                MessageBox.Show("Böyle bir kayıt bulunamadı", "Silinme Uyarısı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        string sorgu;
        private void btn_sil_aile_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Silmek istediğinizden eminmisiniz?", "Silme uyarısı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    string sqlSorgu = "delete from ekle_aile where TC='" + maskedTextBox2.Text + "'";
                    SqlCommand cmd2 = new SqlCommand(sqlSorgu, con2);
                    con2.Open();
                    cmd2.ExecuteNonQuery();
                    con2.Close();
                    GridDoldur2();

                    MessageBox.Show("Kaydınız Silindi", "Silinme uyarısı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    mask_tc2.Clear();
                    txt_aile_ad.Clear();
                    txt_aile_soyad.Clear();
                    mask_aile_no.Clear();
                    mask_aile_no2.Clear();
                    combo_cinsiyet.Text = string.Empty;
                    textBox_meslek2.Clear();
                    com_aile_sehir.Text = string.Empty;
                    textBox1.Clear();
                    maskedTextBox2.Clear();
                    mask_tc2.Focus();
                    dataGridView3.Refresh();

                }
                else
                {



                    con2.Close();
                    MessageBox.Show("Silmek istediğiniz kişinin TC noyu sağdaki beyaz kısma yazınız!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }

            catch
            {
                con2.Close();
                MessageBox.Show("Böyle bir kayıt bulunamadı", "Silinme Uyarısı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        public void verilerigoster(string veriler)
        {
            SqlDataAdapter da = new SqlDataAdapter(veriler, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }
        private void btn_guncel_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("update tbl_sakinEkle set ADI='" + textBox2.Text + "',SOYADI='" + textBox3_3.Text + "',GSM_NO='" + masktext_cep.Text + "', DOGUM_YER='" + combodyer.Text + "', D_TARIHI='" + mask_dt.Text + "',CINSIYET='" + comboBox_cinsiyet.Text + "',KAN_GRUBU='" + combo_kan.Text + "', MESLEK='" + textBox_meslek.Text + "',GUVENCE='" + combo_sgk.Text + "',ADRES='" + textBox5.Text + "',RAHATSIZLIKLAR='" + textBox3.Text + "',RESIM='" + txtResim.Text + "' where  TC='" + masktext_tc.Text + "'", con );
            cmd.ExecuteNonQuery();
            verilerigoster("select * from tbl_sakinEkle");
            con.Close();

            MessageBox.Show("Kayıt Güncellendi");
            masktext_tc.Clear();
            textBox2.Clear();
            textBox3_3.Clear();
            masktext_cep.Clear();
            combodyer.Text = string.Empty;
            mask_dt.Clear();
            comboBox_cinsiyet.Text = string.Empty;
            combo_kan.Text = string.Empty;
            textBox_meslek.Clear();
            combo_sgk.Text = string.Empty;
            textBox5.Clear();
            textBox3.Clear();
            txtResim.Clear();
            maskedTextBox3.Clear();
            pictureBox1.Image = null;
            masktext_tc.Focus();
            dataGridView3.Refresh();

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
               
          
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox1.ImageLocation = openFileDialog1.FileName;
            txtResim.Text = openFileDialog1.FileName;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            masktext_tc.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            maskedTextBox3.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            textBox3_3.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            masktext_cep.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            combodyer.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            mask_dt.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            comboBox_cinsiyet.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
            combo_kan.Text = dataGridView1.Rows[secilen].Cells[7].Value.ToString();
            textBox_meslek.Text = dataGridView1.Rows[secilen].Cells[8].Value.ToString();
            combo_sgk.Text = dataGridView1.Rows[secilen].Cells[9].Value.ToString();
            textBox5.Text = dataGridView1.Rows[secilen].Cells[10].Value.ToString();
            textBox3.Text = dataGridView1.Rows[secilen].Cells[11].Value.ToString();
            txtResim.Text = dataGridView1.Rows[secilen].Cells[12].Value.ToString();

            pictureBox1.ImageLocation= dataGridView1.Rows[secilen].Cells[12].Value.ToString();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView2.SelectedCells[0].RowIndex;
            mask_tc2.Text = dataGridView2.Rows[secilen].Cells[0].Value.ToString();
            maskedTextBox2.Text = dataGridView2.Rows[secilen].Cells[0].Value.ToString();
            txt_aile_ad.Text = dataGridView2.Rows[secilen].Cells[1].Value.ToString();
            txt_aile_soyad.Text = dataGridView2.Rows[secilen].Cells[2].Value.ToString();
            mask_aile_no.Text = dataGridView2.Rows[secilen].Cells[3].Value.ToString();
            mask_aile_no2.Text = dataGridView2.Rows[secilen].Cells[4].Value.ToString();
            combo_cinsiyet.Text = dataGridView2.Rows[secilen].Cells[5].Value.ToString();
            textBox_meslek2.Text = dataGridView2.Rows[secilen].Cells[6].Value.ToString();
            com_aile_sehir.Text = dataGridView2.Rows[secilen].Cells[7].Value.ToString();
            textBox1.Text = dataGridView2.Rows[secilen].Cells[8].Value.ToString();
            
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("select * from tbl_sakinEkle where TC like '%" + maskedTextBox3.Text + "%'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            con2.Open();
            cmd2 = new SqlCommand("select * from ekle_aile where TC like '%" + maskedTextBox2.Text + "%'", con2);
            SqlDataAdapter da = new SqlDataAdapter(cmd2);
            DataSet ds2 = new DataSet();
            da.Fill(ds2);
            dataGridView2.DataSource = ds2.Tables[0];
            con2.Close();
        }
        public void verilerigoster2(string veriler2)
        {
            SqlDataAdapter da = new SqlDataAdapter(veriler2, con2);
            DataSet ds2 = new DataSet();
            da.Fill(ds2);
            dataGridView2.DataSource = ds2.Tables[0];
        }
        private void pictureBox7_Click(object sender, EventArgs e)
        {
            con2.Open();
            cmd2 = new SqlCommand("update ekle_aile set ADI='" + txt_aile_ad.Text + "',SOYADI='" + txt_aile_soyad.Text + "',GSM_NO='" + mask_aile_no.Text + "', GSM_NOIKI='" + mask_aile_no2.Text + "', CINSIYET='" + combo_cinsiyet.Text + "',MESLEK='" + textBox_meslek2.Text + "',SEHIR='" + com_aile_sehir.Text + "', ADRES='" + textBox1.Text + "' where  TC='" + mask_tc2.Text + "'", con2);
            cmd2.ExecuteNonQuery();
            verilerigoster2("select * from ekle_aile");
            con.Close();
            mask_tc2.Clear();
            txt_aile_ad.Clear();
            txt_aile_soyad.Clear();
            mask_aile_no.Clear();
            mask_aile_no2.Clear();
            combo_cinsiyet.Text = string.Empty;
            textBox_meslek2.Clear();
            com_aile_sehir.Text = string.Empty;
            textBox1.Clear();
            maskedTextBox2.Clear();
            mask_tc2.Focus();
            dataGridView3.Refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text != "")
            {

              GridDoldurStoredProcedure2(maskedTextBox1.Text);

            }
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            RaporlamaHuzurevi a = new RaporlamaHuzurevi();
            a.Show();

        }
    }
}
    

