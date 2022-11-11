using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing.Drawing2D;
using System.IO;

namespace ÖdevBilgisayar
{
    public partial class ÜrünEkleme : Form
    {
        string connection = ConfigurationManager.ConnectionStrings["Bilgisayar"].ConnectionString;
        EkranKartı ek;
        public ÜrünEkleme()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ÜrünEkleme_Load(object sender, EventArgs e)
        {
            getBilgisayarCombo();
            getGpu();
            getRam();


            getMainCard();
        }
        public void getBilgisayarCombo()
        {
            string str = "select*from BilgisayarAd";
            SqlConnection conn = new SqlConnection(connection);
            conn.Open();
            SqlCommand cmd = new SqlCommand(str, conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            MarkaCombo.DataSource = dt;

            MarkaCombo.ValueMember = "Bilgisayar_Id";
            MarkaCombo.DisplayMember = "BilgisayarAd";

            conn.Close();

        }
        public void getGpu()
        {
            string str = "select*from EkranKart";
            SqlConnection conn = new SqlConnection(connection);
            conn.Open();
            SqlCommand cmd = new SqlCommand(str, conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            EkranKartCombo.DataSource = dt;

            EkranKartCombo.ValueMember = "EkranKart_Id";
            EkranKartCombo.DisplayMember = "EkranKartAd";


            conn.Close();
        }

        private void MarkaCombo_SelectedIndexChanged(object sender, EventArgs e)
        {

            string str = "";
            SqlConnection conn = new SqlConnection(connection);
            conn.Open();
            if (MarkaCombo.Text.ToString() == "Sony")
            {
                str = "select*from Islemci where IslemciAd = @islemci";
                SqlCommand cmd = new SqlCommand(str, conn);
                cmd.Parameters.AddWithValue("@islemci", "Intel Core i5");
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                islemciCombo.DataSource = dt;
                islemciCombo.ValueMember = "IslemciId";
                islemciCombo.DisplayMember = "IslemciAd";
            }
            else if (MarkaCombo.Text.ToString() == "Asus")
            {
                str = "select*from Islemci where IslemciAd = @islemci";
                SqlCommand cmd = new SqlCommand(str, conn);
                cmd.Parameters.AddWithValue("@islemci", "Intel Core i7");
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                islemciCombo.DataSource = dt;
                islemciCombo.ValueMember = "IslemciId";
                islemciCombo.DisplayMember = "IslemciAd";
            }
            else
            {
                str = "select*from Islemci";
                SqlCommand cmd = new SqlCommand(str, conn);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                islemciCombo.DataSource = dt;
                islemciCombo.ValueMember = "IslemciId";
                islemciCombo.DisplayMember = "IslemciAd";
            }

            conn.Close();
            getDisc();
            getScreen();

     
        }
        public void getRam()
        {
            string str = "select*from Ram";
            SqlConnection conn = new SqlConnection(connection);
            conn.Open();
            SqlCommand cmd = new SqlCommand(str, conn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            RamCombo.DataSource = dt;
            RamCombo.ValueMember = "RamId";
            RamCombo.DisplayMember = "RamAd";
            conn.Close();
            
           

        }
        public void getDisc()
        {
            string str = "";
            SqlConnection conn = new SqlConnection(connection);
            conn.Open();
            if (MarkaCombo.Text == "Dell")           
            {
                str = "select*from Diskler where DiskTür = @disk";
                SqlCommand cmd = new SqlCommand(str, conn);
                cmd.Parameters.AddWithValue("@disk", "SSD");
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                DiskCombo.DataSource = dt;
                DiskCombo.ValueMember = "DiskId";
                DiskCombo.DisplayMember = "DiskAd";
                conn.Close();
            }
            else
            {
                str = "select*from Diskler";
                SqlCommand cmd = new SqlCommand(str, conn);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                DiskCombo.DataSource = dt;
                DiskCombo.ValueMember = "DiskId";
                DiskCombo.DisplayMember = "DiskAd";
                conn.Close();
            }
           
           
        }
        public void getScreen()
        {
            string str = "";
            SqlConnection conn = new SqlConnection(connection);
            conn.Open();
            if (MarkaCombo.Text.ToString() == "Lenovo")
            {
                str = "select*from Ekran where EkranBoyut = @ekran";
                SqlCommand cmd = new SqlCommand(str, conn);
                cmd.Parameters.AddWithValue("@ekran", "17'3");
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                EkranCombo.DataSource = dt;
                EkranCombo.ValueMember = "EkranId";
                EkranCombo.DisplayMember = "EkranBoyut";
            }
            else
            {
                str = "select*from Ekran";
                SqlCommand cmd = new SqlCommand(str, conn);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                EkranCombo.DataSource = dt;
                EkranCombo.ValueMember = "EkranId";
                EkranCombo.DisplayMember = "EkranBoyut";

            }
            conn.Close();

        }
        public void getMainCard()
        {
            string str = "select*from Anakart";
            SqlConnection conn = new SqlConnection(connection);
            conn.Open();
            SqlCommand cmd = new SqlCommand(str,conn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            AnakartCombo.DataSource = dt;
            AnakartCombo.ValueMember = "AnakartId";
            AnakartCombo.DisplayMember = "AnakartAd";
            conn.Close();

        }

        private void EkranCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
            
            

        }

        private void EkleBtn_Click(object sender, EventArgs e)
        {
           

            if(pictureBox1.Image != null)
            {
                MemoryStream ms = new MemoryStream();
                pictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] resim = ms.GetBuffer();
                ek = new EkranKartı(Convert.ToInt64(MarkaCombo.SelectedValue), resim, Convert.ToInt64(EkranKartCombo.SelectedValue), Convert.ToInt64(islemciCombo.SelectedValue), Convert.ToInt64(RamCombo.SelectedValue), Convert.ToInt64(EkranCombo.SelectedValue), Convert.ToInt64(DiskCombo.SelectedValue), Convert.ToInt64(AnakartCombo.SelectedValue));
                ek.ekle();
                MessageBox.Show("Ürün Başarıyla Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Resim Boş Geçilemez", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.ShowDialog();
            pictureBox1.ImageLocation = open.FileName;
        }

        private void EkranKartCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
          

        }

        private void AnakartCombo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
  
}
