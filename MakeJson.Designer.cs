namespace DeJePecat
{
    partial class MakeJson
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
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtSourcePath = new System.Windows.Forms.TextBox();
            this.btnMakeJson = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(857, 9);
            this.btnBrowse.Margin = new System.Windows.Forms.Padding(4);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(159, 28);
            this.btnBrowse.TabIndex = 3;
            this.btnBrowse.Text = "Source folder";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtSourcePath
            // 
            this.txtSourcePath.Location = new System.Drawing.Point(13, 13);
            this.txtSourcePath.Margin = new System.Windows.Forms.Padding(4);
            this.txtSourcePath.Name = "txtSourcePath";
            this.txtSourcePath.Size = new System.Drawing.Size(835, 22);
            this.txtSourcePath.TabIndex = 2;
            // 
            // btnMakeJson
            // 
            this.btnMakeJson.Location = new System.Drawing.Point(857, 45);
            this.btnMakeJson.Margin = new System.Windows.Forms.Padding(4);
            this.btnMakeJson.Name = "btnMakeJson";
            this.btnMakeJson.Size = new System.Drawing.Size(159, 59);
            this.btnMakeJson.TabIndex = 14;
            this.btnMakeJson.Text = "MAKE JSON";
            this.btnMakeJson.UseVisualStyleBackColor = true;
            this.btnMakeJson.Click += new System.EventHandler(this.btnMakeJson_Click);
            // 
            // MakeJson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1023, 111);
            this.Controls.Add(this.btnMakeJson);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtSourcePath);
            this.Name = "MakeJson";
            this.Text = "Make Json";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtSourcePath;
        private System.Windows.Forms.Button btnMakeJson;
    }
}