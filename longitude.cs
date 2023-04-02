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
    public partial class f5 : Form
    {
        public f5()
        {
            InitializeComponent();
        }

        private void back2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form8 f8 = new Form8();
            f8.ShowDialog();
        }

        DataTable table1 = new DataTable();
        DataTable table2 = new DataTable();
        DataTable table3 = new DataTable();

        private void f5_Load(object sender, EventArgs e)
        {
            table1.Columns.Add("Obser", typeof(int));
            table1.Columns.Add("VA", typeof(double));
            table1.Columns.Add("CR", typeof(double));
            table1.Columns.Add("SW", typeof(double));

            inputgrid.DataSource = table1;

            table2.Columns.Add("Obser", typeof(int));
            table2.Columns.Add("CT", typeof(double));

            computationalResultForEastStar.DataSource = table2;

            table3.Columns.Add("Obser", typeof(int));
            table3.Columns.Add("CT", typeof(double));

            computationalResultForWestStar.DataSource = table3;
        }

        private void add_Click(object sender, EventArgs e)
        {
            double va = ((double.Parse(va1.Text)) + (double.Parse(va2.Text) / 60) + (double.Parse(va3.Text) / 3600));
            double cr = ((double.Parse(cr1.Text)) + (double.Parse(cr2.Text) / 60) + (double.Parse(cr3.Text) / 3600));
            double sw = ((double.Parse(sw1.Text)) + (double.Parse(sw2.Text) / 60) + (double.Parse(sw3.Text) / 3600));
            


            table1.Rows.Add(no.Text, va, cr, sw);
            inputgrid.DataSource = table1;
        }

        private void computeInputForEastStar_Click(object sender, EventArgs e)
        {
            double r0 = ((double.Parse(r01.Text)) + (double.Parse(r02.Text) / 60) + (double.Parse(r03.Text) / 3600));
            double f = ((double.Parse(f1.Text)) + (double.Parse(f2.Text) / 60) + (double.Parse(f3.Text) / 3600));
            double dec = ((double.Parse(dec1.Text)) + (double.Parse(dec2.Text) / 60) + (double.Parse(dec3.Text) / 3600));
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
            ECMVA.Text = Meanh.ToString();
            double Meanh1 = Meanh * (Math.PI / 180);
            double lat1 = (lat) * (Math.PI / 180);
            double decc = (dec) * (Math.PI / 180);

            double t = ((Math.Sin(Meanh1) * (1 / Math.Cos(lat1)) * (1 / Math.Cos(decc))) - (Math.Tan(lat1) * Math.Tan(decc)));
            double tt = Math.Acos(t);
            double ttt = tt / (Math.PI / 180);
            double T = -(ttt / 15);

            ET.Text = T.ToString();

            for (int j = 0; j <= inputgrid.Rows.Count - 1; j++)
            {
                double CT = double.Parse(inputgrid.Rows[j].Cells[2].Value.ToString()) - double.Parse(inputgrid.Rows[j].Cells[3].Value.ToString());

                table2.Rows.Add(j.ToString(), CT.ToString());
                computationalResultForEastStar.DataSource = table2;
            }

            double result;
            double sumH = 0;
            for (int i = 0; i <= computationalResultForEastStar.Rows.Count - 1; i++)
            {
                sumH = sumH + double.Parse(computationalResultForEastStar.Rows[i].Cells[1].Value.ToString());
                result = sumH / (i + 1);
                EMCT.Text = result.ToString();
                double utc = result - (ctutc);
                double ut1 = utc + (dut);
                this.ut.Text = ut1.ToString();

                double lamdard = ((T + ra - ut1 - r) + 24);
                ELAM.Text = lamdard.ToString();
            }
        }


        private void computeInputForWestStar_Click(object sender, EventArgs e)
        {
            double r0 = ((double.Parse(r01.Text)) + (double.Parse(r02.Text) / 60) + (double.Parse(r03.Text) / 3600));
            double f = ((double.Parse(f1.Text)) + (double.Parse(f2.Text) / 60) + (double.Parse(f3.Text) / 3600));
            double dec = ((double.Parse(dec1.Text)) + (double.Parse(dec2.Text) / 60) + (double.Parse(dec3.Text) / 3600));
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

            double Ref = r0 + f;

            double Meanh = MeanVa + Ref;
            WCMVA.Text = Meanh.ToString();
            double Meanh1 = Meanh * (Math.PI / 180);
            double lat1 = (lat) * (Math.PI / 180);
            double decc = (dec) * (Math.PI / 180);

            double t = (Math.Sin(Meanh1) * (1 / Math.Cos(lat1)) * (1 / Math.Cos(decc)) - (Math.Tan(lat1) * Math.Tan(decc)));
            double tt = Math.Acos(t);
            double ttt = tt / (Math.PI / 180);
            double T = ttt / 15;

            WT.Text = T.ToString();

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
                WMCT.Text = result.ToString();
                double utc = result - (ctutc);
                double ut1 = utc + (dut);
                this.ut.Text = ut1.ToString();
           
            double lamdard = (T + ra - ut1 - r);
            WLAM.Text = lamdard.ToString();
            }
        }

        private void computeSigma_Click(object sender, EventArgs e)
        {
            double si = 0.5 * (double.Parse(ELAM.Text) + double.Parse(WLAM.Text));
            double sig = si * 15;
            sigma.Text = sig.ToString();
        }

        private void computeSec_Click(object sender, EventArgs e)
        {
            total.Text = ((double.Parse(deg.Text)) + (double.Parse(min.Text) / 60) + (double.Parse(sec.Text) / 3600)).ToString();
        }

        private void label35_Click(object sender, EventArgs e)
        {

        }

        private void label36_Click(object sender, EventArgs e)
        {

        }

        private void label37_Click(object sender, EventArgs e)
        {

        }

        private void total_TextChanged(object sender, EventArgs e)
        {

        }

        private void sec_TextChanged(object sender, EventArgs e)
        {

        }

        private void min_TextChanged(object sender, EventArgs e)
        {

        }

        private void deg_TextChanged(object sender, EventArgs e)
        {

        }

        private void WCMVA_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void ELAM_TextChanged(object sender, EventArgs e)
        {

        }

        private void esig_TextChanged(object sender, EventArgs e)
        {

        }

        private void WLAM_TextChanged(object sender, EventArgs e)
        {

        }

        private void ECMVA_TextChanged(object sender, EventArgs e)
        {

        }

        private void sigma_TextChanged(object sender, EventArgs e)
        {

        }

        private void wsig_TextChanged(object sender, EventArgs e)
        {

        }

        private void EMCT_TextChanged(object sender, EventArgs e)
        {

        }

        private void label32_Click(object sender, EventArgs e)
        {

        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void computationalResultForEastStar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void inputgrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cr_TextChanged(object sender, EventArgs e)
        {

        }

        private void va_TextChanged(object sender, EventArgs e)
        {

        }

        private void sw_TextChanged(object sender, EventArgs e)
        {

        }

        private void phy_TextChanged(object sender, EventArgs e)
        {

        }

        private void ET_TextChanged(object sender, EventArgs e)
        {

        }

        private void computationalResultForWestStar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void no_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
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

        private void va3_TextChanged(object sender, EventArgs e)
        {

        }

        private void sw2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
