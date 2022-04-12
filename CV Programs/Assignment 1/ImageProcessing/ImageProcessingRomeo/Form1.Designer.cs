
namespace ImageProcessingRomeo
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
            this.originalPic = new System.Windows.Forms.PictureBox();
            this.loadPic = new System.Windows.Forms.Button();
            this.newPic = new System.Windows.Forms.PictureBox();
            this.brightnessBtn = new System.Windows.Forms.Button();
            this.contrastBtn = new System.Windows.Forms.Button();
            this.brightnessText = new System.Windows.Forms.TextBox();
            this.contrastText = new System.Windows.Forms.TextBox();
            this.resetBtn = new System.Windows.Forms.Button();
            this.originalLable = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.imageLabel = new System.Windows.Forms.Label();
            this.grayscaleBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.histEqBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.comparerTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.originalPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.newPic)).BeginInit();
            this.SuspendLayout();
            // 
            // originalPic
            // 
            this.originalPic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.originalPic.Location = new System.Drawing.Point(12, 41);
            this.originalPic.Name = "originalPic";
            this.originalPic.Size = new System.Drawing.Size(504, 581);
            this.originalPic.TabIndex = 0;
            this.originalPic.TabStop = false;
            this.originalPic.Click += new System.EventHandler(this.originalPic_Click);
            // 
            // loadPic
            // 
            this.loadPic.Location = new System.Drawing.Point(568, 41);
            this.loadPic.Name = "loadPic";
            this.loadPic.Size = new System.Drawing.Size(88, 37);
            this.loadPic.TabIndex = 2;
            this.loadPic.Text = "Load Image";
            this.loadPic.UseVisualStyleBackColor = true;
            this.loadPic.Click += new System.EventHandler(this.loadPic_Click);
            // 
            // newPic
            // 
            this.newPic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.newPic.Location = new System.Drawing.Point(718, 41);
            this.newPic.Name = "newPic";
            this.newPic.Size = new System.Drawing.Size(504, 581);
            this.newPic.TabIndex = 3;
            this.newPic.TabStop = false;
            this.newPic.Click += new System.EventHandler(this.newPic_Click);
            // 
            // brightnessBtn
            // 
            this.brightnessBtn.Location = new System.Drawing.Point(568, 162);
            this.brightnessBtn.Name = "brightnessBtn";
            this.brightnessBtn.Size = new System.Drawing.Size(88, 37);
            this.brightnessBtn.TabIndex = 4;
            this.brightnessBtn.Text = "Change Brightness";
            this.brightnessBtn.UseVisualStyleBackColor = true;
            this.brightnessBtn.Click += new System.EventHandler(this.brightnessBtn_Click);
            // 
            // contrastBtn
            // 
            this.contrastBtn.Location = new System.Drawing.Point(568, 284);
            this.contrastBtn.Name = "contrastBtn";
            this.contrastBtn.Size = new System.Drawing.Size(88, 37);
            this.contrastBtn.TabIndex = 5;
            this.contrastBtn.Text = "Change Contrast";
            this.contrastBtn.UseVisualStyleBackColor = true;
            this.contrastBtn.Click += new System.EventHandler(this.contrastBtn_Click);
            // 
            // brightnessText
            // 
            this.brightnessText.Location = new System.Drawing.Point(568, 111);
            this.brightnessText.Name = "brightnessText";
            this.brightnessText.Size = new System.Drawing.Size(88, 20);
            this.brightnessText.TabIndex = 6;
            this.brightnessText.Text = "0";
            this.brightnessText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // contrastText
            // 
            this.contrastText.Location = new System.Drawing.Point(568, 230);
            this.contrastText.Name = "contrastText";
            this.contrastText.Size = new System.Drawing.Size(88, 20);
            this.contrastText.TabIndex = 7;
            this.contrastText.Text = "0";
            this.contrastText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // resetBtn
            // 
            this.resetBtn.Location = new System.Drawing.Point(568, 528);
            this.resetBtn.Name = "resetBtn";
            this.resetBtn.Size = new System.Drawing.Size(88, 37);
            this.resetBtn.TabIndex = 8;
            this.resetBtn.Text = "Reset Image";
            this.resetBtn.UseVisualStyleBackColor = true;
            this.resetBtn.Click += new System.EventHandler(this.resetBtn_Click);
            // 
            // originalLable
            // 
            this.originalLable.AutoSize = true;
            this.originalLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.originalLable.Location = new System.Drawing.Point(193, 647);
            this.originalLable.Name = "originalLable";
            this.originalLable.Size = new System.Drawing.Size(111, 20);
            this.originalLable.TabIndex = 9;
            this.originalLable.Text = "Original Image";
            this.originalLable.Click += new System.EventHandler(this.originalLable_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(921, 647);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Modified Image";
            // 
            // imageLabel
            // 
            this.imageLabel.AutoSize = true;
            this.imageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.imageLabel.Location = new System.Drawing.Point(168, 284);
            this.imageLabel.Name = "imageLabel";
            this.imageLabel.Size = new System.Drawing.Size(188, 20);
            this.imageLabel.TabIndex = 11;
            this.imageLabel.Text = "Click Here to Load Image";
            this.imageLabel.Click += new System.EventHandler(this.imageLabel_Click);
            // 
            // grayscaleBtn
            // 
            this.grayscaleBtn.Location = new System.Drawing.Point(568, 375);
            this.grayscaleBtn.Name = "grayscaleBtn";
            this.grayscaleBtn.Size = new System.Drawing.Size(88, 37);
            this.grayscaleBtn.TabIndex = 12;
            this.grayscaleBtn.Text = "Grayscale";
            this.grayscaleBtn.UseVisualStyleBackColor = true;
            this.grayscaleBtn.Click += new System.EventHandler(this.grayscaleBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(887, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(176, 20);
            this.label2.TabIndex = 13;
            this.label2.Text = "Click to View Full Image";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // histEqBtn
            // 
            this.histEqBtn.Location = new System.Drawing.Point(568, 463);
            this.histEqBtn.Name = "histEqBtn";
            this.histEqBtn.Size = new System.Drawing.Size(88, 37);
            this.histEqBtn.TabIndex = 14;
            this.histEqBtn.Text = "Histogram Equalization";
            this.histEqBtn.UseVisualStyleBackColor = true;
            this.histEqBtn.Click += new System.EventHandler(this.histEqBtn_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(568, 640);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 37);
            this.button1.TabIndex = 15;
            this.button1.Text = "Compare";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comparerTextBox
            // 
            this.comparerTextBox.Location = new System.Drawing.Point(568, 602);
            this.comparerTextBox.Name = "comparerTextBox";
            this.comparerTextBox.Size = new System.Drawing.Size(88, 20);
            this.comparerTextBox.TabIndex = 16;
            this.comparerTextBox.Text = "0";
            this.comparerTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1234, 709);
            this.Controls.Add(this.comparerTextBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.histEqBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.grayscaleBtn);
            this.Controls.Add(this.imageLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.originalLable);
            this.Controls.Add(this.resetBtn);
            this.Controls.Add(this.contrastText);
            this.Controls.Add(this.brightnessText);
            this.Controls.Add(this.contrastBtn);
            this.Controls.Add(this.brightnessBtn);
            this.Controls.Add(this.newPic);
            this.Controls.Add(this.loadPic);
            this.Controls.Add(this.originalPic);
            this.Name = "Form1";
            this.Text = "Image Processing --Romeo";
            ((System.ComponentModel.ISupportInitialize)(this.originalPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.newPic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox originalPic;
        private System.Windows.Forms.Button loadPic;
        private System.Windows.Forms.PictureBox newPic;
        private System.Windows.Forms.Button brightnessBtn;
        private System.Windows.Forms.Button contrastBtn;
        private System.Windows.Forms.TextBox brightnessText;
        private System.Windows.Forms.TextBox contrastText;
        private System.Windows.Forms.Button resetBtn;
        private System.Windows.Forms.Label originalLable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label imageLabel;
        private System.Windows.Forms.Button grayscaleBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button histEqBtn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox comparerTextBox;
    }
}

