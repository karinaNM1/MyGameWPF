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
    /// Логика взаимодействия для PageAdminDeleteQuestion.xaml
    /// </summary>
    public partial class PageAdminDeleteQuestion : Page
    {
        public PageAdminDeleteQuestion()
        {
            InitializeComponent();
        }

        private void bDeleteQuest_Click(object sender, RoutedEventArgs e)
        {
            if (cbQuestId.Text != "")
            {
                App.activeUser.DeleteQuestion(cbQuestId.Text);
                MessageBox.Show("Вопрос успешно удален");
            }
            else
            {
                MessageBox.Show("Заполните поле");
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            string filename = "Resources/Json files/Questions.json";
            string jsonstring = File.ReadAllText(filename);
            List<Quest> questions = JsonSerializer.Deserialize<List<Quest>>(jsonstring);
            List<string> strquestsId = new List<string>();
            foreach (Quest quest in questions)
            {
                strquestsId.Add(quest.IdQuest);
            }
            cbQuestId.ItemsSource = strquestsId;
        }
    }
}
