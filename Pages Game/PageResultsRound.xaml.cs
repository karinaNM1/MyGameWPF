using MyGame.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace MyGame.Pages_Game
{
    /// <summary>
    /// Логика взаимодействия для PageResultsRound.xaml
    /// </summary>
    public partial class PageResultsRound : Page
    {
        public PageResultsRound()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            List<Player> players = App.activeRound.ChainPlayers;
            //заполнение игроков
            List<TextBlock> tbPlayers = new List<TextBlock>() { tbPlayer1, tbPlayer2, tbPlayer3, tbPlayer4 };
            for (int i = 0; i < players.Count; i++)
            {
                tbPlayers[i].Text = players[i].Name;
            }

            //заполнение очков
            List<TextBlock> tbPoints = new List<TextBlock>() { tbPoints1, tbPoints2, tbPoints3, tbPoints4 };
            for (int i = 0; i < players.Count; i++)
            {
                tbPoints[i].Text = players[i].Points.ToString();
            }

            if (App.activeRound.IdRound == "2")
            {
                btnNextGame.Width = 0;
            }
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<Player> players = App.activeRound.ChainPlayers;
            App.activeRound = App.rounds[1];
            App.activeRound.ChainPlayers = players;
            Manager.MainFrame.Navigate(new PageQuestions());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
