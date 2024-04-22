using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using MyGame.Classes;

namespace MyGame
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Round activeRound { get; set; }
        public static Quest activeQuest { get; set; }
        public static Player activePlayer { get; set; }
        public static User activeUser { get; set; }
    }
}
