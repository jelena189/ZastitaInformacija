﻿namespace ZIKlijent
{
    partial class MainForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnIV = new System.Windows.Forms.Button();
            this.txtIV = new System.Windows.Forms.TextBox();
            this.btnKljuc = new System.Windows.Forms.Button();
            this.txtKljuc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnUpload = new System.Windows.Forms.Button();
            this.lblPad = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnDownload = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lv1 = new System.Windows.Forms.ListView();
            this.ofdUploadFile = new System.Windows.Forms.OpenFileDialog();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtP = new System.Windows.Forms.TextBox();
            this.txtA = new System.Windows.Forms.TextBox();
            this.txtX = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(211, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "IV:";
            // 
            // btnIV
            // 
            this.btnIV.BackColor = System.Drawing.Color.PeachPuff;
            this.btnIV.Location = new System.Drawing.Point(140, 67);
            this.btnIV.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnIV.Name = "btnIV";
            this.btnIV.Size = new System.Drawing.Size(194, 41);
            this.btnIV.TabIndex = 3;
            this.btnIV.Text = "Generisi random iv";
            this.btnIV.UseVisualStyleBackColor = false;
            this.btnIV.Click += new System.EventHandler(this.btnIV_Click);
            // 
            // txtIV
            // 
            this.txtIV.Location = new System.Drawing.Point(140, 32);
            this.txtIV.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtIV.Name = "txtIV";
            this.txtIV.Size = new System.Drawing.Size(194, 27);
            this.txtIV.TabIndex = 4;
            // 
            // btnKljuc
            // 
            this.btnKljuc.BackColor = System.Drawing.Color.PeachPuff;
            this.btnKljuc.Location = new System.Drawing.Point(126, 89);
            this.btnKljuc.Name = "btnKljuc";
            this.btnKljuc.Size = new System.Drawing.Size(194, 41);
            this.btnKljuc.TabIndex = 3;
            this.btnKljuc.Text = "Generisi random kljuc";
            this.btnKljuc.UseVisualStyleBackColor = false;
            this.btnKljuc.Click += new System.EventHandler(this.btnKljuc_Click);
            // 
            // txtKljuc
            // 
            this.txtKljuc.Location = new System.Drawing.Point(126, 47);
            this.txtKljuc.Name = "txtKljuc";
            this.txtKljuc.Size = new System.Drawing.Size(194, 27);
            this.txtKljuc.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(186, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Kljuc:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 19);
            this.label3.TabIndex = 7;
            this.label3.Text = "Algoritam:";
            // 
            // btnUpload
            // 
            this.btnUpload.BackColor = System.Drawing.Color.LightSalmon;
            this.btnUpload.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpload.Location = new System.Drawing.Point(151, 606);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(194, 41);
            this.btnUpload.TabIndex = 9;
            this.btnUpload.Text = "Upload";
            this.btnUpload.UseVisualStyleBackColor = false;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // lblPad
            // 
            this.lblPad.AutoSize = true;
            this.lblPad.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPad.Location = new System.Drawing.Point(122, 172);
            this.lblPad.Name = "lblPad";
            this.lblPad.Size = new System.Drawing.Size(36, 19);
            this.lblPad.TabIndex = 10;
            this.lblPad.Text = "pad";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnDownload);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.lv1);
            this.groupBox3.Location = new System.Drawing.Point(454, -10);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(599, 676);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            // 
            // btnDownload
            // 
            this.btnDownload.BackColor = System.Drawing.Color.LightSalmon;
            this.btnDownload.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDownload.Location = new System.Drawing.Point(32, 616);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(194, 40);
            this.btnDownload.TabIndex = 2;
            this.btnDownload.Text = "Download";
            this.btnDownload.UseVisualStyleBackColor = false;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 19);
            this.label4.TabIndex = 1;
            this.label4.Text = "Dostupni fajlovi:";
            // 
            // lv1
            // 
            this.lv1.HideSelection = false;
            this.lv1.Location = new System.Drawing.Point(32, 63);
            this.lv1.MultiSelect = false;
            this.lv1.Name = "lv1";
            this.lv1.Size = new System.Drawing.Size(544, 530);
            this.lv1.TabIndex = 0;
            this.lv1.UseCompatibleStateImageBehavior = false;
            this.lv1.View = System.Windows.Forms.View.List;
            // 
            // ofdUploadFile
            // 
            this.ofdUploadFile.FileName = "openFileDialog1";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton1.Location = new System.Drawing.Point(5, 68);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(54, 23);
            this.radioButton1.TabIndex = 4;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Tea";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton2.Location = new System.Drawing.Point(6, 172);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(64, 23);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "OTP";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton3.Location = new System.Drawing.Point(6, 301);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(97, 23);
            this.radioButton3.TabIndex = 1;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "ElGamal";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button1);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.txtX);
            this.groupBox4.Controls.Add(this.txtA);
            this.groupBox4.Controls.Add(this.txtP);
            this.groupBox4.Controls.Add(this.btnKljuc);
            this.groupBox4.Controls.Add(this.radioButton3);
            this.groupBox4.Controls.Add(this.lblPad);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.txtKljuc);
            this.groupBox4.Controls.Add(this.radioButton1);
            this.groupBox4.Controls.Add(this.radioButton2);
            this.groupBox4.Location = new System.Drawing.Point(25, 156);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(408, 427);
            this.groupBox4.TabIndex = 12;
            this.groupBox4.TabStop = false;
            // 
            // txtP
            // 
            this.txtP.Location = new System.Drawing.Point(244, 256);
            this.txtP.Name = "txtP";
            this.txtP.Size = new System.Drawing.Size(130, 27);
            this.txtP.TabIndex = 11;
            // 
            // txtA
            // 
            this.txtA.Location = new System.Drawing.Point(244, 295);
            this.txtA.Name = "txtA";
            this.txtA.Size = new System.Drawing.Size(130, 27);
            this.txtA.TabIndex = 12;
            // 
            // txtX
            // 
            this.txtX.Location = new System.Drawing.Point(244, 335);
            this.txtX.Name = "txtX";
            this.txtX.Size = new System.Drawing.Size(130, 27);
            this.txtX.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(152, 256);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 19);
            this.label5.TabIndex = 14;
            this.label5.Text = "P (moduo):";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(213, 295);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 19);
            this.label6.TabIndex = 15;
            this.label6.Text = "a:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(111, 335);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(127, 19);
            this.label7.TabIndex = 16;
            this.label7.Text = "x (privatni kljuc):";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.PeachPuff;
            this.button1.Location = new System.Drawing.Point(217, 379);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(157, 33);
            this.button1.TabIndex = 17;
            this.button1.Text = "Generisi vrednosti";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LemonChiffon;
            this.ClientSize = new System.Drawing.Size(1049, 659);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtIV);
            this.Controls.Add(this.btnIV);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnIV;
        private System.Windows.Forms.TextBox txtIV;
        private System.Windows.Forms.TextBox txtKljuc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnKljuc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Label lblPad;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView lv1;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.OpenFileDialog ofdUploadFile;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtX;
        private System.Windows.Forms.TextBox txtA;
        private System.Windows.Forms.TextBox txtP;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label7;
    }
}

