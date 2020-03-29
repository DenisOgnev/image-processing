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
    public partial class KernelSetForm : Form
    {
        protected int[,] kernel;
        public KernelSetForm()
        {
            InitializeComponent();
            kernel = new int[3, 3];
        }
        public int[,] setKernel()
        {
            return kernel;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "1" && textBox1.Text != "0" && textBox1.Text != "")
                MessageBox.Show("Неверный элемент");
            if (textBox1.Text == "1")
                kernel[0, 0] = 1;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text != "1" && textBox2.Text != "0" && textBox2.Text != "")
                MessageBox.Show("Неверный элемент");
            if (textBox2.Text == "1")
                kernel[0, 1] = 1;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text != "1" && textBox3.Text != "0" && textBox3.Text != "")
                MessageBox.Show("Неверный элемент");
            if (textBox3.Text == "1")
                kernel[0, 2] = 1;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text != "1" && textBox4.Text != "0" && textBox4.Text != "")
                MessageBox.Show("Неверный элемент");
            if (textBox4.Text == "1")
                kernel[1, 0] = 1;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.Text != "1" && textBox5.Text != "0" && textBox5.Text != "")
                MessageBox.Show("Неверный элемент");
            if (textBox5.Text == "1")
                kernel[1, 1] = 1;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (textBox6.Text != "1" && textBox6.Text != "0" && textBox6.Text != "")
                MessageBox.Show("Неверный элемент");
            if (textBox6.Text == "1")
                kernel[1, 2] = 1;
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (textBox7.Text != "1" && textBox7.Text != "0" && textBox7.Text != "")
                MessageBox.Show("Неверный элемент");
            if (textBox7.Text == "1")
                kernel[2, 0] = 1;
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            if (textBox8.Text != "1" && textBox8.Text != "0" && textBox8.Text != "")
                MessageBox.Show("Неверный элемент");
            if (textBox8.Text == "1")
                kernel[2, 1] = 1;
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            if (textBox9.Text != "1" && textBox9.Text != "0" && textBox9.Text != "")
                MessageBox.Show("Неверный элемент");
            if (textBox9.Text == "1")
                kernel[2, 2] = 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
    }
}
