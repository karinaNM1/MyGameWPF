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

        public bool Auth()
        {
            if (Role == "Администратор")
                return true;
            else
                return false;
        }

        public void AddQuestion(Quest addquest)
        {
            if (Auth() == true)
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
        }

        public void EditQuestion(Quest edditquest)
        {
            if (Auth() == true)
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
        }

        public void DeleteQuestion(string iddelquest)
        {
            if (Auth() == true)
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
        }

        public void AddCategory(QuestCategory addcategory)
        {
            if (Auth() == true)
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
        }

        public void EditCategory(QuestCategory editcategory)
        {
            if (Auth() == true)
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
        }

        public void DeleteCategory(string iddelcategory)
        {
            if (Auth() == true)
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
        }

        public void AddComplexity(QuestComplexity addcomplexity)
        {
            if (Auth() == true)
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
        }

        public void EditComplexity(QuestComplexity editcomplexity)
        {
            if (Auth() == true)
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
        }

        public void DeleteComplexity(string iddelcomplexity)
        {
            if (Auth() == true)
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
        }

        public void AddPlayer(Player addplayer)
        {
            if (Auth() == false)
            {
                string projectPath = AppDomain.CurrentDomain.BaseDirectory;
                projectPath = projectPath.Substring(0, projectPath.Length - 10);
                string filename = projectPath + "Resources/Json files/Players.json";
                string jsonstring = File.ReadAllText(filename);
                List<Player> players = JsonSerializer.Deserialize<List<Player>>(jsonstring);
                List<string> idPlayers = new List<string>();
                foreach (Player player in players)
                {
                    idPlayers.Add(player.IdPlayer);
                }
                if (idPlayers.Contains(addplayer.IdPlayer))
                {
                    MessageBox.Show("Игрок с таким id уже существует");
                }
                else
                {
                    players.Add(addplayer);
                    jsonstring = JsonSerializer.Serialize(players);
                    File.WriteAllText(filename, jsonstring);
                    MessageBox.Show("Игрок успешно добавлен");
                }
            }
        }
        public void EditPlayer(Player editplayer)
        {
            if (Auth() == false)
            {
                string projectPath = AppDomain.CurrentDomain.BaseDirectory;
                projectPath = projectPath.Substring(0, projectPath.Length - 10);
                string filename = projectPath + "Resources/Json files/Players.json";
                string jsonstring = File.ReadAllText(filename);
                List<Player> players = JsonSerializer.Deserialize<List<Player>>(jsonstring);
                List<string> idPlayers = new List<string>();
                int index = 0;
                int points = 0;
                foreach (Player player in players)
                {
                    idPlayers.Add(player.IdPlayer);
                    if (player.IdPlayer == editplayer.IdPlayer)
                    {
                        index = players.IndexOf(player);
                        points = player.Points;
                    }
                }
                players[index] = new Player(editplayer.IdPlayer, editplayer.Name, points);
                jsonstring = JsonSerializer.Serialize(players);
                File.WriteAllText(filename, jsonstring);
                MessageBox.Show("Игрок успешно изменен");
            }
        }
        public void DeletePlayer(Player deleteplayer)
        {
            if (Auth() == false)
            {
                string projectPath = AppDomain.CurrentDomain.BaseDirectory;
                projectPath = projectPath.Substring(0, projectPath.Length - 10);
                string filename = projectPath + "Resources/Json files/Players.json";
                string jsonstring = File.ReadAllText(filename);
                List<Player> players = JsonSerializer.Deserialize<List<Player>>(jsonstring);
                List<string> idPlayers = new List<string>();
                int index = 0;
                foreach (Player player in players)
                {
                    idPlayers.Add(player.IdPlayer);
                    if (player.IdPlayer == deleteplayer.IdPlayer)
                    {
                        index = players.IndexOf(player);
                    }
                }
                players.Remove(players[index]);
                jsonstring = JsonSerializer.Serialize(players);
                File.WriteAllText(filename, jsonstring);
                MessageBox.Show("Игрок успешно удален");
            }
        }
        public void StartGame(string idRound)
        {
            if (Auth() == false)
            {
                string projectPath = AppDomain.CurrentDomain.BaseDirectory;
                projectPath = projectPath.Substring(0, projectPath.Length - 10);
                string filename = projectPath + "Resources/Json files/Rounds.json";
                string jsonstring = File.ReadAllText(filename);
                List<Round> rounds = JsonSerializer.Deserialize<List<Round>>(jsonstring);
                foreach (Round round in rounds)
                {
                    if (round.IdRound == idRound)
                    {
                        App.activeRound = round;
                        break;
                    }
                }
                // Открытие окна с вопросами
            }
        }
        public void SelectQuest(string idQuest)
        {
            if (Auth() == false)
            {
                string projectPath = AppDomain.CurrentDomain.BaseDirectory;
                projectPath = projectPath.Substring(0, projectPath.Length - 10);
                string filename = projectPath + "Resources/Json files/Quest.json";
                string jsonstring = File.ReadAllText(filename);
                List<Quest> questions = JsonSerializer.Deserialize<List<Quest>>(jsonstring);
                foreach (Quest question in questions)
                {
                    if (question.IdQuest == idQuest)
                    {
                        App.activeQuest = question;
                        break;
                    }
                }
                // Открытие окна с вопросом
            }
        }
    }
}

