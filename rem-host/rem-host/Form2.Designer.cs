
namespace rem_host
{
    partial class Form2
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cliM_pointX = new System.Windows.Forms.Label();
            this.cliM_pointY = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(800, 450);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // cliM_pointX
            // 
            this.cliM_pointX.AutoSize = true;
            this.cliM_pointX.Location = new System.Drawing.Point(728, 13);
            this.cliM_pointX.Name = "cliM_pointX";
            this.cliM_pointX.Size = new System.Drawing.Size(35, 13);
            this.cliM_pointX.TabIndex = 1;
            this.cliM_pointX.Text = "label1";
            // 
            // cliM_pointY
            // 
            this.cliM_pointY.AutoSize = true;
            this.cliM_pointY.Location = new System.Drawing.Point(728, 36);
            this.cliM_pointY.Name = "cliM_pointY";
            this.cliM_pointY.Size = new System.Drawing.Size(35, 13);
            this.cliM_pointY.TabIndex = 2;
            this.cliM_pointY.Text = "label2";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cliM_pointY);
            this.Controls.Add(this.cliM_pointX);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label cliM_pointX;
        private System.Windows.Forms.Label cliM_pointY;
    }
}