using MyGame.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static MyGame.PageChangeQuestions;

namespace MyGame
{
    /// <summary>
    /// Логика взаимодействия для PageQuestions.xaml
    /// </summary>
    public partial class PageQuestions : Page
    {
        public PageQuestions()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            string projectPath = AppDomain.CurrentDomain.BaseDirectory;
            projectPath = projectPath.Substring(0, projectPath.Length - 10);
            string filename = projectPath + "Resources/Json files/Players.json";
            string jsonstring = File.ReadAllText(filename);
            List<Player> players = JsonSerializer.Deserialize<List<Player>>(jsonstring);

            List<TextBlock> tbPlayers = new List<TextBlock>() { tbPlayer1 , tbPlayer2 , tbPlayer3 , tbPlayer4};
            for(int i = 0; i < players.Count; i++)
            {
                tbPlayers[i].Text = players[i].Name;
            }

            List<TextBlock> tbPoints = new List<TextBlock>() { tbPoints1, tbPoints2, tbPoints3, tbPoints4 };
            for (int i = 0; i < players.Count; i++)
            {
                tbPoints[i].Text = players[i].Points.ToString();
            }

            List<Border> borderPlayers = new List<Border>() { borderPlayer1, borderPlayer2, borderPlayer3, borderPlayer4 };
            App.activeUser.ActivePlayers(players);
            borderPlayers[int.Parse(App.activePlayer.IdPlayer)].Background = Brushes.Gold;

        }
    }
}
