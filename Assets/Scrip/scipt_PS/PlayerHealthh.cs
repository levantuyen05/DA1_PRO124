using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealthh : MonoBehaviour
{

    public AllPlayerData_PL characterData;

    private PlayerData playerData;
    public int health;
    


    //[SerializeField] private int maxHealth;
    int currentHealth;
    public HealthBar_PS healthbar;
    public UnityEvent OnDeath;

    private void OnEnable()
    {
        OnDeath.AddListener(Death);
    }
    private void OnDisable()
    {
        OnDeath.RemoveListener(Death);
    }
    private void Start()
    {
        if (characterData != null && characterData.character.Count > 0)
        {
            playerData = characterData.character[1].GetDataInstance();

            health = playerData.maxHealth;
            currentHealth = playerData.currentHealth;
            
            // Ví dụ: truy cập dữ liệu của nhân vật đầu tiên
            
            Debug.Log("Character Health: " + characterData.character[1].currentHealth);
        }


        //currentHealth = maxHealth;
        healthbar.UpdateBar(currentHealth, health);  //maxHealth);
    }

    public void TakeDamage(int damage)
    {
        
        currentHealth -= damage;
        if (currentHealth < 0)
        {
            currentHealth = 0;
            OnDeath.Invoke();
        }
        healthbar.UpdateBar(currentHealth,health);//maxHealth);
    }
    public void Death()
    {
        Destroy(gameObject);
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(1);
        }
    }
}
