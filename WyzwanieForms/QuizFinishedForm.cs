using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms;
using Quobject.SocketIoClientDotNet.Client;
using System.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WyzwanieForms
{
    public partial class QuizFinishedForm : Form
    {
        public QuizFinishedForm()
        {
            InitializeComponent();
        }

        public QuizFinishedForm(Socket socket)
        {
            InitializeComponent();
            socket.On("playersscore", (data) =>
            {
                if (this.IsHandleCreated)
                {
                    chartScores.BeginInvoke(new Action(() =>
                    {
                        chartScores.Series["Scores"].Points.Clear();
                        chartScores.Series["Scores"].Points.ResumeUpdates();
                    }));
                }

                JArray scoresArray = JArray.Parse(data.ToString());

                foreach (JObject ps in scoresArray)
                {
                    string playerName = ps.GetValue("name").ToString();
                    int playerScore = int.Parse(ps.GetValue("score").ToString());
                    if (this.IsHandleCreated)
                    {
                        SetChartData(playerName, playerScore);
                    }
                }
            });
        }

        private void SetChartData(string playerName, int score)
        {
            Debug.WriteLine("SetChartData, playerName: " + playerName + " score: "+ score);
            chartScores.BeginInvoke(new Action(() =>
            {
                chartScores.Series["Scores"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
                chartScores.Series["Scores"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
                chartScores.Series["Scores"].Points.AddXY(playerName, score);
            }));
        }
    }
}
