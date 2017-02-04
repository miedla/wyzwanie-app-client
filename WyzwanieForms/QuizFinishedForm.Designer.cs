namespace WyzwanieForms
{
    partial class QuizFinishedForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartScores = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.labelCongratz = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chartScores)).BeginInit();
            this.SuspendLayout();
            // 
            // chartScores
            // 
            chartArea1.Name = "ChartArea1";
            this.chartScores.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartScores.Legends.Add(legend1);
            this.chartScores.Location = new System.Drawing.Point(22, 112);
            this.chartScores.Name = "chartScores";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Scores";
            this.chartScores.Series.Add(series1);
            this.chartScores.Size = new System.Drawing.Size(376, 146);
            this.chartScores.TabIndex = 0;
            this.chartScores.Text = "Final scores:";
            // 
            // labelCongratz
            // 
            this.labelCongratz.AutoSize = true;
            this.labelCongratz.Location = new System.Drawing.Point(175, 9);
            this.labelCongratz.Name = "labelCongratz";
            this.labelCongratz.Size = new System.Drawing.Size(83, 13);
            this.labelCongratz.TabIndex = 1;
            this.labelCongratz.Text = "Congratulations!";
            // 
            // QuizFinishedForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 261);
            this.Controls.Add(this.labelCongratz);
            this.Controls.Add(this.chartScores);
            this.Name = "QuizFinishedForm";
            this.Text = "QuizFinishedForm";
            ((System.ComponentModel.ISupportInitialize)(this.chartScores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartScores;
        private System.Windows.Forms.Label labelCongratz;
    }
}