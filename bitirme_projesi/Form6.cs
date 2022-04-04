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
    public partial class Form6 : Form
    {
        public Form6()
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

        public static Bitmap AdjustBrightness(Bitmap Image, int Value)
        {
            Bitmap TempBitmap = Image;
            float FinalValue = (float)Value / 255.0f;
            Bitmap NewBitmap = new Bitmap(TempBitmap.Width, TempBitmap.Height);
            Graphics NewGraphics = Graphics.FromImage(NewBitmap);
            float[][] FloatColorMatrix ={
                     new float[] {1, 0, 0, 0, 0},
                     new float[] {0, 1, 0, 0, 0},
                     new float[] {0, 0, 1, 0, 0},
                     new float[] {0, 0, 0, 1, 0},
                     new float[] {FinalValue, FinalValue, FinalValue, 1, 1}
                 };

            ColorMatrix NewColorMatrix = new ColorMatrix(FloatColorMatrix);
            ImageAttributes Attributes = new ImageAttributes();
            Attributes.SetColorMatrix(NewColorMatrix);
            NewGraphics.DrawImage(TempBitmap, new Rectangle(0, 0, TempBitmap.Width, TempBitmap.Height), 0, 0, TempBitmap.Width,
                TempBitmap.Height, GraphicsUnit.Pixel, Attributes);
            Attributes.Dispose();
            NewGraphics.Dispose();
            return NewBitmap;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            pictureBox1.Image = AdjustBrightness(ımg, trackBar1.Value);
        }

    }
}
