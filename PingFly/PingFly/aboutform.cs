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
    public partial class aboutform : Form
    {
        public aboutform()
        {
            InitializeComponent();
        }

        private void exitbutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutform_Load(object sender, EventArgs e)
        {
            try
            {
                label2.Text = "v" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            }
            catch
            {
                MessageBox.Show("This Error really Shouldn't happen, Did you Remove the Programs Version?");
            }
            
        }
    }
}
