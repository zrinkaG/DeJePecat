namespace DeJePecat
{
    partial class CompareResults
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
            this.btnBrowseResult = new System.Windows.Forms.Button();
            this.txtResultStamps = new System.Windows.Forms.TextBox();
            this.btnBrowseLabeled = new System.Windows.Forms.Button();
            this.txtLabeledPath = new System.Windows.Forms.TextBox();
            this.btnComparisonResultPath = new System.Windows.Forms.Button();
            this.txtComparisonResultPath = new System.Windows.Forms.TextBox();
            this.btnCompare = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnBrowseResult
            // 
            this.btnBrowseResult.Location = new System.Drawing.Point(452, 36);
            this.btnBrowseResult.Name = "btnBrowseResult";
            this.btnBrowseResult.Size = new System.Drawing.Size(119, 23);
            this.btnBrowseResult.TabIndex = 8;
            this.btnBrowseResult.Text = "Result stamps";
            this.btnBrowseResult.UseVisualStyleBackColor = true;
            this.btnBrowseResult.Click += new System.EventHandler(this.btnBrowseResult_Click);
            // 
            // txtResultStamps
            // 
            this.txtResultStamps.Location = new System.Drawing.Point(12, 38);
            this.txtResultStamps.Name = "txtResultStamps";
            this.txtResultStamps.Size = new System.Drawing.Size(434, 20);
            this.txtResultStamps.TabIndex = 7;
            // 
            // btnBrowseLabeled
            // 
            this.btnBrowseLabeled.Location = new System.Drawing.Point(452, 10);
            this.btnBrowseLabeled.Name = "btnBrowseLabeled";
            this.btnBrowseLabeled.Size = new System.Drawing.Size(119, 23);
            this.btnBrowseLabeled.TabIndex = 6;
            this.btnBrowseLabeled.Text = "Labeled stamps";
            this.btnBrowseLabeled.UseVisualStyleBackColor = true;
            this.btnBrowseLabeled.Click += new System.EventHandler(this.btnBrowseLabeled_Click);
            // 
            // txtLabeledPath
            // 
            this.txtLabeledPath.Location = new System.Drawing.Point(12, 12);
            this.txtLabeledPath.Name = "txtLabeledPath";
            this.txtLabeledPath.Size = new System.Drawing.Size(434, 20);
            this.txtLabeledPath.TabIndex = 5;
            // 
            // btnComparisonResultPath
            // 
            this.btnComparisonResultPath.Location = new System.Drawing.Point(452, 62);
            this.btnComparisonResultPath.Name = "btnComparisonResultPath";
            this.btnComparisonResultPath.Size = new System.Drawing.Size(119, 23);
            this.btnComparisonResultPath.TabIndex = 10;
            this.btnComparisonResultPath.Text = "Comparison result";
            this.btnComparisonResultPath.UseVisualStyleBackColor = true;
            this.btnComparisonResultPath.Click += new System.EventHandler(this.btnBrowseComparison_Click);
            // 
            // txtComparisonResultPath
            // 
            this.txtComparisonResultPath.Location = new System.Drawing.Point(12, 64);
            this.txtComparisonResultPath.Name = "txtComparisonResultPath";
            this.txtComparisonResultPath.Size = new System.Drawing.Size(434, 20);
            this.txtComparisonResultPath.TabIndex = 9;
            // 
            // btnCompare
            // 
            this.btnCompare.Location = new System.Drawing.Point(452, 112);
            this.btnCompare.Name = "btnCompare";
            this.btnCompare.Size = new System.Drawing.Size(115, 68);
            this.btnCompare.TabIndex = 11;
            this.btnCompare.Text = "COMPARE ";
            this.btnCompare.UseVisualStyleBackColor = true;
            this.btnCompare.Click += new System.EventHandler(this.btnCompare_Click);
            // 
            // CompareResults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 192);
            this.Controls.Add(this.btnCompare);
            this.Controls.Add(this.btnComparisonResultPath);
            this.Controls.Add(this.txtComparisonResultPath);
            this.Controls.Add(this.btnBrowseResult);
            this.Controls.Add(this.txtResultStamps);
            this.Controls.Add(this.btnBrowseLabeled);
            this.Controls.Add(this.txtLabeledPath);
            this.Name = "CompareResults";
            this.Text = "Compare Results";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBrowseResult;
        private System.Windows.Forms.TextBox txtResultStamps;
        private System.Windows.Forms.Button btnBrowseLabeled;
        private System.Windows.Forms.TextBox txtLabeledPath;
        private System.Windows.Forms.Button btnComparisonResultPath;
        private System.Windows.Forms.TextBox txtComparisonResultPath;
        private System.Windows.Forms.Button btnCompare;
    }
}