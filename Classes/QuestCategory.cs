using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame.Classes
{
    public class QuestCategory : Quest
    {
        public string IdQuestCategory;
        public string Theme;

        public QuestCategory(string idQuestCategory, string theme, string idQuest, string text, string correctAnswer, string[] incorrectAnswer, bool used) : base(idQuest, text, correctAnswer, incorrectAnswer, used)
        {
            IdQuestCategory = idQuestCategory;
            Theme = theme;
        }
    }
}
