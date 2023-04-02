namespace AstronomicalComputations
{
    partial class Form8
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
            this.altitudeofeastweststar = new System.Windows.Forms.Button();
            this.back1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // altitudeofeastweststar
            // 
            this.altitudeofeastweststar.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.altitudeofeastweststar.Location = new System.Drawing.Point(14, 194);
            this.altitudeofeastweststar.Name = "altitudeofeastweststar";
            this.altitudeofeastweststar.Size = new System.Drawing.Size(351, 51);
            this.altitudeofeastweststar.TabIndex = 0;
            this.altitudeofeastweststar.Text = "TIMED ALTITUDE OF EAST AND WEST STARS";
            this.altitudeofeastweststar.UseVisualStyleBackColor = true;
            this.altitudeofeastweststar.Click += new System.EventHandler(this.altitudeofeastweststar_Click);
            // 
            // back1
            // 
            this.back1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.back1.Location = new System.Drawing.Point(278, 388);
            this.back1.Name = "back1";
            this.back1.Size = new System.Drawing.Size(87, 43);
            this.back1.TabIndex = 1;
            this.back1.Text = "BACK";
            this.back1.UseVisualStyleBackColor = true;
            this.back1.Click += new System.EventHandler(this.back1_Click);
            // 
            // Form8
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::AstronomicalComputations.Properties.Resources._1_radisson_blu_nigeria_vol1_main;
            this.ClientSize = new System.Drawing.Size(390, 440);
            this.Controls.Add(this.back1);
            this.Controls.Add(this.altitudeofeastweststar);
            this.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Form8";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LONGITUDE COMPUTATION";
            this.Load += new System.EventHandler(this.Form8_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button altitudeofeastweststar;
        private System.Windows.Forms.Button back1;
    }
}