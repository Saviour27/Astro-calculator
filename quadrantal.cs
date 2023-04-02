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
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
        }

        DataTable table1 = new DataTable();
        DataTable table2 = new DataTable();
        DataTable table3 = new DataTable();

        private void Form11_Load(object sender, EventArgs e)
        {
                table1.Columns.Add("Obser", typeof(int));
                table1.Columns.Add("VA", typeof(double));
                table1.Columns.Add("CR", typeof(double));
                table1.Columns.Add("SW", typeof(double));

                inputgrid.DataSource = table1;
           
                table3.Columns.Add("Obser", typeof(int));
                table3.Columns.Add("CT", typeof(double));

                computationalResultForWestStar.DataSource = table3;

                table2.Columns.Add("obser", typeof(int));
                table2.Columns.Add("cosA", typeof(double));
                table2.Columns.Add("sinA", typeof(double));

        }

        private void inputgrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void add_Click(object sender, EventArgs e)
        {
            double va = ((double.Parse(va1.Text)) + (double.Parse(va2.Text) / 60) + (double.Parse(va3.Text) / 3600));
            double cr = ((double.Parse(cr1.Text)) + (double.Parse(cr2.Text) / 60) + (double.Parse(cr3.Text) / 3600));
            double sw = ((double.Parse(sw1.Text)) + (double.Parse(sw2.Text) / 60) + (double.Parse(sw3.Text) / 3600));


            table1.Rows.Add(no.Text, va, cr, sw);
            inputgrid.DataSource = table1;
        }

        private void back2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form9 f9 = new Form9();
            f9.ShowDialog();
        }



        private void compute_Click(object sender, EventArgs e)
        {

            double r0 = ((double.Parse(r01.Text)) + (double.Parse(r02.Text) / 60) + (double.Parse(r03.Text) / 3600));
            double lon = ((double.Parse(lon1.Text)) + (double.Parse(lon2.Text) / 60) + (double.Parse(lon3.Text) / 3600));
            double f = ((double.Parse(f1.Text)) + (double.Parse(f2.Text) / 60) + (double.Parse(f3.Text) / 3600));
            double dec = ((double.Parse(dec11.Text)) + (double.Parse(dec2.Text) / 60) + (double.Parse(dec3.Text) / 3600));
            double lat = ((double.Parse(lat11.Text)) + (double.Parse(lat2.Text) / 60) + (double.Parse(lat3.Text) / 3600));
            double r = ((double.Parse(r1.Text)) + (double.Parse(r2.Text) / 60) + (double.Parse(r3.Text) / 3600));
            double ra = ((double.Parse(ra1.Text)) + (double.Parse(ra2.Text) / 60) + (double.Parse(ra3.Text) / 3600));
            double dut = ((double.Parse(dut1.Text)) + (double.Parse(dut2.Text) / 60) + (double.Parse(dut3.Text) / 3600));
            double ctutc = ((double.Parse(ctutc1.Text)) + (double.Parse(ctutc2.Text) / 60) + (double.Parse(ctutc3.Text) / 3600));


            double sum = 0;
            for (int i = 0; i <= inputgrid.Rows.Count - 1; i++)
            {
                sum = sum + double.Parse(inputgrid.Rows[i].Cells[1].Value.ToString());
            }
            int count_row = inputgrid.Rows.Count;
            double MeanVa = sum / count_row;

            double Ref = (r0) * (f);

            double Meanh = MeanVa + Ref;
            ho.Text = Meanh.ToString();

            for (int j = 0; j <= inputgrid.Rows.Count - 1; j++)
            {
                double CT = double.Parse(inputgrid.Rows[j].Cells[2].Value.ToString()) - double.Parse(inputgrid.Rows[j].Cells[3].Value.ToString());

                table3.Rows.Add(j.ToString(), CT.ToString());
                computationalResultForWestStar.DataSource = table3;
            }

            double result;
            double sumH = 0;
            for (int i = 0; i <= computationalResultForWestStar.Rows.Count - 1; i++)
            {
                sumH = sumH + double.Parse(computationalResultForWestStar.Rows[i].Cells[1].Value.ToString());
                result = sumH / (i + 1);
                meanCT.Text = result.ToString();
            }
            double tt = double.Parse(meanCT.Text) - (ctutc);
            utc.Text = tt.ToString();
            double ttt = double.Parse(utc.Text) + (dut);
            ut.Text = ttt.ToString();


            double lon5 = lon / 15;
            double tttt = double.Parse(ut.Text) + (r) + (lon5) - (ra);
            double ttttt = tttt * 15;
            t.Text = ttttt.ToString();

            double lat1 = (lat) * (Math.PI / 180);
            double dec1 = (dec) * (Math.PI / 180);
            double t1 = double.Parse(t.Text)* (Math.PI / 180);


            double htc = (Math.Sin(lat1) * Math.Sin(dec1)) + (Math.Cos(lat1) * Math.Cos(dec1) * Math.Cos(t1));
            double Hc = Math.Asin(htc);
            double Hc1 = Hc / (Math.PI / 180);
            hc.Text = Hc1.ToString();
            double hc1 = double.Parse(hc.Text) * (Math.PI / 180);
        }

        private void ho_TextChanged(object sender, EventArgs e)
        {

        }

        private void computationalResultForEastStar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void computationalResultForWestStar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void meanCT_TextChanged(object sender, EventArgs e)
        {

        }

        private void ctutc_TextChanged(object sender, EventArgs e)
        {

        }

        private void utc_TextChanged(object sender, EventArgs e)
        {

        }

        private void dut_TextChanged(object sender, EventArgs e)
        {

        }

        private void t_TextChanged(object sender, EventArgs e)
        {

        }

        private void lon_TextChanged(object sender, EventArgs e)
        {

        }

        private void hc_TextChanged(object sender, EventArgs e)
        {

        }

        private void hohc_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void no_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            double dec = ((double.Parse(dec11.Text)) + (double.Parse(dec2.Text) / 60) + (double.Parse(dec3.Text) / 3600));
            double lat = ((double.Parse(lat11.Text)) + (double.Parse(lat2.Text) / 60) + (double.Parse(lat3.Text) / 3600));
            double lat1 = (lat) * (Math.PI / 180);
            double dec1 = (dec) * (Math.PI / 180);
            double t1 = double.Parse(t.Text) * (Math.PI / 180);
            double hc1 = double.Parse(hc.Text) * (Math.PI / 180);

            double cosA= Math.Sin((dec1)) * (1 / (Math.Cos((lat1)))) * (1 / (Math.Cos((hc1)))) - Math.Tan((lat1)) * Math.Tan((hc1));
            a1.Text = cosA.ToString();
            double sinA = -Math.Sin((t1)) * Math.Cos((dec1)) * (1 / (Math.Cos((hc1))));
            s1.Text = sinA.ToString();
            double HcHo = double.Parse(ho.Text) - double.Parse(hc.Text);
            hohc1.Text = HcHo.ToString();
        }

        private void computedeg_Click(object sender, EventArgs e)
        {
            total.Text = ((double.Parse(deg.Text)) + (double.Parse(min.Text) / 60) + (double.Parse(sec.Text) / 3600)).ToString();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            double dec = ((double.Parse(dec11.Text)) + (double.Parse(dec2.Text) / 60) + (double.Parse(dec3.Text) / 3600));
            double lat = ((double.Parse(lat11.Text)) + (double.Parse(lat2.Text) / 60) + (double.Parse(lat3.Text) / 3600));
            double lat1 = (lat) * (Math.PI / 180);
            double dec1 = (dec) * (Math.PI / 180);
            double t1 = double.Parse(t.Text) * (Math.PI / 180);
            double hc1 = double.Parse(hc.Text) * (Math.PI / 180);

            double cosA = -Math.Sin((dec1)) * (1 / (Math.Cos((lat1)))) * (1 / (Math.Cos((hc1)))) - Math.Tan((lat1)) * Math.Tan((hc1));
            a2.Text = cosA.ToString();
            double sinA = -Math.Sin((t1)) * Math.Cos((dec1)) * (1 / (Math.Cos((hc1))));
            s2.Text = sinA.ToString();
            double HcHo = double.Parse(ho.Text) - double.Parse(hc.Text);
            hohc2.Text = HcHo.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            double dec = ((double.Parse(dec11.Text)) + (double.Parse(dec2.Text) / 60) + (double.Parse(dec3.Text) / 3600));
            double lat = ((double.Parse(lat11.Text)) + (double.Parse(lat2.Text) / 60) + (double.Parse(lat3.Text) / 3600));
            double lat1 = (lat) * (Math.PI / 180);
            double dec1 = (dec) * (Math.PI / 180);
            double t1 = double.Parse(t.Text) * (Math.PI / 180);
            double hc1 = double.Parse(hc.Text) * (Math.PI / 180);

            double cosA = -Math.Sin((dec1)) * (1 / (Math.Cos((lat1)))) * (1 / (Math.Cos((hc1)))) - Math.Tan((lat1)) * Math.Tan((hc1));
            a3.Text = cosA.ToString();
            double sinA = Math.Sin((t1)) * Math.Cos((dec1)) * (1 / (Math.Cos((hc1))));
            s3.Text = sinA.ToString();
            double HcHo = double.Parse(ho.Text) - double.Parse(hc.Text);
            hohc3.Text = HcHo.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            double dec = ((double.Parse(dec11.Text)) + (double.Parse(dec2.Text) / 60) + (double.Parse(dec3.Text) / 3600));
            double lat = ((double.Parse(lat11.Text)) + (double.Parse(lat2.Text) / 60) + (double.Parse(lat3.Text) / 3600));
            double lat1 = (lat) * (Math.PI / 180);
            double dec1 = (dec) * (Math.PI / 180);
            double t1 = double.Parse(t.Text) * (Math.PI / 180);
            double hc1 = double.Parse(hc.Text) * (Math.PI / 180);

            double cosA = Math.Sin((dec1)) * (1 / (Math.Cos((lat1)))) * (1 / (Math.Cos((hc1)))) - Math.Tan((lat1)) * Math.Tan((hc1));
            a4.Text = cosA.ToString();
            double sinA = Math.Sin((t1)) * Math.Cos((dec1)) * (1 / (Math.Cos((hc1))));
            s4.Text = sinA.ToString();
            double HcHo = double.Parse(ho.Text) - double.Parse(hc.Text);
            hohc4.Text = HcHo.ToString();
        }

        private void a1_TextChanged(object sender, EventArgs e)
        {

        }

        private void s1_TextChanged(object sender, EventArgs e)
        {

        }

        private void a2_TextChanged(object sender, EventArgs e)
        {

        }

        private void s2_TextChanged(object sender, EventArgs e)
        {

        }

        private void a3_TextChanged(object sender, EventArgs e)
        {

        }

        private void s3_TextChanged(object sender, EventArgs e)
        {

        }

        private void a4_TextChanged(object sender, EventArgs e)
        {

        }

        private void s4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click_1(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            double lon = ((double.Parse(lon1.Text)) + (double.Parse(lon2.Text) / 60) + (double.Parse(lon3.Text) / 3600));
            double dec = ((double.Parse(dec11.Text)) + (double.Parse(dec2.Text) / 60) + (double.Parse(dec3.Text) / 3600));
            double lat = ((double.Parse(lat11.Text)) + (double.Parse(lat2.Text) / 60) + (double.Parse(lat3.Text) / 3600));
            double lat1 = (lat) * (Math.PI / 180);
            double dec1 = (dec) * (Math.PI / 180);
            double t1 = double.Parse(t.Text) * (Math.PI / 180);
            double hc1 = double.Parse(hc.Text) * (Math.PI / 180);
            double a1a3 = double.Parse(a1.Text) - double.Parse(a3.Text);
            double a2a4 = double.Parse(a2.Text) - double.Parse(a4.Text);
            double s1s3 = double.Parse(s1.Text) - double.Parse(s3.Text);
            double s2s4 = double.Parse(s2.Text) - double.Parse(s4.Text);
            double u = double.Parse(hohc1.Text) - double.Parse(hohc3.Text);
            double q = double.Parse(hohc2.Text) - double.Parse(hohc4.Text);

            double ww = s1s3 * a2a4;
            double uu = u * a2a4;
            double vv = a2a4 * a1a3;
            double qq = q * a1a3;
            double cc = a1a3 * a2a4;
            double dd = a1a3 * s2s4;
            double vvv = vv - cc;
            double www = ww - dd;
            double uuu = uu - qq;
            double vvw = vvv + www;
            double yy = uuu / vvw;
            double xx = (u - (s1s3 * yy)) / a1a3;
            double xx1 = xx;
            double dy = yy * (1 / (Math.Cos(lat1)));
            double dy1 = dy;
            double yyy = (lon) + dy1;
            longitude.Text = yyy.ToString();
            double xxx = (lat) + xx1;
            latitude.Text = xxx.ToString();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            double xx = double.Parse(longitude.Text);
            int sec = (int)Math.Round(xx * 3600);
            int dd = sec / 3600;
            sec = Math.Abs(sec % 3600);
            int min = sec / 60;
            sec %= 60;
            d.Text = dd.ToString();
            m.Text = min.ToString();
            s.Text = sec.ToString();

            double xx1 = double.Parse(latitude.Text);
            int sec1 = (int)Math.Round(xx1 * 3600);
            int dd1 = sec1 / 3600;
            sec1 = Math.Abs(sec1 % 3600);
            int min1 = sec1 / 60;
            sec1 %= 60;
            d1.Text = dd1.ToString();
            m1.Text = min1.ToString();
            ss1.Text = sec1.ToString();
        }

        private void lat_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
