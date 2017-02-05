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
    public partial class WaitingForm : Form
    {
        private Form1 form1;
        private Socket socket;
        private Timer timer;
        private int waitingSeconds;// = 10;
        private DateTime startTime;
        private string labelWaitInfoText;
        private bool gameStarted;
        public int playersCount = 0;
        private string noEnoughPlayersInfo = "Unfortunately, there's no enought players to play the game.";

        public WaitingForm(Form1 form1, Socket socket)
        {
            InitializeComponent();
            labelWaitInfoText = noEnoughPlayersInfo;
            gameStarted = true;
            InitializeWaitingForm(10, form1, socket);

            socket.On("updategame", (data) =>
            {
                JObject jo = JObject.Parse(data.ToString());

                playersCount = int.Parse(jo.GetValue("usersQ").ToString());
                //Debug.WriteLine("playersCount: "+ rjo.GetValue("active").ToString());
                Debug.WriteLine("room jo: " + jo.ToString());
                if (!this.IsDisposed)
                {
                    labelPlayersCount.BeginInvoke(new Action(() =>
                    {
                        labelPlayersCount.Text = playersCount.ToString() + "/" + form1.requiredPlayersQuantity;
                    }));
                }

                if (playersCount == form1.requiredPlayersQuantity)
                {
                    timer.Stop();
                    form1.BeginInvoke(new Action(() =>
                    {
                        form1.Enabled = true;
                    }));

                    if (this.IsHandleCreated)
                    {
                        Debug.WriteLine("WaitingForm, playersCount == form1.requiredPlayersQuantity");
                        socket.Emit("requiredplayersforquiz");
                        FormGame gf = new FormGame(form1.questionList, socket, form1);
                        this.Invoke(new Action(() =>
                        {
                            gf.Show();
                            this.Close();
                        }));
                    }
                }
            });
        }

        public WaitingForm(Form1 form1, Socket socket, string labelWaitInfoText)
        {
            InitializeComponent();
            this.labelWaitInfoText = labelWaitInfoText;
            InitializeWaitingForm(0, form1, socket);
            labelWaitingSeconds.Visible = false;
            this.socket = socket;
            Debug.WriteLine("WaitingForm()");

            socket.On("quizstarted", () =>
            {
                Debug.WriteLine("quizstarted");
                
                if (this.IsHandleCreated)
                {
                    this.Invoke(new Action(() =>
                    {
                        Debug.WriteLine("form1.questionList.Count: "+ form1.questionList.Count);
                        FormGame fg = new FormGame(form1.questionList, socket, form1);
                        fg.Show();
                        this.Close();
                    }));
                }
            });

            socket.On("updategame", (data) =>
            {
                JObject jo = JObject.Parse(data.ToString());
                playersCount = int.Parse(jo.GetValue("usersQ").ToString());

                if (!this.IsDisposed)
                {
                    labelPlayersCount.BeginInvoke(new Action(() =>
                    {
                        labelPlayersCount.Text = playersCount.ToString() + "/" + form1.requiredPlayersQuantity;
                    }));
                }
            });

            socket.On("quizfinished", () =>
            {
                if (this.IsHandleCreated)
                {
                    labelWaitInfo.BeginInvoke(new Action(() =>
                    {
                        labelWaitInfo.Text = noEnoughPlayersInfo;
                    }));
                }

                if (!this.InvokeRequired)
                {
                    this.Close();//this.Enabled = true;
                    form1.GetButtonPlay.Enabled = true;
                }
                else
                {
                    this.BeginInvoke(new Action(() =>
                    {
                        this.Close();//this.Enabled = true;
                        form1.GetButtonPlay.Enabled = true;
                    }));
                }
            });

        }

        private void InitializeWaitingForm(int waitingSeconds, Form1 form1, Socket socket)
        {
            this.form1 = form1;
            this.socket = socket;
            this.waitingSeconds = waitingSeconds;
            this.Enabled = false;

            if (waitingSeconds != 0)
            {
                timer = new Timer();
                timer.Interval = 500;
                timer.Tick += new EventHandler(Timer_Tick);
                timer.Start();
                startTime = DateTime.Now;
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            int elapsedSeconds = (int)(DateTime.Now - startTime).TotalSeconds;
            int remainingSeconds = waitingSeconds - elapsedSeconds;

            if(remainingSeconds <= 0)
            {
                timer.Stop();
                form1.Enabled = true;

                if (gameStarted)
                {
                    if (playersCount == form1.requiredPlayersQuantity)
                    {
                        Debug.WriteLine("WaitingForm, playersCount == form1.requiredPlayersQuantity");
                        socket.Emit("requiredplayersforquiz");
                        FormGame fg = new FormGame(form1.questionList, socket, form1);
                        fg.Show();
                        this.Close();
                    }
                    else
                    {
                        labelWaitInfo.Text = labelWaitInfoText;
                        this.Enabled = true;
                        form1.GetButtonPlay.Enabled = true;
                        socket.Emit("gamefinished");
                    }
                }

                form1.Cursor = Cursors.Default;
                labelSeconds.Visible = false;
            }

            if (this.IsHandleCreated)
            {
                labelSeconds.Invoke(new Action(() =>
                {
                    if (!labelSeconds.IsDisposed)
                    {
                        labelSeconds.Text = remainingSeconds.ToString();
                    }
                }));
            }
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
