using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealthTest : MonoBehaviour
{
    public float health = 100f;
    public int experiencePoints = 10;

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        // Thông báo cho hệ thống kinh nghiệm của nhân vật
        EXPplayer playerExperience = FindObjectOfType<EXPplayer>();
        if (playerExperience != null)
        {
            playerExperience.UpdateExperience(experiencePoints);
        }

        // Phá hủy đối tượng quái vật
        Destroy(gameObject);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
