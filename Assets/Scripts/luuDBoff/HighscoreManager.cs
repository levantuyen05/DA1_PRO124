using System;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreManager : MonoBehaviour
{
    private string filePath;
    public TextMeshProUGUI highscoreText; // Tham chiếu đến UI Text để hiển thị bảng xếp hạng

    private List<HighscoreEntry> highscores = new List<HighscoreEntry>();

    void Start()
    {
        filePath = Path.Combine(Application.dataPath, "bangvukhi.txt");
        LoadHighscores();
        //DisplayHighscores();
    }

    // Hàm để lưu điểm số của người chơi kèm theo tên nhân vật và vũ khí
    public void SaveHighscore(string username, string vukhihiem, int atk, int crit,float atkspeed)
    {
        highscores.Add(new HighscoreEntry(username, vukhihiem, atk, crit,atkspeed));
        highscores.Sort((entry1, entry2) => entry2.Vukhihiem.CompareTo(entry1.Vukhihiem)); // Sắp xếp từ cao xuống thấp

        // Ghi lại bảng xếp hạng vào file
        using (StreamWriter writer = new StreamWriter(filePath, false)) // false để ghi đè file
        {
            writer.WriteLine($"{"Username",-15} {"Weapon Name",-15} {"ATK",-15} {"Crit",-15} {"ATKSpeed",-15}"); // In tiêu đề cột
            writer.WriteLine(new string('-', 85)); // In dòng gạch ngang
            foreach (var highscore in highscores)
            {
                // In từng hàng dữ liệu, căn chỉnh theo chiều dài của các cột
                writer.WriteLine($"{highscore.Username,-15} {highscore.Vukhihiem,-15} {highscore.Atk,-15} {highscore.Crit,-15} {highscore.AtkSpeed,-15}");
            }
        }

        //DisplayHighscores();
    }

    // Hàm để tải bảng xếp hạng từ file
    private void LoadHighscores()
    {
        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);
            bool isFirstLine = true;
            foreach (string line in lines)
            {
                // Bỏ qua dòng tiêu đề và dòng gạch ngang
                if (isFirstLine || line.StartsWith("-"))
                {
                    isFirstLine = false;
                    continue;
                }

                string[] data = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string username = data[0];
                string vukhihiem = data[1];
                int atk = int.Parse(data[2]);
                int crit = int.Parse(data[3]);
                float atkSpeed = float.Parse(data[4]);
               
                highscores.Add(new HighscoreEntry(username, vukhihiem, atk, crit, atkSpeed));
            }

            highscores.Sort((entry1, entry2) => entry2.Vukhihiem.CompareTo(entry1.Vukhihiem)); // Sắp xếp từ cao xuống thấp
        }
    }

    // Hàm để hiển thị bảng xếp hạng trên UI
    //public void DisplayHighscores()
    //{
    //    highscoreText.text = "Highscores:\n";
    //    highscoreText.text += $"{"Username",-15} {"Score",-10} {"Character",-15} {"Weapon",-15}\n"; // In tiêu đề cột
    //    highscoreText.text += new string('-', 55) + "\n"; // In dòng gạch ngang
    //    foreach (var highscore in highscores)
    //    {
    //        highscoreText.text += $"{highscore.Username,-15} {highscore.Vukhihiem,-10} {highscore.Atk,-15} {highscore.Crit,-15}\n";
    //    }
    //}

    // Lớp để lưu trữ thông tin điểm số
    private class HighscoreEntry
    {
        public string Username { get; }
        public string Vukhihiem { get; }
        public int Atk { get; }
        public int Crit { get; }
        public float AtkSpeed { get; }

        public HighscoreEntry(string username, string vukhihiem, int atk, int crit, float atkSpeed)
        {
            Username = username;
            Vukhihiem = vukhihiem;
            Atk = atk;
            Crit = crit;
            AtkSpeed = atkSpeed;
        }
    }
}
