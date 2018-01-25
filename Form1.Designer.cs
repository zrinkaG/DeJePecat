namespace DeJePecat
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
            this.txtSourcePath = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chbPGAlgorithm = new System.Windows.Forms.CheckBox();
            this.chbHughes = new System.Windows.Forms.CheckBox();
            this.chbMatchingTemplate = new System.Windows.Forms.CheckBox();
            this.btnBrowseDestination = new System.Windows.Forms.Button();
            this.txtDestPath = new System.Windows.Forms.TextBox();
            this.chbCreateCompFiles = new System.Windows.Forms.CheckBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSourcePath
            // 
            this.txtSourcePath.Location = new System.Drawing.Point(13, 13);
            this.txtSourcePath.Name = "txtSourcePath";
            this.txtSourcePath.Size = new System.Drawing.Size(627, 20);
            this.txtSourcePath.TabIndex = 0;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(646, 10);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(119, 23);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Text = "Source folder";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chbCreateCompFiles);
            this.groupBox1.Controls.Add(this.chbPGAlgorithm);
            this.groupBox1.Controls.Add(this.btnStart);
            this.groupBox1.Controls.Add(this.chbHughes);
            this.groupBox1.Controls.Add(this.chbMatchingTemplate);
            this.groupBox1.Location = new System.Drawing.Point(13, 74);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(753, 140);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detecting Algorithms";
            // 
            // chbPGAlgorithm
            // 
            this.chbPGAlgorithm.AutoSize = true;
            this.chbPGAlgorithm.Location = new System.Drawing.Point(6, 78);
            this.chbPGAlgorithm.Name = "chbPGAlgorithm";
            this.chbPGAlgorithm.Size = new System.Drawing.Size(86, 17);
            this.chbPGAlgorithm.TabIndex = 2;
            this.chbPGAlgorithm.Text = "PG algorithm";
            this.chbPGAlgorithm.UseVisualStyleBackColor = true;
            // 
            // chbHughes
            // 
            this.chbHughes.AutoSize = true;
            this.chbHughes.Location = new System.Drawing.Point(6, 54);
            this.chbHughes.Name = "chbHughes";
            this.chbHughes.Size = new System.Drawing.Size(126, 17);
            this.chbHughes.TabIndex = 1;
            this.chbHughes.Text = "Huges transformation";
            this.chbHughes.UseVisualStyleBackColor = true;
            // 
            // chbMatchingTemplate
            // 
            this.chbMatchingTemplate.AutoSize = true;
            this.chbMatchingTemplate.Location = new System.Drawing.Point(6, 30);
            this.chbMatchingTemplate.Name = "chbMatchingTemplate";
            this.chbMatchingTemplate.Size = new System.Drawing.Size(113, 17);
            this.chbMatchingTemplate.TabIndex = 0;
            this.chbMatchingTemplate.Text = "Matching template";
            this.chbMatchingTemplate.UseVisualStyleBackColor = true;
            // 
            // btnBrowseDestination
            // 
            this.btnBrowseDestination.Location = new System.Drawing.Point(646, 36);
            this.btnBrowseDestination.Name = "btnBrowseDestination";
            this.btnBrowseDestination.Size = new System.Drawing.Size(119, 23);
            this.btnBrowseDestination.TabIndex = 4;
            this.btnBrowseDestination.Text = "Destination folder";
            this.btnBrowseDestination.UseVisualStyleBackColor = true;
            this.btnBrowseDestination.Click += new System.EventHandler(this.btnBrowseDestination_Click);
            // 
            // txtDestPath
            // 
            this.txtDestPath.Location = new System.Drawing.Point(12, 39);
            this.txtDestPath.Name = "txtDestPath";
            this.txtDestPath.Size = new System.Drawing.Size(627, 20);
            this.txtDestPath.TabIndex = 3;
            // 
            // chbCreateCompFiles
            // 
            this.chbCreateCompFiles.AutoSize = true;
            this.chbCreateCompFiles.Location = new System.Drawing.Point(6, 117);
            this.chbCreateCompFiles.Name = "chbCreateCompFiles";
            this.chbCreateCompFiles.Size = new System.Drawing.Size(135, 17);
            this.chbCreateCompFiles.TabIndex = 5;
            this.chbCreateCompFiles.Text = "Create comparison files";
            this.chbCreateCompFiles.UseVisualStyleBackColor = true;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(634, 78);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(114, 48);
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "START";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 221);
            this.Controls.Add(this.btnBrowseDestination);
            this.Controls.Add(this.txtDestPath);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtSourcePath);
            this.Name = "Form1";
            this.Text = "Train train train";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSourcePath;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chbPGAlgorithm;
        private System.Windows.Forms.CheckBox chbHughes;
        private System.Windows.Forms.CheckBox chbMatchingTemplate;
        private System.Windows.Forms.Button btnBrowseDestination;
        private System.Windows.Forms.TextBox txtDestPath;
        private System.Windows.Forms.CheckBox chbCreateCompFiles;
        private System.Windows.Forms.Button btnStart;
    }
}

