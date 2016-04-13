namespace EvanGomoku
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
            this.chessboardPanel = new System.Windows.Forms.Panel();
            this.logTextBox = new System.Windows.Forms.TextBox();
            this.copyrightLabel = new System.Windows.Forms.Label();
            this.logGroupBox = new System.Windows.Forms.GroupBox();
            this.restartButton = new System.Windows.Forms.Button();
            this.logGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // chessboardPanel
            // 
            this.chessboardPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chessboardPanel.Location = new System.Drawing.Point(5, 5);
            this.chessboardPanel.Name = "chessboardPanel";
            this.chessboardPanel.Size = new System.Drawing.Size(750, 750);
            this.chessboardPanel.TabIndex = 0;
            this.chessboardPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.chessboardPanel_Paint);
            this.chessboardPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.chessboardPanel_MouseDown);
            // 
            // logTextBox
            // 
            this.logTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.logTextBox.Location = new System.Drawing.Point(5, 15);
            this.logTextBox.Multiline = true;
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.ReadOnly = true;
            this.logTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logTextBox.Size = new System.Drawing.Size(260, 380);
            this.logTextBox.TabIndex = 1;
            // 
            // copyrightLabel
            // 
            this.copyrightLabel.AutoSize = true;
            this.copyrightLabel.Location = new System.Drawing.Point(846, 746);
            this.copyrightLabel.Name = "copyrightLabel";
            this.copyrightLabel.Size = new System.Drawing.Size(185, 12);
            this.copyrightLabel.TabIndex = 2;
            this.copyrightLabel.Text = "evan2048. All Rights Reserved.";
            // 
            // logGroupBox
            // 
            this.logGroupBox.Controls.Add(this.logTextBox);
            this.logGroupBox.Location = new System.Drawing.Point(760, 5);
            this.logGroupBox.Name = "logGroupBox";
            this.logGroupBox.Size = new System.Drawing.Size(270, 400);
            this.logGroupBox.TabIndex = 3;
            this.logGroupBox.TabStop = false;
            this.logGroupBox.Text = "log:";
            // 
            // restartButton
            // 
            this.restartButton.Location = new System.Drawing.Point(840, 420);
            this.restartButton.Name = "restartButton";
            this.restartButton.Size = new System.Drawing.Size(120, 50);
            this.restartButton.TabIndex = 4;
            this.restartButton.Text = "Restart";
            this.restartButton.UseVisualStyleBackColor = true;
            this.restartButton.Click += new System.EventHandler(this.restartButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 761);
            this.Controls.Add(this.restartButton);
            this.Controls.Add(this.logGroupBox);
            this.Controls.Add(this.copyrightLabel);
            this.Controls.Add(this.chessboardPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EvanGomoku http://lovecoding.sinaapp.com";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.logGroupBox.ResumeLayout(false);
            this.logGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel chessboardPanel;
        private System.Windows.Forms.TextBox logTextBox;
        private System.Windows.Forms.Label copyrightLabel;
        private System.Windows.Forms.GroupBox logGroupBox;
        private System.Windows.Forms.Button restartButton;
    }
}

