using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

[CreateAssetMenu]
public class CharacterDatabase : ScriptableObject
    
{
    public character[] characters;
    public int characterCount
    {
        get
        {
           return  characters.Length;
        }

    }

    public character GetCharacter(int index)
    {
        return characters[index];
    }
}
