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
        public List<string> IncorrectAnswer;
        public bool Used;
        public QuestCategory Category;
        public QuestComplexity Complexity;

        public Quest(string idQuest, string text, string correctAnswer, List<string> incorrectAnswer, bool used, QuestCategory idQuestCategory, QuestComplexity idQuestComplexity)
        {
            IdQuest = idQuest;
            Text = text;
            CorrectAnswer = correctAnswer;
            IncorrectAnswer = incorrectAnswer;
            Used = used;
            Category = idQuestCategory;
            Complexity = idQuestComplexity;
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
