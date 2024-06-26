﻿using System;
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
    /// Логика взаимодействия для PageAddComplexity.xaml
    /// </summary>
    public partial class PageAddComplexity : Page
    {
        public PageAddComplexity()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new PageAdmin());
        }

        private void bAddComplexity_Click(object sender, RoutedEventArgs e)
        {
            if (tbTier.Text != "" && tbReward.Text != "")
            {
                bool tierCheck = decimal.TryParse(tbTier.Text, out var tier);
                bool rewardCheck = int.TryParse(tbReward.Text, out var reward);
                if (tierCheck == true && rewardCheck == true && tier > 0 && reward > 0)
                {
                    string projectPath = AppDomain.CurrentDomain.BaseDirectory;
                    projectPath = projectPath.Substring(0, projectPath.Length - 10);
                    string filename = projectPath + "Resources/Json files/QuestComplexities.json";
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
                        string idNewComplexity = (complexities.Count + 1).ToString();
                        QuestComplexity questComplexity = new QuestComplexity(idNewComplexity, tbTier.Text, tbReward.Text);
                        App.activeUser.AddComplexity(questComplexity);
                        MessageBox.Show("Сложность успешно добавлена");
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
