using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class Leaderboard : MonoBehaviour
{
    public TextMeshProUGUI UserNamePrefab;
    public TextMeshProUGUI TopPrefab;
    public TextMeshProUGUI HighScorePrefab;
    public TextMeshProUGUI LevelPrefab;
    public Transform content;

    private int currentScore = 0;
    private string currentUserName = "";
    private int numPlayersToShow = 10;
    public static Leaderboard Instance { get; private set; }

    private List<PlayerData> playerDataList = new List<PlayerData>();

    [System.Serializable]
    public struct PlayerData
    {
        public string UserName;
        public int HighScore;
        public int Level;
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Giữ GameObject này qua các scene
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        currentUserName = PlayerPrefs.GetString("UserName", "");
        LoadAndDisplayLeaderboard();
    }

    public void UpdateScore(int pointsToAdd)
    {
        currentScore += pointsToAdd;

        // Tìm và cập nhật điểm nếu người chơi đã có trong danh sách
        PlayerData existingPlayer = playerDataList.Find(player => player.UserName == currentUserName);
        if (existingPlayer.UserName != null)
        {
            existingPlayer.HighScore = currentScore;
        }
        else
        {
            // Thêm người chơi mới vào danh sách
            playerDataList.Add(new PlayerData { UserName = currentUserName, HighScore = currentScore, Level = 1 }); // Level mặc định là 1
        }
    }

    public void SetUserName(string userName)
    {
        currentUserName = userName;
        PlayerPrefs.SetString("UserName", currentUserName);
    }

    public void GameOver()
    {
        SaveLeaderboardData();
        LoadAndDisplayLeaderboard();
    }

    void SaveLeaderboardData()
    {
        // Sắp xếp theo điểm giảm dần trước khi lưu
        playerDataList = playerDataList.OrderByDescending(player => player.HighScore).ToList();

        for (int i = 0; i < playerDataList.Count && i < numPlayersToShow; i++)
        {
            PlayerPrefs.SetString("UserName" + i, playerDataList[i].UserName);
            PlayerPrefs.SetInt("HighScore" + i, playerDataList[i].HighScore);
            PlayerPrefs.SetInt("Level" + i, playerDataList[i].Level);
        }
    }

    void LoadAndDisplayLeaderboard()
    {
        playerDataList.Clear();

        for (int i = 0; i < numPlayersToShow; i++)
        {
            string userNameKey = "UserName" + i;
            string highScoreKey = "HighScore" + i;
            string levelKey = "Level" + i;

            if (PlayerPrefs.HasKey(userNameKey))
            {
                playerDataList.Add(new PlayerData
                {
                    UserName = PlayerPrefs.GetString(userNameKey),
                    HighScore = PlayerPrefs.GetInt(highScoreKey),
                    Level = PlayerPrefs.GetInt(levelKey)
                });
            }
        }

        // Sắp xếp lại theo điểm giảm dần (trong trường hợp dữ liệu từ PlayerPrefs không đúng thứ tự)
        playerDataList = playerDataList.OrderByDescending(player => player.HighScore).ToList();

        foreach (Transform child in content)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < playerDataList.Count && i < numPlayersToShow; i++)
        {
            TextMeshProUGUI TopText = Instantiate(TopPrefab, content);
            TextMeshProUGUI UserNameText = Instantiate(UserNamePrefab, content);
            TextMeshProUGUI HighScoreText = Instantiate(HighScorePrefab, content);
            TextMeshProUGUI LevelText = Instantiate(LevelPrefab, content);

            TopText.text = (i + 1).ToString();
            UserNameText.text = playerDataList[i].UserName;
            HighScoreText.text = playerDataList[i].HighScore.ToString();
            LevelText.text = playerDataList[i].Level.ToString();
        }
    }
}
