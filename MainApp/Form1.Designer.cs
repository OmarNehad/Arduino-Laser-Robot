namespace MainApp
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.buttonResetRobot = new System.Windows.Forms.Button();
            this.buttonTestRobot = new System.Windows.Forms.Button();
            this.buttonShoot = new System.Windows.Forms.Button();
            this.labelAverage = new System.Windows.Forms.Label();
            this.labelScale = new System.Windows.Forms.Label();
            this.labelHeight = new System.Windows.Forms.Label();
            this.labelWidth = new System.Windows.Forms.Label();
            this.buttonCalibration = new System.Windows.Forms.Button();
            this.buttonStopCamera = new System.Windows.Forms.Button();
            this.buttonStartCamera = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxTheta_1 = new System.Windows.Forms.TextBox();
            this.textBoxX_Pix = new System.Windows.Forms.TextBox();
            this.textBoxTheta_2 = new System.Windows.Forms.TextBox();
            this.textBoxY_Pix = new System.Windows.Forms.TextBox();
            this.textBoxZ_Cm = new System.Windows.Forms.TextBox();
            this.textBoxY_Cm = new System.Windows.Forms.TextBox();
            this.textBoxX_Cm = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.trackBarRedCor = new System.Windows.Forms.TrackBar();
            this.trackBarRedThr = new System.Windows.Forms.TrackBar();
            this.trackBarBlackCor = new System.Windows.Forms.TrackBar();
            this.trackBarBlackThr = new System.Windows.Forms.TrackBar();
            this.labelRedImage = new System.Windows.Forms.Label();
            this.labelBlackImage = new System.Windows.Forms.Label();
            this.imageBoxRed = new Emgu.CV.UI.ImageBox();
            this.imageBoxBlack = new Emgu.CV.UI.ImageBox();
            this.imageBoxOriginal = new Emgu.CV.UI.ImageBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRedCor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRedThr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBlackCor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBlackThr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxRed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxBlack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxOriginal)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.buttonResetRobot);
            this.splitContainer1.Panel1.Controls.Add(this.buttonTestRobot);
            this.splitContainer1.Panel1.Controls.Add(this.buttonShoot);
            this.splitContainer1.Panel1.Controls.Add(this.labelAverage);
            this.splitContainer1.Panel1.Controls.Add(this.labelScale);
            this.splitContainer1.Panel1.Controls.Add(this.labelHeight);
            this.splitContainer1.Panel1.Controls.Add(this.labelWidth);
            this.splitContainer1.Panel1.Controls.Add(this.buttonCalibration);
            this.splitContainer1.Panel1.Controls.Add(this.buttonStopCamera);
            this.splitContainer1.Panel1.Controls.Add(this.buttonStartCamera);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label11);
            this.splitContainer1.Panel2.Controls.Add(this.label10);
            this.splitContainer1.Panel2.Controls.Add(this.label9);
            this.splitContainer1.Panel2.Controls.Add(this.label8);
            this.splitContainer1.Panel2.Controls.Add(this.label7);
            this.splitContainer1.Panel2.Controls.Add(this.label6);
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this.textBoxTheta_1);
            this.splitContainer1.Panel2.Controls.Add(this.textBoxX_Pix);
            this.splitContainer1.Panel2.Controls.Add(this.textBoxTheta_2);
            this.splitContainer1.Panel2.Controls.Add(this.textBoxY_Pix);
            this.splitContainer1.Panel2.Controls.Add(this.textBoxZ_Cm);
            this.splitContainer1.Panel2.Controls.Add(this.textBoxY_Cm);
            this.splitContainer1.Panel2.Controls.Add(this.textBoxX_Cm);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.trackBarRedCor);
            this.splitContainer1.Panel2.Controls.Add(this.trackBarRedThr);
            this.splitContainer1.Panel2.Controls.Add(this.trackBarBlackCor);
            this.splitContainer1.Panel2.Controls.Add(this.trackBarBlackThr);
            this.splitContainer1.Panel2.Controls.Add(this.labelRedImage);
            this.splitContainer1.Panel2.Controls.Add(this.labelBlackImage);
            this.splitContainer1.Panel2.Controls.Add(this.imageBoxRed);
            this.splitContainer1.Panel2.Controls.Add(this.imageBoxBlack);
            this.splitContainer1.Panel2.Controls.Add(this.imageBoxOriginal);
            this.splitContainer1.Size = new System.Drawing.Size(1338, 875);
            this.splitContainer1.SplitterDistance = 285;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 0;
            // 
            // buttonResetRobot
            // 
            this.buttonResetRobot.BackColor = System.Drawing.Color.Silver;
            this.buttonResetRobot.Location = new System.Drawing.Point(156, 141);
            this.buttonResetRobot.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonResetRobot.Name = "buttonResetRobot";
            this.buttonResetRobot.Size = new System.Drawing.Size(114, 29);
            this.buttonResetRobot.TabIndex = 10;
            this.buttonResetRobot.Text = "Reset Robot";
            this.buttonResetRobot.UseVisualStyleBackColor = false;
            this.buttonResetRobot.Click += new System.EventHandler(this.buttonResetRobot_Click);
            // 
            // buttonTestRobot
            // 
            this.buttonTestRobot.BackColor = System.Drawing.Color.Silver;
            this.buttonTestRobot.Location = new System.Drawing.Point(38, 141);
            this.buttonTestRobot.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonTestRobot.Name = "buttonTestRobot";
            this.buttonTestRobot.Size = new System.Drawing.Size(112, 29);
            this.buttonTestRobot.TabIndex = 9;
            this.buttonTestRobot.Text = "Test Robot";
            this.buttonTestRobot.UseVisualStyleBackColor = false;
            this.buttonTestRobot.Click += new System.EventHandler(this.buttonTestRobot_Click);
            // 
            // buttonShoot
            // 
            this.buttonShoot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonShoot.Location = new System.Drawing.Point(87, 528);
            this.buttonShoot.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonShoot.Name = "buttonShoot";
            this.buttonShoot.Size = new System.Drawing.Size(112, 121);
            this.buttonShoot.TabIndex = 8;
            this.buttonShoot.Text = "SHOOT!!!";
            this.buttonShoot.UseVisualStyleBackColor = false;
            this.buttonShoot.Click += new System.EventHandler(this.buttonShoot_Click);
            // 
            // labelAverage
            // 
            this.labelAverage.AutoSize = true;
            this.labelAverage.Location = new System.Drawing.Point(15, 443);
            this.labelAverage.Name = "labelAverage";
            this.labelAverage.Size = new System.Drawing.Size(68, 20);
            this.labelAverage.TabIndex = 7;
            this.labelAverage.Text = "Average";
            // 
            // labelScale
            // 
            this.labelScale.AutoSize = true;
            this.labelScale.Location = new System.Drawing.Point(34, 407);
            this.labelScale.Name = "labelScale";
            this.labelScale.Size = new System.Drawing.Size(49, 20);
            this.labelScale.TabIndex = 6;
            this.labelScale.Text = "Scale";
            // 
            // labelHeight
            // 
            this.labelHeight.AutoSize = true;
            this.labelHeight.Location = new System.Drawing.Point(28, 370);
            this.labelHeight.Name = "labelHeight";
            this.labelHeight.Size = new System.Drawing.Size(56, 20);
            this.labelHeight.TabIndex = 5;
            this.labelHeight.Text = "Height";
            // 
            // labelWidth
            // 
            this.labelWidth.AutoSize = true;
            this.labelWidth.Location = new System.Drawing.Point(34, 334);
            this.labelWidth.Name = "labelWidth";
            this.labelWidth.Size = new System.Drawing.Size(50, 20);
            this.labelWidth.TabIndex = 4;
            this.labelWidth.Text = "Width";
            // 
            // buttonCalibration
            // 
            this.buttonCalibration.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonCalibration.Location = new System.Drawing.Point(87, 287);
            this.buttonCalibration.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonCalibration.Name = "buttonCalibration";
            this.buttonCalibration.Size = new System.Drawing.Size(112, 29);
            this.buttonCalibration.TabIndex = 3;
            this.buttonCalibration.Text = "Calibrate";
            this.buttonCalibration.UseVisualStyleBackColor = false;
            this.buttonCalibration.Click += new System.EventHandler(this.buttonCalibration_Click);
            // 
            // buttonStopCamera
            // 
            this.buttonStopCamera.Enabled = false;
            this.buttonStopCamera.Location = new System.Drawing.Point(152, 62);
            this.buttonStopCamera.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonStopCamera.Name = "buttonStopCamera";
            this.buttonStopCamera.Size = new System.Drawing.Size(112, 35);
            this.buttonStopCamera.TabIndex = 1;
            this.buttonStopCamera.Text = "Stop Camera";
            this.buttonStopCamera.UseVisualStyleBackColor = true;
            this.buttonStopCamera.Click += new System.EventHandler(this.buttonStopCamera_Click);
            // 
            // buttonStartCamera
            // 
            this.buttonStartCamera.Location = new System.Drawing.Point(32, 62);
            this.buttonStartCamera.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonStartCamera.Name = "buttonStartCamera";
            this.buttonStartCamera.Size = new System.Drawing.Size(112, 35);
            this.buttonStartCamera.TabIndex = 0;
            this.buttonStartCamera.Text = "Start Camera";
            this.buttonStartCamera.UseVisualStyleBackColor = true;
            this.buttonStartCamera.Click += new System.EventHandler(this.buttonStartCamera_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(695, 696);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 20);
            this.label11.TabIndex = 29;
            this.label11.Text = "Theta 2";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(695, 661);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 20);
            this.label10.TabIndex = 28;
            this.label10.Text = "Theta 1";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(412, 696);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 20);
            this.label9.TabIndex = 27;
            this.label9.Text = "Y Pix";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(414, 661);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 20);
            this.label8.TabIndex = 26;
            this.label8.Text = "X Pix";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(91, 731);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 20);
            this.label7.TabIndex = 25;
            this.label7.Text = "Z Cm";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(90, 699);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 20);
            this.label6.TabIndex = 24;
            this.label6.Text = "Y Cm";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(91, 661);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 20);
            this.label5.TabIndex = 23;
            this.label5.Text = "X Cm";
            // 
            // textBoxTheta_1
            // 
            this.textBoxTheta_1.Location = new System.Drawing.Point(759, 658);
            this.textBoxTheta_1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxTheta_1.Name = "textBoxTheta_1";
            this.textBoxTheta_1.Size = new System.Drawing.Size(112, 26);
            this.textBoxTheta_1.TabIndex = 22;
            // 
            // textBoxX_Pix
            // 
            this.textBoxX_Pix.Location = new System.Drawing.Point(460, 658);
            this.textBoxX_Pix.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxX_Pix.Name = "textBoxX_Pix";
            this.textBoxX_Pix.Size = new System.Drawing.Size(112, 26);
            this.textBoxX_Pix.TabIndex = 21;
            // 
            // textBoxTheta_2
            // 
            this.textBoxTheta_2.Location = new System.Drawing.Point(759, 692);
            this.textBoxTheta_2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxTheta_2.Name = "textBoxTheta_2";
            this.textBoxTheta_2.Size = new System.Drawing.Size(112, 26);
            this.textBoxTheta_2.TabIndex = 20;
            // 
            // textBoxY_Pix
            // 
            this.textBoxY_Pix.Location = new System.Drawing.Point(460, 692);
            this.textBoxY_Pix.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxY_Pix.Name = "textBoxY_Pix";
            this.textBoxY_Pix.Size = new System.Drawing.Size(112, 26);
            this.textBoxY_Pix.TabIndex = 19;
            // 
            // textBoxZ_Cm
            // 
            this.textBoxZ_Cm.Location = new System.Drawing.Point(141, 728);
            this.textBoxZ_Cm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxZ_Cm.Name = "textBoxZ_Cm";
            this.textBoxZ_Cm.Size = new System.Drawing.Size(112, 26);
            this.textBoxZ_Cm.TabIndex = 18;
            // 
            // textBoxY_Cm
            // 
            this.textBoxY_Cm.Location = new System.Drawing.Point(141, 692);
            this.textBoxY_Cm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxY_Cm.Name = "textBoxY_Cm";
            this.textBoxY_Cm.Size = new System.Drawing.Size(112, 26);
            this.textBoxY_Cm.TabIndex = 17;
            // 
            // textBoxX_Cm
            // 
            this.textBoxX_Cm.Location = new System.Drawing.Point(141, 658);
            this.textBoxX_Cm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxX_Cm.Name = "textBoxX_Cm";
            this.textBoxX_Cm.Size = new System.Drawing.Size(112, 26);
            this.textBoxX_Cm.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(584, 580);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 20);
            this.label4.TabIndex = 15;
            this.label4.Text = "Corrosion";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(573, 504);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 20);
            this.label3.TabIndex = 14;
            this.label3.Text = "Threshhold";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(61, 580);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 20);
            this.label2.TabIndex = 13;
            this.label2.Text = "Corrosion";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 504);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "Threshhold";
            // 
            // trackBarRedCor
            // 
            this.trackBarRedCor.Location = new System.Drawing.Point(664, 580);
            this.trackBarRedCor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.trackBarRedCor.Name = "trackBarRedCor";
            this.trackBarRedCor.Size = new System.Drawing.Size(343, 69);
            this.trackBarRedCor.TabIndex = 11;
            // 
            // trackBarRedThr
            // 
            this.trackBarRedThr.Location = new System.Drawing.Point(664, 502);
            this.trackBarRedThr.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.trackBarRedThr.Maximum = 255;
            this.trackBarRedThr.Name = "trackBarRedThr";
            this.trackBarRedThr.Size = new System.Drawing.Size(343, 69);
            this.trackBarRedThr.TabIndex = 10;
            // 
            // trackBarBlackCor
            // 
            this.trackBarBlackCor.Location = new System.Drawing.Point(141, 580);
            this.trackBarBlackCor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.trackBarBlackCor.Name = "trackBarBlackCor";
            this.trackBarBlackCor.Size = new System.Drawing.Size(351, 69);
            this.trackBarBlackCor.TabIndex = 9;
            // 
            // trackBarBlackThr
            // 
            this.trackBarBlackThr.Location = new System.Drawing.Point(141, 502);
            this.trackBarBlackThr.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.trackBarBlackThr.Maximum = 255;
            this.trackBarBlackThr.Name = "trackBarBlackThr";
            this.trackBarBlackThr.Size = new System.Drawing.Size(351, 69);
            this.trackBarBlackThr.TabIndex = 8;
            // 
            // labelRedImage
            // 
            this.labelRedImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRedImage.Location = new System.Drawing.Point(755, 151);
            this.labelRedImage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelRedImage.Name = "labelRedImage";
            this.labelRedImage.Size = new System.Drawing.Size(73, 35);
            this.labelRedImage.TabIndex = 7;
            this.labelRedImage.Text = "Red";
            // 
            // labelBlackImage
            // 
            this.labelBlackImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBlackImage.Location = new System.Drawing.Point(201, 145);
            this.labelBlackImage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelBlackImage.Name = "labelBlackImage";
            this.labelBlackImage.Size = new System.Drawing.Size(73, 35);
            this.labelBlackImage.TabIndex = 6;
            this.labelBlackImage.Text = "Black";
            // 
            // imageBoxRed
            // 
            this.imageBoxRed.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.imageBoxRed.Location = new System.Drawing.Point(543, 191);
            this.imageBoxRed.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.imageBoxRed.Name = "imageBoxRed";
            this.imageBoxRed.Size = new System.Drawing.Size(464, 302);
            this.imageBoxRed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageBoxRed.TabIndex = 3;
            this.imageBoxRed.TabStop = false;
            // 
            // imageBoxBlack
            // 
            this.imageBoxBlack.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.imageBoxBlack.Location = new System.Drawing.Point(28, 191);
            this.imageBoxBlack.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.imageBoxBlack.Name = "imageBoxBlack";
            this.imageBoxBlack.Size = new System.Drawing.Size(464, 302);
            this.imageBoxBlack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageBoxBlack.TabIndex = 2;
            this.imageBoxBlack.TabStop = false;
            // 
            // imageBoxOriginal
            // 
            this.imageBoxOriginal.Location = new System.Drawing.Point(388, 19);
            this.imageBoxOriginal.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.imageBoxOriginal.Name = "imageBoxOriginal";
            this.imageBoxOriginal.Size = new System.Drawing.Size(258, 162);
            this.imageBoxOriginal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageBoxOriginal.TabIndex = 2;
            this.imageBoxOriginal.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1338, 875);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRedCor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRedThr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBlackCor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBlackThr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxRed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxBlack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxOriginal)).EndInit();
            this.ResumeLayout(false);

        }
        private Emgu.CV.UI.ImageBox imageBoxRed;
        private System.Windows.Forms.Label labelBlackImage;
        private System.Windows.Forms.Label labelRedImage;

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button buttonStopCamera;
        private System.Windows.Forms.Button buttonStartCamera;
        private Emgu.CV.UI.ImageBox imageBoxOriginal;
        private Emgu.CV.UI.ImageBox imageBoxBlack;
        private System.Windows.Forms.Button buttonResetRobot;
        private System.Windows.Forms.Button buttonTestRobot;
        private System.Windows.Forms.Button buttonShoot;
        private System.Windows.Forms.Label labelAverage;
        private System.Windows.Forms.Label labelScale;
        private System.Windows.Forms.Label labelHeight;
        private System.Windows.Forms.Label labelWidth;
        private System.Windows.Forms.Button buttonCalibration;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxTheta_1;
        private System.Windows.Forms.TextBox textBoxX_Pix;
        private System.Windows.Forms.TextBox textBoxTheta_2;
        private System.Windows.Forms.TextBox textBoxY_Pix;
        private System.Windows.Forms.TextBox textBoxZ_Cm;
        private System.Windows.Forms.TextBox textBoxY_Cm;
        private System.Windows.Forms.TextBox textBoxX_Cm;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar trackBarRedCor;
        private System.Windows.Forms.TrackBar trackBarRedThr;
        private System.Windows.Forms.TrackBar trackBarBlackCor;
        private System.Windows.Forms.TrackBar trackBarBlackThr;
    }
}

