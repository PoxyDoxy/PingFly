using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PingFly
{
    public partial class ImageViewer : Form
    {
        public ImageViewer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ImageViewer_Load(object sender, EventArgs e)
        {
            pictureBox1.Load(aboutform.varholder.image_url);
            pictureBox1.Size = this.Size;
        }
    }
}
