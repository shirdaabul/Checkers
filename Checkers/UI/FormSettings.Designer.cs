namespace EnglishCheckersUI
{
    partial class FormSettings
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
            this.BoardSizeLable = new System.Windows.Forms.Label();
            this.size6Rb = new System.Windows.Forms.RadioButton();
            this.size8Rb = new System.Windows.Forms.RadioButton();
            this.size10Rb = new System.Windows.Forms.RadioButton();
            this.PlayersLabel = new System.Windows.Forms.Label();
            this.Player1Label = new System.Windows.Forms.Label();
            this.Player1TB = new System.Windows.Forms.TextBox();
            this.Player2CB = new System.Windows.Forms.CheckBox();
            this.Player2TB = new System.Windows.Forms.TextBox();
            this.DoneBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BoardSizeLable
            // 
            this.BoardSizeLable.AutoSize = true;
            this.BoardSizeLable.Location = new System.Drawing.Point(12, 9);
            this.BoardSizeLable.Name = "BoardSizeLable";
            this.BoardSizeLable.Size = new System.Drawing.Size(61, 13);
            this.BoardSizeLable.TabIndex = 0;
            this.BoardSizeLable.Text = "Board Size:";
            // 
            // size6Rb
            // 
            this.size6Rb.AutoSize = true;
            this.size6Rb.Checked = true;
            this.size6Rb.Location = new System.Drawing.Point(15, 37);
            this.size6Rb.Name = "size6Rb";
            this.size6Rb.Size = new System.Drawing.Size(50, 17);
            this.size6Rb.TabIndex = 1;
            this.size6Rb.TabStop = true;
            this.size6Rb.Text = "6 X 6";
            this.size6Rb.UseVisualStyleBackColor = true;
            // 
            // size8Rb
            // 
            this.size8Rb.AutoSize = true;
            this.size8Rb.Location = new System.Drawing.Point(90, 37);
            this.size8Rb.Name = "size8Rb";
            this.size8Rb.Size = new System.Drawing.Size(50, 17);
            this.size8Rb.TabIndex = 2;
            this.size8Rb.Text = "8 X 8";
            this.size8Rb.UseVisualStyleBackColor = true;
            // 
            // size10Rb
            // 
            this.size10Rb.AutoSize = true;
            this.size10Rb.Location = new System.Drawing.Point(161, 37);
            this.size10Rb.Name = "size10Rb";
            this.size10Rb.Size = new System.Drawing.Size(62, 17);
            this.size10Rb.TabIndex = 3;
            this.size10Rb.Text = "10 X 10";
            this.size10Rb.UseVisualStyleBackColor = true;
            // 
            // PlayersLabel
            // 
            this.PlayersLabel.AutoSize = true;
            this.PlayersLabel.Location = new System.Drawing.Point(12, 76);
            this.PlayersLabel.Name = "PlayersLabel";
            this.PlayersLabel.Size = new System.Drawing.Size(44, 13);
            this.PlayersLabel.TabIndex = 4;
            this.PlayersLabel.Text = "Players:";
            // 
            // Player1Label
            // 
            this.Player1Label.AutoSize = true;
            this.Player1Label.Location = new System.Drawing.Point(12, 109);
            this.Player1Label.Name = "Player1Label";
            this.Player1Label.Size = new System.Drawing.Size(45, 13);
            this.Player1Label.TabIndex = 5;
            this.Player1Label.Text = "Player1:";
            // 
            // Player1TB
            // 
            this.Player1TB.Location = new System.Drawing.Point(63, 106);
            this.Player1TB.Name = "Player1TB";
            this.Player1TB.Size = new System.Drawing.Size(100, 20);
            this.Player1TB.TabIndex = 4;
            // 
            // Player2CB
            // 
            this.Player2CB.AutoSize = true;
            this.Player2CB.Location = new System.Drawing.Point(15, 144);
            this.Player2CB.Name = "Player2CB";
            this.Player2CB.Size = new System.Drawing.Size(67, 17);
            this.Player2CB.TabIndex = 5;
            this.Player2CB.Text = "Player 2:";
            this.Player2CB.UseVisualStyleBackColor = true;
            this.Player2CB.CheckedChanged += new System.EventHandler(this.Player2CB_CheckedChanged);
            // 
            // Player2TB
            // 
            this.Player2TB.Enabled = false;
            this.Player2TB.Location = new System.Drawing.Point(101, 142);
            this.Player2TB.Name = "Player2TB";
            this.Player2TB.Size = new System.Drawing.Size(100, 20);
            this.Player2TB.TabIndex = 6;
            this.Player2TB.Text = "[Computer]";
            // 
            // DoneBtn
            // 
            this.DoneBtn.Location = new System.Drawing.Point(161, 184);
            this.DoneBtn.Name = "DoneBtn";
            this.DoneBtn.Size = new System.Drawing.Size(75, 23);
            this.DoneBtn.TabIndex = 7;
            this.DoneBtn.Text = "Done";
            this.DoneBtn.UseVisualStyleBackColor = true;
            this.DoneBtn.Click += new System.EventHandler(this.DoneBtn_Click);
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(249, 216);
            this.Controls.Add(this.DoneBtn);
            this.Controls.Add(this.Player2TB);
            this.Controls.Add(this.Player2CB);
            this.Controls.Add(this.Player1TB);
            this.Controls.Add(this.Player1Label);
            this.Controls.Add(this.PlayersLabel);
            this.Controls.Add(this.size10Rb);
            this.Controls.Add(this.size8Rb);
            this.Controls.Add(this.size6Rb);
            this.Controls.Add(this.BoardSizeLable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GameSettings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button DoneBtn;
        private System.Windows.Forms.TextBox Player2TB;
        private System.Windows.Forms.CheckBox Player2CB;
        private System.Windows.Forms.TextBox Player1TB;
        private System.Windows.Forms.Label Player1Label;
        private System.Windows.Forms.Label PlayersLabel;
        private System.Windows.Forms.RadioButton size10Rb;
        private System.Windows.Forms.RadioButton size8Rb;
        private System.Windows.Forms.RadioButton size6Rb;
        private System.Windows.Forms.Label BoardSizeLable;
    }
}