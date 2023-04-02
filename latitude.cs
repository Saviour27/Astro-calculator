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
    public partial class f6 : Form
    {
        //private double ;
        
        //public setBigValue(double index, double[] myArray){
          //  this.bigArray[index-1] = myArray;        }
        public f6()
        {
            InitializeComponent();
        }

        private void back2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form7 f7 = new Form7();
            f7.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /**double [] smallArray = new double[4];
            
            smallArray [0] = double.Parse(vat.Text);
            smallArray [1] = double.Parse(ctot.Text);
            smallArray [2] = double.Parse(tt.Text);
            smallArray [3] = double.Parse(mt.Text);

            double [,] bigArray = new double [int.Parse(obser.Text) , 4 ];**/
             
            //for (int i = 0; i <= 4; i ++){
               // smallArray[i] = double.Parse(va.Text);
            //}
        }

        DataTable table1 = new DataTable();
        DataTable table2 = new DataTable();
        DataTable table3 = new DataTable();

        private void f6_Load(object sender, EventArgs e)
        {
            table3.Columns.Add("Obser", typeof(int));
            table3.Columns.Add("VA", typeof(double));
            table3.Columns.Add("CTO", typeof(double));
            table3.Columns.Add("M", typeof(double));

            inputgrid.DataSource = table3;

            table1.Columns.Add("Obser", typeof(int));
            table1.Columns.Add("AM", typeof(double));
            table1.Columns.Add("HM", typeof(double));
            table1.Columns.Add("T", typeof(double));

            computationalResultForNorthStar.DataSource = table1;

            table2.Columns.Add("Obser", typeof(int));
            table2.Columns.Add("AM", typeof(double));
            table2.Columns.Add("HM", typeof(double));
            table2.Columns.Add("T", typeof(double));

            computationalResultForSouthStar.DataSource = table2;
        }

        private void computeInputForNorthStar_Click(object sender, EventArgs e)
        {
            double ctt = ((double.Parse(ctt1.Text)) + (double.Parse(ctt2.Text) / 60) + (double.Parse(ctt3.Text) / 3600));
            double dec = ((double.Parse(dec11.Text)) + (double.Parse(dec2.Text) / 60) + (double.Parse(dec3.Text) / 3600));
            double decs = ((double.Parse(decs1.Text)) + (double.Parse(decs2.Text) / 60) + (double.Parse(decs3.Text) / 3600));
            double lat = ((double.Parse(lat11.Text)) + (double.Parse(lat2.Text) / 60) + (double.Parse(lat3.Text) / 3600));
            double f = ((double.Parse(f1.Text)) + (double.Parse(f2.Text) / 60) + (double.Parse(f3.Text) / 3600));
            double r0 = ((double.Parse(r01.Text)) + (double.Parse(r02.Text) / 60) + (double.Parse(r03.Text) / 3600));



            double sum = 0;
            for (int i = 0; i <= inputgrid.Rows.Count - 1; i++) {
                sum = sum + double.Parse(inputgrid.Rows[i].Cells[1].Value.ToString());
            }
            int count_row = inputgrid.Rows.Count;
            double MeanVa = sum / count_row;
            double lat1 = (lat) * (Math.PI / 180);
            double dec1 = (dec) * (Math.PI / 180);
            double MeanVa1 = MeanVa * (Math.PI / 180);
            double AAA = (Math.Cos((lat1))) * (Math.Cos((dec1))) * (1/(Math.Acos(MeanVa1)));

            NA.Text = AAA.ToString();

            for(int j = 0; j <= inputgrid.Rows.Count - 1; j++){
                double AM = AAA * double.Parse(inputgrid.Rows[j].Cells[3].Value.ToString());
                double HH = double.Parse(inputgrid.Rows[j].Cells[1].Value.ToString()) + AM;
                double TTT = double.Parse(inputgrid.Rows[j].Cells[2].Value.ToString()) - (ctt);
                
                table1.Rows.Add(j.ToString(), AM.ToString(), HH.ToString(), TTT.ToString());
                computationalResultForNorthStar.DataSource = table1;
            }
            
            double result;
            double sumH = 0;
            for (int i = 0; i <= computationalResultForNorthStar.Rows.Count - 1; i++)
            {
                sumH = sumH + double.Parse(computationalResultForNorthStar.Rows[i].Cells[2].Value.ToString());
                result = sumH / (i + 1);
                NMVH.Text = result.ToString();


                double NNR = (r0) * (f);
                NR.Text = NNR.ToString();
                double cmvhh = result + NNR;
                NCMVH.Text = cmvhh.ToString();
            }
        }

        private void add_Click(object sender, EventArgs e)
        {
            double va = ((double.Parse(va1.Text)) + (double.Parse(va2.Text) / 60) + (double.Parse(va3.Text) / 3600));
            double cto = ((double.Parse(cto1.Text)) + (double.Parse(cto2.Text) / 60) + (double.Parse(cto3.Text) / 3600));
            double m = ((double.Parse(m11.Text)) + (double.Parse(m12.Text) / 60) + (double.Parse(m13.Text) / 3600));

            table3.Rows.Add(no.Text, va, cto, m);
            inputgrid.DataSource = table3;
        }

        private void computeInputForSouthStar_Click(object sender, EventArgs e)
        {
            double ctt = ((double.Parse(ctt1.Text)) + (double.Parse(ctt2.Text) / 60) + (double.Parse(ctt3.Text) / 3600));
            double dec = ((double.Parse(dec11.Text)) + (double.Parse(dec2.Text) / 60) + (double.Parse(dec3.Text) / 3600));
            double decs = ((double.Parse(decs1.Text)) + (double.Parse(decs2.Text) / 60) + (double.Parse(decs3.Text) / 3600));
            double lat = ((double.Parse(lat11.Text)) + (double.Parse(lat2.Text) / 60) + (double.Parse(lat3.Text) / 3600));
            double f = ((double.Parse(f1.Text)) + (double.Parse(f2.Text) / 60) + (double.Parse(f3.Text) / 3600));
            double r0 = ((double.Parse(r01.Text)) + (double.Parse(r02.Text) / 60) + (double.Parse(r03.Text) / 3600));


            double sum = 0;
            for (int i = 0; i <= inputgrid.Rows.Count - 1; i++)
            {
                sum = sum + double.Parse(inputgrid.Rows[i].Cells[1].Value.ToString());
            }
            int count_row = inputgrid.Rows.Count;
            double MeanVa = sum / count_row;
            double lat1 = (lat) * (Math.PI / 180);
            double dec1 = (decs) * (Math.PI / 180);
            double MeanVa1 = MeanVa * (Math.PI / 180);
            double AAA = (Math.Cos((lat1))) * (Math.Cos((dec1))) * (1/(Math.Cos(MeanVa1)));

            SA.Text = AAA.ToString();

            for (int j = 0; j <= inputgrid.Rows.Count - 1; j++)
            {
                double AM = AAA * double.Parse(inputgrid.Rows[j].Cells[3].Value.ToString());
                double HH = double.Parse(inputgrid.Rows[j].Cells[1].Value.ToString()) + AM;
                double TTT = double.Parse(inputgrid.Rows[j].Cells[2].Value.ToString()) - (ctt);

                table2.Rows.Add(j.ToString(), AM.ToString(), HH.ToString(), TTT.ToString());
                computationalResultForSouthStar.DataSource = table2;
            }

            double result;
            double sumH = 0;
            for (int i = 0; i <= computationalResultForSouthStar.Rows.Count - 1; i++)
            {
                sumH = sumH + double.Parse(computationalResultForSouthStar.Rows[i].Cells[2].Value.ToString());
                result = sumH / (i + 1);
                SMVH.Text = result.ToString();

                double SNR = (r0) * (f);
                SR.Text = SNR.ToString();
                double cmvhh = result + SNR;
                SCMVH.Text = cmvhh.ToString();
            }
        }

        private void computeSigma_Click(object sender, EventArgs e)
        {
            double dec = ((double.Parse(dec11.Text)) + (double.Parse(dec2.Text) / 60) + (double.Parse(dec3.Text) / 3600));
            double decs = ((double.Parse(decs1.Text)) + (double.Parse(decs2.Text) / 60) + (double.Parse(decs3.Text) / 3600));

            double sig = (0.5 * (double.Parse(NCMVH.Text) - double.Parse(SCMVH.Text))) + (0.5 * ((dec) - (decs)));
            sigma.Text = sig.ToString();
        }

        private void sigma_TextChanged(object sender, EventArgs e)
        {

        }

        private void NMVH_TextChanged(object sender, EventArgs e)
        {

        }

        private void NstarNo_TextChanged(object sender, EventArgs e)
        {

        }
        private void sec_TextChanged(object sender, EventArgs e)
        {

        }

      

        private void deg_Click(object sender, EventArgs e)
        {

        }

        private void min_Click(object sender, EventArgs e)
        {

        }

        private void sec_Click(object sender, EventArgs e)
        {

        }

        private void computeSec_Click(object sender, EventArgs e)
        {

        }

        private void deg_TextChanged(object sender, EventArgs e)
        {

        }

        private void min_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter_1(object sender, EventArgs e)
        {

        }

        private void computeSec_Click_1(object sender, EventArgs e)
        {
            total.Text = ((double.Parse(deg.Text)) + (double.Parse(min.Text) / 60) + (double.Parse(sec.Text) / 3600)).ToString();
        }

        private void label33_Click(object sender, EventArgs e)
        {

        }

        private void label35_Click(object sender, EventArgs e)
        {

        }

        private void label34_Click(object sender, EventArgs e)
        {

        }

        private void gam_TextChanged(object sender, EventArgs e)
        {

        }

        private void NCMVH_TextChanged(object sender, EventArgs e)
        {

        }

        private void nsig_TextChanged(object sender, EventArgs e)
        {

        }

        private void NA_TextChanged(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void m_TextChanged(object sender, EventArgs e)
        {

        }

        private void va_TextChanged(object sender, EventArgs e)
        {

        }

        private void phy_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void inputgrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Ntemp_TextChanged(object sender, EventArgs e)
        {

        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void SA_TextChanged(object sender, EventArgs e)
        {

        }

        private void SMVH_TextChanged(object sender, EventArgs e)
        {

        }

        private void SR_TextChanged(object sender, EventArgs e)
        {

        }

        private void SCMVH_TextChanged(object sender, EventArgs e)
        {

        }

        private void ssig_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void NR_TextChanged(object sender, EventArgs e)
        {

        }

        private void computationalResultForNorthStar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void SstarNo_TextChanged(object sender, EventArgs e)
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
            m1.Text = min.ToString();
            s.Text = sec.ToString();
        }
    }
}
