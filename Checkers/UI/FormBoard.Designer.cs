namespace EnglishCheckersUI
{
    partial class FormBoard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBoard));
            this.panelBoard = new System.Windows.Forms.Panel();
            this.LabelScorePlayer1 = new System.Windows.Forms.Label();
            this.LabelScorePlayer2 = new System.Windows.Forms.Label();
            this.pictureBoxPlayer1 = new System.Windows.Forms.PictureBox();
            this.pictureBoxPlayer2 = new System.Windows.Forms.PictureBox();
            this.Player1Name = new System.Windows.Forms.Label();
            this.Player2Name = new System.Windows.Forms.Label();
            this.YourTurnLabel1 = new System.Windows.Forms.Label();
            this.YourTurnLabel2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPlayer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPlayer2)).BeginInit();
            this.SuspendLayout();
            // 
            // panelBoard
            // 
            this.panelBoard.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBoard.BackColor = System.Drawing.Color.Black;
            this.panelBoard.Location = new System.Drawing.Point(15, 73);
            this.panelBoard.Margin = new System.Windows.Forms.Padding(0);
            this.panelBoard.Name = "panelBoard";
            this.panelBoard.Size = new System.Drawing.Size(305, 274);
            this.panelBoard.TabIndex = 1;
            this.panelBoard.TabStop = true;
            // 
            // LabelScorePlayer1
            // 
            this.LabelScorePlayer1.AutoSize = true;
            this.LabelScorePlayer1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.LabelScorePlayer1.Location = new System.Drawing.Point(96, 45);
            this.LabelScorePlayer1.Name = "LabelScorePlayer1";
            this.LabelScorePlayer1.Size = new System.Drawing.Size(103, 18);
            this.LabelScorePlayer1.TabIndex = 1;
            this.LabelScorePlayer1.Text = "ScorePlayer1";
            // 
            // LabelScorePlayer2
            // 
            this.LabelScorePlayer2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelScorePlayer2.AutoSize = true;
            this.LabelScorePlayer2.Font = new System.Drawing.Font("Arial", 12F);
            this.LabelScorePlayer2.Location = new System.Drawing.Point(225, 44);
            this.LabelScorePlayer2.Name = "LabelScorePlayer2";
            this.LabelScorePlayer2.Size = new System.Drawing.Size(103, 18);
            this.LabelScorePlayer2.TabIndex = 2;
            this.LabelScorePlayer2.Text = "ScorePlayer2";
            // 
            // pictureBoxPlayer1
            // 
            this.pictureBoxPlayer1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxPlayer1.BackgroundImage")));
            this.pictureBoxPlayer1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxPlayer1.ImageLocation = "";
            this.pictureBoxPlayer1.Location = new System.Drawing.Point(48, 21);
            this.pictureBoxPlayer1.Name = "pictureBoxPlayer1";
            this.pictureBoxPlayer1.Size = new System.Drawing.Size(41, 41);
            this.pictureBoxPlayer1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxPlayer1.TabIndex = 3;
            this.pictureBoxPlayer1.TabStop = false;
            // 
            // pictureBoxPlayer2
            // 
            this.pictureBoxPlayer2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxPlayer2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxPlayer2.BackgroundImage")));
            this.pictureBoxPlayer2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxPlayer2.Enabled = false;
            this.pictureBoxPlayer2.ImageLocation = "";
            this.pictureBoxPlayer2.Location = new System.Drawing.Point(180, 21);
            this.pictureBoxPlayer2.Name = "pictureBoxPlayer2";
            this.pictureBoxPlayer2.Size = new System.Drawing.Size(41, 41);
            this.pictureBoxPlayer2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxPlayer2.TabIndex = 4;
            this.pictureBoxPlayer2.TabStop = false;
            // 
            // Player1Name
            // 
            this.Player1Name.AutoSize = true;
            this.Player1Name.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player1Name.Location = new System.Drawing.Point(94, 20);
            this.Player1Name.Name = "Player1Name";
            this.Player1Name.Size = new System.Drawing.Size(66, 25);
            this.Player1Name.TabIndex = 5;
            this.Player1Name.Text = "name1";
            // 
            // Player2Name
            // 
            this.Player2Name.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Player2Name.AutoSize = true;
            this.Player2Name.Font = new System.Drawing.Font("Arial Narrow", 15.75F);
            this.Player2Name.Location = new System.Drawing.Point(223, 20);
            this.Player2Name.Name = "Player2Name";
            this.Player2Name.Size = new System.Drawing.Size(66, 25);
            this.Player2Name.TabIndex = 6;
            this.Player2Name.Text = "name2";
            // 
            // YourTurnLabel1
            // 
            this.YourTurnLabel1.AutoSize = true;
            this.YourTurnLabel1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.YourTurnLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.YourTurnLabel1.Location = new System.Drawing.Point(60, 3);
            this.YourTurnLabel1.Name = "YourTurnLabel1";
            this.YourTurnLabel1.Size = new System.Drawing.Size(74, 18);
            this.YourTurnLabel1.TabIndex = 2;
            this.YourTurnLabel1.Text = "Your turn";
            // 
            // YourTurnLabel2
            // 
            this.YourTurnLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.YourTurnLabel2.AutoSize = true;
            this.YourTurnLabel2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.YourTurnLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.YourTurnLabel2.Location = new System.Drawing.Point(193, 3);
            this.YourTurnLabel2.Name = "YourTurnLabel2";
            this.YourTurnLabel2.Size = new System.Drawing.Size(74, 18);
            this.YourTurnLabel2.TabIndex = 2;
            this.YourTurnLabel2.Text = "Your turn";
            this.YourTurnLabel2.Visible = false;
            // 
            // FormBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(334, 361);
            this.Controls.Add(this.YourTurnLabel2);
            this.Controls.Add(this.YourTurnLabel1);
            this.Controls.Add(this.Player2Name);
            this.Controls.Add(this.Player1Name);
            this.Controls.Add(this.pictureBoxPlayer2);
            this.Controls.Add(this.pictureBoxPlayer1);
            this.Controls.Add(this.LabelScorePlayer2);
            this.Controls.Add(this.LabelScorePlayer1);
            this.Controls.Add(this.panelBoard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormBoard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Damka";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPlayer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPlayer2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelBoard;
        private System.Windows.Forms.Label LabelScorePlayer1;
        private System.Windows.Forms.Label LabelScorePlayer2;
        private System.Windows.Forms.PictureBox pictureBoxPlayer1;
        private System.Windows.Forms.PictureBox pictureBoxPlayer2;
        private System.Windows.Forms.Label Player1Name;
        private System.Windows.Forms.Label Player2Name;
        private System.Windows.Forms.Label YourTurnLabel1;
        private System.Windows.Forms.Label YourTurnLabel2;
    }
}