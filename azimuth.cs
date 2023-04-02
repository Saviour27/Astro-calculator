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
    public partial class f2 : Form
    {
        public f2()
        {
            InitializeComponent();
        }

        private void back1_Click(object sender, EventArgs e)
        {
            this.Hide();
            f1 f1 = new f1();
            f1.ShowDialog();
        }

        private void angleOfPolaris_Click(object sender, EventArgs e)
        {
            this.Hide();
            f3 f3 = new f3();
             f3.ShowDialog();
        }

        private void eastWestSun_Click(object sender, EventArgs e)
        {
            this.Hide();
            f4 f4 = new f4();
            f4.ShowDialog();
        }

        private void f2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            alteastweststars houranglesun = new alteastweststars();
            houranglesun.ShowDialog();
        }
    }
}
