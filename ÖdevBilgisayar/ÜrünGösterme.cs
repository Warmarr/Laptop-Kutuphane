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
using System.IO;

namespace ÖdevBilgisayar
{
    public partial class ÜrünGösterme : Form
    {
        public long ÜrünId { get; set; }
        public double fiyat { get; set; }
        public ÜrünGösterme()
        {
            InitializeComponent();
        }
        string conneciton = ConfigurationManager.ConnectionStrings["Bilgisayar"].ConnectionString;
        private void ÜrünGösterme_Load(object sender, EventArgs e)
        {
            loadData();
        }
        public void loadData()
        {
            string str = "Select Ürünler.UrunId, BilgisayarAd.BilgisayarAd, EkranKart.EkranKartAd,Islemci.IslemciAd,Ram.RamAd,Anakart.AnakartAd,Diskler.DiskAd,Ekran.EkranBoyut,Ürünler.Fiyat,Ürünler.Resim from Ürünler inner join BilgisayarAd on Ürünler.BilgisayarId = BilgisayarAd.Bilgisayar_Id inner join EkranKart on EkranKart.EkranKart_Id  = Ürünler.EkranKartId inner join Islemci on Islemci.IslemciId = Ürünler.IslemciId inner join Ram on Ram.RamId = Ürünler.IslemciId inner join Anakart on Anakart.AnakartId = Ürünler.AnakartId inner join Diskler on Diskler.DiskId = Ürünler.DiskId inner join Ekran on Ekran.EkranId = Ürünler.EkranId";

            try
            {
                SqlConnection conn = new SqlConnection(conneciton);
                conn.Open();
                SqlCommand cmd = new SqlCommand(str, conn);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                ÜrünlerVeri.DataSource = dt;
                conn.Close();

            }
            catch 
            {
                MessageBox.Show("Lütfen Tekrar Deneyiniz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
 
        }

        private void ÜrünlerVeri_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            MarkaText.Text = ÜrünlerVeri.CurrentRow.Cells[1].Value.ToString();
            EkranText.Text = ÜrünlerVeri.CurrentRow.Cells[2].Value.ToString();
            İslemciText.Text = ÜrünlerVeri.CurrentRow.Cells[3].Value.ToString();
            RamText.Text = ÜrünlerVeri.CurrentRow.Cells[4].Value.ToString();
            AnakartText.Text = ÜrünlerVeri.CurrentRow.Cells[5].Value.ToString();
            DiskText.Text = ÜrünlerVeri.CurrentRow.Cells[6].Value.ToString();
            EkranBoyutText.Text = ÜrünlerVeri.CurrentRow.Cells[7].Value.ToString();
            FiyatText.Text = ÜrünlerVeri.CurrentRow.Cells[8].Value.ToString();
            if (ÜrünlerVeri.CurrentRow.Cells[9].Value.ToString() != "")
            {
                byte[] imageData = (byte[])ÜrünlerVeri.CurrentRow.Cells[9].Value;
                MemoryStream mm = new MemoryStream(imageData);
                ResimBox.Image = Image.FromStream(mm);

            }
            if (ÜrünlerVeri.CurrentRow.Cells[9].Value.ToString() == "")
            {
                ResimBox.Image = null;
            }
            if(ÜrünlerVeri.CurrentRow.Cells[0].Value.ToString() != "")
            {
                ÜrünId = Convert.ToInt64(ÜrünlerVeri.CurrentRow.Cells[0].Value.ToString());

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ÜrünDetay üd = new ÜrünDetay();
            üd.ÜrünId = ÜrünId;
            üd.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = "insert into Siparisler(UrunId,Adet,Fiyat) values(@ürün,@adet,@fiyat)";
            DialogResult dialog = MessageBox.Show("Sipariş vermekte emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if(dialog == DialogResult.Yes)
            {
                try
                {
                    SqlConnection conn = new SqlConnection(conneciton);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(str, conn);
                    cmd.Parameters.AddWithValue("@ürün", ÜrünlerVeri.CurrentRow.Cells[0].Value.ToString());
                    cmd.Parameters.AddWithValue("@adet", Convert.ToInt32(numericUpDown1.Value.ToString()));
                    cmd.Parameters.AddWithValue("@fiyat", siparisFiyatHesap(Convert.ToDouble(ÜrünlerVeri.CurrentRow.Cells[8].Value.ToString())));
                    int affectedRows = cmd.ExecuteNonQuery();
                    if (affectedRows > 0)
                    {
                        MessageBox.Show("Siparişiniz başarıyla verildi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch
                {
                    MessageBox.Show("Tekrar Deneyiniz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }
        public double siparisFiyatHesap(double data)
        {
            fiyat = Convert.ToDouble(numericUpDown1.Value.ToString()) * data;
            return fiyat;
        }
    }
}
