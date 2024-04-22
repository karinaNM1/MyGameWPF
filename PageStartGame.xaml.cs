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
    /// Логика взаимодействия для PageStartGame.xaml
    /// </summary>
    public partial class PageStartGame : Page
    {
        public PageStartGame()
        {
            InitializeComponent();
        }

        private void btnStartGame_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new PageQuestions());
        }

        private void btnAuto_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new PageAutoLeader());
        }
    }
}
