using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoiMauRGP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            label4.Text = hScrollBar1.Value.ToString();
            changleColorpanel();
        }

        private void hScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {
            label5.Text = hScrollBar2.Value.ToString();
            changleColorpanel();
        }

        private void hScrollBar3_Scroll(object sender, ScrollEventArgs e)
        {
            label6.Text = hScrollBar3.Value.ToString();
            changleColorpanel();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label4.Text = hScrollBar1.Value.ToString();
            label5.Text = hScrollBar2.Value.ToString();
            label6.Text = hScrollBar3.Value.ToString();
            panel1.BackColor = Color.FromArgb(hScrollBar1.Value, hScrollBar2.Value, hScrollBar3.Value);
        }
        private void changleColorpanel()
        {
            panel1.BackColor = Color.FromArgb(hScrollBar1.Value, hScrollBar2.Value, hScrollBar3.Value);
        }
    }
    
}
