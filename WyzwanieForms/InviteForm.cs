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
    public partial class InviteForm : Form
    {
        private Socket socket;
        private Form1 menu;

        public InviteForm()
        {
            InitializeComponent();
        }

        public InviteForm(string message, Socket socket, Form1 menu)
        {
            InitializeComponent();

            this.socket = socket;
            this.menu = menu;
            label1.Text = message;

            socket.On("updategame", (data) =>
            {
                Debug.WriteLine("InviteForm data: "+ data);
                JObject jo = JObject.Parse(data.ToString());
                bool isGameFinished = bool.Parse(jo.GetValue("active").ToString());
                bool isQuizStarted = bool.Parse(jo.GetValue("isQuizStarted").ToString());

                if (this.IsHandleCreated && (!isGameFinished || isQuizStarted))
                {
                    Invoke(new Action(() =>
                    { 
                        this.Close();
                    }));
                }
            });
        }

        private void buttonYes_Click(object sender, EventArgs e)
        {
            if (this.IsHandleCreated)
            {
                new WaitingForm(menu, socket, "Waiting for rest players...").Show();
                socket.Emit("playerjoinedgame");
                //Invoke(new Action(() =>
                //{
                //    new WaitingForm(menu, socket, "Waiting for rest players...").Show();
                //}));
                this.Close();
            }
        }

        private void buttonNo_Click(object sender, EventArgs e)
        {
            if (this.IsHandleCreated)
            {
                this.Close();
            }
        }
    }
}
