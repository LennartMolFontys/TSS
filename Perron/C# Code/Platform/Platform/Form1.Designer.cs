﻿namespace Platform
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.idLabel = new System.Windows.Forms.Label();
            this.Unit1LB = new System.Windows.Forms.Label();
            this.Unit2LB = new System.Windows.Forms.Label();
            this.Unit3Lb = new System.Windows.Forms.Label();
            this.Unit4Lb = new System.Windows.Forms.Label();
            this.Unit5Lb = new System.Windows.Forms.Label();
            this.Unit6Lb = new System.Windows.Forms.Label();
            this.Unit7Lb = new System.Windows.Forms.Label();
            this.Unit8Lb = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(23, 75);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(788, 127);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Train ID:";
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.Location = new System.Drawing.Point(100, 43);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(0, 17);
            this.idLabel.TabIndex = 3;
            // 
            // Unit1LB
            // 
            this.Unit1LB.AutoSize = true;
            this.Unit1LB.Location = new System.Drawing.Point(77, 179);
            this.Unit1LB.Name = "Unit1LB";
            this.Unit1LB.Size = new System.Drawing.Size(16, 17);
            this.Unit1LB.TabIndex = 4;
            this.Unit1LB.Text = "0";
            // 
            // Unit2LB
            // 
            this.Unit2LB.AutoSize = true;
            this.Unit2LB.Location = new System.Drawing.Point(202, 179);
            this.Unit2LB.Name = "Unit2LB";
            this.Unit2LB.Size = new System.Drawing.Size(16, 17);
            this.Unit2LB.TabIndex = 5;
            this.Unit2LB.Text = "0";
            // 
            // Unit3Lb
            // 
            this.Unit3Lb.AutoSize = true;
            this.Unit3Lb.Location = new System.Drawing.Point(289, 179);
            this.Unit3Lb.Name = "Unit3Lb";
            this.Unit3Lb.Size = new System.Drawing.Size(16, 17);
            this.Unit3Lb.TabIndex = 6;
            this.Unit3Lb.Text = "0";
            // 
            // Unit4Lb
            // 
            this.Unit4Lb.AutoSize = true;
            this.Unit4Lb.Location = new System.Drawing.Point(362, 179);
            this.Unit4Lb.Name = "Unit4Lb";
            this.Unit4Lb.Size = new System.Drawing.Size(16, 17);
            this.Unit4Lb.TabIndex = 7;
            this.Unit4Lb.Text = "0";
            // 
            // Unit5Lb
            // 
            this.Unit5Lb.AutoSize = true;
            this.Unit5Lb.Location = new System.Drawing.Point(451, 179);
            this.Unit5Lb.Name = "Unit5Lb";
            this.Unit5Lb.Size = new System.Drawing.Size(16, 17);
            this.Unit5Lb.TabIndex = 8;
            this.Unit5Lb.Text = "0";
            // 
            // Unit6Lb
            // 
            this.Unit6Lb.AutoSize = true;
            this.Unit6Lb.Location = new System.Drawing.Point(545, 179);
            this.Unit6Lb.Name = "Unit6Lb";
            this.Unit6Lb.Size = new System.Drawing.Size(16, 17);
            this.Unit6Lb.TabIndex = 9;
            this.Unit6Lb.Text = "0";
            // 
            // Unit7Lb
            // 
            this.Unit7Lb.AutoSize = true;
            this.Unit7Lb.Location = new System.Drawing.Point(623, 179);
            this.Unit7Lb.Name = "Unit7Lb";
            this.Unit7Lb.Size = new System.Drawing.Size(16, 17);
            this.Unit7Lb.TabIndex = 10;
            this.Unit7Lb.Text = "0";
            // 
            // Unit8Lb
            // 
            this.Unit8Lb.AutoSize = true;
            this.Unit8Lb.Location = new System.Drawing.Point(725, 179);
            this.Unit8Lb.Name = "Unit8Lb";
            this.Unit8Lb.Size = new System.Drawing.Size(16, 17);
            this.Unit8Lb.TabIndex = 11;
            this.Unit8Lb.Text = "0";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(837, 238);
            this.Controls.Add(this.Unit8Lb);
            this.Controls.Add(this.Unit7Lb);
            this.Controls.Add(this.Unit6Lb);
            this.Controls.Add(this.Unit5Lb);
            this.Controls.Add(this.Unit4Lb);
            this.Controls.Add(this.Unit3Lb);
            this.Controls.Add(this.Unit2LB);
            this.Controls.Add(this.Unit1LB);
            this.Controls.Add(this.idLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.Label Unit1LB;
        private System.Windows.Forms.Label Unit2LB;
        private System.Windows.Forms.Label Unit3Lb;
        private System.Windows.Forms.Label Unit4Lb;
        private System.Windows.Forms.Label Unit5Lb;
        private System.Windows.Forms.Label Unit6Lb;
        private System.Windows.Forms.Label Unit7Lb;
        private System.Windows.Forms.Label Unit8Lb;
        private System.Windows.Forms.Timer timer1;
    }
}

