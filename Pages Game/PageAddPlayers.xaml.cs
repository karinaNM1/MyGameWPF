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
    /// Логика взаимодействия для PageAddPlayers.xaml
    /// </summary>
    public partial class PageAddPlayers : Page
    {
        public PageAddPlayers()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            App.activeUser = new User("1", "Ведущии", "login", "password");
            try
            {
                App.activeUser.AddPlayers(new List<string> { tbPl1.Text, tbPl2.Text, tbPl3.Text, tbPl4.Text });
            }
            catch (Exception e1) { MessageBox.Show("Ошибка: " + e1); }
            Manager.MainFrame.Navigate(new PageQuestions());
        }
    }
}
