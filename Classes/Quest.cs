using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame.Classes
{
    public class Quest
    {
        public string IdQuest;
        public string Text;
        public string CorrectAnswer;
        public string[] IncorrectAnswer;
        public bool Used;
        public string IdQuestCategoty;
        public string IdQuestComplexity;

        public Quest(string idQuest, string text, string correctAnswer, string[] incorrectAnswer, bool used, string idQuestCategoty, string idQuestComplexity)
        {
            IdQuest = idQuest;
            Text = text;
            CorrectAnswer = correctAnswer;
            IncorrectAnswer = incorrectAnswer;
            Used = used;
            IdQuestCategoty = idQuestCategoty;
            IdQuestComplexity = idQuestComplexity;
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
