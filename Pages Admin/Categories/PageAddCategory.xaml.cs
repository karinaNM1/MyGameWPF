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
    /// Логика взаимодействия для PageAddCategory.xaml
    /// </summary>
    public partial class PageAddCategory : Page
    {
        public PageAddCategory()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new PageAdmin());
        }

        private void addCategory_Click(object sender, RoutedEventArgs e)
        {
            if (tbCategory.Text != "")
            {
                string projectPath = AppDomain.CurrentDomain.BaseDirectory;
                projectPath = projectPath.Substring(0, projectPath.Length - 10);
                string filename = projectPath + "Resources/Json files/QuestCategories.json";
                string jsonstring = File.ReadAllText(filename);
                List<QuestCategory> categories = JsonSerializer.Deserialize<List<QuestCategory>>(jsonstring);
                List<string> categoryNames = new List<string>();
                foreach (QuestCategory category in categories)
                {
                    categoryNames.Add(category.Theme);
                }
                if (categoryNames.Contains(tbCategory.Text))
                {
                    MessageBox.Show("Категория уже существует");
                }
                else
                {
                    string idNewCategory = (categories.Count + 1).ToString();
                    QuestCategory questCategory = new QuestCategory(idNewCategory, tbCategory.Text);
                    App.activeUser.AddCategory(questCategory);
                    MessageBox.Show("Категория успешно добавлена");
                }
            }
            else
            {
                MessageBox.Show("Заполните поле");
            }
        }
    }
}
