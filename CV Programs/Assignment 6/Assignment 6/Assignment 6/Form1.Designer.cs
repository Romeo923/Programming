
namespace Assignment_6
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
            this.panShape1 = new System.Windows.Forms.PictureBox();
            this.panShape2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.panShape1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panShape2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // panShape1
            // 
            this.panShape1.Location = new System.Drawing.Point(67, 62);
            this.panShape1.Name = "panShape1";
            this.panShape1.Size = new System.Drawing.Size(254, 407);
            this.panShape1.TabIndex = 0;
            this.panShape1.TabStop = false;
            // 
            // panShape2
            // 
            this.panShape2.Location = new System.Drawing.Point(441, 62);
            this.panShape2.Name = "panShape2";
            this.panShape2.Size = new System.Drawing.Size(254, 407);
            this.panShape2.TabIndex = 1;
            this.panShape2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(801, 62);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(254, 407);
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1144, 692);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.panShape2);
            this.Controls.Add(this.panShape1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.panShape1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panShape2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox panShape1;
        private System.Windows.Forms.PictureBox panShape2;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}

