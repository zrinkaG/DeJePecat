namespace DeJePecat
{
    partial class LabelResults
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
            this.btnLabel = new System.Windows.Forms.Button();
            this.btnSource = new System.Windows.Forms.Button();
            this.txtSource = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.gbImage = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pbCut = new System.Windows.Forms.PictureBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnDestination = new System.Windows.Forms.Button();
            this.txtDestination = new System.Windows.Forms.TextBox();
            this.btnCreateJson = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.gbImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCut)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLabel
            // 
            this.btnLabel.Location = new System.Drawing.Point(139, 65);
            this.btnLabel.Name = "btnLabel";
            this.btnLabel.Size = new System.Drawing.Size(156, 46);
            this.btnLabel.TabIndex = 14;
            this.btnLabel.Text = "START LABEL";
            this.btnLabel.UseVisualStyleBackColor = true;
            this.btnLabel.Click += new System.EventHandler(this.btnLabel_Click);
            // 
            // btnSource
            // 
            this.btnSource.Location = new System.Drawing.Point(452, 10);
            this.btnSource.Name = "btnSource";
            this.btnSource.Size = new System.Drawing.Size(119, 23);
            this.btnSource.TabIndex = 13;
            this.btnSource.Text = "Source";
            this.btnSource.UseVisualStyleBackColor = true;
            this.btnSource.Click += new System.EventHandler(this.btnComparisonResultPath_Click);
            // 
            // txtSource
            // 
            this.txtSource.Location = new System.Drawing.Point(12, 12);
            this.txtSource.Name = "txtSource";
            this.txtSource.Size = new System.Drawing.Size(434, 20);
            this.txtSource.TabIndex = 12;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(6, 32);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(421, 595);
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // gbImage
            // 
            this.gbImage.Controls.Add(this.label2);
            this.gbImage.Controls.Add(this.label1);
            this.gbImage.Controls.Add(this.pbCut);
            this.gbImage.Controls.Add(this.btnOK);
            this.gbImage.Controls.Add(this.pictureBox1);
            this.gbImage.Location = new System.Drawing.Point(12, 117);
            this.gbImage.Name = "gbImage";
            this.gbImage.Size = new System.Drawing.Size(559, 622);
            this.gbImage.TabIndex = 16;
            this.gbImage.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(437, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Extracted image";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Original image";
            // 
            // pbCut
            // 
            this.pbCut.Location = new System.Drawing.Point(440, 31);
            this.pbCut.Name = "pbCut";
            this.pbCut.Size = new System.Drawing.Size(100, 100);
            this.pbCut.TabIndex = 17;
            this.pbCut.TabStop = false;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(440, 137);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 29);
            this.btnOK.TabIndex = 16;
            this.btnOK.Text = "Next";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnDestination
            // 
            this.btnDestination.Location = new System.Drawing.Point(452, 36);
            this.btnDestination.Name = "btnDestination";
            this.btnDestination.Size = new System.Drawing.Size(119, 23);
            this.btnDestination.TabIndex = 18;
            this.btnDestination.Text = "Destination";
            this.btnDestination.UseVisualStyleBackColor = true;
            this.btnDestination.Click += new System.EventHandler(this.btnDestination_Click);
            // 
            // txtDestination
            // 
            this.txtDestination.Location = new System.Drawing.Point(12, 38);
            this.txtDestination.Name = "txtDestination";
            this.txtDestination.Size = new System.Drawing.Size(434, 20);
            this.txtDestination.TabIndex = 17;
            // 
            // btnCreateJson
            // 
            this.btnCreateJson.Location = new System.Drawing.Point(301, 65);
            this.btnCreateJson.Name = "btnCreateJson";
            this.btnCreateJson.Size = new System.Drawing.Size(145, 46);
            this.btnCreateJson.TabIndex = 19;
            this.btnCreateJson.Text = "CREATE JSON";
            this.btnCreateJson.UseVisualStyleBackColor = true;
            this.btnCreateJson.Click += new System.EventHandler(this.btnCreateJson_Click);
            // 
            // LabelResults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 745);
            this.Controls.Add(this.btnCreateJson);
            this.Controls.Add(this.btnDestination);
            this.Controls.Add(this.txtDestination);
            this.Controls.Add(this.gbImage);
            this.Controls.Add(this.btnLabel);
            this.Controls.Add(this.btnSource);
            this.Controls.Add(this.txtSource);
            this.Name = "LabelResults";
            this.Text = "Label Results";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.gbImage.ResumeLayout(false);
            this.gbImage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCut)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLabel;
        private System.Windows.Forms.Button btnSource;
        private System.Windows.Forms.TextBox txtSource;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox gbImage;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnDestination;
        private System.Windows.Forms.TextBox txtDestination;
        private System.Windows.Forms.PictureBox pbCut;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCreateJson;
    }
}