using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXPplayer : MonoBehaviour
{
    public HealthBar_PS EXPBar;
    int currentExp = 0;
    int currentLevel = 1;
    int requirExp = 30;
    public GameObject levelUpPanel;
    public void UpdateExperience(int addExp)
    {
        currentExp += addExp;
        if (currentExp >= requirExp)
        {
            currentLevel++;
            currentExp = currentExp - requirExp;
            requirExp = (int)(requirExp * 2);
            OpenLevelUpPanel();
        }
        EXPBar.UpdateBar(currentExp, requirExp, "level: " + currentLevel.ToString());
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
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            UpdateExperience(currentLevel);
        }
    }

}
