namespace Minesweeper
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
            this.LabelMineCount = new System.Windows.Forms.Label();
            this.labelTimer = new System.Windows.Forms.Label();
            this.labelGameStatus = new System.Windows.Forms.Label();
            this.buttonEasy = new System.Windows.Forms.Button();
            this.buttonMedium = new System.Windows.Forms.Button();
            this.buttonHard = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LabelMineCount
            // 
            this.LabelMineCount.AutoSize = true;
            this.LabelMineCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelMineCount.Location = new System.Drawing.Point(12, 9);
            this.LabelMineCount.Name = "LabelMineCount";
            this.LabelMineCount.Size = new System.Drawing.Size(55, 39);
            this.LabelMineCount.TabIndex = 0;
            this.LabelMineCount.Text = 0 + "";
            // 
            // labelTimer
            // 
            this.labelTimer.AutoSize = true;
            this.labelTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTimer.Location = new System.Drawing.Point(339, 9);
            this.labelTimer.Name = "labelTimer";
            this.labelTimer.Size = new System.Drawing.Size(149, 39);
            this.labelTimer.TabIndex = 1;
            this.labelTimer.Text = "00:00:00";
            // 
            // labelGameStatus
            // 
            this.labelGameStatus.AutoSize = true;
            this.labelGameStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGameStatus.Location = new System.Drawing.Point(176, 3);
            this.labelGameStatus.Name = "labelGameStatus";
            this.labelGameStatus.Size = new System.Drawing.Size(66, 17);
            this.labelGameStatus.TabIndex = 2;
            this.labelGameStatus.Text = "¯\\_(ツ)_/¯";
            // 
            // buttonEasy
            // 
            this.buttonEasy.Location = new System.Drawing.Point(86, 24);
            this.buttonEasy.Name = "buttonEasy";
            this.buttonEasy.Size = new System.Drawing.Size(75, 24);
            this.buttonEasy.TabIndex = 3;
            this.buttonEasy.Text = "Easy";
            this.buttonEasy.UseVisualStyleBackColor = true;
            this.buttonEasy.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonMedium
            // 
            this.buttonMedium.Location = new System.Drawing.Point(167, 23);
            this.buttonMedium.Name = "buttonMedium";
            this.buttonMedium.Size = new System.Drawing.Size(75, 24);
            this.buttonMedium.TabIndex = 4;
            this.buttonMedium.Text = "Medium";
            this.buttonMedium.UseVisualStyleBackColor = true;
            this.buttonMedium.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonHard
            // 
            this.buttonHard.Location = new System.Drawing.Point(248, 23);
            this.buttonHard.Name = "buttonHard";
            this.buttonHard.Size = new System.Drawing.Size(75, 24);
            this.buttonHard.TabIndex = 5;
            this.buttonHard.Text = "Hard";
            this.buttonHard.UseVisualStyleBackColor = true;
            this.buttonHard.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(500, 550);
            this.Controls.Add(this.buttonHard);
            this.Controls.Add(this.buttonMedium);
            this.Controls.Add(this.buttonEasy);
            this.Controls.Add(this.labelGameStatus);
            this.Controls.Add(this.labelTimer);
            this.Controls.Add(this.LabelMineCount);
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LabelMineCount;
        private System.Windows.Forms.Label labelTimer;
        private System.Windows.Forms.Label labelGameStatus;
        private System.Windows.Forms.Button buttonEasy;
        private System.Windows.Forms.Button buttonMedium;
        private System.Windows.Forms.Button buttonHard;
    }
}

