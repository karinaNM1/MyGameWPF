using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using System.Windows;
using static System.Net.Mime.MediaTypeNames;
using MyGame.Classes;
using MyGame;

namespace MyGame.Classes
{
    public class User
    {
        public string IdUser { get; set; }
        public string Role { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public User(string idUser, string role, string login, string password)
        {
            IdUser = idUser;
            Role = role;
            Login = login;
            Password = password;
        }

        public void AddQuestion(Quest addquest)
        {
            string projectPath = AppDomain.CurrentDomain.BaseDirectory;
            projectPath = projectPath.Substring(0, projectPath.Length - 10);
            string filename = projectPath + "Resources/Json files/Questions.json";
            string jsonstring = File.ReadAllText(filename);
            List<Quest> questions = JsonSerializer.Deserialize<List<Quest>>(jsonstring);
            questions.Add(addquest);
            jsonstring = JsonSerializer.Serialize(questions);
            File.WriteAllText(filename, jsonstring);
        }

        public void EditQuestion(Quest edditquest)
        {
            string projectPath = AppDomain.CurrentDomain.BaseDirectory;
            projectPath = projectPath.Substring(0, projectPath.Length - 10);
            string filename = projectPath + "Resources/Json files/Questions.json";
            string jsonstring = File.ReadAllText(filename);
            List<Quest> questions = JsonSerializer.Deserialize<List<Quest>>(jsonstring);
            int id = 0;
            foreach (Quest quest in questions)
            {
                if (quest.IdQuest == edditquest.IdQuest)
                {
                    id = questions.IndexOf(quest);
                    break;
                }
            }
            questions[id] = edditquest;
            jsonstring = JsonSerializer.Serialize(questions);
            File.WriteAllText(filename, jsonstring);
        }

        public void DeleteQuestion(string iddelquest)
        {
            string projectPath = AppDomain.CurrentDomain.BaseDirectory;
            projectPath = projectPath.Substring(0, projectPath.Length - 10);
            string filename = projectPath + "Resources/Json files/Questions.json";
            string jsonstring = File.ReadAllText(filename);
            List<Quest> questions = JsonSerializer.Deserialize<List<Quest>>(jsonstring);
            int id = 0;
            foreach (Quest quest in questions)
            {
                if (quest.IdQuest == iddelquest)
                {
                    id = questions.IndexOf(quest);
                }
            }
            questions.Remove(questions[id]);
            jsonstring = JsonSerializer.Serialize(questions);
            File.WriteAllText(filename, jsonstring);
        }

        public void AddCategory(QuestCategory addcategory)
        {
            string projectPath = AppDomain.CurrentDomain.BaseDirectory;
            projectPath = projectPath.Substring(0, projectPath.Length - 10);
            string filename = projectPath + "Resources/Json files/QuestCategories.json";
            string jsonstring = File.ReadAllText(filename);
            List<QuestCategory> categories = JsonSerializer.Deserialize<List<QuestCategory>>(jsonstring);
            categories.Add(addcategory);
            jsonstring = JsonSerializer.Serialize(categories);
            File.WriteAllText(filename, jsonstring);
        }

        public void EditCategory(QuestCategory editcategory)
        {
            string projectPath = AppDomain.CurrentDomain.BaseDirectory;
            projectPath = projectPath.Substring(0, projectPath.Length - 10);
            string filename = projectPath + "Resources/Json files/QuestCategories.json";
            string jsonstring = File.ReadAllText(filename);
            List<QuestCategory> categories = JsonSerializer.Deserialize<List<QuestCategory>>(jsonstring);
            int id = 0;
            foreach (QuestCategory category in categories)
            {
                if (category.IdQuestCategory == editcategory.IdQuestCategory)
                {
                    id = categories.IndexOf(category);
                    break;
                }
            }
            categories[id] = editcategory;
            jsonstring = JsonSerializer.Serialize(categories);
            File.WriteAllText(filename, jsonstring);
        }

        public void DeleteCategory(string iddelcategory)
        {
            string projectPath = AppDomain.CurrentDomain.BaseDirectory;
            projectPath = projectPath.Substring(0, projectPath.Length - 10);
            string filename = projectPath + "Resources/Json files/QuestCategories.json";
            string jsonstring = File.ReadAllText(filename);
            List<QuestCategory> categories = JsonSerializer.Deserialize<List<QuestCategory>>(jsonstring);
            int id = 0;
            foreach (QuestCategory category in categories)
            {
                if (category.IdQuestCategory == iddelcategory)
                {
                    id = categories.IndexOf(category);
                }
            }
            categories.Remove(categories[id]);
            jsonstring = JsonSerializer.Serialize(categories);
            File.WriteAllText(filename, jsonstring);
        }

        public void AddComplexity(QuestComplexity addcomplexity)
        {
            string projectPath = AppDomain.CurrentDomain.BaseDirectory;
            projectPath = projectPath.Substring(0, projectPath.Length - 10);
            string filename = projectPath + "Resources/Json files/QuestComplexities.json";
            string jsonstring = File.ReadAllText(filename);
            List<QuestComplexity> complexities = JsonSerializer.Deserialize<List<QuestComplexity>>(jsonstring);
            complexities.Add(addcomplexity);
            jsonstring = JsonSerializer.Serialize(complexities);
            File.WriteAllText(filename, jsonstring);
        }

        public void EditComplexity(QuestComplexity editcomplexity)
        {
            string projectPath = AppDomain.CurrentDomain.BaseDirectory;
            projectPath = projectPath.Substring(0, projectPath.Length - 10);
            string filename = projectPath + "Resources/Json files/QuestComplexities.json";
            string jsonstring = File.ReadAllText(filename);
            List<QuestComplexity> complexities = JsonSerializer.Deserialize<List<QuestComplexity>>(jsonstring);
            int id = 0;
            foreach (QuestComplexity complexity in complexities)
            {
                if (complexity.IdQuestComplexity == editcomplexity.IdQuestComplexity)
                {
                    id = complexities.IndexOf(complexity);
                    break;
                }
            }
            complexities[id] = editcomplexity;
            jsonstring = JsonSerializer.Serialize(complexities);
            File.WriteAllText(filename, jsonstring);
        }

        public void DeleteComplexity(string iddelcomplexity)
        {
            string projectPath = AppDomain.CurrentDomain.BaseDirectory;
            projectPath = projectPath.Substring(0, projectPath.Length - 10);
            string filename = projectPath + "Resources/Json files/QuestComplexities.json";
            string jsonstring = File.ReadAllText(filename);
            List<QuestComplexity> complexities = JsonSerializer.Deserialize<List<QuestComplexity>>(jsonstring);
            int id = 0;
            foreach (QuestComplexity complexity in complexities)
            {
                if (complexity.IdQuestComplexity == iddelcomplexity)
                {
                    id = complexities.IndexOf(complexity);
                }
            }
            complexities.Remove(complexities[id]);
            jsonstring = JsonSerializer.Serialize(complexities);
            File.WriteAllText(filename, jsonstring);
        }

        //public void AddPlayer(Player addplayer)
        //{
        //    string projectPath = AppDomain.CurrentDomain.BaseDirectory;
        //    projectPath = projectPath.Substring(0, projectPath.Length - 10);
        //    string filename = projectPath + "Resources/Json files/Players.json";
        //    string jsonstring = File.ReadAllText(filename);
        //    List<Player> players = JsonSerializer.Deserialize<List<Player>>(jsonstring);
        //    List<string> idPlayers = new List<string>();
        //    foreach (Player player in players)
        //    {
        //        idPlayers.Add(player.IdPlayer);
        //    }
        //    if (idPlayers.Contains(addplayer.IdPlayer))
        //    {
        //        MessageBox.Show("Игрок с таким id уже существует");
        //    }
        //    else
        //    {
        //        players.Add(addplayer);
        //        jsonstring = JsonSerializer.Serialize(players);
        //        File.WriteAllText(filename, jsonstring);
        //        MessageBox.Show("Игрок успешно добавлен");
        //    }
        //}
        
        public void AddPlayers(List<string> players)
        {
            DeletePlayers();

            List<Player> addPlayer = new List<Player>();
            int id = 0;
            foreach (string pl in players)
            {
                addPlayer.Add(new Player(id.ToString(), pl, 0));
                id++;
            }

            string projectPath = AppDomain.CurrentDomain.BaseDirectory;
            projectPath = projectPath.Substring(0, projectPath.Length - 10);
            string filename = Path.Combine(projectPath, "Resources", "Json files", "Players.json");

            try
            {
                // Читаем существующие данные из файла
                string jsonstring = File.ReadAllText(filename);
                List<Player> existingPlayers = JsonSerializer.Deserialize<List<Player>>(jsonstring);

                // Объединяем существующих игроков с новыми
                existingPlayers.AddRange(addPlayer);

                // Записываем обновленные данные в файл
                jsonstring = JsonSerializer.Serialize(existingPlayers);
                File.WriteAllText(filename, jsonstring);
            }
            catch (Exception ex)
            {
                // Обрабатываем ошибки
                MessageBox.Show($"Ошибка при добавлении игроков: {ex.Message}");
            }
        }
        public void ActivePlayers(List<Player> players)
        {
            if (App.activePlayer == null)
                App.activePlayer = players[0];
            else
            {
                int idActivePlayer = int.Parse(App.activePlayer.IdPlayer);
                if (idActivePlayer == 3)
                    App.activePlayer = players[0];
                else
                    App.activePlayer = players[idActivePlayer + 1];
            }
        }
        public void CreateRounds()
        {
            string projectPath = AppDomain.CurrentDomain.BaseDirectory;
            projectPath = projectPath.Substring(0, projectPath.Length - 10);

            string filename = projectPath + "Resources/Json files/QuestCategories.json";
            string jsonstring = File.ReadAllText(filename);
            List<QuestCategory> categories = JsonSerializer.Deserialize<List<QuestCategory>>(jsonstring);

            filename = projectPath + "Resources/Json files/Questions.json";
            jsonstring = File.ReadAllText(filename);
            List<Quest> questions = JsonSerializer.Deserialize<List<Quest>>(jsonstring);

            filename = projectPath + "Resources/Json files/Players.json";
            jsonstring = File.ReadAllText(filename);
            List<Player> players = JsonSerializer.Deserialize<List<Player>>(jsonstring);

            Random rand = new Random();
            Round round1 = new Round("1", new List<Quest>(), new List<QuestCategory>(), players);
            Round round2 = new Round("2", new List<Quest>(), new List<QuestCategory>(), players);

            List<int> rand1 = new List<int>();
            List<int> rand2 = Enumerable.Range(1, 13).ToList();
            while (true)
            {
                int r = rand.Next(1, 13);
                if (!rand1.Contains(r))
                {
                    rand1.Add(r);
                    rand2.Remove(r);
                    if (rand1.Count == 6)
                        break;
                }
            }
            round1.Category = categories.Where(c => rand1.Contains(int.Parse(c.IdQuestCategory))).ToList();
            round2.Category = categories.Where(c => rand2.Contains(int.Parse(c.IdQuestCategory))).ToList();

            round1.Questions = questions.Where(q => rand1.Contains(int.Parse(q.Category.IdQuestCategory))).ToList();
            round2.Questions = questions.Where(q => rand2.Contains(int.Parse(q.Category.IdQuestCategory))).ToList();

            List<Round> rounds = new List<Round>() { round1, round2 };
            App.rounds = rounds;
            App.activeRound = rounds[0];

        }
        //public void EditPlayer(Player editplayer)
        //{
        //    string projectPath = AppDomain.CurrentDomain.BaseDirectory;
        //    projectPath = projectPath.Substring(0, projectPath.Length - 10);
        //    string filename = projectPath + "Resources/Json files/Players.json";
        //    string jsonstring = File.ReadAllText(filename);
        //    List<Player> players = JsonSerializer.Deserialize<List<Player>>(jsonstring);
        //    List<string> idPlayers = new List<string>();
        //    int index = 0;
        //    int points = 0;
        //    foreach (Player player in players)
        //    {
        //        idPlayers.Add(player.IdPlayer);
        //        if (player.IdPlayer == editplayer.IdPlayer)
        //        {
        //            index = players.IndexOf(player);
        //            points = player.Points;
        //        }
        //    }
        //    players[index] = new Player(editplayer.IdPlayer, editplayer.Name, points);
        //    jsonstring = JsonSerializer.Serialize(players);
        //    File.WriteAllText(filename, jsonstring);
        //    MessageBox.Show("Игрок успешно изменен");
        //}

        public void AddPoints(int points)
        {
            App.activeRound.ChainPlayers.FirstOrDefault(p => p.IdPlayer == App.activePlayer.IdPlayer).Points += points;
        }

        public void DellPoints(int points)
        {
            App.activeRound.ChainPlayers.FirstOrDefault(p => p.IdPlayer == App.activePlayer.IdPlayer).Points -= points;
        }

        public void DeletePlayers()
        {
            string projectPath = AppDomain.CurrentDomain.BaseDirectory;
            projectPath = projectPath.Substring(0, projectPath.Length - 10);
            string filename = projectPath + "Resources/Json files/Players.json";
            string jsonstring = File.ReadAllText(filename);
            List<Player> players = JsonSerializer.Deserialize<List<Player>>(jsonstring);
            players.Clear();
            jsonstring = JsonSerializer.Serialize(players);
            File.WriteAllText(filename, jsonstring);
        }

        //public void StartGame(string idRound)
        //{
        //    string projectPath = AppDomain.CurrentDomain.BaseDirectory;
        //    projectPath = projectPath.Substring(0, projectPath.Length - 10);
        //    string filename = projectPath + "Resources/Json files/Rounds.json";
        //    string jsonstring = File.ReadAllText(filename);
        //    List<Round> rounds = JsonSerializer.Deserialize<List<Round>>(jsonstring);
        //    foreach (Round round in rounds)
        //    {
        //        if (round.IdRound == idRound)
        //        {
        //            App.activeRound = round;
        //            break;
        //        }
        //    }
        //    // Открытие окна с вопросами
        //}
        //public void SelectQuest(string idQuest)
        //{
        //    string projectPath = AppDomain.CurrentDomain.BaseDirectory;
        //    projectPath = projectPath.Substring(0, projectPath.Length - 10);
        //    string filename = projectPath + "Resources/Json files/Quest.json";
        //    string jsonstring = File.ReadAllText(filename);
        //    List<Quest> questions = JsonSerializer.Deserialize<List<Quest>>(jsonstring);
        //    foreach (Quest question in questions)
        //    {
        //        if (question.IdQuest == idQuest)
        //        {
        //            App.activeQuest = question;
        //            break;
        //        }
        //    }
        //    // Открытие окна с вопросом
        //}

        public void SelectQuest(Quest selectedQuest)
        {
            App.activeQuest = selectedQuest;

            switch (App.activeQuest.Complexity.IdQuestComplexity)
            {
                case "1":
                    Manager.MainFrame.Navigate(new PageFirstDifficulty());
                    break;
                case "2":
                    Manager.MainFrame.Navigate(new PageSecondDifficulty());
                    break;
                case "3":
                    Manager.MainFrame.Navigate(new PageThirdDifficulty());
                    break;
                case "4":
                    Manager.MainFrame.Navigate(new PageFourthDifficulty());
                    break;
                case "5":
                    Manager.MainFrame.Navigate(new PageFifthDifficulty());
                    break;
            }
            
        }

       
    }
}

