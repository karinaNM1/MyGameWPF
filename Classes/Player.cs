using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame.Classes
{
    public class Player
    {
        public string IdPlayer { get; set; }
        public string Name { get; set; }
        public int Points { get; set; }

        public Player(string idPlayer, string name, int points) 
        {
            IdPlayer = idPlayer;
            Name = name;
            Points = points;
        }

        public void AddPoints(int reward)
        {
            Points = Points + reward;
        }

        public void DeletePoints(int reward)
        {
            Points = Points - reward;
        }
    }
}
