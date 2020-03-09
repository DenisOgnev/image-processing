using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace computer_graphics_1
{
    class GlassFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Random random = new Random();
            int resultX = (int)(x + (random.NextDouble() - 0.5) * 10);
            int resultY = (int)(y + (random.NextDouble() - 0.5) * 10);
            Color resultColor = sourceImage.GetPixel(Clamp(resultX, 0, sourceImage.Width - 1), Clamp(resultY, 0, sourceImage.Height - 1));
            return resultColor;
        }
    }
}
