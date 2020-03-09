using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace computer_graphics_1
{
    public partial class Form1 : Form
    {
        Bitmap image;
        Stack<Bitmap> images = new Stack<Bitmap>();
        public Form1()
        {
            InitializeComponent();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image Files|*.png;*.jpg;*.bmp|All Files(*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                image = new Bitmap(dialog.FileName);
                pictureBox1.Image = image;
                pictureBox1.Refresh();
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Filter = "Png Image | *.png | JPeg Image | *.jpg | Bitmap Image | *.bmp";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    switch (dialog.FilterIndex)
                    {
                        case 1:
                            image.Save(dialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
                            break;
                        case 2:
                            image.Save(dialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                            break;
                        case 3:
                            image.Save(dialog.FileName, System.Drawing.Imaging.ImageFormat.Bmp);
                            break;
                    }
                }
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Bitmap newImage = ((Filters)e.Argument).processImage(image, backgroundWorker1, images);
            if (backgroundWorker1.CancellationPending != true)
                image = newImage;
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled) 
            {
                pictureBox1.Image = image;
                pictureBox1.Refresh();
            }
            progressBar1.Value = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
        }

        private void инверсияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InvertFilter filter = new InvertFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void размытиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new BlurFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void фильтрГауссаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new GaussianFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void чернобелыйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new GrayScaleFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void сепияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new SepiaFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void яркостьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new BrightnessFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void резкостьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new SharpnessFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void фильтрСобеляToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new SobelFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void тиснениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new EmbossingFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void влевоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new ShiftLeftFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void вправоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new ShiftRightFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void внизToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new ShiftDownFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void вверхToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new ShiftUpFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void поворотToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new RotationFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void волнаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new WaveFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void эффектСтеклаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new GlassFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void motionBlurToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Filters filter = new MotionBlurFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void резкостьвариант2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new SharpnessFilter1();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void операторЩарраToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new SharrFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void операторПриюттаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new PriyuttFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(images.Count != 0)
            {
                Bitmap oldImage = images.Pop();
                pictureBox1.Image = oldImage;
                pictureBox1.Refresh();
            }
        }
    }
}
