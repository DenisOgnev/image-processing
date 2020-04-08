using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace computer_graphics_1
{
    class GradFilter : MathMorphologyFilter
    {
        public GradFilter()
        {
            kernel = new int[3, 3] { { 0, 1, 0 }, { 1, 1, 1 }, { 0, 1, 0 } };
            radius = kernel.GetLength(0) / 2;
        }

        public GradFilter(int[,] kernel)
        {
            this.kernel = kernel;
            radius = kernel.GetLength(0) / 2;
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            return sourceImage.GetPixel(x, y);
        }

        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker, Stack<Bitmap> bitmaps)
        {

            float resultR = 0;
            float resultG = 0;
            float resultB = 0;
            if (sourceImage == null)
            {
                MessageBox.Show("Откройте изображение");
                return null;
            }
            bitmaps.Push(sourceImage);
            Filters filter1 = new DilationFilter();
            Bitmap tempImage1 = filter1.processImage(sourceImage, worker, bitmaps);
            Filters filter2 = new ErosionFilter();
            Bitmap tempImage2 = filter2.processImage(sourceImage, worker, bitmaps);
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            for (int i = 0; i < sourceImage.Width; i++)
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    resultR = tempImage1.GetPixel(i, j).R - tempImage2.GetPixel(i, j).R;
                    resultG = tempImage1.GetPixel(i, j).G - tempImage2.GetPixel(i, j).G;
                    resultB = tempImage1.GetPixel(i, j).B - tempImage2.GetPixel(i, j).B;
                    resultImage.SetPixel(i, j, Color.FromArgb(
                        Clamp((int)resultR, 0, 255),
                        Clamp((int)resultG, 0, 255),
                        Clamp((int)resultB, 0, 255)));
                }
                
            return resultImage;

        }
    }
}
