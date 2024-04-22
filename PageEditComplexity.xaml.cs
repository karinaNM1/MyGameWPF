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
    /// Логика взаимодействия для PageEditComplexity.xaml
    /// </summary>
    public partial class PageEditComplexity : Page
    {
        public PageEditComplexity()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            string filename = "Resources/Json files/QuestComplexities.json";
            string jsonstring = File.ReadAllText(filename);
            List<QuestComplexity> complexities = JsonSerializer.Deserialize<List<QuestComplexity>>(jsonstring);
            List<string> strcomoplexity = new List<string>();
            foreach (QuestComplexity complexity in complexities)
            {
                strcomoplexity.Add(complexity.IdQuestComplexity);
            }
            cbComplexityId.ItemsSource = strcomoplexity;
        }

        private void bEditComplexity_Click(object sender, RoutedEventArgs e)
        {
            if (tbTier.Text != "" && tbReward.Text != "" && cbComplexityId.Text != "")
            {
                bool tierCheck = decimal.TryParse(tbTier.Text, out var tier);
                bool rewardCheck = int.TryParse(tbReward.Text, out var reward);
                if (tierCheck == true && rewardCheck == true && tier > 0 && reward > 0)
                {
                    string filename = "Resources/Json files/QuestComplexities.json";
                    string jsonstring = File.ReadAllText(filename);
                    List<QuestComplexity> complexities = JsonSerializer.Deserialize<List<QuestComplexity>>(jsonstring);
                    List<string> complexityTiers = new List<string>();
                    foreach (QuestComplexity complexity in complexities)
                    {
                        complexityTiers.Add(complexity.Tier);
                    }
                    if (complexityTiers.Contains(tbTier.Text))
                    {
                        MessageBox.Show("Сложность уже существует");
                    }
                    else
                    {
                        QuestComplexity questComplexity = new QuestComplexity(cbComplexityId.Text, tbTier.Text, tbReward.Text);
                        App.activeUser.EditComplexity(questComplexity);
                        MessageBox.Show("Сложность успешно изменена");
                    }
                }
                else
                {
                    MessageBox.Show("Введите корректные данные");
                }
            }
            else
            {
                MessageBox.Show("Заполните поля");
            }
        }
    }
}
