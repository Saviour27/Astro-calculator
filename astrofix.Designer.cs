using System;

namespace AstronomicalComputations
{
    partial class Form9
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
            this.equalaltitudemethod = new System.Windows.Forms.Button();
            this.back2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // equalaltitudemethod
            // 
            this.equalaltitudemethod.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.equalaltitudemethod.Location = new System.Drawing.Point(31, 190);
            this.equalaltitudemethod.Margin = new System.Windows.Forms.Padding(4);
            this.equalaltitudemethod.Name = "equalaltitudemethod";
            this.equalaltitudemethod.Size = new System.Drawing.Size(342, 61);
            this.equalaltitudemethod.TabIndex = 0;
            this.equalaltitudemethod.Text = "TIMED ALTITUDE OF QUADRANTAL STARS";
            this.equalaltitudemethod.UseVisualStyleBackColor = true;
            this.equalaltitudemethod.Click += new System.EventHandler(this.equalaltitudemethod_Click_1);
            // 
            // back2
            // 
            this.back2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.back2.Location = new System.Drawing.Point(275, 378);
            this.back2.Margin = new System.Windows.Forms.Padding(4);
            this.back2.Name = "back2";
            this.back2.Size = new System.Drawing.Size(112, 45);
            this.back2.TabIndex = 2;
            this.back2.Text = "BACK";
            this.back2.UseVisualStyleBackColor = true;
            this.back2.Click += new System.EventHandler(this.back2_Click);
            // 
            // Form9
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::AstronomicalComputations.Properties.Resources._1_radisson_blu_nigeria_vol1_main;
            this.ClientSize = new System.Drawing.Size(400, 445);
            this.Controls.Add(this.back2);
            this.Controls.Add(this.equalaltitudemethod);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form9";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ASTRO FIX";
            this.Load += new System.EventHandler(this.Form9_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button equalaltitudemethod;
        private System.Windows.Forms.Button back2;
    }
}