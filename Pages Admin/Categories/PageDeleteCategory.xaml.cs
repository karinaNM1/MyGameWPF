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
    /// Логика взаимодействия для PageDeleteCategory.xaml
    /// </summary>
    public partial class PageDeleteCategory : Page
    {
        public PageDeleteCategory()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new PageAdmin());
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

        private void deleteCategory_Click(object sender, RoutedEventArgs e)
        {
            if (cbCategoryId.Text != "")
            {
                App.activeUser.DeleteCategory(cbCategoryId.Text);
                MessageBox.Show("Категория успешно удалена");
            }
            else
            {
                MessageBox.Show("Заполните поле");
            }
        }
    }
}
