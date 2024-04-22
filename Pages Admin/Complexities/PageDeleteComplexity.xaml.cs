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
    /// Логика взаимодействия для PageDeleteComplexity.xaml
    /// </summary>
    public partial class PageDeleteComplexity : Page
    {
        public PageDeleteComplexity()
        {
            InitializeComponent();
        }

        private void bDeleteComplexity_Click(object sender, RoutedEventArgs e)
        {
            if (cbComplexityId.Text != "")
            {
                App.activeUser.DeleteComplexity(cbComplexityId.Text);
                MessageBox.Show("Сложность успешно удалена");
            }
            else
            {
                MessageBox.Show("Заполните поле");
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            string projectPath = AppDomain.CurrentDomain.BaseDirectory;
            projectPath = projectPath.Substring(0, projectPath.Length - 10);
            string filename = projectPath + "Resources/Json files/QuestComplexities.json";
            string jsonstring = File.ReadAllText(filename);
            List<QuestComplexity> complexities = JsonSerializer.Deserialize<List<QuestComplexity>>(jsonstring);
            List<string> strcomoplexity = new List<string>();
            foreach (QuestComplexity complexity in complexities)
            {
                strcomoplexity.Add(complexity.IdQuestComplexity);
            }
            cbComplexityId.ItemsSource = strcomoplexity;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new PageAdmin());
        }
    }
}
