namespace WyzwanieForms
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
            this.components = new System.ComponentModel.Container();
            this.buttonServerConnect = new System.Windows.Forms.Button();
            this.textBoxMessage = new System.Windows.Forms.TextBox();
            this.buttonSend = new System.Windows.Forms.Button();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.listViewConnectedUsers = new System.Windows.Forms.ListView();
            this.columnUsername = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnScore = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.labelUsersList = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.labelMessage = new System.Windows.Forms.Label();
            this.buttonCreateRoom = new System.Windows.Forms.Button();
            this.textBoxRoomName = new System.Windows.Forms.TextBox();
            this.labelRoomName = new System.Windows.Forms.Label();
            this.listBoxRooms = new System.Windows.Forms.ListBox();
            this.labelRoomList = new System.Windows.Forms.Label();
            this.listViewMessages = new System.Windows.Forms.ListView();
            this.columnMessage = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnFrom = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonPlay = new System.Windows.Forms.Button();
            this.timerWaitForPlayers = new System.Windows.Forms.Timer(this.components);
            this.comboBoxRoomPlayers = new System.Windows.Forms.ComboBox();
            this.labelRoomPlayers = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonServerConnect
            // 
            this.buttonServerConnect.Location = new System.Drawing.Point(215, 1);
            this.buttonServerConnect.Name = "buttonServerConnect";
            this.buttonServerConnect.Size = new System.Drawing.Size(115, 23);
            this.buttonServerConnect.TabIndex = 0;
            this.buttonServerConnect.Text = "ConnectToServer";
            this.buttonServerConnect.UseVisualStyleBackColor = true;
            this.buttonServerConnect.Click += new System.EventHandler(this.buttonConnectToServer_Click);
            // 
            // textBoxMessage
            // 
            this.textBoxMessage.Location = new System.Drawing.Point(89, 111);
            this.textBoxMessage.Name = "textBoxMessage";
            this.textBoxMessage.Size = new System.Drawing.Size(115, 20);
            this.textBoxMessage.TabIndex = 1;
            // 
            // buttonSend
            // 
            this.buttonSend.Location = new System.Drawing.Point(105, 140);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(75, 23);
            this.buttonSend.TabIndex = 2;
            this.buttonSend.Text = "Send";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.SendMessage_Click);
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(89, 0);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(115, 20);
            this.textBoxName.TabIndex = 4;
            // 
            // listViewConnectedUsers
            // 
            this.listViewConnectedUsers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnUsername,
            this.columnScore});
            this.listViewConnectedUsers.Location = new System.Drawing.Point(592, 27);
            this.listViewConnectedUsers.Name = "listViewConnectedUsers";
            this.listViewConnectedUsers.Size = new System.Drawing.Size(152, 222);
            this.listViewConnectedUsers.TabIndex = 5;
            this.listViewConnectedUsers.UseCompatibleStateImageBehavior = false;
            this.listViewConnectedUsers.View = System.Windows.Forms.View.Details;
            this.listViewConnectedUsers.SelectedIndexChanged += new System.EventHandler(this.UsernameListViewSelected_Changed);
            // 
            // columnUsername
            // 
            this.columnUsername.Text = "Username";
            this.columnUsername.Width = 80;
            // 
            // columnScore
            // 
            this.columnScore.Text = "Score";
            // 
            // labelUsersList
            // 
            this.labelUsersList.AutoSize = true;
            this.labelUsersList.Location = new System.Drawing.Point(633, 9);
            this.labelUsersList.Name = "labelUsersList";
            this.labelUsersList.Size = new System.Drawing.Size(87, 13);
            this.labelUsersList.TabIndex = 6;
            this.labelUsersList.Text = "Connected users";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(26, 3);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(35, 13);
            this.labelName.TabIndex = 7;
            this.labelName.Text = "Name";
            // 
            // labelMessage
            // 
            this.labelMessage.AutoSize = true;
            this.labelMessage.Location = new System.Drawing.Point(26, 114);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(50, 13);
            this.labelMessage.TabIndex = 8;
            this.labelMessage.Text = "Message";
            // 
            // buttonCreateRoom
            // 
            this.buttonCreateRoom.Location = new System.Drawing.Point(218, 35);
            this.buttonCreateRoom.Name = "buttonCreateRoom";
            this.buttonCreateRoom.Size = new System.Drawing.Size(75, 23);
            this.buttonCreateRoom.TabIndex = 9;
            this.buttonCreateRoom.Text = "Create room";
            this.buttonCreateRoom.UseVisualStyleBackColor = true;
            this.buttonCreateRoom.Click += new System.EventHandler(this.CreateRoom_Click);
            // 
            // textBoxRoomName
            // 
            this.textBoxRoomName.Location = new System.Drawing.Point(89, 35);
            this.textBoxRoomName.Name = "textBoxRoomName";
            this.textBoxRoomName.Size = new System.Drawing.Size(115, 20);
            this.textBoxRoomName.TabIndex = 10;
            // 
            // labelRoomName
            // 
            this.labelRoomName.AutoSize = true;
            this.labelRoomName.Location = new System.Drawing.Point(26, 38);
            this.labelRoomName.Name = "labelRoomName";
            this.labelRoomName.Size = new System.Drawing.Size(64, 13);
            this.labelRoomName.TabIndex = 11;
            this.labelRoomName.Text = "Room name";
            // 
            // listBoxRooms
            // 
            this.listBoxRooms.FormattingEnabled = true;
            this.listBoxRooms.Location = new System.Drawing.Point(396, 27);
            this.listBoxRooms.Name = "listBoxRooms";
            this.listBoxRooms.Size = new System.Drawing.Size(170, 225);
            this.listBoxRooms.TabIndex = 12;
            this.listBoxRooms.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBoxRooms_DoubleClick);
            // 
            // labelRoomList
            // 
            this.labelRoomList.AutoSize = true;
            this.labelRoomList.Location = new System.Drawing.Point(453, 9);
            this.labelRoomList.Name = "labelRoomList";
            this.labelRoomList.Size = new System.Drawing.Size(50, 13);
            this.labelRoomList.TabIndex = 13;
            this.labelRoomList.Text = "Room list";
            // 
            // listViewMessages
            // 
            this.listViewMessages.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnMessage,
            this.columnFrom});
            this.listViewMessages.Location = new System.Drawing.Point(12, 168);
            this.listViewMessages.Name = "listViewMessages";
            this.listViewMessages.Size = new System.Drawing.Size(325, 97);
            this.listViewMessages.TabIndex = 14;
            this.listViewMessages.UseCompatibleStateImageBehavior = false;
            this.listViewMessages.View = System.Windows.Forms.View.Details;
            // 
            // columnMessage
            // 
            this.columnMessage.Text = "Message";
            this.columnMessage.Width = 200;
            // 
            // columnFrom
            // 
            this.columnFrom.Text = "From";
            this.columnFrom.Width = 120;
            // 
            // buttonPlay
            // 
            this.buttonPlay.Location = new System.Drawing.Point(234, 111);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(103, 52);
            this.buttonPlay.TabIndex = 15;
            this.buttonPlay.Text = "Start Game";
            this.buttonPlay.UseVisualStyleBackColor = true;
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
            // 
            // comboBoxRoomPlayers
            // 
            this.comboBoxRoomPlayers.FormattingEnabled = true;
            this.comboBoxRoomPlayers.Items.AddRange(new object[] {
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.comboBoxRoomPlayers.Location = new System.Drawing.Point(122, 65);
            this.comboBoxRoomPlayers.Name = "comboBoxRoomPlayers";
            this.comboBoxRoomPlayers.Size = new System.Drawing.Size(53, 21);
            this.comboBoxRoomPlayers.TabIndex = 16;
            // 
            // labelRoomPlayers
            // 
            this.labelRoomPlayers.AutoSize = true;
            this.labelRoomPlayers.Location = new System.Drawing.Point(26, 68);
            this.labelRoomPlayers.Name = "labelRoomPlayers";
            this.labelRoomPlayers.Size = new System.Drawing.Size(90, 13);
            this.labelRoomPlayers.TabIndex = 17;
            this.labelRoomPlayers.Text = "Required Players:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 277);
            this.Controls.Add(this.labelRoomPlayers);
            this.Controls.Add(this.comboBoxRoomPlayers);
            this.Controls.Add(this.buttonPlay);
            this.Controls.Add(this.listViewMessages);
            this.Controls.Add(this.labelRoomList);
            this.Controls.Add(this.listBoxRooms);
            this.Controls.Add(this.labelRoomName);
            this.Controls.Add(this.textBoxRoomName);
            this.Controls.Add(this.buttonCreateRoom);
            this.Controls.Add(this.labelMessage);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.labelUsersList);
            this.Controls.Add(this.listViewConnectedUsers);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.textBoxMessage);
            this.Controls.Add(this.buttonServerConnect);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonServerConnect;
        private System.Windows.Forms.TextBox textBoxMessage;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.ListView listViewConnectedUsers;
        private System.Windows.Forms.Label labelUsersList;
        private System.Windows.Forms.ColumnHeader columnUsername;
        private System.Windows.Forms.ColumnHeader columnScore;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelMessage;
        private System.Windows.Forms.Button buttonCreateRoom;
        private System.Windows.Forms.TextBox textBoxRoomName;
        private System.Windows.Forms.Label labelRoomName;
        private System.Windows.Forms.ListBox listBoxRooms;
        private System.Windows.Forms.Label labelRoomList;
        private System.Windows.Forms.ListView listViewMessages;
        private System.Windows.Forms.ColumnHeader columnMessage;
        private System.Windows.Forms.ColumnHeader columnFrom;
        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.Timer timerWaitForPlayers;
        private System.Windows.Forms.ComboBox comboBoxRoomPlayers;
        private System.Windows.Forms.Label labelRoomPlayers;
    }
}

