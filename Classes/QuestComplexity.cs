using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame.Classes
{
    public class QuestComplexity : Quest
    {
        public string IdQuestComplexity;
        public string Tier;
        public string Reward;

        public QuestComplexity(string idQuestComplexity, string tier, string reward, string idQuest, string text, string correctAnswer, string[] incorrectAnswer, bool used) : base(idQuest, text, correctAnswer, incorrectAnswer, used)
        {
            IdQuestComplexity = idQuestComplexity;
            Tier = tier;
            Reward = reward;
        }
    }
}
