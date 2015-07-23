namespace PingFly
{
    partial class Updater
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Updater));
            this.updatelabel = new System.Windows.Forms.Label();
            this.updatecheck = new System.ComponentModel.BackgroundWorker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.updatetext = new System.Windows.Forms.Label();
            this.yesupdate = new System.Windows.Forms.Button();
            this.noupdate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // updatelabel
            // 
            this.updatelabel.AutoSize = true;
            this.updatelabel.Font = new System.Drawing.Font("Nirmala UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updatelabel.Location = new System.Drawing.Point(14, 9);
            this.updatelabel.Name = "updatelabel";
            this.updatelabel.Size = new System.Drawing.Size(215, 30);
            this.updatelabel.TabIndex = 0;
            this.updatelabel.Text = "Checking For Updates";
            // 
            // updatecheck
            // 
            this.updatecheck.DoWork += new System.ComponentModel.DoWorkEventHandler(this.updatecheck_DoWork);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PingFly.Properties.Resources.image_8777591;
            this.pictureBox1.Location = new System.Drawing.Point(84, 49);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(71, 70);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // updatetext
            // 
            this.updatetext.AutoSize = true;
            this.updatetext.Location = new System.Drawing.Point(45, 122);
            this.updatetext.Name = "updatetext";
            this.updatetext.Size = new System.Drawing.Size(150, 13);
            this.updatetext.TabIndex = 2;
            this.updatetext.Text = "Download and Install Update?";
            this.updatetext.Visible = false;
            // 
            // yesupdate
            // 
            this.yesupdate.BackColor = System.Drawing.Color.WhiteSmoke;
            this.yesupdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.yesupdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.yesupdate.Location = new System.Drawing.Point(12, 141);
            this.yesupdate.Name = "yesupdate";
            this.yesupdate.Size = new System.Drawing.Size(77, 34);
            this.yesupdate.TabIndex = 4;
            this.yesupdate.Text = "Yes";
            this.yesupdate.UseVisualStyleBackColor = false;
            this.yesupdate.Visible = false;
            this.yesupdate.Click += new System.EventHandler(this.yesupdate_Click);
            // 
            // noupdate
            // 
            this.noupdate.BackColor = System.Drawing.Color.WhiteSmoke;
            this.noupdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.noupdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.noupdate.Location = new System.Drawing.Point(152, 141);
            this.noupdate.Name = "noupdate";
            this.noupdate.Size = new System.Drawing.Size(77, 34);
            this.noupdate.TabIndex = 5;
            this.noupdate.Text = "No";
            this.noupdate.UseVisualStyleBackColor = false;
            this.noupdate.Visible = false;
            this.noupdate.Click += new System.EventHandler(this.noupdate_Click);
            // 
            // Updater
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(243, 187);
            this.Controls.Add(this.noupdate);
            this.Controls.Add(this.yesupdate);
            this.Controls.Add(this.updatetext);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.updatelabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Updater";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PingFly Updater";
            this.Load += new System.EventHandler(this.Updater_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label updatelabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.ComponentModel.BackgroundWorker updatecheck;
        private System.Windows.Forms.Label updatetext;
        private System.Windows.Forms.Button yesupdate;
        private System.Windows.Forms.Button noupdate;
    }
}