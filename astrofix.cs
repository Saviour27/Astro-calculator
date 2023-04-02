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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        private void back2_Click(object sender, EventArgs e)
        {
            this.Hide();
            f1 f1 = new f1();
            f1.ShowDialog();
        }

        private void Form9_Load(object sender, EventArgs e)
        {

        }

       
        private void equalaltitudemethod_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form11 f11 = new Form11();
            f11.ShowDialog();
        }
    }
  }