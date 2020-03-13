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
    class SobelFilter : MatrixFilter
    {
        protected float[,] kernelY = null;
        public SobelFilter()
        {
            kernel = new float[3, 3] { { -1, 0, 1 }, { -2, 0, 2 }, { -1, 0, 1 } };
            kernelY = new float[3, 3] { { -1, -2, -1 }, { 0, 0, 0 }, { 1, 2, 1 } };
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int radiusX = kernel.GetLength(0) / 2;
            int radiusY = kernel.GetLength(1) / 2;
            float resultR = 0;
            float resultG = 0;
            float resultB = 0;
            for (int l = -radiusY; l <= radiusY; l++)
                for (int k = -radiusX; k <= radiusX; k++)
                {
                    int idX = Clamp(x + k, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + l, 0, sourceImage.Height - 1);
                    Color neighborColor = sourceImage.GetPixel(idX, idY);
                    resultR += neighborColor.R * kernel[k + radiusX, l + radiusY] + neighborColor.R * kernelY[k + radiusX, l + radiusY];
                    resultG += neighborColor.G * kernel[k + radiusX, l + radiusY] + neighborColor.G * kernelY[k + radiusX, l + radiusY];
                    resultB += neighborColor.B * kernel[k + radiusX, l + radiusY] + neighborColor.B * kernelY[k + radiusX, l + radiusY];
                }
            resultR = Math.Abs(resultR);
            resultG = Math.Abs(resultG);
            resultB = Math.Abs(resultB);
            return Color.FromArgb(
                Clamp((int)resultR, 0, 255),
                Clamp((int)resultG, 0, 255),
                Clamp((int)resultB, 0, 255)
                );
        }
        
        //public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker, Stack<Bitmap> bitmaps)
        //{
        //    if (sourceImage == null)
        //    {
        //        MessageBox.Show("Откройте изображение");
        //        return null;
        //    }
        //    bitmaps.Push(sourceImage);
        //    Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);
        //    Filters filter = new GrayScaleFilter();
        //    sourceImage = filter.processImage(sourceImage, worker, bitmaps);
        //    for (int i = 0; i < sourceImage.Width; i++)
        //    {
        //        worker.ReportProgress((int)((float)i / resultImage.Width * 100));
        //        if (worker.CancellationPending)
        //            return null;
        //        for (int j = 0; j < sourceImage.Height; j++)
        //        {
        //            resultImage.SetPixel(i, j, calculateNewPixelColor(sourceImage, i, j));
        //        }
        //    }

        //    return resultImage;
        //}
    }
}
