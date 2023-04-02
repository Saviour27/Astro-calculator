using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AstronomicalComputations
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void Form8_Load(object sender, EventArgs e)
        {

        }

        private void back1_Click(object sender, EventArgs e)
        {
            this.Hide();
            f1 f1 = new f1();
            f1.ShowDialog();
        }

        private void altitudeofeastweststar_Click(object sender, EventArgs e)
        {
            this.Hide();
            f5 f5 = new f5();
            f5.ShowDialog();
        }
    }
}
