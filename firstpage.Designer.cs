namespace AstronomicalComputations
{
    partial class f1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.azimuth = new System.Windows.Forms.Button();
            this.latitude = new System.Windows.Forms.Button();
            this.longitude = new System.Windows.Forms.Button();
            this.astro = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // azimuth
            // 
            this.azimuth.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.azimuth.ForeColor = System.Drawing.SystemColors.Desktop;
            this.azimuth.Location = new System.Drawing.Point(14, 128);
            this.azimuth.Name = "azimuth";
            this.azimuth.Size = new System.Drawing.Size(288, 58);
            this.azimuth.TabIndex = 0;
            this.azimuth.Text = "AZIMUTH COMPUTATION";
            this.azimuth.UseVisualStyleBackColor = true;
            this.azimuth.Click += new System.EventHandler(this.azimuth_Click);
            // 
            // latitude
            // 
            this.latitude.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.latitude.ForeColor = System.Drawing.SystemColors.Desktop;
            this.latitude.Location = new System.Drawing.Point(146, 218);
            this.latitude.Name = "latitude";
            this.latitude.Size = new System.Drawing.Size(288, 58);
            this.latitude.TabIndex = 1;
            this.latitude.Text = "LATITUDE COMPUTATION";
            this.latitude.UseVisualStyleBackColor = true;
            this.latitude.Click += new System.EventHandler(this.latitude_Click);
            // 
            // longitude
            // 
            this.longitude.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.longitude.ForeColor = System.Drawing.SystemColors.Desktop;
            this.longitude.Location = new System.Drawing.Point(14, 306);
            this.longitude.Name = "longitude";
            this.longitude.Size = new System.Drawing.Size(308, 58);
            this.longitude.TabIndex = 2;
            this.longitude.Text = "LONGITUDE COMPUTATION";
            this.longitude.UseVisualStyleBackColor = true;
            this.longitude.Click += new System.EventHandler(this.longitude_Click);
            // 
            // astro
            // 
            this.astro.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.astro.ForeColor = System.Drawing.SystemColors.Desktop;
            this.astro.Location = new System.Drawing.Point(138, 393);
            this.astro.Name = "astro";
            this.astro.Size = new System.Drawing.Size(296, 58);
            this.astro.TabIndex = 3;
            this.astro.Text = "ASTRO FIX COMPUTATION";
            this.astro.UseVisualStyleBackColor = true;
            this.astro.Click += new System.EventHandler(this.astro_Click);
            // 
            // button1
            // 
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.button1.Location = new System.Drawing.Point(146, 41);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(288, 58);
            this.button1.TabIndex = 6;
            this.button1.Text = "STAR IDENTIFICATION";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // f1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::AstronomicalComputations.Properties.Resources._1_radisson_blu_nigeria_vol1_main;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(460, 474);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.astro);
            this.Controls.Add(this.longitude);
            this.Controls.Add(this.latitude);
            this.Controls.Add(this.azimuth);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Location = new System.Drawing.Point(50, 50);
            this.MaximizeBox = false;
            this.Name = "f1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ASTRO-LAB";
            this.Load += new System.EventHandler(this.f1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button azimuth;
        private System.Windows.Forms.Button latitude;
        private System.Windows.Forms.Button longitude;
        private System.Windows.Forms.Button astro;
        private System.Windows.Forms.Button button1;
    }
}

