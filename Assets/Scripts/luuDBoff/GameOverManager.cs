using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{

    public HighscoreManager highscoreManager; // Kéo GameObject HighscoreManager vào đây trong Inspector
    string username = "Player1";// int score = 1000;
    string vukhihiem = "Súng mãn xà"; int atk = 105; int crit = 25; float atkspeed = 0.8f;
    public void OnGameOver()
    {
        highscoreManager.SaveHighscore(username,vukhihiem,atk,crit,atkspeed );
       // highscoreManager.DisplayHighscores(); // Hiển thị bảng xếp hạng trong UI
    }




    //public HighscoreManager highscoreManager;
    //string username ="tuyen"; int score = 1000;

    //public void OnGameOver()
    //{
    //    highscoreManager.SaveHighscore(username, score);
    //    highscoreManager.DisplayHighscores();
    //}
}
    
