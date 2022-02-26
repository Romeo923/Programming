
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
            this.panShape3 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.panShape1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panShape2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panShape3)).BeginInit();
            this.SuspendLayout();
            // 
            // panShape1
            // 
            this.panShape1.Location = new System.Drawing.Point(67, 62);
            this.panShape1.Name = "panShape1";
            this.panShape1.Size = new System.Drawing.Size(276, 407);
            this.panShape1.TabIndex = 0;
            this.panShape1.TabStop = false;
            // 
            // panShape2
            // 
            this.panShape2.Location = new System.Drawing.Point(441, 62);
            this.panShape2.Name = "panShape2";
            this.panShape2.Size = new System.Drawing.Size(275, 407);
            this.panShape2.TabIndex = 1;
            this.panShape2.TabStop = false;
            // 
            // panShape3
            // 
            this.panShape3.Location = new System.Drawing.Point(801, 62);
            this.panShape3.Name = "panShape3";
            this.panShape3.Size = new System.Drawing.Size(290, 407);
            this.panShape3.TabIndex = 2;
            this.panShape3.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(110, 521);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(158, 43);
            this.button1.TabIndex = 3;
            this.button1.Text = "Initialize Shapes";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(498, 521);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(158, 43);
            this.button2.TabIndex = 4;
            this.button2.Text = "Apply Transformation";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(870, 521);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(158, 43);
            this.button3.TabIndex = 5;
            this.button3.Text = "Outlier Removal";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(469, 484);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(217, 13);
            this.textBox1.TabIndex = 6;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Location = new System.Drawing.Point(838, 484);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(217, 13);
            this.textBox2.TabIndex = 7;
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1144, 692);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panShape3);
            this.Controls.Add(this.panShape2);
            this.Controls.Add(this.panShape1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.panShape1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panShape2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panShape3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox panShape1;
        private System.Windows.Forms.PictureBox panShape2;
        private System.Windows.Forms.PictureBox panShape3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
    }
}

