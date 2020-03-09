using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace computer_graphics_1
{
    class WaveFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int resultX = (int)(x + 20 * Math.Sin(2 * Math.PI * y / 120));
            Color resultColor = sourceImage.GetPixel(Clamp(resultX, 0, sourceImage.Width - 1), y);
            return resultColor;
        }
    }
}
