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
    public partial class alteastweststars : Form
    {
        public alteastweststars()
        {
            InitializeComponent();
        }
        DataTable table1 = new DataTable();
        DataTable table2 = new DataTable();

        private void houranglesun_Load(object sender, EventArgs e)
        {
            table1.Columns.Add("Obser", typeof(int));
            table1.Columns.Add("h", typeof(double));
            table1.Columns.Add("Corrected HA", typeof(double));
            table1.Columns.Add("A", typeof(double));
            table1.Columns.Add("TB", typeof(double));

            computationalResultForEastStar.DataSource = table1;

            table2.Columns.Add("Obser", typeof(int));
            table2.Columns.Add("h", typeof(double));
            table2.Columns.Add("CorrectedHA", typeof(double));
            table2.Columns.Add("A", typeof(double));
            table2.Columns.Add("TB", typeof(double));

            computationalResultForWestStar.DataSource = table2;
        }

       
        double TB;

        private void computeSec_Click(object sender, EventArgs e)
        {
            total.Text = ((double.Parse(deg.Text)) + (double.Parse(min.Text) / 60) + (double.Parse(sec.Text) / 3600)).ToString();
        }

        private void computeInputForWestSun_Click(object sender, EventArgs e)
        {
           
        }

        private void computeInputForEastSun_Click(object sender, EventArgs e)
        {
           
        }

        private void computeMMTB_Click(object sender, EventArgs e)
        {
           
        }

        private void r0_TextChanged(object sender, EventArgs e)
        {

        }

        private void back2_Click(object sender, EventArgs e)
        {
            this.Hide();
            f2 f2 = new f2();
            f2.ShowDialog();
        }

        private void computeSec_Click_1(object sender, EventArgs e)
        {
            total.Text = ((double.Parse(deg.Text)) + (double.Parse(min.Text) / 60) + (double.Parse(sec.Text) / 3600)).ToString();
        }


        private void computeInputForEastSun_Click_1(object sender, EventArgs e)
        {
            double ro1 = ((double.Parse(ro11.Text)) + (double.Parse(ro12.Text) / 60) + (double.Parse(ro13.Text) / 3600));
            double ro2 = ((double.Parse(ro21.Text)) + (double.Parse(ro22.Text) / 60) + (double.Parse(ro23.Text) / 3600));
            double s1 = ((double.Parse(s11.Text)) + (double.Parse(s12.Text) / 60) + (double.Parse(s13.Text) / 3600));
            double s2 = ((double.Parse(s21.Text)) + (double.Parse(s22.Text) / 60) + (double.Parse(s23.Text) / 3600));
            double v1 = ((double.Parse(v11.Text)) + (double.Parse(v12.Text) / 60) + (double.Parse(v13.Text) / 3600));
            double v2 = ((double.Parse(v21.Text)) + (double.Parse(v22.Text) / 60) + (double.Parse(v23.Text) / 3600));
           
            double dec1 = ((double.Parse(dec11.Text)) + (double.Parse(dec12.Text) / 60) + (double.Parse(dec13.Text) / 3600));
            double r0 = ((double.Parse(r01.Text)) + (double.Parse(r02.Text) / 60) + (double.Parse(r03.Text) / 3600));
            double f = ((double.Parse(f1.Text)) + (double.Parse(f2.Text) / 60) + (double.Parse(f3.Text) / 3600));
            double asslat = ((double.Parse(asslat01.Text)) + (double.Parse(asslat2.Text) / 60) + (double.Parse(asslat3.Text) / 3600));
            double lon = ((double.Parse(lon1.Text)) + (double.Parse(lon2.Text) / 60) + (double.Parse(lon3.Text) / 3600));
            double longi = (lon * 24) / 360;


            double asslat1 = (asslat) * (Math.PI / 180);
            double va = (((v1) + (v2)) / 2);
            double va1 = va * (Math.PI / 180);
            double h = va + (0.0024 * Math.Cos(va1)) - ((r0) * (f));
            double h1 = h * (Math.PI / 180);

            double c11 = (double.Parse(c1.Text)) + (double.Parse(c2.Text));
            double d11 = ((double.Parse(d1.Text)) + (double.Parse(d2.Text)));

            double c = (c11 - d11) * 0.001389 * (Math.Tan(h1));

            double l11;
            double l22;
            double l1 = (s1 - ro1);
                 if (l1 < 0)
               l11 = l1 + 360;
            else
                l11 = l1;

            double l2 = (s2 - ro2);
            if (l2 < 0)
                l22 = l2 + 360;
            else
                l22 = l2;


            double HA = ( l11 + l22 ) / 2;

            
            double correctedHA = HA - c;

            double decc = dec1 * (Math.PI / 180);

            double AAA = (((Math.Sin(decc)) * (1 / Math.Cos(asslat1)) * ((1 / Math.Cos(h1)))) - ((Math.Tan(asslat1)) * (Math.Tan(h1))));
            double AA = Math.Acos(AAA);
            double AAAA = AA / (Math.PI / 180);
            

            double Tbb = AAAA - HA;

            if (HA > AAAA)
                TB = Tbb + 360;
            else
                TB = Tbb;

            double sum = 0;
            double result;
            for (int i = 0; i <= computationalResultForEastStar.Rows.Count - 1; i++)
            {
                sum = sum + double.Parse(computationalResultForEastStar.Rows[i].Cells[4].Value.ToString());
                result = sum / (i + 1);
                meaneastTB.Text = result.ToString();
            }

            //meanTB.Text = ra.Text;

            table1.Rows.Add(obser.Text, h.ToString(), correctedHA.ToString(), AAAA.ToString(), TB.ToString());
            computationalResultForEastStar.DataSource = table1;
        }


        private void computeInputForWestSun_Click_1(object sender, EventArgs e)
        {
            double ro1 = ((double.Parse(ro11.Text)) + (double.Parse(ro12.Text) / 60) + (double.Parse(ro13.Text) / 3600));
            double ro2 = ((double.Parse(ro21.Text)) + (double.Parse(ro22.Text) / 60) + (double.Parse(ro23.Text) / 3600));
            double s1 = ((double.Parse(s11.Text)) + (double.Parse(s12.Text) / 60) + (double.Parse(s13.Text) / 3600));
            double s2 = ((double.Parse(s21.Text)) + (double.Parse(s22.Text) / 60) + (double.Parse(s23.Text) / 3600));
            double v1 = ((double.Parse(v11.Text)) + (double.Parse(v12.Text) / 60) + (double.Parse(v13.Text) / 3600));
            double v2 = ((double.Parse(v21.Text)) + (double.Parse(v22.Text) / 60) + (double.Parse(v23.Text) / 3600));

            double dec1 = ((double.Parse(dec11.Text)) + (double.Parse(dec12.Text) / 60) + (double.Parse(dec13.Text) / 3600));
            double r0 = ((double.Parse(r01.Text)) + (double.Parse(r02.Text) / 60) + (double.Parse(r03.Text) / 3600));
            double f = ((double.Parse(f1.Text)) + (double.Parse(f2.Text) / 60) + (double.Parse(f3.Text) / 3600));
            double asslat = ((double.Parse(asslat01.Text)) + (double.Parse(asslat2.Text) / 60) + (double.Parse(asslat3.Text) / 3600));
            double lon = ((double.Parse(lon1.Text)) + (double.Parse(lon2.Text) / 60) + (double.Parse(lon3.Text) / 3600));
            double longi = (lon * 24) / 360;



            double asslat1 = (asslat) * (Math.PI / 180);
            double va = ((v1 + v2) / 2);
            double va1 = va * (Math.PI / 180);
            double h = va + (0.0024 * Math.Cos(va1)) - (r0 * f);
            double h1 = h * (Math.PI / 180);

            double c11 = (double.Parse(c1.Text)) + (double.Parse(c2.Text));
            double d11 = ((double.Parse(d1.Text)) + (double.Parse(d2.Text)));
            double c = (c11 - d11) * 0.001389 * (Math.Tan(h1));
            double l11;
            double l22;
            double l1 = (s1 - ro1);
            if (l1 < 0)
                l11 = l1 + 360;
            else
                l11 = l1;

            double l2 = (s2 - ro2);
            if (l2 < 0)
                l22 = l2 + 360;
            else
                l22 = l2;


            double HA = (l11 + l22) / 2;


            double correctedHA = HA - c;
            double decc = dec1 * (Math.PI / 180);

            double AAAAAA;
            double AAA = (((Math.Sin(decc)) * (1 / Math.Cos(asslat1)) * ((1 / Math.Cos(h1)))) + ((Math.Tan(asslat1)) * (Math.Tan(h1))));
            double AA = Math.Acos(AAA);
            double AAAA = AA / (Math.PI / 180);
            double AAAAA = AAAA + 180;


            if (AAAAA < 0)
                AAAAAA = AAAAA + 360;
            else
                AAAAAA = AAAAA;


            double Tbb = AAAAAA - HA;

            if (HA > AAAAAA)
                TB = Tbb + 360;
            else
                TB = Tbb;

            double sum = 0;
            double result;
            for (int i = 0; i <= computationalResultForWestStar.Rows.Count - 1; i++)
            {
                sum = sum + double.Parse(computationalResultForWestStar.Rows[i].Cells[4].Value.ToString());
                result = sum / (i + 1);
                meanwestTB.Text = result.ToString();
            }

            //meanTB.Text = ra.Text;

            table2.Rows.Add(obser.Text, h.ToString(), correctedHA.ToString(), AAAAAA.ToString(), TB.ToString());
            computationalResultForWestStar.DataSource = table2;
        }

        private void computeMMTB_Click_1(object sender, EventArgs e)
        {
            totalMeanTB.Text = ((double.Parse(meaneastTB.Text) + double.Parse(meanwestTB.Text)) / 2).ToString();

            double cm = ((double.Parse(cm1.Text)) + (double.Parse(cm2.Text) / 60) + (double.Parse(cm3.Text) / 3600));

            double asslat = ((double.Parse(asslat01.Text)) + (double.Parse(asslat2.Text) / 60) + (double.Parse(asslat3.Text) / 3600));
            double lon = ((double.Parse(lon1.Text)) + (double.Parse(lon2.Text) / 60) + (double.Parse(lon3.Text) / 3600));

            double asslat1 = asslat * (Math.PI / 180);
                double w = double.Parse(cm1.Text) - lon;
                double c;
                c = w * Math.Sin(asslat1);
                gb.Text = (totalMeanTB.Text + c).ToString();
            
        }

        private void gb_TextChanged(object sender, EventArgs e)
        {

        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void w_TextChanged(object sender, EventArgs e)
        {

        }

        private void plateLevel_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void cm_TextChanged(object sender, EventArgs e)
        {

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

        private void lon1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dec12_TextChanged(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void computationalResultForEastSun_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void clearGrid_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
    }
