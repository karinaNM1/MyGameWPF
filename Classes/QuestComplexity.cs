using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame.Classes
{
    public class QuestComplexity
    {
        public string IdQuestComplexity;
        public string Tier;
        public string Reward;

        public QuestComplexity(string idQuestComplexity, string tier, string reward)
        {
            IdQuestComplexity = idQuestComplexity;
            Tier = tier;
            Reward = reward;
        }
    }
}
