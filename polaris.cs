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
    public partial class f3 : Form
    {
        public f3()
        {
            InitializeComponent();
        }

        private void back2_Click(object sender, EventArgs e)
        {
            this.Hide();
            f2 f2 = new f2();
            f2.ShowDialog();
        }

        DataTable table = new DataTable();
        private void f3_Load(object sender, EventArgs e)
        {
            table.Columns.Add("Obser", typeof(int));
            table.Columns.Add("Corrected HA", typeof(double));
            table.Columns.Add("T", typeof(double));
            table.Columns.Add("K1", typeof(double));
            table.Columns.Add("K2", typeof(double));
            table.Columns.Add("A\"", typeof(double));
            table.Columns.Add("A", typeof(double));
            table.Columns.Add("TB", typeof(double));
            
            computationResult.DataSource = table;
        }

        

        private void computeSec_Click(object sender, EventArgs e)
        {
            total.Text = ((double.Parse(deg.Text)) + (double.Parse(min.Text) / 60) + (double.Parse(sec.Text) / 3600)).ToString();
        }

        private void computeInput_Click(object sender, EventArgs e)
        {
            double ro1 = ((double.Parse(ro11.Text)) + (double.Parse(ro12.Text) / 60) + (double.Parse(ro13.Text) / 3600));
            double ro2 = ((double.Parse(ro21.Text)) + (double.Parse(ro22.Text) / 60) + (double.Parse(ro23.Text) / 3600));
            double po1 = ((double.Parse(po11.Text)) + (double.Parse(po12.Text) / 60) + (double.Parse(po13.Text) / 3600));
            double po2 = ((double.Parse(po21.Text)) + (double.Parse(po22.Text) / 60) + (double.Parse(po23.Text) / 3600));
            double cm = ((double.Parse(cm1.Text)) + (double.Parse(cm2.Text) / 60) + (double.Parse(cm3.Text) / 3600));
            double ra = ((double.Parse(ra1.Text)) + (double.Parse(ra2.Text) / 60) + (double.Parse(ra3.Text) / 3600));
            double w1 = ((double.Parse(w11.Text)) + (double.Parse(w12.Text) / 60) + (double.Parse(w13.Text) / 3600));
            double w2 = ((double.Parse(w21.Text)) + (double.Parse(w22.Text) / 60) + (double.Parse(w23.Text) / 3600));
            double dec = ((double.Parse(dec1.Text)) + (double.Parse(this.dec2.Text) / 60) + (double.Parse(dec3.Text) / 3600));
            double con = ((double.Parse(con1.Text)) + (double.Parse(this.con2.Text) / 60) + (double.Parse(con3.Text) / 3600));
            double R1 = ((double.Parse(a01.Text)) + (double.Parse(a02.Text) / 60) + (double.Parse(a03.Text) / 3600));
            double diff1 = ((double.Parse(a11.Text)) + (double.Parse(a12.Text) / 60) + (double.Parse(a13.Text) / 3600));
            double asslat = ((double.Parse(asslat11.Text)) + (double.Parse(asslat2.Text) / 60) + (double.Parse(asslat3.Text) / 3600));
            double asslong = ((double.Parse(asslong11.Text)) + (double.Parse(asslong2.Text) / 60) + (double.Parse(asslong3.Text) / 3600));


            double asslat1 = (asslat) * (Math.PI / 180);
            double c = ((((double.Parse(c1.Text)) + (double.Parse(c2.Text))) - ((double.Parse(d1.Text)) + (double.Parse(d2.Text)))) * 0.001388 * (Math.Tan((asslat1))));

            double HA = (((po1) - (ro1)) + ((po2) - (ro2))) / 2;
            double correctedHA = HA + c;

            double TTttt;
            double uT = (((w1 + w2) / 2) - con) * 15;

            double diff = ((diff1) / 6.00);
            double R = (R1 + diff) * 15;

            double raa = (ra) * 15;
            double TTt = uT + R + (asslong) - raa;
      
                   TTttt = TTt - 360;
           
            
            double TTtttt = TTttt * (Math.PI / 180);

            double p2 = 90 - ((dec));
            double p21 = p2 * (Math.PI / 180);
            double pp2 = p2 * 3600;
            double l = Math.Cos((asslat1));
            double j = Math.Tan((asslat1));
            double k = Math.Tan(p21);
            double K1 = -(pp2 * (1 / l));
            double K2 = -(pp2 * k * (1 / l) * j);
            double AA = (K1 * Math.Sin(TTtttt)) + (K2 * Math.Sin(TTtttt) * Math.Cos(TTtttt));
            double AAAA = 360 + (AA / 3600);

            double TB;
            double Tbb = AAAA - correctedHA;

            if (Tbb < 0)
                TB = Tbb + 360;
            else
                TB = Tbb;

            double sum = 0;
            double result;
            for (int i = 0; i <= computationResult.Rows.Count - 1; i++)
            {
                sum = sum + double.Parse(computationResult.Rows[i].Cells[7].Value.ToString());
                result = sum / (i + 1);
                meanTB.Text = result.ToString();

                int sec1 = (int)Math.Round(result * 3600);
                int ddd1 = sec1 / 3600;
                sec1 = Math.Abs(sec1 % 3600);
                int min1 = sec1 / 60;
                sec1 %= 60;
                de.Text = ddd1.ToString();
                mi.Text = min1.ToString();
                se.Text = sec1.ToString();

                double w = (cm) - (asslong);
                double cc;
                cc = w * Math.Sin(asslat1);
                double gb1 = result + cc;
                gb.Text = gb1.ToString();

                int sec = (int)Math.Round(gb1 * 3600);
                int ddd = sec / 3600;
                sec = Math.Abs(sec % 3600);
                int min = sec / 60;
                sec %= 60;
                d.Text = ddd.ToString();
                m.Text = min.ToString();
                s.Text = sec.ToString();
            }

            table.Rows.Add(obser.Text, correctedHA.ToString(), TTttt.ToString(), K1.ToString(), K2.ToString(), AA.ToString(), AAAA.ToString(), TB.ToString());
            computationResult.DataSource = table;

           
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void min_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void con_TextChanged(object sender, EventArgs e)
        {

        }

        private void computationResult_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void meanTB_TextChanged(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void asslat_TextChanged(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void cm_TextChanged(object sender, EventArgs e)
        {

        }


        private void button4_Click(object sender, EventArgs e)
        {
           
        }
        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void textBox22_TextChanged(object sender, EventArgs e)
        {

        }

        private void dec3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
