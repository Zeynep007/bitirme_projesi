using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace bitirme_projesi
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        Bitmap ımg = null;
        private void button1_Click(object sender, EventArgs e)
        {

            OpenFileDialog dosya = new OpenFileDialog();
            dosya.Filter = "Resim Dosyası |*.jpg;*.nef;*.png| Video|*.avi| Tüm Dosyalar |*.*";
            dosya.Title = "resim";
            dosya.ShowDialog();
            string DosyaYolu = dosya.FileName;
            pictureBox1.ImageLocation = DosyaYolu;
            ımg = new Bitmap(DosyaYolu);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Color OkunanRenk, DonusenRenk;

            Bitmap GirisResmi = new Bitmap(pictureBox1.Image);
            int ResimGenisligi = GirisResmi.Width; //GirisResmi global tanımlandı. 
            int ResimYuksekligi = GirisResmi.Height;
            Bitmap CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi); //Cikis resmini   oluşturuyor.Boyutları giriş resmi ile aynı olur.
            int GriDeger = 0;
            for (int x = 0; x < ResimGenisligi; x++)
            {
                for (int y = 0; y < ResimYuksekligi; y++)
                {
                    OkunanRenk = GirisResmi.GetPixel(x, y);
                    double R = OkunanRenk.R;
                    double G = OkunanRenk.G;
                    double B = OkunanRenk.B;
                    GriDeger = Convert.ToInt16((R + G + B) / 3);

                    // GriDeger = Convert.ToInt16(R * 0.3 + G * 0.6 + B * 0.1);
                    DonusenRenk = Color.FromArgb(GriDeger, GriDeger, GriDeger);
                    CikisResmi.SetPixel(x, y, DonusenRenk);
                }
            }
            pictureBox2.Image = CikisResmi;

        }
    }
}
