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
using System.IO;
using System.Configuration;
namespace ÖdevBilgisayar
{
    public partial class ÜrünDetay : Form
    {
        public long ÜrünId { get; set; }
        public ÜrünDetay()
        {
            InitializeComponent();
        }
        public string connection = ConfigurationManager.ConnectionStrings["Bilgisayar"].ConnectionString;
        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void ÜrünDetay_Load(object sender, EventArgs e)
        {
            ramDetay();
            ekrankartDetay();
            islemciDetay();
            anakartDetay();
            diskDetay();
            ekranResim();
        }
        public void ramDetay()
        {
            string str = "select Ram.RamAd , Ram.RamHafıza,Ram.RamHız from Ram inner join Ürünler on Ürünler.RamId = Ram.RamId where Ürünler.UrunId = @ürün";
            try
            {
                SqlConnection conn = new SqlConnection(connection);
                conn.Open();
                SqlCommand cmd = new SqlCommand(str, conn);
                cmd.Parameters.AddWithValue("@ürün", ÜrünId);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    RMarkaLabel.Text = dr["RamAd"].ToString();
                    RHafızaLabel.Text = dr["RamHafıza"].ToString() + "GB";
                    RHızLabel.Text = dr["RamHız"].ToString() + " GHz";
                }
                conn.Close();
            }
            catch
            {
                MessageBox.Show("Tekrar Deneyiniz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void ekrankartDetay()
        {
            string str = "select EkranKart.EkranKartAd,EkranKart.BellekTipi,EkranKart.ÇekirdekHızı,EkranKart.Bellek from EkranKart inner join Ürünler on Ürünler.EkranKartId=EkranKart.EkranKart_Id where Ürünler.UrunId = @ürün";
            try
            {
                SqlConnection conn = new SqlConnection(connection);
                conn.Open();
                SqlCommand cmd = new SqlCommand(str, conn);
                cmd.Parameters.AddWithValue("@ürün", ÜrünId);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    EKMarkaText.Text = dr["EkranKartAd"].ToString();
                    EKBellektText.Text = dr["BellekTipi"].ToString();
                    EKÇekirdekhText.Text = dr["ÇekirdekHızı"].ToString();
                    EKBellekText.Text = dr["Bellek"].ToString();
                }
                conn.Close();
            }
            catch {
                MessageBox.Show("Tekrar Deneyiniz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void islemciDetay()
        {
            string str = "select Islemci.IslemciAd,Islemci.IslemciHiz,Islemci.IslemciNesil from Islemci inner join Ürünler on Islemci.IslemciId = Ürünler.IslemciId where Ürünler.UrunId = @ürün";
            try
            {
                SqlConnection conn = new SqlConnection(connection);
                conn.Open();
                SqlCommand cmd = new SqlCommand(str, conn);
                cmd.Parameters.AddWithValue("@ürün", ÜrünId);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    İMarkaLabel.Text = dr["IslemciAd"].ToString();
                    İHızLabel.Text = dr["IslemciHiz"].ToString();
                    İNesilLabel.Text = dr["IslemciNesil"].ToString();
                   
                }
                conn.Close();
            }
            catch 
            {
                MessageBox.Show("Tekrar Deneyiniz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void anakartDetay()
        {
            string str = "select Anakart.AnakartAd from Anakart inner join Ürünler on Anakart.AnakartId = Ürünler.AnakartId where Ürünler.UrunId = @ürün";
            try
            {
                SqlConnection conn = new SqlConnection(connection);
                conn.Open();
                SqlCommand cmd = new SqlCommand(str, conn);
                cmd.Parameters.AddWithValue("@ürün", ÜrünId);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    AmarkaLabel.Text = dr["AnakartAd"].ToString();
                    

                }
                conn.Close();
            }
            catch 
            {
                MessageBox.Show("Tekrar Deneyiniz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void diskDetay()
        {
            string str = "select Diskler.DiskAd,Diskler.DiskOkumaHiz,Diskler.DiskYazmaHiz,Diskler.DiskBoyut,Diskler.DiskTür from Diskler inner join Ürünler on Diskler.DiskId = Ürünler.DiskId where Ürünler.UrunId = @ürün";
            try
            {
                SqlConnection conn = new SqlConnection(connection);
                conn.Open();
                SqlCommand cmd = new SqlCommand(str, conn);
                cmd.Parameters.AddWithValue("@ürün", ÜrünId);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    DiskMarkaLabel.Text = dr["DiskAd"].ToString();
                    DiskTürLabel.Text = dr["DiskTür"].ToString();
                    HızDiskLabel.Text = dr["DiskOkumaHiz"].ToString() +" " + dr["DiskYazmaHiz"].ToString();
                    boyutDiskLabel.Text = dr["DiskBoyut"].ToString();
                }
                conn.Close();
            }
            catch
            {
                MessageBox.Show("Tekrar Deneyiniz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void ekranResim()
        {
            string str = "select Ekran.EkranBoyut, Ürünler.Resim from Ekran inner join Ürünler on Ürünler.EkranId = Ekran.EkranId where Ürünler.UrunId = @ürün ";
            try
            {
                SqlConnection conn = new SqlConnection(connection);
                conn.Open();
                SqlCommand cmd = new SqlCommand(str, conn);
                cmd.Parameters.AddWithValue("@ürün", ÜrünId);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    BoyutLabel.Text = dr["EkranBoyut"].ToString();
                    if(dr["Resim"].ToString() != "")
                    {
                        byte[] imageData = (byte[])dr["Resim"];
                        MemoryStream ms = new MemoryStream(imageData);
                        BilgisayarResim.Image = Image.FromStream(ms);
                    }
                   
                }
                conn.Close();
            }
            catch
            {
                MessageBox.Show("Tekrar Deneyiniz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
    }
}
