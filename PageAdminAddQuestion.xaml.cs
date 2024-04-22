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
    /// Логика взаимодействия для PageAdminAddQuestion.xaml
    /// </summary>
    public partial class PageAdminAddQuestion : Page
    {
        public PageAdminAddQuestion()
        {
            InitializeComponent();
            projectPath = projectPath.Substring(0, projectPath.Length - 10);
        }
        string projectPath = AppDomain.CurrentDomain.BaseDirectory;
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            
            string filename = projectPath + "Resources/Json files/QuestCategories.json";
            string jsonstring = File.ReadAllText(filename);
            List<QuestCategory> categories = JsonSerializer.Deserialize<List<QuestCategory>>(jsonstring);
            filename = projectPath + "Resources/Json files/QuestComplexities.json";
            jsonstring = File.ReadAllText(filename);
            List<QuestComplexity> complexities = JsonSerializer.Deserialize<List<QuestComplexity>>(jsonstring);
            List<string> strcomplexities = new List<string>();
            List<string> strcategories = new List<string>();
            foreach (QuestComplexity complexity in complexities)
            {
                strcomplexities.Add(complexity.Tier);
            }
            foreach (QuestCategory category in categories)
            {
                strcategories.Add(category.Theme);
            }
            cbQuestCategory.ItemsSource = strcategories;
            cbQuestComplexity.ItemsSource = strcomplexities;
        }
        private void bAddQuest_Click(object sender, RoutedEventArgs e)
        {
            if (tbQuestText.Text != "" && cbQuestCategory.Text != "" && ((cbQuestComplexity.Text == "1" && tbQuestCorrectAnswer.Text != "" && tbQuestIncorrectAnswer1.Text != "") || (cbQuestComplexity.Text == "2" && tbQuestCorrectAnswer.Text != "" && tbQuestIncorrectAnswer1.Text != "" && tbQuestIncorrectAnswer2.Text != "") || (cbQuestComplexity.Text == "3" && tbQuestCorrectAnswer.Text != "" && tbQuestIncorrectAnswer1.Text != "" && tbQuestIncorrectAnswer2.Text != "" && tbQuestIncorrectAnswer3.Text != "") || cbQuestComplexity.Text != ""))
            {
                string filename = projectPath +  "Resources/Json files/Questions.json";
                string jsonstring = File.ReadAllText(filename);
                List<Quest> questions = JsonSerializer.Deserialize<List<Quest>>(jsonstring);
                filename = projectPath +  "Resources/Json files/QuestCategories.json";
                jsonstring = File.ReadAllText(filename);
                List<QuestCategory> categories = JsonSerializer.Deserialize<List<QuestCategory>>(jsonstring);
                filename = projectPath + "Resources/Json files/QuestComplexities.json";
                jsonstring = File.ReadAllText(filename);
                List<QuestComplexity> complexities = JsonSerializer.Deserialize<List<QuestComplexity>>(jsonstring);
                List<string> questTexts = new List<string>();
                foreach (Quest quest in questions)
                {
                    questTexts.Add(quest.Text);
                }
                if (questTexts.Contains(tbQuestText.Text))
                {
                    MessageBox.Show("Такой вопрос уже существует");
                }
                else
                {
                    string idNewQuest = questions.Count.ToString();
                    List<string> incorrectAnswers = new List<string>();
                    incorrectAnswers.Add(tbQuestIncorrectAnswer1.Text);
                    incorrectAnswers.Add(tbQuestIncorrectAnswer2.Text);
                    incorrectAnswers.Add(tbQuestIncorrectAnswer3.Text);
                    QuestCategory category = categories[0];
                    foreach (QuestCategory questCategory in categories)
                    {
                        if (questCategory.Theme == cbQuestCategory.Text)
                        {
                            category = questCategory;
                            break;
                        }
                    }
                    QuestComplexity complexity = complexities[0];
                    foreach (QuestComplexity questComplexity in complexities)
                    {
                        if (questComplexity.Tier == cbQuestComplexity.Text)
                        {
                            complexity = questComplexity;
                            break;
                        }
                    }
                    Quest newQuest = new Quest(idNewQuest, tbQuestText.Text, tbQuestCorrectAnswer.Text, incorrectAnswers, false, category, complexity);
                    App.activeUser.AddQuestion(newQuest);
                    MessageBox.Show("Вопрос успешно добавлен");
                }
            }
            else
            {
                MessageBox.Show("Заполните все поля");
            }
        }

        private void cbQuestComplexity_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbQuestComplexity.Text == "1")
            {
                tblAnswer.Visibility = Visibility.Visible;
                tbQuestCorrectAnswer.Visibility = Visibility.Visible;
                tblAnswers.Visibility = Visibility.Visible;
                tbQuestIncorrectAnswer1.Visibility = Visibility.Visible;
                tbQuestIncorrectAnswer2.Visibility = Visibility.Hidden;
                tbQuestIncorrectAnswer3.Visibility = Visibility.Hidden;
            }
            else if (cbQuestComplexity.Text == "2")
            {
                tblAnswer.Visibility = Visibility.Visible;
                tbQuestCorrectAnswer.Visibility = Visibility.Visible;
                tblAnswers.Visibility = Visibility.Visible;
                tbQuestIncorrectAnswer1.Visibility = Visibility.Visible;
                tbQuestIncorrectAnswer2.Visibility = Visibility.Visible;
                tbQuestIncorrectAnswer3.Visibility = Visibility.Hidden;
            }
            else if (cbQuestComplexity.Text == "3")
            {
                tblAnswer.Visibility = Visibility.Visible;
                tbQuestCorrectAnswer.Visibility = Visibility.Visible;
                tblAnswers.Visibility = Visibility.Visible;
                tbQuestIncorrectAnswer1.Visibility = Visibility.Visible;
                tbQuestIncorrectAnswer2.Visibility = Visibility.Visible;
                tbQuestIncorrectAnswer3.Visibility = Visibility.Visible;
            }
            else
            {
                tblAnswer.Visibility = Visibility.Hidden;
                tbQuestCorrectAnswer.Visibility = Visibility.Hidden;
                tblAnswers.Visibility = Visibility.Hidden;
                tbQuestIncorrectAnswer1.Visibility = Visibility.Hidden;
                tbQuestIncorrectAnswer2.Visibility = Visibility.Hidden;
                tbQuestIncorrectAnswer3.Visibility = Visibility.Hidden;
            }
        }
    }
}
