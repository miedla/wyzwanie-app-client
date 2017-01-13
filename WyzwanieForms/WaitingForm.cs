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
        private int waitingSeconds = 10;
        private DateTime startTime;
        public int playersCount = 0;

        public WaitingForm(Form1 form1, Socket socket)
        {
            InitializeComponent();
            this.form1 = form1;
            this.socket = socket;

            this.Enabled = false;

            timer = new Timer();
            timer.Interval = 500;
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Start();
            startTime = DateTime.Now;

            socket.On("updategame", (data) =>
            {
                JObject jo = JObject.Parse(data.ToString());

                playersCount = int.Parse(jo.GetValue("usersQ").ToString());
                //Debug.WriteLine("playersCount: "+ rjo.GetValue("active").ToString());
                Debug.WriteLine("room jo: " + jo.ToString());
                labelPlayersCount.BeginInvoke(new Action(() =>
                {
                    labelPlayersCount.Text = playersCount.ToString();
                }));

                if (playersCount == form1.requiredPlayersQuantity)
                {
                    timer.Stop();
                    form1.BeginInvoke(new Action(() =>
                    {
                        form1.Enabled = true;
                    }));

                    this.Close();
                    new FormGame(form1.questionList, socket).Show();
                }
            });
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            int elapsedSeconds = (int)(DateTime.Now - startTime).TotalSeconds;
            int remainingSeconds = waitingSeconds - elapsedSeconds;

            if(remainingSeconds <= 0)
            {
                timer.Stop();
                form1.Enabled = true;
                Debug.WriteLine("timer.Interval: " + timer.Interval);

                if (playersCount == form1.requiredPlayersQuantity)
                {
                    this.Close();
                    new FormGame(form1.questionList, socket).Show();
                }
                else
                {
                    labelWaitInfo.Text = "Unfortunately, there's no enought players to play game.";
                    this.Enabled = true;

                    socket.Emit("gamefinished");
                }

                form1.Cursor = Cursors.Default;
                labelSeconds.Visible = false;
            }

            labelSeconds.Invoke(new Action(() =>
            {
                if (!labelSeconds.IsDisposed)
                {
                    labelSeconds.Text = remainingSeconds.ToString();
                }
            }));
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
