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
using MyGame.Classes;

namespace MyGame
{
    /// <summary>
    /// Логика взаимодействия для PageChangeComplexity.xaml
    /// </summary>
    public partial class PageChangeComplexity : Page
    {
        public PageChangeComplexity()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            string projectPath = AppDomain.CurrentDomain.BaseDirectory;
            projectPath = projectPath.Substring(0, projectPath.Length - 10);
            string filename = projectPath+ "Resources/Json files/QuestComplexities.json";
            string jsonstring = File.ReadAllText(filename);
            List<QuestComplexity> complexities = JsonSerializer.Deserialize<List<QuestComplexity>>(jsonstring);
            dataQuestComplexity.ItemsSource = complexities;

        }

        private void btmAddQuest_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new PageAddComplexity());
        }

        private void btmEditQuest_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new PageEditComplexity());
        }

        private void btmDeleteQuest_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new PageDeleteComplexity());
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new PageAdmin());
        }
    }
}
