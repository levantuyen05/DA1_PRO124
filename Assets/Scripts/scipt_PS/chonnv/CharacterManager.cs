using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
    public CharacterDatabase characterDB;
    public TextMeshProUGUI nameText;
    public SpriteRenderer spriteRenderer;


    private int selectedOption = 0;
    void Start()
    {
        if (!PlayerPrefs.HasKey("selectdOption"))
        {
            selectedOption = 0;
        }
        else
        {
            load();
        }
        UpdateCharacter(selectedOption);
    }
    
    public void NextOption()
    {
        selectedOption++;
        if(selectedOption >= characterDB.characterCount)
        {
            selectedOption = 0;
        }
        UpdateCharacter(selectedOption);
        Save();
    }

    public void BackOption()
    {
        selectedOption--;
        if (selectedOption < 0)
        {
            selectedOption = characterDB.characterCount - 1;
        }
        UpdateCharacter(selectedOption);
        Save();
    }
    private void UpdateCharacter(int selectedOption)
    {
        character Character = characterDB.GetCharacter(selectedOption);
        spriteRenderer.sprite = Character.characterSprite;
        
        nameText.text = Character.characterName;
    }
   
    private void load()
    {
        selectedOption = PlayerPrefs.GetInt("selectdOption");
    }

    private void Save()
    {
        PlayerPrefs.SetInt("selectdOption", selectedOption);
    }
    public void ChangeScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }
}
