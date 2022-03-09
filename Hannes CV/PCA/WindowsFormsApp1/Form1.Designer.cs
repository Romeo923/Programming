namespace FaceRecogPCA
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
            this.picAvg = new System.Windows.Forms.PictureBox();
            this.pic0 = new System.Windows.Forms.PictureBox();
            this.picAdjustedImage = new System.Windows.Forms.PictureBox();
            this.picRecov = new System.Windows.Forms.PictureBox();
            this.picBestMatch0 = new System.Windows.Forms.PictureBox();
            this.picBestMatch4 = new System.Windows.Forms.PictureBox();
            this.picBestMatch1 = new System.Windows.Forms.PictureBox();
            this.picBestMatch5 = new System.Windows.Forms.PictureBox();
            this.picBestMatch2 = new System.Windows.Forms.PictureBox();
            this.picBestMatch6 = new System.Windows.Forms.PictureBox();
            this.picBestMatch3 = new System.Windows.Forms.PictureBox();
            this.picBestMatch7 = new System.Windows.Forms.PictureBox();
            this.picEF0 = new System.Windows.Forms.PictureBox();
            this.picEF1 = new System.Windows.Forms.PictureBox();
            this.picEF2 = new System.Windows.Forms.PictureBox();
            this.picEF3 = new System.Windows.Forms.PictureBox();
            this.picEF4 = new System.Windows.Forms.PictureBox();
            this.btnTestImage = new System.Windows.Forms.Button();
            this.btnComputeAccuracy = new System.Windows.Forms.Button();
            this.btnCalculateEFs = new System.Windows.Forms.Button();
            this.lblAverageImage = new System.Windows.Forms.Label();
            this.lblImageToCheck = new System.Windows.Forms.Label();
            this.lblAdjustedImage = new System.Windows.Forms.Label();
            this.lblReconstructedError = new System.Windows.Forms.Label();
            this.lblBestMatch0 = new System.Windows.Forms.Label();
            this.lblBestMatch1 = new System.Windows.Forms.Label();
            this.lblBestMatch2 = new System.Windows.Forms.Label();
            this.lblBestMatch3 = new System.Windows.Forms.Label();
            this.lblBestMatch4 = new System.Windows.Forms.Label();
            this.lblBestMatch5 = new System.Windows.Forms.Label();
            this.lblBestMatch6 = new System.Windows.Forms.Label();
            this.lblBestMatch7 = new System.Windows.Forms.Label();
            this.picEF5 = new System.Windows.Forms.PictureBox();
            this.picEF6 = new System.Windows.Forms.PictureBox();
            this.picEF7 = new System.Windows.Forms.PictureBox();
            this.picEF8 = new System.Windows.Forms.PictureBox();
            this.picEF9 = new System.Windows.Forms.PictureBox();
            this.picEF10 = new System.Windows.Forms.PictureBox();
            this.picEF11 = new System.Windows.Forms.PictureBox();
            this.picEF12 = new System.Windows.Forms.PictureBox();
            this.picEF13 = new System.Windows.Forms.PictureBox();
            this.picEF14 = new System.Windows.Forms.PictureBox();
            this.picEF15 = new System.Windows.Forms.PictureBox();
            this.lblEigenValues = new System.Windows.Forms.Label();
            this.txtBoxEV = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.picAvg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAdjustedImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRecov)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBestMatch0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBestMatch4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBestMatch1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBestMatch5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBestMatch2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBestMatch6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBestMatch3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBestMatch7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEF0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEF1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEF2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEF3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEF4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEF5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEF6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEF7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEF8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEF9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEF10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEF11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEF12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEF13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEF14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEF15)).BeginInit();
            this.SuspendLayout();
            // 
            // picAvg
            // 
            this.picAvg.Location = new System.Drawing.Point(32, 124);
            this.picAvg.Name = "picAvg";
            this.picAvg.Size = new System.Drawing.Size(85, 113);
            this.picAvg.TabIndex = 0;
            this.picAvg.TabStop = false;
            // 
            // pic0
            // 
            this.pic0.Location = new System.Drawing.Point(141, 12);
            this.pic0.Name = "pic0";
            this.pic0.Size = new System.Drawing.Size(110, 142);
            this.pic0.TabIndex = 1;
            this.pic0.TabStop = false;
            // 
            // picAdjustedImage
            // 
            this.picAdjustedImage.Location = new System.Drawing.Point(257, 12);
            this.picAdjustedImage.Name = "picAdjustedImage";
            this.picAdjustedImage.Size = new System.Drawing.Size(110, 142);
            this.picAdjustedImage.TabIndex = 2;
            this.picAdjustedImage.TabStop = false;
            // 
            // picRecov
            // 
            this.picRecov.Location = new System.Drawing.Point(373, 12);
            this.picRecov.Name = "picRecov";
            this.picRecov.Size = new System.Drawing.Size(110, 142);
            this.picRecov.TabIndex = 3;
            this.picRecov.TabStop = false;
            // 
            // picBestMatch0
            // 
            this.picBestMatch0.Location = new System.Drawing.Point(501, 12);
            this.picBestMatch0.Name = "picBestMatch0";
            this.picBestMatch0.Size = new System.Drawing.Size(88, 124);
            this.picBestMatch0.TabIndex = 4;
            this.picBestMatch0.TabStop = false;
            // 
            // picBestMatch4
            // 
            this.picBestMatch4.Location = new System.Drawing.Point(501, 205);
            this.picBestMatch4.Name = "picBestMatch4";
            this.picBestMatch4.Size = new System.Drawing.Size(88, 129);
            this.picBestMatch4.TabIndex = 5;
            this.picBestMatch4.TabStop = false;
            // 
            // picBestMatch1
            // 
            this.picBestMatch1.Location = new System.Drawing.Point(605, 12);
            this.picBestMatch1.Name = "picBestMatch1";
            this.picBestMatch1.Size = new System.Drawing.Size(84, 124);
            this.picBestMatch1.TabIndex = 6;
            this.picBestMatch1.TabStop = false;
            // 
            // picBestMatch5
            // 
            this.picBestMatch5.Location = new System.Drawing.Point(605, 205);
            this.picBestMatch5.Name = "picBestMatch5";
            this.picBestMatch5.Size = new System.Drawing.Size(84, 129);
            this.picBestMatch5.TabIndex = 7;
            this.picBestMatch5.TabStop = false;
            // 
            // picBestMatch2
            // 
            this.picBestMatch2.Location = new System.Drawing.Point(705, 12);
            this.picBestMatch2.Name = "picBestMatch2";
            this.picBestMatch2.Size = new System.Drawing.Size(80, 124);
            this.picBestMatch2.TabIndex = 8;
            this.picBestMatch2.TabStop = false;
            // 
            // picBestMatch6
            // 
            this.picBestMatch6.Location = new System.Drawing.Point(705, 208);
            this.picBestMatch6.Name = "picBestMatch6";
            this.picBestMatch6.Size = new System.Drawing.Size(80, 126);
            this.picBestMatch6.TabIndex = 9;
            this.picBestMatch6.TabStop = false;
            // 
            // picBestMatch3
            // 
            this.picBestMatch3.Location = new System.Drawing.Point(800, 12);
            this.picBestMatch3.Name = "picBestMatch3";
            this.picBestMatch3.Size = new System.Drawing.Size(77, 124);
            this.picBestMatch3.TabIndex = 10;
            this.picBestMatch3.TabStop = false;
            // 
            // picBestMatch7
            // 
            this.picBestMatch7.Location = new System.Drawing.Point(800, 208);
            this.picBestMatch7.Name = "picBestMatch7";
            this.picBestMatch7.Size = new System.Drawing.Size(77, 126);
            this.picBestMatch7.TabIndex = 11;
            this.picBestMatch7.TabStop = false;
            // 
            // picEF0
            // 
            this.picEF0.Location = new System.Drawing.Point(32, 379);
            this.picEF0.Name = "picEF0";
            this.picEF0.Size = new System.Drawing.Size(100, 139);
            this.picEF0.TabIndex = 12;
            this.picEF0.TabStop = false;
            this.picEF0.Click += new System.EventHandler(this.picEF0_Click);
            // 
            // picEF1
            // 
            this.picEF1.Location = new System.Drawing.Point(141, 379);
            this.picEF1.Name = "picEF1";
            this.picEF1.Size = new System.Drawing.Size(100, 139);
            this.picEF1.TabIndex = 13;
            this.picEF1.TabStop = false;
            // 
            // picEF2
            // 
            this.picEF2.Location = new System.Drawing.Point(247, 379);
            this.picEF2.Name = "picEF2";
            this.picEF2.Size = new System.Drawing.Size(100, 139);
            this.picEF2.TabIndex = 14;
            this.picEF2.TabStop = false;
            // 
            // picEF3
            // 
            this.picEF3.Location = new System.Drawing.Point(353, 379);
            this.picEF3.Name = "picEF3";
            this.picEF3.Size = new System.Drawing.Size(100, 139);
            this.picEF3.TabIndex = 15;
            this.picEF3.TabStop = false;
            // 
            // picEF4
            // 
            this.picEF4.Location = new System.Drawing.Point(459, 379);
            this.picEF4.Name = "picEF4";
            this.picEF4.Size = new System.Drawing.Size(100, 139);
            this.picEF4.TabIndex = 16;
            this.picEF4.TabStop = false;
            // 
            // btnTestImage
            // 
            this.btnTestImage.Location = new System.Drawing.Point(12, 42);
            this.btnTestImage.Name = "btnTestImage";
            this.btnTestImage.Size = new System.Drawing.Size(87, 23);
            this.btnTestImage.TabIndex = 17;
            this.btnTestImage.Text = "Test Image";
            this.btnTestImage.UseVisualStyleBackColor = true;
            this.btnTestImage.Click += new System.EventHandler(this.btnTestImage_Click_1);
            // 
            // btnComputeAccuracy
            // 
            this.btnComputeAccuracy.Location = new System.Drawing.Point(12, 71);
            this.btnComputeAccuracy.Name = "btnComputeAccuracy";
            this.btnComputeAccuracy.Size = new System.Drawing.Size(87, 35);
            this.btnComputeAccuracy.TabIndex = 18;
            this.btnComputeAccuracy.Text = "Compute Accuracy";
            this.btnComputeAccuracy.UseVisualStyleBackColor = true;
            this.btnComputeAccuracy.Click += new System.EventHandler(this.btnComputeAccuracy_Click_1);
            // 
            // btnCalculateEFs
            // 
            this.btnCalculateEFs.Location = new System.Drawing.Point(12, 12);
            this.btnCalculateEFs.Name = "btnCalculateEFs";
            this.btnCalculateEFs.Size = new System.Drawing.Size(87, 23);
            this.btnCalculateEFs.TabIndex = 19;
            this.btnCalculateEFs.Text = "Calculate EFs";
            this.btnCalculateEFs.UseVisualStyleBackColor = true;
            this.btnCalculateEFs.Click += new System.EventHandler(this.btnCaluculateEFs_Click);
            // 
            // lblAverageImage
            // 
            this.lblAverageImage.AutoSize = true;
            this.lblAverageImage.Location = new System.Drawing.Point(38, 240);
            this.lblAverageImage.Name = "lblAverageImage";
            this.lblAverageImage.Size = new System.Drawing.Size(79, 13);
            this.lblAverageImage.TabIndex = 20;
            this.lblAverageImage.Text = "Average Image";
            // 
            // lblImageToCheck
            // 
            this.lblImageToCheck.AutoSize = true;
            this.lblImageToCheck.Location = new System.Drawing.Point(148, 157);
            this.lblImageToCheck.Name = "lblImageToCheck";
            this.lblImageToCheck.Size = new System.Drawing.Size(86, 13);
            this.lblImageToCheck.TabIndex = 21;
            this.lblImageToCheck.Text = "Image To Check";
            this.lblImageToCheck.Click += new System.EventHandler(this.label2_Click);
            // 
            // lblAdjustedImage
            // 
            this.lblAdjustedImage.AutoSize = true;
            this.lblAdjustedImage.Location = new System.Drawing.Point(274, 157);
            this.lblAdjustedImage.Name = "lblAdjustedImage";
            this.lblAdjustedImage.Size = new System.Drawing.Size(80, 13);
            this.lblAdjustedImage.TabIndex = 22;
            this.lblAdjustedImage.Text = "Adjusted Image";
            // 
            // lblReconstructedError
            // 
            this.lblReconstructedError.AutoSize = true;
            this.lblReconstructedError.Location = new System.Drawing.Point(373, 157);
            this.lblReconstructedError.Name = "lblReconstructedError";
            this.lblReconstructedError.Size = new System.Drawing.Size(112, 13);
            this.lblReconstructedError.TabIndex = 23;
            this.lblReconstructedError.Text = "Reconstructed Image ";
            // 
            // lblBestMatch0
            // 
            this.lblBestMatch0.AutoSize = true;
            this.lblBestMatch0.Location = new System.Drawing.Point(516, 141);
            this.lblBestMatch0.Name = "lblBestMatch0";
            this.lblBestMatch0.Size = new System.Drawing.Size(61, 13);
            this.lblBestMatch0.TabIndex = 24;
            this.lblBestMatch0.Text = "Best Match";
            // 
            // lblBestMatch1
            // 
            this.lblBestMatch1.AutoSize = true;
            this.lblBestMatch1.Location = new System.Drawing.Point(607, 141);
            this.lblBestMatch1.Name = "lblBestMatch1";
            this.lblBestMatch1.Size = new System.Drawing.Size(82, 13);
            this.lblBestMatch1.TabIndex = 25;
            this.lblBestMatch1.Text = "2nd Best Match";
            // 
            // lblBestMatch2
            // 
            this.lblBestMatch2.AutoSize = true;
            this.lblBestMatch2.Location = new System.Drawing.Point(706, 139);
            this.lblBestMatch2.Name = "lblBestMatch2";
            this.lblBestMatch2.Size = new System.Drawing.Size(79, 13);
            this.lblBestMatch2.TabIndex = 26;
            this.lblBestMatch2.Text = "3rd Best Match";
            // 
            // lblBestMatch3
            // 
            this.lblBestMatch3.AutoSize = true;
            this.lblBestMatch3.Location = new System.Drawing.Point(798, 139);
            this.lblBestMatch3.Name = "lblBestMatch3";
            this.lblBestMatch3.Size = new System.Drawing.Size(79, 13);
            this.lblBestMatch3.TabIndex = 27;
            this.lblBestMatch3.Text = "4th Best Match";
            // 
            // lblBestMatch4
            // 
            this.lblBestMatch4.AutoSize = true;
            this.lblBestMatch4.Location = new System.Drawing.Point(510, 337);
            this.lblBestMatch4.Name = "lblBestMatch4";
            this.lblBestMatch4.Size = new System.Drawing.Size(79, 13);
            this.lblBestMatch4.TabIndex = 28;
            this.lblBestMatch4.Text = "5th Best Match";
            this.lblBestMatch4.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblBestMatch5
            // 
            this.lblBestMatch5.AutoSize = true;
            this.lblBestMatch5.Location = new System.Drawing.Point(607, 337);
            this.lblBestMatch5.Name = "lblBestMatch5";
            this.lblBestMatch5.Size = new System.Drawing.Size(79, 13);
            this.lblBestMatch5.TabIndex = 29;
            this.lblBestMatch5.Text = "6th Best Match";
            // 
            // lblBestMatch6
            // 
            this.lblBestMatch6.AutoSize = true;
            this.lblBestMatch6.Location = new System.Drawing.Point(713, 337);
            this.lblBestMatch6.Name = "lblBestMatch6";
            this.lblBestMatch6.Size = new System.Drawing.Size(79, 13);
            this.lblBestMatch6.TabIndex = 30;
            this.lblBestMatch6.Text = "7th Best Match";
            // 
            // lblBestMatch7
            // 
            this.lblBestMatch7.AutoSize = true;
            this.lblBestMatch7.Location = new System.Drawing.Point(798, 337);
            this.lblBestMatch7.Name = "lblBestMatch7";
            this.lblBestMatch7.Size = new System.Drawing.Size(79, 13);
            this.lblBestMatch7.TabIndex = 31;
            this.lblBestMatch7.Text = "8th Best Match";
            // 
            // picEF5
            // 
            this.picEF5.Location = new System.Drawing.Point(565, 379);
            this.picEF5.Name = "picEF5";
            this.picEF5.Size = new System.Drawing.Size(100, 139);
            this.picEF5.TabIndex = 32;
            this.picEF5.TabStop = false;
            // 
            // picEF6
            // 
            this.picEF6.Location = new System.Drawing.Point(671, 379);
            this.picEF6.Name = "picEF6";
            this.picEF6.Size = new System.Drawing.Size(100, 139);
            this.picEF6.TabIndex = 33;
            this.picEF6.TabStop = false;
            // 
            // picEF7
            // 
            this.picEF7.Location = new System.Drawing.Point(777, 379);
            this.picEF7.Name = "picEF7";
            this.picEF7.Size = new System.Drawing.Size(100, 139);
            this.picEF7.TabIndex = 34;
            this.picEF7.TabStop = false;
            // 
            // picEF8
            // 
            this.picEF8.Location = new System.Drawing.Point(32, 524);
            this.picEF8.Name = "picEF8";
            this.picEF8.Size = new System.Drawing.Size(100, 139);
            this.picEF8.TabIndex = 35;
            this.picEF8.TabStop = false;
            // 
            // picEF9
            // 
            this.picEF9.Location = new System.Drawing.Point(141, 524);
            this.picEF9.Name = "picEF9";
            this.picEF9.Size = new System.Drawing.Size(100, 139);
            this.picEF9.TabIndex = 36;
            this.picEF9.TabStop = false;
            // 
            // picEF10
            // 
            this.picEF10.Location = new System.Drawing.Point(247, 524);
            this.picEF10.Name = "picEF10";
            this.picEF10.Size = new System.Drawing.Size(100, 139);
            this.picEF10.TabIndex = 37;
            this.picEF10.TabStop = false;
            // 
            // picEF11
            // 
            this.picEF11.Location = new System.Drawing.Point(353, 524);
            this.picEF11.Name = "picEF11";
            this.picEF11.Size = new System.Drawing.Size(100, 139);
            this.picEF11.TabIndex = 38;
            this.picEF11.TabStop = false;
            // 
            // picEF12
            // 
            this.picEF12.Location = new System.Drawing.Point(459, 524);
            this.picEF12.Name = "picEF12";
            this.picEF12.Size = new System.Drawing.Size(100, 139);
            this.picEF12.TabIndex = 39;
            this.picEF12.TabStop = false;
            // 
            // picEF13
            // 
            this.picEF13.Location = new System.Drawing.Point(565, 524);
            this.picEF13.Name = "picEF13";
            this.picEF13.Size = new System.Drawing.Size(100, 139);
            this.picEF13.TabIndex = 40;
            this.picEF13.TabStop = false;
            // 
            // picEF14
            // 
            this.picEF14.Location = new System.Drawing.Point(671, 524);
            this.picEF14.Name = "picEF14";
            this.picEF14.Size = new System.Drawing.Size(100, 139);
            this.picEF14.TabIndex = 41;
            this.picEF14.TabStop = false;
            // 
            // picEF15
            // 
            this.picEF15.Location = new System.Drawing.Point(777, 524);
            this.picEF15.Name = "picEF15";
            this.picEF15.Size = new System.Drawing.Size(100, 139);
            this.picEF15.TabIndex = 42;
            this.picEF15.TabStop = false;
            // 
            // lblEigenValues
            // 
            this.lblEigenValues.AutoSize = true;
            this.lblEigenValues.Location = new System.Drawing.Point(27, 764);
            this.lblEigenValues.Name = "lblEigenValues";
            this.lblEigenValues.Size = new System.Drawing.Size(72, 13);
            this.lblEigenValues.TabIndex = 43;
            this.lblEigenValues.Text = "Eigen Values:";
            // 
            // txtBoxEV
            // 
            this.txtBoxEV.Location = new System.Drawing.Point(105, 713);
            this.txtBoxEV.Multiline = true;
            this.txtBoxEV.Name = "txtBoxEV";
            this.txtBoxEV.Size = new System.Drawing.Size(828, 72);
            this.txtBoxEV.TabIndex = 47;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(971, 797);
            this.Controls.Add(this.txtBoxEV);
            this.Controls.Add(this.lblEigenValues);
            this.Controls.Add(this.picEF15);
            this.Controls.Add(this.picEF14);
            this.Controls.Add(this.picEF13);
            this.Controls.Add(this.picEF12);
            this.Controls.Add(this.picEF11);
            this.Controls.Add(this.picEF10);
            this.Controls.Add(this.picEF9);
            this.Controls.Add(this.picEF8);
            this.Controls.Add(this.picEF7);
            this.Controls.Add(this.picEF6);
            this.Controls.Add(this.picEF5);
            this.Controls.Add(this.lblBestMatch7);
            this.Controls.Add(this.lblBestMatch6);
            this.Controls.Add(this.lblBestMatch5);
            this.Controls.Add(this.lblBestMatch4);
            this.Controls.Add(this.lblBestMatch3);
            this.Controls.Add(this.lblBestMatch2);
            this.Controls.Add(this.lblBestMatch1);
            this.Controls.Add(this.lblBestMatch0);
            this.Controls.Add(this.lblReconstructedError);
            this.Controls.Add(this.lblAdjustedImage);
            this.Controls.Add(this.lblImageToCheck);
            this.Controls.Add(this.lblAverageImage);
            this.Controls.Add(this.btnCalculateEFs);
            this.Controls.Add(this.btnComputeAccuracy);
            this.Controls.Add(this.btnTestImage);
            this.Controls.Add(this.picEF4);
            this.Controls.Add(this.picEF3);
            this.Controls.Add(this.picEF2);
            this.Controls.Add(this.picEF1);
            this.Controls.Add(this.picEF0);
            this.Controls.Add(this.picBestMatch7);
            this.Controls.Add(this.picBestMatch3);
            this.Controls.Add(this.picBestMatch6);
            this.Controls.Add(this.picBestMatch2);
            this.Controls.Add(this.picBestMatch5);
            this.Controls.Add(this.picBestMatch1);
            this.Controls.Add(this.picBestMatch4);
            this.Controls.Add(this.picBestMatch0);
            this.Controls.Add(this.picRecov);
            this.Controls.Add(this.picAdjustedImage);
            this.Controls.Add(this.pic0);
            this.Controls.Add(this.picAvg);
            this.Name = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.picAvg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAdjustedImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRecov)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBestMatch0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBestMatch4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBestMatch1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBestMatch5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBestMatch2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBestMatch6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBestMatch3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBestMatch7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEF0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEF1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEF2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEF3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEF4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEF5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEF6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEF7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEF8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEF9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEF10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEF11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEF12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEF13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEF14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEF15)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.PictureBox picAvg;
        private System.Windows.Forms.PictureBox pic0;
        private System.Windows.Forms.PictureBox picAdjustedImage;
        private System.Windows.Forms.PictureBox picRecov;
        private System.Windows.Forms.PictureBox picBestMatch0;
        private System.Windows.Forms.PictureBox picBestMatch4;
        private System.Windows.Forms.PictureBox picBestMatch1;
        private System.Windows.Forms.PictureBox picBestMatch5;
        private System.Windows.Forms.PictureBox picBestMatch2;
        private System.Windows.Forms.PictureBox picBestMatch6;
        private System.Windows.Forms.PictureBox picBestMatch3;
        private System.Windows.Forms.PictureBox picBestMatch7;
        private System.Windows.Forms.PictureBox picEF0;
        private System.Windows.Forms.PictureBox picEF1;
        private System.Windows.Forms.PictureBox picEF2;
        private System.Windows.Forms.PictureBox picEF3;
        private System.Windows.Forms.PictureBox picEF4;
        private System.Windows.Forms.Button btnTestImage;
        private System.Windows.Forms.Button btnComputeAccuracy;
        private System.Windows.Forms.Button btnCalculateEFs;
        private System.Windows.Forms.Label lblAverageImage;
        private System.Windows.Forms.Label lblImageToCheck;
        private System.Windows.Forms.Label lblAdjustedImage;
        private System.Windows.Forms.Label lblReconstructedError;
        private System.Windows.Forms.Label lblBestMatch0;
        private System.Windows.Forms.Label lblBestMatch1;
        private System.Windows.Forms.Label lblBestMatch2;
        private System.Windows.Forms.Label lblBestMatch3;
        private System.Windows.Forms.Label lblBestMatch4;
        private System.Windows.Forms.Label lblBestMatch5;
        private System.Windows.Forms.Label lblBestMatch6;
        private System.Windows.Forms.Label lblBestMatch7;
        private System.Windows.Forms.PictureBox picEF5;
        private System.Windows.Forms.PictureBox picEF6;
        private System.Windows.Forms.PictureBox picEF7;
        private System.Windows.Forms.PictureBox picEF8;
        private System.Windows.Forms.PictureBox picEF9;
        private System.Windows.Forms.PictureBox picEF10;
        private System.Windows.Forms.PictureBox picEF11;
        private System.Windows.Forms.PictureBox picEF12;
        private System.Windows.Forms.PictureBox picEF13;
        private System.Windows.Forms.PictureBox picEF14;
        private System.Windows.Forms.PictureBox picEF15;
        private System.Windows.Forms.Label lblEigenValues;
        private System.Windows.Forms.TextBox txtBoxEV;

        #endregion

        //        private System.Windows.Forms.PictureBox picAvg;
        //      private System.Windows.Forms.PictureBox pic0;
        //    private System.Windows.Forms.PictureBox picAdjustedImage;
        //  private System.Windows.Forms.PictureBox picRecov;
        //private System.Windows.Forms.PictureBox picBestMatch0;
        //private System.Windows.Forms.PictureBox picBestMatch1;
        //private System.Windows.Forms.PictureBox picBestMatch2;
        //private System.Windows.Forms.PictureBox picBestMatch3;
        //private System.Windows.Forms.PictureBox picBestMatch4;
        //private System.Windows.Forms.PictureBox picBestMatch5;
        //private System.Windows.Forms.PictureBox picBestMatch6;
        //private System.Windows.Forms.PictureBox picBestMatch7;
        //private System.Windows.Forms.PictureBox picEF0;
        //private System.Windows.Forms.PictureBox picEF1;
        //private System.Windows.Forms.PictureBox picEF2;
        //private System.Windows.Forms.PictureBox picEF3;
        //private System.Windows.Forms.PictureBox picEF4;
        //private System.Windows.Forms.PictureBox picAvgr;
    }
}

