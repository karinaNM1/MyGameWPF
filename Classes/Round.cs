using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame.Classes
{
    public class Round
    {
        public string IdRound;
        public string[] IdQuestions;
        public string[] ChainPlayers;

        public Round(string idRound, string[] idQuestions, string[] chainPlayers)
        {
            IdRound = idRound;
            IdQuestions = idQuestions;
            ChainPlayers = chainPlayers;
        }

        public string[] CheckQuestions()
        {
            if (IdQuestions.Length == 0) FinishRound();
            return IdQuestions;
        }

        public void FinishRound()
        {
            //Открытие окна с результатами
        }
    }
}
