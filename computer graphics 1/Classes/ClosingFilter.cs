﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace computer_graphics_1
{
    class ClosingFilter : ErosionFilter
    {
        public ClosingFilter()
        {
            kernel = new int[3, 3] { { 0, 1, 0 }, { 1, 1, 1 }, { 0, 1, 0 } };
            radius = kernel.GetLength(0) / 2;
        }

        public ClosingFilter(int[,] kernel)
        {
            this.kernel = kernel;
            radius = kernel.GetLength(0) / 2;
        }

        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker, Stack<Bitmap> bitmaps)
        {
            if (sourceImage == null)
            {
                MessageBox.Show("Откройте изображение");
                return null;
            }
            bitmaps.Push(sourceImage);
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            Filters filter = new DilationFilter();

            sourceImage = filter.processImage(sourceImage, worker, bitmaps);

            return base.processImage(sourceImage, worker, bitmaps);
        }
    }
}
