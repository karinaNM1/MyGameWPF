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
    /// Логика взаимодействия для UCQuest.xaml
    /// </summary>
    public partial class UCQuest : UserControl
    {
        Quest Quest;
        public UCQuest(Quest quest)
        {
            InitializeComponent();
            Quest = quest;
            DataContext = quest;
        }

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = Quest.Used;
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            //MessageBox.Show($"{Quest.Text}");
           

            App.activeUser.SelectQuest(Quest);
            Quest.Used = false;
        }
    }
}
