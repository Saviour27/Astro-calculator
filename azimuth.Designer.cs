namespace AstronomicalComputations
{
    partial class f2
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
            this.eastWestSun = new System.Windows.Forms.Button();
            this.back1 = new System.Windows.Forms.Button();
            this.angleOfPolaris = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // eastWestSun
            // 
            this.eastWestSun.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eastWestSun.ForeColor = System.Drawing.SystemColors.Desktop;
            this.eastWestSun.Location = new System.Drawing.Point(85, 44);
            this.eastWestSun.Name = "eastWestSun";
            this.eastWestSun.Size = new System.Drawing.Size(301, 58);
            this.eastWestSun.TabIndex = 1;
            this.eastWestSun.Text = "ALTITUDE OF EAST WEST SUN";
            this.eastWestSun.UseVisualStyleBackColor = true;
            this.eastWestSun.Click += new System.EventHandler(this.eastWestSun_Click);
            // 
            // back1
            // 
            this.back1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.back1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.back1.Location = new System.Drawing.Point(359, 360);
            this.back1.Name = "back1";
            this.back1.Size = new System.Drawing.Size(89, 38);
            this.back1.TabIndex = 4;
            this.back1.Text = "Back";
            this.back1.UseVisualStyleBackColor = true;
            this.back1.Click += new System.EventHandler(this.back1_Click);
            // 
            // angleOfPolaris
            // 
            this.angleOfPolaris.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.angleOfPolaris.ForeColor = System.Drawing.SystemColors.Desktop;
            this.angleOfPolaris.Location = new System.Drawing.Point(85, 144);
            this.angleOfPolaris.Name = "angleOfPolaris";
            this.angleOfPolaris.Size = new System.Drawing.Size(301, 58);
            this.angleOfPolaris.TabIndex = 2;
            this.angleOfPolaris.Text = "HOUR ANGLE OF POLARIS";
            this.angleOfPolaris.UseVisualStyleBackColor = true;
            this.angleOfPolaris.Click += new System.EventHandler(this.angleOfPolaris_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.button1.Location = new System.Drawing.Point(70, 252);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(329, 58);
            this.button1.TabIndex = 5;
            this.button1.Text = "ALTITUDE OF EAST WEST STARS";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // f2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::AstronomicalComputations.Properties.Resources._1_radisson_blu_nigeria_vol1_main;
            this.ClientSize = new System.Drawing.Size(460, 419);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.back1);
            this.Controls.Add(this.angleOfPolaris);
            this.Controls.Add(this.eastWestSun);
            this.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Location = new System.Drawing.Point(50, 50);
            this.MaximizeBox = false;
            this.Name = "f2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AZIMUTH COMPUTATION";
            this.Load += new System.EventHandler(this.f2_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button eastWestSun;
        private System.Windows.Forms.Button angleOfPolaris;
        private System.Windows.Forms.Button back1;
        private System.Windows.Forms.Button button1;
    }
}