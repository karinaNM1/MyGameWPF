using MyGame.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Логика взаимодействия для PageAutoLeader.xaml
    /// </summary>
    public partial class PageAutoLeader : Page
    {
        
        public PageAutoLeader()
        {
            InitializeComponent();
        }

        private void btnSigIn_Click(object sender, RoutedEventArgs e)
        {
            if (tbLogin.Text != "" && tbPassword.Text != "")
            {
                string projectPath = AppDomain.CurrentDomain.BaseDirectory;
                projectPath = projectPath.Substring(0, projectPath.Length - 10);
                string filename = projectPath + "Resources/Json files/Users.json";
                string jsonstring = File.ReadAllText(filename);
                List<User> users = JsonSerializer.Deserialize<List<User>>(jsonstring);
                foreach (User user in users)
                {
                    if (user.Login == tbLogin.Text && user.Password == tbPassword.Text)
                    {
                        App.activeUser = user;
                        Manager.MainFrame.Navigate(new PageAdmin());
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("Заполните все поля");
            }
        }
    }
}
