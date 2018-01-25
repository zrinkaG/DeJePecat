namespace DeJePecat
{
    partial class InitialForm
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
            this.btnCompare = new System.Windows.Forms.Button();
            this.btnTrain = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnMakeJson = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLabel
            // 
            this.btnLabel.Location = new System.Drawing.Point(379, 28);
            this.btnLabel.Margin = new System.Windows.Forms.Padding(4);
            this.btnLabel.Name = "btnLabel";
            this.btnLabel.Size = new System.Drawing.Size(152, 59);
            this.btnLabel.TabIndex = 1;
            this.btnLabel.Text = "LABEL";
            this.btnLabel.UseVisualStyleBackColor = true;
            this.btnLabel.Click += new System.EventHandler(this.btnLabel_Click);
            // 
            // btnCompare
            // 
            this.btnCompare.Location = new System.Drawing.Point(219, 95);
            this.btnCompare.Margin = new System.Windows.Forms.Padding(4);
            this.btnCompare.Name = "btnCompare";
            this.btnCompare.Size = new System.Drawing.Size(152, 59);
            this.btnCompare.TabIndex = 2;
            this.btnCompare.Text = "COMPARE";
            this.btnCompare.UseVisualStyleBackColor = true;
            this.btnCompare.Click += new System.EventHandler(this.btnCompare_Click);
            // 
            // btnTrain
            // 
            this.btnTrain.Location = new System.Drawing.Point(219, 28);
            this.btnTrain.Margin = new System.Windows.Forms.Padding(4);
            this.btnTrain.Name = "btnTrain";
            this.btnTrain.Size = new System.Drawing.Size(152, 59);
            this.btnTrain.TabIndex = 0;
            this.btnTrain.Text = "TRAIN";
            this.btnTrain.UseVisualStyleBackColor = true;
            this.btnTrain.Click += new System.EventHandler(this.btnTrain_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DeJePecat.Properties.Resources.deJePecatiImage;
            this.pictureBox1.Location = new System.Drawing.Point(16, 16);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(195, 154);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // btnMakeJson
            // 
            this.btnMakeJson.Location = new System.Drawing.Point(379, 95);
            this.btnMakeJson.Margin = new System.Windows.Forms.Padding(4);
            this.btnMakeJson.Name = "btnMakeJson";
            this.btnMakeJson.Size = new System.Drawing.Size(152, 59);
            this.btnMakeJson.TabIndex = 13;
            this.btnMakeJson.Text = "MAKE JSON";
            this.btnMakeJson.UseVisualStyleBackColor = true;
            this.btnMakeJson.Click += new System.EventHandler(this.btnMakeJson_Click);
            // 
            // InitialForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 178);
            this.Controls.Add(this.btnMakeJson);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnTrain);
            this.Controls.Add(this.btnLabel);
            this.Controls.Add(this.btnCompare);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "InitialForm";
            this.Text = "De je pecat??";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLabel;
        private System.Windows.Forms.Button btnCompare;
        private System.Windows.Forms.Button btnTrain;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnMakeJson;
    }
}