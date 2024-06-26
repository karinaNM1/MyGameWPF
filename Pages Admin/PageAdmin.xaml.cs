﻿using MyGame.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace MyGame
{
    /// <summary>
    /// Логика взаимодействия для PageAdmin.xaml
    /// </summary>
    public partial class PageAdmin : Page
    {
        public PageAdmin()
        {
            InitializeComponent();
        }

        private void btnQuestion_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new PageChangeQuestions());
        }

        private void btnCategory_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new PageChangeCategory());
        }

        private void btnComplexity_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new PageChangeComplexity());
        }
    }
}
