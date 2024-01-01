namespace ZMLInstaller
{
    partial class InstallerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InstallerForm));
            this.OpenDirButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Step2DownloadProgress = new System.Windows.Forms.ProgressBar();
            this.Step2DownloadButton = new System.Windows.Forms.Button();
            this.Step2Label = new System.Windows.Forms.Label();
            this.Step3Label = new System.Windows.Forms.Label();
            this.Step3InstallButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // OpenDirButton
            // 
            this.OpenDirButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(40)))), ((int)(((byte)(43)))));
            this.OpenDirButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(25)))), ((int)(((byte)(29)))));
            this.OpenDirButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OpenDirButton.Location = new System.Drawing.Point(51, 8);
            this.OpenDirButton.Name = "OpenDirButton";
            this.OpenDirButton.Size = new System.Drawing.Size(249, 23);
            this.OpenDirButton.TabIndex = 0;
            this.OpenDirButton.Text = "Select your CarX Folder";
            this.OpenDirButton.UseVisualStyleBackColor = false;
            this.OpenDirButton.Click += new System.EventHandler(this.OpenDirButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Step 1";
            // 
            // Step2DownloadProgress
            // 
            this.Step2DownloadProgress.Enabled = false;
            this.Step2DownloadProgress.Location = new System.Drawing.Point(127, 37);
            this.Step2DownloadProgress.Name = "Step2DownloadProgress";
            this.Step2DownloadProgress.Size = new System.Drawing.Size(172, 23);
            this.Step2DownloadProgress.TabIndex = 2;
            // 
            // Step2DownloadButton
            // 
            this.Step2DownloadButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(40)))), ((int)(((byte)(43)))));
            this.Step2DownloadButton.Enabled = false;
            this.Step2DownloadButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(25)))), ((int)(((byte)(29)))));
            this.Step2DownloadButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Step2DownloadButton.Location = new System.Drawing.Point(51, 37);
            this.Step2DownloadButton.Name = "Step2DownloadButton";
            this.Step2DownloadButton.Size = new System.Drawing.Size(70, 23);
            this.Step2DownloadButton.TabIndex = 3;
            this.Step2DownloadButton.Text = "Download";
            this.Step2DownloadButton.UseVisualStyleBackColor = false;
            this.Step2DownloadButton.Click += new System.EventHandler(this.Step2DownloadButton_Button);
            // 
            // Step2Label
            // 
            this.Step2Label.AutoSize = true;
            this.Step2Label.Enabled = false;
            this.Step2Label.Location = new System.Drawing.Point(7, 42);
            this.Step2Label.Name = "Step2Label";
            this.Step2Label.Size = new System.Drawing.Size(38, 13);
            this.Step2Label.TabIndex = 4;
            this.Step2Label.Text = "Step 2";
            // 
            // Step3Label
            // 
            this.Step3Label.AutoSize = true;
            this.Step3Label.Enabled = false;
            this.Step3Label.Location = new System.Drawing.Point(7, 71);
            this.Step3Label.Name = "Step3Label";
            this.Step3Label.Size = new System.Drawing.Size(38, 13);
            this.Step3Label.TabIndex = 5;
            this.Step3Label.Text = "Step 3";
            // 
            // Step3InstallButton
            // 
            this.Step3InstallButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(40)))), ((int)(((byte)(43)))));
            this.Step3InstallButton.Enabled = false;
            this.Step3InstallButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(25)))), ((int)(((byte)(29)))));
            this.Step3InstallButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Step3InstallButton.Location = new System.Drawing.Point(51, 66);
            this.Step3InstallButton.Name = "Step3InstallButton";
            this.Step3InstallButton.Size = new System.Drawing.Size(249, 23);
            this.Step3InstallButton.TabIndex = 6;
            this.Step3InstallButton.Text = "Install";
            this.Step3InstallButton.UseVisualStyleBackColor = false;
            this.Step3InstallButton.Click += new System.EventHandler(this.Step3InstallButton_Click);
            // 
            // InstallerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.ClientSize = new System.Drawing.Size(434, 235);
            this.Controls.Add(this.Step3InstallButton);
            this.Controls.Add(this.Step3Label);
            this.Controls.Add(this.Step2Label);
            this.Controls.Add(this.Step2DownloadButton);
            this.Controls.Add(this.Step2DownloadProgress);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.OpenDirButton);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InstallerForm";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ZML Installer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OpenDirButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar Step2DownloadProgress;
        private System.Windows.Forms.Button Step2DownloadButton;
        private System.Windows.Forms.Label Step2Label;
        private System.Windows.Forms.Label Step3Label;
        private System.Windows.Forms.Button Step3InstallButton;
    }
}

