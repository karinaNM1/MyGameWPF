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
    /// Логика взаимодействия для PageChangeQuestions.xaml
    /// </summary>
    public partial class PageChangeQuestions : Page
    {

        public PageChangeQuestions()
        {
            InitializeComponent();
        }

        public class ListQuest
        {
            Quest Question { get; set; }
            string StringrIncorrectAnswers { get; set; }
            public ListQuest (Quest question, string stringrIncorrectAnswers)
            {
                Question = question;
                StringrIncorrectAnswers = stringrIncorrectAnswers;
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            string projectPath = AppDomain.CurrentDomain.BaseDirectory;
            projectPath = projectPath.Substring(0, projectPath.Length - 10);
            string filename = projectPath + "Resources/Json files/Questions.json";
            string jsonstring = File.ReadAllText(filename);
            List<Quest> questions = JsonSerializer.Deserialize<List<Quest>>(jsonstring);
            List<ListQuest> listQuests = new List<ListQuest>();
            string strIncorrectAnswers = "";
            foreach (Quest quest in questions)
            {
                strIncorrectAnswers = "";
                foreach (string incorrectAnswer in quest.IncorrectAnswer)
                {
                    strIncorrectAnswers = strIncorrectAnswers + incorrectAnswer + "; ";
                }
                btmAddQuest.Content = strIncorrectAnswers;
                ListQuest listQuest = new ListQuest(quest, strIncorrectAnswers);
                listQuests.Add(listQuest);
            }
            dataQuest.ItemsSource = listQuests;
        }

        private void btmAddQuest_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new PageAdminAddQuestion());
        }

        private void btmEditQuest_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new PageAdminEditQuestion());
        }

        private void btmDeleteQuest_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new PageAdminDeleteQuestion());
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new PageAdmin());
        }
    }
}
