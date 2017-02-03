namespace WyzwanieForms
{
    partial class FormGame
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
            this.labelQuestion = new System.Windows.Forms.Label();
            this.buttonA = new System.Windows.Forms.Button();
            this.buttonB = new System.Windows.Forms.Button();
            this.buttonC = new System.Windows.Forms.Button();
            this.buttonD = new System.Windows.Forms.Button();
            this.labelQuestionNumber = new System.Windows.Forms.Label();
            this.labelScore = new System.Windows.Forms.Label();
            this.labelScoreName = new System.Windows.Forms.Label();
            this.labelQTime = new System.Windows.Forms.Label();
            this.labelElapsedTime = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelQuestion
            // 
            this.labelQuestion.AutoSize = true;
            this.labelQuestion.Location = new System.Drawing.Point(57, 46);
            this.labelQuestion.MaximumSize = new System.Drawing.Size(200, 60);
            this.labelQuestion.MinimumSize = new System.Drawing.Size(0, 60);
            this.labelQuestion.Name = "labelQuestion";
            this.labelQuestion.Size = new System.Drawing.Size(182, 60);
            this.labelQuestion.TabIndex = 0;
            this.labelQuestion.Text = "Pytanie dsad asd asdaswe dsad sad dasdd ";
            // 
            // buttonA
            // 
            this.buttonA.Location = new System.Drawing.Point(49, 111);
            this.buttonA.Name = "buttonA";
            this.buttonA.Size = new System.Drawing.Size(200, 60);
            this.buttonA.TabIndex = 1;
            this.buttonA.Text = "button1";
            this.buttonA.UseVisualStyleBackColor = true;
            this.buttonA.Click += new System.EventHandler(this.buttonAnswer_Click);
            // 
            // buttonB
            // 
            this.buttonB.Location = new System.Drawing.Point(49, 177);
            this.buttonB.Name = "buttonB";
            this.buttonB.Size = new System.Drawing.Size(200, 60);
            this.buttonB.TabIndex = 2;
            this.buttonB.Text = "button2";
            this.buttonB.UseVisualStyleBackColor = true;
            this.buttonB.Click += new System.EventHandler(this.buttonAnswer_Click);
            // 
            // buttonC
            // 
            this.buttonC.Location = new System.Drawing.Point(49, 243);
            this.buttonC.Name = "buttonC";
            this.buttonC.Size = new System.Drawing.Size(200, 60);
            this.buttonC.TabIndex = 3;
            this.buttonC.Text = "button3";
            this.buttonC.UseVisualStyleBackColor = true;
            this.buttonC.Click += new System.EventHandler(this.buttonAnswer_Click);
            // 
            // buttonD
            // 
            this.buttonD.Location = new System.Drawing.Point(49, 309);
            this.buttonD.Name = "buttonD";
            this.buttonD.Size = new System.Drawing.Size(200, 60);
            this.buttonD.TabIndex = 4;
            this.buttonD.Text = "sadasldkasdlsakdsaldkadasdasd dasd sadas dsadsad ad asd dsad sad  dsadadasdasdsad" +
    "sa dsa asdd sldkasdasdk";
            this.buttonD.UseVisualStyleBackColor = true;
            this.buttonD.Click += new System.EventHandler(this.buttonAnswer_Click);
            // 
            // labelQuestionNumber
            // 
            this.labelQuestionNumber.AutoSize = true;
            this.labelQuestionNumber.Location = new System.Drawing.Point(132, 382);
            this.labelQuestionNumber.Name = "labelQuestionNumber";
            this.labelQuestionNumber.Size = new System.Drawing.Size(30, 13);
            this.labelQuestionNumber.TabIndex = 5;
            this.labelQuestionNumber.Text = "1/10";
            // 
            // labelScore
            // 
            this.labelScore.AutoSize = true;
            this.labelScore.Location = new System.Drawing.Point(12, 24);
            this.labelScore.Name = "labelScore";
            this.labelScore.Size = new System.Drawing.Size(25, 13);
            this.labelScore.TabIndex = 6;
            this.labelScore.Text = "100";
            // 
            // labelScoreName
            // 
            this.labelScoreName.AutoSize = true;
            this.labelScoreName.Location = new System.Drawing.Point(13, 8);
            this.labelScoreName.Name = "labelScoreName";
            this.labelScoreName.Size = new System.Drawing.Size(38, 13);
            this.labelScoreName.TabIndex = 7;
            this.labelScoreName.Text = "Score:";
            // 
            // labelQTime
            // 
            this.labelQTime.AutoSize = true;
            this.labelQTime.Location = new System.Drawing.Point(136, 9);
            this.labelQTime.Name = "labelQTime";
            this.labelQTime.Size = new System.Drawing.Size(26, 13);
            this.labelQTime.TabIndex = 8;
            this.labelQTime.Text = "time";
            // 
            // labelElapsedTime
            // 
            this.labelElapsedTime.AutoSize = true;
            this.labelElapsedTime.Location = new System.Drawing.Point(66, 8);
            this.labelElapsedTime.Name = "labelElapsedTime";
            this.labelElapsedTime.Size = new System.Drawing.Size(70, 13);
            this.labelElapsedTime.TabIndex = 9;
            this.labelElapsedTime.Text = "Elapsed time:";
            // 
            // FormGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 404);
            this.Controls.Add(this.labelElapsedTime);
            this.Controls.Add(this.labelQTime);
            this.Controls.Add(this.labelScoreName);
            this.Controls.Add(this.labelScore);
            this.Controls.Add(this.labelQuestionNumber);
            this.Controls.Add(this.buttonD);
            this.Controls.Add(this.buttonC);
            this.Controls.Add(this.buttonB);
            this.Controls.Add(this.buttonA);
            this.Controls.Add(this.labelQuestion);
            this.Name = "FormGame";
            this.Text = "FormGame";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelQuestion;
        private System.Windows.Forms.Button buttonA;
        private System.Windows.Forms.Button buttonB;
        private System.Windows.Forms.Button buttonC;
        private System.Windows.Forms.Button buttonD;
        private System.Windows.Forms.Label labelQuestionNumber;
        private System.Windows.Forms.Label labelScore;
        private System.Windows.Forms.Label labelScoreName;
        private System.Windows.Forms.Label labelQTime;
        private System.Windows.Forms.Label labelElapsedTime;
    }
}