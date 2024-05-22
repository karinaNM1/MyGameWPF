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
    /// Логика взаимодействия для PageSecondDifficulty.xaml
    /// </summary>
    public partial class PageSecondDifficulty : Page
    {
        
        public PageSecondDifficulty()
        {
            InitializeComponent();
        }

        bool btnClik = true;
        int nextUser = 0;
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Players_Load();
            tbQuest.Text = App.activeQuest.Text;

            Random rand = new Random();
            int r = rand.Next(1, 4);
            if (r == 1)
            {
                btnAnsweOne.Content = App.activeQuest.CorrectAnswer;
                btnAnsweTwo.Content = App.activeQuest.IncorrectAnswer[0];
                btnAnsweTree.Content = App.activeQuest.IncorrectAnswer[1];
            }
            else if (r == 2)
            {
                btnAnsweTwo.Content = App.activeQuest.CorrectAnswer;
                btnAnsweTree.Content = App.activeQuest.IncorrectAnswer[1];
                btnAnsweOne.Content = App.activeQuest.IncorrectAnswer[0];
            }
            else
            {
                btnAnsweTree.Content = App.activeQuest.CorrectAnswer;
                btnAnsweTwo.Content = App.activeQuest.IncorrectAnswer[1];
                btnAnsweOne.Content = App.activeQuest.IncorrectAnswer[0];
            }

        }

        private void Players_Load()
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

            //заполнение заливки игроков
            List<Border> borderPlayers = new List<Border>() { borderPlayer1, borderPlayer2, borderPlayer3, borderPlayer4 };
            for (int i = 0; i < borderPlayers.Count; i++)
            {
                if (i == int.Parse(App.activePlayer.IdPlayer))
                    borderPlayers[int.Parse(App.activePlayer.IdPlayer)].Background = Brushes.Gold;
                else
                    borderPlayers[i].Background = new SolidColorBrush(Color.FromRgb(151, 0, 255));
            }
        }

        private void btnAnswe_Click(object sender, RoutedEventArgs e)
        {
            if (btnClik)
            {
                btnClik = false;
                var btn = e.Source as Button;
                if (btn.Content.ToString() == App.activeQuest.CorrectAnswer)
                {
                    btn.BorderBrush = Brushes.Green;
                    App.activeUser.AddPoints(int.Parse(App.activeQuest.Complexity.Reward));
                }
                else if (btn.Content.ToString() != App.activeQuest.CorrectAnswer)
                {
                    btn.BorderBrush = Brushes.Red;
                    App.activeUser.DellPoints(int.Parse(App.activeQuest.Complexity.Reward));
                    List<Button> lstBtn = new List<Button> { btnAnsweOne, btnAnsweTwo, btnAnsweTree };
                    foreach (Button b in lstBtn)
                    {
                        if (b.Content.ToString() == App.activeQuest.CorrectAnswer)
                        {
                            b.BorderBrush = Brushes.Green;
                            break;
                        }
                    }
                }
                btnBack.Width = 200;
                btnNext.Width = 0;
                Players_Load();
            }

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new PageQuestions());

        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            if (btnClik)
            {
                if (nextUser == 4)
                {
                    btnNext.Width = 0;
                }
                else
                {
                    App.activeUser.ActivePlayers(App.activeRound.ChainPlayers);
                    Players_Load();
                }
                nextUser += 1;
            }
        }

        
    }
}
