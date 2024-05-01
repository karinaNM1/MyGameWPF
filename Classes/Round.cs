using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame.Classes
{
    public class Round
    {
        public string IdRound { get; set; }
        public List<Quest> Questions { get; set; }
        public List<QuestCategory> Category { get; set; }
        public List<Player> ChainPlayers { get; set; }

        public Round(string idRound, List<Quest> questions, List<QuestCategory> category, List<Player> chainPlayers)
        {
            IdRound = idRound;
            Questions = questions;
            Category = category;
            ChainPlayers = chainPlayers;
        }

        public List<Quest> CheckQuestions()
        {
            if (Questions.Count == 0) FinishRound();
            return Questions;
        }

        public void FinishRound()
        {
            //Открытие окна с результатами
        }
    }
}
