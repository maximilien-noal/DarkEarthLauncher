namespace DarkEarthLauncher
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.PlayButton = new System.Windows.Forms.Button();
            this.DisableDdrawCompatCheckBox = new System.Windows.Forms.CheckBox();
            this.WarningLabel = new System.Windows.Forms.Label();
            this.SeeDefaultControlsButton = new System.Windows.Forms.Button();
            this.GameHelpButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PlayButton
            // 
            this.PlayButton.Location = new System.Drawing.Point(117, 12);
            this.PlayButton.Name = "PlayButton";
            this.PlayButton.Size = new System.Drawing.Size(75, 23);
            this.PlayButton.TabIndex = 0;
            this.PlayButton.Text = "Jouer";
            this.PlayButton.UseVisualStyleBackColor = true;
            this.PlayButton.Click += new System.EventHandler(this.PlayButton_Click);
            // 
            // DisableDdrawCompatCheckBox
            // 
            this.DisableDdrawCompatCheckBox.AutoSize = true;
            this.DisableDdrawCompatCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.DisableDdrawCompatCheckBox.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DisableDdrawCompatCheckBox.Location = new System.Drawing.Point(87, 52);
            this.DisableDdrawCompatCheckBox.Name = "DisableDdrawCompatCheckBox";
            this.DisableDdrawCompatCheckBox.Size = new System.Drawing.Size(145, 17);
            this.DisableDdrawCompatCheckBox.TabIndex = 1;
            this.DisableDdrawCompatCheckBox.Text = "Désactiver ddrawCompat";
            this.DisableDdrawCompatCheckBox.UseVisualStyleBackColor = false;
            // 
            // WarningLabel
            // 
            this.WarningLabel.AutoSize = true;
            this.WarningLabel.BackColor = System.Drawing.Color.Transparent;
            this.WarningLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.WarningLabel.Location = new System.Drawing.Point(56, 72);
            this.WarningLabel.Name = "WarningLabel";
            this.WarningLabel.Size = new System.Drawing.Size(208, 13);
            this.WarningLabel.TabIndex = 2;
            this.WarningLabel.Text = "(Utile uniquement si le jeu ne se lance pas)";
            // 
            // SeeDefaultControlsButton
            // 
            this.SeeDefaultControlsButton.Location = new System.Drawing.Point(75, 124);
            this.SeeDefaultControlsButton.Name = "SeeDefaultControlsButton";
            this.SeeDefaultControlsButton.Size = new System.Drawing.Size(157, 25);
            this.SeeDefaultControlsButton.TabIndex = 3;
            this.SeeDefaultControlsButton.Text = "Voir les contrôles par défaut";
            this.SeeDefaultControlsButton.UseVisualStyleBackColor = true;
            this.SeeDefaultControlsButton.Click += new System.EventHandler(this.SeeDefaultControlsButton_Click);
            // 
            // GameHelpButton
            // 
            this.GameHelpButton.Location = new System.Drawing.Point(117, 95);
            this.GameHelpButton.Name = "GameHelpButton";
            this.GameHelpButton.Size = new System.Drawing.Size(75, 23);
            this.GameHelpButton.TabIndex = 4;
            this.GameHelpButton.Text = "Aide de jeu";
            this.GameHelpButton.UseVisualStyleBackColor = true;
            this.GameHelpButton.Click += new System.EventHandler(this.GameHelpButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(304, 161);
            this.Controls.Add(this.GameHelpButton);
            this.Controls.Add(this.SeeDefaultControlsButton);
            this.Controls.Add(this.WarningLabel);
            this.Controls.Add(this.DisableDdrawCompatCheckBox);
            this.Controls.Add(this.PlayButton);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(320, 200);
            this.MinimumSize = new System.Drawing.Size(320, 200);
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lanceur Dark Earth";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button PlayButton;
        private System.Windows.Forms.CheckBox DisableDdrawCompatCheckBox;
        private System.Windows.Forms.Label WarningLabel;
        private System.Windows.Forms.Button SeeDefaultControlsButton;
        private System.Windows.Forms.Button GameHelpButton;
    }
}

