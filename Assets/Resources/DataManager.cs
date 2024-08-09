using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;




public class PlayerScore
{
    public string username;  // Tên người chơi
    public int score;  // Điểm số
    public int rank;  // Vị trí xếp hạng

    public PlayerScore(string username,int score,int rank)
    {
        this.username = username;
        this.score = score;
        this.rank = rank;
    }
}
public class DataManager : MonoBehaviour
{

    private string filePath;
    private void Start()
    {
        filePath = Application.persistentDataPath + "/leaderboard.txt";
    }
    public void SaveLeaderboard(List<PlayerScore> leaderboard)
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (PlayerScore player in leaderboard)
            {
                writer.WriteLine(player.username);
                writer.WriteLine(player.score);
                writer.WriteLine(player.rank);
            }
        }
        Debug.Log("Bảng xếp hạng đã được lưu.");
    }
    public List<PlayerScore> LoadLeaderboard()
    {
        List<PlayerScore> leaderboard = new List<PlayerScore>();

        if (File.Exists(filePath))
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    string username = reader.ReadLine();
                    int score = int.Parse(reader.ReadLine());
                    int rank = int.Parse(reader.ReadLine());
                    leaderboard.Add(new PlayerScore(username, score, rank));
                }
            }
            Debug.Log("Bảng xếp hạng đã được tải.");
        }
        else
        {
            Debug.LogWarning("Không tìm thấy file dữ liệu.");
        }

        return leaderboard;
    }
    }
