using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace computer_graphics_1
{
    class LinearCorrection : Filters   
    {

        float minBright, maxBright;
        Color max, min;

        private void setMinMax(Bitmap sourceImage)
        {
            minBright = maxBright = 0.3f * sourceImage.GetPixel(0, 0).R + 0.59f * sourceImage.GetPixel(0, 0).G + 0.11f * sourceImage.GetPixel(0, 0).B;
            max = min = sourceImage.GetPixel(0, 0);
            float currentBright;
            for (int i = 0; i < sourceImage.Width; i++)
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    currentBright = 0.3f * sourceImage.GetPixel(i, j).R + 0.59f * sourceImage.GetPixel(i, j).G + 0.11f * sourceImage.GetPixel(i, j).B;
                    if (currentBright > maxBright)
                    {
                        maxBright = currentBright;
                        max = sourceImage.GetPixel(i, j);
                    }
                    if (currentBright < minBright)
                    {
                        minBright = currentBright;
                        min = sourceImage.GetPixel(i, j);
                    }
                }
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            float resultR, resultG, resultB;
            resultR = (sourceImage.GetPixel(x, y).R - min.R) * 255 / (max.R - min.R);
            resultG = (sourceImage.GetPixel(x, y).G - min.G) * 255 / (max.G - min.G);
            resultB = (sourceImage.GetPixel(x, y).B - min.B) * 255 / (max.B - min.B);
            return Color.FromArgb(
                Clamp((int)resultR, 0, 255),
                Clamp((int)resultG, 0, 255),
                Clamp((int)resultB, 0, 255)
                );
        }

        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker, Stack<Bitmap> bitmaps)
        {
            setMinMax(sourceImage);
            return base.processImage(sourceImage, worker, bitmaps);
        }
        
    }
}
