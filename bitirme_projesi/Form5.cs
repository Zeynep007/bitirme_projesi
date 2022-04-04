using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bitirme_projesi
{
    public partial class Form5 : Form
    {
        public Form5()
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
            int R = 0, G = 0, B = 0;
            Color OkunanRenk, DonusenRenk;
            Bitmap GirisResmi, CikisResmi;
            GirisResmi = new Bitmap(pictureBox1.Image);
            int ResimGenisligi = GirisResmi.Width; 
            int ResimYuksekligi = GirisResmi.Height;
            CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi); 
            int i = 0, j = 0;
            for (int x = 0; x < ResimGenisligi; x++)
            {
                j = 0;
                for (int y = 0; y < ResimYuksekligi; y++)
                {
                    OkunanRenk = GirisResmi.GetPixel(x, y);

                    R = OkunanRenk.R - 50;
                    G = OkunanRenk.G - 50;
                    B = OkunanRenk.B - 50;

                    if (R < 0) R = 0;
                    if (G < 0) G = 0;
                    if (B < 0) B = 0;
                    DonusenRenk = Color.FromArgb(R, G, B);
                    CikisResmi.SetPixel(i, j, DonusenRenk);
                    j++;
                }
                i++;
            }
            pictureBox2.Image = CikisResmi;

        }
    }
}
