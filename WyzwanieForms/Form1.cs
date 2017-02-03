using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

//using System.Net.Sockets;
using System.Threading;
using Quobject.SocketIoClientDotNet.Client;
using Quobject.EngineIoClientDotNet.ComponentEmitter;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Converters;
using System.Net.Http;
using System.Net.Http.Headers;

namespace WyzwanieForms
{
    public partial class Form1 : Form
    {
        static HttpClient client = new HttpClient();
        public List<Question> questionList = new List<Question>();
        public WaitingForm waitingForm;

        public Socket GetSocket
        {
            get { return socket; }
        }

        //public Button GetButtonPlay
        //{
        //    get { return buttonPlay; }
        //}

        static async Task<List<Question>> GetQuestionsAsync(string path)
        {
            List<Question> questions = new List<Question>();
            HttpResponseMessage response = await client.GetAsync(path);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                Debug.WriteLine("get questions ok: " + content);

                JArray qjarray = JArray.Parse(content);//JObject.Parse(q);
                //Debug.WriteLine("qjarray: " + qjarray);
                foreach(JObject qo in qjarray)
                {
                    //Debug.WriteLine("qo.id: " + qo.GetValue("_id").ToString());
                    string id = qo.GetValue("_id").ToString();
                    string questionName = qo.GetValue("question").ToString();
                    char correct = Char.Parse(qo.GetValue("correct").ToString());
                    Dictionary<char, string> answers = new Dictionary<char, string>();
                    JArray aarray = JArray.Parse(qo.GetValue("answers").ToString());

                    foreach (JObject ao in aarray)
                    {
                        char key = Char.Parse(ao.Properties().ToArray()[0].Name);
                        string value = ao.GetValue(key.ToString()).ToString();
                        Debug.WriteLine("key: " + key);
                        Debug.WriteLine("value: "+value);
                        answers.Add(key, value);
                    }

                    Question question = new Question(id, questionName, correct, answers);
                    if (question != null)
                    {
                        questions.Add(question);
                    }else
                    {
                        Debug.WriteLine("question is NULL");
                    }
                }
                return questions;
            }
            else
            {
                Debug.WriteLine("get questions error");
            }

            return null;
        }

        const String socketAddress = "http://localhost:8000";
        List<String> usernameList = new List<string>();
        List<String> roomList = new List<string>();
        Socket socket; //= IO.Socket(socketAddress);
        String selectedUser = String.Empty;
        public int requiredPlayersQuantity = 2;

        public Form1()
        {
            InitializeComponent();

            client.BaseAddress = new Uri("http://localhost:5000/");
            //client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            comboBoxRoomPlayers.SelectedIndex = 0;
        }

        private async void buttonPlay_Click(object sender, EventArgs e)
        {
            try
            {
                this.Enabled = false;
                this.Cursor = Cursors.WaitCursor;
                waitingForm = new WaitingForm(this, socket);
                waitingForm.Show();

                //waitingForm.FormClosed += new FormClosedEventHandler((s, e) =>
                //{
                //    buttonPlay
                //});


                questionList = await GetQuestionsAsync("http://localhost:5000/getQuestions.json");

                //new FormGame(questionList, socket).Show();

                buttonPlay.Enabled = false;

                string jsonQuestionList = JsonConvert.SerializeObject(questionList);
                Debug.WriteLine("gamestarted, jsonQList: " + jsonQuestionList);
                socket.Emit("gamestarted", jsonQuestionList);
            }
            catch(Exception ex)
            {
                Debug.WriteLine("Error: "+ex.ToString());
            }
        }

        private void buttonConnectToServer_Click(object sender, System.EventArgs e)
        {
            socket = IO.Socket(socketAddress);

            socket.On(Socket.EVENT_CONNECT, () =>
            {
                Debug.WriteLine("Socket.EVENT_CONNECT");
                socket.Emit("adduser", textBoxName.Text.Trim());
            });

            socket.On("updatechat", (data) =>
            {
                Debug.WriteLine("data: " + data.ToString());
                try
                {
                    JObject json = JObject.Parse(data.ToString());
                    string message = (string) json.GetValue("message");
                    string from = (string)json.GetValue("from");
                    string info = "MESSAGE: " + message + "\n" + "FROM: " + from + "\n";

                    listViewMessages.Invoke(new Action(() =>
                    {
                        string[] row = { message, from };
                        ListViewItem item = new ListViewItem(row);
                        listViewMessages.Items.Add(item);
                    }));
                }
                catch(JsonReaderException ex)
                {
                    Debug.WriteLine(ex.ToString());
                }
            });

            socket.On("updateusers", (data) =>
            {
                Debug.WriteLine("updateusers data: "+data.ToString());
                try
                {
                    JArray jarray = JArray.Parse(data.ToString());

                    usernameList = new List<string>();
                    listViewConnectedUsers.Invoke(new Action(delegate ()
                    {
                        listViewConnectedUsers.Items.Clear();
                    }));

                    foreach (Object o in jarray)
                    {
                        usernameList.Add(o.ToString());
                        listViewConnectedUsers.Invoke(new Action(delegate ()
                        {
                            if (!listViewConnectedUsers.Items.ContainsKey(usernameList.Last()))
                            {
                                string[] row = { usernameList.Last(), "0" };
                                ListViewItem item = new ListViewItem(row);
                                listViewConnectedUsers.Items.Add(item);
                                Debug.WriteLine(listViewConnectedUsers.Items[0].Name);
                            }
                        }));
                    }
                }
                catch (JsonReaderException ex)
                {
                    Debug.WriteLine(ex.ToString());
                }

            });

            socket.On("updaterooms", (data) =>
            {
                roomList = new List<string>();

                JArray jarray = JArray.Parse(data.ToString());
                listBoxRooms.Invoke(new Action(delegate ()
                {
                    listBoxRooms.Items.Clear();
                }));
                foreach(Object o in jarray)
                {
                    Debug.WriteLine("room: "+o.ToString());
                    roomList.Add(o.ToString());
                    listBoxRooms.Invoke(new Action(delegate ()
                    {
                        listBoxRooms.Items.Add(roomList.Last());
                    }));
                }
            });

            socket.On("gameinvite", (data) =>
            {
                JObject jo = JObject.Parse(data.ToString());
                JArray jarray = JArray.Parse(jo.GetValue("questions").ToString());

                foreach(JObject o in jarray)
                {
                    Debug.WriteLine("gameInvite o: "+o.ToString());
                    string id = o.GetValue("Id").ToString();
                    string questioName = o.GetValue("QuestionName").ToString();
                    char correct = char.Parse(o.GetValue("Correct").ToString());
                    Dictionary<string, string> answersS = JsonConvert.DeserializeObject<Dictionary<string, string>>(o.GetValue("Answers").ToString());//new Dictionary<char, string>();

                    Dictionary<char, string> answers = answersS.ToDictionary(x => char.Parse(x.Key.ToString()), x => x.Value.ToString());

                    Question q = new Question(id, questioName, correct, answers);
                    questionList.Add(q);
                }

                DialogResult dr = MessageBox.Show("Username: " + jo.GetValue("from"), " send You Invitation for play game.\nDo You accept his request?", MessageBoxButtons.YesNo);

                if(dr == DialogResult.Yes)
                {
                    Invoke(new Action(() =>
                    {
                        socket.Emit("playerjoinedgame");
                        new FormGame(questionList, socket, this).Show();
                    }));
                    
                }
                if(dr == DialogResult.No)
                {

                }
                buttonPlay.Invoke(new Action(() =>
                {
                    buttonPlay.Enabled = false;
                }));
            });

            socket.On("updategame", (data) =>
            {
                JObject jo = JObject.Parse(data.ToString());
                Debug.WriteLine("room jo: " + jo.ToString());
                Debug.WriteLine("room active: " + bool.Parse(jo.GetValue("active").ToString()));

                if (!bool.Parse(jo.GetValue("active").ToString()))
                {
                    buttonPlay.Invoke(new Action(() =>
                    {
                        buttonPlay.Enabled = true;
                    }));
                }
            });
        }

        private void SendMessage_Click(object sender, System.EventArgs e)
        {
            if (selectedUser.Equals(String.Empty))
            {
                socket.Emit("sendchat", textBoxMessage.Text);
            }
            else
            {
                socket.Emit("sendpm", textBoxMessage.Text, selectedUser);
            }
        }

        private void CreateRoom_Click(object sender, System.EventArgs e)
        {
            requiredPlayersQuantity = int.Parse(comboBoxRoomPlayers.SelectedItem.ToString());
            socket.Emit("create", textBoxRoomName.Text);
        }

        private void listBoxRooms_DoubleClick(object sender, MouseEventArgs e)
        {
            int index = listBoxRooms.IndexFromPoint(e.Location);
            if(index != ListBox.NoMatches)
            {
                Debug.WriteLine("index: "+index);
                string selectedRoom = listBoxRooms.Items[index].ToString();
                socket.Emit("switchRoom", selectedRoom);
            }
        }

        private void UsernameListViewSelected_Changed(object sender, System.EventArgs e)
        {
            if(listViewConnectedUsers.SelectedItems.Count == 0)
            {
                return;
            }

            selectedUser = listViewConnectedUsers.SelectedItems[0].Text;
            Debug.WriteLine("selected item: "+ selectedUser);
        }
    }
}
