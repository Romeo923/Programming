namespace ConvolFilters
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
            this.btnConvolve = new System.Windows.Forms.Button();
            this.pic1 = new System.Windows.Forms.PictureBox();
            this.pic2 = new System.Windows.Forms.PictureBox();
            this.filterText = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.edgeBtn = new System.Windows.Forms.Button();
            this.sobelXbtn = new System.Windows.Forms.Button();
            this.sobelYbtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pic1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConvolve
            // 
            this.btnConvolve.Location = new System.Drawing.Point(12, 12);
            this.btnConvolve.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnConvolve.Name = "btnConvolve";
            this.btnConvolve.Size = new System.Drawing.Size(155, 23);
            this.btnConvolve.TabIndex = 0;
            this.btnConvolve.Text = "Convolve";
            this.btnConvolve.UseVisualStyleBackColor = true;
            this.btnConvolve.Click += new System.EventHandler(this.btnConvolve_Click);
            // 
            // pic1
            // 
            this.pic1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic1.Location = new System.Drawing.Point(194, 12);
            this.pic1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pic1.Name = "pic1";
            this.pic1.Size = new System.Drawing.Size(557, 624);
            this.pic1.TabIndex = 1;
            this.pic1.TabStop = false;
            this.pic1.Click += new System.EventHandler(this.pic1_Click);
            // 
            // pic2
            // 
            this.pic2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic2.Location = new System.Drawing.Point(770, 12);
            this.pic2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pic2.Name = "pic2";
            this.pic2.Size = new System.Drawing.Size(557, 624);
            this.pic2.TabIndex = 2;
            this.pic2.TabStop = false;
            this.pic2.Click += new System.EventHandler(this.pic2_Click);
            // 
            // filterText
            // 
            this.filterText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filterText.Location = new System.Drawing.Point(16, 62);
            this.filterText.Margin = new System.Windows.Forms.Padding(4);
            this.filterText.Name = "filterText";
            this.filterText.Size = new System.Drawing.Size(150, 134);
            this.filterText.TabIndex = 3;
            this.filterText.Text = "0,0,0\n0,1,0\n0,0,0";
            this.filterText.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(16, 212);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(155, 27);
            this.button1.TabIndex = 4;
            this.button1.Text = "Indentity";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(16, 252);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(155, 25);
            this.button2.TabIndex = 5;
            this.button2.Text = "Average";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(16, 290);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(155, 25);
            this.button3.TabIndex = 6;
            this.button3.Text = "High Pass";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(16, 328);
            this.button4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(155, 28);
            this.button4.TabIndex = 7;
            this.button4.Text = "Sharpening";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(16, 369);
            this.button5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(155, 27);
            this.button5.TabIndex = 8;
            this.button5.Text = "Gaussian";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(16, 409);
            this.button6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(155, 25);
            this.button6.TabIndex = 9;
            this.button6.Text = "Gradient";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(16, 447);
            this.button7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(155, 27);
            this.button7.TabIndex = 10;
            this.button7.Text = "Laplacian";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(16, 487);
            this.button8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(155, 41);
            this.button8.TabIndex = 11;
            this.button8.Text = "Difference of Gaussians";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // edgeBtn
            // 
            this.edgeBtn.Location = new System.Drawing.Point(16, 622);
            this.edgeBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.edgeBtn.Name = "edgeBtn";
            this.edgeBtn.Size = new System.Drawing.Size(155, 27);
            this.edgeBtn.TabIndex = 12;
            this.edgeBtn.Text = "Edge Detection";
            this.edgeBtn.UseVisualStyleBackColor = true;
            this.edgeBtn.Click += new System.EventHandler(this.edgeBtn_Click);
            // 
            // sobelXbtn
            // 
            this.sobelXbtn.Location = new System.Drawing.Point(16, 541);
            this.sobelXbtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sobelXbtn.Name = "sobelXbtn";
            this.sobelXbtn.Size = new System.Drawing.Size(155, 27);
            this.sobelXbtn.TabIndex = 13;
            this.sobelXbtn.Text = "Sobel X";
            this.sobelXbtn.UseVisualStyleBackColor = true;
            this.sobelXbtn.Click += new System.EventHandler(this.sobelXbtn_Click);
            // 
            // sobelYbtn
            // 
            this.sobelYbtn.Location = new System.Drawing.Point(16, 581);
            this.sobelYbtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sobelYbtn.Name = "sobelYbtn";
            this.sobelYbtn.Size = new System.Drawing.Size(155, 27);
            this.sobelYbtn.TabIndex = 14;
            this.sobelYbtn.Text = "Sobel Y";
            this.sobelYbtn.UseVisualStyleBackColor = true;
            this.sobelYbtn.Click += new System.EventHandler(this.sobelYbtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1365, 683);
            this.Controls.Add(this.sobelYbtn);
            this.Controls.Add(this.sobelXbtn);
            this.Controls.Add(this.edgeBtn);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.filterText);
            this.Controls.Add(this.pic2);
            this.Controls.Add(this.pic1);
            this.Controls.Add(this.btnConvolve);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Convolution Filters --Romeo";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pic1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnConvolve;
        private System.Windows.Forms.PictureBox pic1;
        private System.Windows.Forms.PictureBox pic2;
        private System.Windows.Forms.RichTextBox filterText;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button edgeBtn;
        private System.Windows.Forms.Button sobelXbtn;
        private System.Windows.Forms.Button sobelYbtn;
    }
}

