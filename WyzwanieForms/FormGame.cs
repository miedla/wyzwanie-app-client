using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Quobject.SocketIoClientDotNet.Client;
using System.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WyzwanieForms
{
    public partial class FormGame : Form
    {
        private Socket socket;
        private Form1 menu;
        private List<Question> questionList;
        private Question currentQuestion;
        private char answer;
        private int score = 0;//0f;
        private int currentNumber = 0;
        private System.Timers.Timer timer;
        private DateTime startTime;
        private int timeForQuestion = 10;
        private bool quizFinished = false;

        public FormGame(List<Question> questionList, Socket socket, Form1 menu)
        {
            InitializeComponent();

            this.menu = menu;
            this.socket = socket;
            this.questionList = questionList;
            Debug.WriteLine("questionList.Count: "+ questionList.Count);
            this.FormClosed += FormGame_Closing;
            currentQuestion = questionList.First();
            labelScore.Text = score.ToString();
            score = 0;
            currentNumber = 0;
            //timer = new System.Timers.Timer();

            NextQuestion();

            socket.On("playersscore", (data) =>
            {
                if (this.IsHandleCreated)
                {
                    if (!dataGridViewScores.InvokeRequired)
                    {
                        dataGridViewScores.Rows.Clear();
                        dataGridViewScores.Refresh();
                    }
                    else
                    {
                        dataGridViewScores.BeginInvoke(new Action(() =>
                        {
                            dataGridViewScores.Rows.Clear();
                            dataGridViewScores.Refresh();
                        }));
                    }
                }

                JArray scoresArray = JArray.Parse(data.ToString());
                foreach(JObject ps in scoresArray)
                {
                    string playerName = ps.GetValue("name").ToString();
                    int playerScore = int.Parse(ps.GetValue("score").ToString());
                    if (this.IsHandleCreated)
                    {
                        setScores(playerName, playerScore);
                    }
                    Debug.WriteLine("playersscore playername: " + playerName);
                }
                //Debug.WriteLine("playersscore, data: "+data);
            });
        }

        private void buttonAnswer_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            switch (button.Name)
            {
                case "buttonA":
                    answer = 'a';
                    break;
                case "buttonB":
                    answer = 'b';
                    break;
                case "buttonC":
                    answer = 'c';
                    break;
                case "ButtonD":
                    answer = 'd';
                    break;
            }

            if (answer.Equals(currentQuestion.Correct))
            {
                score += 1;
                labelScore.Text = score.ToString();
            }

            socket.Emit("updatescore", score);
            NextQuestion();
        }

        private void NextQuestion()
        {
            //socket.Emit("updatescore", score);
            currentNumber += 1;
            Debug.WriteLine("currentNumber: "+ currentNumber);
            if (this.IsHandleCreated)
            {
                labelQuestionNumber.BeginInvoke(new Action(() =>
                {
                    labelQuestionNumber.Text = currentNumber.ToString();
                }));
            }
            if (currentNumber <= questionList.Count)
            {
                setTimer();
                currentQuestion = questionList[currentNumber - 1];
                DisplayQuestion();
            }
            else
            {
                timer.Stop();
                timer.Elapsed -= Timer_Tick;

                Debug.WriteLine("FORM GAME TIMER STOPPED");
                socket.Emit("playerexitedgame");
                if (this.IsHandleCreated)
                {
                    if (!this.IsDisposed)
                    {
                        this.Invoke(new Action(() =>
                        {
                            new QuizFinishedForm(socket).Show();
                            this.Close();
                        }));
                    }
                }
            }
        }

        private void DisplayQuestion()
        {
            if (this.IsHandleCreated)
            {
                labelQuestion.BeginInvoke(new Action(() =>
                {
                    labelQuestion.Text = currentQuestion.QuestionName;
                }));

                buttonA.BeginInvoke(new Action(() =>
                {
                    buttonA.Text = currentQuestion.Answers['a'];
                }));

                buttonB.BeginInvoke(new Action(() =>
                {
                    buttonB.Text = currentQuestion.Answers['b'];
                }));

                buttonC.BeginInvoke(new Action(() =>
                {
                    buttonC.Text = currentQuestion.Answers['c'];
                }));

                buttonD.BeginInvoke(new Action(() =>
                {
                    buttonD.Text = currentQuestion.Answers['d'];
                }));
            }

            answer = currentQuestion.Correct;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            int elapsedSeconds = (int)(DateTime.Now - startTime).TotalSeconds;
            int remainingSeconds = timeForQuestion - elapsedSeconds;
            //Debug.WriteLine("FORM GAME, remainingSeconds: " + remainingSeconds);
            if (this.IsHandleCreated)
            {
                labelQTime.BeginInvoke(new Action(() =>
                {
                    labelQTime.Text = remainingSeconds.ToString();
                }));
            }

            if (remainingSeconds == 0 && !quizFinished)
            {
                timer.Stop();
                NextQuestion();
                quizFinished = true;
            }
        }

        private void setTimer()
        {
            Debug.WriteLine("FORM GAME, setTimer(): ");
            timer = new System.Timers.Timer();
            timer.Interval = 500;
            timer.Elapsed += Timer_Tick;
            timer.Start();
            startTime = DateTime.Now;
        }

        private void setScores(string playerName, int playerScore)
        {
            if (!dataGridViewScores.InvokeRequired)
            {
                dataGridViewScores.Rows.Add(playerName, playerScore);
                dataGridViewScores.Refresh();
            }
            else
            {
                dataGridViewScores.BeginInvoke(new Action(() =>
                {
                    dataGridViewScores.Rows.Add(playerName, playerScore);
                    dataGridViewScores.Update();
                }));
            }
        }

        private void FormGame_Closing(object sender, FormClosedEventArgs e)
        {
            Debug.WriteLine("FormGame_Closing");
            menu.Invoke(new Action(() =>
            {
                menu.Cursor = Cursors.Default;
                menu.GetSocket.Emit("playerexitedgame");
            }));
        }
    }
}
