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
using System.Configuration;
namespace ÖdevBilgisayar
{
    public partial class LoginPage : Form
    {
        public string conneciton = ConfigurationManager.ConnectionStrings["Bilgisayar"].ConnectionString;
        public LoginPage()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox2.PasswordChar == '*')
            {
                textBox2.PasswordChar = '\0';
                button2.SendToBack();
                button3.BringToFront();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.PasswordChar == '\0')
            {
                textBox2.PasswordChar = '*';
                button3.SendToBack();
                button2.BringToFront();

            }
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            panel3.BackColor = SystemColors.Control;
            textBox2.BackColor = SystemColors.Control;
            panel2.BackColor = Color.White;
            textBox1.BackColor = Color.White;
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            panel2.BackColor = SystemColors.Control;
            textBox1.BackColor = SystemColors.Control;
            panel3.BackColor = Color.White;
            textBox2.BackColor = Color.White;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();

            string str = "select*from Users where Mail = @gmail and Sifre = @sifre";
            
            try
            {
                SqlConnection conn = new SqlConnection(conneciton);
                conn.Open();
                SqlCommand cmd = new SqlCommand(str, conn);
                cmd.Parameters.AddWithValue("@gmail", textBox1.Text);
                cmd.Parameters.AddWithValue("@sifre", textBox2.Text);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    if (dr["Yetki"].ToString() == "Müsteri")
                    {
                        frm.ürünEkleToolStripMenuItem.Available = false;
                        frm.isim = dr["KullaniciAd"].ToString();
                        frm.soyisim = dr["KullaniciSoyad"].ToString();
                        frm.label6.Text = "Mağazamıza Hoş Geldiniz! İyi Alışverişler!";
                        frm.Show();
                        this.Hide();

                    }
                    else if (dr["Yetki"].ToString() == "Admin")
                    {
                        frm.ürünSilToolStripMenuItem.Available = false;
                        frm.isim = dr["KullaniciAd"].ToString();
                        frm.soyisim = dr["KullaniciSoyad"].ToString();
                        frm.label6.Text = "Tekrar Hoş Geldiniz! İyi Çalışmalar!";
                        frm.Show();
                        this.Hide();
                      

                    }

                }
                else
                {
                    MessageBox.Show("E-Mail veya Şifre Yanlış!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }



            }
            catch
            {
                
            }
        }
        private bool kontrol(string mail,string sifre)
        {
            string str = "select*from Users where KullaniciMail = @mail and Sifre = @sifre";
            SqlConnection conn = new SqlConnection(conneciton);
            conn.Open();
            SqlCommand cmd = new SqlCommand(str, conn);
            cmd.Parameters.AddWithValue("@mail", mail);
            cmd.Parameters.AddWithValue("@sifre", sifre);
            var sonuc = cmd.ExecuteScalar();
            if(sonuc != null)
            {
                return true;
            }
            else
            {
                return false;
            }
            

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
