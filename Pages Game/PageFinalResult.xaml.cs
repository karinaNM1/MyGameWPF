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

namespace MyGame
{
    /// <summary>
    /// Логика взаимодействия для PageFinalResult.xaml
    /// </summary>
    public partial class PageFinalResult : Page
    {
        public PageFinalResult()
        {
            InitializeComponent();
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            List<Player> players = App.activeRound.ChainPlayers.OrderByDescending(p => p.Points).ToList();
            //заполнение игроков
            List<TextBlock> tbPlayers = new List<TextBlock>() { tbPlayer1, tbPlayer2, tbPlayer3 };
            for (int i = 0; i < tbPlayers.Count; i++)
            {
                tbPlayers[i].Text = players[i].Name;
            }

            //заполнение очков
            List<TextBlock> tbPoints = new List<TextBlock>() { tbPoints1, tbPoints2, tbPoints3 };
            for (int i = 0; i < tbPoints.Count; i++)
            {
                tbPoints[i].Text = players[i].Points.ToString();
            }

            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new PageStartGame());
            App.activeRound = null;
            App.activePlayer = null;
            App.activeUser.DeletePlayers();
            App.activeUser = null;
        }
    }
}
