using MyGame.Classes;
using MyGame.Pages_Game;
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
            if(App.activeRound == null)
                App.activeUser.CreateRounds();
            List<Player> players = App.activeRound.ChainPlayers;

            //заполнение игроков
            List<TextBlock> tbPlayers = new List<TextBlock>() { tbPlayer1 , tbPlayer2 , tbPlayer3 , tbPlayer4};
            for(int i = 0; i < players.Count; i++)
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
            App.activeUser.ActivePlayers(players);
            borderPlayers[int.Parse(App.activePlayer.IdPlayer)].Background = Brushes.Gold;

            //заполнение категории
            lstCat.Items.Clear();
            foreach (QuestCategory cat in App.activeRound.Category)
            {
                lstCat.Items.Add(new UCCategory(cat));
            }

            //заполнение вопросов
            List<ListView> lstQuest = new List<ListView>() { lstComplexity1, lstComplexity2, lstComplexity3, lstComplexity4, lstComplexity5};
            for(int i = 0;i < 5;i++) 
            {
                lstQuest[i].Items.Clear();
                foreach (Quest q in App.activeRound.Questions.Where(q => q.Complexity.Tier == (i+1).ToString() ))
                {
                    lstQuest[i].Items.Add(new UCQuest(q));
                }
            }
            

        }
    }
}
