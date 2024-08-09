using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class playerTest : MonoBehaviour
{
    public CharacterDatabase characterDB;

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
