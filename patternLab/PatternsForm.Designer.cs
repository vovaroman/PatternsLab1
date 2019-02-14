using System;
using System.Windows.Forms;

namespace patternLab
{
    partial class PatternsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private Timer Timer = new Timer();

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
            this.SuspendLayout();
            // 
            // PatternsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(5F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 881);
            this.Name = "PatternsForm";
            this.Text = "Patterns";
            this.Load += new System.EventHandler(this.PatternsForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.PatternsForm_Paint);
            this.Timer.Enabled = true;
            this.Timer.Tick += new System.EventHandler(this.OnTimer);
            this.Timer.Interval = 10;
            this.DoubleBuffered = true;
            
            //this.Timer.Start();
            this.ResumeLayout(false);

        }




        #endregion
    }
}

