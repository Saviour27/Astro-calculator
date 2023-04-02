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
    public partial class f4 : Form
    {
        public f4()
        {
            InitializeComponent();
        }
        private void back2_Click(object sender, EventArgs e)
        {
            this.Hide();
            f2 f2 = new f2();
            f2.ShowDialog();
        }

        DataTable table1 = new DataTable();
        DataTable table2 = new DataTable();
        private void f4_Load(object sender, EventArgs e)
        {
            table1.Columns.Add("Obser", typeof(int));
            table1.Columns.Add("h", typeof(double));
            table1.Columns.Add("Corrected HA", typeof(double));
            table1.Columns.Add("Dec", typeof(double));
            table1.Columns.Add("A", typeof(double));
            table1.Columns.Add("TB", typeof(double));

            computationalResultForEastSun.DataSource = table1;

            table2.Columns.Add("Obser", typeof(int));
            table2.Columns.Add("h", typeof(double));
            table2.Columns.Add("CorrectedHA", typeof(double));
            table2.Columns.Add("Dec", typeof(double));
            table2.Columns.Add("A", typeof(double));
            table2.Columns.Add("TB", typeof(double));

            computationalResultForWestSun.DataSource = table2;
        }

        
        double TB;

        private void computeSec_Click(object sender, EventArgs e)
        {
            total.Text = ((double.Parse(deg.Text)) + (double.Parse(min.Text) / 60) + (double.Parse(sec.Text) / 3600)).ToString();
        }

        private void computeInputForWestSun_Click(object sender, EventArgs e)
        {
           double l2_l1= ((double.Parse(ro11.Text)) + (double.Parse(ro12.Text) / 60) + (double.Parse(ro13.Text) / 3600));
            double r2_r1 = ((double.Parse(ro21.Text)) + (double.Parse(ro22.Text) / 60) + (double.Parse(ro23.Text) / 3600));
           
            double v1 = ((double.Parse(v11.Text)) + (double.Parse(v12.Text) / 60) + (double.Parse(v13.Text) / 3600));
            double v2 = ((double.Parse(v21.Text)) + (double.Parse(v22.Text) / 60) + (double.Parse(v23.Text) / 3600));
            double w1 = ((double.Parse(w11.Text)) + (double.Parse(w12.Text) / 60) + (double.Parse(w13.Text) / 3600));
            double w2 = ((double.Parse(w21.Text)) + (double.Parse(w22.Text) / 60) + (double.Parse(w23.Text) / 3600));
            double dec1 = ((double.Parse(dec11.Text)) + (double.Parse(dec12.Text) / 60) + (double.Parse(dec13.Text) / 3600));
            double diff1 = ((double.Parse(dec21.Text)) + (double.Parse(dec22.Text) / 60) + (double.Parse(dec23.Text) / 3600));
            double r0 = ((double.Parse(r01.Text)) + (double.Parse(r02.Text) / 60) + (double.Parse(r03.Text) / 3600));
            double f = ((double.Parse(f1.Text)) + (double.Parse(f2.Text) / 60) + (double.Parse(f3.Text) / 3600));
            double asslat = ((double.Parse(asslat01.Text)) + (double.Parse(asslat2.Text) / 60) + (double.Parse(asslat3.Text) / 3600));
            double lon = ((double.Parse(lon1.Text)) + (double.Parse(lon2.Text) / 60) + (double.Parse(lon3.Text) / 3600));



            double asslat1 = asslat * (Math.PI / 180);
            double va = ((v1 + v2) / 2);
            double va1 = va * (Math.PI / 180);
            double h = va + (0.0024 * Math.Cos(va1)) - (double.Parse(r01.Text) * double.Parse(f1.Text));
            double h1 = h * (Math.PI / 180);

            double c11 = (double.Parse(this.c1.Text)) + (double.Parse(c2.Text));
            double d11 = ((double.Parse(d1.Text)) + (double.Parse(d2.Text)));
            double c = (c11 - d11) * 0.001389 * (Math.Tan(h1));
            double HA = ((l2_l1) + (r2_r1)) / 2;
            double correctedHA = HA + c;

            double uT = (((w1 + w2) / 2) - 1.00);
          
            double dec = dec1 + diff1;
            double decc = dec * (Math.PI / 180);

            double AAA = ((Math.Sin(decc)) * (1 / Math.Cos(((asslat1)))) * (1 / Math.Cos(h1))) - ((Math.Tan((asslat1))) * (Math.Tan(h1)));
            double AA = Math.Acos(AAA);
            double AAAA = AA / (Math.PI / 180);

            double Tbb = AAAA - HA;

            if (HA > AAAA)
                TB = Tbb + 360;
            else
                TB = Tbb;

            double sum = 0;
            double result;
            for (int i = 0; i <= computationalResultForWestSun.Rows.Count - 1; i++)
            {
                sum = sum + double.Parse(computationalResultForWestSun.Rows[i].Cells[5].Value.ToString());
                result = sum / (i + 1);
                meanwestTB.Text = result.ToString();
            }

            //meanTB.Text = ra.Text;

            table2.Rows.Add(obser.Text, h.ToString(), correctedHA.ToString(), dec.ToString(), AAAA.ToString(), TB.ToString());
            computationalResultForWestSun.DataSource = table2;
        }

        private void computeInputForEastSun_Click(object sender, EventArgs e)
        {
            double l2_l1 = ((double.Parse(ro11.Text)) + (double.Parse(ro12.Text) / 60) + (double.Parse(ro13.Text) / 3600));
            double r2_r1 = ((double.Parse(ro21.Text)) + (double.Parse(ro22.Text) / 60) + (double.Parse(ro23.Text) / 3600));
           
            double v1 = ((double.Parse(v11.Text)) + (double.Parse(v12.Text) / 60) + (double.Parse(v13.Text) / 3600));
            double v2 = ((double.Parse(v21.Text)) + (double.Parse(v22.Text) / 60) + (double.Parse(v23.Text) / 3600));
            double w1 = ((double.Parse(w11.Text)) + (double.Parse(w12.Text) / 60) + (double.Parse(w13.Text) / 3600));
            double w2 = ((double.Parse(w21.Text)) + (double.Parse(w22.Text) / 60) + (double.Parse(w23.Text) / 3600));
            double dec1 = ((double.Parse(dec11.Text)) + (double.Parse(dec12.Text) / 60) + (double.Parse(dec13.Text) / 3600));
            double diff1 = ((double.Parse(dec21.Text)) + (double.Parse(dec22.Text) / 60) + (double.Parse(dec23.Text) / 3600));
            double r0 = ((double.Parse(r01.Text)) + (double.Parse(r02.Text) / 60) + (double.Parse(r03.Text) / 3600));
            double f = ((double.Parse(f1.Text)) + (double.Parse(f2.Text) / 60) + (double.Parse(f3.Text) / 3600));
            double asslat = ((double.Parse(asslat01.Text)) + (double.Parse(asslat2.Text) / 60) + (double.Parse(asslat3.Text) / 3600));
            double lon = ((double.Parse(lon1.Text)) + (double.Parse(lon2.Text) / 60) + (double.Parse(lon3.Text) / 3600));


            double asslat1 = asslat * (Math.PI / 180);
            double va =((v1 + v2) / 2);
            double va1 = va * (Math.PI / 180);
            double h = va + (0.0024 * Math.Cos(va1)) - (r0 * f);
            double h1 = h * (Math.PI / 180);

            double c11 = (double.Parse(this.c1.Text)) + (double.Parse(c2.Text));
            double d11 = ((double.Parse(d1.Text)) + (double.Parse(d2.Text)));
            double c = (c11 - d11) * 0.001389 * (Math.Tan(h1));
            double HA = ((l2_l1) + (r2_r1)) / 2;
            double correctedHA = HA - c;

            double uT = (((w1 + w2) / 2) - 1.00);
            double diff = (uT - 6.00) * ((diff1) / 6.00);
            double dec = dec1 - diff;
            double decc = dec * (Math.PI / 180);

            double AAA = ((Math.Sin(decc)) * (1 / Math.Cos(((asslat1)))) * (1 / Math.Cos(h1))) - ((Math.Tan((asslat1))) * (Math.Tan(h1)));
            double AA = Math.Acos(AAA);
            double AAAA = AA / (Math.PI / 180);

            double Tbb = AAAA - HA;

            if (HA > AAAA)
                TB = Tbb + 360;
            else
                TB = Tbb;

            double sum = 0;
            double result;
            for (int i = 0; i <= computationalResultForEastSun.Rows.Count - 1; i++)
            {
                sum = sum + double.Parse(computationalResultForEastSun.Rows[i].Cells[5].Value.ToString());
                result = sum / (i + 1);
                meaneastTB.Text = result.ToString();
            }

            //meanTB.Text = ra.Text;

            table1.Rows.Add(obser.Text, h.ToString(), correctedHA.ToString(), dec.ToString(), AAAA.ToString(), TB.ToString());
            computationalResultForEastSun.DataSource = table1;
        }

        private void computeMMTB_Click(object sender, EventArgs e)
        {
            totalMeanTB.Text = ((double.Parse(meaneastTB.Text) + double.Parse(meanwestTB.Text))/2).ToString();

           
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void deg_TextChanged(object sender, EventArgs e)
        {

        }

        private void min_TextChanged(object sender, EventArgs e)
        {

        }

        private void sec_TextChanged(object sender, EventArgs e)
        {

        }

        private void total_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void computationalResultForEastSun_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void totalMeanTB_TextChanged(object sender, EventArgs e)
        {

        }

        private void meaneastTB_TextChanged(object sender, EventArgs e)
        {

        }

        private void obser_TextChanged(object sender, EventArgs e)
        {

        }

        private void asslat_TextChanged(object sender, EventArgs e)
        {

        }

       

        private void button4_Click(object sender, EventArgs e)
        {
            double cm = ((double.Parse(cm1.Text)) + (double.Parse(cm2.Text) / 60) + (double.Parse(cm3.Text) / 3600));
            double lon = ((double.Parse(lon1.Text)) + (double.Parse(lon2.Text) / 60) + (double.Parse(lon3.Text) / 3600));

            double asslat1 = double.Parse(this.asslat01.Text) * (Math.PI / 180);
            double w = cm - lon;
            double c;
            c = w * Math.Sin(asslat1);
            gb.Text = ((totalMeanTB.Text) + c).ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            double xx = double.Parse(dd.Text);
            int sec = (int)Math.Round(xx * 3600);
            int ddd = sec / 3600;
            sec = Math.Abs(sec % 3600);
            int min = sec / 60;
            sec %= 60;
            d.Text = ddd.ToString();
            m.Text = min.ToString();
            s.Text = sec.ToString();
        }

        private void gb_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
    }
}
