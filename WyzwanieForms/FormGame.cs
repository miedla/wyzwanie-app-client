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

namespace WyzwanieForms
{
    public partial class FormGame : Form
    {
        private Socket socket;
        private Form1 menu;

        private List<Question> questionList;
        private Question currentQuestion;
        private char answer;
        private float score = 0f;
        private int currentNumber = 1;
        public FormGame(List<Question> questionList, Socket socket, Form1 menu)
        {
            InitializeComponent();

            this.menu = menu;
            this.socket = socket;
            this.questionList = questionList;
            this.FormClosed += FormGame_Closing;
            currentQuestion = questionList.First();
            labelScore.Text = score.ToString();

            DisplayQuestion();
        }

        private void FormGame_FormClosed(object sender, FormClosedEventArgs e)
        {
            throw new NotImplementedException();
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
                score += 1f;
                labelScore.Text = score.ToString();
            }

            currentNumber += 1;
            labelQuestionNumber.Text = currentNumber.ToString();

            if (currentNumber <= questionList.Count)
            {
                currentQuestion = questionList[currentNumber - 1];
                DisplayQuestion();
            }else
            {
                DialogResult dr = MessageBox.Show("Quiz finished! Your score: " + score, "Congratulations!", MessageBoxButtons.OK);

                if(dr == DialogResult.OK)
                {
                    socket.Emit("playerexitedgame");
                    this.Close();
                }
            }
        }

        private void DisplayQuestion()
        {
            labelQuestion.Text = currentQuestion.QuestionName;
            buttonA.Text = currentQuestion.Answers['a'];
            buttonB.Text = currentQuestion.Answers['b'];
            buttonC.Text = currentQuestion.Answers['c'];
            buttonD.Text = currentQuestion.Answers['d'];

            answer = currentQuestion.Correct;
        }

        private void FormGame_Closing(object sender, FormClosedEventArgs e)
        {
            //menu.Cursor = Cursors.Default;
            menu.Invoke(new Action(() =>
            {
                menu.Cursor = Cursors.Default;
                menu.GetSocket.Emit("playerexitedgame");
            }));
            //socket.Emit("playerexitedgame");
        }
    }
}
