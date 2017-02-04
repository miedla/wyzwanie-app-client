namespace WyzwanieForms
{
    partial class WaitingForm
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
            this.labelWaitInfo = new System.Windows.Forms.Label();
            this.labelPlayersCount = new System.Windows.Forms.Label();
            this.buttonOk = new System.Windows.Forms.Button();
            this.labelSeconds = new System.Windows.Forms.Label();
            this.labelWaitingSeconds = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelWaitInfo
            // 
            this.labelWaitInfo.AutoSize = true;
            this.labelWaitInfo.Location = new System.Drawing.Point(75, 9);
            this.labelWaitInfo.MaximumSize = new System.Drawing.Size(150, 300);
            this.labelWaitInfo.Name = "labelWaitInfo";
            this.labelWaitInfo.Size = new System.Drawing.Size(103, 13);
            this.labelWaitInfo.TabIndex = 1;
            this.labelWaitInfo.Text = "Waiting for players...";
            // 
            // labelPlayersCount
            // 
            this.labelPlayersCount.AutoSize = true;
            this.labelPlayersCount.Location = new System.Drawing.Point(125, 80);
            this.labelPlayersCount.Name = "labelPlayersCount";
            this.labelPlayersCount.Size = new System.Drawing.Size(0, 13);
            this.labelPlayersCount.TabIndex = 2;
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(78, 114);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 3;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // labelSeconds
            // 
            this.labelSeconds.AutoSize = true;
            this.labelSeconds.Location = new System.Drawing.Point(168, 43);
            this.labelSeconds.Name = "labelSeconds";
            this.labelSeconds.Size = new System.Drawing.Size(0, 13);
            this.labelSeconds.TabIndex = 4;
            // 
            // labelWaitingSeconds
            // 
            this.labelWaitingSeconds.AutoSize = true;
            this.labelWaitingSeconds.Location = new System.Drawing.Point(75, 54);
            this.labelWaitingSeconds.Name = "labelWaitingSeconds";
            this.labelWaitingSeconds.Size = new System.Drawing.Size(89, 13);
            this.labelWaitingSeconds.TabIndex = 5;
            this.labelWaitingSeconds.Text = "Waiting seconds:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(81, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Players:";
            // 
            // WaitingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(250, 149);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelWaitingSeconds);
            this.Controls.Add(this.labelSeconds);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.labelPlayersCount);
            this.Controls.Add(this.labelWaitInfo);
            this.Name = "WaitingForm";
            this.Text = "WaitingForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelWaitInfo;
        private System.Windows.Forms.Label labelPlayersCount;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Label labelSeconds;
        private System.Windows.Forms.Label labelWaitingSeconds;
        private System.Windows.Forms.Label label2;
    }
}