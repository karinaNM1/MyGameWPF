﻿using System;
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
        public string IdUser;
        public string Role;
        public string Login;
        public string Password;

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
                string filename = "Resources/Json files/Questions.json";
                string jsonstring = File.ReadAllText(filename);
                List<Quest> questions = JsonSerializer.Deserialize<List<Quest>>(jsonstring);
                List<string> idQuests = new List<string>();
                foreach (Quest quest in questions)
                {
                    idQuests.Add(quest.IdQuest);
                }
                if (idQuests.Contains(addquest.IdQuest))
                {
                    MessageBox.Show("Вопрос с таким id уже существует");
                }
                else
                {
                    questions.Add(addquest);
                    jsonstring = JsonSerializer.Serialize(questions);
                    File.WriteAllText(filename, jsonstring);
                    MessageBox.Show("Вопрос успешно добавлен");
                }
            }
        }

        public void EditQuestion(Quest edditquest)
        {
            if (Auth() == true)
            {
                string filename = "Resources/Json files/Questions.json";
                string jsonstring = File.ReadAllText(filename);
                List<Quest> questions = JsonSerializer.Deserialize<List<Quest>>(jsonstring);
                List<string> idQuests = new List<string>();
                int index = 0;
                foreach (Quest quest in questions)
                {
                    idQuests.Add(quest.IdQuest);
                    if (quest.IdQuest == edditquest.IdQuest)
                    {
                        index = questions.IndexOf(quest);
                    }
                }
                questions[index] = new Quest(edditquest.IdQuest, edditquest.Text, edditquest.CorrectAnswer, edditquest.IncorrectAnswer, false, edditquest.Category, edditquest.Complexity);
                jsonstring = JsonSerializer.Serialize(questions);
                File.WriteAllText(filename, jsonstring);
                MessageBox.Show("Вопрос успешно изменен");
            }
        }

        public void DeleteQuestion(Quest deleteitquest)
        {
            if (Auth() == true)
            {
                string filename = "Resources/Json files/Questions.json";
                string jsonstring = File.ReadAllText(filename);
                List<Quest> questions = JsonSerializer.Deserialize<List<Quest>>(jsonstring);
                List<string> idQuests = new List<string>();
                int index = 0;
                foreach (Quest quest in questions)
                {
                    idQuests.Add(quest.IdQuest);
                    if (quest.IdQuest == deleteitquest.IdQuest)
                    {
                        index = questions.IndexOf(quest);
                    }
                }
                questions.Remove(questions[index]);
                jsonstring = JsonSerializer.Serialize(questions);
                File.WriteAllText(filename, jsonstring);
                MessageBox.Show("Вопрос успешно удален");
            }
        }

        public void AddPlayer(Player addplayer)
        {
            if (Auth() == false)
            {
                string filename = "Resources/Json files/Players.json";
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
                string filename = "Resources/Json files/Players.json";
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
                string filename = "Resources/Json files/Players.json";
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
                string filename = "Resources/Json files/Rounds.json";
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
                string filename = "Resources/Json files/Quest.json";
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