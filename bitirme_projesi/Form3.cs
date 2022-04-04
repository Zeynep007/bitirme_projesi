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
    public partial class Form3 : Form
    {
        public Form3()
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
            int R = 0, G = 0, B = 0;
            Bitmap GirisResmi, CikisResmi;
            GirisResmi = new Bitmap(pictureBox1.Image);
            int ResimGenisligi = GirisResmi.Width; 
            int ResimYuksekligi = GirisResmi.Height;
            CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi); 
            int i = 0, j = 0; //Çıkış resminin x ve y si olacak.
            for (int x = 0; x < ResimGenisligi; x++)
            {
                for (int y = 0; y < ResimYuksekligi; y++)
                {
                    OkunanRenk = GirisResmi.GetPixel(x, y);
                    R = 255 - OkunanRenk.R;
                    G = 255 - OkunanRenk.G;
                    B = 255 - OkunanRenk.B;
                    DonusenRenk = Color.FromArgb(R, G, B);
                    CikisResmi.SetPixel(x, y, DonusenRenk);
                }
            }
            pictureBox2.Image = CikisResmi;
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
