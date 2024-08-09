using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerExp : MonoBehaviour
{
    public Slider expBar;
    public TextMeshProUGUI LevelText;
    public int currentExp = 0;
    public int expToNextLevel = 100;
    public int currentLevel = 1;

    public GameObject levelUpPanel;

    // Level + exp
    public void GainExp(int amount)
    {
        currentExp += amount;
        expBar.value = (float)currentExp / expToNextLevel; 

        if (currentExp >= expToNextLevel)
        {
            LevelUp();
        }
    }
    public void LevelUp()
    {
        currentLevel++;
        currentExp -= expToNextLevel;
        expToNextLevel += 50;
        LevelText.text = "Level " + currentLevel;
        expBar.value = (float)currentExp / expToNextLevel;
    }

    public void CloseLevelUpPanel()
    {
        CanvasGroup group = levelUpPanel.GetComponent<CanvasGroup>();
        group.alpha = 0;
        group.blocksRaycasts = false;
        group.interactable = false;
        Time.timeScale = 1;
    }

    public void OpenLevelUpPanel()
    {
        CanvasGroup group = levelUpPanel.GetComponent<CanvasGroup>();
        group.alpha = 1;
        group.blocksRaycasts = true;
        group.interactable = true;
        Time.timeScale = 0;
    }
}
