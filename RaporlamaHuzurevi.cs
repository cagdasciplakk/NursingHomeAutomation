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
    public partial class RaporlamaHuzurevi : Form
    {

        SqlConnection con;
        SqlDataAdapter da;
        DataSet ds;
        public static string SqlCon = @"Data Source=CAKI\SQLEXPRESS;Initial Catalog=deneme;Integrated Security=True";

        public void RaporDoldur(string sql)
        {
            con = new SqlConnection(SqlCon);
            da = new SqlDataAdapter(sql, con);
            ds = new DataSet();

            con.Open();
            da.Fill(ds);
            raporHuzurevi1.SetDataSource(ds.Tables[0]);
            crystalReportViewer1.ReportSource = raporHuzurevi1;
            con.Close();
        }

        public RaporlamaHuzurevi()
        {
            InitializeComponent();
        }

        private void RaporlamaHuzurevi_Load(object sender, EventArgs e)
        {
            RaporDoldur("select * from tbl_sakinEkle");
        }
    }
}
