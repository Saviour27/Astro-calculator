using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;

namespace AstronomicalComputations
{
    public partial class Form12 : Form
    {
        public Form12()
        {
            InitializeComponent();
        }
        DataTable table1 = new DataTable();

        private void Form12_Load(object sender, EventArgs e)
        {

            table1.Columns.Add("Obser", typeof(int));
            table1.Columns.Add("VA", typeof(double));

            inputgrid.DataSource = table1;


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void add_Click_1(object sender, EventArgs e)
        {
            double va = ((double.Parse(va1.Text)) + (double.Parse(va2.Text) / 60) + (double.Parse(va3.Text) / 3600));

            table1.Rows.Add(textBox6.Text, va);
            inputgrid.DataSource = table1;
        }

        private void va_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void ut_TextChanged(object sender, EventArgs e)
        {

        }

        private void asslat_TextChanged(object sender, EventArgs e)
        {

        }

        private void ut_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void computeInputForEastStar_Click(object sender, EventArgs e)
        {


            double r = ((double.Parse(r1.Text)) + (double.Parse(r2.Text) / 60) + (double.Parse(r3.Text) / 3600));
            double w1 = ((double.Parse(w11.Text)) + (double.Parse(w12.Text) / 60) + (double.Parse(w13.Text) / 3600));
            double w2 = ((double.Parse(w21.Text)) + (double.Parse(w22.Text) / 60) + (double.Parse(w23.Text) / 3600));
            double a = ((double.Parse(a11.Text)) + (double.Parse(a12.Text) / 60) + (double.Parse(a13.Text) / 3600));
            double r0 = ((double.Parse(r01.Text)) + (double.Parse(r02.Text) / 60) + (double.Parse(r03.Text) / 3600));
            double f = ((double.Parse(f1.Text)) + (double.Parse(f2.Text) / 60) + (double.Parse(f3.Text) / 3600));
            double asslat = ((double.Parse(lat11.Text)) + (double.Parse(lat2.Text) / 60) + (double.Parse(lat3.Text) / 3600));
            double along = ((double.Parse(along1.Text)) + (double.Parse(along2.Text) / 60) + (double.Parse(along3.Text) / 3600));


            double sum = 0;
            for (int i = 0; i <= inputgrid.Rows.Count - 1; i++)
            {
                sum = sum + double.Parse(inputgrid.Rows[i].Cells[1].Value.ToString());
            }
            int count_row = inputgrid.Rows.Count;
            double MeanVa = sum / count_row;

            double Ref = double.Parse(r01.Text) * double.Parse(f1.Text);

            double Meanh = MeanVa + Ref;
            this.meanh.Text = Meanh.ToString();

            double lat1 = asslat * (3.142 / 180);
            double Meanh1 = (Meanh) * (3.142 / 180);
            double a1 = a * (3.142 / 180);

            double gst = (w1 + w2) / 2;
            double ut = gst - 1.00;
            this.ut.Text = ut.ToString();
            double dec = Math.Asin((Math.Sin((lat1))) * (Math.Sin(Meanh1)) + ((Math.Cos((lat1))) * (Math.Cos(Meanh1)) * (Math.Cos((a1)))));
            double dec1 = (dec) / (3.142 / 180);
            this.dec.Text = dec1.ToString();
            double t = Math.Asin((-(Math.Sin((a1)))) * (Math.Cos(Meanh1)) * (1 / Math.Cos((dec))));
            double tt = t / (3.142 / 180);
            this.t.Text = tt.ToString();


            double along11 = along * 0.067;
            double tt1 = tt * 0.067;

            double ra = ut + r + along11 - tt1;
            double ra1 = ra * 0.067;
            this.ra.Text = ra1.ToString();


            if (ra1 > 0 && ra1 < 1 && dec1 > 25 && dec1 < 35)
                northstar.Text = "Star No = 1" + Environment.NewLine + "Magnitude = 2.1" + Environment.NewLine + "Name = α Andromedae";
            else
            if (ra1 > 0 && ra1 < 1 && dec1 > 55 && dec1 < 65)
                northstar.Text = "Star No = 2" + Environment.NewLine + "Magnitude = 2.4" + Environment.NewLine + "Name = β Cassiopeiae";
            else
            if (ra1 > 0 && ra1 < 1 && dec1 > -50 && dec1 < -40)
                southstar.Text = "Star No = 3" + Environment.NewLine + "Magnitude = 3.9" + Environment.NewLine + "Name = ε Pheonicis";
            else
            if (ra1 > 0 && ra1 < 1 && dec1 > 10 && dec1 < 20)
                northstar.Text = "Star No = 4" + Environment.NewLine + "Magnitude = 2.9" + Environment.NewLine + "Name = γ Pegasi";
            else
            if (ra1 > 0 && ra1 < 1 && dec1 > -15 && dec1 < -5)
                southstar.Text = "Star No = 5" + Environment.NewLine + "Magnitude = 3.7" + Environment.NewLine + "Name =  ι Ceti";
            else
            if (ra1 > 0 && ra1 < 1 && dec1 > -70 && dec1 < -60)
                southstar.Text = "Star No = 6" + Environment.NewLine + "Magnitude = 4.3" + Environment.NewLine + "Name = ζ Tucanae";
            else
            if (ra1 > 0 && ra1 < 1 && dec1 > -80 && dec1 < -70)
                southstar.Text = "Star No = 7" + Environment.NewLine + "Magnitude = 2.9" + Environment.NewLine + "Name = β Hydri";
            else
            if (ra1 > 0 && ra1 < 1 && dec1 > -50 && dec1 < -40)
                southstar.Text = "Star No = 8" + Environment.NewLine + "Magnitude = 3.9" + Environment.NewLine + "Name = Κ Pheonicis";
            else
            if (ra1 > 0 && ra1 < 1 && dec1 > -50 && dec1 < -40)
                southstar.Text = "Star No = 9" + Environment.NewLine + "Magnitude = 2.4" + Environment.NewLine + "Name = α Pheonicis";
            else
            if (ra1 > 0 && ra1 < 1 && dec1 > 60 && dec1 < 70)
                northstar.Text = "Star No = 10" + Environment.NewLine + "Magnitude = 4.2" + Environment.NewLine + "Name = Κ Cassiopeiae";
            else
            if (ra1 > 0 && ra1 < 1 && dec1 > 50 && dec1 < 60)
                northstar.Text = "Star No = 11" + Environment.NewLine + "Magnitude = 3.7" + Environment.NewLine + "Name = ζ Cassiopeiae";
            else
            if (ra1 > 0 && ra1 < 1 && dec1 > 25 && dec1 < 35)
                northstar.Text = "Star No = 12" + Environment.NewLine + "Magnitude = 3.5" + Environment.NewLine + "Name = δ Andromedae";
            else
            if (ra1 > 0 && ra1 < 1 && dec1 > 50 && dec1 < 60)
                northstar.Text = "Star No = 13" + Environment.NewLine + "Magnitude = 2.3" + Environment.NewLine + "Name = α Cassiopeiae";
            else
            if (ra1 > 0 && ra1 < 1 && dec1 > 15 && dec1 < 25)
                northstar.Text = "Star No = 14" + Environment.NewLine + "Magnitude = 2.2" + Environment.NewLine + "Name = β Ceti";
            else
            if (ra1 > 0 && ra1 < 1 && dec1 > 20 && dec1 < 30)
                northstar.Text = "Star No = 15" + Environment.NewLine + "Magnitude = 4.3" + Environment.NewLine + "Name = ζ Andromedae";
            else
            if (ra1 > 0 && ra1 < 1 && dec1 > 55 && dec1 < 65)
                northstar.Text = "Star No = 16" + Environment.NewLine + "Magnitude = 3.6" + Environment.NewLine + "Name = η Cassiopeiae";
            else
            if (ra1 > 0 && ra1 < 1 && dec1 > 35 && dec1 < 45)
                northstar.Text = "Star No = 17" + Environment.NewLine + "Magnitude = 4.4" + Environment.NewLine + "Name = ν Andromedae";
            else
            if (ra1 > 0 && ra1 < 1.0 && dec1 > 55 && dec1 < 65)
                northstar.Text = "Star No = 18" + Environment.NewLine + "Magnitude = 1-4" + Environment.NewLine + "Name = γ Cassiopeiae";
            else
            if (ra1 > 0 && ra1 < 1.0 && dec1 > 35 && dec1 < 45)
                northstar.Text = "Star No = 19" + Environment.NewLine + "Magnitude = 3.9" + Environment.NewLine + "Name = μ Andromedae";
            else
            if (ra1 > 0 && ra1 < 1 && dec1 > -35 && dec1 < -25)
                southstar.Text = "Star No = 20" + Environment.NewLine + "Magnitude = 4.4" + Environment.NewLine + "Name = α Sculptoris";
            else
            if (ra > 0 && ra1 < 1 && dec1 > 5 && dec1 < 15)
                northstar.Text = "Star No = 21" + Environment.NewLine + "Magnitude = 4.4" + Environment.NewLine + "Name = ε Piscium";
            else
            if (ra1 > 1 && ra1 < 2 && dec1 > -50 && dec1 < -40)
                southstar.Text = "Star No = 22" + Environment.NewLine + "Magnitude = 3.3" + Environment.NewLine + "Name = β Pheonicis";
            else
            if (ra1 > 1 && ra1 < 2 && dec1 > -15 && dec1 < -5)
                southstar.Text = "Star No = 23" + Environment.NewLine + "Magnitude = 3.6" + Environment.NewLine + "Name = η Ceti";
            else
            if (ra1 > 1 && ra1 < 2 && dec1 > 30 && dec1 < 40)
                northstar.Text = "Star No = 24" + Environment.NewLine + "Magnitude = 2.4" + Environment.NewLine + "Name = β Andromedae";
            else
            if (ra1 > 1 && ra1 < 2 && dec1 > -15 && dec1 < -5)
                southstar.Text = "Star No = 25" + Environment.NewLine + "Magnitude = 3.8" + Environment.NewLine + "Name = θ Ceti";
            else
            if (ra1 > 1 && ra1 < 2 && dec1 > 55 && dec1 < 65)
                northstar.Text = "Star No = 26" + Environment.NewLine + "Magnitude = 2.8" + Environment.NewLine + "Name = δ Cassiopeiae";
            else
            if (ra1 > 1 && ra1 < 2 && dec1 > -50 && dec1 < -40)
                southstar.Text = "Star No = 27" + Environment.NewLine + "Magnitude = 3.4" + Environment.NewLine + "Name = γ Pheonicis";
            else
            if (ra1 > 1 && ra1 < 2 && dec1 > 10 && dec1 < 20)
                northstar.Text = "Star No = 28" + Environment.NewLine + "Magnitude = 3.7" + Environment.NewLine + "Name = η Piscium";
            else
            if (ra1 > 1 && ra1 < 2 && dec1 > -55 && dec1 < -45)
                southstar.Text = "Star No = 29" + Environment.NewLine + "Magnitude = 4.0" + Environment.NewLine + "Name = δ Pheonicis";
            else
            if (ra1 > 1 && ra1 < 2 && dec1 > 35 && dec1 < 45)
                northstar.Text = "Star No = 30" + Environment.NewLine + "Magnitude = 4.2" + Environment.NewLine + "Name =ν Andromedae";
            else
            if (ra1 > 1 && ra1 < 2 && dec1 > 45 && dec1 < 55)
                northstar.Text = "Star No = 31" + Environment.NewLine + "Magnitude = 3.8" + Environment.NewLine + "Name = 51 Andromedae";
            else
            if (ra1 > 1 && ra1 < 2 && dec1 > -65 && dec1 < -55)
                southstar.Text = "Star No = 32" + Environment.NewLine + "Magnitude = 0.6" + Environment.NewLine + "Name = Achenar (α Eri)";
            else
            if (ra1 > 1 && ra1 < 2 && dec1 > 45 && dec1 < 55)
                northstar.Text = "Star No = 33" + Environment.NewLine + "Magnitude = 4.2" + Environment.NewLine + "Name = φ Persei";
            else
            if (ra1 > 1 && ra1 < 2 && dec1 > -20 && dec1 < -10)
                southstar.Text = "Star No = 34" + Environment.NewLine + "Magnitude = 3.6" + Environment.NewLine + "Name = τ Ceti";
            else
            if (ra1 > 1 && ra1 < 2 && dec1 > -15 && dec1 < -5)
                southstar.Text = "Star No = 35" + Environment.NewLine + "Magnitude = 3.9" + Environment.NewLine + "Name = ζ Ceti";
            else
            if (ra1 > 1 && ra1 < 2 && dec1 > 25 && dec1 < 35)
                northstar.Text = "Star No = 36" + Environment.NewLine + "Magnitude = 3.6" + Environment.NewLine + "Name = α Trianguli";
            else
            if (ra1 > 1 && ra1 < 2 && dec1 > 60 && dec1 < 70)
                northstar.Text = "Star No = 37" + Environment.NewLine + "Magnitude = 3.4" + Environment.NewLine + "Name = ε Cassiopeiae";
            else
            if (ra1 > 1 && ra1 < 2 && dec1 > -50 && dec1 < -40)
                southstar.Text = "Star No = 38" + Environment.NewLine + "Magnitude = 4.4" + Environment.NewLine + "Name = ϕ Phoenicis";
            else
            if (ra1 > 1 && ra1 < 2 && dec1 > 15 && dec1 < 25)
                northstar.Text = "Star No = 39" + Environment.NewLine + "Magnitude = 2.7" + Environment.NewLine + "Name = β Arietis";
            else
            if (ra1 > 1 && ra1 < 2 && dec1 > -55 && dec1 < -45)
                southstar.Text = "Star No = 40" + Environment.NewLine + "Magnitude = 3.7" + Environment.NewLine + "Name = χ Eridani";
            else
            if (ra1 > 1 && ra1 < 2 && dec1 > -65 && dec1 < -55)
                southstar.Text = "Star No = 41" + Environment.NewLine + "Magnitude = 3.0" + Environment.NewLine + "Name = α Hydri";
            else
            if (ra1 > 1 && ra1 < 2 && dec1 > -25 && dec1 < -15)
                southstar.Text = "Star No = 42" + Environment.NewLine + "Magnitude = 4.2" + Environment.NewLine + "Name = υ Ceti";
            else
            if (ra1 > 1 && ra1 < 2 && dec1 > 0 && dec1 < 10)
                northstar.Text = "Star No = 43" + Environment.NewLine + "Magnitude = 3.9" + Environment.NewLine + "Name = α Piscium";
            else
            if (ra1 > 2 && ra1 < 3 && dec1 > 65.000 && dec1 < 70.000)
                northstar.Text = "Star No = 44" + Environment.NewLine + "Magnitude = 4.1" + Environment.NewLine + "Name = 50 Cassiopeiae";
            else
            if (ra1 > 1 && ra1 < 2 && dec1 > 40 && dec1 < 50)
                northstar.Text = "Star No = 45" + Environment.NewLine + "Magnitude = 2.3" + Environment.NewLine + "Name = γ Andromedae";
            else
            if (ra1 > 2 && ra1 < 3 && dec1 > 20 && dec1 < 30)
                northstar.Text = "Star No = 46" + Environment.NewLine + "Magnitude = 2.2" + Environment.NewLine + "Name = α Arietis";
            else
            if (ra1 > 2 && ra1 < 3 && dec1 > 30 && dec1 < 40)
                northstar.Text = "Star No = 47" + Environment.NewLine + "Magnitude = 3.1" + Environment.NewLine + "Name = β Trianguli";
            else
            if (ra1 > 2 && ra1 < 3 && dec1 > -55 && dec1 < -45)
                southstar.Text = "Star No = 48" + Environment.NewLine + "Magnitude = 3.8" + Environment.NewLine + "Name = φ Eridani";
            else
            if (ra1 > 2 && ra1 < 3 && dec1 > 30 && dec1 < 40)
                northstar.Text = "Star No = 49" + Environment.NewLine + "Magnitude = 4.1" + Environment.NewLine + "Name = γ Trianguli";
            else
            if (ra1 > 2 && ra1 < 3 && dec1 > -10 && dec1 < 0)
                southstar.Text = "Star No = 50" + Environment.NewLine + "Magnitude = 2-10" + Environment.NewLine + "Name = ο Ceti";
            else
            if (ra1 > 2 && ra1 < 3 && dec1 > -75 && dec1 < -65)
                southstar.Text = "Star No = 51" + Environment.NewLine + "Magnitude = 4.3" + Environment.NewLine + "Name = δ Hydri";
            else
            if (ra1 > 2 && ra1 < 3 && dec1 > -50 && dec1 < -40)
                southstar.Text = "Star No = 52" + Environment.NewLine + "Magnitude = 4.4" + Environment.NewLine + "Name = Κ Eridani";
            else
            if (ra1 > 2 && ra1 < 3 && dec1 > 5 && dec1 < 15)
                northstar.Text = "Star No = 53" + Environment.NewLine + "Magnitude = 4.3" + Environment.NewLine + "Name = ξ^2 Ceti";
            else
            if (ra1 > 2 && ra1 < 3 && dec1 > 0 && dec1 < 10)
                northstar.Text = "Star No = 54" + Environment.NewLine + "Magnitude = 4.0" + Environment.NewLine + "Name = δ Ceti";
            else
            if (ra1 > 2 && ra1 < 3 && dec1 > -75 && dec1 < -65)
                southstar.Text = "Star No = 55" + Environment.NewLine + "Magnitude = 4.3" + Environment.NewLine + "Name =ε Hydri";
            else
            if (ra1 > 2 && ra1 < 3 && dec1 > -45 && dec1 < -35)
                southstar.Text = "Star No = 56" + Environment.NewLine + "Magnitude = 4.1" + Environment.NewLine + "Name = ι Eridani";
            else
            if (ra1 > 2 && ra1 < 3 && dec1 > 0 && dec1 < 10)
                northstar.Text = "Star No = 57" + Environment.NewLine + "Magnitude = 3.6" + Environment.NewLine + "Name = γ Ceti";
            else
            if (ra1 > 2 && ra1 < 3 && dec1 > 45 && dec1 < 55)
                northstar.Text = "Star No = 58" + Environment.NewLine + "Magnitude = 4.2" + Environment.NewLine + "Name = θ Persei";
            else
            if (ra1 > 2 && ra1 < 3 && dec1 > -20 && dec1 < -10)
                southstar.Text = "Star No = 59" + Environment.NewLine + "Magnitude = 4.4" + Environment.NewLine + "Name = π Ceti";
            else
            if (ra1 > 2 && ra1 < 3 && dec1 > 5 && dec1 < 15)
                northstar.Text = "Star No = 60" + Environment.NewLine + "Magnitude = 4.4" + Environment.NewLine + "Name = μ Ceti";
            else
            if (ra1 > 2 && ra1 < 3 && dec1 > 20 && dec1 < 30)
                northstar.Text = "Star No = 61" + Environment.NewLine + "Magnitude = 3.7" + Environment.NewLine + "Name = 41 Arietis";
            else
            if (ra1 > 2 && ra1 < 3 && dec1 > 50 && dec1 < 60)
                northstar.Text = "Star No = 62" + Environment.NewLine + "Magnitude = 3.9" + Environment.NewLine + "Name = η Persei";
            else
            if (ra1 > 2 && ra1 < 3.0 && dec1 > 50 && dec1 < 60)
                northstar.Text = "Star No = 63" + Environment.NewLine + "Magnitude = 4.1" + Environment.NewLine + "Name = τ Persei";
            else
            if (ra1 > 2 && ra1 < 3.0 && dec1 > -15 && dec1 < -5)
                southstar.Text = "Star No = 64" + Environment.NewLine + "Magnitude = 4.0" + Environment.NewLine + "Name = η Eridani";
            else
            if (ra1 > 2 && ra1 < 3.0 && dec1 > -45 && dec1 < -35)
                southstar.Text = "Star No = 65" + Environment.NewLine + "Magnitude = 3.4" + Environment.NewLine + "Name = θ Eridani";
            else
            if (ra1 > 2 && ra1 < 3 && dec1 > 0 && dec1 < 10)
                northstar.Text = "Star No = 66" + Environment.NewLine + "Magnitude = 2.8" + Environment.NewLine + "Name = α Ceti";
            else
            if (ra1 > 2 && ra1 < 3 && dec1 > -30 && dec1 < -20)
                southstar.Text = "Star No = 67" + Environment.NewLine + "Magnitude = 4.2" + Environment.NewLine + "Name = τ^3 Eridani";
            else
            if (ra1 > 2 && ra1 < 3 && dec1 > 50 && dec1 < 60)
                northstar.Text = "Star No = 68" + Environment.NewLine + "Magnitude = 3.1" + Environment.NewLine + "Name = γ Persei";
            else
            if (ra1 > 3 && ra1 < 4 && dec1 > 35 && dec1 < 45)
                northstar.Text = "Star No = 69" + Environment.NewLine + "Magnitude = 3.7" + Environment.NewLine + "Name = ρ Persei";
            else
            if (ra1 > 3 && ra1 < 4 && dec1 > 35 && dec1 < 45)
                northstar.Text = "Star No = 70" + Environment.NewLine + "Magnitude = 2-3" + Environment.NewLine + "Name = Algol (β Persei)";
            else
            if (ra1 > 3 && ra1 < 4 && dec1 > 45 && dec1 < 55)
                northstar.Text = "Star No = 71" + Environment.NewLine + "Magnitude = 4.2" + Environment.NewLine + "Name = ι Persei";
            else
            if (ra1 > 3 && ra1 < 4 && dec1 > -35 && dec1 < -25)
                southstar.Text = "Star No = 72" + Environment.NewLine + "Magnitude = 3.9" + Environment.NewLine + "Name = α Fornacis";
            else
            if (ra1 > 3 && ra1 < 4 && dec1 > -25 && dec1 < -15)
                southstar.Text = "Star No = 73" + Environment.NewLine + "Magnitude = 3.9" + Environment.NewLine + "Name = 16 Eridani";
            else
            if (ra1 > 3 && ra1 < 4 && dec1 > -50 && dec1 < -40)
                southstar.Text = "Star No = 74" + Environment.NewLine + "Magnitude = 4.3" + Environment.NewLine + "Name = BS 1008 (Eridani)";
            else
            if (ra1 > 3 && ra1 < 4 && dec1 > 45 && dec1 < 55)
                northstar.Text = "Star No = 75" + Environment.NewLine + "Magnitude = 1.9" + Environment.NewLine + "Name = α Persei";
            else
            if (ra1 > 3 && ra1 < 4 && dec1 > 5 && dec1 < 15)
                northstar.Text = "Star No = 76" + Environment.NewLine + "Magnitude = 3.8" + Environment.NewLine + "Name = ο Tauri";
            else
            if (ra1 > 3 && ra1 < 4 && dec1 > 5 && dec1 < 15)
                northstar.Text = "Star No = 77" + Environment.NewLine + "Magnitude = 3.7" + Environment.NewLine + "Name = ξ Tauri";
            else
            if (ra1 > 3 && ra1 < 4 && dec1 > 55 && dec1 < 65)
                northstar.Text = "Star No = 78" + Environment.NewLine + "Magnitude = 4.4" + Environment.NewLine + "Name = BS 1035 (Cam)";
            else
            if (ra1 > 3 && ra1 < 4 && dec1 > 5 && dec1 < 15)
                northstar.Text = "Star No = 79" + Environment.NewLine + "Magnitude = 4.3" + Environment.NewLine + "Name = 5 Tauri";
            else
            if (ra1 > 3 && ra1 < 4 && dec1 > -15 && dec1 < -5)
                southstar.Text = "Star No = 80" + Environment.NewLine + "Magnitude = 3.8" + Environment.NewLine + "Name = ε Eridani";
            else
            if (ra1 > 3 && ra1 < 4 && dec1 > -25 && dec1 < -15)
                southstar.Text = "Star No = 81" + Environment.NewLine + "Magnitude = 4.3" + Environment.NewLine + "Name = τ^5 Eridani";
            else
            if (ra1 > 3 && ra1 < 4 && dec1 > 0 && dec1 < 10)
                northstar.Text = "Star No = 82" + Environment.NewLine + "Magnitude = 4.4" + Environment.NewLine + "Name = 10 Tauri";
            else
            if (ra1 > 3 && ra1 < 4 && dec1 > 45 && dec1 < 55)
                northstar.Text = "Star No = 83" + Environment.NewLine + "Magnitude = 3.1" + Environment.NewLine + "Name = δ Persei";
            else
            if (ra1 > 3 && ra1 < 4 && dec1 > -15 && dec1 < -5)
                southstar.Text = "Star No = 84" + Environment.NewLine + "Magnitude = 3.7" + Environment.NewLine + "Name = δ Eridani";
            else
            if (ra1 > 3 && ra1 < 4 && dec1 > 25 && dec1 < 35)
                northstar.Text = "Star No = 85" + Environment.NewLine + "Magnitude = 3.9" + Environment.NewLine + "Name = ο Persei";
            else
            if (ra1 > 3 && ra1 < 4 && dec1 > 20 && dec1 < 30)
                northstar.Text = "Star No = 86" + Environment.NewLine + "Magnitude = 3.8" + Environment.NewLine + "Name = 17 Tauri";
            else
            if (ra1 > 3 && ra1 < 4 && dec1 > 40 && dec1 < 50)
                northstar.Text = "Star No = 87" + Environment.NewLine + "Magnitude = 3.9" + Environment.NewLine + "Name = ν Persei";
            else
            if (ra1 > 3 && ra1 < 4 && dec1 > -70 && dec1 < -60)
                southstar.Text = "Star No = 88" + Environment.NewLine + "Magnitude = 3.8" + Environment.NewLine + "Name = β Recticuli";
            else
            if (ra1 > 3 && ra1 < 4 && dec1 > -30 && dec1 < -20)
                northstar.Text = "Star No = 89" + Environment.NewLine + "Magnitude = 4.3" + Environment.NewLine + "Name = τ^6 Eridani";
            else
            if (ra1 > 3 && ra1 < 4 && dec1 > 20 && dec1 < 30)
                northstar.Text = "Star No = 90" + Environment.NewLine + "Magnitude = 3.0" + Environment.NewLine + "Name =  η Tauri";
            else
            if (ra1 > 3 && ra1 < 4 && dec1 > -80 && dec1 < -70)
                southstar.Text = "Star No = 91" + Environment.NewLine + "Magnitude = 3.2" + Environment.NewLine + "Name = Hydri";
            else
            if (ra1 > 3 && ra1 < 4 && dec1 > 20 && dec1 < 30)
                northstar.Text = "Star No = 92" + Environment.NewLine + "Magnitude = 3.8" + Environment.NewLine + "Name = γ Tauri";
            else
            if (ra1 > 3 && ra1 < 4 && dec1 > -40 && dec1 < -30)
                southstar.Text = "Star No = 93" + Environment.NewLine + "Magnitude = 4.2" + Environment.NewLine + "Name = BS 1195 (Eridani)";
            else
            if (ra1 > 3 && ra1 < 4.0 && dec1 > 25 && dec1 < 35)
                northstar.Text = "Star No = 94" + Environment.NewLine + "Magnitude = 2.9" + Environment.NewLine + "Name = ζ Persei";
            else
            if (ra1 > 3 && ra1 < 4.0 && dec1 > 35 && dec1 < 45)
                northstar.Text = "Star No = 95" + Environment.NewLine + "Magnitude = 3.0" + Environment.NewLine + "Name = ε Persei";
            else
            if (ra1 > 3 && ra1 < 4.0 && dec1 > -15 && dec1 < -5)
                southstar.Text = "Star No = 96" + Environment.NewLine + "Magnitude = 3.2" + Environment.NewLine + "Name =γ Eridani";
            else
            if (ra1 > 3 && ra1 < 4 && dec1 > 30 && dec1 < 40)
                northstar.Text = "Star No = 97" + Environment.NewLine + "Magnitude = 4.0" + Environment.NewLine + "Name =ξ Persei";
            else
            if (ra1 > 3 && ra1 < 4 && dec1 > -65 && dec1 < -55)
                southstar.Text = "Star No = 98" + Environment.NewLine + "Magnitude = 4.4" + Environment.NewLine + "Name =δ Recticuli";
            else
            if (ra1 > 3 && ra1 < 4 && dec1 > 5 && dec1 < 15)
                northstar.Text = "Star No = 99" + Environment.NewLine + "Magnitude = 3.9" + Environment.NewLine + "Name = λ Tauri";
            else
            if (ra1 > 3 && ra1 < 4 && dec1 > 0 && dec1 < 10)
                northstar.Text = "Star No = 100" + Environment.NewLine + "Magnitude = 3.9" + Environment.NewLine + "Name = ν Tauri";
            else
            if (ra1 > 4 && ra1 < 5 && dec1 > 45 && dec1 < 55)
                northstar.Text = "Star No = 101" + Environment.NewLine + "Magnitude = 4.3" + Environment.NewLine + "Name = λ Persei";
            else
            if (ra1 > 4 && ra1 < 5 && dec1 > 45 && dec1 < 55)
                northstar.Text = "Star No = 102" + Environment.NewLine + "Magnitude = 4.0" + Environment.NewLine + "Name = 48 persei";
            else
            if (ra1 > 4 && ra1 < 5 && dec1 > -10 && dec1 < 0)
                southstar.Text = "Star No = 103" + Environment.NewLine + "Magnitude = 4.1" + Environment.NewLine + "Name = 0^1 Eridani";
            else
            if (ra1 > 4 && ra1 < 5 && dec1 > 45 && dec1 < 55)
                northstar.Text = "Star No = 104" + Environment.NewLine + "Magnitude = 4,3" + Environment.NewLine + "Name = μ Persei";
            else
            if (ra1 > 4 && ra1 < 5 && dec1 > -45 && dec1 < -35)
                southstar.Text = "Star No = 105" + Environment.NewLine + "Magnitude = 3.8" + Environment.NewLine + "Name = α Horologii";
            else
            if (ra1 > 4 && ra1 < 5 && dec1 > -65 && dec1 < -55)
                southstar.Text = "Star No = 106" + Environment.NewLine + "Magnitude = 3.4" + Environment.NewLine + "Name = α Recticuli";
            else
            if (ra1 > 4 && ra1 < 5 && dec1 > 5 && dec1 < 15)
                northstar.Text = "Star No = 107" + Environment.NewLine + "Magnitude = 4.3" + Environment.NewLine + "Name = μ Tauri";
            else
            if (ra1 > 4 && ra1 < 5 && dec1 > -55 && dec1 < -45)
                southstar.Text = "Star No = 108" + Environment.NewLine + "Magnitude = 4.4" + Environment.NewLine + "Name = γ Doradus";
            else
            if (ra1 > 4 && ra1 < 5 && dec1 > -40 && dec1 < -30)
                southstar.Text = "Star No = 109" + Environment.NewLine + "Magnitude = 3.6" + Environment.NewLine + "Name = υ^4 Eridani";
            else
            if (ra1 > 4 && ra1 < 5 && dec1 > 10 && dec1 < 20)
                northstar.Text = "Star No = 110" + Environment.NewLine + "Magnitude = 3.9" + Environment.NewLine + "Name = γ Tauri";
            else
            if (ra1 > 4 && ra1 < 5 && dec1 > 15 && dec1 < 25)
                northstar.Text = "Star No = 111" + Environment.NewLine + "Magnitude = 3.9" + Environment.NewLine + "Name = δ Tauri";
            else
            if (ra1 > 4 && ra1 < 5 && dec1 > -40 && dec1 < -30)
                southstar.Text = "Star No = 112" + Environment.NewLine + "Magnitude = 4.1" + Environment.NewLine + "Name = 43 Eridani";
            else
            if (ra1 > 4 && ra1 < 5 && dec1 > 15 && dec1 < 25)
                northstar.Text = "Star No = 113" + Environment.NewLine + "Magnitude = 3.6" + Environment.NewLine + "Name = ε Tauri";
            else
            if (ra1 > 4 && ra1 < 5 && dec1 > 10 && dec1 < 20)
                northstar.Text = "Star No = 114" + Environment.NewLine + "Magnitude = 3.6" + Environment.NewLine + "Name = θ^2 Tauri";
            else
            if (ra1 > 4 && ra1 < 5 && dec1 > -60 && dec1 < -50)
                southstar.Text = "Star No = 115" + Environment.NewLine + "Magnitude = 3.5" + Environment.NewLine + "Name = α Doradus";
            else
            if (ra1 > 4 && ra1 < 5 && dec1 > 10 && dec1 < 20)
                northstar.Text = "Star No = 116" + Environment.NewLine + "Magnitude = 1.1" + Environment.NewLine + "Name = Aldebaran (α Tau)";
            else
            if (ra1 > 4 && ra1 < 5 && dec1 > -35 && dec1 < -25)
                southstar.Text = "Star No = 117" + Environment.NewLine + "Magnitude = 3.9" + Environment.NewLine + "Name = υ^2 Eridani";
            else
            if (ra1 > 4 && ra1 < 5 && dec1 > -10 && dec1 < 0)
                southstar.Text = "Star No = 118" + Environment.NewLine + "Magnitude = 4.1" + Environment.NewLine + "Name = ν Eridani";
            else
            if (ra1 > 4 && ra1 < 5 && dec1 > -20 && dec1 < -10)
                southstar.Text = "Star No = 119" + Environment.NewLine + "Magnitude = 4.0" + Environment.NewLine + "Name = 53 Eridani";
            else
            if (ra1 > 4 && ra1 < 5 && dec1 > 20 && dec1 < 30)
                northstar.Text = "Star No = 120" + Environment.NewLine + "Magnitude = 4.3" + Environment.NewLine + "Name = τ Tauri";
            else
            if (ra1 > 4 && ra1 < 5 && dec1 > -10 && dec1 < 0)
                southstar.Text = "Star No = 121" + Environment.NewLine + "Magnitude = 4.2" + Environment.NewLine + "Name = μ Eridani";
            else
            if (ra1 > 4 && ra1 < 5 && dec1 > 1 && dec1 < 10)
                northstar.Text = "Star No = 122" + Environment.NewLine + "Magnitude = 3.3" + Environment.NewLine + "Name = π^3 Orionis";
            else
            if (ra1 > 4 && ra1 < 5 && dec1 > 1 && dec1 < 10)
                northstar.Text = "Star No = 123" + Environment.NewLine + "Magnitude = 3.8" + Environment.NewLine + "Name = π^4 Orionis";
            else
            if (ra1 > 4 && ra1 < 5.0 && dec1 > 60 && dec1 < 70)
                northstar.Text = "Star No = 124" + Environment.NewLine + "Magnitude = 4.4" + Environment.NewLine + "Name = α Camelopardalis";
            else
            if (ra1 > 4 && ra1 < 5.0 && dec1 > 1 && dec1 < 10)
                northstar.Text = "Star No = 125" + Environment.NewLine + "Magnitude = 3.9" + Environment.NewLine + "Name = π^5 Orionis";
            else
            if (ra1 > 4 && ra1 < 5.0 && dec1 > 30 && dec1 < 40)
                northstar.Text = "Star No = 126" + Environment.NewLine + "Magnitude = 2.9" + Environment.NewLine + "Name = ι Aurigae";
            else
            if (ra1 > 4 && ra1 < 5 && dec1 > 40 && dec1 < 50)
                northstar.Text = "Star No = 127" + Environment.NewLine + "Magnitude = 3.4" + Environment.NewLine + "Name = ε Aurigae";
            else
            if (ra1 > 4 && ra1 < 5 && dec1 > 35 && dec1 < 45)
                northstar.Text = "Star No = 128" + Environment.NewLine + "Magnitude = 3.9" + Environment.NewLine + "Name = ζ Aurigae";
            else
            if (ra1 > 4 && ra1 < 5 && dec1 > 55 && dec1 < 65)
                northstar.Text = "Star No = 129" + Environment.NewLine + "Magnitude = 4.2" + Environment.NewLine + "Name = β Camelopardalis";
            else
            if (ra1 > 5 && ra1 < 6 && dec1 > -30 && dec1 < -20)
                southstar.Text = "Star No = 130" + Environment.NewLine + "Magnitude = 3.3" + Environment.NewLine + "Name = ε Leporis";
            else
            if (ra1 > 5 && ra1 < 6 && dec1 > 35 && dec1 < 45)
                northstar.Text = "Star No = 131" + Environment.NewLine + "Magnitude = 3.3" + Environment.NewLine + "Name = η Aurigae";
            else
            if (ra1 > 5 && ra1 < 6 && dec1 > -10 && dec1 < 0)
                southstar.Text = "Star No = 132" + Environment.NewLine + "Magnitude = 2.9" + Environment.NewLine + "Name = β Eridani";
            else
            if (ra1 > 5 && ra1 < 6 && dec1 > -10 && dec1 < 0)
                southstar.Text = "Star No = 133" + Environment.NewLine + "Magnitude = 4.3" + Environment.NewLine + "Name = λ Eridani";
            else
            if (ra1 > 5 && ra1 < 6 && dec1 > -20 && dec1 < -10)
                southstar.Text = "Star No = 134" + Environment.NewLine + "Magnitude = 3.3" + Environment.NewLine + "Name = μ Leporis";
            else
            if (ra1 > 5 && ra1 < 6 && dec1 > -10 && dec1 < 0)
                southstar.Text = "Star No = 135" + Environment.NewLine + "Magnitude = 0.3" + Environment.NewLine + "Name = Rigel ( β Ori)";
            else
            if (ra1 > 5 && ra1 < 6 && dec1 > 40 && dec1 < 50)
                northstar.Text = "Star No = 136" + Environment.NewLine + "Magnitude = 0.2" + Environment.NewLine + "Name = Capella (α Aur)";
            else
            if (ra1 > 5 && ra1 < 6 && dec1 > -10 && dec1 < 0)
                southstar.Text = "Star No = 137" + Environment.NewLine + "Magnitude = 3.7" + Environment.NewLine + "Name = τ Orionis";
            else
            if (ra1 > 5 && ra1 < 6 && dec1 > -20 && dec1 < -10)
                southstar.Text = "Star No = 138" + Environment.NewLine + "Magnitude = 4.3" + Environment.NewLine + "Name = λ Leporis";
            else
            if (ra1 > 5 && ra1 < 6 && dec1 > -10 && dec1 < 0)
                southstar.Text = "Star No = 139" + Environment.NewLine + "Magnitude = 3.4" + Environment.NewLine + "Name = η Orionis";
            else
            if (ra1 > 5 && ra1 < 6 && dec1 > 0 && dec1 < 10)
                northstar.Text = "Star No = 140" + Environment.NewLine + "Magnitude = 1.7" + Environment.NewLine + "Name = γ Bellatrix (Ori)";
            else
            if (ra1 > 5 && ra1 < 6 && dec1 > 25 && dec1 < 35)
                northstar.Text = "Star No = 141" + Environment.NewLine + "Magnitude = 1.8" + Environment.NewLine + "Name = β Tauri";
            else
            if (ra1 > 5 && ra1 < 6 && dec1 > -25 && dec1 < -15)
                southstar.Text = "Star No = 142" + Environment.NewLine + "Magnitude = 3.0" + Environment.NewLine + "Name = β Leporis";
            else
            if (ra1 > 5 && ra1 < 6 && dec1 > -40 && dec1 < -30)
                southstar.Text = "Star No = 143" + Environment.NewLine + "Magnitude = 3.9" + Environment.NewLine + "Name = ε Columbae";
            else
            if (ra1 > 5 && ra1 < 6 && dec1 > -10 && dec1 < 5)
                southstar.Text = "Star No = 144" + Environment.NewLine + "Magnitude = 2.5" + Environment.NewLine + "Name = δ Orionis";
            else
            if (ra1 > 5 && ra1 < 6 && dec1 > -25 && dec1 < -10)
                southstar.Text = "Star No = 145" + Environment.NewLine + "Magnitude = 2.7" + Environment.NewLine + "Name = α Leporis";
            else
            if (ra1 > 5 && ra1 < 6 && dec1 > 70 && dec1 < 55)
                northstar.Text = "Star No = 146" + Environment.NewLine + "Magnitude = 3.8" + Environment.NewLine + "Name = β Doradus";
            else
            if (ra1 > 5 && ra1 < 6 && dec1 > 5 && dec1 < 15)
                northstar.Text = "Star No = 147" + Environment.NewLine + "Magnitude = 3.7" + Environment.NewLine + "Name = λ Orionis";
            else
            if (ra1 > 5 && ra1 < 6 && dec1 > -10 && dec1 < 0)
                southstar.Text = "Star No = 148" + Environment.NewLine + "Magnitude = 2.9" + Environment.NewLine + "Name = ι Orionis";
            else
            if (ra1 > 5 && ra1 < 6 && dec1 > -10 && dec1 < 5)
                southstar.Text = "Star No = 149" + Environment.NewLine + "Magnitude = 1.7" + Environment.NewLine + "Name = ε Orionis";
            else
            if (ra1 > 5 && ra1 < 6 && dec1 > 15 && dec1 < 25)
                northstar.Text = "Star No = 150" + Environment.NewLine + "Magnitude = 3.0" + Environment.NewLine + "Name = ζ Tauri";
            else
            if (ra1 > 5 && ra1 < 6 && dec1 > -10 && dec1 < 0)
                southstar.Text = "Star No = 151" + Environment.NewLine + "Magnitude = 3.8" + Environment.NewLine + "Name = σ Orionis";
            else
            if (ra1 > 5 && ra1 < 6 && dec1 > -40 && dec1 < -30)
                southstar.Text = "Star No = 152" + Environment.NewLine + "Magnitude = 2.7" + Environment.NewLine + "Name = α columbae";
            else
            if (ra1 > 5 && ra1 < 6 && dec1 > -10 && dec1 < 5)
                southstar.Text = "Star No = 153" + Environment.NewLine + "Magnitude = 2.0" + Environment.NewLine + "Name = ζ^1 Orionis";
            else
            if (ra1 > 5 && ra1 < 6 && dec1 > -25 && dec1 < -15)
                southstar.Text = "Star No = 154" + Environment.NewLine + "Magnitude = 3.8" + Environment.NewLine + "Name = γ Leporis";
            else
            if (ra1 > 5 && ra1 < 6 && dec1 > -20 && dec1 < -10)
                southstar.Text = "Star No = 155" + Environment.NewLine + "Magnitude = 3.7" + Environment.NewLine + "Name = ζ Leporis";
            else
            if (ra1 > 5 && ra1 < 6 && dec1 > -15 && dec1 < -5)
                southstar.Text = "Star No = 156" + Environment.NewLine + "Magnitude = 2.2" + Environment.NewLine + "Name = Κ Orionis";
            else
            if (ra1 > 5 && ra1 < 6 && dec1 > -55 && dec1 < -45)
                southstar.Text = "Star No = 157" + Environment.NewLine + "Magnitude = 3.9" + Environment.NewLine + "Name = β Pictoris";
            else
            if (ra1 > 5 && ra1 < 6 && dec1 > -60 && dec1 < -50)
                southstar.Text = "Star No = 158" + Environment.NewLine + "Magnitude = 4.4" + Environment.NewLine + "Name = γ Pictoris";
            else
            if (ra1 > 5 && ra1 < 6 && dec1 > 35 && dec1 < 45)
                northstar.Text = "Star No = 159" + Environment.NewLine + "Magnitude = 4.2" + Environment.NewLine + "Name = ν Aurigae";
            else
            if (ra1 > 5 && ra1 < 6 && dec1 > -40 && dec1 < -30)
                southstar.Text = "Star No = 160" + Environment.NewLine + "Magnitude = 3.2" + Environment.NewLine + "Name = β Columbae";
            else
            if (ra1 > 5 && ra1 < 6 && dec1 > -25 && dec1 < -15)
                southstar.Text = "Star No = 161" + Environment.NewLine + "Magnitude = 3.9" + Environment.NewLine + "Name = δ Leporis";
            else
            if (ra1 > 5 && ra1 < 6 && dec1 > 5 && dec1 < 15)
                northstar.Text = "Star No = 162" + Environment.NewLine + "Magnitude = d 0-1" + Environment.NewLine + "Name = Betelgeuse (α Ori)";
            else
            if (ra1 > 5 && ra1 < 6 && dec1 > -20 && dec1 < -10)
                southstar.Text = "Star No = 163" + Environment.NewLine + "Magnitude = 3.3" + Environment.NewLine + "Name = η Leporis";
            else
            if (ra1 > 5 && ra1 < 6 && dec1 > -40 && dec1 < -30)
                southstar.Text = "Star No = 164" + Environment.NewLine + "Magnitude = 4.4" + Environment.NewLine + "Name = γ Columbae";
            else
            if (ra1 > 5 && ra1 < 6 && dec1 > 50 && dec1 < 60)
                northstar.Text = "Star No = 165" + Environment.NewLine + "Magnitude = 3.9" + Environment.NewLine + "Name = δ Aurigae";
            else
            if (ra1 > 5 && ra1 < 6 && dec1 > 40 && dec1 < 50)
                northstar.Text = "Star No = 166" + Environment.NewLine + "Magnitude = 2.1" + Environment.NewLine + "Name = β Aurigae";
            else
            if (ra1 > 5 && ra1 < 6 && dec1 > 35 && dec1 < 45)
                northstar.Text = "Star No = 167" + Environment.NewLine + "Magnitude = 2.7" + Environment.NewLine + "Name = θ Aurigae";
            else
            if (ra1 > 5 && ra1 < 6 && dec1 > -50 && dec1 < -40)
                southstar.Text = "Star No = 168" + Environment.NewLine + "Magnitude = 4.0" + Environment.NewLine + "Name = η Columbae";
            else
            if (ra1 > 5 && ra1 < 6 && dec1 > 20 && dec1 < 30)
                northstar.Text = "Star No = 169" + Environment.NewLine + "Magnitude = 4.3" + Environment.NewLine + "Name = ι Germinorum";
            else
            if (ra1 > 5 && ra1 < 6 && dec1 > 10 && dec1 < 20)
                northstar.Text = "Star No = 170" + Environment.NewLine + "Magnitude = 4.4" + Environment.NewLine + "Name = ν Orionis";
            else
            if (ra1 > 5 && ra1 < 6 && dec1 > 20 && dec1 < 30)
                northstar.Text = "Star No = 171" + Environment.NewLine + "Magnitude = 3-4" + Environment.NewLine + "Name = η Germinorum";
            else
            if (ra1 > 5 && ra1 < 6 && dec1 > 25 && dec1 < 35)
                northstar.Text = "Star No = 172" + Environment.NewLine + "Magnitude = 4.4" + Environment.NewLine + "Name = Κ Aurigae";
            else
            if (ra1 > 5 && ra1 < 6 && dec1 > 55 && dec1 < 65)
                northstar.Text = "Star No = 173" + Environment.NewLine + "Magnitude = 4.4" + Environment.NewLine + "Name = 2 Lyncis";
            else
            if (ra1 > 5 && ra1 < 6 && dec1 > -35 && dec1 < -25)
                southstar.Text = "Star No = 174" + Environment.NewLine + "Magnitude = 3.1" + Environment.NewLine + "Name = ζ Canis Majoris";
            else
            if (ra1 > 5 && ra1 < 6 && dec1 > -40 && dec1 < -30)
                southstar.Text = "Star No = 175" + Environment.NewLine + "Magnitude = 4.0" + Environment.NewLine + "Name = δ Columbae";
            else
            if (ra1 > 6 && ra1 < 7 && dec1 > 20 && dec1 < 30)
                northstar.Text = "Star No = 176" + Environment.NewLine + "Magnitude = 3.2" + Environment.NewLine + "Name = μ Germinorum";
            else
            if (ra1 > 6 && ra1 < 7 && dec1 > -25 && dec1 < -15)
                southstar.Text = "Star No = 177" + Environment.NewLine + "Magnitude = 2.0" + Environment.NewLine + "Name = β Canis Majoris";
            else
            if (ra1 > 6 && ra1 < 7 && dec1 > 0 && dec1 < 10)
                northstar.Text = "Star No = 178" + Environment.NewLine + "Magnitude = 4.5" + Environment.NewLine + "Name = ε Monocerotis";
            else
            if (ra1 > 6 && ra1 < 7 && dec1 > -60 && dec1 < -50)
                southstar.Text = "Star No = 179" + Environment.NewLine + "Magnitude = d-0.9" + Environment.NewLine + "Name = Canopus (α Car)";
            else
            if (ra1 > 6 && ra1 < 7 && dec1 > 15 && dec1 < 25)
                northstar.Text = "Star No = 180" + Environment.NewLine + "Magnitude = 4.1" + Environment.NewLine + "Name = ν Germinorum";
            else
            if (ra1 > 6 && ra1 < 7 && dec1 > 10 && dec1 < 20)
                northstar.Text = "Star No = 181" + Environment.NewLine + "Magnitude = 1.9" + Environment.NewLine + "Name = γ Germinorum";
            else
            if (ra1 > 6 && ra1 < 7 && dec1 > -50 && dec1 < -40)
                southstar.Text = "Star No = 182" + Environment.NewLine + "Magnitude = 3.2" + Environment.NewLine + "Name = ν Puppis";
            else
            if (ra1 > 6 && ra1 < 7 && dec1 > 20 && dec1 < 30)
                northstar.Text = "Star No = 183" + Environment.NewLine + "Magnitude = 3.2" + Environment.NewLine + "Name = ε Germinorum";
            else
            if (ra1 > 6 && ra1 < 7 && dec1 > 10 && dec1 < 20)
                northstar.Text = "Star No = 184" + Environment.NewLine + "Magnitude = 3.4" + Environment.NewLine + "Name = ξ Germinorum";
            else
            if (ra1 > 6 && ra1 < 7 && dec1 > -20 && dec1 < -10)
                southstar.Text = "Star No = 185" + Environment.NewLine + "Magnitude = d-1.6" + Environment.NewLine + "Name = Sirius (α CMa)";
            else
            if (ra1 > 6 && ra1 < 7 && dec1 > -65 && dec1 < -55)
                southstar.Text = "Star No = 186" + Environment.NewLine + "Magnitude = 3.3" + Environment.NewLine + "Name = α Pictoris";
            else
            if (ra1 > 6 && ra1 < 7 && dec1 > -40 && dec1 < -30)
                southstar.Text = "Star No = 187" + Environment.NewLine + "Magnitude = 3.8" + Environment.NewLine + "Name = Κ Canis Majoris";
            else
            if (ra1 > 6 && ra1 < 7 && dec1 > -55 && dec1 < -45)
                southstar.Text = "Star No = 188" + Environment.NewLine + "Magnitude = 2.8" + Environment.NewLine + "Name = τ Puppis";
            else
            if (ra1 > 6 && ra1 < 7 && dec1 > 30 && dec1 < 40)
                northstar.Text = "Star No = 189" + Environment.NewLine + "Magnitude = 3.6" + Environment.NewLine + "Name = θ Germinorum";
            else
            if (ra1 > 6 && ra1 < 7 && dec1 > -20 && dec1 < -10)
                southstar.Text = "Star No = 190" + Environment.NewLine + "Magnitude = 4.2" + Environment.NewLine + "Name = θ Canis Majoris";
            else
            if (ra1 > 6 && ra1 < 7 && dec1 > -30 && dec1 < -20)
                southstar.Text = "Star No = 191" + Environment.NewLine + "Magnitude = 1.6" + Environment.NewLine + "Name = ε   Canis Majoris";
            else
            if (ra1 > 6 && ra1 < 7 && dec1 > -30 && dec1 < -20)
                southstar.Text = "Star No = 192" + Environment.NewLine + "Magnitude = 3.7" + Environment.NewLine + "Name = σ Canis Majoris";
            else
            if (ra1 > 6 && ra1 < 7 && dec1 > -30 && dec1 < -20)
                southstar.Text = "Star No = 193" + Environment.NewLine + "Magnitude = 3.1" + Environment.NewLine + "Name = σ^2 Canis Majoris";
            else
            if (ra1 > 6 && ra1 < 7 && dec1 > 15 && dec1 < 25)
                northstar.Text = "Star No = 194" + Environment.NewLine + "Magnitude = 3.9" + Environment.NewLine + "Name = ζ Germinorum";
            else
            if (ra1 > 6 && ra1 < 7 && dec1 > -20 && dec1 < -10)
                southstar.Text = "Star No = 195" + Environment.NewLine + "Magnitude = 4.1" + Environment.NewLine + "Name = γ Canis Majoris";
            else
            if (ra1 > 7 && ra1 < 8 && dec1 > -30 && dec1 < -20)
                southstar.Text = "Star No = 196" + Environment.NewLine + "Magnitude = 2.0" + Environment.NewLine + "Name = δ Canis Majoris";
            else
            if (ra1 > 7 && ra1 < 8 && dec1 > -75 && dec1 < -65)
                southstar.Text = "Star No = 197" + Environment.NewLine + "Magnitude = 3.9" + Environment.NewLine + "Name = γ^2 Volantis";
            else
            if (ra1 > 7 && ra1 < 8 && dec1 > -10 && dec1 < 5)
                southstar.Text = "Star No = 198" + Environment.NewLine + "Magnitude = 4.1" + Environment.NewLine + "Name = δ Monocerotis";
            else
            if (ra1 > 7 && ra1 < 8 && dec1 > -50 && dec1 < -40)
                southstar.Text = "Star No = 199" + Environment.NewLine + "Magnitude = 4.5" + Environment.NewLine + "Name = Ι Puppis";
            else
            if (ra1 > 7 && ra1 < 8 && dec1 > -30 && dec1 < -20)
                southstar.Text = "Star No = 200" + Environment.NewLine + "Magnitude = 3.8" + Environment.NewLine + "Name = ω Canis Majoris";
            else
            if (ra1 > 7 && ra1 < 8 && dec1 > -40 && dec1 < -30)
                southstar.Text = "Star No = 201" + Environment.NewLine + "Magnitude = 2.7" + Environment.NewLine + "Name = π Puppis";
            else
            if (ra1 > 7 && ra1 < 8 && dec1 > 10 && dec1 < 20)
                northstar.Text = "Star No = 202" + Environment.NewLine + "Magnitude = 3.6" + Environment.NewLine + "Name = λ Germinorum";
            else
            if (ra1 > 7 && ra1 < 8 && dec1 > -70 && dec1 < -60)
                southstar.Text = "Star No = 203" + Environment.NewLine + "Magnitude = 4.0" + Environment.NewLine + "Name = δ Volantis";
            else
            if (ra1 > 7 && ra1 < 8 && dec1 > 15 && dec1 < 25)
                northstar.Text = "Star No = 204" + Environment.NewLine + "Magnitude = 3.5" + Environment.NewLine + "Name = δ Germinorum";
            else
            if (ra1 > 7 && ra1 < 8 && dec1 > -35 && dec1 < -25)
                southstar.Text = "Star No = 205" + Environment.NewLine + "Magnitude = 2.4" + Environment.NewLine + "Name = η Canis Majoris";
            else
            if (ra1 > 7 && ra1 < 8 && dec1 > 20 && dec1 < 30)
                northstar.Text = "Star No = 206" + Environment.NewLine + "Magnitude = 3.9" + Environment.NewLine + "Name = ι Germinorum";
            else
            if (ra1 > 7 && ra1 < 8 && dec1 > 5 && dec1 < 15)
                northstar.Text = "Star No = 207" + Environment.NewLine + "Magnitude = 3.1" + Environment.NewLine + "Name = β Canis Minoris";
            else
            if (ra1 > 7 && ra1 < 8 && dec1 > 25 && dec1 < 35)
                northstar.Text = "Star No = 208" + Environment.NewLine + "Magnitude = 4.2" + Environment.NewLine + "Name = ρ Germinorum";
            else
            if (ra1 > 7 && ra1 < 8 && dec1 > -50 && dec1 < -40)
                southstar.Text = "Star No = 209" + Environment.NewLine + "Magnitude = 3.3" + Environment.NewLine + "Name = σ Puppis";
            else
            if (ra1 > 7 && ra1 < 8 && dec1 > 25 && dec1 < 35)
                northstar.Text = "Star No = 210" + Environment.NewLine + "Magnitude = 1.6" + Environment.NewLine + "Name = Castor (α Gem)";
            else
            if (ra1 > 7 && ra1 < 8 && dec1 > 20 && dec1 < 30)
                northstar.Text = "Star No = 211" + Environment.NewLine + "Magnitude = 4.2" + Environment.NewLine + "Name = υ Germinorum";
            else
            if (ra1 > 7 && ra1 < 8 && dec1 > 0 && dec1 < 10)
                northstar.Text = "Star No = 212" + Environment.NewLine + "Magnitude = d 0.5" + Environment.NewLine + "Name = Procyon (α CMi)";
            else
            if (ra1 > 7 && ra1 < 8 && dec1 > -15 && dec1 < -5)
                southstar.Text = "Star No = 213" + Environment.NewLine + "Magnitude = 4.1" + Environment.NewLine + "Name = α Monocerotis";
            else
            if (ra1 > 7 && ra1 < 8 && dec1 > -75 && dec1 < -65)
                southstar.Text = "Star No = 214" + Environment.NewLine + "Magnitude = 3.9" + Environment.NewLine + "Name = ζ Volantis";
            else
            if (ra1 > 7 && ra1 < 8 && dec1 > 20 && dec1 < 30)
                northstar.Text = "Star No = 215" + Environment.NewLine + "Magnitude = 3.7" + Environment.NewLine + "Name = Κ Germinorum";
            else
            if (ra1 > 7 && ra1 < 8 && dec1 > 25 && dec1 < 35)
                northstar.Text = "Star No = 216" + Environment.NewLine + "Magnitude = d 1.2" + Environment.NewLine + "Name = Pollux (β Gem)";
            else
            if (ra1 > 7 && ra1 < 8 && dec1 > -45 && dec1 < -35)
                southstar.Text = "Star No = 217" + Environment.NewLine + "Magnitude = 3.7" + Environment.NewLine + "Name = ϲ Puppis";
            else
            if (ra1 > 7 && ra1 < 8 && dec1 > -30 && dec1 < -20)
                southstar.Text = "Star No = 218" + Environment.NewLine + "Magnitude = 3.5" + Environment.NewLine + "Name = ξ Puppis";
            else
            if (ra1 > 7 && ra1 < 8 && dec1 > -45 && dec1 < -35)
                southstar.Text = "Star No = 219" + Environment.NewLine + "Magnitude = 3.8" + Environment.NewLine + "Name = BS 3080 (Puppis)";
            else
            if (ra1 > 7 && ra1 < 8 && dec1 > -60 && dec1 < -50)
                southstar.Text = "Star No = 220" + Environment.NewLine + "Magnitude = 3.6" + Environment.NewLine + "Name = χ Carinae";
            else
            if (ra1 > 7 && ra1 < 8 && dec1 > -45 && dec1 < -35)
                southstar.Text = "Star No = 221" + Environment.NewLine + "Magnitude = 2.3" + Environment.NewLine + "Name = ζ Puppis";
            else
            if (ra1 > 8 && ra1 < 9 && dec1 > -30 && dec1 < -20)
                southstar.Text = "Star No = 222" + Environment.NewLine + "Magnitude = 2.9" + Environment.NewLine + "Name = ρ PUppis";
            else
            if (ra1 > 8 && ra1 < 9 && dec1 > -50 && dec1 < -40)
                southstar.Text = "Star No = 223" + Environment.NewLine + "Magnitude = 1.9" + Environment.NewLine + "Name = γ^2 Velorum";
            else
            if (ra1 > 8 && ra1 < 9 && dec1 > 5 && dec1 < 15)
                northstar.Text = "Star No = 224" + Environment.NewLine + "Magnitude = 3.8" + Environment.NewLine + "Name = β Cancri";
            else
            if (ra1 > 8 && ra1 < 9 && dec1 > -40 && dec1 < -30)
                southstar.Text = "Star No = 225" + Environment.NewLine + "Magnitude = 4.4" + Environment.NewLine + "Name = BS 3270 (Puppis)";
            else
            if (ra1 > 8 && ra1 < 9 && dec1 > 40 && dec1 < 50)
                northstar.Text = "Star No = 226" + Environment.NewLine + "Magnitude = 4.4" + Environment.NewLine + "Name = 31 Lyncis";
            else
            if (ra1 > 8 && ra1 < 9 && dec1 > -80 && dec1 < -70)
                southstar.Text = "Star No = 227" + Environment.NewLine + "Magnitude = 4.3" + Environment.NewLine + "Name = θ Chamaeleontis";
            else
            if (ra1 > 8 && ra1 < 9 && dec1 > -65 && dec1 < -55)
                southstar.Text = "Star No = 228" + Environment.NewLine + "Magnitude = 1.7" + Environment.NewLine + "Name = ε Carinae";
            else
            if (ra1 > 8 && ra1 < 9 && dec1 > -10 && dec1 < 0)
                southstar.Text = "Star No = 229" + Environment.NewLine + "Magnitude = 3.9" + Environment.NewLine + "Name = BS 3314 (Hydrae)";
            else
            if (ra1 > 8 && ra1 < 9 && dec1 > -70 && dec1 < -60)
                southstar.Text = "Star No = 230" + Environment.NewLine + "Magnitude = 3.6" + Environment.NewLine + "Name = β Volantis";
            else
            if (ra1 > 8 && ra1 < 9 && dec1 > 55 && dec1 < 65)
                northstar.Text = "Star No = 231" + Environment.NewLine + "Magnitude = 3.5" + Environment.NewLine + "Name = ο Ursae Majoris";
            else
            if (ra1 > 8 && ra1 < 9 && dec1 > 0 && dec1 < 10)
                northstar.Text = "Star No = 232" + Environment.NewLine + "Magnitude = 4.2" + Environment.NewLine + "Name = δ Hydrae";
            else
            if (ra1 > 8 && ra1 < 9 && dec1 > -50 && dec1 < -40)
                southstar.Text = "Star No = 233" + Environment.NewLine + "Magnitude = 4.1" + Environment.NewLine + "Name = BS 3426 (Velorum)";
            else
            if (ra1 > 8 && ra1 < 9 && dec1 > -60 && dec1 < -50)
                southstar.Text = "Star No = 234" + Environment.NewLine + "Magnitude = 3.7" + Environment.NewLine + "Name = ο Velorum";
            else
            if (ra1 > 8 && ra1 < 9 && dec1 > -50 && dec1 < -40)
                southstar.Text = "Star No = 235" + Environment.NewLine + "Magnitude = 4.1" + Environment.NewLine + "Name = BS 3445 (Velorum)";
            else
            if (ra1 > 8 && ra1 < 9 && dec1 > -40 && dec1 < -30)
                southstar.Text = "Star No = 236" + Environment.NewLine + "Magnitude = 3.7" + Environment.NewLine + "Name = α Pyxidis";
            else
            if (ra1 > 8 && ra1 < 9 && dec1 > 15 && dec1 < 25)
                northstar.Text = "Star No = 237" + Environment.NewLine + "Magnitude = 4.2" + Environment.NewLine + "Name = δ Cancri";
            else
            if (ra1 > 8 && ra1 < 9 && dec1 > -60 && dec1 < -50)
                southstar.Text = "Star No = 238" + Environment.NewLine + "Magnitude = 2.0" + Environment.NewLine + "Name = δ Velorum";
            else
            if (ra1 > 8 && ra1 < 9 && dec1 > 25 && dec1 < 35)
                northstar.Text = "Star No = 239" + Environment.NewLine + "Magnitude = 4.2" + Environment.NewLine + "Name = ι Cancri";
            else
            if (ra1 > 8 && ra1 < 9 && dec1 > 0 && dec1 < 10)
                northstar.Text = "Star No = 240" + Environment.NewLine + "Magnitude = 3.5" + Environment.NewLine + "Name = ε Hydrae";
            else
            if (ra1 > 8 && ra1 < 9 && dec1 > -30 && dec1 < -20)
                southstar.Text = "Star No = 241" + Environment.NewLine + "Magnitude = 4.2" + Environment.NewLine + "Name = γ Pyxidis";
            else
            if (ra1 > 8 && ra1 < 9 && dec1 > 0 && dec1 < 10)
                northstar.Text = "Star No = 242" + Environment.NewLine + "Magnitude = 3.3" + Environment.NewLine + "Name = ζ Hydrae";
            else
            if (ra1 > 8 && ra1 < 9 && dec1 > -65 && dec1 < -55)
                southstar.Text = "Star No = 243" + Environment.NewLine + "Magnitude = 4.0" + Environment.NewLine + "Name = BS 3571 (Carinae)";
            else
            if (ra1 > 8 && ra1 < 9 && dec1 > 5 && dec1 < 15)
                northstar.Text = "Star No = 244" + Environment.NewLine + "Magnitude = 4.3" + Environment.NewLine + "Name = α Cancri";
            else
            if (ra1 > 8 && ra1 < 9 && dec1 > 40 && dec1 < 50)
                northstar.Text = "Star No = 245" + Environment.NewLine + "Magnitude = 3.1" + Environment.NewLine + "Name = ι Ursae Majoris";
            else
            if (ra1 > 8 && ra1 < 9 && dec1 > 35 && dec1 < 45)
                northstar.Text = "Star No = 246" + Environment.NewLine + "Magnitude = 4.1" + Environment.NewLine + "Name = BS 3579 (Lyncis)";
            else
            if (ra1 > 8 && ra1 < 9 && dec1 > -45 && dec1 < -35)
                southstar.Text = "Star No = 247" + Environment.NewLine + "Magnitude = 4.4" + Environment.NewLine + "Name = BS 3591 (Velorum)";
            else
            if (ra1 > 8 && ra1 < 9 && dec1 > 40 && dec1 < 50)
                northstar.Text = "Star No = 248" + Environment.NewLine + "Magnitude = 3.7" + Environment.NewLine + "Name = Κ Ursae Majoris";
            else
            if (ra1 > 8 && ra1 < 9 && dec1 > -70 && dec1 < -60)
                southstar.Text = "Star No = 249" + Environment.NewLine + "Magnitude = 4.2" + Environment.NewLine + "Name = α Volantis";
            else
            if (ra1 > 8 && ra1 < 9 && dec1 > -50 && dec1 < -40)
                southstar.Text = "Star No = 250" + Environment.NewLine + "Magnitude = 3.7" + Environment.NewLine + "Name = BS 3614 (Velorum)";
            else
            if (ra1 > 9 && ra1 < 10 && dec1 > -50 && dec1 < -40)
                northstar.Text = "Star No = 251" + Environment.NewLine + "Magnitude = 2.2" + Environment.NewLine + "Name = λ Velorum";
            else
            if (ra1 > 9 && ra1 < 10 && dec1 > -65 && dec1 < -55)
                northstar.Text = "Star No = 252" + Environment.NewLine + "Magnitude = 3.6" + Environment.NewLine + "Name = α Carinae";
            else
            if (ra1 > 9 && ra1 < 10 && dec1 > -75 && dec1 < -65)
                northstar.Text = "Star No = 253" + Environment.NewLine + "Magnitude = 1.8" + Environment.NewLine + "Name = β Carinae";
            else
            if (ra1 > 9 && ra1 < 10 && dec1 > 1 && dec1 < 10)
                northstar.Text = "Star No = 254" + Environment.NewLine + "Magnitude = 3.8" + Environment.NewLine + "Name = θ Hydrae";
            else
            if (ra1 > 9 && ra1 < 10 && dec1 > -65 && dec1 < -55)
                northstar.Text = "Star No = 255" + Environment.NewLine + "Magnitude = 2.2" + Environment.NewLine + "Name = ι Carinae";
            else
            if (ra1 > 9 && ra1 < 10 && dec1 > 30 && dec1 < 40)
                northstar.Text = "Star No = 256" + Environment.NewLine + "Magnitude = 3.8" + Environment.NewLine + "Name = 38 Lyncis";
            else
            if (ra1 > 9 && ra1 < 10 && dec1 > 30 && dec1 < 40)
                northstar.Text = "Star No = 257" + Environment.NewLine + "Magnitude = 3.3" + Environment.NewLine + "Name = α Lyncis";
            else
            if (ra1 > 9 && ra1 < 10 && dec1 > -60 && dec1 < -50)
                northstar.Text = "Star No = 258" + Environment.NewLine + "Magnitude = 2.6" + Environment.NewLine + "Name = Κ Velorum";
            else
            if (ra1 > 9 && ra1 < 10 && dec1 > -10 && dec1 < 0)
                northstar.Text = "Star No = 259" + Environment.NewLine + "Magnitude = 2.2" + Environment.NewLine + "Name = α Hydrae";
            else
            if (ra1 > 9 && ra1 < 10 && dec1 > 60 && dec1 < 70)
                northstar.Text = "Star No = 260" + Environment.NewLine + "Magnitude = 3.7" + Environment.NewLine + "Name = 23 Ursae Majoris";
            else
            if (ra1 > 9 && ra1 < 10 && dec1 > -45 && dec1 < -35)
                northstar.Text = "Star No = 261" + Environment.NewLine + "Magnitude = 3.6" + Environment.NewLine + "Name = ϕ Velorum";
            else
            if (ra1 > 9 && ra1 < 10 && dec1 > -60 && dec1 < -50)
                northstar.Text = "Star No = 262" + Environment.NewLine + "Magnitude = 3.0" + Environment.NewLine + "Name = Ν Velorum";
            else
            if (ra1 > 9 && ra1 < 10 && dec1 > 45 && dec1 < 55)
                northstar.Text = "Star No = 263" + Environment.NewLine + "Magnitude = 3.3" + Environment.NewLine + "Name = θ Ursae Majoris";
            else
            if (ra1 > 9 && ra1 < 10 && dec1 > -10 && dec1 < 5)
                northstar.Text = "Star No = 264" + Environment.NewLine + "Magnitude = 4.1" + Environment.NewLine + "Name = ι Hydrae";
            else
            if (ra1 > 9 && ra1 < 10 && dec1 > 5 && dec1 < 15)
                northstar.Text = "Star No = 265" + Environment.NewLine + "Magnitude = 3.8" + Environment.NewLine + "Name = ο Leonis";
            else
            if (ra1 > 9 && ra1 < 10 && dec1 > 20 && dec1 < 30)
                northstar.Text = "Star No = 266" + Environment.NewLine + "Magnitude = 3.1" + Environment.NewLine + "Name = ε Leonis";
            else
            if (ra1 > 9 && ra1 < 10 && dec1 > -70 && dec1 < -60)
                northstar.Text = "Star No = 267" + Environment.NewLine + "Magnitude = 4-5" + Environment.NewLine + "Name = Ι Carinae";
            else
            if (ra1 > 9 && ra1 < 10 && dec1 > -70 && dec1 < -60)
                northstar.Text = "Star No = 268" + Environment.NewLine + "Magnitude = 3.1" + Environment.NewLine + "Name = υ Carinae";
            else
            if (ra1 > 9 && ra1 < 10 && dec1 > 55 && dec1 < 65)
                northstar.Text = "Star No = 269" + Environment.NewLine + "Magnitude = 3.9" + Environment.NewLine + "Name = υ Ursae Majoris";
            else
            if (ra1 > 9 && ra1 < 10 && dec1 > 20 && dec1 < 30)
                northstar.Text = "Star No = 270" + Environment.NewLine + "Magnitude = 4.1" + Environment.NewLine + "Name = μ Leonis";
            else
            if (ra1 > 9 && ra1 < 10 && dec1 > -60 && dec1 < -50)
                northstar.Text = "Star No = 271" + Environment.NewLine + "Magnitude = 3.7" + Environment.NewLine + "Name = φ Velorum";
            else
            if (ra1 > 10 && ra1 < 11 && dec1 > 10 && dec1 < 20)
                northstar.Text = "Star No = 272" + Environment.NewLine + "Magnitude = 3.6" + Environment.NewLine + "Name = η Leonis";
            else
            if (ra1 > 10 && ra1 < 11 && dec1 > 5 && dec1 < 15)
                northstar.Text = "Star No = 273" + Environment.NewLine + "Magnitude = d 1.3" + Environment.NewLine + "Name = Regulus (α Leo)";
            else
            if (ra1 > 10 && ra1 < 11 && dec1 > -15 && dec1 < -5)
                northstar.Text = "Star No = 274" + Environment.NewLine + "Magnitude = 3.8" + Environment.NewLine + "Name = λ Hydrae";
            else
            if (ra1 > 10 && ra1 < 11 && dec1 > -75 && dec1 < -65)
                northstar.Text = "Star No = 275" + Environment.NewLine + "Magnitude = 3.6" + Environment.NewLine + "Name = ω Carinae";
            else
            if (ra1 > 10 && ra1 < 11 && dec1 > -50 && dec1 < -40)
                northstar.Text = "Star No = 276" + Environment.NewLine + "Magnitude = 4.1" + Environment.NewLine + "Name = BS 4023 (Velorum)";
            else
            if (ra1 > 10 && ra1 < 11 && dec1 > 20 && dec1 < 30)
                northstar.Text = "Star No = 277" + Environment.NewLine + "Magnitude = 3.6" + Environment.NewLine + "Name = ζ Leonis";
            else
            if (ra1 > 10 && ra1 < 11 && dec1 > 40 && dec1 < 50)
                northstar.Text = "Star No = 278" + Environment.NewLine + "Magnitude = 3.5" + Environment.NewLine + "Name = λ Ursae Majoris";
            else
            if (ra1 > 10 && ra1 < 11 && dec1 > -65 && dec1 < -55)
                northstar.Text = "Star No = 279" + Environment.NewLine + "Magnitude = 3.4" + Environment.NewLine + "Name = BS 4050 (Carinae)";
            else
            if (ra1 > 10 && ra1 < 11 && dec1 > 15 && dec1 < 25)
                northstar.Text = "Star No = 280" + Environment.NewLine + "Magnitude = 2.6" + Environment.NewLine + "Name = γ^1 Leonis";
            else
            if (ra1 > 10 && ra1 < 11 && dec1 > 35 && dec1 < 45)
                northstar.Text = "Star No = 281" + Environment.NewLine + "Magnitude = 3.2" + Environment.NewLine + "Name = μ Ursae Majoris";
            else
            if (ra1 > 10 && ra1 < 11 && dec1 > -80 && dec1 < -70)
                northstar.Text = "Star No = 282" + Environment.NewLine + "Magnitude = 4.1" + Environment.NewLine + "Name = Ι Carinae";
            else
            if (ra1 > 10 && ra1 < 11 && dec1 > -20 && dec1 < -10)
                northstar.Text = "Star No = 283" + Environment.NewLine + "Magnitude = 4.1" + Environment.NewLine + "Name = μ Hydrae";
            else
            if (ra1 > 10 && ra1 < 11 && dec1 > -35 && dec1 < -25)
                northstar.Text = "Star No = 284" + Environment.NewLine + "Magnitude = 4.4" + Environment.NewLine + "Name = α Antliae";
            else
            if (ra1 > 10 && ra1 < 11 && dec1 > 30 && dec1 < 40)
                northstar.Text = "Star No = 285" + Environment.NewLine + "Magnitude = 4.4" + Environment.NewLine + "Name = β Leonis Minoris";
            else
            if (ra1 > 10 && ra1 < 11 && dec1 > -65 && dec1 < -55)
                northstar.Text = "Star No = 286" + Environment.NewLine + "Magnitude = 4.1" + Environment.NewLine + "Name = BS 4114 (Carinae)";
            else
            if (ra1 > 10 && ra1 < 11 && dec1 > -65 && dec1 < -55)
                northstar.Text = "Star No = 287" + Environment.NewLine + "Magnitude = 3.6" + Environment.NewLine + "Name = BS 4140 (Carinae)";
            else
            if (ra1 > 10 && ra1 < 11 && dec1 > 5 && dec1 < 15)
                northstar.Text = "Star No = 288" + Environment.NewLine + "Magnitude = 3.8" + Environment.NewLine + "Name = ρ Leonis";
            else
            if (ra1 > 10 && ra1 < 11 && dec1 > -85 && dec1 < -75)
                northstar.Text = "Star No = 289" + Environment.NewLine + "Magnitude = 4.1" + Environment.NewLine + "Name = γ Chamaeleontis";
            else
            if (ra1 > 10 && ra1 < 11 && dec1 > -60 && dec1 < -50)
                southstar.Text = "Star No = 290" + Environment.NewLine + "Magnitude = 4.4" + Environment.NewLine + "Name = BS 4180 (Velorum)";
            else
            if (ra1 > 10 && ra1 < 11 && dec1 > -70 && dec1 < -60)
                southstar.Text = "Star No = 291" + Environment.NewLine + "Magnitude = 3.0" + Environment.NewLine + "Name = θ Carinae";
            else
            if (ra1 > 10 && ra1 < 11 && dec1 > -55 && dec1 < -45)
                southstar.Text = "Star No = 292" + Environment.NewLine + "Magnitude = 2.8" + Environment.NewLine + "Name = μ Velorum";
            else
            if (ra1 > 10 && ra1 < 11 && dec1 > -20 && dec1 < -10)
                southstar.Text = "Star No = 293" + Environment.NewLine + "Magnitude = 3.3" + Environment.NewLine + "Name = ν Hydrae";
            else
            if (ra1 > 10 && ra1 < 11 && dec1 > 30 && dec1 < 40)
                northstar.Text = "Star No = 294" + Environment.NewLine + "Magnitude = 3.9" + Environment.NewLine + "Name = 46 Leonis Minoris";
            else
            if (ra1 > 10 && ra1 < 11 && dec1 > -65 && dec1 < -55)
                southstar.Text = "Star No = 295" + Environment.NewLine + "Magnitude = 3.9" + Environment.NewLine + "Name = υ Carinae";
            else
            if (ra1 > 10 && ra1 < 11 && dec1 > -25 && dec1 < -15)
                southstar.Text = "Star No = 296" + Environment.NewLine + "Magnitude = 4.2" + Environment.NewLine + "Name = α Crateris";
            else
            if (ra1 > 10 && ra1 < 11 && dec1 > 50 && dec1 < 60)
                northstar.Text = "Star No = 297" + Environment.NewLine + "Magnitude = 2.4" + Environment.NewLine + "Name = β Ursae Majoris";
            else
            if (ra1 > 10 && ra1 < 11 && dec1 > 55 && dec1 < 65)
                northstar.Text = "Star No = 298" + Environment.NewLine + "Magnitude = 1.9" + Environment.NewLine + "Name = Dubhe (α UMa)";
            else
            if (ra1 > 11 && ra1 < 12 && dec1 > -65 && dec1 < -55)
                southstar.Text = "Star No = 299" + Environment.NewLine + "Magnitude = 4.0" + Environment.NewLine + "Name = BS 4337 (Carinae)";
            else
            if (ra1 > 11 && ra1 < 12 && dec1 > 40 && dec1 < 50)
                northstar.Text = "Star No = 300" + Environment.NewLine + "Magnitude = 3.1" + Environment.NewLine + "Name = ϕ Ursae Majoris";
            else
            if (ra1 > 11 && ra1 < 12 && dec1 > 15 && dec1 < 25)
                northstar.Text = "Star No = 301" + Environment.NewLine + "Magnitude = 2.6" + Environment.NewLine + "Name = δ Leonis";
            else
            if (ra1 > 11 && ra1 < 12 && dec1 > 10 && dec1 < 20)
                northstar.Text = "Star No = 302" + Environment.NewLine + "Magnitude = 3.4" + Environment.NewLine + "Name = θ Leonis";
            else
            if (ra1 > 11 && ra1 < 12 && dec1 > 25 && dec1 < 35)
                northstar.Text = "Star No = 303" + Environment.NewLine + "Magnitude = 3.9" + Environment.NewLine + "Name = ξ Ursae Majoris";
            else
            if (ra1 > 11 && ra1 < 12 && dec1 > 25 && dec1 < 35)
                northstar.Text = "Star No = 304" + Environment.NewLine + "Magnitude = 3.7" + Environment.NewLine + "Name =  ν Ursae Majoris";
            else
            if (ra1 > 11 && ra1 < 12 && dec1 > -20 && dec1 < -10)
                northstar.Text = "Star No = 305" + Environment.NewLine + "Magnitude = 3.8" + Environment.NewLine + "Name = δ Crateris";
            else
            if (ra1 > 11 && ra1 < 12 && dec1 > 0 && dec1 < 10)
                northstar.Text = "Star No = 306" + Environment.NewLine + "Magnitude = 4.1" + Environment.NewLine + "Name = σ Leonis";
            else
            if (ra1 > 11 && ra1 < 12 && dec1 > -50 && dec1 < -40)
                northstar.Text = "Star No = 307" + Environment.NewLine + "Magnitude = 4.3" + Environment.NewLine + "Name = π Centauri";
            else
            if (ra1 > 11 && ra1 < 12 && dec1 > -25 && dec1 < -15)
                northstar.Text = "Star No = 308" + Environment.NewLine + "Magnitude = 4.1" + Environment.NewLine + "Name = γ Crateris";
            else
            if (ra1 > 11 && ra1 < 12 && dec1 > 65 && dec1 < 75)
                northstar.Text = "Star No = 309" + Environment.NewLine + "Magnitude = 4.1" + Environment.NewLine + "Name = λ Draconis";
            else
            if (ra1 > 11 && ra1 < 12 && dec1 > -35 && dec1 < -25)
                northstar.Text = "Star No = 310" + Environment.NewLine + "Magnitude = 3.7" + Environment.NewLine + "Name = ξ Hydrae";
            else
            if (ra1 > 11 && ra1 < 12 && dec1 > -70 && dec1 < -60)
                northstar.Text = "Star No = 311" + Environment.NewLine + "Magnitude = 3.3" + Environment.NewLine + "Name = λ Centauri";
            else
            if (ra1 > 11 && ra1 < 12 && dec1 > -70 && dec1 < -60)
                northstar.Text = "Star No = 312" + Environment.NewLine + "Magnitude = 3.8" + Environment.NewLine + "Name = λ Muscae";
            else
            if (ra1 > 11 && ra1 < 12 && dec1 > 0 && dec1 < 10)
                northstar.Text = "Star No = 313" + Environment.NewLine + "Magnitude = 4.2" + Environment.NewLine + "Name = ν Virginis";
            else
            if (ra1 > 11 && ra1 < 12 && dec1 > 45 && dec1 < 55)
                northstar.Text = "Star No = 314" + Environment.NewLine + "Magnitude = 3.8" + Environment.NewLine + "Name = ϰ Ursae Majoris";
            else
            if (ra1 > 11 && ra1 < 12 && dec1 > -65 && dec1 < -55)
                northstar.Text = "Star No = 315" + Environment.NewLine + "Magnitude = 4.2" + Environment.NewLine + "Name = BS 4522 (Centauri)";
            else
            if (ra1 > 11 && ra1 < 12 && dec1 > 10 && dec1 < 20)
                northstar.Text = "Star No = 316" + Environment.NewLine + "Magnitude = 2.2" + Environment.NewLine + "Name = Denebola (β Leo)";
            else
            if (ra1 > 11 && ra1 < 12 && dec1 > 0 && dec1 < 10)
                northstar.Text = "Star No = 317" + Environment.NewLine + "Magnitude = 3.8" + Environment.NewLine + "Name = β Virginis";
            else
            if (ra1 > 11 && ra1 < 12 && dec1 > 50 && dec1 < 60)
                northstar.Text = "Star No = 318" + Environment.NewLine + "Magnitude = 2.5" + Environment.NewLine + "Name =  γ Ursae Majoris";
            else
            if (ra1 > 12 && ra1 < 13 && dec1 > 5 && dec1 < 15)
                northstar.Text = "Star No = 319" + Environment.NewLine + "Magnitude = 4.2" + Environment.NewLine + "Name = σ Virginis";
            else
            if (ra1 > 12 && ra1 < 13 && dec1 > -55 && dec1 < -45)
                northstar.Text = "Star No = 320" + Environment.NewLine + "Magnitude = 2.9" + Environment.NewLine + "Name = δ Centauri";
            else
            if (ra1 > 12 && ra1 < 13 && dec1 > -30 && dec1 < -20)
                northstar.Text = "Star No = 321" + Environment.NewLine + "Magnitude = 3.2" + Environment.NewLine + "Name = ε Corvi";
            else
            if (ra1 > 12 && ra1 < 13 && dec1 > -65 && dec1 < -55)
                northstar.Text = "Star No = 322" + Environment.NewLine + "Magnitude = 3.1" + Environment.NewLine + "Name = δ Crucis";
            else
            if (ra1 > 12 && ra1 < 13 && dec1 > 50 && dec1 < 60)
                northstar.Text = "Star No = 323" + Environment.NewLine + "Magnitude = 3.4" + Environment.NewLine + "Name = δ Ursae Majoris";
            else
            if (ra1 > 12 && ra1 < 13 && dec1 > -25 && dec1 < -15)
                northstar.Text = "Star No = 324" + Environment.NewLine + "Magnitude = 2.8" + Environment.NewLine + "Name = γ Corvi";
            else
            if (ra1 > 12 && ra1 < 13 && dec1 > -85 && dec1 < -75)
                northstar.Text = "Star No = 325" + Environment.NewLine + "Magnitude = 4.4" + Environment.NewLine + "Name = β Chamaeleontis";
            else
            if (ra1 > 12 && ra1 < 13 && dec1 > -5 && dec1 < 5)
                northstar.Text = "Star No = 326" + Environment.NewLine + "Magnitude = 4.0" + Environment.NewLine + "Name = η Virginis";
            else
            if (ra1 > 12 && ra1 < 13 && dec1 > -65 && dec1 < -55)
                northstar.Text = "Star No = 327" + Environment.NewLine + "Magnitude = 3.6" + Environment.NewLine + "Name = ε Crucis";
            else
            if (ra1 > 12 && ra1 < 13 && dec1 > -70 && dec1 < -60)
                northstar.Text = "Star No = 328" + Environment.NewLine + "Magnitude = 1.6" + Environment.NewLine + "Name = α Crucis";
            else
            if (ra1 > 12 && ra1 < 13 && dec1 > -55 && dec1 < -45)
                northstar.Text = "Star No = 329" + Environment.NewLine + "Magnitude = 4.2" + Environment.NewLine + "Name = σ Centauri";
            else
            if (ra1 > 12 && ra1 < 13 && dec1 > -20 && dec1 < -10)
                northstar.Text = "Star No = 330" + Environment.NewLine + "Magnitude = 3.1" + Environment.NewLine + "Name = δ Corvi";
            else
            if (ra1 > 12 && ra1 < 13 && dec1 > -65 && dec1 < -55)
                northstar.Text = "Star No = 331" + Environment.NewLine + "Magnitude = 1.6" + Environment.NewLine + "Name = γ Crucis";
            else
            if (ra1 > 12 && ra1 < 13 && dec1 > -75 && dec1 < -65)
                northstar.Text = "Star No = 332" + Environment.NewLine + "Magnitude = 4.0" + Environment.NewLine + "Name = γ Muscae";
            else
            if (ra1 > 12 && ra1 < 13 && dec1 > 65 && dec1 < 75)
                northstar.Text = "Star No = 333" + Environment.NewLine + "Magnitude = 3.9" + Environment.NewLine + "Name = Κ Draconis";
            else
            if (ra1 > 12 && ra1 < 13 && dec1 > 35 && dec1 < 45)
                northstar.Text = "Star No = 334" + Environment.NewLine + "Magnitude = 4.3" + Environment.NewLine + "Name = β Canum Venat";
            else
            if (ra1 > 12 && ra1 < 13 && dec1 > -30 && dec1 < -20)
                northstar.Text = "Star No = 335" + Environment.NewLine + "Magnitude = 2.8" + Environment.NewLine + "Name = β Corvi";
            else
            if (ra1 > 12 && ra1 < 13 && dec1 > -75 && dec1 < -65)
                northstar.Text = "Star No = 336" + Environment.NewLine + "Magnitude = 2.9" + Environment.NewLine + "Name = α Muscae";
            else
            if (ra1 > 12 && ra1 < 13 && dec1 > -55 && dec1 < -45)
                northstar.Text = "Star No = 337" + Environment.NewLine + "Magnitude = 2.4" + Environment.NewLine + "Name = γ Centauri";
            else
            if (ra1 > 12 && ra1 < 13 && dec1 > -10 && dec1 < 5)
                northstar.Text = "Star No = 338" + Environment.NewLine + "Magnitude = 2.9" + Environment.NewLine + "Name = γ Virginis";
            else
            if (ra1 > 12 && ra1 < 13 && dec1 > -75 && dec1 < -65)
                northstar.Text = "Star No = 339" + Environment.NewLine + "Magnitude = 3.3" + Environment.NewLine + "Name = β Muscae";
            else
            if (ra1 > 12 && ra1 < 13 && dec1 > -65 && dec1 < -55)
                northstar.Text = "Star No = 340" + Environment.NewLine + "Magnitude = 1.5" + Environment.NewLine + "Name = β Crucis";
            else
            if (ra1 > 12 && ra1 < 13.0 && dec1 > -45 && dec1 < -35)
                northstar.Text = "Star No = 341" + Environment.NewLine + "Magnitude = 4.3" + Environment.NewLine + "Name = BS 4889 (Centauri)";
            else
            if (ra1 > 12 && ra1 < 13.0 && dec1 > 50 && dec1 < 60)
                northstar.Text = "Star No = 342" + Environment.NewLine + "Magnitude = 1.7" + Environment.NewLine + "Name = ε Ursae Majoris";
            else
            if (ra1 > 12 && ra1 < 13.0 && dec1 > 0 && dec1 < 10)
                northstar.Text = "Star No = 343" + Environment.NewLine + "Magnitude = 3.7" + Environment.NewLine + "Name = δ Virginis";
            else
            if (ra1 > 12 && ra1 < 13.0 && dec1 > 35 && dec1 < 45)
                northstar.Text = "Star No = 344" + Environment.NewLine + "Magnitude = 2.9" + Environment.NewLine + "Name = α Canum Venat";
            else
            if (ra1 > 12 && ra1 < 13 && dec1 > -75 && dec1 < -65)
                northstar.Text = "Star No = 345" + Environment.NewLine + "Magnitude = 3.6" + Environment.NewLine + "Name = δ Muscae";
            else
            if (ra1 > 12 && ra1 < 13 && dec1 > 5 && dec1 < 15)
                northstar.Text = "Star No = 346" + Environment.NewLine + "Magnitude = 2.9" + Environment.NewLine + "Name = ε Virginis";
            else
            if (ra1 > 13 && ra1 < 14 && dec1 > -55 && dec1 < -45)
                northstar.Text = "Star No = 347" + Environment.NewLine + "Magnitude = 4.4" + Environment.NewLine + "Name = ξ^2 Centauri";
            else
            if (ra1 > 13 && ra1 < 14 && dec1 > -10 && dec1 < 0)
                northstar.Text = "Star No = 348" + Environment.NewLine + "Magnitude = 4.5" + Environment.NewLine + "Name = ϑ Virginis";
            else
            if (ra1 > 13 && ra1 < 14 && dec1 > 25 && dec1 < 35)
                northstar.Text = "Star No = 349" + Environment.NewLine + "Magnitude = 4.3" + Environment.NewLine + "Name = β Comae Ber";
            else
            if (ra1 > 13 && ra1 < 14 && dec1 > -30 && dec1 < -20)
                northstar.Text = "Star No = 350" + Environment.NewLine + "Magnitude = 3.3" + Environment.NewLine + "Name = γ Hydrae";
            else
            if (ra1 > 13 && ra1 < 14 && dec1 > -40 && dec1 < -30)
                northstar.Text = "Star No = 351" + Environment.NewLine + "Magnitude = 2.9" + Environment.NewLine + "Name = τ Centauri";
            else
            if (ra1 > 13 && ra1 < 14 && dec1 > 50 && dec1 < 60)
                northstar.Text = "Star No = 352" + Environment.NewLine + "Magnitude = 2.4" + Environment.NewLine + "Name = ζ Ursae Majoris";
            else
            if (ra1 > 13 && ra1 < 14 && dec1 > -15 && dec1 < -5)
                northstar.Text = "Star No = 353" + Environment.NewLine + "Magnitude = 1.2" + Environment.NewLine + "Name = Spica (α Vir)";
            else
            if (ra1 > 13 && ra1 < 14 && dec1 > -45 && dec1 < -35)
                northstar.Text = "Star No = 354" + Environment.NewLine + "Magnitude = 4.0" + Environment.NewLine + "Name = d Centauri";
            else
            if (ra1 > 13 && ra1 < 14 && dec1 > -5 && dec1 < 5)
                northstar.Text = "Star No = 355" + Environment.NewLine + "Magnitude = 3.4" + Environment.NewLine + "Name = ζ Virginis";
            else
            if (ra1 > 13 && ra1 < 14 && dec1 > -60 && dec1 < -50)
                northstar.Text = "Star No = 356" + Environment.NewLine + "Magnitude = 2.6" + Environment.NewLine + "Name = ε Centauri";
            else
            if (ra1 > 13 && ra1 < 14 && dec1 > -40 && dec1 < -30)
                northstar.Text = "Star No = 357" + Environment.NewLine + "Magnitude = 4.4" + Environment.NewLine + "Name = Ι Centauri";
            else
            if (ra1 > 13 && ra1 < 14 && dec1 > 45 && dec1 < 55)
                northstar.Text = "Star No = 358" + Environment.NewLine + "Magnitude = 1.9" + Environment.NewLine + "Name = η Ursae Majoris";
            else
            if (ra1 > 13 && ra1 < 14 && dec1 > -45 && dec1 < -35)
                northstar.Text = "Star No = 359" + Environment.NewLine + "Magnitude = 3.5" + Environment.NewLine + "Name = ν Centauri";
            else
            if (ra1 > 13 && ra < 14 && dec1 > -45 && dec1 < -35)
                northstar.Text = "Star No = 360" + Environment.NewLine + "Magnitude = 3.3" + Environment.NewLine + "Name = μ Centauri";
            else
            if (ra1 > 13 && ra < 14.0 && dec1 > 15 && dec1 < 25)
                northstar.Text = "Star No = 361" + Environment.NewLine + "Magnitude = 2.8" + Environment.NewLine + "Name = η Bootis";
            else
            if (ra1 > 13 && ra < 14.0 && dec1 > -55 && dec1 < -45)
                northstar.Text = "Star No = 362" + Environment.NewLine + "Magnitude = 3.1" + Environment.NewLine + "Name = ζ Centauri";
            else
            if (ra1 > 13 && ra < 14 && dec1 > 0 && dec1 < 10)
                northstar.Text = "Star No = 363" + Environment.NewLine + "Magnitude = 4.3" + Environment.NewLine + "Name = τ Virginis";
            else
            if (ra1 > 13 && ra < 14 && dec1 > -65 && dec1 < -55)
                northstar.Text = "Star No = 364" + Environment.NewLine + "Magnitude = 0.9" + Environment.NewLine + "Name = β Centauri";
            else
            if (ra1 > 13 && ra < 14 && dec1 > 60 && dec1 < 70)
                northstar.Text = "Star No = 365" + Environment.NewLine + "Magnitude = 3.6" + Environment.NewLine + "Name = α Draconis";
            else
            if (ra1 > 14 && ra < 15 && dec1 > -30 && dec1 < -20)
                northstar.Text = "Star No = 366" + Environment.NewLine + "Magnitude = 3.5" + Environment.NewLine + "Name = π Hydrae";
            else
            if (ra1 > 14 && ra < 15 && dec1 > -40 && dec1 < -30)
                northstar.Text = "Star No = 367" + Environment.NewLine + "Magnitude = 2.3" + Environment.NewLine + "Name = ϑ Centauri";
            else
            if (ra1 > 14 && ra < 15 && dec1 > -15 && dec1 < -5)
                northstar.Text = "Star No = 368" + Environment.NewLine + "Magnitude = 4.3" + Environment.NewLine + "Name = Κ Virginis";
            else
            if (ra1 > 14 && ra1 < 15 && dec1 > 15 && dec1 < 25)
                northstar.Text = "Star No = 369" + Environment.NewLine + "Magnitude = 0.2" + Environment.NewLine + "Name = Arcturus (α Boo)";
            else
            if (ra1 > 14 && ra1 < 15 && dec1 > -10 && dec1 < 0)
                northstar.Text = "Star No = 370" + Environment.NewLine + "Magnitude = 4.2" + Environment.NewLine + "Name = τ Virginis";
            else
            if (ra1 > 14 && ra1 < 15 && dec1 > 40 && dec1 < 50)
                northstar.Text = "Star No = 371" + Environment.NewLine + "Magnitude = 4.3" + Environment.NewLine + "Name = λ Bootis";
            else
            if (ra1 > 14 && ra1 < 15 && dec1 > -60 && dec1 < -50)
                northstar.Text = "Star No = 372" + Environment.NewLine + "Magnitude = 4.4" + Environment.NewLine + "Name = ν Centauri";
            else
            if (ra1 > 14 && ra1 < 15 && dec1 > -45 && dec1 < -35)
                northstar.Text = "Star No = 373" + Environment.NewLine + "Magnitude = 4.2" + Environment.NewLine + "Name = φ Centauri";
            else
            if (ra1 > 14 && ra1 < 15 && dec1 > 45 && dec1 < 55)
                northstar.Text = "Star No = 374" + Environment.NewLine + "Magnitude = 4.1" + Environment.NewLine + "Name = ϑ Bootis";
            else
            if (ra1 > 14 && ra1 < 15 && dec1 > 70 && dec1 < 80)
                northstar.Text = "Star No = 375" + Environment.NewLine + "Magnitude = 4.4" + Environment.NewLine + "Name = 5 Ursae Minoris";
            else
            if (ra1 > 14 && ra1 < 15 && dec1 > 25 && dec1 < 35)
                northstar.Text = "Star No = 376" + Environment.NewLine + "Magnitude = 3.8" + Environment.NewLine + "Name = ρ Bootis";
            else
            if (ra1 > 14 && ra1 < 15 && dec1 > 35 && dec1 < 45)
                northstar.Text = "Star No = 377" + Environment.NewLine + "Magnitude = 3.0" + Environment.NewLine + "Name = γ Bootis";
            else
            if (ra1 > 14 && ra1 < 15 && dec1 > -50 && dec1 < -40)
                northstar.Text = "Star No = 378" + Environment.NewLine + "Magnitude = 2.6" + Environment.NewLine + "Name = η Centauri";
            else
            if (ra1 > 14 && ra1 < 15 && dec1 > -65 && dec1 < -55)
                northstar.Text = "Star No = 379" + Environment.NewLine + "Magnitude = 0.1" + Environment.NewLine + "Name = α Centauri";
            else
            if (ra1 > 14 && ra1 < 15 && dec1 > 10 && dec1 < 20)
                northstar.Text = "Star No = 380" + Environment.NewLine + "Magnitude = 3.9" + Environment.NewLine + "Name = ζ Bootis";
            else
            if (ra1 > 14 && ra1 < 15 && dec1 > -55 && dec1 < -45)
                northstar.Text = "Star No = 381" + Environment.NewLine + "Magnitude = 2.9" + Environment.NewLine + "Name = α Lupi";
            else
            if (ra1 > 14 && ra1 < 15 && dec1 > -70 && dec1 < -60)
                northstar.Text = "Star No = 382" + Environment.NewLine + "Magnitude = 3.4" + Environment.NewLine + "Name = α Circini";
            else
            if (ra1 > 14 && ra1 < 15 && dec1 > -10 && dec1 < 0)
                northstar.Text = "Star No = 383" + Environment.NewLine + "Magnitude = 3.9" + Environment.NewLine + "Name = μ Virginis";
            else
            if (ra1 > 14 && ra1 < 15 && dec1 > -40 && dec1 < -30)
                northstar.Text = "Star No = 384" + Environment.NewLine + "Magnitude = 4.1" + Environment.NewLine + "Name = BS 5485 (Centauris)";
            else
            if (ra1 > 14 && ra1 < 15 && dec1 > 20 && dec1 < 30)
                northstar.Text = "Star No = 385" + Environment.NewLine + "Magnitude = 2.7" + Environment.NewLine + "Name = ε Bootis";
            else
            if (ra1 > 14 && ra1 < 15 && dec1 > -85 && dec1 < -75)
                northstar.Text = "Star No = 386" + Environment.NewLine + "Magnitude = 3.8" + Environment.NewLine + "Name = α Apodis";
            else
            if (ra1 > 14 && ra1 < 15 && dec1 > 0 && dec1 < 10)
                northstar.Text = "Star No = 387" + Environment.NewLine + "Magnitude = 3.8" + Environment.NewLine + "Name = 109 Virginis";
            else
            if (ra1 > 14 && ra1 < 15 && dec1 > -20 && dec1 < -10)
                northstar.Text = "Star No = 388" + Environment.NewLine + "Magnitude = 2.9" + Environment.NewLine + "Name = α^2 Librae";
            else
            if (ra1 > 14 && ra1 < 15 && dec1 > 70 && dec1 < 80)
                northstar.Text = "Star No = 389" + Environment.NewLine + "Magnitude = 2.2" + Environment.NewLine + "Name = β Ursae Minoris";
            else
            if (ra1 > 14 && ra1 < 15 && dec1 > -50 && dec1 < -40)
                northstar.Text = "Star No = 390" + Environment.NewLine + "Magnitude = 2.8" + Environment.NewLine + "Name = β Lupi";
            else
            if (ra1 > 15 && ra1 < 16 && dec1 > -45 && dec1 < -35)
                northstar.Text = "Star No = 391" + Environment.NewLine + "Magnitude = 3.3" + Environment.NewLine + "Name = Κ Centauri";
            else
            if (ra1 > 15 && ra1 < 16 && dec1 > 35 && dec1 < 45)
                northstar.Text = "Star No = 392" + Environment.NewLine + "Magnitude = 3.6" + Environment.NewLine + "Name = β Bootis";
            else
            if (ra1 > 15 && ra1 < 16 && dec1 > -30 && dec1 < -20)
                northstar.Text = "Star No = 393" + Environment.NewLine + "Magnitude = 3.4" + Environment.NewLine + "Name = σ Librae";
            else
            if (ra1 > 15 && ra1 < 16 && dec1 > -55 && dec1 < -45)
                northstar.Text = "Star No = 394" + Environment.NewLine + "Magnitude = 4.1" + Environment.NewLine + "Name = Κ^1 Lupi";
            else
            if (ra1 > 15 && ra1 < 16 && dec1 > -55 && dec1 < -45)
                northstar.Text = "Star No = 395" + Environment.NewLine + "Magnitude = 3.5" + Environment.NewLine + "Name = ζ Lupi";
            else
            if (ra1 > 15 && ra1 < 16 && dec1 > 30 && dec1 < 40)
                northstar.Text = "Star No = 396" + Environment.NewLine + "Magnitude = 3.5" + Environment.NewLine + "Name = δ Bootis";
            else
            if (ra1 > 15 && ra1 < 16 && dec1 > -65 && dec1 < -55)
                northstar.Text = "Star No = 397" + Environment.NewLine + "Magnitude = 4.2" + Environment.NewLine + "Name = β Circini";
            else
            if (ra1 > 15 && ra1 < 16 && dec1 > -15 && dec1 < -5)
                northstar.Text = "Star No = 398" + Environment.NewLine + "Magnitude = 2.7" + Environment.NewLine + "Name = β Librae";
            else
            if (ra1 > 15 && ra1 < 16 && dec1 > -75 && dec1 < -65)
                northstar.Text = "Star No = 399" + Environment.NewLine + "Magnitude = 3.1" + Environment.NewLine + "Name = γ Trianguli Aust";
            else
            if (ra1 > 15 && ra1 < 16 && dec1 > -45 && dec1 < -35)
                northstar.Text = "Star No = 400" + Environment.NewLine + "Magnitude = 3.4" + Environment.NewLine + "Name = δ Lupi";
            else
            if (ra1 > 15 && ra1 < 16 && dec1 > -40 && dec1 < -30)
                northstar.Text = "Star No = 401" + Environment.NewLine + "Magnitude = 3.6" + Environment.NewLine + "Name = Φ^1 Lupi";
            else
            if (ra1 > 15 && ra1 < 16 && dec1 > 65 && dec1 < 75)
                northstar.Text = "Star No = 402" + Environment.NewLine + "Magnitude = 3.1" + Environment.NewLine + "Name =  γ Ursae Minoris";
            else
            if (ra1 > 15 && ra1 < 16 && dec1 > -50 && dec1 < -40)
                northstar.Text = "Star No = 403" + Environment.NewLine + "Magnitude = 3.7" + Environment.NewLine + "Name = ε Lupi";
            else
            if (ra1 > 15 && ra1 < 16 && dec1 > 30 && dec1 < 40)
                northstar.Text = "Star No = 404" + Environment.NewLine + "Magnitude = 4.5" + Environment.NewLine + "Name = μ Bootis";
            else
            if (ra1 > 15 && ra1 < 16 && dec1 > 55 && dec1 < 65)
                northstar.Text = "Star No = 405" + Environment.NewLine + "Magnitude = 3.5" + Environment.NewLine + "Name = τ Draconis";
            else
            if (ra1 > 15 && ra1 < 16 && dec1 > 25 && dec1 < 35)
                northstar.Text = "Star No = 406" + Environment.NewLine + "Magnitude = 3.7" + Environment.NewLine + "Name = β Coronae Bor.";
            else
            if (ra1 > 15 && ra1 < 16 && dec1 > 25 && dec1 < 35)
                northstar.Text = "Star No = 407" + Environment.NewLine + "Magnitude = 4.2" + Environment.NewLine + "Name = ϑ Coronae Bor.";
            else
            if (ra1 > 15 && ra1 < 16 && dec1 > -45 && dec1 < -35)
                northstar.Text = "Star No = 408" + Environment.NewLine + "Magnitude = 2.9" + Environment.NewLine + "Name = γ Lupi";
            else
            if (ra1 > 15 && ra1 < 16 && dec1 > 5 && dec1 < 15)
                northstar.Text = "Star No = 409" + Environment.NewLine + "Magnitude = 3.8" + Environment.NewLine + "Name = δ Serpentis";
            else
            if (ra1 > 15 && ra1 < 16 && dec1 > 20 && dec1 < 30)
                northstar.Text = "Star No = 410" + Environment.NewLine + "Magnitude = 2.3" + Environment.NewLine + "Name = α Coronae Bor.";
            else
            if (ra1 > 15 && ra1 < 16 && dec1 > -20 && dec1 < -10)
                northstar.Text = "Star No = 411" + Environment.NewLine + "Magnitude = 4.0" + Environment.NewLine + "Name = γ Librae";
            else
            if (ra1 > 15 && ra1 < 16 && dec1 > -70 && dec1 < -60)
                northstar.Text = "Star No = 412" + Environment.NewLine + "Magnitude = 4.1" + Environment.NewLine + "Name = ε Trianguli Aust";
            else
            if (ra1 > 15 && ra1 < 16 && dec1 > -35 && dec1 < -25)
                northstar.Text = "Star No = 413" + Environment.NewLine + "Magnitude = 3.8" + Environment.NewLine + "Name = υ Librae";
            else
            if (ra1 > 15 && ra1 < 16 && dec1 > -35 && dec1 < -25)
                northstar.Text = "Star No = 414" + Environment.NewLine + "Magnitude = 3.8" + Environment.NewLine + "Name = τ Librea";
            else
            if (ra1 > 15 && ra1 < 16 && dec1 > 20 && dec1 < 30)
                northstar.Text = "Star No = 415" + Environment.NewLine + "Magnitude = 3.9" + Environment.NewLine + "Name = γ Coronae Bor.";
            else
            if (ra1 > 15 && ra1 < 16 && dec1 > 0 && dec1 < 10)
                northstar.Text = "Star No = 416" + Environment.NewLine + "Magnitude = 2.7" + Environment.NewLine + "Name = α Serpentis";
            else
            if (ra1 > 15 && ra1 < 16 && dec1 > 70 && dec1 < 80)
                northstar.Text = "Star No = 417" + Environment.NewLine + "Magnitude = 4.3" + Environment.NewLine + "Name = ζ Ursae Minoris";
            else
            if (ra1 > 15 && ra1 < 16 && dec1 > 10 && dec1 < 20)
                northstar.Text = "Star No = 418" + Environment.NewLine + "Magnitude = 3.7" + Environment.NewLine + "Name = β Serpentis";
            else
            if (ra1 > 15 && ra1 < 16 && dec1 > 15 && dec1 < 25)
                northstar.Text = "Star No = 419" + Environment.NewLine + "Magnitude = 4.3" + Environment.NewLine + "Name = Κ Serpentis";
            else
            if (ra1 > 15 && ra1 < 16 && dec1 > -10 && dec1 < 0)
                northstar.Text = "Star No = 420" + Environment.NewLine + "Magnitude = 3.6" + Environment.NewLine + "Name = μ Serpentis";
            else
            if (ra1 > 15 && ra1 < 16 && dec1 > -40 && dec1 < -30)
                northstar.Text = "Star No = 421" + Environment.NewLine + "Magnitude = 4.1" + Environment.NewLine + "Name = χ Lupi";
            else
            if (ra1 > 15 && ra1 < 16 && dec1 > 0 && dec1 < 10)
                northstar.Text = "Star No = 422" + Environment.NewLine + "Magnitude = 3.7" + Environment.NewLine + "Name = ε Serpentis";
            else
            if (ra1 > 15 && ra1 < 16.0 && dec1 > -70 && dec1 < -60)
                northstar.Text = "Star No = 423" + Environment.NewLine + "Magnitude = 3.0" + Environment.NewLine + "Name = β Triangulis Aust";
            else
            if (ra1 > 15 && ra1 < 16.0 && dec1 > 10 && dec1 < 20)
                northstar.Text = "Star No = 424" + Environment.NewLine + "Magnitude = 3.9" + Environment.NewLine + "Name = γ Serpentis";
            else
            if (ra1 > 15 && ra1 < 16.0 && dec1 > 20 && dec1 < 30)
                northstar.Text = "Star No = 425" + Environment.NewLine + "Magnitude = 4.2" + Environment.NewLine + "Name = ε Coronae Bor.";
            else
            if (ra1 > 15 && ra1 < 16.0 && dec1 > -30 && dec1 < -20)
                northstar.Text = "Star No = 426" + Environment.NewLine + "Magnitude = 3.0" + Environment.NewLine + "Name = π Scorpii";
            else
            if (ra1 > 15 && ra1 < 16 && dec1 > -45 && dec1 < -35)
                northstar.Text = "Star No = 427" + Environment.NewLine + "Magnitude = 3.6" + Environment.NewLine + "Name = η Lupi";
            else
            if (ra1 > 15 && ra1 < 16 && dec1 > -30 && dec1 < -20)
                northstar.Text = "Star No = 428" + Environment.NewLine + "Magnitude = 2.5" + Environment.NewLine + "Name = δ Scorpii";
            else
            if (ra1 > 15 && ra1 < 16 && dec1 > 55 && dec1 < 65)
                northstar.Text = "Star No = 429" + Environment.NewLine + "Magnitude = 4.1" + Environment.NewLine + "Name = ϑ Draconis";
            else
            if (ra1 > 16 && ra1 < 17 && dec1 > -25 && dec1 < -15)
                northstar.Text = "Star No = 430" + Environment.NewLine + "Magnitude = 2.9" + Environment.NewLine + "Name = β Sorpii";
            else
            if (ra1 > 16 && ra1 < 17 && dec1 > -40 && dec1 < -30)
                northstar.Text = "Star No = 431" + Environment.NewLine + "Magnitude = 4.3" + Environment.NewLine + "Name = ϑ Lupi";
            else
            if (ra1 > 16 && ra1 < 17 && dec1 > 40 && dec1 < 50)
                northstar.Text = "Star No = 432" + Environment.NewLine + "Magnitude = 4.3" + Environment.NewLine + "Name = Φ Herculis";
            else
            if (ra1 > 16 && ra1 < 17 && dec1 > -10 && dec1 < 0)
                northstar.Text = "Star No = 433" + Environment.NewLine + "Magnitude = 3.0" + Environment.NewLine + "Name = δ Ophiuchis";
            else
            if (ra1 > 16 && ra1 < 17 && dec1 > -70 && dec1 < -60)
                northstar.Text = "Star No = 434" + Environment.NewLine + "Magnitude = 4.0" + Environment.NewLine + "Name = δ Trianguli Aust";
            else
            if (ra1 > 16 && ra1 < 17 && dec1 > -10 && dec1 < 0)
                northstar.Text = "Star No = 435" + Environment.NewLine + "Magnitude = 3.3" + Environment.NewLine + "Name = ε Ophiuchi";
            else
            if (ra1 > 16 && ra1 < 17 && dec1 > -55 && dec1 < -45)
                northstar.Text = "Star No = 436" + Environment.NewLine + "Magnitude = 4.1" + Environment.NewLine + "Name = γ^2 Normae";
            else
            if (ra1 > 16 && ra1 < 17 && dec1 > 40 && dec1 < 50)
                northstar.Text = "Star No = 437" + Environment.NewLine + "Magnitude = 3.9" + Environment.NewLine + "Name = τ Herculis";
            else
            if (ra1 > 16 && ra1 < 17 && dec1 > -30 && dec1 < -20)
                northstar.Text = "Star No = 438" + Environment.NewLine + "Magnitude = 3.1" + Environment.NewLine + "Name = σ Sorpii";
            else
            if (ra1 > 16 && ra1 < 17 && dec1 > 15 && dec1 < 25)
                northstar.Text = "Star No = 439" + Environment.NewLine + "Magnitude = 3.8" + Environment.NewLine + "Name = γ Herculis";
            else
            if (ra1 > 16 && ra1 < 17 && dec1 > 55 && dec1 < 65)
                northstar.Text = "Star No = 440" + Environment.NewLine + "Magnitude = 2.9" + Environment.NewLine + "Name = η Draconis";
            else
            if (ra1 > 16 && ra1 < 17 && dec1 > -30 && dec1 < -20)
                northstar.Text = "Star No = 441" + Environment.NewLine + "Magnitude = d 1.2" + Environment.NewLine + "Name = Antares (α Sco)";
            else
            if (ra1 > 16 && ra1 < 17 && dec1 > 15 && dec1 < 25)
                northstar.Text = "Star No = 442" + Environment.NewLine + "Magnitude = 2.8" + Environment.NewLine + "Name = β Herculis";
            else
            if (ra1 > 16 && ra1 < 17 && dec1 > -85 && dec1 < -75)
                northstar.Text = "Star No = 443" + Environment.NewLine + "Magnitude = 3.9" + Environment.NewLine + "Name = γ Apodis";
            else
            if (ra1 > 16 && ra1 < 17 && dec1 > 0 && dec1 < 10)
                northstar.Text = "Star No = 444" + Environment.NewLine + "Magnitude = 3.8" + Environment.NewLine + "Name = λ Ophiuchi";
            else
            if (ra1 > 16 && ra1 < 17 && dec1 > -40 && dec1 < -30)
                northstar.Text = "Star No = 445" + Environment.NewLine + "Magnitude = 4.3" + Environment.NewLine + "Name = Ν Scorpii";
            else
            if (ra1 > 16 && ra1 < 17 && dec1 > 40 && dec1 < 50)
                northstar.Text = "Star No = 446" + Environment.NewLine + "Magnitude = 4.2" + Environment.NewLine + "Name = σ Herculis";
            else
            if (ra1 > 16 && ra1 < 17 && dec1 > -35 && dec1 < -25)
                northstar.Text = "Star No = 447" + Environment.NewLine + "Magnitude = 2.9" + Environment.NewLine + "Name = τ Scorpii";
            else
            if (ra1 > 16 && ra1 < 17 && dec1 > -15 && dec1 < -5)
                northstar.Text = "Star No = 448" + Environment.NewLine + "Magnitude = 2.7" + Environment.NewLine + "Name = ζ Ophiuchi";
            else
            if (ra1 > 16 && ra1 < 17 && dec1 > 25 && dec1 < 35)
                northstar.Text = "Star No = 449" + Environment.NewLine + "Magnitude = 3.0" + Environment.NewLine + "Name = ζ Herculis";
            else
            if (ra1 > 16 && ra1 < 17 && dec1 > 35 && dec1 < 45)
                northstar.Text = "Star No = 450" + Environment.NewLine + "Magnitude = 3.6" + Environment.NewLine + "Name = η Herculis";
            else
            if (ra1 > 16 && ra1 < 17 && dec1 > -75 && dec1 < -65)
                northstar.Text = "Star No = 451" + Environment.NewLine + "Magnitude = 1.9" + Environment.NewLine + "Name = α Trianguli Aust.";
            else
            if (ra1 > 16 && ra1 < 17 && dec1 > -65 && dec1 < -55)
                northstar.Text = "Star No = 452" + Environment.NewLine + "Magnitude = 3.7" + Environment.NewLine + "Name = η Arae";
            else
            if (ra1 > 16 && ra1 < 17 && dec1 > 75 && dec1 < 85)
                northstar.Text = "Star No = 453" + Environment.NewLine + "Magnitude = 4.4" + Environment.NewLine + "Name = ε Ursae Minoris";
            else
            if (ra1 > 16 && ra1 < 17 && dec1 > -40 && dec1 < -30)
                northstar.Text = "Star No = 454" + Environment.NewLine + "Magnitude = 2.4" + Environment.NewLine + "Name = ε Sorpii";
            else
            if (ra1 > 16 && ra1 < 17 && dec1 > -45 && dec1 < -35)
                northstar.Text = "Star No = 455" + Environment.NewLine + "Magnitude = 3.1" + Environment.NewLine + "Name = μ^1 Sorpii";
            else
            if (ra1 > 16 && ra1 < 17 && dec1 > -45 && dec1 < -35)
                northstar.Text = "Star No = 456" + Environment.NewLine + "Magnitude = 3.6" + Environment.NewLine + "Name = μ^2 Sorpii";
            else
            if (ra1 > 16 && ra1 < 17.0 && dec1 > -50 && dec1 < -40)
                northstar.Text = "Star No = 457" + Environment.NewLine + "Magnitude = 3.7" + Environment.NewLine + "Name = ζ^2 Sorpii";
            else
            if (ra1 > 16 && ra1 < 17.0 && dec1 > 5 && dec1 < 15)
                northstar.Text = "Star No = 458" + Environment.NewLine + "Magnitude = 4.3" + Environment.NewLine + "Name = τ ophiuchi";
            else
            if (ra1 > 16 && ra1 < 17.0 && dec1 > 5 && dec1 < 15)
                northstar.Text = "Star No = 459" + Environment.NewLine + "Magnitude = 3.4" + Environment.NewLine + "Name = Κ ophiuchi";
            else
            if (ra1 > 16 && ra1 < 17.0 && dec1 > -60 && dec1 < -50)
                northstar.Text = "Star No = 460" + Environment.NewLine + "Magnitude = 3.1" + Environment.NewLine + "Name = ζ Arae";
            else
            if (ra1 > 16 && ra1 < 17 && dec1 > -60 && dec1 < -50)
                northstar.Text = "Star No = 461" + Environment.NewLine + "Magnitude = 4.1" + Environment.NewLine + "Name = ε^1 Arae";
            else
            if (ra1 > 16 && ra1 < 17 && dec1 > 25 && dec1 < 35)
                northstar.Text = "Star No = 462" + Environment.NewLine + "Magnitude = 3.9" + Environment.NewLine + "Name = ε Herculis";
            else
            if (ra1 > 17 && ra1 < 18 && dec1 > 60 && dec1 < 70)
                northstar.Text = "Star No = 463" + Environment.NewLine + "Magnitude = 3.2" + Environment.NewLine + "Name = ζ Draconis";
            else
            if (ra1 > 17 && ra1 < 18 && dec1 > -20 && dec1 < -10)
                northstar.Text = "Star No = 464" + Environment.NewLine + "Magnitude = 2.6" + Environment.NewLine + "Name = η Ophiuchi";
            else
            if (ra1 > 17 && ra1 < 18 && dec1 > -50 && dec1 < -40)
                northstar.Text = "Star No = 465" + Environment.NewLine + "Magnitude = 3.4" + Environment.NewLine + "Name = η Scorpii";
            else
            if (ra1 > 17 && ra1 < 18 && dec1 > 10 && dec1 < 20)
                northstar.Text = "Star No = 466" + Environment.NewLine + "Magnitude = 3.5" + Environment.NewLine + "Name = α Herculis";
            else
            if (ra1 > 17 && ra1 < 18 && dec1 > 20 && dec1 < 30)
                northstar.Text = "Star No = 467" + Environment.NewLine + "Magnitude = 3.2" + Environment.NewLine + "Name = δ Herculis";
            else
            if (ra1 > 17 && ra1 < 18 && dec1 > 30 && dec1 < 40)
                northstar.Text = "Star No = 468" + Environment.NewLine + "Magnitude = 3.4" + Environment.NewLine + "Name = π Herculis";
            else
            if (ra1 > 17 && ra1 < 18 && dec1 > -30 && dec1 < -20)
                northstar.Text = "Star No = 469" + Environment.NewLine + "Magnitude = 3.4" + Environment.NewLine + "Name = ϑ Ophiuchi";
            else
            if (ra1 > 17 && ra1 < 18 && dec1 > -60 && dec1 < -50)
                northstar.Text = "Star No = 470" + Environment.NewLine + "Magnitude = 2.8" + Environment.NewLine + "Name = β Arae";
            else
            if (ra1 > 17 && ra1 < 18 && dec1 > -60 && dec1 < -50)
                northstar.Text = "Star No = 471" + Environment.NewLine + "Magnitude = 3.5" + Environment.NewLine + "Name = γ Arae";
            else
            if (ra1 > 17 && ra1 < 18 && dec1 > -30 && dec1 < -20)
                northstar.Text = "Star No = 472" + Environment.NewLine + "Magnitude = 4.3" + Environment.NewLine + "Name = 44 Ophiuchi";
            else
            if (ra1 > 17 && ra1 < 18 && dec1 > 0 && dec1 < 10)
                northstar.Text = "Star No = 473" + Environment.NewLine + "Magnitude = 4.4" + Environment.NewLine + "Name = σ Ophiuchi";
            else
            if (ra1 > 17 && ra1 < 18 && dec1 > -35 && dec1 < -25)
                northstar.Text = "Star No = 474" + Environment.NewLine + "Magnitude = 4.4" + Environment.NewLine + "Name = 45 Ophiuchi";
            else
            if (ra1 > 17 && ra1 < 18 && dec1 > -65 && dec1 < -55)
                northstar.Text = "Star No = 475" + Environment.NewLine + "Magnitude = 3.8" + Environment.NewLine + "Name = δ Arae";
            else
            if (ra1 > 17 && ra1 < 18 && dec1 > -45 && dec1 < -35)
                northstar.Text = "Star No = 476" + Environment.NewLine + "Magnitude = 2.8" + Environment.NewLine + "Name = υ Scorpii";
            else
            if (ra1 > 17 && ra1 < 18 && dec1 > 20 && dec1 < 30)
                northstar.Text = "Star No = 477" + Environment.NewLine + "Magnitude = 4.5" + Environment.NewLine + "Name = λ Herculis";
            else
            if (ra1 > 17 && ra1 < 18 && dec1 > 50 && dec1 < 60)
                northstar.Text = "Star No = 478" + Environment.NewLine + "Magnitude = 3.0" + Environment.NewLine + "Name = β Draconis";
            else
            if (ra1 > 17 && ra1 < 18 && dec1 > -55 && dec1 < -45)
                northstar.Text = "Star No = 479" + Environment.NewLine + "Magnitude = 3.0" + Environment.NewLine + "Name = α Arae";
            else
            if (ra1 > 17 && ra1 < 18 && dec1 > -40 && dec1 < -30)
                northstar.Text = "Star No = 480" + Environment.NewLine + "Magnitude = 1.7" + Environment.NewLine + "Name = λ Scorpii";
            else
            if (ra1 > 17 && ra1 < 18 && dec1 > 10 && dec1 < 20)
                northstar.Text = "Star No = 481" + Environment.NewLine + "Magnitude = 2.1" + Environment.NewLine + "Name = α Ophiuchi";
            else
            if (ra1 > 17 && ra1 < 18 && dec1 > -50 && dec1 < -40)
                northstar.Text = "Star No = 482" + Environment.NewLine + "Magnitude = 2.0" + Environment.NewLine + "Name = ϑ Scorpii";
            else
            if (ra1 > 17 && ra1 < 18 && dec1 > -20 && dec1 < -10)
                northstar.Text = "Star No = 483" + Environment.NewLine + "Magnitude = 3.6" + Environment.NewLine + "Name = ξ Serpentis";
            else
            if (ra1 > 17 && ra1 < 18 && dec1 > 40 && dec1 < 50)
                northstar.Text = "Star No = 484" + Environment.NewLine + "Magnitude = 3.8" + Environment.NewLine + "Name = τ Herculis";
            else
            if (ra1 > 17 && ra1 < 18 && dec1 > -45 && dec1 < -35)
                northstar.Text = "Star No = 485" + Environment.NewLine + "Magnitude = 2.5" + Environment.NewLine + "Name = Κ Scorpii";
            else
            if (ra1 > 17 && ra1 < 18 && dec1 > 0 && dec1 < 10)
                northstar.Text = "Star No = 486" + Environment.NewLine + "Magnitude = 2.9" + Environment.NewLine + "Name = β Ophiuchi";
            else
            if (ra1 > 17 && ra1 < 18 && dec1 > -70 && dec1 < -60)
                northstar.Text = "Star No = 487" + Environment.NewLine + "Magnitude = 3.6" + Environment.NewLine + "Name = η Pavonis";
            else
            if (ra1 > 17 && ra1 < 18 && dec1 > 20 && dec1 < 30)
                northstar.Text = "Star No = 488" + Environment.NewLine + "Magnitude = 3.5" + Environment.NewLine + "Name = μ Herculis";
            else
            if (ra1 > 17 && ra1 < 18 && dec1 > -45 && dec1 < -35)
                northstar.Text = "Star No = 489" + Environment.NewLine + "Magnitude = 3.1" + Environment.NewLine + "Name = l^1 Scorpii";
            else
            if (ra1 > 17 && ra1 < 18 && dec1 > 0 && dec1 < 10)
                northstar.Text = "Star No = 490" + Environment.NewLine + "Magnitude = 3.7" + Environment.NewLine + "Name = γ Ophiuchi";
            else
            if (ra1 > 17 && ra1 < 18 && dec1 > -40 && dec1 < -30)
                northstar.Text = "Star No = 491" + Environment.NewLine + "Magnitude = 3.2" + Environment.NewLine + "Name = G Scorpii";
            else
            if (ra1 > 17 && ra1 < 18 && dec1 > 50 && dec1 < 60)
                northstar.Text = "Star No = 492" + Environment.NewLine + "Magnitude = 3.9" + Environment.NewLine + "Name = ξ Draconis";
            else
            if (ra1 > 17 && ra1 < 18 && dec1 > 30 && dec1 < 40)
                northstar.Text = "Star No = 493" + Environment.NewLine + "Magnitude = 4.0" + Environment.NewLine + "Name = ϑ Herculis";
            else
            if (ra1 > 17 && ra1 < 18 && dec1 > 45 && dec1 < 55)
                northstar.Text = "Star No = 494" + Environment.NewLine + "Magnitude = 2.4" + Environment.NewLine + "Name = γ Draconis";
            else
            if (ra1 > 17 && ra1 < 18 && dec1 > 25 && dec1 < 35)
                northstar.Text = "Star No = 495" + Environment.NewLine + "Magnitude = 3.8" + Environment.NewLine + "Name = ξ Herculis";
            else
            if (ra1 > 17 && ra1 < 18 && dec1 > -15 && dec1 < -5)
                northstar.Text = "Star No = 496" + Environment.NewLine + "Magnitude = 3.5" + Environment.NewLine + "Name = ν Ophiuchi";
            else
            if (ra1 > 17 && ra1 < 18 && dec1 > 0 && dec1 < 10)
                northstar.Text = "Star No = 497" + Environment.NewLine + "Magnitude = 3.9" + Environment.NewLine + "Name = 67 Ophiuchi";
            else
            if (ra1 > 18 && ra1 < 19 && dec1 > -35 && dec1 < -25)
                northstar.Text = "Star No = 498" + Environment.NewLine + "Magnitude = 3.1" + Environment.NewLine + "Name = γ Sagittarii";
            else
            if (ra1 > 18 && ra1 < 19 && dec1 > -55 && dec1 < -45)
                northstar.Text = "Star No = 499" + Environment.NewLine + "Magnitude = 3.9" + Environment.NewLine + "Name = ϑ Arae";
            else
            if (ra1 > 18 && ra1 < 19 && dec1 > 5 && dec1 < 15)
                northstar.Text = "Star No = 500" + Environment.NewLine + "Magnitude = 3.7" + Environment.NewLine + "Name = 72 Ophiuchi";
            else
            if (ra1 > 18 && ra1 < 19 && dec1 > 25 && dec1 < 35)
                northstar.Text = "Star No = 501" + Environment.NewLine + "Magnitude = 3.8" + Environment.NewLine + "Name = ο Herculis";
            else
            if (ra1 > 18 && ra1 < 19 && dec1 > -25 && dec1 < -15)
                northstar.Text = "Star No = 502" + Environment.NewLine + "Magnitude = 4.0" + Environment.NewLine + "Name = μ Sagittarii";
            else
            if (ra1 > 18 && ra1 < 19 && dec1 > -40 && dec1 < -30)
                northstar.Text = "Star No = 503" + Environment.NewLine + "Magnitude = 3.2" + Environment.NewLine + "Name = η Sagittarii";
            else
            if (ra1 > 18 && ra1 < 19 && dec1 > 30 && dec1 < 40)
                northstar.Text = "Star No = 504" + Environment.NewLine + "Magnitude = 4.3" + Environment.NewLine + "Name = Κ Lyrae";
            else
            if (ra1 > 18 && ra1 < 19 && dec1 > -35 && dec1 < -25)
                northstar.Text = "Star No = 505" + Environment.NewLine + "Magnitude = 2.8" + Environment.NewLine + "Name = δ Sagittarii";
            else
            if (ra1 > 18 && ra1 < 19 && dec1 > -10 && dec1 < 0)
                northstar.Text = "Star No = 506" + Environment.NewLine + "Magnitude = 3.4" + Environment.NewLine + "Name = η Serpentis";
            else
            if (ra1 > 18 && ra1 < 19 && dec1 > -65 && dec1 < -55)
                northstar.Text = "Star No = 507" + Environment.NewLine + "Magnitude = 4.2" + Environment.NewLine + "Name = ξ Pavonis";
            else
            if (ra1 > 18 && ra1 < 19 && dec1 > 70 && dec1 < 80)
                northstar.Text = "Star No = 508" + Environment.NewLine + "Magnitude = 3.7" + Environment.NewLine + "Name = χ Draconis";
            else
            if (ra1 > 18 && ra1 < 19 && dec1 > -40 && dec1 < -30)
                northstar.Text = "Star No = 509" + Environment.NewLine + "Magnitude = 1.9" + Environment.NewLine + "Name = ε Sagittarii";
            else
            if (ra1 > 18 && ra1 < 19 && dec1 > 15 && dec1 < 25)
                northstar.Text = "Star No = 510" + Environment.NewLine + "Magnitude = 3.9" + Environment.NewLine + "Name = 109 Herculis";
            else
            if (ra1 > 18 && ra1 < 19 && dec1 > -50 && dec1 < -40)
                northstar.Text = "Star No = 511" + Environment.NewLine + "Magnitude = 3.8" + Environment.NewLine + "Name = α Telescopii";
            else
            if (ra1 > 18 && ra1 < 19 && dec1 > -30 && dec1 < -20)
                northstar.Text = "Star No = 512" + Environment.NewLine + "Magnitude = 2.9" + Environment.NewLine + "Name = λ Sagittarii";
            else
            if (ra1 > 18 && ra1 < 19 && dec1 > -10 && dec1 < 0)
                northstar.Text = "Star No = 513" + Environment.NewLine + "Magnitude = 4.1" + Environment.NewLine + "Name = α Scuti";
            else
            if (ra1 > 18 && ra1 < 19 && dec1 > 35 && dec1 < 45)
                northstar.Text = "Star No = 514" + Environment.NewLine + "Magnitude = d 0.1" + Environment.NewLine + "Name = Vega (α Lyrae)";
            else
            if (ra1 > 18 && ra1 < 19 && dec1 > -75 && dec1 < -65)
                northstar.Text = "Star No = 515" + Environment.NewLine + "Magnitude = 4.1" + Environment.NewLine + "Name = ζ Pavonis";
            else
            if (ra1 > 18 && ra1 < 19 && dec1 > -30 && dec1 < -20)
                northstar.Text = "Star No = 516" + Environment.NewLine + "Magnitude = 3.3" + Environment.NewLine + "Name = Φ Sagittarii";
            else
            if (ra1 > 18 && ra1 < 19 && dec1 > 15 && dec1 < 25)
                northstar.Text = "Star No = 517" + Environment.NewLine + "Magnitude = 4.3" + Environment.NewLine + "Name = 110 Herculis";
            else
            if (ra1 > 18 && ra1 < 19 && dec1 > -10 && dec1 < 0)
                northstar.Text = "Star No = 518" + Environment.NewLine + "Magnitude = 4.5" + Environment.NewLine + "Name = β Scuti";
            else
            if (ra1 > 18 && ra1 < 19 && dec1 > 15 && dec1 < 25)
                northstar.Text = "Star No = 519" + Environment.NewLine + "Magnitude = 4.4" + Environment.NewLine + "Name = 111 Herculis";
            else
            if (ra1 > 18 && ra1 < 19 && dec1 > 30 && dec1 < 40)
                northstar.Text = "Star No = 520" + Environment.NewLine + "Magnitude = 3.8" + Environment.NewLine + "Name = β Lyrae";
            else
            if (ra1 > 18 && ra1 < 19 && dec1 > -65 && dec1 < -55)
                northstar.Text = "Star No = 521" + Environment.NewLine + "Magnitude = 4.4" + Environment.NewLine + "Name = λ Pavonis";
            else
            if (ra1 > 18 && ra1 < 19.0 && dec1 > -30 && dec1 < -20)
                northstar.Text = "Star No = 522" + Environment.NewLine + "Magnitude = 2.1" + Environment.NewLine + "Name = σ Sagittarii";
            else
            if (ra1 > 18 && ra1 < 19.0 && dec1 > 40 && dec1 < 50)
                northstar.Text = "Star No = 523" + Environment.NewLine + "Magnitude = 4.2" + Environment.NewLine + "Name = R Lyrae";
            else
            if (ra1 > 18 && ra1 < 19.0 && dec1 > -25 && dec1 < -15)
                northstar.Text = "Star No = 524" + Environment.NewLine + "Magnitude = 3.6" + Environment.NewLine + "Name = ξ^2 Sagittarii";
            else
            if (ra1 > 18 && ra1 < 19.0 && dec1 > 30 && dec1 < 40)
                northstar.Text = "Star No = 525" + Environment.NewLine + "Magnitude = 3.3" + Environment.NewLine + "Name = γ Lyrae";
            else
            if (ra1 > 18 && ra1 < 19 && dec1 > 10 && dec1 < 20)
                northstar.Text = "Star No = 526" + Environment.NewLine + "Magnitude = 4.2" + Environment.NewLine + "Name = ε Aquilae";
            else
            if (ra1 > 18 && ra1 < 19 && dec1 > -35 && dec1 < -25)
                northstar.Text = "Star No = 527" + Environment.NewLine + "Magnitude = 2.7" + Environment.NewLine + "Name = ζ Sagittarii";
            else
            if (ra1 > 18 && ra1 < 19 && dec1 > -25 && dec1 < -15)
                northstar.Text = "Star No = 528" + Environment.NewLine + "Magnitude = 3.9" + Environment.NewLine + "Name = ο Sagittarii";
            else
            if (ra1 > 19 && ra1 < 20 && dec1 > 10 && dec1 < 20)
                northstar.Text = "Star No = 529" + Environment.NewLine + "Magnitude = 3.0" + Environment.NewLine + "Name = ζ Aquilae";
            else
            if (ra1 > 19 && ra1 < 20 && dec1 > 10 && dec1 < 0)
                northstar.Text = "Star No = 530" + Environment.NewLine + "Magnitude = 3.5" + Environment.NewLine + "Name = λ Aquilae";
            else
            if (ra1 > 19 && ra1 < 20 && dec1 > -35 && dec1 < -25)
                northstar.Text = "Star No = 531" + Environment.NewLine + "Magnitude = 3.4" + Environment.NewLine + "Name = τ Sagittarii";
            else
            if (ra1 > 19 && ra1 < 20 && dec1 > -45 && dec1 < -35)
                northstar.Text = "Star No = 532" + Environment.NewLine + "Magnitude = 4.1" + Environment.NewLine + "Name = α Coronae Aust.";
            else
            if (ra1 > 19 && ra1 < 20 && dec1 > -25 && dec1 < -15)
                northstar.Text = "Star No = 533" + Environment.NewLine + "Magnitude = 3.0" + Environment.NewLine + "Name = π Sagittarii";
            else
            if (ra1 > 19 && ra1 < 20 && dec1 > 65 && dec1 < 75)
                northstar.Text = "Star No = 534" + Environment.NewLine + "Magnitude = 3.2" + Environment.NewLine + "Name = δ Draconis";
            else
            if (ra1 > 19 && ra1 < 20 && dec1 > 35 && dec1 < 45)
                northstar.Text = "Star No = 535" + Environment.NewLine + "Magnitude = 4.5" + Environment.NewLine + "Name = ϑ Lyrae";
            else
            if (ra1 > 19 && ra1 < 20 && dec1 > 50 && dec1 < 60)
                northstar.Text = "Star No = 536" + Environment.NewLine + "Magnitude = 4.0" + Environment.NewLine + "Name = Κ Cygni";
            else
            if (ra1 > 19 && ra1 < 20 && dec1 > -25 && dec1 < -15)
                northstar.Text = "Star No = 537" + Environment.NewLine + "Magnitude = 3.9" + Environment.NewLine + "Name = ρ Sagittarii";
            else
            if (ra1 > 19 && ra1 < 20 && dec1 > -50 && dec1 < -40)
                northstar.Text = "Star No = 538" + Environment.NewLine + "Magnitude = 4.3" + Environment.NewLine + "Name = β^1 Sagittarii";
            else
            if (ra1 > 19 && ra1 < 20 && dec1 > -45 && dec1 < -35)
                northstar.Text = "Star No = 539" + Environment.NewLine + "Magnitude = 4.1" + Environment.NewLine + "Name = α Sagittarii";
            else
            if (ra1 > 19 && ra1 < 20 && dec1 > 0 && dec1 < 10)
                northstar.Text = "Star No = 540" + Environment.NewLine + "Magnitude = 3.4" + Environment.NewLine + "Name = δ Aquilea";
            else
            if (ra1 > 19 && ra1 < 20 && dec1 > 45 && dec1 < 55)
                northstar.Text = "Star No = 541" + Environment.NewLine + "Magnitude = 3.9" + Environment.NewLine + "Name = l Cygni";
            else
            if (ra1 > 19 && ra1 < 20 && dec1 > 25 && dec1 < 35)
                northstar.Text = "Star No = 542" + Environment.NewLine + "Magnitude = 3.2" + Environment.NewLine + "Name = β Cygni";
            else
            if (ra1 > 19 && ra1 < 20 && dec1 > 15 && dec1 < 25)
                northstar.Text = "Star No = 543" + Environment.NewLine + "Magnitude = 4.4" + Environment.NewLine + "Name = β Sagittae";
            else
            if (ra1 > 19 && ra1 < 20 && dec1 > 40 && dec1 < 50)
                northstar.Text = "Star No = 544" + Environment.NewLine + "Magnitude = 3.0" + Environment.NewLine + "Name = δ Cygni";
            else
            if (ra1 > 19 && ra1 < 20 && dec1 > 5 && dec1 < 15)
                northstar.Text = "Star No = 545" + Environment.NewLine + "Magnitude = 2.8" + Environment.NewLine + "Name = γ Aquilae";
            else
            if (ra1 > 19 && ra1 < 20 && dec1 > 15 && dec1 < 25)
                northstar.Text = "Star No = 546" + Environment.NewLine + "Magnitude = 3.8" + Environment.NewLine + "Name = δ Sagittae";
            else
            if (ra1 > 19 && ra1 < 20 && dec1 > 65 && dec1 < 75)
                northstar.Text = "Star No = 547" + Environment.NewLine + "Magnitude = 4.0" + Environment.NewLine + "Name = ε Draconis";
            else
            if (ra1 > 19 && ra1 < 20 && dec1 > 5 && dec1 < 15)
                northstar.Text = "Star No = 548" + Environment.NewLine + "Magnitude = 0.9" + Environment.NewLine + "Name = Altair (α Aql)";
            else
            if (ra1 > 19 && ra1 < 20 && dec1 > 0 && dec1 < 10)
                northstar.Text = "Star No = 549" + Environment.NewLine + "Magnitude = 4.0" + Environment.NewLine + "Name = η Aquilae";
            else
            if (ra1 > 19 && ra1 < 20 && dec1 > -45 && dec1 < -35)
                northstar.Text = "Star No = 550" + Environment.NewLine + "Magnitude = 4.2" + Environment.NewLine + "Name = l Sagittarii";
            else
            if (ra1 > 19 && ra1 < 20 && dec1 > 0 && dec1 < 10)
                northstar.Text = "Star No = 551" + Environment.NewLine + "Magnitude = 3.9" + Environment.NewLine + "Name = β Aquilae";
            else
            if (ra1 > 19 && ra1 < 20 && dec1 > 30 && dec1 < 40)
                northstar.Text = "Star No = 552" + Environment.NewLine + "Magnitude = 4.0" + Environment.NewLine + "Name = η Cygni";
            else
            if (ra1 > 19 && ra1 < 20 && dec1 > 15 && dec1 < 25)
                northstar.Text = "Star No = 553" + Environment.NewLine + "Magnitude = 3.7" + Environment.NewLine + "Name = γ Sagittae";
            else
            if (ra1 > 19 && ra1 < 20 && dec1 > -75 && dec1 < -65)
                northstar.Text = "Star No = 554" + Environment.NewLine + "Magnitude = 4.1" + Environment.NewLine + "Name = ε Pavonis";
            else
            if (ra1 > 19 && ra1 < 20 && dec1 > -40 && dec1 < -30)
                northstar.Text = "Star No = 555" + Environment.NewLine + "Magnitude = 4.4" + Environment.NewLine + "Name = ϑ^1 Sagittarii";
            else
            if (ra1 > 20 && ra1 < 21 && dec1 > -70 && dec1 < -60)
                northstar.Text = "Star No = 556" + Environment.NewLine + "Magnitude = 3.6" + Environment.NewLine + "Name = δ Pavonis";
            else
            if (ra1 > 20 && ra1 < 21 && dec1 > 75 && dec1 < 85)
                northstar.Text = "Star No = 557" + Environment.NewLine + "Magnitude = 4.4" + Environment.NewLine + "Name = Κ Cephei";
            else
            if (ra1 > 20 && ra1 < 21 && dec1 > -5 && dec1 < 5)
                northstar.Text = "Star No = 558" + Environment.NewLine + "Magnitude = 3.4" + Environment.NewLine + "Name = ϑ Aquilae";
            else
            if (ra1 > 20 && ra1 < 21 && dec1 > 50 && dec1 < 60)
                northstar.Text = "Star No = 559" + Environment.NewLine + "Magnitude = 4.3" + Environment.NewLine + "Name = 33 Cygni";
            else
            if (ra1 > 20 && ra1 < 21 && dec1 > 40 && dec1 < 50)
                northstar.Text = "Star No = 560" + Environment.NewLine + "Magnitude = 3.9" + Environment.NewLine + "Name = ο^1 Cygni";
            else
            if (ra1 > 20 && ra1 < 21 && dec1 > -15 && dec1 < -5)
                northstar.Text = "Star No = 561" + Environment.NewLine + "Magnitude = 3.8" + Environment.NewLine + "Name = α^2 Capricorni";
            else
            if (ra1 > 20 && ra1 < 21 && dec1 > -20 && dec1 < -10)
                northstar.Text = "Star No = 562" + Environment.NewLine + "Magnitude = 3.2" + Environment.NewLine + "Name = β Capricorni";
            else
            if (ra1 > 20 && ra1 < 21 && dec1 > 35 && dec1 < 45)
                northstar.Text = "Star No = 563" + Environment.NewLine + "Magnitude = 2.3" + Environment.NewLine + "Name = γ Cygni";
            else
            if (ra1 > 20 && ra1 < 21 && dec1 > -60 && dec1 < -50)
                northstar.Text = "Star No = 564" + Environment.NewLine + "Magnitude = 2.1" + Environment.NewLine + "Name = α Pavonis";
            else
            if (ra1 > 20 && ra1 < 21 && dec1 > 25 && dec1 < 35)
                northstar.Text = "Star No = 565" + Environment.NewLine + "Magnitude = 4.1" + Environment.NewLine + "Name = 41 Cygni";
            else
            if (ra1 > 20 && ra1 < 21 && dec1 > 60 && dec1 < 70)
                northstar.Text = "Star No = 566" + Environment.NewLine + "Magnitude = 4.3" + Environment.NewLine + "Name = ϑ Celphei";
            else
            if (ra1 > 20 && ra1 < 21 && dec1 > 5 && dec1 < 15)
                northstar.Text = "Star No = 567" + Environment.NewLine + "Magnitude = 4.0" + Environment.NewLine + "Name = ε Delphini";
            else
            if (ra1 > 20 && ra1 < 21 && dec1 > -50 && dec1 < -40)
                northstar.Text = "Star No = 568" + Environment.NewLine + "Magnitude = 3.2" + Environment.NewLine + "Name = α Indi";
            else
            if (ra1 > 20 && ra1 < 21 && dec1 > 10 && dec1 < 20)
                northstar.Text = "Star No = 569" + Environment.NewLine + "Magnitude = 3.7" + Environment.NewLine + "Name = β Delphini";
            else
            if (ra1 > 20 && ra1 < 21 && dec1 > 10 && dec1 < 20)
                northstar.Text = "Star No = 570" + Environment.NewLine + "Magnitude = 3.9" + Environment.NewLine + "Name = α Delphini";
            else
            if (ra1 > 20 && ra1 < 21 && dec1 > 40 && dec1 < 50)
                northstar.Text = "Star No = 571" + Environment.NewLine + "Magnitude = d 1.3" + Environment.NewLine + "Name = Deneb (α Cygni)";
            else
            if (ra1 > 20 && ra1 < 21 && dec1 > -70 && dec1 < -60)
                northstar.Text = "Star No = 572" + Environment.NewLine + "Magnitude = 3.6" + Environment.NewLine + "Name = β Pavonis";
            else
            if (ra1 > 20 && ra1 < 21 && dec1 > -30 && dec1 < -20)
                northstar.Text = "Star No = 573" + Environment.NewLine + "Magnitude = 4.3" + Environment.NewLine + "Name = ϕ Capricorni";
            else
            if (ra1 > 20 && ra1 < 21 && dec1 > 55 && dec1 < 65)
                northstar.Text = "Star No = 574" + Environment.NewLine + "Magnitude = 3.6" + Environment.NewLine + "Name = η Cephei";
            else
            if (ra1 > 20 && ra1 < 21 && dec1 > 30 && dec1 < 40)
                northstar.Text = "Star No = 575" + Environment.NewLine + "Magnitude = 2.6" + Environment.NewLine + "Name = ε Cygni";
            else
            if (ra1 > 20 && ra1 < 21 && dec1 > -15 && dec1 < -5)
                northstar.Text = "Star No = 576" + Environment.NewLine + "Magnitude = 3.8" + Environment.NewLine + "Name = ε Aquarii";
            else
            if (ra1 > 20 && ra1 < 21 && dec1 > -30 && dec1 < -20)
                northstar.Text = "Star No = 577" + Environment.NewLine + "Magnitude = 4.2" + Environment.NewLine + "Name = ω Capricorni";
            else
            if (ra1 > 20 && ra1 < 21.0 && dec1 > -65 && dec1 < -55)
                northstar.Text = "Star No = 578" + Environment.NewLine + "Magnitude = 3.7" + Environment.NewLine + "Name = β Indi";
            else
            if (ra1 > 20 && ra1 < 21.0 && dec1 > 35 && dec1 < 45)
                northstar.Text = "Star No = 579" + Environment.NewLine + "Magnitude = 4.0" + Environment.NewLine + "Name = ν Cygni";
            else
            if (ra1 > 20 && ra1 < 21 && dec1 > 40 && dec1 < 50)
                northstar.Text = "Star No = 580" + Environment.NewLine + "Magnitude = 3.9" + Environment.NewLine + "Name =  ξ Cygni";
            else
            if (ra1 > 21 && ra1 < 22 && dec1 > -20 && dec1 < -10)
                northstar.Text = "Star No = 581" + Environment.NewLine + "Magnitude = 4.2" + Environment.NewLine + "Name = ϑ Capricorni";
            else
            if (ra1 > 21 && ra1 < 22 && dec1 > 25 && dec1 < 35)
                northstar.Text = "Star No = 582" + Environment.NewLine + "Magnitude = 3.4" + Environment.NewLine + "Name = ζ Cygni";
            else
            if (ra1 > 21 && ra1 < 22 && dec1 > 35 && dec1 < 45)
                northstar.Text = "Star No = 583" + Environment.NewLine + "Magnitude = 3.8" + Environment.NewLine + "Name = τ Cygni";
            else
            if (ra1 > 21 && ra1 < 22 && dec1 > 0 && dec1 < 10)
                northstar.Text = "Star No = 584" + Environment.NewLine + "Magnitude = 4.1" + Environment.NewLine + "Name = α Equulei";
            else
            if (ra1 > 21 && ra1 < 22 && dec1 > 35 && dec1 < 45)
                northstar.Text = "Star No = 585" + Environment.NewLine + "Magnitude = 4.3" + Environment.NewLine + "Name = σ Cygni";
            else
            if (ra1 > 21 && ra1 < 22 && dec1 > 30 && dec1 < 40)
                northstar.Text = "Star No = 586" + Environment.NewLine + "Magnitude = 4.4" + Environment.NewLine + "Name = υ Cygni";
            else
            if (ra1 > 21 && ra1 < 22 && dec1 > 60 && dec1 < 70)
                northstar.Text = "Star No = 587" + Environment.NewLine + "Magnitude = 2.6" + Environment.NewLine + "Name = α Cephei";
            else
            if (ra1 > 21 && ra1 < 22 && dec1 > -20 && dec1 < -10)
                northstar.Text = "Star No = 588" + Environment.NewLine + "Magnitude = 4.3" + Environment.NewLine + "Name = l Capricorni";
            else
            if (ra1 > 21 && ra1 < 22 && dec1 > 15 && dec1 < 25)
                northstar.Text = "Star No = 589" + Environment.NewLine + "Magnitude = 4.3" + Environment.NewLine + "Name = Ι Pegasi";
            else
            if (ra1 > 21 && ra1 < 22 && dec1 > -70 && dec1 < -60)
                northstar.Text = "Star No = 590" + Environment.NewLine + "Magnitude = 4.3" + Environment.NewLine + "Name = γ Pavonis";
            else
            if (ra1 > 21 && ra1 < 22 && dec1 > -25 && dec1 < -15)
                northstar.Text = "Star No = 591" + Environment.NewLine + "Magnitude = 3.9" + Environment.NewLine + "Name = ζ Capricorni";
            else
            if (ra1 > 21 && ra1 < 22 && dec1 > 65 && dec1 < 75)
                northstar.Text = "Star No = 592" + Environment.NewLine + "Magnitude = 3.3" + Environment.NewLine + "Name = β Cephei";
            else
            if (ra1 > 21 && ra1 < 22 && dec1 > -10 && dec1 < 0)
                northstar.Text = "Star No = 593" + Environment.NewLine + "Magnitude = 3.1" + Environment.NewLine + "Name = β Aquarii";
            else
            if (ra1 > 21 && ra1 < 22 && dec1 > 40 && dec1 < 50)
                northstar.Text = "Star No = 594" + Environment.NewLine + "Magnitude = 4.2" + Environment.NewLine + "Name = ρ Cygni";
            else
            if (ra1 > 21 && ra1 < 22 && dec1 > -20 && dec1 < -10)
                northstar.Text = "Star No = 595" + Environment.NewLine + "Magnitude = 3.8" + Environment.NewLine + "Name = γ Capricorni";
            else
            if (ra1 > 21 && ra1 < 22 && dec1 > -80 && dec1 < -70)
                northstar.Text = "Star No = 596" + Environment.NewLine + "Magnitude = 3.7" + Environment.NewLine + "Name = ν Octantis";
            else
            if (ra1 > 21 && ra1 < 22 && dec1 > 55 && dec1 < 65)
                northstar.Text = "Star No = 597" + Environment.NewLine + "Magnitude = 4.4" + Environment.NewLine + "Name = μ Cephei";
            else
            if (ra1 > 21 && ra1 < 22 && dec1 > 5 && dec1 < 15)
                northstar.Text = "Star No = 598" + Environment.NewLine + "Magnitude = 2.5" + Environment.NewLine + "Name = ε Pegasi";
            else
            if (ra1 > 21 && ra1 < 22 && dec1 > -40 && dec1 < -30)
                northstar.Text = "Star No = 599" + Environment.NewLine + "Magnitude = 4.3" + Environment.NewLine + "Name = l Piscis Aust";
            else
            if (ra1 > 21 && ra1 < 22 && dec1 > 55 && dec1 < 65)
                northstar.Text = "Star No = 600" + Environment.NewLine + "Magnitude = 4.5" + Environment.NewLine + "Name = ν Cephei";
            else
            if (ra1 > 21 && ra1 < 22 && dec1 > -20 && dec1 < -10)
                northstar.Text = "Star No = 601" + Environment.NewLine + "Magnitude = 3.0" + Environment.NewLine + "Name = δ Capricorni";
            else
            if (ra1 > 21 && ra1 < 22 && dec1 > 45 && dec1 < 55)
                northstar.Text = "Star No = 602" + Environment.NewLine + "Magnitude = 4.3" + Environment.NewLine + "Name = π^2 Cygni";
            else
            if (ra1 > 21 && ra1 < 22 && dec1 > -40 && dec1 < -307)
                northstar.Text = "Star No = 603" + Environment.NewLine + "Magnitude = 3.2" + Environment.NewLine + "Name = γ Gruis";
            else
            if (ra1 > 22 && ra1 < 23 && dec1 > -5 && dec1 < 5)
                northstar.Text = "Star No = 604" + Environment.NewLine + "Magnitude = 3.2" + Environment.NewLine + "Name = α Aquarii";
            else
            if (ra1 > 22 && ra1 < 23 && dec1 > -20 && dec1 < 10)
                northstar.Text = "Star No = 605" + Environment.NewLine + "Magnitude = 4.3" + Environment.NewLine + "Name = l Aquarii";
            else
            if (ra1 > 22 && ra1 < 23 && dec1 > 20 && dec1 < 30)
                northstar.Text = "Star No = 606" + Environment.NewLine + "Magnitude = 4.0" + Environment.NewLine + "Name = l Pegasi";
            else
            if (ra1 > 22 && ra1 < 23 && dec1 > -50 && dec1 < -40)
                northstar.Text = "Star No = 607" + Environment.NewLine + "Magnitude = 2.2" + Environment.NewLine + "Name = α Gruis";
            else
            if (ra1 > 22 && ra1 < 23 && dec1 > 30 && dec1 < 40)
                northstar.Text = "Star No = 608" + Environment.NewLine + "Magnitude = 4.4" + Environment.NewLine + "Name = π Pegasi";
            else
            if (ra1 > 22 && ra1 < 23 && dec1 > 0 && dec1 < 10)
                northstar.Text = "Star No = 609" + Environment.NewLine + "Magnitude = 3.7" + Environment.NewLine + "Name = ϑ Pegasi";
            else
            if (ra1 > 22 && ra1 < 23 && dec1 > 55 && dec1 < 65)
                northstar.Text = "Star No = 610" + Environment.NewLine + "Magnitude = 3.6" + Environment.NewLine + "Name = ζ Cephei";
            else
            if (ra1 > 22 && ra1 < 23 && dec1 > -15 && dec1 < -5)
                northstar.Text = "Star No = 611" + Environment.NewLine + "Magnitude = 4.3" + Environment.NewLine + "Name = ϑ Aquarii";
            else
            if (ra1 > 22 && ra1 < 23 && dec1 > -65 && dec1 < -55)
                northstar.Text = "Star No = 612" + Environment.NewLine + "Magnitude = 2.9" + Environment.NewLine + "Name = α Tucanae";
            else
            if (ra1 > 22 && ra1 < 23 && dec1 > -5 && dec1 < 5)
                northstar.Text = "Star No = 613" + Environment.NewLine + "Magnitude = 4.0" + Environment.NewLine + "Name = γ Aquarii";
            else
            if (ra1 > 22 && ra1 < 23 && dec1 > -5 && dec1 < 5)
                northstar.Text = "Star No = 614" + Environment.NewLine + "Magnitude = 3.7" + Environment.NewLine + "Name = ζ Aquarii";
            else
            if (ra1 > 22 && ra1 < 23 && dec1 > -50 && dec1 < -40)
                northstar.Text = "Star No = 615" + Environment.NewLine + "Magnitude = 4.0" + Environment.NewLine + "Name = δ^1 Gruis";
            else
            if (ra1 > 22 && ra1 < 23 && dec1 > 55 && dec1 < 65)
                northstar.Text = "Star No = 616" + Environment.NewLine + "Magnitude = 4.0" + Environment.NewLine + "Name = δ Cephei";
            else
            if (ra1 > 22 && ra1 < 23 && dec1 > -35 && dec1 < -25)
                northstar.Text = "Star No = 617" + Environment.NewLine + "Magnitude = 4.4" + Environment.NewLine + "Name = β Pisci Aust";
            else
            if (ra1 > 22 && ra1 < 23 && dec1 > 45 && dec1 < 55)
                northstar.Text = "Star No = 618" + Environment.NewLine + "Magnitude = 3.8" + Environment.NewLine + "Name = α Lacertae";
            else
            if (ra1 > 22 && ra1 < 23 && dec1 > -5 && dec1 < 5)
                northstar.Text = "Star No = 619" + Environment.NewLine + "Magnitude = 4.1" + Environment.NewLine + "Name = η Aquarii";
            else
            if (ra1 > 22 && ra1 < 23 && dec1 > -30 && dec1 < -20)
                northstar.Text = "Star No = 620" + Environment.NewLine + "Magnitude = 4.2" + Environment.NewLine + "Name = ε Piscis Aust";
            else
            if (ra1 > 22 && ra1 < 23 && dec1 > 5 && dec1 < 15)
                northstar.Text = "Star No = 621" + Environment.NewLine + "Magnitude = 3.6" + Environment.NewLine + "Name = ζ Pegasi";
            else
            if (ra1 > 22 && ra1 < 23 && dec1 > -50 && dec1 < -40)
                northstar.Text = "Star No = 622" + Environment.NewLine + "Magnitude = 2.2" + Environment.NewLine + "Name = β Gruis";
            else
            if (ra1 > 22 && ra1 < 23 && dec1 > 25 && dec1 < 35)
                northstar.Text = "Star No = 623" + Environment.NewLine + "Magnitude = 3.1" + Environment.NewLine + "Name = η Pegasi";
            else
            if (ra1 > 22 && ra1 < 23 && dec1 > -25 && dec1 < -15)
                northstar.Text = "Star No = 624" + Environment.NewLine + "Magnitude = 4.3" + Environment.NewLine + "Name = β Octantis";
            else
            if (ra1 > 22 && ra1 < 23 && dec1 > 20 && dec1 < 30)
                northstar.Text = "Star No = 625" + Environment.NewLine + "Magnitude = 4.1" + Environment.NewLine + "Name = λ Pegasi";
            else
            if (ra1 > 22 && ra1 < 23 && dec1 > -55 && dec1 < -45)
                northstar.Text = "Star No = 626" + Environment.NewLine + "Magnitude = 3.7" + Environment.NewLine + "Name = ε Gruis";
            else
            if (ra1 > 22 && ra1 < 23 && dec1 > -20 && dec1 < -10)
                northstar.Text = "Star No = 627" + Environment.NewLine + "Magnitude = 4.2" + Environment.NewLine + "Name = τ Aquarii";
            else
            if (ra1 > 22 && ra1 < 23 && dec1 > 60 && dec1 < 70)
                northstar.Text = "Star No = 628" + Environment.NewLine + "Magnitude = 3.7" + Environment.NewLine + "Name = l Cephei";
            else
            if (ra1 > 22 && ra1 < 23 && dec1 > 20 && dec1 < 30)
                northstar.Text = "Star No = 629" + Environment.NewLine + "Magnitude = 3.7" + Environment.NewLine + "Name = μ Pegasi";
            else
            if (ra1 > 22 && ra1 < 23 && dec1 > -10 && dec1 < 0)
                northstar.Text = "Star No = 630" + Environment.NewLine + "Magnitude = 3.8" + Environment.NewLine + "Name = λ Aquarii";
            else
            if (ra1 > 22 && ra1 < 23 && dec1 > -20 && dec1 < -10)
                northstar.Text = "Star No = 631" + Environment.NewLine + "Magnitude = 3.5" + Environment.NewLine + "Name = δ Aquarii";
            else
            if (ra1 > 22 && ra1 < 23 && dec1 > -35 && dec1 < -25)
                northstar.Text = "Star No = 632" + Environment.NewLine + "Magnitude = d 1.3" + Environment.NewLine + "Name = Fomalhaut (α PsA)";
            else
            if (ra1 > 22 && ra1 < 23 && dec1 > -60 && dec1 < -50)
                northstar.Text = "Star No = 633" + Environment.NewLine + "Magnitude = 4.2" + Environment.NewLine + "Name = ζ Gruis";
            else
            if (ra1 > 22 && ra1 < 23 && dec1 > 40 && dec1 < 50)
                northstar.Text = "Star No = 634" + Environment.NewLine + "Magnitude = 3.6" + Environment.NewLine + "Name = ο Andromedae";
            else
            if (ra1 > 22 && ra1 < 23 && dec1 > 25 && dec1 < 35)
                northstar.Text = "Star No = 635" + Environment.NewLine + "Magnitude = 2.6" + Environment.NewLine + "Name = β Pegasi";
            else
            if (ra1 > 22 && ra1 < 23 && dec1 > 10 && dec1 < 20)
                northstar.Text = "Star No = 636" + Environment.NewLine + "Magnitude = 2.6" + Environment.NewLine + "Name = α Pegasi";
            else
            if (ra1 > 23 && ra1 < 24 && dec1 > -25 && dec1 < -15)
                northstar.Text = "Star No = 637" + Environment.NewLine + "Magnitude = 3.8" + Environment.NewLine + "Name = 88 Aquarii";
            else
            if (ra1 > 23 && ra1 < 24 && dec1 > -50 && dec1 < -40)
                northstar.Text = "Star No = 638" + Environment.NewLine + "Magnitude = 4.1" + Environment.NewLine + "Name = l Gruis";
            else
            if (ra1 > 23 && ra1 < 24 && dec1 > -10 && dec1 < 0)
                northstar.Text = "Star No = 639" + Environment.NewLine + "Magnitude = 4.4" + Environment.NewLine + "Name = φ Aquarii";
            else
            if (ra1 > 23 && ra1 < 24 && dec1 > 0 && dec1 < 10)
                northstar.Text = "Star No = 640" + Environment.NewLine + "Magnitude = 3.8" + Environment.NewLine + "Name = γ Piscium";
            else
            if (ra1 > 23 && ra1 < 24 && dec1 > -65 && dec1 < -55)
                northstar.Text = "Star No = 641" + Environment.NewLine + "Magnitude = 4.1" + Environment.NewLine + "Name = γ Tucanae";
            else
            if (ra1 > 23 && ra1 < 24 && dec1 > -25 && dec1 < -15)
                northstar.Text = "Star No = 642" + Environment.NewLine + "Magnitude = 4.2" + Environment.NewLine + "Name = 98 Aquarii";
            else
            if (ra1 > 23 && ra1 < 24 && dec1 > 0 && dec1 < 10)
                northstar.Text = "Star No = 643" + Environment.NewLine + "Magnitude = 4.4" + Environment.NewLine + "Name = ϑ Piscium";
            else
            if (ra1 > 23 && ra1 < 24 && dec1 > -45 && dec1 < -35)
                northstar.Text = "Star No = 644" + Environment.NewLine + "Magnitude = 4.5" + Environment.NewLine + "Name = β Sculptoris";
            else
            if (ra1 > 23 && ra1 < 24 && dec1 > 40 && dec1 < 50)
                northstar.Text = "Star No = 645" + Environment.NewLine + "Magnitude = 4.0" + Environment.NewLine + "Name = λ Andromedae";
            else
            if (ra1 > 23 && ra1 < 24 && dec1 > 40 && dec1 < 50)
                northstar.Text = "Star No = 646" + Environment.NewLine + "Magnitude = 4.3" + Environment.NewLine + "Name = l Andromedae";
            else
            if (ra1 > 23 && ra1 < 24 && dec1 > 75 && dec1 < 85)
                northstar.Text = "Star No = 647" + Environment.NewLine + "Magnitude = 3.4" + Environment.NewLine + "Name = γ Cephei";
            else
            if (ra1 > 23 && ra1 < 24 && dec1 > 0 && dec1 < 10)
                northstar.Text = "Star No = 648" + Environment.NewLine + "Magnitude = 4.3" + Environment.NewLine + "Name = l Piscium";
            else
            if (ra1 > 23 && ra1 < 24 && dec1 > 40 && dec1 < 50)
                northstar.Text = "Star No = 649" + Environment.NewLine + "Magnitude = 4.3" + Environment.NewLine + "Name = Κ Andromedae";
            else
            if (ra1 > 0 && ra1 < 1 && dec1 > 0 && dec1 < 10)
                northstar.Text = "Star No = 650" + Environment.NewLine + "Magnitude = 4.0" + Environment.NewLine + "Name = ω Piscium";
            else
            if (ra1 > 0 && ra1 < 1 && dec1 > 70 && dec1 < 80)
                northstar.Text = "Star No = 651" + Environment.NewLine + "Magnitude = 5.4" + Environment.NewLine + "Name = 23 Cassiopeiae";
            else
            if (ra1 > 1 && ra1 < 3 && dec1 > 70 && dec1 < 80)
                northstar.Text = "Star No = 652" + Environment.NewLine + "Magnitude = 5.2" + Environment.NewLine + "Name = 49 Cassiopeiae";
            else
            if (ra1 > 3 && ra1 < 4 && dec1 > 75 && dec1 < 85)
                northstar.Text = "Star No = 653" + Environment.NewLine + "Magnitude = 5.5" + Environment.NewLine + "Name = BS 0961 (Cephei)";
            else
            if (ra1 > 4 && ra1 < 5 && dec1 > 75 && dec1 < 85)
                northstar.Text = "Star No = 654" + Environment.NewLine + "Magnitude = 5.2" + Environment.NewLine + "Name = BS 1230 (Cephei)";
            else
            if (ra1 > 5 && ra1 < 6 && dec1 > 75 && dec1 < 85)
                northstar.Text = "Star No = 655" + Environment.NewLine + "Magnitude = 5.1" + Environment.NewLine + "Name = BS 1523 (Cephei)";
            else
            if (ra1 > 5 && ra1 < 6 && dec1 > 75 && dec1 < 85)
                northstar.Text = "Star No = 656" + Environment.NewLine + "Magnitude = 5.2" + Environment.NewLine + "Name = BS 1686 (Cam)";
            else
            if (ra1 > 7 && ra1 < 8 && dec1 > 70 && dec1 < 80)
                northstar.Text = "Star No = 657" + Environment.NewLine + "Magnitude = 4.7" + Environment.NewLine + "Name = BS 2527 (Cam)";
            else
            if (ra1 > 8 && ra1 < 9 && dec1 > 75 && dec1 < 85)
                northstar.Text = "Star No = 658" + Environment.NewLine + "Magnitude = 5.3" + Environment.NewLine + "Name = BS 3082 (Cam)";
            else
            if (ra1 > 9 && ra1 < 10 && dec1 > 75 && dec1 < 85)
                northstar.Text = "Star No = 659" + Environment.NewLine + "Magnitude = 4.6" + Environment.NewLine + "Name = BS 3751 (Draconis)";
            else
            if (ra1 > 10 && ra1 < 11 && dec1 > 70 && dec1 < 80)
                northstar.Text = "Star No = 660" + Environment.NewLine + "Magnitude = 5.0" + Environment.NewLine + "Name = BS 4126 (Draconis)";
            else
            if (ra1 > 12 && ra1 < 13 && dec1 > 75 && dec1 < 85)
                northstar.Text = "Star No = 661" + Environment.NewLine + "Magnitude = 5.1" + Environment.NewLine + "Name = BS 4646 (Cam)";
            else
            if (ra1 > 12 && ra1 < 13 && dec1 > 80 && dec1 < 90)
                northstar.Text = "Star No = 662" + Environment.NewLine + "Magnitude = 5.3" + Environment.NewLine + "Name = BS 4893 (Cam)";
            else
            if (ra1 > 14 && ra1 < 15 && dec1 > 70 && dec1 < 80)
                northstar.Text = "Star No = 663" + Environment.NewLine + "Magnitude = 5.0" + Environment.NewLine + "Name = 4 Ursae Minoris";
            else
            if (ra1 > 16 && ra1 < 17 && dec1 > 70 && dec1 < 80)
                northstar.Text = "Star No = 664" + Environment.NewLine + "Magnitude = 5.0" + Environment.NewLine + "Name = η Ursae Minoris";
            else
            if (ra1 > 17 && ra1 < 18 && dec1 > 70 && dec1 < 80)
                northstar.Text = "Star No = 665" + Environment.NewLine + "Magnitude = 5.0" + Environment.NewLine + "Name = 35 Draconis";
            else
            if (ra1 > 19 && ra1 < 20 && dec1 > 70 && dec1 < 80)
                northstar.Text = "Star No = 666" + Environment.NewLine + "Magnitude = 5.1" + Environment.NewLine + "Name = 59 Draconis";
            else
            if (ra1 > 20 && ra1 < 21 && dec1 > 70 && dec1 < 80)
                northstar.Text = "Star No = 667" + Environment.NewLine + "Magnitude = 5.2" + Environment.NewLine + "Name = 73 Draconis";
            else
            if (ra1 > 22 && ra1 < 23 && dec1 > 80 && dec1 < 90)
                northstar.Text = "Star No = 668" + Environment.NewLine + "Magnitude = 4.8" + Environment.NewLine + "Name = BS 8702 (Cephei)";
            else
            if (ra1 > 23 && ra1 < 24 && dec1 > 70 && dec1 < 80)
                northstar.Text = "Star No = 669" + Environment.NewLine + "Magnitude = 4.5" + Environment.NewLine + "Name = π Cephei";
            else
            if (ra1 > 0 && ra1 < 1 && dec1 > -80 && dec1 < -70)
                northstar.Text = "Star No = 670" + Environment.NewLine + "Magnitude = 4.7" + Environment.NewLine + "Name = ϑ Octantis";
            else
            if (ra1 > 2 && ra1 < 3 && dec1 > -80 && dec1 < -70)
                northstar.Text = "Star No = 671" + Environment.NewLine + "Magnitude = 4.7" + Environment.NewLine + "Name = ν Hydri";
            else
            if (ra1 > 6 && ra1 < 7 && dec1 > -80 && dec1 < -70)
                northstar.Text = "Star No = 672" + Environment.NewLine + "Magnitude = 5.1" + Environment.NewLine + "Name = α Mensae";
            else
            if (ra1 > 8 && ra1 < 9 && dec1 > -80 && dec1 < -70)
                northstar.Text = "Star No = 673" + Environment.NewLine + "Magnitude = 4.1" + Environment.NewLine + "Name = α Chamaeleontis";
            else
            if (ra1 > 9 && ra1 < 10 && dec1 > -85 && dec1 < -75)
                northstar.Text = "Star No = 674" + Environment.NewLine + "Magnitude = 5.2" + Environment.NewLine + "Name = ζ Chamaeleontis";
            else
            if (ra1 > 10 && ra1 < 11 && dec1 > -85 && dec1 < -75)
                northstar.Text = "Star No = 675" + Environment.NewLine + "Magnitude = 4.6" + Environment.NewLine + "Name = δ^2 Chamaeleontis";
            else
            if (ra1 > 12 && ra1 < 13 && dec1 > -85 && dec1 < -75)
                northstar.Text = "Star No = 676" + Environment.NewLine + "Magnitude = 4.9" + Environment.NewLine + "Name = ε Chamaeleontis";
            else
            if (ra1 > 12 && ra1 < 13 && dec1 > -80 && dec1 < -70)
                northstar.Text = "Star No = 677" + Environment.NewLine + "Magnitude = 5.0" + Environment.NewLine + "Name = Κ Chamaeleontis";
            else
            if (ra1 > 13 && ra1 < 14 && dec1 > -80 && dec1 < -70)
                northstar.Text = "Star No = 678" + Environment.NewLine + "Magnitude = 5.0" + Environment.NewLine + "Name = l^1 Muscae";
            else
            if (ra1 > 14 && ra1 < 15 && dec1 > -85 && dec1 < -75)
                northstar.Text = "Star No = 679" + Environment.NewLine + "Magnitude = 4.9" + Environment.NewLine + "Name = η Apodis";
            else
            if (ra1 > 14 && ra1 < 15 && dec1 > -90 && dec1 < -80)
                northstar.Text = "Star No = 680" + Environment.NewLine + "Magnitude = 4.3" + Environment.NewLine + "Name = δ Octantis";
            else
            if (ra1 > 14 && ra1 < 15 && dec1 > -80 && dec1 < -70)
                northstar.Text = "Star No = 681" + Environment.NewLine + "Magnitude = 5.0" + Environment.NewLine + "Name = R Apodis";
            else
            if (ra1 > 16 && ra1 < 17 && dec1 > -85 && dec1 < -75)
                northstar.Text = "Star No = 682" + Environment.NewLine + "Magnitude = 4.8" + Environment.NewLine + "Name = δ^1 Apodis";
            else
            if (ra1 > 16 && ra1 < 17 && dec1 > -85 && dec1 < -75)
                northstar.Text = "Star No = 683" + Environment.NewLine + "Magnitude = 4.3" + Environment.NewLine + "Name = β Apodis";
            else
            if (ra1 > 21 && ra1 < 22 && dec1 > -80 && dec1 < -70)
                northstar.Text = "Star No = 684" + Environment.NewLine + "Magnitude = 5.2" + Environment.NewLine + "Name = α Octantis";
            else
            if (ra1 > 22 && ra1 < 23 && dec1 > -85 && dec1 < -75)
                northstar.Text = "Star No = 685" + Environment.NewLine + "Magnitude = 5.1" + Environment.NewLine + "Name = ε Octantis";
            else
                northstar.Text = "Could Not Identify Star";



        }

        private void meanh_TextChanged(object sender, EventArgs e)
        {

        }

        private void dec_TextChanged(object sender, EventArgs e)
        {

        }

        private void t_TextChanged(object sender, EventArgs e)
        {

        }

        private void ET_TextChanged(object sender, EventArgs e)
        {

        }

        private void ra_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void tb_TextChanged(object sender, EventArgs e)
        {

        }

        private void r_TextChanged(object sender, EventArgs e)
        {

        }

        private void lat_TextChanged(object sender, EventArgs e)
        {

        }

        private void along_TextChanged(object sender, EventArgs e)
        {

        }

        private void w1_TextChanged(object sender, EventArgs e)
        {

        }

        private void w2_TextChanged(object sender, EventArgs e)
        {

        }

        private void r0_TextChanged(object sender, EventArgs e)
        {

        }

        private void f_TextChanged(object sender, EventArgs e)
        {

        }

        private void deg_TextChanged(object sender, EventArgs e)
        {

        }

        private void total_TextChanged(object sender, EventArgs e)
        {

        }

        private void computeSec_Click(object sender, EventArgs e)
        {
            total.Text = ((double.Parse(deg.Text)) + (double.Parse(min.Text) / 60) + (double.Parse(sec.Text) / 3600)).ToString();
        }

        private void clearInput_Click(object sender, EventArgs e)
        {

        }

        private void back2_Click(object sender, EventArgs e)
        {
            this.Hide();
            f1 f1 = new f1();
            f1.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
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

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void computationalResultForEastSun_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void inputgrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void clearGrid_Click(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
