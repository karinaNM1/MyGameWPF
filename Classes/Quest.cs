using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame.Classes
{
    public class Quest
    {
        public string IdQuest { get; set; }
        public string Text { get; set; }
        public string CorrectAnswer { get; set; }
        public List<string> IncorrectAnswer { get; set; }
        public bool Used { get; set; }
        public QuestCategory Category { get; set; }
        public QuestComplexity Complexity { get; set; }

        public Quest(string idQuest, string text, string correctAnswer, List<string> incorrectAnswer, bool used, QuestCategory category, QuestComplexity complexity)
        {
            this.IdQuest = idQuest;
            this.Text = text;
            this.CorrectAnswer = correctAnswer;
            this.IncorrectAnswer = incorrectAnswer;
            this.Used = used;
            this.Category = category;
            this.Complexity = complexity;
        }

        public bool CheckAnswer(string answer)
        {
            if (answer == CorrectAnswer) return true;
            else return false;
        }

        public string ShowAnswer()
        {
            return CorrectAnswer;
        }
    }
}
