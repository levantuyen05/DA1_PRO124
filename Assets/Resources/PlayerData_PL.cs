using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Character", menuName = "Character/CharacterData")]
public class PlayerData_PL : ScriptableObject
{
    public int id;
    public string playerName;
    public int currentHealth;
    public int maxHealth;

    public PlayerData GetDataInstance()
    {
        return new PlayerData()
        {
            id = this.id,
            playerName = this.playerName,
            maxHealth = this.maxHealth,
            currentHealth = this.currentHealth,
        };
    }
}
