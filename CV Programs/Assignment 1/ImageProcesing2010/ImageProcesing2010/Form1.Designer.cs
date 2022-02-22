namespace ImageProcesing2010
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
            this.picOrigImage = new System.Windows.Forms.PictureBox();
            this.picProcImage = new System.Windows.Forms.PictureBox();
            this.txtWidthOrig = new System.Windows.Forms.TextBox();
            this.txtHeightOrig = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtHeightProc = new System.Windows.Forms.TextBox();
            this.txtWidthProc = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMouseY = new System.Windows.Forms.TextBox();
            this.txtMouseX = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtMouseRY = new System.Windows.Forms.TextBox();
            this.txtMouseRX = new System.Windows.Forms.TextBox();
            this.btnLoadImage = new System.Windows.Forms.Button();
            this.lblImageUnderTest = new System.Windows.Forms.Label();
            this.btnConvertToGray = new System.Windows.Forms.Button();
            this.btnRotateFillImage = new System.Windows.Forms.Button();
            this.btnCropAroundMouseClick = new System.Windows.Forms.Button();
            this.txtCropAroundW = new System.Windows.Forms.TextBox();
            this.txtCropAroundH = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btnBrightenImage = new System.Windows.Forms.Button();
            this.btnChangeContrast = new System.Windows.Forms.Button();
            this.btnSaveProcessedImage = new System.Windows.Forms.Button();
            this.btnResizeImage = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.btnResizeProportional = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtNewSizeH = new System.Windows.Forms.TextBox();
            this.txtNewSizeW = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.btnCropAroundDragAndReleaseMouse = new System.Windows.Forms.Button();
            this.btnDraRectangle = new System.Windows.Forms.Button();
            this.btnDrawX = new System.Windows.Forms.Button();
            this.btnRotateClear = new System.Windows.Forms.Button();
            this.btnRotateByPoints = new System.Windows.Forms.Button();
            this.btnRotateFill = new System.Windows.Forms.Button();
            this.btnShiftHorizontal = new System.Windows.Forms.Button();
            this.btnShiftVertical = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picOrigImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picProcImage)).BeginInit();
            this.SuspendLayout();
            // 
            // picOrigImage
            // 
            this.picOrigImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picOrigImage.Location = new System.Drawing.Point(9, 49);
            this.picOrigImage.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.picOrigImage.Name = "picOrigImage";
            this.picOrigImage.Size = new System.Drawing.Size(454, 491);
            this.picOrigImage.TabIndex = 0;
            this.picOrigImage.TabStop = false;
            this.picOrigImage.Click += new System.EventHandler(this.picOrigImage_Click);
            this.picOrigImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picOrigImage_MouseDown);
            this.picOrigImage.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picOrigImage_MouseUp);
            // 
            // picProcImage
            // 
            this.picProcImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picProcImage.Location = new System.Drawing.Point(483, 49);
            this.picProcImage.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.picProcImage.Name = "picProcImage";
            this.picProcImage.Size = new System.Drawing.Size(454, 491);
            this.picProcImage.TabIndex = 1;
            this.picProcImage.TabStop = false;
            // 
            // txtWidthOrig
            // 
            this.txtWidthOrig.Location = new System.Drawing.Point(134, 26);
            this.txtWidthOrig.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtWidthOrig.Name = "txtWidthOrig";
            this.txtWidthOrig.Size = new System.Drawing.Size(44, 20);
            this.txtWidthOrig.TabIndex = 2;
            // 
            // txtHeightOrig
            // 
            this.txtHeightOrig.Location = new System.Drawing.Point(199, 26);
            this.txtHeightOrig.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtHeightOrig.Name = "txtHeightOrig";
            this.txtHeightOrig.Size = new System.Drawing.Size(47, 20);
            this.txtHeightOrig.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(113, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "W";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(181, 28);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "H";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(766, 30);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "H";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(675, 28);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "W";
            // 
            // txtHeightProc
            // 
            this.txtHeightProc.Location = new System.Drawing.Point(784, 26);
            this.txtHeightProc.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtHeightProc.Name = "txtHeightProc";
            this.txtHeightProc.Size = new System.Drawing.Size(56, 20);
            this.txtHeightProc.TabIndex = 7;
            // 
            // txtWidthProc
            // 
            this.txtWidthProc.Location = new System.Drawing.Point(695, 26);
            this.txtWidthProc.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtWidthProc.Name = "txtWidthProc";
            this.txtWidthProc.Size = new System.Drawing.Size(52, 20);
            this.txtWidthProc.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(344, 30);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Y";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(277, 28);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "X";
            // 
            // txtMouseY
            // 
            this.txtMouseY.Location = new System.Drawing.Point(361, 28);
            this.txtMouseY.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtMouseY.Name = "txtMouseY";
            this.txtMouseY.Size = new System.Drawing.Size(38, 20);
            this.txtMouseY.TabIndex = 11;
            // 
            // txtMouseX
            // 
            this.txtMouseX.Location = new System.Drawing.Point(294, 26);
            this.txtMouseX.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtMouseX.Name = "txtMouseX";
            this.txtMouseX.Size = new System.Drawing.Size(38, 20);
            this.txtMouseX.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(308, 7);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Mouse Position";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(554, 7);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Mouse Position";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(590, 30);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(14, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Y";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(523, 28);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(14, 13);
            this.label10.TabIndex = 17;
            this.label10.Text = "X";
            // 
            // txtMouseRY
            // 
            this.txtMouseRY.Location = new System.Drawing.Point(607, 28);
            this.txtMouseRY.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtMouseRY.Name = "txtMouseRY";
            this.txtMouseRY.Size = new System.Drawing.Size(38, 20);
            this.txtMouseRY.TabIndex = 16;
            // 
            // txtMouseRX
            // 
            this.txtMouseRX.Location = new System.Drawing.Point(540, 26);
            this.txtMouseRX.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtMouseRX.Name = "txtMouseRX";
            this.txtMouseRX.Size = new System.Drawing.Size(38, 20);
            this.txtMouseRX.TabIndex = 15;
            // 
            // btnLoadImage
            // 
            this.btnLoadImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnLoadImage.Location = new System.Drawing.Point(9, 546);
            this.btnLoadImage.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLoadImage.Name = "btnLoadImage";
            this.btnLoadImage.Size = new System.Drawing.Size(71, 22);
            this.btnLoadImage.TabIndex = 20;
            this.btnLoadImage.Text = "Load Image";
            this.btnLoadImage.UseVisualStyleBackColor = false;
            this.btnLoadImage.Click += new System.EventHandler(this.btnLoadImage_Click);
            // 
            // lblImageUnderTest
            // 
            this.lblImageUnderTest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblImageUnderTest.Location = new System.Drawing.Point(9, 7);
            this.lblImageUnderTest.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblImageUnderTest.Name = "lblImageUnderTest";
            this.lblImageUnderTest.Size = new System.Drawing.Size(100, 40);
            this.lblImageUnderTest.TabIndex = 21;
            // 
            // btnConvertToGray
            // 
            this.btnConvertToGray.BackColor = System.Drawing.Color.Gray;
            this.btnConvertToGray.ForeColor = System.Drawing.Color.White;
            this.btnConvertToGray.Location = new System.Drawing.Point(92, 548);
            this.btnConvertToGray.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnConvertToGray.Name = "btnConvertToGray";
            this.btnConvertToGray.Size = new System.Drawing.Size(93, 22);
            this.btnConvertToGray.TabIndex = 22;
            this.btnConvertToGray.Text = "Convert to Gray";
            this.btnConvertToGray.UseVisualStyleBackColor = false;
            this.btnConvertToGray.Click += new System.EventHandler(this.btnConvertToGray_Click);
            // 
            // btnRotateFillImage
            // 
            this.btnRotateFillImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnRotateFillImage.ForeColor = System.Drawing.Color.Red;
            this.btnRotateFillImage.Location = new System.Drawing.Point(196, 602);
            this.btnRotateFillImage.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnRotateFillImage.Name = "btnRotateFillImage";
            this.btnRotateFillImage.Size = new System.Drawing.Size(93, 22);
            this.btnRotateFillImage.TabIndex = 23;
            this.btnRotateFillImage.Text = "RotateFillImage";
            this.btnRotateFillImage.UseVisualStyleBackColor = false;
            this.btnRotateFillImage.Click += new System.EventHandler(this.btnRotateFillImage_Click);
            // 
            // btnCropAroundMouseClick
            // 
            this.btnCropAroundMouseClick.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnCropAroundMouseClick.ForeColor = System.Drawing.Color.Red;
            this.btnCropAroundMouseClick.Location = new System.Drawing.Point(403, 590);
            this.btnCropAroundMouseClick.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCropAroundMouseClick.Name = "btnCropAroundMouseClick";
            this.btnCropAroundMouseClick.Size = new System.Drawing.Size(112, 35);
            this.btnCropAroundMouseClick.TabIndex = 24;
            this.btnCropAroundMouseClick.Text = "Crop Around One Mouse Click";
            this.btnCropAroundMouseClick.UseVisualStyleBackColor = false;
            this.btnCropAroundMouseClick.Click += new System.EventHandler(this.btnCropAroundMouseClick_Click);
            // 
            // txtCropAroundW
            // 
            this.txtCropAroundW.Location = new System.Drawing.Point(429, 567);
            this.txtCropAroundW.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtCropAroundW.Name = "txtCropAroundW";
            this.txtCropAroundW.Size = new System.Drawing.Size(29, 20);
            this.txtCropAroundW.TabIndex = 25;
            // 
            // txtCropAroundH
            // 
            this.txtCropAroundH.Location = new System.Drawing.Point(476, 567);
            this.txtCropAroundH.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtCropAroundH.Name = "txtCropAroundH";
            this.txtCropAroundH.Size = new System.Drawing.Size(29, 20);
            this.txtCropAroundH.TabIndex = 26;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(409, 567);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(18, 13);
            this.label11.TabIndex = 27;
            this.label11.Text = "W";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(458, 567);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(15, 13);
            this.label12.TabIndex = 28;
            this.label12.Text = "H";
            // 
            // btnBrightenImage
            // 
            this.btnBrightenImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnBrightenImage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnBrightenImage.Location = new System.Drawing.Point(92, 575);
            this.btnBrightenImage.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnBrightenImage.Name = "btnBrightenImage";
            this.btnBrightenImage.Size = new System.Drawing.Size(93, 22);
            this.btnBrightenImage.TabIndex = 29;
            this.btnBrightenImage.Text = "Brighten Image";
            this.btnBrightenImage.UseVisualStyleBackColor = false;
            this.btnBrightenImage.Click += new System.EventHandler(this.btnBrightenImage_Click);
            // 
            // btnChangeContrast
            // 
            this.btnChangeContrast.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnChangeContrast.ForeColor = System.Drawing.Color.Cornsilk;
            this.btnChangeContrast.Location = new System.Drawing.Point(92, 602);
            this.btnChangeContrast.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnChangeContrast.Name = "btnChangeContrast";
            this.btnChangeContrast.Size = new System.Drawing.Size(93, 22);
            this.btnChangeContrast.TabIndex = 30;
            this.btnChangeContrast.Text = "Change Contrast";
            this.btnChangeContrast.UseVisualStyleBackColor = false;
            this.btnChangeContrast.Click += new System.EventHandler(this.btnChangeContrast_Click);
            // 
            // btnSaveProcessedImage
            // 
            this.btnSaveProcessedImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnSaveProcessedImage.Location = new System.Drawing.Point(9, 575);
            this.btnSaveProcessedImage.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSaveProcessedImage.Name = "btnSaveProcessedImage";
            this.btnSaveProcessedImage.Size = new System.Drawing.Size(71, 49);
            this.btnSaveProcessedImage.TabIndex = 31;
            this.btnSaveProcessedImage.Text = "Save Processed Image";
            this.btnSaveProcessedImage.UseVisualStyleBackColor = false;
            this.btnSaveProcessedImage.Click += new System.EventHandler(this.btnSaveProcessedImage_Click);
            // 
            // btnResizeImage
            // 
            this.btnResizeImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnResizeImage.ForeColor = System.Drawing.Color.Red;
            this.btnResizeImage.Location = new System.Drawing.Point(196, 575);
            this.btnResizeImage.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnResizeImage.Name = "btnResizeImage";
            this.btnResizeImage.Size = new System.Drawing.Size(93, 22);
            this.btnResizeImage.TabIndex = 32;
            this.btnResizeImage.Text = "Resize Image";
            this.btnResizeImage.UseVisualStyleBackColor = false;
            this.btnResizeImage.Click += new System.EventHandler(this.btnResizeImage_Click);
            // 
            // label13
            // 
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label13.Location = new System.Drawing.Point(196, 541);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(94, 37);
            this.label13.TabIndex = 33;
            this.label13.Text = "click in top left box for new size";
            // 
            // btnResizeProportional
            // 
            this.btnResizeProportional.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnResizeProportional.ForeColor = System.Drawing.Color.Red;
            this.btnResizeProportional.Location = new System.Drawing.Point(294, 590);
            this.btnResizeProportional.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnResizeProportional.Name = "btnResizeProportional";
            this.btnResizeProportional.Size = new System.Drawing.Size(104, 34);
            this.btnResizeProportional.TabIndex = 34;
            this.btnResizeProportional.Text = "Resize Proportional";
            this.btnResizeProportional.UseVisualStyleBackColor = false;
            this.btnResizeProportional.Click += new System.EventHandler(this.btnResizeProportional_Click);
            // 
            // label14
            // 
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label14.Location = new System.Drawing.Point(294, 541);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(105, 24);
            this.label14.TabIndex = 35;
            this.label14.Text = "Enter New Size";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(346, 567);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(15, 13);
            this.label15.TabIndex = 39;
            this.label15.Text = "H";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(294, 567);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(18, 13);
            this.label16.TabIndex = 38;
            this.label16.Text = "W";
            // 
            // txtNewSizeH
            // 
            this.txtNewSizeH.Location = new System.Drawing.Point(361, 567);
            this.txtNewSizeH.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtNewSizeH.Name = "txtNewSizeH";
            this.txtNewSizeH.Size = new System.Drawing.Size(38, 20);
            this.txtNewSizeH.TabIndex = 37;
            // 
            // txtNewSizeW
            // 
            this.txtNewSizeW.Location = new System.Drawing.Point(310, 567);
            this.txtNewSizeW.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtNewSizeW.Name = "txtNewSizeW";
            this.txtNewSizeW.Size = new System.Drawing.Size(36, 20);
            this.txtNewSizeW.TabIndex = 36;
            // 
            // label17
            // 
            this.label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label17.Location = new System.Drawing.Point(407, 541);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(97, 24);
            this.label17.TabIndex = 40;
            this.label17.Text = "Enter Crop Size";
            // 
            // btnCropAroundDragAndReleaseMouse
            // 
            this.btnCropAroundDragAndReleaseMouse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnCropAroundDragAndReleaseMouse.ForeColor = System.Drawing.Color.Red;
            this.btnCropAroundDragAndReleaseMouse.Location = new System.Drawing.Point(520, 590);
            this.btnCropAroundDragAndReleaseMouse.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCropAroundDragAndReleaseMouse.Name = "btnCropAroundDragAndReleaseMouse";
            this.btnCropAroundDragAndReleaseMouse.Size = new System.Drawing.Size(112, 35);
            this.btnCropAroundDragAndReleaseMouse.TabIndex = 41;
            this.btnCropAroundDragAndReleaseMouse.Text = "Crop Around Drag And Release Mouse";
            this.btnCropAroundDragAndReleaseMouse.UseVisualStyleBackColor = false;
            this.btnCropAroundDragAndReleaseMouse.Click += new System.EventHandler(this.btnCropAroundDragAndReleaseMouse_Click);
            // 
            // btnDraRectangle
            // 
            this.btnDraRectangle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnDraRectangle.Location = new System.Drawing.Point(730, 575);
            this.btnDraRectangle.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDraRectangle.Name = "btnDraRectangle";
            this.btnDraRectangle.Size = new System.Drawing.Size(116, 48);
            this.btnDraRectangle.TabIndex = 42;
            this.btnDraRectangle.Text = "Draw Rectangle (click, drag and release on left image)";
            this.btnDraRectangle.UseVisualStyleBackColor = false;
            this.btnDraRectangle.Click += new System.EventHandler(this.btnDraRectangle_Click);
            // 
            // btnDrawX
            // 
            this.btnDrawX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnDrawX.Location = new System.Drawing.Point(730, 546);
            this.btnDrawX.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDrawX.Name = "btnDrawX";
            this.btnDrawX.Size = new System.Drawing.Size(116, 20);
            this.btnDrawX.TabIndex = 43;
            this.btnDrawX.Text = "DrawX";
            this.btnDrawX.UseVisualStyleBackColor = false;
            this.btnDrawX.Click += new System.EventHandler(this.btnDrawX_Click);
            // 
            // btnRotateClear
            // 
            this.btnRotateClear.BackColor = System.Drawing.Color.Blue;
            this.btnRotateClear.ForeColor = System.Drawing.Color.White;
            this.btnRotateClear.Location = new System.Drawing.Point(520, 548);
            this.btnRotateClear.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnRotateClear.Name = "btnRotateClear";
            this.btnRotateClear.Size = new System.Drawing.Size(112, 19);
            this.btnRotateClear.TabIndex = 44;
            this.btnRotateClear.Text = "Rotate Clear";
            this.btnRotateClear.UseVisualStyleBackColor = false;
            this.btnRotateClear.Click += new System.EventHandler(this.btnRotateClear_Click);
            // 
            // btnRotateByPoints
            // 
            this.btnRotateByPoints.BackColor = System.Drawing.Color.Blue;
            this.btnRotateByPoints.ForeColor = System.Drawing.Color.White;
            this.btnRotateByPoints.Location = new System.Drawing.Point(637, 544);
            this.btnRotateByPoints.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnRotateByPoints.Name = "btnRotateByPoints";
            this.btnRotateByPoints.Size = new System.Drawing.Size(89, 83);
            this.btnRotateByPoints.TabIndex = 45;
            this.btnRotateByPoints.Text = "Rotate By Points (click, drag,release on left image to pick two points)";
            this.btnRotateByPoints.UseVisualStyleBackColor = false;
            this.btnRotateByPoints.Click += new System.EventHandler(this.btnRotateByPoints_Click);
            // 
            // btnRotateFill
            // 
            this.btnRotateFill.BackColor = System.Drawing.Color.Blue;
            this.btnRotateFill.ForeColor = System.Drawing.Color.White;
            this.btnRotateFill.Location = new System.Drawing.Point(520, 572);
            this.btnRotateFill.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnRotateFill.Name = "btnRotateFill";
            this.btnRotateFill.Size = new System.Drawing.Size(112, 19);
            this.btnRotateFill.TabIndex = 46;
            this.btnRotateFill.Text = "Rotate Fill";
            this.btnRotateFill.UseVisualStyleBackColor = false;
            this.btnRotateFill.Click += new System.EventHandler(this.btnRotateFill_Click);
            // 
            // btnShiftHorizontal
            // 
            this.btnShiftHorizontal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnShiftHorizontal.ForeColor = System.Drawing.Color.White;
            this.btnShiftHorizontal.Location = new System.Drawing.Point(860, 546);
            this.btnShiftHorizontal.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnShiftHorizontal.Name = "btnShiftHorizontal";
            this.btnShiftHorizontal.Size = new System.Drawing.Size(90, 24);
            this.btnShiftHorizontal.TabIndex = 47;
            this.btnShiftHorizontal.Text = "Shift Horizontal";
            this.btnShiftHorizontal.UseVisualStyleBackColor = false;
            this.btnShiftHorizontal.Click += new System.EventHandler(this.btnShiftHorizontal_Click);
            // 
            // btnShiftVertical
            // 
            this.btnShiftVertical.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnShiftVertical.ForeColor = System.Drawing.Color.White;
            this.btnShiftVertical.Location = new System.Drawing.Point(860, 577);
            this.btnShiftVertical.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnShiftVertical.Name = "btnShiftVertical";
            this.btnShiftVertical.Size = new System.Drawing.Size(90, 20);
            this.btnShiftVertical.TabIndex = 48;
            this.btnShiftVertical.Text = "Shift Vertical";
            this.btnShiftVertical.UseVisualStyleBackColor = false;
            this.btnShiftVertical.Click += new System.EventHandler(this.btnShiftVertical_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 625);
            this.Controls.Add(this.btnShiftVertical);
            this.Controls.Add(this.btnShiftHorizontal);
            this.Controls.Add(this.btnRotateFill);
            this.Controls.Add(this.btnRotateByPoints);
            this.Controls.Add(this.btnRotateClear);
            this.Controls.Add(this.btnDrawX);
            this.Controls.Add(this.btnDraRectangle);
            this.Controls.Add(this.btnCropAroundDragAndReleaseMouse);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txtNewSizeH);
            this.Controls.Add(this.txtNewSizeW);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.btnResizeProportional);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.btnResizeImage);
            this.Controls.Add(this.btnSaveProcessedImage);
            this.Controls.Add(this.btnChangeContrast);
            this.Controls.Add(this.btnBrightenImage);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtCropAroundH);
            this.Controls.Add(this.txtCropAroundW);
            this.Controls.Add(this.btnCropAroundMouseClick);
            this.Controls.Add(this.btnRotateFillImage);
            this.Controls.Add(this.btnConvertToGray);
            this.Controls.Add(this.lblImageUnderTest);
            this.Controls.Add(this.btnLoadImage);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtMouseRY);
            this.Controls.Add(this.txtMouseRX);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtMouseY);
            this.Controls.Add(this.txtMouseX);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtHeightProc);
            this.Controls.Add(this.txtWidthProc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtHeightOrig);
            this.Controls.Add(this.txtWidthOrig);
            this.Controls.Add(this.picProcImage);
            this.Controls.Add(this.picOrigImage);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picOrigImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picProcImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picOrigImage;
        private System.Windows.Forms.PictureBox picProcImage;
        private System.Windows.Forms.TextBox txtWidthOrig;
        private System.Windows.Forms.TextBox txtHeightOrig;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtHeightProc;
        private System.Windows.Forms.TextBox txtWidthProc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMouseY;
        private System.Windows.Forms.TextBox txtMouseX;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtMouseRY;
        private System.Windows.Forms.TextBox txtMouseRX;
        private System.Windows.Forms.Button btnLoadImage;
        private System.Windows.Forms.Label lblImageUnderTest;
        private System.Windows.Forms.Button btnConvertToGray;
        private System.Windows.Forms.Button btnRotateFillImage;
        private System.Windows.Forms.Button btnCropAroundMouseClick;
        private System.Windows.Forms.TextBox txtCropAroundW;
        private System.Windows.Forms.TextBox txtCropAroundH;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnBrightenImage;
        private System.Windows.Forms.Button btnChangeContrast;
        private System.Windows.Forms.Button btnSaveProcessedImage;
        private System.Windows.Forms.Button btnResizeImage;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnResizeProportional;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtNewSizeH;
        private System.Windows.Forms.TextBox txtNewSizeW;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btnCropAroundDragAndReleaseMouse;
        private System.Windows.Forms.Button btnDraRectangle;
        private System.Windows.Forms.Button btnDrawX;
        private System.Windows.Forms.Button btnRotateClear;
        private System.Windows.Forms.Button btnRotateByPoints;
        private System.Windows.Forms.Button btnRotateFill;
        private System.Windows.Forms.Button btnShiftHorizontal;
        private System.Windows.Forms.Button btnShiftVertical;
    }
}

