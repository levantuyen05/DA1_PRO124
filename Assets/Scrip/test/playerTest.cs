using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class playerTest : MonoBehaviour
{
    public AllPlayerData_PL characterData;

    private PlayerData playerData;


    public int health;
    public string playerName;

    public CharacterDatabase characterDB;

    public SpriteRenderer spriteRenderer;

    private int selectedOption = 0;

    void Start()
    {
        if (characterData != null && characterData.character.Count > 0)
        {
            playerData = characterData.character[0].GetDataInstance();

            health = playerData.currentHealth;
            playerName = playerData.playerName;
            // Ví dụ: truy cập dữ liệu của nhân vật đầu tiên
            Debug.Log("Character Name: " + characterData.character[0].playerName);
            Debug.Log("Character Health: " + characterData.character[0].currentHealth);
        }


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

    private void UpdateCharacter(int selectedOption)
    {
        character Character = characterDB.GetCharacter(selectedOption);
        spriteRenderer.sprite = Character.characterSprite;

    }
    private void load()
    {
        selectedOption = PlayerPrefs.GetInt("selectdOption");
    }
}
