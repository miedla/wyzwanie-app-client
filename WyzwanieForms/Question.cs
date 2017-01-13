using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WyzwanieForms
{
    public class Question
    {
        string id;
        string question;
        char correct;
        Dictionary<char, string> answers;

        public Question(string id, string question, char correct, Dictionary<char, string> answers)
        {
            this.id = id;
            this.question = question;
            this.correct = correct;
            this.answers = answers;
        }

        public string Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string QuestionName
        {
            get
            {
                return question;
            }

            set
            {
                question = value;
            }
        }

        public char Correct
        {
            get
            {
                return correct;
            }

            set
            {
                correct = value;
            }
        }

        public Dictionary<char, string> Answers
        {
            get
            {
                return answers;
            }

            set
            {
                answers = value;
            }
        }
    }
}
