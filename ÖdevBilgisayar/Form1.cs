using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ÖdevBilgisayar
{
    public partial class Form1 : Form
    {
        public string isim { get; set; }
        public string soyisim { get; set; }


        public Form1()
        {
            InitializeComponent();
        }

        private void ürünEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            
            bool IsOpen = false;
            foreach(Form f in Application.OpenForms)
            {
                if(f.Text == "ÜrünEkleme")
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }
            if(IsOpen == false)
            {
                ÜrünEkleme ur = new ÜrünEkleme();
                ur.MdiParent = this;
                ur.Dock = DockStyle.Fill;
                ur.FormBorderStyle = FormBorderStyle.None;
                ur.Show();
            }
           
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString("T");
            label2.Text = DateTime.Now.ToString("d");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label4.Text = isim + " " + soyisim;
           
            timer1.Start();
        }

        private void ürünSilToolStripMenuItem_Click(object sender, EventArgs e)
        {

            panel1.Visible = false;
            bool IsOpen = false;
            foreach(Form f1 in Application.OpenForms)
            {
                if (f1.Text == "ÜrünGösterme")
                {
                    IsOpen = true;
                    f1.Focus();
                    break;
                }
                
            }
            if (IsOpen == false)
            {
                ÜrünGösterme üg = new ÜrünGösterme();
                üg.MdiParent = this;
                üg.Dock = DockStyle.Fill;
                üg.FormBorderStyle = FormBorderStyle.None;
                üg.Show();
            }
        }
    }
}
