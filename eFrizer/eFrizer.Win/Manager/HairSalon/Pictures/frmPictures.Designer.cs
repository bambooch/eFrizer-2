﻿
namespace eFrizer.Win
{
    partial class frmPictures
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
            this.btnNew = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.pbHairSalon = new System.Windows.Forms.PictureBox();
            this.ofdNewImage = new System.Windows.Forms.OpenFileDialog();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbHairSalon)).BeginInit();
            this.SuspendLayout();
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(12, 293);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(600, 32);
            this.btnNew.TabIndex = 0;
            this.btnNew.Text = "Add new photo";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(322, 255);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(290, 32);
            this.btnNext.TabIndex = 1;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(12, 255);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(290, 32);
            this.btnPrevious.TabIndex = 2;
            this.btnPrevious.Text = "Previous";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // pbHairSalon
            // 
            this.pbHairSalon.Location = new System.Drawing.Point(12, 21);
            this.pbHairSalon.Name = "pbHairSalon";
            this.pbHairSalon.Size = new System.Drawing.Size(600, 228);
            this.pbHairSalon.TabIndex = 3;
            this.pbHairSalon.TabStop = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(12, 331);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(600, 32);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Delete selected photo";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // frmPictures
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 370);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.pbHairSalon);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnNew);
            this.Name = "frmPictures";
            this.Text = "frmPictures";
            this.Load += new System.EventHandler(this.frmPictures_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbHairSalon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.PictureBox pbHairSalon;
        private System.Windows.Forms.OpenFileDialog ofdNewImage;
        private System.Windows.Forms.Button btnDelete;
    }
}