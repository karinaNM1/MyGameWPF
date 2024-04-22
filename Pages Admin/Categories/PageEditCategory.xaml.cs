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
    /// Логика взаимодействия для PageEditCategory.xaml
    /// </summary>
    public partial class PageEditCategory : Page
    {
        public PageEditCategory()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new PageAdmin());
        }
        private void editCategory_Click(object sender, RoutedEventArgs e)
        {
            if (tbCategoryTheme.Text != "" && cbCategoryId.Text != "")
            {
                string filename = "Resources/Json files/QuestCategories.json";
                string jsonstring = File.ReadAllText(filename);
                List<QuestCategory> categories = JsonSerializer.Deserialize<List<QuestCategory>>(jsonstring);
                List<string> categoryNames = new List<string>();
                foreach (QuestCategory category in categories)
                {
                    categoryNames.Add(category.Theme);
                }
                if (categoryNames.Contains(tbCategoryTheme.Text))
                {
                    MessageBox.Show("Категория уже существует");
                }
                else
                {
                    QuestCategory questCategory = new QuestCategory(cbCategoryId.Text, tbCategoryTheme.Text);
                    App.activeUser.EditCategory(questCategory);
                    MessageBox.Show("Категория успешно изменена");
                }
            }
            else
            {
                MessageBox.Show("Заполните поля");
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            string filename = "Resources/Json files/QuestCategories.json";
            string jsonstring = File.ReadAllText(filename);
            List<QuestCategory> categories = JsonSerializer.Deserialize<List<QuestCategory>>(jsonstring);
            List<string> strcategories = new List<string>();
            foreach (QuestCategory category in categories)
            {
                strcategories.Add(category.IdQuestCategory);
            }
            cbCategoryId.ItemsSource = strcategories;
        }
    }
}
