
namespace Assignment_5
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.panShape1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panShape2)).BeginInit();
            this.SuspendLayout();
            // 
            // panShape1
            // 
            this.panShape1.Cursor = System.Windows.Forms.Cursors.Default;
            this.panShape1.Location = new System.Drawing.Point(106, 33);
            this.panShape1.Name = "panShape1";
            this.panShape1.Size = new System.Drawing.Size(438, 640);
            this.panShape1.TabIndex = 0;
            this.panShape1.TabStop = false;
            // 
            // panShape2
            // 
            this.panShape2.Location = new System.Drawing.Point(634, 33);
            this.panShape2.Name = "panShape2";
            this.panShape2.Size = new System.Drawing.Size(438, 640);
            this.panShape2.TabIndex = 1;
            this.panShape2.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(198, 679);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(252, 57);
            this.button1.TabIndex = 2;
            this.button1.Text = "Initialize Shapes";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(737, 679);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(252, 57);
            this.button2.TabIndex = 3;
            this.button2.Text = "Apply Transformation";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1152, 765);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panShape2);
            this.Controls.Add(this.panShape1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.panShape1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panShape2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox panShape1;
        private System.Windows.Forms.PictureBox panShape2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

